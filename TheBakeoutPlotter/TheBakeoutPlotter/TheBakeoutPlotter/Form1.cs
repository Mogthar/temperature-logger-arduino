using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TheBakeoutPlotter
{

    public partial class MainForm : Form
    {

        private Form2 _Form2;

 

        private string sessionfolderPath = "";

        private TimeSpan trange = new TimeSpan();
        private String data = "";
        private String oldpdata = "";
        private static System.Timers.Timer aTimer;
        
        //TODO check whether these array sizes are correct (should be number of T channels)
        string[] f2data = new string[5];
        Color[] f2datacolor = new Color[5];

        // TODO what is data single line string count separated by , ??
        static int line_length = 10;
        string[] current_line = new string[line_length];
        private bool monitors = false;
        private bool atrange = true;
        private bool apresrange = true;
        private bool atemprange = true;
        private DateTime t1;
        private DateTime t2;

        private double refresh_rate = 5000;        // refresh reate of the plotting

        private double T1 = 0;
        private double T2 = 200;

        private double P1 = 1E-12;
        private double P2 = 1;

        private DateTime timestamp1;
        private DateTime timestamp2;

        public MainForm(Form2 form2)
        {
            InitializeComponent();
            _Form2 = form2;
            _Form2.Form1 = this;
            temp_monitor.Enabled = false;
            stop_plotting.Enabled = false;
        }



        // Convert the string DD-MM-YY_HH-mm-dd into DateTime
        private DateTime TimeFromString(string time)
        {
            DateTime result = new DateTime(1994, 7, 19, 12, 5, 0);
            try
            {
                Int32 dd = Convert.ToInt32(time.Substring(0, 2));
                Int32 mm = Convert.ToInt32(time.Substring(3, 2));
                Int32 yy = Convert.ToInt32(time.Substring(6, 4));
                Int32 h = Convert.ToInt32(time.Substring(11, 2));
                Int32 m = Convert.ToInt32(time.Substring(14, 2));
                Int32 s = Convert.ToInt32(time.Substring(17, 2));
                result = new DateTime(yy, mm, dd, h, m, s);
            }
            catch
            {

                result = new DateTime(1994, 7, 19, 12, 5, 0);
            }

            return result;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sessionfolderPath = folderBrowserDialog1.SelectedPath;
            }

            if (File.Exists(System.IO.Path.Combine(sessionfolderPath, "config.txt")) && Directory.Exists(System.IO.Path.Combine(sessionfolderPath, "buffer")) && Directory.Exists(System.IO.Path.Combine(sessionfolderPath, "data")))
            {
                //Prepare the timer
                aTimer = new System.Timers.Timer(500);  //made the interval short for the first run, and will set it to 5000 later
                aTimer.Elapsed += ATimer_Elapsed;                                         
                aTimer.AutoReset = false;                                                   
                aTimer.Enabled = true;

                //show all the temperature monitors
                _Form2.Show();
                monitors = true;
                temp_monitor.Enabled = false;

                //show the session location:
                label1.Text = "Session Path: " + sessionfolderPath;

                //enable/disable stuff
                browse.Enabled = false;
                stop_plotting.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid session folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //TODO make sure that we dont put the gauge info data at the end of the config file!!
        //TODO make sure that arduino puts -1 if not all channels are connected
        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool plot = false;

            //move the cursor around to stop the computer from sleeping(unsure if this actually does anything)
            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
            Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y - 1);

            //prepare the list of available buffer files
            string bufferfolderPath = System.IO.Path.Combine(sessionfolderPath, "buffer");
            DirectoryInfo d = new DirectoryInfo(bufferfolderPath);
            FileInfo[] bufferfiles = d.GetFiles("*.txt");
            Int32 l = bufferfiles.Length;
            string[] buffers = new string[l];
            for (int i = 0; i < l; i++)
            {
                buffers[i] = bufferfiles[i].Name.Replace(".txt", "");
            }
            
            //read the data from the buffers and plot if everything is ok
            if (buffers.Length>0)
            {
                //find the lates buffer
                DateTime First = TimeFromString(buffers[0]);
                Int32 First_index = 0;
                for (int i = 1; i < l; i++)
                {
                    if (TimeFromString(buffers[i]) > First)
                    {
                        First = TimeFromString(buffers[i]);
                        First_index = i;
                    }
                }
                string rbufferfilePath = System.IO.Path.Combine(bufferfolderPath, buffers[First_index] + ".txt");

                //try to access the buffer file multiple times
                int j = 0;                
                while (j < 10)
                {
                    data = "";
                    try
                    {
                        //read the data from buffer file
                        StreamReader bufferfiler = new StreamReader(rbufferfilePath);
                        data = bufferfiler.ReadToEnd();
                        bufferfiler.Close();

                        //read the config file to get timestamps and active status
                        string configfilePath = System.IO.Path.Combine(sessionfolderPath, "config.txt");
                        StreamReader configfiler = new StreamReader(configfilePath);
                        string ts1 = configfiler.ReadLine();
                        ts1 = configfiler.ReadLine();
                        timestamp1 = TimeFromString(ts1);
                        timestamp2 = new DateTime();

                        //stop timer if the session is no longer active
                        if (File.ReadLines(configfilePath).Count() == 4)
                        {
                            string ts2 = configfiler.ReadLine();
                            ts2 = configfiler.ReadLine();
                            timestamp2 = TimeFromString(ts2);

                            aTimer.AutoReset = false;
                            plot = true;
                        }
                        else if (File.ReadLines(configfilePath).Count() == 2)
                        {
                            timestamp2 = DateTime.Now;
                            aTimer.Interval = refresh_rate;
                            aTimer.AutoReset = true;
                            plot = true;
                        }
                        else
                        {
                            plot = false;
                            aTimer.AutoReset = false;
                            MessageBox.Show("Invalid Config File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        trange = timestamp2 - timestamp1;
                        if (atrange)
                        {
                            t1 = timestamp1;
                            t2 = timestamp2;
                        }

                        //give the command for plotting if everything is ok and exit the while
                        
                        j = 11;
                    }
                    catch
                    {
                        j = j + 1;
                    }
                }
            }
            
            //plot if everything is ok
            if (plot)
            {
                RefreshCharts();
            }
        }

        delegate void VoidDelegate();

        // TODO need to look at structure of data and have arduino spit out -1 for unused channels; indexing below is wrong!
        private void RefreshCharts()
        {
            if (this.t_plot.InvokeRequired)
            {
                VoidDelegate d = new VoidDelegate(RefreshCharts);
                this.Invoke(d, new object[] { });
            }
            else
            {
                //---------------------------------------------------------------
                //take care of the plots
                //---------------------------------------------------------------
                int numPoints = this.t_plot.Series["Ch1"].Points.Count;
                string[] data_lines = data.Split('\n');
                int numLines = data_lines.Length - 1;


                t_plot.ChartAreas["T_ChartArea"].AxisX.Minimum = t1.ToOADate();          
                t_plot.ChartAreas["T_ChartArea"].AxisX.Maximum = t2.ToOADate();
                
                t_plot.ChartAreas["T_ChartArea"].AxisY.Minimum = T1;
                t_plot.ChartAreas["T_ChartArea"].AxisY.Maximum = T2;

                p_plot.ChartAreas["ChartArea1"].AxisX.Minimum = t1.ToOADate();
                p_plot.ChartAreas["ChartArea1"].AxisX.Maximum = t2.ToOADate();

                p_plot.ChartAreas["ChartArea1"].AxisY.Minimum = P1;
                p_plot.ChartAreas["ChartArea1"].AxisY.Maximum = P2;

                // plot just the new data
                for (int i = numPoints; i < numLines; i++)
                {
                    current_line = data_lines[i].Split(',');
                    DateTime td_stamp = TimeFromString(current_line[0]);

                    for (int j = 1; j <= 5; j++)
                    {
                        string ch_name = "Ch" + Convert.ToString(j);
                        if (!(Convert.ToDouble(current_line[j]) == -1))
                        {
                            this.t_plot.Series[ch_name].Points.AddXY(td_stamp, Convert.ToDouble(current_line[j]));
                        }
                        // show last datapoint on the monitor!
                        if (i == numLines - 1)
                        {
                            if (!(current_line[j] == "-1"))
                            {
                                f2data[j - 1] = t_plot.Series[ch_name].LegendText + '\n' + current_line[j];
                                f2datacolor[j - 1] = t_plot.Series[ch_name].Color;
                            }
                        }

                    }
                    if (!(Convert.ToDouble(current_line[6]) == -1))
                    {
                        this.p_plot.Series["Turbo"].Points.AddXY(td_stamp, Convert.ToDouble(current_line[6]));
                    }
                    // add one more index to these
                    if (!(Convert.ToDouble(current_line[8]) == 0) && !(Convert.ToDouble(current_line[8]) == -1) && (current_line[7]=="HV_Pump" || current_line[7] == "Cell_Pump" || current_line[7] == "MOT_Pump" ))
                    {
                        this.p_plot.Series[current_line[7]].Points.AddXY(td_stamp, Convert.ToDouble(current_line[8]));
                    }
                    if (!(Convert.ToDouble(current_line[10]) == 0) && !(Convert.ToDouble(current_line[10]) == -1) && (current_line[9] == "HV_Pump" || current_line[9] == "Cell_Pump" || current_line[9] == "MOT_Pump"))
                    {
                        this.p_plot.Series[current_line[9]].Points.AddXY(td_stamp, Convert.ToDouble(current_line[10]));
                    }
                    if (!(Convert.ToDouble(current_line[12]) == 0) && !(Convert.ToDouble(current_line[12]) == -1) && (current_line[11] == "HV_Pump" || current_line[11] == "Cell_Pump" || current_line[11] == "MOT_Pump"))
                    {
                        this.p_plot.Series[current_line[11]].Points.AddXY(td_stamp, Convert.ToDouble(current_line[12]));
                    }
                }
                _Form2.RefreshMonitors(f2data,f2datacolor);

            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

            int form_height;
            int form_width;
            if (!(MainForm.ActiveForm== null))
            {
                form_height = MainForm.ActiveForm.Height;
                form_width = MainForm.ActiveForm.Width;
            }
            else
            {
                form_height = 600;
                form_width = 800;
            }
            t_plot.Height = Convert.ToInt32(Math.Truncate(form_height * Convert.ToDouble(25)/36));
            t_plot.Width = Convert.ToInt32(Math.Truncate(form_width * 0.5-50));
            t_plot.Location = new Point(30, Convert.ToInt32(Math.Truncate(form_height* Convert.ToDouble(11) / 36 - 60)));

            p_plot.Height = Convert.ToInt32(Math.Truncate(form_height * Convert.ToDouble(25) / 36));
            p_plot.Width = Convert.ToInt32(Math.Truncate(form_width * 0.5 - 50));
            p_plot.Location = new Point(60+ Convert.ToInt32(Math.Truncate(form_width * 0.5 - 50)), Convert.ToInt32(Math.Truncate(form_height * Convert.ToDouble(11) / 36 - 60)));

            at_range.Location = new Point(30, Convert.ToInt32(Math.Truncate(form_height * 0.2)));
            st_range.Location = new Point(30, Convert.ToInt32(Math.Truncate(form_height * 0.2))-30);

            label6.Location = new Point(166, Convert.ToInt32(Math.Truncate(form_height * 0.2))+5);
            label5.Location = new Point(163, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 25);

            StartDT.Location = new Point(200, Convert.ToInt32(Math.Truncate(form_height * 0.2))-30);
            EndDT.Location = new Point(200, Convert.ToInt32(Math.Truncate(form_height * 0.2)));

            atemp_range.Location = new Point(360, Convert.ToInt32(Math.Truncate(form_height * 0.2)));
            stemp_range.Location = new Point(360, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 30);

            label4.Location = new Point(465, Convert.ToInt32(Math.Truncate(form_height * 0.2)) + 5);
            label3.Location = new Point(465, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 25);

            T_max.Location = new Point(510, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 27);
            T_min.Location = new Point(510, Convert.ToInt32(Math.Truncate(form_height * 0.2))+3);

            apres_range.Location = new Point(570, Convert.ToInt32(Math.Truncate(form_height * 0.2)));
            spres_range.Location = new Point(570, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 30);

            label7.Location = new Point(680, Convert.ToInt32(Math.Truncate(form_height * 0.2)) + 5);
            label8.Location = new Point(680, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 25);

            P_max.Location = new Point(725, Convert.ToInt32(Math.Truncate(form_height * 0.2)) - 27);
            P_min.Location = new Point(725, Convert.ToInt32(Math.Truncate(form_height * 0.2)) + 3);


        }

        private void temp_monitor_Click(object sender, EventArgs e)
        {
            _Form2 = new Form2();
            _Form2.Form1 = this;
            _Form2.Show();
            monitors = true;
        }


        public void StopMonitors()
        {
            monitors = false;
            temp_monitor.Enabled = true;
        }

        private void st_range_Click(object sender, EventArgs e)
        {
            DateTime t1_new = StartDT.Value;
            DateTime t2_new = EndDT.Value;
            if (t2_new > t1_new)
            {
                t1 = t1_new;
                t2 = t2_new;
            }
            else
            {
                StartDT.Value = t1;
                EndDT.Value = t2;
                MessageBox.Show("Invalid time interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            atrange = false;
            RefreshCharts();
        }

        private void at_range_Click(object sender, EventArgs e)
        {
            t1 = timestamp1;
            t2 = timestamp2;
            atrange = true;
            RefreshCharts();
        }

        private void stemp_range_Click(object sender, EventArgs e)
        {

            double T1_new = Convert.ToDouble(T_min.Text);
            double T2_new = Convert.ToDouble(T_max.Text);

            if (T2_new > T1_new)
            {
                T1 = T1_new;
                T2 = T2_new;
            }
            else
            {
                T_min.Text = Convert.ToString(T1);
                T_max.Text = Convert.ToString(T2);
                MessageBox.Show("Invalid Temperature interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            atemprange = false;
            RefreshCharts();
        }

        private void atemp_range_Click(object sender, EventArgs e)
        {
            T1 = 0;
            T2 = 150;
            atemprange = true;
            RefreshCharts();
        }

        private void stop_plotting_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
            aTimer.Close();
            label1.Text = "Session Path:";

            for (int j = 1; j <= 5; j++)
            {
                string ch_name = "Ch" + Convert.ToString(j);
                t_plot.Series[ch_name].Points.Clear();
            }

            p_plot.Series["HV_Pump"].Points.Clear();
            p_plot.Series["MOT_Pump"].Points.Clear();
            p_plot.Series["Cell_Pump"].Points.Clear();

            T1 = 0;
            T2 = 200;
            P1 = 1E-12;
            P2 = 1;

            _Form2.Close();
            browse.Enabled = true;
            stop_plotting.Enabled = false;

        }

        private void spres_range_Click(object sender, EventArgs e)
        {
            double P1_new = Convert.ToDouble(P_min.Text);
            double P2_new = Convert.ToDouble(P_max.Text);

            if (P2_new > P1_new)
            {
                P1 = P1_new;
                P2 = P2_new;
            }
            else
            {
                P_min.Text = Convert.ToString(P1);
                P_max.Text = Convert.ToString(P2);
                MessageBox.Show("Invalid Pressure interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            apresrange = false;
            RefreshCharts();
        }

        private void apres_range_Click(object sender, EventArgs e)
        {
            P1 = 1E-12;
            P2 = 1;
            atemprange = true;
            RefreshCharts();
        }
    }
}
