namespace SolvisSC2Viewer {
    partial class HeatCurve {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatCurve));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupCurve1 = new System.Windows.Forms.GroupBox();
            this.group1Layout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel1 = new System.Windows.Forms.Label();
            this.temperatureUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.niveauLabel1 = new System.Windows.Forms.Label();
            this.niveauUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel1 = new System.Windows.Forms.Label();
            this.gradientUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupCurve2 = new System.Windows.Forms.GroupBox();
            this.group2Layout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel2 = new System.Windows.Forms.Label();
            this.temperatureUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.niveauLabel2 = new System.Windows.Forms.Label();
            this.niveauUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel2 = new System.Windows.Forms.Label();
            this.gradientUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupCurve3 = new System.Windows.Forms.GroupBox();
            this.group3Layout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel3 = new System.Windows.Forms.Label();
            this.temperatureUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.niveauLabel3 = new System.Windows.Forms.Label();
            this.niveauUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel3 = new System.Windows.Forms.Label();
            this.gradientUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.closeButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.printHeadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationHeadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve1FloorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve1RoundItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve1NotRoundItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.curve2FloorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve2RoundItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve2NotRoundItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.bottomLayout.SuspendLayout();
            this.groupCurve1.SuspendLayout();
            this.group1Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown1)).BeginInit();
            this.groupCurve2.SuspendLayout();
            this.group2Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown2)).BeginInit();
            this.groupCurve3.SuspendLayout();
            this.group3Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown3)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogLayout
            // 
            resources.ApplyResources(this.dialogLayout, "dialogLayout");
            this.dialogLayout.Controls.Add(this.chartMain, 0, 0);
            this.dialogLayout.Controls.Add(this.bottomLayout, 0, 1);
            this.dialogLayout.Name = "dialogLayout";
            // 
            // chartMain
            // 
            chartArea1.AxisX.Interval = 2D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Maximum = 20D;
            chartArea1.AxisX.Minimum = -20D;
            chartArea1.AxisX.Title = "Outdoor Temp.";
            chartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisY.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY2.Interval = 5D;
            chartArea1.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisY2.Maximum = 70D;
            chartArea1.AxisY2.Minimum = 15D;
            chartArea1.AxisY2.Title = "Vorlauf Temp.";
            chartArea1.AxisY2.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.chartMain, "chartMain");
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Curve1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Curve2";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Ideal";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartMain.Series.Add(series1);
            this.chartMain.Series.Add(series2);
            this.chartMain.Series.Add(series3);
            this.chartMain.TabStop = false;
            title1.Name = "Title1";
            this.chartMain.Titles.Add(title1);
            // 
            // bottomLayout
            // 
            resources.ApplyResources(this.bottomLayout, "bottomLayout");
            this.bottomLayout.Controls.Add(this.groupCurve1, 0, 0);
            this.bottomLayout.Controls.Add(this.groupCurve2, 1, 0);
            this.bottomLayout.Controls.Add(this.groupCurve3, 2, 0);
            this.bottomLayout.Controls.Add(this.closeButton, 3, 0);
            this.bottomLayout.Name = "bottomLayout";
            // 
            // groupCurve1
            // 
            resources.ApplyResources(this.groupCurve1, "groupCurve1");
            this.groupCurve1.Controls.Add(this.group1Layout);
            this.groupCurve1.Name = "groupCurve1";
            this.groupCurve1.TabStop = false;
            // 
            // group1Layout
            // 
            resources.ApplyResources(this.group1Layout, "group1Layout");
            this.group1Layout.Controls.Add(this.temperatureLabel1, 0, 0);
            this.group1Layout.Controls.Add(this.temperatureUpDown1, 1, 0);
            this.group1Layout.Controls.Add(this.niveauLabel1, 0, 1);
            this.group1Layout.Controls.Add(this.niveauUpDown1, 1, 1);
            this.group1Layout.Controls.Add(this.gradientLabel1, 0, 2);
            this.group1Layout.Controls.Add(this.gradientUpDown1, 1, 2);
            this.group1Layout.Name = "group1Layout";
            // 
            // temperatureLabel1
            // 
            resources.ApplyResources(this.temperatureLabel1, "temperatureLabel1");
            this.temperatureLabel1.MinimumSize = new System.Drawing.Size(69, 0);
            this.temperatureLabel1.Name = "temperatureLabel1";
            // 
            // temperatureUpDown1
            // 
            resources.ApplyResources(this.temperatureUpDown1, "temperatureUpDown1");
            this.temperatureUpDown1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.temperatureUpDown1.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.temperatureUpDown1.Name = "temperatureUpDown1";
            this.temperatureUpDown1.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // niveauLabel1
            // 
            resources.ApplyResources(this.niveauLabel1, "niveauLabel1");
            this.niveauLabel1.Name = "niveauLabel1";
            // 
            // niveauUpDown1
            // 
            resources.ApplyResources(this.niveauUpDown1, "niveauUpDown1");
            this.niveauUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.niveauUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.niveauUpDown1.Name = "niveauUpDown1";
            // 
            // gradientLabel1
            // 
            resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
            this.gradientLabel1.Name = "gradientLabel1";
            // 
            // gradientUpDown1
            // 
            resources.ApplyResources(this.gradientUpDown1, "gradientUpDown1");
            this.gradientUpDown1.DecimalPlaces = 2;
            this.gradientUpDown1.Name = "gradientUpDown1";
            // 
            // groupCurve2
            // 
            resources.ApplyResources(this.groupCurve2, "groupCurve2");
            this.groupCurve2.Controls.Add(this.group2Layout);
            this.groupCurve2.Name = "groupCurve2";
            this.groupCurve2.TabStop = false;
            // 
            // group2Layout
            // 
            resources.ApplyResources(this.group2Layout, "group2Layout");
            this.group2Layout.Controls.Add(this.temperatureLabel2, 0, 0);
            this.group2Layout.Controls.Add(this.temperatureUpDown2, 1, 0);
            this.group2Layout.Controls.Add(this.niveauLabel2, 0, 1);
            this.group2Layout.Controls.Add(this.niveauUpDown2, 1, 1);
            this.group2Layout.Controls.Add(this.gradientLabel2, 0, 2);
            this.group2Layout.Controls.Add(this.gradientUpDown2, 1, 2);
            this.group2Layout.Name = "group2Layout";
            // 
            // temperatureLabel2
            // 
            resources.ApplyResources(this.temperatureLabel2, "temperatureLabel2");
            this.temperatureLabel2.MinimumSize = new System.Drawing.Size(69, 0);
            this.temperatureLabel2.Name = "temperatureLabel2";
            // 
            // temperatureUpDown2
            // 
            resources.ApplyResources(this.temperatureUpDown2, "temperatureUpDown2");
            this.temperatureUpDown2.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.temperatureUpDown2.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.temperatureUpDown2.Name = "temperatureUpDown2";
            this.temperatureUpDown2.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // niveauLabel2
            // 
            resources.ApplyResources(this.niveauLabel2, "niveauLabel2");
            this.niveauLabel2.Name = "niveauLabel2";
            // 
            // niveauUpDown2
            // 
            resources.ApplyResources(this.niveauUpDown2, "niveauUpDown2");
            this.niveauUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.niveauUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.niveauUpDown2.Name = "niveauUpDown2";
            // 
            // gradientLabel2
            // 
            resources.ApplyResources(this.gradientLabel2, "gradientLabel2");
            this.gradientLabel2.Name = "gradientLabel2";
            // 
            // gradientUpDown2
            // 
            resources.ApplyResources(this.gradientUpDown2, "gradientUpDown2");
            this.gradientUpDown2.DecimalPlaces = 2;
            this.gradientUpDown2.Name = "gradientUpDown2";
            // 
            // groupCurve3
            // 
            resources.ApplyResources(this.groupCurve3, "groupCurve3");
            this.groupCurve3.Controls.Add(this.group3Layout);
            this.groupCurve3.Name = "groupCurve3";
            this.groupCurve3.TabStop = false;
            // 
            // group3Layout
            // 
            resources.ApplyResources(this.group3Layout, "group3Layout");
            this.group3Layout.Controls.Add(this.temperatureLabel3, 0, 0);
            this.group3Layout.Controls.Add(this.temperatureUpDown3, 1, 0);
            this.group3Layout.Controls.Add(this.niveauLabel3, 0, 1);
            this.group3Layout.Controls.Add(this.niveauUpDown3, 1, 1);
            this.group3Layout.Controls.Add(this.gradientLabel3, 0, 2);
            this.group3Layout.Controls.Add(this.gradientUpDown3, 1, 2);
            this.group3Layout.Name = "group3Layout";
            // 
            // temperatureLabel3
            // 
            resources.ApplyResources(this.temperatureLabel3, "temperatureLabel3");
            this.temperatureLabel3.MinimumSize = new System.Drawing.Size(69, 0);
            this.temperatureLabel3.Name = "temperatureLabel3";
            // 
            // temperatureUpDown3
            // 
            resources.ApplyResources(this.temperatureUpDown3, "temperatureUpDown3");
            this.temperatureUpDown3.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.temperatureUpDown3.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.temperatureUpDown3.Name = "temperatureUpDown3";
            this.temperatureUpDown3.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // niveauLabel3
            // 
            resources.ApplyResources(this.niveauLabel3, "niveauLabel3");
            this.niveauLabel3.Name = "niveauLabel3";
            // 
            // niveauUpDown3
            // 
            resources.ApplyResources(this.niveauUpDown3, "niveauUpDown3");
            this.niveauUpDown3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.niveauUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.niveauUpDown3.Name = "niveauUpDown3";
            // 
            // gradientLabel3
            // 
            resources.ApplyResources(this.gradientLabel3, "gradientLabel3");
            this.gradientLabel3.Name = "gradientLabel3";
            // 
            // gradientUpDown3
            // 
            resources.ApplyResources(this.gradientUpDown3, "gradientUpDown3");
            this.gradientUpDown3.DecimalPlaces = 2;
            this.gradientUpDown3.Name = "gradientUpDown3";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printHeadItem,
            this.configurationHeadItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.TabStop = true;
            // 
            // printHeadItem
            // 
            this.printHeadItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewItem,
            this.printItem});
            this.printHeadItem.Name = "printHeadItem";
            resources.ApplyResources(this.printHeadItem, "printHeadItem");
            // 
            // printPreviewItem
            // 
            this.printPreviewItem.Name = "printPreviewItem";
            resources.ApplyResources(this.printPreviewItem, "printPreviewItem");
            this.printPreviewItem.Click += new System.EventHandler(this.printPreviewItem_Click);
            // 
            // printItem
            // 
            this.printItem.Name = "printItem";
            resources.ApplyResources(this.printItem, "printItem");
            this.printItem.Click += new System.EventHandler(this.printItem_Click);
            // 
            // configurationHeadItem
            // 
            this.configurationHeadItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curve1FloorItem,
            this.curve1RoundItem,
            this.curve1NotRoundItem,
            this.seperator1,
            this.curve2FloorItem,
            this.curve2RoundItem,
            this.curve2NotRoundItem});
            this.configurationHeadItem.Name = "configurationHeadItem";
            resources.ApplyResources(this.configurationHeadItem, "configurationHeadItem");
            // 
            // curve1FloorItem
            // 
            this.curve1FloorItem.Name = "curve1FloorItem";
            resources.ApplyResources(this.curve1FloorItem, "curve1FloorItem");
            this.curve1FloorItem.Click += new System.EventHandler(this.curve1RoundItem_Click);
            // 
            // curve1RoundItem
            // 
            this.curve1RoundItem.Name = "curve1RoundItem";
            resources.ApplyResources(this.curve1RoundItem, "curve1RoundItem");
            this.curve1RoundItem.Click += new System.EventHandler(this.curve1FloorItem_Click);
            // 
            // curve1NotRoundItem
            // 
            this.curve1NotRoundItem.Name = "curve1NotRoundItem";
            resources.ApplyResources(this.curve1NotRoundItem, "curve1NotRoundItem");
            this.curve1NotRoundItem.Click += new System.EventHandler(this.curve1NotRoundItem_Click);
            // 
            // seperator1
            // 
            this.seperator1.Name = "seperator1";
            resources.ApplyResources(this.seperator1, "seperator1");
            // 
            // curve2FloorItem
            // 
            this.curve2FloorItem.Name = "curve2FloorItem";
            resources.ApplyResources(this.curve2FloorItem, "curve2FloorItem");
            this.curve2FloorItem.Click += new System.EventHandler(this.curve2RoundItem_Click);
            // 
            // curve2RoundItem
            // 
            this.curve2RoundItem.Name = "curve2RoundItem";
            resources.ApplyResources(this.curve2RoundItem, "curve2RoundItem");
            this.curve2RoundItem.Click += new System.EventHandler(this.curve2FloorItem_Click);
            // 
            // curve2NotRoundItem
            // 
            this.curve2NotRoundItem.Name = "curve2NotRoundItem";
            resources.ApplyResources(this.curve2NotRoundItem, "curve2NotRoundItem");
            this.curve2NotRoundItem.Click += new System.EventHandler(this.curve2NotRoundItem_Click);
            // 
            // HeatCurve
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dialogLayout);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HeatCurve";
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.groupCurve1.ResumeLayout(false);
            this.groupCurve1.PerformLayout();
            this.group1Layout.ResumeLayout(false);
            this.group1Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown1)).EndInit();
            this.groupCurve2.ResumeLayout(false);
            this.groupCurve2.PerformLayout();
            this.group2Layout.ResumeLayout(false);
            this.group2Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown2)).EndInit();
            this.groupCurve3.ResumeLayout(false);
            this.groupCurve3.PerformLayout();
            this.group3Layout.ResumeLayout(false);
            this.group3Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown3)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.GroupBox groupCurve1;
        private System.Windows.Forms.TableLayoutPanel group1Layout;
        private System.Windows.Forms.Label temperatureLabel1;
        private System.Windows.Forms.NumericUpDown temperatureUpDown1;
        private System.Windows.Forms.Label niveauLabel1;
        private System.Windows.Forms.NumericUpDown niveauUpDown1;
        private System.Windows.Forms.Label gradientLabel1;
        private System.Windows.Forms.NumericUpDown gradientUpDown1;
        private System.Windows.Forms.GroupBox groupCurve2;
        private System.Windows.Forms.TableLayoutPanel group2Layout;
        private System.Windows.Forms.Label temperatureLabel2;
        private System.Windows.Forms.NumericUpDown temperatureUpDown2;
        private System.Windows.Forms.Label niveauLabel2;
        private System.Windows.Forms.NumericUpDown niveauUpDown2;
        private System.Windows.Forms.Label gradientLabel2;
        private System.Windows.Forms.NumericUpDown gradientUpDown2;
        private System.Windows.Forms.GroupBox groupCurve3;
        private System.Windows.Forms.TableLayoutPanel group3Layout;
        private System.Windows.Forms.Label temperatureLabel3;
        private System.Windows.Forms.NumericUpDown temperatureUpDown3;
        private System.Windows.Forms.Label niveauLabel3;
        private System.Windows.Forms.NumericUpDown niveauUpDown3;
        private System.Windows.Forms.Label gradientLabel3;
        private System.Windows.Forms.NumericUpDown gradientUpDown3;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem printHeadItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewItem;
        private System.Windows.Forms.ToolStripMenuItem printItem;
        private System.Windows.Forms.ToolStripMenuItem configurationHeadItem;
        private System.Windows.Forms.ToolStripMenuItem curve1FloorItem;
        private System.Windows.Forms.ToolStripMenuItem curve1RoundItem;
        private System.Windows.Forms.ToolStripMenuItem curve1NotRoundItem;
        private System.Windows.Forms.ToolStripSeparator seperator1;
        private System.Windows.Forms.ToolStripMenuItem curve2FloorItem;
        private System.Windows.Forms.ToolStripMenuItem curve2RoundItem;
        private System.Windows.Forms.ToolStripMenuItem curve2NotRoundItem;
    }
}