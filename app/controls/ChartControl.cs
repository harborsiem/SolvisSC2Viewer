using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public partial class ChartControl : UserControl {
        private double resetZoomInterval = 6D;
        private double resetZoomAxisInterval = 1D;

        public ChartControl() {
            InitializeComponent();
            chartMain.ChartAreas["ChartArea1"].AxisX.StripLines[0].Text = Resources.ChartControlNewDay; //@Language Resource
            chartMain.AxisViewChanged += new EventHandler<ViewEventArgs>(ChartMain_AxisViewChanged);
            chartMain.PrePaint += new EventHandler<ChartPaintEventArgs>(chartMain_PrePaint);
        }

        void chartMain_PrePaint(object sender, ChartPaintEventArgs e) {
            ChartArea area1 = chartMain.ChartAreas["ChartArea1"];
            if (double.IsNaN(area1.AxisY.Maximum)) {
                return;
            }
            if (area1.AxisY.Maximum <= 100.0) {
                area1.AxisY.MajorGrid.Interval = 5;
            } else {
                area1.AxisY.MajorGrid.Interval = 20;
            }
        }

        public Chart ChartMain {
            get { return chartMain; }
        }

        private static void CalculateLabelInterval(Axis axisX1) {
            double diff = axisX1.ScaleView.ViewMaximum - axisX1.ScaleView.ViewMinimum;
            if (diff > 7.03) { // > 7 days
                axisX1.Interval = 6;
                axisX1.LabelStyle.Interval = 24;
                axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            } else if (diff > 1.03) { // > 1 day
                axisX1.Interval = 1;
                axisX1.LabelStyle.Interval = 6;
                axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            } else if (diff > 0.25) { // 24 hours > diff > 6 hours 
                axisX1.Interval = 1;
                axisX1.LabelStyle.Interval = 1;
                axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            } else if (diff > 0.085) { // 6 hours > diff > 2 hours 
                axisX1.Interval = 1;
                axisX1.LabelStyle.Interval = 15;
                axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            } else { // diff <= 2 hours 
                axisX1.Interval = 1;
                axisX1.LabelStyle.Interval = 5;
                axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            }
        }

        public void ResetZoom() {
            chartMain.SuspendLayout();
            Axis axisX1 = chartMain.ChartAreas["ChartArea1"].AxisX;
            axisX1.LabelStyle.Angle = -90;
            if (axisX1.ScaleView.IsZoomed) {
                ResetZoom(axisX1);
                axisX1.ScaleView.ZoomReset(100);
            }
            chartMain.ResumeLayout();
        }

        private void ResetZoom(Axis axisX1) {
            chartMain.ChartAreas["ChartArea2"].AxisX.MinorGrid.Enabled = false;
            axisX1.MinorGrid.Enabled = false;
            axisX1.LabelStyle.Angle = -90;
            axisX1.Interval = resetZoomAxisInterval;
            axisX1.LabelStyle.Interval = resetZoomInterval;
            axisX1.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
        }

        public void SetCursorCrossHairState() {
            chartMain.SuspendLayout();
            ChartArea area1 = chartMain.ChartAreas["ChartArea1"];
            ChartArea area2 = chartMain.ChartAreas["ChartArea2"];
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorX1 = area1.CursorX;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorY1 = area1.CursorY;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorX2 = area2.CursorX;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorY2 = area2.CursorY;
            cursorX1.IsUserSelectionEnabled = false;
            cursorX1.IntervalType = DateTimeIntervalType.Minutes;
            cursorX2.IsUserSelectionEnabled = false;
            cursorX2.IntervalType = DateTimeIntervalType.Minutes;
            cursorY1.IsUserEnabled = true;
            cursorY1.LineWidth = 1;
            cursorY2.IsUserEnabled = true;
            cursorY2.LineWidth = 1;
            chartMain.ResumeLayout();
        }

        public void SetCursorSelectionState() {
            chartMain.SuspendLayout();
            ChartArea area1 = chartMain.ChartAreas["ChartArea1"];
            ChartArea area2 = chartMain.ChartAreas["ChartArea2"];
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorX1 = area1.CursorX;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorY1 = area1.CursorY;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorX2 = area2.CursorX;
            System.Windows.Forms.DataVisualization.Charting.Cursor cursorY2 = area2.CursorY;
            cursorX1.IsUserSelectionEnabled = true;
            cursorX1.IntervalType = DateTimeIntervalType.Hours;
            cursorX2.IsUserSelectionEnabled = true;
            cursorX2.IntervalType = DateTimeIntervalType.Hours;
            cursorY1.IsUserEnabled = false;
            cursorY1.LineWidth = 0;
            cursorY2.IsUserEnabled = false;
            cursorY2.LineWidth = 0;
            chartMain.ResumeLayout();
        }

        public void SetIntervals(TimeSpan delta) {
            Axis axisX1 = chartMain.ChartAreas["ChartArea1"].AxisX;
            Axis axisX2 = chartMain.ChartAreas["ChartArea2"].AxisX;
            if (delta <= new TimeSpan(7, 0, 3, 0)) {
                axisX1.MajorGrid.Interval = 6D;
                axisX1.LabelStyle.Interval = 6D;
                axisX2.MajorGrid.Interval = 6D;
                axisX2.LabelStyle.Interval = 6D;
                axisX1.Interval = 1D;
                resetZoomInterval = 6D;
                resetZoomAxisInterval = 1D;
            } else {
                axisX1.MajorGrid.Interval = 24D;
                axisX1.LabelStyle.Interval = 24D;
                axisX2.MajorGrid.Interval = 24D;
                axisX2.LabelStyle.Interval = 24D;
                axisX1.Interval = 6D;
                resetZoomInterval = 24D;
                resetZoomAxisInterval = 6D;
            }
        }

        private void ChartMain_AxisViewChanged(object sender, ViewEventArgs e) {
            if (e.Axis.AxisName == AxisName.X) {
                chartMain.SuspendLayout();
                Axis axisX1 = chartMain.ChartAreas["ChartArea1"].AxisX;
                if (axisX1.ScrollBar.IsVisible) {
                    chartMain.ChartAreas["ChartArea2"].AxisX.MinorGrid.Enabled = true;
                    axisX1.MinorGrid.Enabled = true;
                    axisX1.LabelStyle.Angle = -90;
                    CalculateLabelInterval(axisX1);
                } else {
                    ResetZoom(axisX1);
                }
                chartMain.ResumeLayout();
            }
        }
    }
}
