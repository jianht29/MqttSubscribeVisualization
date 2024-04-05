namespace MqttSubscribeVisualization
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiBarChart = new Sunny.UI.UIBarChart();
            this.uiLineChart = new Sunny.UI.UILineChart();
            this.uiContextMenuStrip = new Sunny.UI.UIContextMenuStrip();
            this.toolStripMenuItemDark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemMqtt = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBarChart
            // 
            this.uiBarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBarChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBarChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBarChart.Location = new System.Drawing.Point(3, 3);
            this.uiBarChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBarChart.Name = "uiBarChart";
            this.uiBarChart.Size = new System.Drawing.Size(1014, 359);
            this.uiBarChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBarChart.TabIndex = 0;
            this.uiBarChart.Text = "uiBarChart";
            // 
            // uiLineChart
            // 
            this.uiLineChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLineChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLineChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLineChart.Location = new System.Drawing.Point(3, 3);
            this.uiLineChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLineChart.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            this.uiLineChart.Name = "uiLineChart";
            this.uiLineChart.Size = new System.Drawing.Size(1014, 355);
            this.uiLineChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLineChart.TabIndex = 1;
            this.uiLineChart.Text = "uiLineChart";
            // 
            // uiContextMenuStrip
            // 
            this.uiContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDark,
            this.toolStripMenuItemLight,
            this.toolStripSeparator1,
            this.toolStripMenuItemMqtt});
            this.uiContextMenuStrip.Name = "uiContextMenuStrip";
            this.uiContextMenuStrip.Size = new System.Drawing.Size(139, 76);
            // 
            // toolStripMenuItemDark
            // 
            this.toolStripMenuItemDark.Name = "toolStripMenuItemDark";
            this.toolStripMenuItemDark.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemDark.Text = "深色主题";
            this.toolStripMenuItemDark.Click += new System.EventHandler(this.ToolStripMenuItemDark_Click);
            // 
            // toolStripMenuItemLight
            // 
            this.toolStripMenuItemLight.Name = "toolStripMenuItemLight";
            this.toolStripMenuItemLight.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemLight.Text = "浅色主题";
            this.toolStripMenuItemLight.Click += new System.EventHandler(this.ToolStripMenuItemLight_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // toolStripMenuItemMqtt
            // 
            this.toolStripMenuItemMqtt.Name = "toolStripMenuItemMqtt";
            this.toolStripMenuItemMqtt.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemMqtt.Text = "连接MQTT";
            this.toolStripMenuItemMqtt.Click += new System.EventHandler(this.ToolStripMenuItemMqtt_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 36);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiBarChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiLineChart);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 730);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ContextMenuStrip = this.uiContextMenuStrip;
            this.Controls.Add(this.splitContainer1);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip;
            this.MaximumSize = new System.Drawing.Size(4096, 2160);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.ShowDragStretch = true;
            this.ShowTitleIcon = true;
            this.Text = "MQTT订阅信息可视化";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 1341, 701);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.uiContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIBarChart uiBarChart;
        private Sunny.UI.UILineChart uiLineChart;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDark;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMqtt;
    }
}

