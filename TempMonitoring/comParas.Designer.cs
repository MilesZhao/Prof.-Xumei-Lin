namespace TempMonitoring
{
    partial class comParas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBPortName = new System.Windows.Forms.ComboBox();
            this.cbBBaudRate = new System.Windows.Forms.ComboBox();
            this.cbBDataBit = new System.Windows.Forms.ComboBox();
            this.cbBCheckBit = new System.Windows.Forms.ComboBox();
            this.cbBStopBit = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位";
            // 
            // cbBPortName
            // 
            this.cbBPortName.FormattingEnabled = true;
            this.cbBPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18"});
            this.cbBPortName.Location = new System.Drawing.Point(122, 32);
            this.cbBPortName.Name = "cbBPortName";
            this.cbBPortName.Size = new System.Drawing.Size(96, 20);
            this.cbBPortName.TabIndex = 5;
            this.cbBPortName.SelectedIndexChanged += new System.EventHandler(this.cbBPortName_SelectedIndexChanged);
            // 
            // cbBBaudRate
            // 
            this.cbBBaudRate.FormattingEnabled = true;
            this.cbBBaudRate.Items.AddRange(new object[] {
            "256000",
            "128000",
            "115200",
            "57600",
            "38400",
            "28800",
            "19200",
            "14400",
            "9600",
            "4800",
            "2400",
            "1200",
            "600"});
            this.cbBBaudRate.Location = new System.Drawing.Point(122, 71);
            this.cbBBaudRate.Name = "cbBBaudRate";
            this.cbBBaudRate.Size = new System.Drawing.Size(96, 20);
            this.cbBBaudRate.TabIndex = 5;
            this.cbBBaudRate.SelectedIndexChanged += new System.EventHandler(this.cbBBaudRate_SelectedIndexChanged);
            // 
            // cbBDataBit
            // 
            this.cbBDataBit.FormattingEnabled = true;
            this.cbBDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbBDataBit.Location = new System.Drawing.Point(122, 110);
            this.cbBDataBit.Name = "cbBDataBit";
            this.cbBDataBit.Size = new System.Drawing.Size(96, 20);
            this.cbBDataBit.TabIndex = 5;
            this.cbBDataBit.SelectedIndexChanged += new System.EventHandler(this.cbBDataBit_SelectedIndexChanged);
            // 
            // cbBCheckBit
            // 
            this.cbBCheckBit.FormattingEnabled = true;
            this.cbBCheckBit.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.cbBCheckBit.Location = new System.Drawing.Point(122, 149);
            this.cbBCheckBit.Name = "cbBCheckBit";
            this.cbBCheckBit.Size = new System.Drawing.Size(96, 20);
            this.cbBCheckBit.TabIndex = 5;
            this.cbBCheckBit.SelectedIndexChanged += new System.EventHandler(this.cbBCheckBit_SelectedIndexChanged);
            // 
            // cbBStopBit
            // 
            this.cbBStopBit.FormattingEnabled = true;
            this.cbBStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbBStopBit.Location = new System.Drawing.Point(122, 188);
            this.cbBStopBit.Name = "cbBStopBit";
            this.cbBStopBit.Size = new System.Drawing.Size(96, 20);
            this.cbBStopBit.TabIndex = 5;
            this.cbBStopBit.SelectedIndexChanged += new System.EventHandler(this.cbBStopBit_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(37, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(187, 238);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // comParas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 273);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbBStopBit);
            this.Controls.Add(this.cbBCheckBit);
            this.Controls.Add(this.cbBDataBit);
            this.Controls.Add(this.cbBBaudRate);
            this.Controls.Add(this.cbBPortName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "comParas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBPortName;
        private System.Windows.Forms.ComboBox cbBBaudRate;
        private System.Windows.Forms.ComboBox cbBDataBit;
        private System.Windows.Forms.ComboBox cbBCheckBit;
        private System.Windows.Forms.ComboBox cbBStopBit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}