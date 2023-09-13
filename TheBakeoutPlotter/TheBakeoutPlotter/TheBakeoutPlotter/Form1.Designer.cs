namespace TheBakeoutPlotter
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.browse = new System.Windows.Forms.Button();
            this.stop_plotting = new System.Windows.Forms.Button();
            this.t_plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.p_plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.temp_monitor = new System.Windows.Forms.Button();
            this.stemp_range = new System.Windows.Forms.Button();
            this.atemp_range = new System.Windows.Forms.Button();
            this.T_max = new System.Windows.Forms.TextBox();
            this.T_min = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StartDT = new System.Windows.Forms.DateTimePicker();
            this.EndDT = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.st_range = new System.Windows.Forms.Button();
            this.at_range = new System.Windows.Forms.Button();
            this.spres_range = new System.Windows.Forms.Button();
            this.apres_range = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.P_min = new System.Windows.Forms.TextBox();
            this.P_max = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.t_plot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_plot)).BeginInit();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(30, 30);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(140, 23);
            this.browse.TabIndex = 0;
            this.browse.Text = "Load Logging Session";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // stop_plotting
            // 
            this.stop_plotting.Location = new System.Drawing.Point(30, 60);
            this.stop_plotting.Name = "stop_plotting";
            this.stop_plotting.Size = new System.Drawing.Size(140, 23);
            this.stop_plotting.TabIndex = 1;
            this.stop_plotting.Text = "Clear Logging Session";
            this.stop_plotting.UseVisualStyleBackColor = true;
            this.stop_plotting.Click += new System.EventHandler(this.stop_plotting_Click);
            // 
            // t_plot
            // 
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 12;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 9;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.Name = "T_ChartArea";
            this.t_plot.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.t_plot.Legends.Add(legend1);
            this.t_plot.Location = new System.Drawing.Point(30, 215);
            this.t_plot.Name = "t_plot";
            this.t_plot.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 2;
            series1.ChartArea = "T_ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.LightSkyBlue;
            series1.Legend = "Legend1";
            series1.LegendText = "Top flange";
            series1.MarkerBorderColor = System.Drawing.Color.LightSkyBlue;
            series1.MarkerColor = System.Drawing.Color.LightSkyBlue;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Ch1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderWidth = 2;
            series2.ChartArea = "T_ChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.LegendText = "Bottom flange";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Ch2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.BorderWidth = 2;
            series3.ChartArea = "T_ChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Silver;
            series3.Legend = "Legend1";
            series3.LegendText = "Bellow";
            series3.MarkerBorderColor = System.Drawing.Color.Silver;
            series3.MarkerColor = System.Drawing.Color.Silver;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Ch3";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.BorderWidth = 2;
            series4.ChartArea = "T_ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Gold;
            series4.Legend = "Legend1";
            series4.LegendText = "Pump";
            series4.MarkerBorderColor = System.Drawing.Color.Gold;
            series4.MarkerColor = System.Drawing.Color.Gold;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Ch4";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.BorderWidth = 2;
            series5.ChartArea = "T_ChartArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.CornflowerBlue;
            series5.Legend = "Legend1";
            series5.LegendText = "Cube";
            series5.MarkerBorderColor = System.Drawing.Color.CornflowerBlue;
            series5.MarkerColor = System.Drawing.Color.CornflowerBlue;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Ch5";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.t_plot.Series.Add(series1);
            this.t_plot.Series.Add(series2);
            this.t_plot.Series.Add(series3);
            this.t_plot.Series.Add(series4);
            this.t_plot.Series.Add(series5);
            this.t_plot.Size = new System.Drawing.Size(750, 625);
            this.t_plot.TabIndex = 2;
            this.t_plot.Text = "chart1";
            title1.Name = "Title_temp";
            title1.Text = "Temperature";
            this.t_plot.Titles.Add(title1);
            // 
            // p_plot
            // 
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 12;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 9;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea2.AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
            chartArea2.AxisY.IsLogarithmic = true;
            chartArea2.Name = "ChartArea1";
            this.p_plot.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.p_plot.Legends.Add(legend2);
            this.p_plot.Location = new System.Drawing.Point(810, 215);
            this.p_plot.Name = "p_plot";
            series19.BorderWidth = 2;
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series19.Legend = "Legend1";
            series19.Name = "HV_Pump";
            series19.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series19.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Color = System.Drawing.Color.Lime;
            series20.Legend = "Legend1";
            series20.Name = "MOT_Pump";
            series20.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series20.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series21.BorderWidth = 2;
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Color = System.Drawing.Color.Blue;
            series21.Legend = "Legend1";
            series21.Name = "Cell_Pump";
            series21.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series21.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series22.BorderWidth = 2;
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Color = System.Drawing.Color.Blue;
            series22.Legend = "Legend1";
            series22.Name = "Turbo";
            series22.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series22.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.p_plot.Series.Add(series19);
            this.p_plot.Series.Add(series20);
            this.p_plot.Series.Add(series21);
            this.p_plot.Series.Add(series22);
            this.p_plot.Size = new System.Drawing.Size(750, 625);
            this.p_plot.TabIndex = 3;
            this.p_plot.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Pressure";
            this.p_plot.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Session Path:";
            // 
            // temp_monitor
            // 
            this.temp_monitor.Location = new System.Drawing.Point(30, 90);
            this.temp_monitor.Name = "temp_monitor";
            this.temp_monitor.Size = new System.Drawing.Size(140, 21);
            this.temp_monitor.TabIndex = 6;
            this.temp_monitor.Text = "Open Monitors";
            this.temp_monitor.UseVisualStyleBackColor = true;
            this.temp_monitor.Click += new System.EventHandler(this.temp_monitor_Click);
            // 
            // stemp_range
            // 
            this.stemp_range.Location = new System.Drawing.Point(360, 150);
            this.stemp_range.Name = "stemp_range";
            this.stemp_range.Size = new System.Drawing.Size(100, 23);
            this.stemp_range.TabIndex = 7;
            this.stemp_range.Text = "Set T Range";
            this.stemp_range.UseVisualStyleBackColor = true;
            this.stemp_range.Click += new System.EventHandler(this.stemp_range_Click);
            // 
            // atemp_range
            // 
            this.atemp_range.Location = new System.Drawing.Point(360, 180);
            this.atemp_range.Name = "atemp_range";
            this.atemp_range.Size = new System.Drawing.Size(100, 23);
            this.atemp_range.TabIndex = 8;
            this.atemp_range.Text = "Auto T Range";
            this.atemp_range.UseVisualStyleBackColor = true;
            this.atemp_range.Click += new System.EventHandler(this.atemp_range_Click);
            // 
            // T_max
            // 
            this.T_max.Location = new System.Drawing.Point(510, 153);
            this.T_max.Name = "T_max";
            this.T_max.Size = new System.Drawing.Size(50, 20);
            this.T_max.TabIndex = 9;
            this.T_max.Text = "200";
            // 
            // T_min
            // 
            this.T_min.Location = new System.Drawing.Point(510, 183);
            this.T_min.Name = "T_min";
            this.T_min.Size = new System.Drawing.Size(50, 20);
            this.T_min.TabIndex = 10;
            this.T_min.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "T_max:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "T_min:";
            // 
            // StartDT
            // 
            this.StartDT.CustomFormat = "dd/MM/yyyy, HH:mm:ss";
            this.StartDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDT.Location = new System.Drawing.Point(200, 150);
            this.StartDT.Name = "StartDT";
            this.StartDT.Size = new System.Drawing.Size(144, 20);
            this.StartDT.TabIndex = 13;
            this.StartDT.Value = new System.DateTime(2018, 12, 6, 0, 0, 0, 0);
            // 
            // EndDT
            // 
            this.EndDT.CustomFormat = "dd/MM/yyyy, HH:mm:ss";
            this.EndDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDT.Location = new System.Drawing.Point(200, 180);
            this.EndDT.Name = "EndDT";
            this.EndDT.Size = new System.Drawing.Size(144, 20);
            this.EndDT.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Start:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "End:";
            // 
            // st_range
            // 
            this.st_range.Location = new System.Drawing.Point(30, 150);
            this.st_range.Name = "st_range";
            this.st_range.Size = new System.Drawing.Size(127, 23);
            this.st_range.TabIndex = 17;
            this.st_range.Text = "Set Time Range";
            this.st_range.UseVisualStyleBackColor = true;
            this.st_range.Click += new System.EventHandler(this.st_range_Click);
            // 
            // at_range
            // 
            this.at_range.Location = new System.Drawing.Point(30, 180);
            this.at_range.Name = "at_range";
            this.at_range.Size = new System.Drawing.Size(127, 23);
            this.at_range.TabIndex = 18;
            this.at_range.Text = "Auto Time Range";
            this.at_range.UseVisualStyleBackColor = true;
            this.at_range.Click += new System.EventHandler(this.at_range_Click);
            // 
            // spres_range
            // 
            this.spres_range.Location = new System.Drawing.Point(570, 150);
            this.spres_range.Name = "spres_range";
            this.spres_range.Size = new System.Drawing.Size(100, 23);
            this.spres_range.TabIndex = 19;
            this.spres_range.Text = "Set P Range";
            this.spres_range.UseVisualStyleBackColor = true;
            this.spres_range.Click += new System.EventHandler(this.spres_range_Click);
            // 
            // apres_range
            // 
            this.apres_range.Location = new System.Drawing.Point(570, 180);
            this.apres_range.Name = "apres_range";
            this.apres_range.Size = new System.Drawing.Size(100, 23);
            this.apres_range.TabIndex = 20;
            this.apres_range.Text = "Auto P Range";
            this.apres_range.UseVisualStyleBackColor = true;
            this.apres_range.Click += new System.EventHandler(this.apres_range_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "P_min:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "P_max:";
            // 
            // P_min
            // 
            this.P_min.Location = new System.Drawing.Point(725, 183);
            this.P_min.Name = "P_min";
            this.P_min.Size = new System.Drawing.Size(50, 20);
            this.P_min.TabIndex = 22;
            // 
            // P_max
            // 
            this.P_max.Location = new System.Drawing.Point(725, 153);
            this.P_max.Name = "P_max";
            this.P_max.Size = new System.Drawing.Size(50, 20);
            this.P_max.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.P_min);
            this.Controls.Add(this.P_max);
            this.Controls.Add(this.apres_range);
            this.Controls.Add(this.spres_range);
            this.Controls.Add(this.at_range);
            this.Controls.Add(this.st_range);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EndDT);
            this.Controls.Add(this.StartDT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.T_min);
            this.Controls.Add(this.T_max);
            this.Controls.Add(this.atemp_range);
            this.Controls.Add(this.stemp_range);
            this.Controls.Add(this.temp_monitor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_plot);
            this.Controls.Add(this.t_plot);
            this.Controls.Add(this.stop_plotting);
            this.Controls.Add(this.browse);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "The Bakeout Plotter";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.t_plot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_plot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button stop_plotting;
        private System.Windows.Forms.DataVisualization.Charting.Chart t_plot;
        private System.Windows.Forms.DataVisualization.Charting.Chart p_plot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button temp_monitor;
        private System.Windows.Forms.Button stemp_range;
        private System.Windows.Forms.Button atemp_range;
        private System.Windows.Forms.TextBox T_max;
        private System.Windows.Forms.TextBox T_min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker StartDT;
        private System.Windows.Forms.DateTimePicker EndDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button st_range;
        private System.Windows.Forms.Button at_range;
        private System.Windows.Forms.Button spres_range;
        private System.Windows.Forms.Button apres_range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox P_min;
        private System.Windows.Forms.TextBox P_max;
    }
}

