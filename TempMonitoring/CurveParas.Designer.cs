namespace TempMonitoring
{
    partial class CurveParas
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RealTime = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbmRNodeNumber = new System.Windows.Forms.ComboBox();
            this.btnRD = new System.Windows.Forms.Button();
            this.btnRA = new System.Windows.Forms.Button();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.History = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHSTime = new System.Windows.Forms.DateTimePicker();
            this.dtHETime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHNodeNumber = new System.Windows.Forms.ComboBox();
            this.btnD = new System.Windows.Forms.Button();
            this.btnA = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.RealTime.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.History.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.RealTime);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 276);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // RealTime
            // 
            this.RealTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RealTime.Controls.Add(this.groupBox3);
            this.RealTime.Controls.Add(this.btnRD);
            this.RealTime.Controls.Add(this.btnRA);
            this.RealTime.Controls.Add(this.listBox4);
            this.RealTime.Controls.Add(this.listBox3);
            this.RealTime.Controls.Add(this.label9);
            this.RealTime.Controls.Add(this.label10);
            this.RealTime.Location = new System.Drawing.Point(4, 22);
            this.RealTime.Name = "RealTime";
            this.RealTime.Padding = new System.Windows.Forms.Padding(3);
            this.RealTime.Size = new System.Drawing.Size(374, 250);
            this.RealTime.TabIndex = 0;
            this.RealTime.Text = "实时曲线";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Salmon;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbmRNodeNumber);
            this.groupBox3.Location = new System.Drawing.Point(117, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(137, 52);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编号设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "结点编号";
            // 
            // cbmRNodeNumber
            // 
            this.cbmRNodeNumber.FormattingEnabled = true;
            this.cbmRNodeNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29"});
            this.cbmRNodeNumber.Location = new System.Drawing.Point(73, 18);
            this.cbmRNodeNumber.Name = "cbmRNodeNumber";
            this.cbmRNodeNumber.Size = new System.Drawing.Size(54, 20);
            this.cbmRNodeNumber.TabIndex = 1;
            // 
            // btnRD
            // 
            this.btnRD.Location = new System.Drawing.Point(160, 188);
            this.btnRD.Name = "btnRD";
            this.btnRD.Size = new System.Drawing.Size(39, 25);
            this.btnRD.TabIndex = 16;
            this.btnRD.Text = "<<";
            this.btnRD.UseVisualStyleBackColor = true;
            this.btnRD.Click += new System.EventHandler(this.btnRD_Click);
            // 
            // btnRA
            // 
            this.btnRA.Location = new System.Drawing.Point(160, 136);
            this.btnRA.Name = "btnRA";
            this.btnRA.Size = new System.Drawing.Size(39, 25);
            this.btnRA.TabIndex = 15;
            this.btnRA.Text = ">>";
            this.btnRA.UseVisualStyleBackColor = true;
            this.btnRA.Click += new System.EventHandler(this.btnRA_Click);
            // 
            // listBox4
            // 
            this.listBox4.ItemHeight = 12;
            this.listBox4.Location = new System.Drawing.Point(248, 126);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(75, 112);
            this.listBox4.TabIndex = 11;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(50, 126);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(69, 112);
            this.listBox3.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "已选曲线";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "待选曲线";
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.SystemColors.ControlLight;
            this.History.Controls.Add(this.groupBox2);
            this.History.Controls.Add(this.groupBox1);
            this.History.Controls.Add(this.btnD);
            this.History.Controls.Add(this.btnA);
            this.History.Controls.Add(this.listBox2);
            this.History.Controls.Add(this.listBox1);
            this.History.Controls.Add(this.label6);
            this.History.Controls.Add(this.label5);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(374, 250);
            this.History.TabIndex = 1;
            this.History.Text = "历史数据";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Salmon;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtHSTime);
            this.groupBox2.Controls.Add(this.dtHETime);
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 78);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时间设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // dtHSTime
            // 
            this.dtHSTime.Location = new System.Drawing.Point(64, 20);
            this.dtHSTime.Name = "dtHSTime";
            this.dtHSTime.Size = new System.Drawing.Size(104, 21);
            this.dtHSTime.TabIndex = 0;
            //this.dtHSTime.ValueChanged += new System.EventHandler(this.dtHSTime_ValueChanged);
            // 
            // dtHETime
            // 
            this.dtHETime.Location = new System.Drawing.Point(64, 49);
            this.dtHETime.Name = "dtHETime";
            this.dtHETime.Size = new System.Drawing.Size(104, 21);
            this.dtHETime.TabIndex = 0;
            //this.dtHETime.ValueChanged += new System.EventHandler(this.dtHETime_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Salmon;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbHNodeNumber);
            this.groupBox1.Location = new System.Drawing.Point(214, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "编号设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "结点编号";
            // 
            // cmbHNodeNumber
            // 
            this.cmbHNodeNumber.FormattingEnabled = true;
            this.cmbHNodeNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29"});
            this.cmbHNodeNumber.Location = new System.Drawing.Point(73, 18);
            this.cmbHNodeNumber.Name = "cmbHNodeNumber";
            this.cmbHNodeNumber.Size = new System.Drawing.Size(54, 20);
            this.cmbHNodeNumber.TabIndex = 1;
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(166, 190);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(39, 25);
            this.btnD.TabIndex = 9;
            this.btnD.Text = "<<";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(166, 135);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(39, 25);
            this.btnA.TabIndex = 9;
            this.btnA.Text = ">>";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // listBox2
            // 
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(248, 125);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(75, 112);
            this.listBox2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(58, 125);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(69, 112);
            this.listBox1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "已选曲线";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "待选曲线";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(75, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(264, 307);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CurveParas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 347);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurveParas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线设置";
            this.tabControl1.ResumeLayout(false);
            this.RealTime.ResumeLayout(false);
            this.RealTime.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.History.ResumeLayout(false);
            this.History.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage RealTime;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHNodeNumber;
        private System.Windows.Forms.DateTimePicker dtHETime;
        private System.Windows.Forms.DateTimePicker dtHSTime;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbmRNodeNumber;
        private System.Windows.Forms.Button btnRD;
        private System.Windows.Forms.Button btnRA;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}