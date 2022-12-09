using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBakeoutPlotter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MainForm form1;

        public MainForm Form1
        {
            get { return form1; }
            set { form1 = value; }
        }

        delegate void VoidDelegate(string[] data, Color[] cdata);
       
        public void RefreshMonitors(string[] data, Color[] cdata)
        {
            if (this.Ch1_mon.InvokeRequired && this.Ch2_mon.InvokeRequired && this.Ch3_mon.InvokeRequired && this.Ch4_mon.InvokeRequired && this.Ch5_mon.InvokeRequired)
            {
                VoidDelegate d = new VoidDelegate(RefreshMonitors);
                this.Invoke(d, new object[] {data, cdata});
            }
            else
            {
                Ch1_mon.Text = data[0];
                Ch2_mon.Text = data[1];
                Ch3_mon.Text = data[2];
                Ch4_mon.Text = data[3];
                Ch5_mon.Text = data[4];

                Ch1_mon.ForeColor = cdata[0];
                Ch2_mon.ForeColor = cdata[1];
                Ch3_mon.ForeColor= cdata[2];
                Ch4_mon.ForeColor= cdata[3];
                Ch5_mon.ForeColor= cdata[4];
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.StopMonitors();
        }
    }
}
