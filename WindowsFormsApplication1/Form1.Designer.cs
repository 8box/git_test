namespace AudioRecord
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sourceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartRecord = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.StopRecord = new System.Windows.Forms.Button();
            this.ListenToThisDevice = new System.Windows.Forms.Button();
            this.Sources = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.VideoCapture = new System.Windows.Forms.Button();
            this.ListClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Samples = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmRight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Current_Sample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceList
            // 
            this.sourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.sourceList.Location = new System.Drawing.Point(0, 0);
            this.sourceList.MultiSelect = false;
            this.sourceList.Name = "sourceList";
            this.sourceList.Size = new System.Drawing.Size(223, 99);
            this.sourceList.TabIndex = 0;
            this.sourceList.UseCompatibleStateImageBehavior = false;
            this.sourceList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Chanels";
            this.columnHeader2.Width = 94;
            // 
            // StartRecord
            // 
            this.StartRecord.Location = new System.Drawing.Point(1, 51);
            this.StartRecord.Name = "StartRecord";
            this.StartRecord.Size = new System.Drawing.Size(155, 45);
            this.StartRecord.TabIndex = 8;
            this.StartRecord.Text = "Start Record";
            this.StartRecord.UseVisualStyleBackColor = true;
            this.StartRecord.Click += new System.EventHandler(this.StartRecord_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(327, 54);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(320, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // StopRecord
            // 
            this.StopRecord.Location = new System.Drawing.Point(166, 51);
            this.StopRecord.Name = "StopRecord";
            this.StopRecord.Size = new System.Drawing.Size(155, 45);
            this.StopRecord.TabIndex = 2;
            this.StopRecord.Text = "Stop Record";
            this.StopRecord.UseVisualStyleBackColor = true;
            this.StopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // ListenToThisDevice
            // 
            this.ListenToThisDevice.Location = new System.Drawing.Point(327, 0);
            this.ListenToThisDevice.Name = "ListenToThisDevice";
            this.ListenToThisDevice.Size = new System.Drawing.Size(320, 45);
            this.ListenToThisDevice.TabIndex = 1;
            this.ListenToThisDevice.Text = "Listen To This Device";
            this.ListenToThisDevice.UseVisualStyleBackColor = true;
            this.ListenToThisDevice.Click += new System.EventHandler(this.ListenToThisDevice_Click);
            // 
            // Sources
            // 
            this.Sources.Location = new System.Drawing.Point(1, 0);
            this.Sources.Name = "Sources";
            this.Sources.Size = new System.Drawing.Size(320, 45);
            this.Sources.TabIndex = 0;
            this.Sources.Text = "Sources";
            this.Sources.UseVisualStyleBackColor = true;
            this.Sources.Click += new System.EventHandler(this.Sources_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 180);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(881, 283);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.Browse);
            this.splitContainer1.Panel1.Controls.Add(this.sourceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox6);
            this.splitContainer1.Panel2.Controls.Add(this.textBox5);
            this.splitContainer1.Panel2.Controls.Add(this.textBox4);
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.VideoCapture);
            this.splitContainer1.Panel2.Controls.Add(this.ListClear);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.StartRecord);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel2.Controls.Add(this.StopRecord);
            this.splitContainer1.Panel2.Controls.Add(this.ListenToThisDevice);
            this.splitContainer1.Panel2.Controls.Add(this.Sources);
            this.splitContainer1.Size = new System.Drawing.Size(881, 150);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 11;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(160, 105);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(60, 45);
            this.Browse.TabIndex = 10;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(487, 121);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(87, 20);
            this.textBox6.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(580, 88);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(67, 20);
            this.textBox5.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(487, 89);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(87, 20);
            this.textBox4.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(407, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(334, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 20);
            this.textBox2.TabIndex = 12;
            // 
            // VideoCapture
            // 
            this.VideoCapture.Location = new System.Drawing.Point(1, 105);
            this.VideoCapture.Name = "VideoCapture";
            this.VideoCapture.Size = new System.Drawing.Size(320, 45);
            this.VideoCapture.TabIndex = 11;
            this.VideoCapture.Text = "Video Capture";
            this.VideoCapture.UseVisualStyleBackColor = true;
            this.VideoCapture.Click += new System.EventHandler(this.VideoCapture_Click);
            // 
            // ListClear
            // 
            this.ListClear.Location = new System.Drawing.Point(589, 114);
            this.ListClear.Name = "ListClear";
            this.ListClear.Size = new System.Drawing.Size(58, 33);
            this.ListClear.TabIndex = 10;
            this.ListClear.Text = "List Clear";
            this.ListClear.UseVisualStyleBackColor = true;
            this.ListClear.Click += new System.EventHandler(this.ListClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(327, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "00:00:00";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Samples,
            this.AmRight,
            this.Current_Sample});
            this.listView1.Location = new System.Drawing.Point(1080, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(172, 659);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Samples
            // 
            this.Samples.Text = "Count";
            this.Samples.Width = 40;
            // 
            // AmRight
            // 
            this.AmRight.Text = "Right";
            this.AmRight.Width = 66;
            // 
            // Current_Sample
            // 
            this.Current_Sample.Text = "ms";
            this.Current_Sample.Width = 111;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.Location = new System.Drawing.Point(899, 12);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(175, 659);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Count";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Left";
            this.columnHeader5.Width = 66;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ms";
            this.columnHeader6.Width = 66;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(12, 469);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(881, 283);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 759);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Recorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView sourceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button StopRecord;
        private System.Windows.Forms.Button ListenToThisDevice;
        private System.Windows.Forms.Button Sources;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button StartRecord;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Samples;
        private System.Windows.Forms.ColumnHeader AmRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader Current_Sample;
        private System.Windows.Forms.Button ListClear;
        private System.Windows.Forms.Button VideoCapture;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

