using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Management;
using System.Text.RegularExpressions;

namespace TheBakeoutLogger
{
    public partial class MainForm : Form
    {

        //Global variables for storing filepaths for creating folders and saving files.
        private string datafilePath = "";
        private string configfilePath = "";
        private string sessionfolderPath = "";
        private string bufferfolderPath = "";
        private string datafolderPath = "";

        //Define the timer used for periodically logging data
        private static System.Timers.Timer aTimer;

        //Define the variables for storing the info about connected and used serial ports
        private SerialPort[] ComPorts = new SerialPort[8];                                                  //Serial ports handles are stored here
        private bool[] ports = new bool[] { false, false, false, false, false, false, false, false };        //is there a port connected and stored in the n-th handle
        private Int32 NComPorts = 0;                                                                        //number of devices connected, limited to 8 so we can preallocate memory
        private Int32[] Ports_used = new Int32[4];                                                          //info about which ports are used for which device (0 = temperature; 1=pump1, 2= pump2 etc)

        //Is there a logging session in progress
        private bool session_active = false;

        //Thermocouple channels used?
        private bool[] channels = new bool[16];

        //Strings for storing names for pressure series
        private string pn1 = "";
        private string pn2 = "";
        private string pn3 = "";

        //time intervals between sedning commands to serial devices
        //TODO this is used to determine the minimum period of logging. it is chosen quite generously and I am sure the arduino can do better
        Int32 t_interval = 1000;
        Int32 p_interval = 2000;
        Int32 log_interval = 10000;
        Int32 overhead_time = 100;

        //Modified Convert.ToString() for logging date and time with zeros for single digit numbers
        private string TwoDigitNumber(Int32 n)
        {
            string s = "";
            if (n >= 0 && n < 10)
            {
                s = "0" + Convert.ToString(n);
            }
            else if (n > 9 && n < 100)
            {
                s = Convert.ToString(n);
            }
            else
            {
                s = "00";
            }
            return s;
        }

        private DateTime TimeFromString(string time)
         {
            DateTime result = new DateTime(1994, 7, 19, 12, 5, 0);
            try
            {
                
                Int32 yy = Convert.ToInt32(time.Substring(6, 4));
                
                Int32 mm = Convert.ToInt32(time.Substring(3, 2));
                Int32 dd = Convert.ToInt32(time.Substring(0, 2));
                Int32 h = Convert.ToInt32(time.Substring(11, 2));
                Int32 m = Convert.ToInt32(time.Substring(14, 2));
                Int32 s = Convert.ToInt32(time.Substring(17, 2));
                
                result = new DateTime(yy,mm,dd,h,m,s);
            }
            catch
            {
                
                result = new DateTime(1994, 7, 19, 12, 5, 0);
            }

            return result;
        }

        //Gives the string with the time and date in the format DD-MM-YYYY_hh-mm-ss
        //Method is overloaded to accept two different types of input
        private string DateAndTime()
        {
            var time = DateTime.Now;
            Int32 t_year = time.Year;
            Int32 t_month = time.Month;
            Int32 t_day = time.Day;
            Int32 t_hour = time.Hour;
            Int32 t_minute = time.Minute;
            Int32 t_second = time.Second;

            return TwoDigitNumber(t_day) + "-" + TwoDigitNumber(t_month) + "-" + Convert.ToString(t_year) + "_" + TwoDigitNumber(t_hour) + "-" + TwoDigitNumber(t_minute) + "-" + TwoDigitNumber(t_second);
        }
        private string DateAndTime(DateTime time)
        {
            Int32 t_year = time.Year;
            Int32 t_month = time.Month;
            Int32 t_day = time.Day;
            Int32 t_hour = time.Hour;
            Int32 t_minute = time.Minute;
            Int32 t_second = time.Second;

            return TwoDigitNumber(t_day) + "-" + TwoDigitNumber(t_month) + "-" + Convert.ToString(t_year) + "_" + TwoDigitNumber(t_hour) + "-" + TwoDigitNumber(t_minute) + "-" + TwoDigitNumber(t_second);
        }


        //Calculates the logging period in seconds based on the value and units supplied
        private Int32 TLog(string logunit, Int32 logperiod)
        {
            Int32 t_log = 0;
            switch (logunit)
            {
                case "s":
                    t_log = 1000 * logperiod;
                    break;
                case "min":
                    t_log = 1000 * 60 * logperiod;
                    break;
                case "h":
                    t_log = 1000 * 3600 * logperiod;

                    break;

            }
            return t_log;
        }


        //Calculates the minimum period of logging
        // TODO potentially remove channels list because it is unused
        private Int32 Timer_Min(Int32[] Ports_used_list, bool[] channels_list, Int32 tint, Int32 pint)
        {

            Int32 timer_minimum = 0;
            if (!(Ports_used_list[0] == -1))
            {
                timer_minimum += tint;
            }
            for (int j = 1; j < 4; j++)
            {
                if (!(Ports_used_list[j] == -1))
                {
                    timer_minimum += pint;
                }
            }
            return timer_minimum;
        }


