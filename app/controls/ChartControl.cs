using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolvisSC2Viewer {
    public partial class ChartControl : UserControl {
        //public Chart chartMain;
        //private ChartArea chartArea2;
        //private ChartArea chartArea2;
        //private Series series1;

        public ChartControl() {
            InitializeComponent();
            //InitChart(); //@Todo entfernen
        }

        public Chart ChartMain {
            get { return chartMain; }
        }

        //private void InitChart() {
        //    this.controlPanel.SuspendLayout();
        //    this.chartMain = new Chart();
        //    this.chartMain.BeginInit();
        //    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new ChartArea();
        //    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new ChartArea();
        //    chartArea1.Name = "ChartArea1";
        //    chartArea2.Name = "ChartArea2";
        //    chartArea1.CursorX.SelectionColor = System.Drawing.Color.LightBlue;
        //    chartArea1.CursorX.IsUserEnabled = true;
        //    chartArea1.CursorX.IsUserSelectionEnabled = true;
        //    chartArea1.CursorX.Interval = 1;
        //    chartArea1.CursorX.IntervalType = DateTimeIntervalType.Hours;
        //    chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
        //    chartArea1.CursorX.AutoScroll = true;
        //    chartArea1.AxisX.ScaleView.SmallScrollSize = 1;
        //    chartArea1.AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Hours;
        //    chartArea1.AxisX.ScaleView.SizeType = DateTimeIntervalType.Hours;
        //    this.chartMain.ChartAreas.Add(chartArea1);
        //    //this.chartMain.ChartAreas.Add(chartArea2);
        //    chartArea1.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
        //    chartArea1.AxisX.MinorGrid.LineWidth = 1;
        //    chartArea1.AxisX.MinorGrid.Enabled = true;
        //    chartArea1.AxisX.MinorGrid.Interval = 1;
        //    chartArea1.AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Hours;
        //    chartArea1.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
        //    chartArea1.AxisX.MinorGrid.LineColor = Color.LightGray;
        //    //chartArea2.AxisX.MajorTickMark.Interval = 1;
        //    chartArea1.AxisX.MajorGrid.Enabled = true;
        //    chartArea1.AxisX.MajorGrid.Interval = 6;
        //    chartArea1.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        //    chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
        //    chartArea1.AxisX.Interval = 1;
        //    chartArea1.AxisX.IntervalType = DateTimeIntervalType.Hours;
        //    chartArea1.AxisX.IntervalOffsetType = DateTimeIntervalType.Hours;
        //    //chartArea2.AxisX.IntervalOffset = 6;
        //    //chartArea2.AxisX.LabelStyle.IntervalOffset = 6;
        //    chartArea1.AxisX.LabelStyle.Enabled = true;
        //    chartArea1.AxisX.LabelStyle.Angle = -90;
        //    chartArea1.AxisX.LabelStyle.Interval = 3;
        //    chartArea1.AxisX.LabelStyle.IntervalOffsetType = DateTimeIntervalType.Minutes;
        //    chartArea1.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
        //    chartArea1.AxisX.LabelStyle.Format = "dd.MM-HH:mm"; //24h Format
        //    StripLine line = new StripLine();
        //    line.Interval = 1;
        //    line.IntervalType = DateTimeIntervalType.Days;
        //    line.Text = "new day";
        //    chartArea1.AxisX.StripLines.Add(line);
        //    chartArea1.AxisY.MajorGrid.Interval = 5;
        //    chartArea1.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        //    chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
        //    //this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        //    //| System.Windows.Forms.AnchorStyles.Left)
        //    //)));
        //    this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.chartMain.Location = new System.Drawing.Point(0, 0);
        //    this.chartMain.Margin = new Padding(0);
        //    //this.chartMain.Size = new Size(782, 503);
        //    this.chartMain.Name = "chartMain";
        //    this.controlPanel.Controls.Add(chartMain);
        //    this.chartMain.EndInit();
        //    this.controlPanel.ResumeLayout();
        //}
    }
}
