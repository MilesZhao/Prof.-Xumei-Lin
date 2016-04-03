namespace TempMonitoring
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改chart参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改串口参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示实时数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.chart1.BorderlineColor = System.Drawing.Color.SkyBlue;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30 | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LineColor = System.Drawing.Color.Blue;
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Blue;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.Size = 20D;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisX.ScrollBar.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.SkyBlue;
            chartArea2.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea2.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea2.AxisX.ScrollBar.LineColor = System.Drawing.Color.DarkTurquoise;
            chartArea2.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisY.Interval = 5D;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Blue;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Blue;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.Maximum = 55D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Straight;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.Name = "Chart";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 97F;
            chartArea2.Position.Width = 90F;
            chartArea2.Position.Y = 3F;
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 25);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(965, 450);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title2.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            title2.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            title2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            title2.DockedToChartArea = "Chart";
            title2.IsDockedInsideChartArea = false;
            title2.Name = "tNodeName";
            title2.Position.Auto = false;
            title2.Position.Height = 3.87667F;
            title2.Position.Width = 15F;
            title2.Position.X = 45F;
            this.chart1.Titles.Add(title2);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开串口ToolStripMenuItem,
            this.修改chart参数ToolStripMenuItem,
            this.修改串口参数ToolStripMenuItem,
            this.显示实时数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开串口ToolStripMenuItem
            // 
            this.打开串口ToolStripMenuItem.Name = "打开串口ToolStripMenuItem";
            this.打开串口ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.打开串口ToolStripMenuItem.Text = "打开串口";
            this.打开串口ToolStripMenuItem.Click += new System.EventHandler(this.打开串口ToolStripMenuItem_Click);
            // 
            // 修改chart参数ToolStripMenuItem
            // 
            this.修改chart参数ToolStripMenuItem.Name = "修改chart参数ToolStripMenuItem";
            this.修改chart参数ToolStripMenuItem.Size = new System.Drawing.Size(97, 21);
            this.修改chart参数ToolStripMenuItem.Text = "修改chart参数";
            this.修改chart参数ToolStripMenuItem.Click += new System.EventHandler(this.修改chart参数ToolStripMenuItem_Click);
            // 
            // 修改串口参数ToolStripMenuItem
            // 
            this.修改串口参数ToolStripMenuItem.Name = "修改串口参数ToolStripMenuItem";
            this.修改串口参数ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.修改串口参数ToolStripMenuItem.Text = "修改串口参数";
            this.修改串口参数ToolStripMenuItem.Click += new System.EventHandler(this.修改串口参数ToolStripMenuItem_Click);
            // 
            // 显示实时数据ToolStripMenuItem
            // 
            this.显示实时数据ToolStripMenuItem.Name = "显示实时数据ToolStripMenuItem";
            this.显示实时数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.显示实时数据ToolStripMenuItem.Text = "显示实时数据";
            this.显示实时数据ToolStripMenuItem.Click += new System.EventHandler(this.显示实时数据ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 475);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "环境监测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改chart参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改串口参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示实时数据ToolStripMenuItem;
    }
}