        public MainForm()
        {
            InitializeComponent();
        }

        //TODO (if time) remove objects that are no longer in the gui
        //TOFO decide if we need more baudrate options
        private void MainForm_Load(object sender, EventArgs e)
        {
            temp_startlog.Enabled = false;
            pump1_startlog.Enabled = false;
            pump2_startlog.Enabled = false;
            pump3_startlog.Enabled = false;
            temp_stoplog.Enabled = false;
            pump1_stoplog.Enabled = false;
            pump2_stoplog.Enabled = false;
            pump3_stoplog.Enabled = false;
            session_stop.Enabled = false;

            temp_dev.Items.Clear();
            pump1_dev.Items.Clear();
            pump2_dev.Items.Clear();
            pump3_dev.Items.Clear();

            temp_dev.Items.Add("None");
            pump1_dev.Items.Add("None");
            pump2_dev.Items.Add("None");
            pump3_dev.Items.Add("None");

            temp_dev.SelectedItem = "None";
            pump1_dev.SelectedItem = "None";
            pump2_dev.SelectedItem = "None";
            pump3_dev.SelectedItem = "None";

            session_name.Text = "Logging_Session_DD-MM-YYYY_hh-mm-ss";
            string default_path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            session_location.Text = default_path;

            string[] baudrates = new string[] { "9600", "115200" };
            baud_rate.Items.AddRange(baudrates);
            baud_rate.SelectedItem = "9600";

            string[] timeunits = new string[] { "s", "min", "h" };
            session_logunit.Items.AddRange(timeunits);
            session_logunit.SelectedItem = "s";
            session_logperiod.Text = "15";

            channels = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
            Ports_used = new Int32[] { -1, -1, -1, -1};

        }

        //Populates the list with the available serial port devices
        private void dev_refresh_Click(object sender, EventArgs e)
        {
            dev_list.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                dev_list.Items.Add(s);
            }

        }

