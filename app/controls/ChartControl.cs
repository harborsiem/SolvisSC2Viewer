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

        public ChartControl() {
            InitializeComponent();
            chartMain.AxisViewChanged += new EventHandler<ViewEventArgs>(ChartMain_AxisViewChanged);
        }

        public Chart ChartMain {
            get { return chartMain; }
        }

        private static void CalculateLabelInterval(Axis axis) {
            double diff = axis.ScaleView.ViewMaximum - axis.ScaleView.ViewMinimum;
            if (diff > 1.03) { // > 1 day
                axis.LabelStyle.Interval = 6;
                axis.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            } else if (diff > 0.25) { // 24 hours > diff > 6 hours 
                axis.LabelStyle.Interval = 1;
                axis.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            } else if (diff > 0.085) { // 6 hours > diff > 2 hours 
                axis.LabelStyle.Interval = 15;
                axis.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            } else { // diff <= 2 hours 
                axis.LabelStyle.Interval = 5;
                axis.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            }
        }

        public void ResetZoom() {
            chartMain.SuspendLayout();
            Axis axisX = chartMain.ChartAreas["ChartArea1"].AxisX;
            axisX.LabelStyle.Angle = -90;
            if (axisX.ScaleView.IsZoomed) {
                ResetZoom(axisX);
                axisX.ScaleView.ZoomReset(100);
            }
            chartMain.ResumeLayout();
        }

        private void ResetZoom(Axis axisX) {
            chartMain.ChartAreas["ChartArea2"].AxisX.MinorGrid.Enabled = false;
            axisX.MinorGrid.Enabled = false;
            axisX.LabelStyle.Angle = -90;
            axisX.LabelStyle.Interval = 6;
            axisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
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
