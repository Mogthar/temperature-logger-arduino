namespace TheBakeoutLogger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dev_list = new System.Windows.Forms.ListBox();
            this.dev_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dev_connect = new System.Windows.Forms.Button();
            this.dev_connected = new System.Windows.Forms.ListBox();
            this.dev_disconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.temp_dev = new System.Windows.Forms.ComboBox();
            this.pump1_dev = new System.Windows.Forms.ComboBox();
            this.pump2_dev = new System.Windows.Forms.ComboBox();
            this.pump3_dev = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.temp_startlog = new System.Windows.Forms.Button();
            this.temp_stoplog = new System.Windows.Forms.Button();
            this.pump1_startlog = new System.Windows.Forms.Button();
            this.pump2_startlog = new System.Windows.Forms.Button();
            this.pump3_startlog = new System.Windows.Forms.Button();
            this.pump1_stoplog = new System.Windows.Forms.Button();
            this.pump2_stoplog = new System.Windows.Forms.Button();
            this.pump3_stoplog = new System.Windows.Forms.Button();
            this.temp_status = new System.Windows.Forms.Label();
            this.pump1_status = new System.Windows.Forms.Label();
            this.pump2_status = new System.Windows.Forms.Label();
            this.pump3_status = new System.Windows.Forms.Label();
            this.session_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.session_location = new System.Windows.Forms.TextBox();
            this.session_browse = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.session_logperiod = new System.Windows.Forms.TextBox();
            this.session_logunit = new System.Windows.Forms.ComboBox();
            this.session_start = new System.Windows.Forms.Button();
            this.session_stop = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.session_current = new System.Windows.Forms.Label();
            this.baud_rate = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.p_name1 = new System.Windows.Forms.TextBox();
            this.p_name2 = new System.Windows.Forms.TextBox();
            this.p_name3 = new System.Windows.Forms.TextBox();
            this.browseoldsession = new System.Windows.Forms.Button();
            this.t_qperiod = new System.Windows.Forms.NumericUpDown();
            this.p_qperiod = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t_qperiod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_qperiod)).BeginInit();
            this.SuspendLayout();
            // 
            // dev_list
            // 
            this.dev_list.FormattingEnabled = true;
            this.dev_list.ItemHeight = 16;
            this.dev_list.Location = new System.Drawing.Point(20, 31);
            this.dev_list.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dev_list.Name = "dev_list";
            this.dev_list.Size = new System.Drawing.Size(159, 84);
            this.dev_list.TabIndex = 0;
            // 
            // dev_refresh
            // 
            this.dev_refresh.Location = new System.Drawing.Point(20, 123);
            this.dev_refresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dev_refresh.Name = "dev_refresh";
            this.dev_refresh.Size = new System.Drawing.Size(160, 31);
            this.dev_refresh.TabIndex = 1;
            this.dev_refresh.Text = "Refresh Device List";
            this.dev_refresh.UseVisualStyleBackColor = true;
            this.dev_refresh.Click += new System.EventHandler(this.dev_refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Device List:";
            // 
            // dev_connect
            // 
            this.dev_connect.Location = new System.Drawing.Point(20, 159);
            this.dev_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dev_connect.Name = "dev_connect";
            this.dev_connect.Size = new System.Drawing.Size(160, 31);
            this.dev_connect.TabIndex = 3;
            this.dev_connect.Text = "Connect to Device";
            this.dev_connect.UseVisualStyleBackColor = true;
            this.dev_connect.Click += new System.EventHandler(this.dev_connect_Click);
            // 
            // dev_connected
            // 
            this.dev_connected.FormattingEnabled = true;
            this.dev_connected.ItemHeight = 16;
            this.dev_connected.Location = new System.Drawing.Point(221, 31);
            this.dev_connected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dev_connected.Name = "dev_connected";
            this.dev_connected.Size = new System.Drawing.Size(159, 84);
            this.dev_connected.TabIndex = 4;
            // 
            // dev_disconnect
            // 
            this.dev_disconnect.Location = new System.Drawing.Point(221, 123);
            this.dev_disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dev_disconnect.Name = "dev_disconnect";
            this.dev_disconnect.Size = new System.Drawing.Size(160, 31);
            this.dev_disconnect.TabIndex = 5;
            this.dev_disconnect.Text = "Disconnect Device";
            this.dev_disconnect.UseVisualStyleBackColor = true;
            this.dev_disconnect.Click += new System.EventHandler(this.dev_disconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Connected Devices:";
            // 
            // temp_dev
            // 
            this.temp_dev.FormattingEnabled = true;
            this.temp_dev.Location = new System.Drawing.Point(181, 276);
            this.temp_dev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.temp_dev.Name = "temp_dev";
            this.temp_dev.Size = new System.Drawing.Size(104, 24);
            this.temp_dev.TabIndex = 7;
            this.temp_dev.SelectionChangeCommitted += new System.EventHandler(this.temp_dev_SelectionChangeCommitted);
            // 
            // pump1_dev
            // 
            this.pump1_dev.FormattingEnabled = true;
            this.pump1_dev.Location = new System.Drawing.Point(181, 309);
            this.pump1_dev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump1_dev.Name = "pump1_dev";
            this.pump1_dev.Size = new System.Drawing.Size(104, 24);
            this.pump1_dev.TabIndex = 8;
            this.pump1_dev.SelectionChangeCommitted += new System.EventHandler(this.pump1_dev_SelectionChangeCommitted);
            // 
            // pump2_dev
            // 
            this.pump2_dev.FormattingEnabled = true;
            this.pump2_dev.Location = new System.Drawing.Point(181, 342);
            this.pump2_dev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump2_dev.Name = "pump2_dev";
            this.pump2_dev.Size = new System.Drawing.Size(103, 24);
            this.pump2_dev.TabIndex = 9;
            this.pump2_dev.SelectionChangeCommitted += new System.EventHandler(this.pump2_dev_SelectionChangeCommitted);
            // 
            // pump3_dev
            // 
            this.pump3_dev.FormattingEnabled = true;
            this.pump3_dev.Location = new System.Drawing.Point(181, 375);
            this.pump3_dev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump3_dev.Name = "pump3_dev";
            this.pump3_dev.Size = new System.Drawing.Size(104, 24);
            this.pump3_dev.TabIndex = 10;
            this.pump3_dev.SelectionChangeCommitted += new System.EventHandler(this.pump3_dev_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Thermocouple Reader:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 313);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pump 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 346);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pump 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 379);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Pump 3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 256);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Device:";
            // 
            // temp_startlog
            // 
            this.temp_startlog.Location = new System.Drawing.Point(493, 273);
            this.temp_startlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.temp_startlog.Name = "temp_startlog";
            this.temp_startlog.Size = new System.Drawing.Size(100, 28);
            this.temp_startlog.TabIndex = 21;
            this.temp_startlog.Text = "Start Log";
            this.temp_startlog.UseVisualStyleBackColor = true;
            this.temp_startlog.Click += new System.EventHandler(this.temp_startlog_Click);
            // 
            // temp_stoplog
            // 
            this.temp_stoplog.Location = new System.Drawing.Point(601, 273);
            this.temp_stoplog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.temp_stoplog.Name = "temp_stoplog";
            this.temp_stoplog.Size = new System.Drawing.Size(100, 28);
            this.temp_stoplog.TabIndex = 22;
            this.temp_stoplog.Text = "Stop Log";
            this.temp_stoplog.UseVisualStyleBackColor = true;
            this.temp_stoplog.Click += new System.EventHandler(this.temp_stoplog_Click);
            // 
            // pump1_startlog
            // 
            this.pump1_startlog.Location = new System.Drawing.Point(493, 306);
            this.pump1_startlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump1_startlog.Name = "pump1_startlog";
            this.pump1_startlog.Size = new System.Drawing.Size(100, 28);
            this.pump1_startlog.TabIndex = 23;
            this.pump1_startlog.Text = "Start Log";
            this.pump1_startlog.UseVisualStyleBackColor = true;
            this.pump1_startlog.Click += new System.EventHandler(this.pump1_startlog_Click);
            // 
            // pump2_startlog
            // 
            this.pump2_startlog.Location = new System.Drawing.Point(493, 340);
            this.pump2_startlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump2_startlog.Name = "pump2_startlog";
            this.pump2_startlog.Size = new System.Drawing.Size(100, 28);
            this.pump2_startlog.TabIndex = 24;
            this.pump2_startlog.Text = "Start Log";
            this.pump2_startlog.UseVisualStyleBackColor = true;
            this.pump2_startlog.Click += new System.EventHandler(this.pump2_startlog_Click);
            // 
            // pump3_startlog
            // 
            this.pump3_startlog.Location = new System.Drawing.Point(493, 373);
            this.pump3_startlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump3_startlog.Name = "pump3_startlog";
            this.pump3_startlog.Size = new System.Drawing.Size(100, 28);
            this.pump3_startlog.TabIndex = 25;
            this.pump3_startlog.Text = "Start Log";
            this.pump3_startlog.UseVisualStyleBackColor = true;
            this.pump3_startlog.Click += new System.EventHandler(this.pump3_startlog_Click);
            // 
            // pump1_stoplog
            // 
            this.pump1_stoplog.Location = new System.Drawing.Point(601, 306);
            this.pump1_stoplog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump1_stoplog.Name = "pump1_stoplog";
            this.pump1_stoplog.Size = new System.Drawing.Size(100, 28);
            this.pump1_stoplog.TabIndex = 26;
            this.pump1_stoplog.Text = "Stop Log";
            this.pump1_stoplog.UseVisualStyleBackColor = true;
            this.pump1_stoplog.Click += new System.EventHandler(this.pump1_stoplog_Click);
            // 
            // pump2_stoplog
            // 
            this.pump2_stoplog.Location = new System.Drawing.Point(601, 340);
            this.pump2_stoplog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump2_stoplog.Name = "pump2_stoplog";
            this.pump2_stoplog.Size = new System.Drawing.Size(100, 28);
            this.pump2_stoplog.TabIndex = 27;
            this.pump2_stoplog.Text = "Stop Log";
            this.pump2_stoplog.UseVisualStyleBackColor = true;
            this.pump2_stoplog.Click += new System.EventHandler(this.pump2_stoplog_Click);
            // 
            // pump3_stoplog
            // 
            this.pump3_stoplog.Location = new System.Drawing.Point(601, 373);
            this.pump3_stoplog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pump3_stoplog.Name = "pump3_stoplog";
            this.pump3_stoplog.Size = new System.Drawing.Size(100, 28);
            this.pump3_stoplog.TabIndex = 28;
            this.pump3_stoplog.Text = "Stop Log";
            this.pump3_stoplog.UseVisualStyleBackColor = true;
            this.pump3_stoplog.Click += new System.EventHandler(this.pump3_stoplog_Click);
            // 
            // temp_status
            // 
            this.temp_status.AutoSize = true;
            this.temp_status.BackColor = System.Drawing.Color.Blue;
            this.temp_status.ForeColor = System.Drawing.Color.White;
            this.temp_status.Location = new System.Drawing.Point(709, 279);
            this.temp_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.temp_status.Name = "temp_status";
            this.temp_status.Size = new System.Drawing.Size(56, 17);
            this.temp_status.TabIndex = 29;
            this.temp_status.Text = "Inactive";
            // 
            // pump1_status
            // 
            this.pump1_status.AutoSize = true;
            this.pump1_status.BackColor = System.Drawing.Color.Blue;
            this.pump1_status.ForeColor = System.Drawing.Color.White;
            this.pump1_status.Location = new System.Drawing.Point(709, 313);
            this.pump1_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pump1_status.Name = "pump1_status";
            this.pump1_status.Size = new System.Drawing.Size(56, 17);
            this.pump1_status.TabIndex = 30;
            this.pump1_status.Text = "Inactive";
            // 
            // pump2_status
            // 
            this.pump2_status.AutoSize = true;
            this.pump2_status.BackColor = System.Drawing.Color.Blue;
            this.pump2_status.ForeColor = System.Drawing.Color.White;
            this.pump2_status.Location = new System.Drawing.Point(709, 346);
            this.pump2_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pump2_status.Name = "pump2_status";
            this.pump2_status.Size = new System.Drawing.Size(56, 17);
            this.pump2_status.TabIndex = 31;
            this.pump2_status.Text = "Inactive";
            // 
            // pump3_status
            // 
            this.pump3_status.AutoSize = true;
            this.pump3_status.BackColor = System.Drawing.Color.Blue;
            this.pump3_status.ForeColor = System.Drawing.Color.White;
            this.pump3_status.Location = new System.Drawing.Point(709, 379);
            this.pump3_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pump3_status.Name = "pump3_status";
            this.pump3_status.Size = new System.Drawing.Size(56, 17);
            this.pump3_status.TabIndex = 32;
            this.pump3_status.Text = "Inactive";
            // 
            // session_name
            // 
            this.session_name.Location = new System.Drawing.Point(565, 31);
            this.session_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_name.Name = "session_name";
            this.session_name.Size = new System.Drawing.Size(472, 22);
            this.session_name.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "Session Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 66);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Session Log Location:";
            // 
            // session_location
            // 
            this.session_location.Enabled = false;
            this.session_location.Location = new System.Drawing.Point(565, 63);
            this.session_location.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_location.Name = "session_location";
            this.session_location.Size = new System.Drawing.Size(472, 22);
            this.session_location.TabIndex = 36;
            // 
            // session_browse
            // 
            this.session_browse.Location = new System.Drawing.Point(412, 95);
            this.session_browse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_browse.Name = "session_browse";
            this.session_browse.Size = new System.Drawing.Size(357, 27);
            this.session_browse.TabIndex = 37;
            this.session_browse.Text = "Browse Location For New Sesion";
            this.session_browse.UseVisualStyleBackColor = true;
            this.session_browse.Click += new System.EventHandler(this.session_browse_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Logging Period:";
            // 
            // session_logperiod
            // 
            this.session_logperiod.Location = new System.Drawing.Point(548, 201);
            this.session_logperiod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_logperiod.Name = "session_logperiod";
            this.session_logperiod.Size = new System.Drawing.Size(101, 22);
            this.session_logperiod.TabIndex = 39;
            // 
            // session_logunit
            // 
            this.session_logunit.FormattingEnabled = true;
            this.session_logunit.Location = new System.Drawing.Point(659, 199);
            this.session_logunit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_logunit.Name = "session_logunit";
            this.session_logunit.Size = new System.Drawing.Size(109, 24);
            this.session_logunit.TabIndex = 40;
            // 
            // session_start
            // 
            this.session_start.Location = new System.Drawing.Point(412, 166);
            this.session_start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_start.Name = "session_start";
            this.session_start.Size = new System.Drawing.Size(168, 28);
            this.session_start.TabIndex = 41;
            this.session_start.Text = "Start Session";
            this.session_start.UseVisualStyleBackColor = true;
            this.session_start.Click += new System.EventHandler(this.session_start_Click);
            // 
            // session_stop
            // 
            this.session_stop.Location = new System.Drawing.Point(601, 166);
            this.session_stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.session_stop.Name = "session_stop";
            this.session_stop.Size = new System.Drawing.Size(168, 28);
            this.session_stop.TabIndex = 42;
            this.session_stop.Text = "Finish Session";
            this.session_stop.UseVisualStyleBackColor = true;
            this.session_stop.Click += new System.EventHandler(this.session_stop_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(709, 256);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 43;
            this.label12.Text = "Status:";
            // 
            // session_current
            // 
            this.session_current.AutoSize = true;
            this.session_current.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.session_current.Location = new System.Drawing.Point(17, 434);
            this.session_current.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.session_current.Name = "session_current";
            this.session_current.Size = new System.Drawing.Size(172, 25);
            this.session_current.TabIndex = 47;
            this.session_current.Text = "No Active Session";
            // 
            // baud_rate
            // 
            this.baud_rate.FormattingEnabled = true;
            this.baud_rate.Location = new System.Drawing.Point(220, 198);
            this.baud_rate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baud_rate.Name = "baud_rate";
            this.baud_rate.Size = new System.Drawing.Size(160, 24);
            this.baud_rate.TabIndex = 48;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(35, 202);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(126, 17);
            this.label29.TabIndex = 49;
            this.label29.Text = "Device Baud Rate:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 313);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Name:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(295, 346);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 17);
            this.label30.TabIndex = 51;
            this.label30.Text = "Name:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(295, 379);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 17);
            this.label31.TabIndex = 52;
            this.label31.Text = "Name:";
            // 
            // p_name1
            // 
            this.p_name1.Enabled = false;
            this.p_name1.Location = new System.Drawing.Point(352, 309);
            this.p_name1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p_name1.Name = "p_name1";
            this.p_name1.Size = new System.Drawing.Size(132, 22);
            this.p_name1.TabIndex = 53;
            this.p_name1.Text = "HV_Pump";
            // 
            // p_name2
            // 
            this.p_name2.Enabled = false;
            this.p_name2.Location = new System.Drawing.Point(352, 342);
            this.p_name2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p_name2.Name = "p_name2";
            this.p_name2.Size = new System.Drawing.Size(132, 22);
            this.p_name2.TabIndex = 54;
            this.p_name2.Text = "MOT_Pump";
            // 
            // p_name3
            // 
            this.p_name3.Enabled = false;
            this.p_name3.Location = new System.Drawing.Point(352, 375);
            this.p_name3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p_name3.Name = "p_name3";
            this.p_name3.Size = new System.Drawing.Size(132, 22);
            this.p_name3.TabIndex = 55;
            this.p_name3.Text = "Cell_Pump";
            // 
            // browseoldsession
            // 
            this.browseoldsession.Location = new System.Drawing.Point(412, 129);
            this.browseoldsession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.browseoldsession.Name = "browseoldsession";
            this.browseoldsession.Size = new System.Drawing.Size(357, 28);
            this.browseoldsession.TabIndex = 58;
            this.browseoldsession.Text = "Continue Existing Session";
            this.browseoldsession.UseVisualStyleBackColor = true;
            this.browseoldsession.Click += new System.EventHandler(this.browseoldsession_Click);
            // 
            // t_qperiod
            // 
            this.t_qperiod.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.t_qperiod.Location = new System.Drawing.Point(573, 233);
            this.t_qperiod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_qperiod.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.t_qperiod.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.t_qperiod.Name = "t_qperiod";
            this.t_qperiod.Size = new System.Drawing.Size(65, 22);
            this.t_qperiod.TabIndex = 59;
            this.t_qperiod.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.t_qperiod.ValueChanged += new System.EventHandler(this.t_qperiod_ValueChanged);
            // 
            // p_qperiod
            // 
            this.p_qperiod.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.p_qperiod.Location = new System.Drawing.Point(704, 233);
            this.p_qperiod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p_qperiod.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.p_qperiod.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.p_qperiod.Name = "p_qperiod";
            this.p_qperiod.Size = new System.Drawing.Size(65, 22);
            this.p_qperiod.TabIndex = 60;
            this.p_qperiod.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.p_qperiod.ValueChanged += new System.EventHandler(this.p_qperiod_ValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(408, 235);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(120, 17);
            this.label33.TabIndex = 61;
            this.label33.Text = "Query times (ms):";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(516, 235);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 17);
            this.label34.TabIndex = 62;
            this.label34.Text = "Temp:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(647, 235);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 17);
            this.label35.TabIndex = 63;
            this.label35.Text = "Pump:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 481);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.p_qperiod);
            this.Controls.Add(this.t_qperiod);
            this.Controls.Add(this.browseoldsession);
            this.Controls.Add(this.p_name3);
            this.Controls.Add(this.p_name2);
            this.Controls.Add(this.p_name1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.baud_rate);
            this.Controls.Add(this.session_current);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.session_stop);
            this.Controls.Add(this.session_start);
            this.Controls.Add(this.session_logunit);
            this.Controls.Add(this.session_logperiod);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.session_browse);
            this.Controls.Add(this.session_location);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.session_name);
            this.Controls.Add(this.pump3_status);
            this.Controls.Add(this.pump2_status);
            this.Controls.Add(this.pump1_status);
            this.Controls.Add(this.temp_status);
            this.Controls.Add(this.pump3_stoplog);
            this.Controls.Add(this.pump2_stoplog);
            this.Controls.Add(this.pump1_stoplog);
            this.Controls.Add(this.pump3_startlog);
            this.Controls.Add(this.pump2_startlog);
            this.Controls.Add(this.pump1_startlog);
            this.Controls.Add(this.temp_stoplog);
            this.Controls.Add(this.temp_startlog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pump3_dev);
            this.Controls.Add(this.pump2_dev);
            this.Controls.Add(this.pump1_dev);
            this.Controls.Add(this.temp_dev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dev_disconnect);
            this.Controls.Add(this.dev_connected);
            this.Controls.Add(this.dev_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dev_refresh);
            this.Controls.Add(this.dev_list);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "The Bakeout Logger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_qperiod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_qperiod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox dev_list;
        private System.Windows.Forms.Button dev_refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dev_connect;
        private System.Windows.Forms.ListBox dev_connected;
        private System.Windows.Forms.Button dev_disconnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox temp_dev;
        private System.Windows.Forms.ComboBox pump1_dev;
        private System.Windows.Forms.ComboBox pump2_dev;
        private System.Windows.Forms.ComboBox pump3_dev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button temp_startlog;
        private System.Windows.Forms.Button temp_stoplog;
        private System.Windows.Forms.Button pump1_startlog;
        private System.Windows.Forms.Button pump2_startlog;
        private System.Windows.Forms.Button pump3_startlog;
        private System.Windows.Forms.Button pump1_stoplog;
        private System.Windows.Forms.Button pump2_stoplog;
        private System.Windows.Forms.Button pump3_stoplog;
        private System.Windows.Forms.Label temp_status;
        private System.Windows.Forms.Label pump1_status;
        private System.Windows.Forms.Label pump2_status;
        private System.Windows.Forms.Label pump3_status;
        private System.Windows.Forms.TextBox session_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox session_location;
        private System.Windows.Forms.Button session_browse;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox session_logperiod;
        private System.Windows.Forms.ComboBox session_logunit;
        private System.Windows.Forms.Button session_start;
        private System.Windows.Forms.Button session_stop;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label session_current;
        private System.Windows.Forms.ComboBox baud_rate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox p_name1;
        private System.Windows.Forms.TextBox p_name2;
        private System.Windows.Forms.TextBox p_name3;
        private System.Windows.Forms.Button browseoldsession;
        private System.Windows.Forms.NumericUpDown t_qperiod;
        private System.Windows.Forms.NumericUpDown p_qperiod;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
    }
}