        //Establishes a new serial connection
        // CHANGE inside
        private void dev_connect_Click(object sender, EventArgs e)
        {
            if (!(dev_list.SelectedItem == null))        //check if anything is selected on the list
            {
                //Initialize a SerialPort Variable
                SerialPort ComPort = new SerialPort();
                if (!(NComPorts == 8))    //Check if there is room for a new device
                {
                    string portname = Convert.ToString(dev_list.SelectedItem);  //get the device ID from he list

                    // CHANGE - removed and condition and added an if condition
                    bool already_connected = false;          //Check if the device is already connected
                    for (int i = 0; (i < 8); i++)
                    {
                        if (ports[i])
                        {
                            if (portname == ComPorts[i].PortName)
                            {
                                already_connected = true;
                            }
                        }
                    }
                    // CHANGE added increment to NComPorts
                    if (!already_connected) //If OK, connect the device to the first available slot in ComPorts[]
                    {
                        Int32 N_port = -1;
                        Int32 i = 0;
                        while (N_port < 0)
                        {
                            if (!ports[i])
                            {
                                N_port = i;
                            }
                            i++;
                        }
                        Int32 bdrt = Convert.ToInt32(baud_rate.SelectedItem);
                        ComPorts[N_port] = new SerialPort(portname, bdrt);                            //Connect to the serial device, use baudrate from combo box
                        ComPorts[N_port].Open();

                        ports[N_port] = true;
                        NComPorts += 1;
                    }
                    else
                    {
                        MessageBox.Show("Device already connected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    dev_connected.Items.Add(Convert.ToString(dev_list.SelectedItem));
                    temp_dev.Items.Add(dev_list.SelectedItem);
                    pump1_dev.Items.Add(dev_list.SelectedItem);
                    pump2_dev.Items.Add(dev_list.SelectedItem);
                    pump3_dev.Items.Add(dev_list.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Maximum number of connected devices reached", "Can't connect device", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }


        //disconnects a selected device
        //TODO (if time) remove extra pumps
        // CHANGE inside
        private void dev_disconnect_Click(object sender, EventArgs e)
        {
            if (!(dev_connected.SelectedItem == null))     //check if anything is selected from the list
            {
                string portname = Convert.ToString(dev_connected.SelectedItem);    //get the name of the device to be disconneceted

                //CHANGE removed and and added an if and decremented number of connected devices
                for (int i = 0; (i < 8); i++)
                {
                    if (ports[i])
                    {
                        if (portname == ComPorts[i].PortName)                       //Find the device in ComPorts[] and close it
                        {
                            ComPorts[i].Close();
                            ports[i] = false;
                            NComPorts -= 1;

                            //Check if the device is currently logging and stop the log in that case.
                            if (i == Ports_used[0])
                            {
                                temp_stoplog_Click(dev_disconnect, new EventArgs());
                                temp_startlog.Enabled = false;
                            }

                            if (i == Ports_used[1])
                            {
                                pump1_stoplog_Click(dev_disconnect, new EventArgs());
                                pump1_startlog.Enabled = false;
                            }

                            if (i == Ports_used[2])
                            {
                                pump2_stoplog_Click(dev_disconnect, new EventArgs());
                                pump2_startlog.Enabled = false;
                            }

                            if (i == Ports_used[3])
                            {
                                pump3_stoplog_Click(dev_disconnect, new EventArgs());
                                pump3_startlog.Enabled = false;
                            }
                        }
                    }
                }

                //Remove the device from the lists
                object ritem = new object();
                foreach (object item in temp_dev.Items)
                {
                                
                    if (Convert.ToString(item)== "None" && Convert.ToString(temp_dev.SelectedItem) == Convert.ToString(dev_connected.SelectedItem)) //change the selected item to "None" and status to "Inactive"
                    {
                        temp_dev.SelectedItem = item;
                        temp_status.BackColor = System.Drawing.Color.Blue;
                        temp_status.ForeColor = System.Drawing.Color.White;
                        temp_status.Text = "Inactive";
                    }
                    if (Convert.ToString(item) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        ritem = item;
                    }

                }
                temp_dev.Items.Remove(ritem);   //remove the item
                foreach (object item in pump1_dev.Items)
                {

                    if (Convert.ToString(item) == "None" && Convert.ToString(pump1_dev.SelectedItem) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        pump1_dev.SelectedItem = item;
                        pump1_status.BackColor = System.Drawing.Color.Blue;
                        pump1_status.ForeColor = System.Drawing.Color.White;
                        pump1_status.Text = "Inactive";
                    }
                    if (Convert.ToString(item) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        ritem = item;
                    }

                }
                pump1_dev.Items.Remove(ritem);
                foreach (object item in pump2_dev.Items)
                {

                    if (Convert.ToString(item) == "None" && Convert.ToString(pump2_dev.SelectedItem) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        pump2_dev.SelectedItem = item;
                        pump2_status.BackColor = System.Drawing.Color.Blue;
                        pump2_status.ForeColor = System.Drawing.Color.White;
                        pump2_status.Text = "Inactive";
                    }
                    if (Convert.ToString(item) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        ritem = item;
                    }

                }
                pump2_dev.Items.Remove(ritem);
                foreach (object item in pump3_dev.Items)
                {

                    if (Convert.ToString(item) == "None" && Convert.ToString(pump3_dev.SelectedItem) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        pump3_dev.SelectedItem = item;
                        pump3_status.BackColor = System.Drawing.Color.Blue;
                        pump3_status.ForeColor = System.Drawing.Color.White;
                        pump3_status.Text = "Inactive";
                    }
                    if (Convert.ToString(item) == Convert.ToString(dev_connected.SelectedItem))
                    {
                        ritem = item;
                    }

                }
                pump3_dev.Items.Remove(ritem);
                dev_connected.Items.Remove(dev_connected.SelectedItem);
            }
        }

        
        //Start a logging session
        //TODO (if time) remove extra pumps
        private void session_start_Click(object sender, EventArgs e)
        {
            string mainfolderPath = session_location.Text;

            if (Directory.Exists(mainfolderPath))
            {
                string sessionName = session_name.Text;


                //Prepare the folders for saving files
                if (!(Path.GetInvalidFileNameChars().Any(sessionName.Contains)) && !(sessionName == ""))
                {
                    if (sessionName == "Logging_Session_DD-MM-YYYY_hh-mm-ss")
                    {
                        sessionName = "Logging_Session_" + DateAndTime();
                    }
                }
                else
                {
                    sessionName = "Logging_Session_" + DateAndTime();
                }

                sessionfolderPath = System.IO.Path.Combine(mainfolderPath, sessionName);
                System.IO.Directory.CreateDirectory(sessionfolderPath);
                datafolderPath = System.IO.Path.Combine(sessionfolderPath, "data");
                System.IO.Directory.CreateDirectory(datafolderPath);
                bufferfolderPath = System.IO.Path.Combine(sessionfolderPath, "buffer");
                System.IO.Directory.CreateDirectory(bufferfolderPath);

                datafilePath = System.IO.Path.Combine(datafolderPath, "data.txt");
                FileStream datafile = System.IO.File.Create(datafilePath);
                datafile.Close();

                configfilePath = System.IO.Path.Combine(sessionfolderPath, "config.txt");
                FileStream configfile = System.IO.File.Create(configfilePath);
                configfile.Close();

                StreamWriter configfilew = new StreamWriter(configfilePath);
                configfilew.WriteLine("start");
                configfilew.WriteLine(DateAndTime());
                configfilew.Close();

                session_start.Enabled = false;
                session_stop.Enabled = true;
                session_location.Enabled = false;
                session_browse.Enabled = false;
                browseoldsession.Enabled = false;

                //Prepare the device controls
                if (!(Convert.ToString(temp_dev.SelectedItem) == "None"))
                {
                    temp_startlog.Enabled = true;

                    temp_status.BackColor = System.Drawing.Color.Red;
                    temp_status.ForeColor = System.Drawing.Color.White;
                    temp_status.Text = "Stand-By";

                }
                if (!(Convert.ToString(pump1_dev.SelectedItem) == "None"))
                {
                    pump1_startlog.Enabled = true;

                    pump1_status.BackColor = System.Drawing.Color.Red;
                    pump1_status.ForeColor = System.Drawing.Color.White;
                    pump1_status.Text = "Stand-By";
                }
                if (!(Convert.ToString(pump2_dev.SelectedItem) == "None"))
                {
                    pump2_startlog.Enabled = true;

                    pump2_status.BackColor = System.Drawing.Color.Red;
                    pump2_status.ForeColor = System.Drawing.Color.White;
                    pump2_status.Text = "Stand-By";
                }
                if (!(Convert.ToString(pump3_dev.SelectedItem) == "None"))
                {
                    pump3_startlog.Enabled = true;

                    pump3_status.BackColor = System.Drawing.Color.Red;
                    pump3_status.ForeColor = System.Drawing.Color.White;
                    pump3_status.Text = "Stand-By";
                }

                //Prepare the timer
                Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text)); // period in seconds

                aTimer = new System.Timers.Timer(t_log);
                log_interval = t_log;             
                aTimer.Elapsed += ATimer_Elapsed;                                         //Link the timer to an event; this is called whenever timer ticked
                aTimer.AutoReset = true;                                                  //Make sure that the timer repeatedly raises the event 
                aTimer.Enabled = true;                                                    //Run the Timer
                session_active = true;
                session_current.Text = "Session started on " + DateAndTime();
            }
            else
            {
                MessageBox.Show("Invalid file path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Do a round of logging every time the timer ticks
        //CHANGE inside
        //TODO inside
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            

            //assign these intervals at the beggining in case something changes during this procedure
            Int32 tint = t_interval;
            Int32 pint = p_interval;

            int[] Ports_used1 = new int[4] {Ports_used[0], Ports_used[1], Ports_used[2], Ports_used[3] };

            //Read the old data file
            StreamReader datafiler = new StreamReader(datafilePath);
            string data = datafiler.ReadToEnd();
            datafiler.Close();

            string new_data = DateAndTime();

            string port_write = "";
            char temp_port_write = 'a';
            string port_read = "";
            
            //CHANGE - completely removed the tc unit section and changed this condition to a standalone if
            if (!(aTimer.Interval==log_interval))
            {
                aTimer.Interval = log_interval;
            }

            //Read the temperature
            //Currently sending in just one temperature. Will need to change this based on what arduino sends
            string temp_data = ",-1,-1,-1,-1,-1";
            Int32 np = Ports_used1[0];
            if (!(np==-1))
            {
                try
                {
                    ComPorts[np].DiscardOutBuffer();
                    //System.Threading.Thread.Sleep(tint / 10);
                    ComPorts[np].DiscardInBuffer();
                    //System.Threading.Thread.Sleep(tint / 10);

                    ComPorts[np].WriteLine("a");
                    System.Threading.Thread.Sleep(tint * 5 / 10);

                    port_read = ComPorts[np].ReadLine().Replace("\n", "").Replace("\r", "");
                    // TODO temp data might need processing
                    temp_data = port_read;
                    System.Threading.Thread.Sleep(tint * 5 / 10);
                }
                catch
                {
                    Console.WriteLine("Misread data on arduino; Timestamp: " + DateAndTime());    
                }
            }

            new_data = new_data + temp_data;

            //read the pressure from pump1 
            np = Ports_used1[1];
            double P1 = -1;
            if (!(np == -1))
            {
                try
                {
                    port_write = "Tb\r\n";
                    ComPorts[np].Write(port_write);    
                   
                    System.Threading.Thread.Sleep(pint / 2);
                    port_read = ComPorts[np].ReadExisting();
                    P1 = Convert.ToDouble(port_read);
                    System.Threading.Thread.Sleep(pint / 2);

                }
                catch
                {
                    Console.WriteLine("Misread data on pump1; Timestamp: " + DateAndTime());
                }
            }
            new_data = new_data + "," + pn1 + "," + Convert.ToString(P1);



            //read the pressure from pump2 
            np = Ports_used1[2];
            double P2 = -1;
            if (!(np == -1))
            {
                try
                {
                    port_write = "Tb\r\n";
                    ComPorts[np].Write(port_write);

                    System.Threading.Thread.Sleep(pint / 2);
                    port_read = ComPorts[np].ReadExisting();
                    P2 = Convert.ToDouble(port_read);
                    System.Threading.Thread.Sleep(pint / 2);
                }
                catch
                {
                    Console.WriteLine("Misread data on pump2; Timestamp: " + DateAndTime());
                }
            }
            new_data = new_data + "," + pn2 + "," + Convert.ToString(P2);

            //read the pressure from pump3 
            np = Ports_used1[3];
            double P3 = -1;
            if (!(np == -1))
            {


                try
                {
                    port_write = "Tb\r\n";
                    ComPorts[np].Write(port_write);

                    System.Threading.Thread.Sleep(pint / 2);
                    port_read = ComPorts[np].ReadExisting();
                    P3 = Convert.ToDouble(port_read);
                    System.Threading.Thread.Sleep(pint / 2);
                }
                catch
                {
                    Console.WriteLine("Misread data on pump3; Timestamp: " + DateAndTime());
                }

            }
            new_data = new_data + "," + pn3 + "," + Convert.ToString(P3);

            int j = 0;
            while (j < 10)
            {
                try
                {
                    StreamWriter datafilew = new StreamWriter(datafilePath);
                    datafilew.Write(data);
                    datafilew.WriteLine(new_data);
                    datafilew.Close();
                    j = 11;
                }
                catch
                {
                    j++;
                }
            }

            
            string bufferfilePath = System.IO.Path.Combine(bufferfolderPath, DateAndTime()+".txt");

            j = 0;
            while (j < 10)
            {
                try
                {
                    StreamWriter bufferfilew = new StreamWriter(bufferfilePath);
                    bufferfilew.Write(data);
                    bufferfilew.WriteLine(new_data);
                    bufferfilew.Close();
                    j = 11;
                }
                catch
                {
                    j++;
                }
            }
           

            Int32 l = 0;
            string[] buffers = new string[l];
            j = 0;
            while (j < 10)
            {
                try
                {
                    DirectoryInfo d = new DirectoryInfo(bufferfolderPath);
                    FileInfo[] bufferfiles = d.GetFiles("*.txt");
                    l = bufferfiles.Length;
                    buffers = new string[l];
                    for (int i = 0; i < l; i++)
                    {
                        buffers[i] = bufferfiles[i].Name.Replace(".txt", "");
                    }
                    j = 11;
                }
                catch
                {
                    j++;
                }
            }

            

            while (l > 10)
            {
                
                DateTime First = TimeFromString(buffers[0]);
                Int32 First_index = 0;
                
                for (int i = 1; i < l; i++)
                {
                    
                    if (TimeFromString(buffers[i]) < First)
                    {
                        
                        First = TimeFromString(buffers[i]);
                        First_index = i;
                        
                    }
                }
                string delbufferfilePath = System.IO.Path.Combine(bufferfolderPath, buffers[First_index] + ".txt");

                
                j = 0;
                while (j < 10)
                {
                    try
                    {
                        File.Delete(delbufferfilePath);
                        j = 11;
                    }
                    catch
                    {
                        j++;
                    }
                }
                j = 0;
                
                while (j < 10)
                {
                    try
                    {
                        DirectoryInfo d = new DirectoryInfo(bufferfolderPath);
                        FileInfo[] bufferfiles = d.GetFiles("*.txt");
                        l = bufferfiles.Length;

                        for (int i = 0; i < l; i++)
                        {
                            buffers[i] = bufferfiles[i].Name.Replace(".txt", "");
                        }
                        j = 11;
                    }
                    catch
                    {
                        j++;
                    }
                }
            }
            
        }

        // TODO (if time) remove extra pump references
        private void session_stop_Click(object sender, EventArgs e)
        {
            session_start.Enabled = true;
            session_stop.Enabled = false;
            session_location.Enabled = true;
            session_browse.Enabled = true;
            browseoldsession.Enabled = true;

            temp_startlog.Enabled = false;
            pump1_startlog.Enabled = false;
            pump2_startlog.Enabled = false;
            pump3_startlog.Enabled = false;

            Ports_used[0] = -1;
            Ports_used[1] = -1;
            Ports_used[2] = -1;
            Ports_used[3] = -1;


            aTimer.Stop();                                                           //Stop the Timer
            aTimer.Dispose();                                                        //Release the resources used by the timer.
            session_active = false;
            session_current.Text = "No Active Session";

            StreamWriter configfilew = File.AppendText(configfilePath);
         
            configfilew.WriteLine("end");
            configfilew.WriteLine(DateAndTime());
            configfilew.Close();
        }

        private void session_browse_Click(object sender, EventArgs e)
        {
            session_name.Enabled = true;
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                session_location.Text = folderPath;
            }
        }

        // TODO arbitrary choice of time interval inside 
        // CHANGE inside, removed gauge business
        private void temp_startlog_Click(object sender, EventArgs e)
        {
           
            temp_stoplog.Enabled = true;
            temp_startlog.Enabled = false;
            temp_status.BackColor = System.Drawing.Color.Green;
            temp_status.ForeColor = System.Drawing.Color.Black;
            temp_status.Text = "Logging";
            temp_dev.Enabled = false;

            string portname = Convert.ToString(temp_dev.SelectedItem);

            // CHANGE removed and and added if
            for (int i = 0; (i < 8); i++)
            {
                if (ports[i])
                {
                    if (portname == ComPorts[i].PortName)
                    {
                        Ports_used[0] = i;

                        Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text));

                        Int32 timer_minimum = Timer_Min(Ports_used, channels, t_interval, p_interval);

                        // this 500 is quite arbitrary
                        if (timer_minimum + overhead_time > t_log)
                        {
                            Int32 timer_period = 1000 * ((timer_minimum + overhead_time - 1) / 1000 + 1); // in miliseconds
                            aTimer.Interval = timer_period;
                            log_interval = timer_period;
                            MessageBox.Show("Logging interval changed to allow for all operations to be completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            session_logunit.SelectedItem = "s";
                            session_logperiod.Text = Convert.ToString(timer_period / 1000);

                        }
                        else
                        {
                            aTimer.Interval = t_log;

                        }

                    }
                }
            }

        }

        private void pump1_startlog_Click(object sender, EventArgs e)
        {
            
            pump1_stoplog.Enabled = true;
            pump1_startlog.Enabled = false;
            pump1_status.BackColor = System.Drawing.Color.Green;
            pump1_status.ForeColor = System.Drawing.Color.Black;
            pump1_status.Text = "Logging";
            pump1_dev.Enabled = false;
            pn1 = p_name1.Text;
            p_name1.Enabled = false;

            string portname = Convert.ToString(pump1_dev.SelectedItem);

            for (int i = 0; (i < 8); i++)
            {
                if (ports[i])
                {
                    if (portname == ComPorts[i].PortName)
                    {
                        Ports_used[1] = i;

                        Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text));

                        Int32 timer_minimum = Timer_Min(Ports_used, channels, t_interval, p_interval);

                        if (timer_minimum + overhead_time > t_log)
                        {
                            Int32 timer_period = 1000 * ((timer_minimum + overhead_time - 1) / 1000 + 1); // in miliseconds
                            aTimer.Interval = timer_period;
                            log_interval = timer_period;
                            MessageBox.Show("Logging interval changed to allow for all operations to be completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            session_logunit.SelectedItem = "s";
                            session_logperiod.Text = Convert.ToString(timer_period / 1000);

                        }
                        else
                        {
                            aTimer.Interval = t_log;

                        }

                    }
                }
            }
        }

        // TODO (if time) get rid off the pump2 and 3
        private void pump2_startlog_Click(object sender, EventArgs e)
        {
            
            pump2_stoplog.Enabled = true;
            pump2_startlog.Enabled = false;
            pump2_status.BackColor = System.Drawing.Color.Green;
            pump2_status.ForeColor = System.Drawing.Color.Black;
            pump2_status.Text = "Logging";
            pump2_dev.Enabled = false;
            pn2 = p_name2.Text;
            p_name2.Enabled = false;

            string portname = Convert.ToString(pump2_dev.SelectedItem);

            for (int i = 0; (i < 8); i++)
            {
                if (ports[i])
                {
                    if (portname == ComPorts[i].PortName)
                    {
                        Ports_used[2] = i;
                    }

                    Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text));

                    Int32 timer_minimum = Timer_Min(Ports_used, channels, t_interval, p_interval);

                    if (timer_minimum + overhead_time > t_log)
                    {
                        Int32 timer_period = 1000 * ((timer_minimum + overhead_time - 1) / 1000 + 1); // in miliseconds
                        aTimer.Interval = timer_period;
                        log_interval = timer_period;
                        MessageBox.Show("Logging interval changed to allow for all operations to be completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        session_logunit.SelectedItem = "s";
                        session_logperiod.Text = Convert.ToString(timer_period / 1000);

                    }
                    else
                    {
                        aTimer.Interval = t_log;

                    }
                }
            }

        }

        private void pump3_startlog_Click(object sender, EventArgs e)
        {
            
            pump3_stoplog.Enabled = true;
            pump3_startlog.Enabled = false;
            pump3_status.BackColor = System.Drawing.Color.Green;
            pump3_status.ForeColor = System.Drawing.Color.Black;
            pump3_status.Text = "Logging";
            pump3_dev.Enabled = false;
            pn3 = p_name3.Text;
            p_name3.Enabled = false;
            string portname = Convert.ToString(pump3_dev.SelectedItem);

            for (int i = 0; (i < 8); i++)
            {
                if (ports[i])
                {
                    if (portname == ComPorts[i].PortName)
                    {
                        Ports_used[3] = i;
                    }

                    Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text));

                    Int32 timer_minimum = Timer_Min(Ports_used, channels, t_interval, p_interval);

                    if (timer_minimum + overhead_time > t_log)
                    {
                        Int32 timer_period = 1000 * ((timer_minimum + overhead_time - 1) / 1000 + 1);
                        aTimer.Interval = timer_period;
                        log_interval = timer_period;
                        MessageBox.Show("Logging interval changed to allow for all operations to be completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        session_logunit.SelectedItem = "s";
                        session_logperiod.Text = Convert.ToString(timer_period / 1000);

                    }
                    else
                    {
                        aTimer.Interval = t_log;

                    }
                }
            }
        }

        private void temp_stoplog_Click(object sender, EventArgs e)
        {
            temp_stoplog.Enabled = false;
            temp_startlog.Enabled = true;
            temp_status.BackColor = System.Drawing.Color.Red;
            temp_status.ForeColor = System.Drawing.Color.White;
            temp_status.Text = "Stand-By";
            temp_dev.Enabled = true;
            Ports_used[0] = -1;
        }

        private void pump1_stoplog_Click(object sender, EventArgs e)
        {
           
            pump1_stoplog.Enabled = false;
            pump1_startlog.Enabled = true;
            pump1_status.BackColor = System.Drawing.Color.Red;
            pump1_status.ForeColor = System.Drawing.Color.White;
            pump1_status.Text = "Stand-By";
            pump1_dev.Enabled = true;
            p_name1.Enabled = true;
            pn1 = "";

            Ports_used[1] = -1;
        }

        //TODO (if time) can remove the next two methods since we only have 1 pump
        private void pump2_stoplog_Click(object sender, EventArgs e)
        {
            
            pump2_stoplog.Enabled = false;
            pump2_startlog.Enabled = true;
            pump2_status.BackColor = System.Drawing.Color.Red;
            pump2_status.ForeColor = System.Drawing.Color.White;
            pump2_status.Text = "Stand-By";
            pump2_dev.Enabled = true;
            p_name2.Enabled = true;
            pn2 = "";
            Ports_used[2] = -1;
        }

        private void pump3_stoplog_Click(object sender, EventArgs e)
        {
            
            pump3_stoplog.Enabled = false;
            pump3_startlog.Enabled = true;
            pump3_status.BackColor = System.Drawing.Color.Red;
            pump3_status.ForeColor = System.Drawing.Color.White;
            pump3_status.Text = "Stand-By";
            pump3_dev.Enabled = true;
            p_name3.Enabled = true;
            pn3 = "";

            Ports_used[3] = -1;
        }

        private void temp_dev_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(temp_dev.SelectedItem) == "None")
            {
                temp_startlog.Enabled = false;
                temp_status.BackColor = System.Drawing.Color.Blue;
                temp_status.ForeColor = System.Drawing.Color.White;
                temp_status.Text = "Inactive";
            }
            else
            {
                if (session_active)
                {
                    temp_startlog.Enabled = true;
                }
                temp_status.BackColor = System.Drawing.Color.Red;
                temp_status.ForeColor = System.Drawing.Color.White;
                temp_status.Text = "Stand-By";
            }
        }

        private void pump1_dev_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(pump1_dev.SelectedItem) == "None")
            {
                pump1_startlog.Enabled = false;
                pump1_status.BackColor = System.Drawing.Color.Blue;
                pump1_status.ForeColor = System.Drawing.Color.White;
                pump1_status.Text = "Inactive";
            }
            else
            {
                if (session_active)
                {
                    pump1_startlog.Enabled = true;
                }
                pump1_status.BackColor = System.Drawing.Color.Red;
                pump1_status.ForeColor = System.Drawing.Color.White;
                pump1_status.Text = "Stand-By";

            }
           
        }

        // TODO (if time) get rid of the pump 2 3
        private void pump2_dev_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if (Convert.ToString(pump2_dev.SelectedItem) == "None")
            {
                pump2_startlog.Enabled = false;
                pump2_status.BackColor = System.Drawing.Color.Blue;
                pump2_status.ForeColor = System.Drawing.Color.White;
                pump2_status.Text = "Inactive";
            }
            else
            {
                if (session_active)
                {
                    pump2_startlog.Enabled = true;
                }
                pump2_status.BackColor = System.Drawing.Color.Red;
                pump2_status.ForeColor = System.Drawing.Color.White;
                pump2_status.Text = "Stand-By";

            }

        }

        private void pump3_dev_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
            if (Convert.ToString(pump3_dev.SelectedItem) == "None")
            {
                pump3_startlog.Enabled = false;
                pump3_status.BackColor = System.Drawing.Color.Blue;
                pump3_status.ForeColor = System.Drawing.Color.White;
                pump3_status.Text = "Inactive";
            }
            else
            {
                if (session_active)
                {
                    pump3_startlog.Enabled = true;
                }
                pump3_status.BackColor = System.Drawing.Color.Red;
                pump3_status.ForeColor = System.Drawing.Color.White;
                pump3_status.Text = "Stand-By";

            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(aTimer == null))
            {
                if (aTimer.Enabled)
                {
                    aTimer.Stop();
                    aTimer.Dispose();
                }
            }

            if (session_active)
            {
                session_active = false;
            }

            for (int i = 0; i < 8; i++)
            {

                if (!(ComPorts[i] == null))
                {
                    if (ComPorts[i].IsOpen)
                    {
                        ComPorts[i].Close();
                        ComPorts[i].Dispose();
                    }
                }
            }
        }

        private void t_qperiod_ValueChanged(object sender, EventArgs e)
        {
            t_interval = Convert.ToInt32(t_qperiod.Value);
        }

        private void p_qperiod_ValueChanged(object sender, EventArgs e)
        {
            p_interval = Convert.ToInt32(p_qperiod.Value);
        }

        // TODO (if time) remove pump 2 3
        private void browseoldsession_Click(object sender, EventArgs e)
        {
            session_name.Enabled = false;
            string sessionName = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sessionfolderPath = folderBrowserDialog1.SelectedPath;
                sessionName = Path.GetFileName(sessionfolderPath);
                session_location.Text = Directory.GetParent(sessionfolderPath).FullName;

            }

            string mainfolderPath = session_location.Text;
            configfilePath = System.IO.Path.Combine(sessionfolderPath, "config.txt");
            bufferfolderPath = System.IO.Path.Combine(sessionfolderPath, "buffer");
            datafolderPath = System.IO.Path.Combine(sessionfolderPath, "data");
            datafilePath = System.IO.Path.Combine(datafolderPath, "data.txt");

            if (Directory.Exists(bufferfolderPath) && Directory.Exists(datafolderPath) && File.Exists(configfilePath) && File.Exists(datafilePath))
            {

                StreamReader configfiler = new StreamReader(configfilePath);
                string configfile_line1 = configfiler.ReadLine();
                string configfile_line2 = configfiler.ReadLine();
                configfiler.Close();
                StreamWriter configfilew = new StreamWriter(configfilePath);
                configfilew.WriteLine(configfile_line1);
                configfilew.WriteLine(configfile_line2);
                configfilew.Close();

                session_start.Enabled = false;
                session_stop.Enabled = true;
                session_location.Enabled = false;
                session_browse.Enabled = false;
                browseoldsession.Enabled = false;

                //Prepare the device controls
                if (!(Convert.ToString(temp_dev.SelectedItem) == "None"))
                {
                    temp_startlog.Enabled = true;

                    temp_status.BackColor = System.Drawing.Color.Red;
                    temp_status.ForeColor = System.Drawing.Color.White;
                    temp_status.Text = "Stand-By";

                }
                if (!(Convert.ToString(pump1_dev.SelectedItem) == "None"))
                {
                    pump1_startlog.Enabled = true;

                    pump1_status.BackColor = System.Drawing.Color.Red;
                    pump1_status.ForeColor = System.Drawing.Color.White;
                    pump1_status.Text = "Stand-By";
                }
                if (!(Convert.ToString(pump2_dev.SelectedItem) == "None"))
                {
                    pump2_startlog.Enabled = true;

                    pump2_status.BackColor = System.Drawing.Color.Red;
                    pump2_status.ForeColor = System.Drawing.Color.White;
                    pump2_status.Text = "Stand-By";
                }
                if (!(Convert.ToString(pump3_dev.SelectedItem) == "None"))
                {
                    pump3_startlog.Enabled = true;

                    pump3_status.BackColor = System.Drawing.Color.Red;
                    pump3_status.ForeColor = System.Drawing.Color.White;
                    pump3_status.Text = "Stand-By";
                }

                //Prepatre the timer
                Int32 t_log = TLog(Convert.ToString(session_logunit.SelectedItem), Convert.ToInt32(session_logperiod.Text));

                aTimer = new System.Timers.Timer(t_log);
                log_interval = t_log;
                aTimer.Elapsed += ATimer_Elapsed;                                         //Link the timer to an event
                aTimer.AutoReset = true;                                                  //Make sure that the timer repeatedly raises the event 
                aTimer.Enabled = true;                                                    //Run the Timer
                session_active = true;
                session_current.Text = "Session started on " + configfile_line2;
            }
            else
            {
                MessageBox.Show("Invalid file path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}
