using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolvisSC2Viewer {
    public static class MsChartExtension {
        /// <summary>
        /// Speed up MSChart data points clear operations.
        /// </summary>
        /// <param name="sender"></param>
        public static void ClearPoints(this Series sender) {
            DataPointCollection points = sender.Points;
            points.SuspendUpdates();
            while (points.Count > 0) {
                points.RemoveAt(points.Count - 1);
            }
            points.ResumeUpdates();
            points.Clear(); //Force refresh.
        }

        public static void ClearPoints(this DataPointCollection points) {
            points.SuspendUpdates();
            while (points.Count > 0) {
                points.RemoveAt(points.Count - 1);
            }
            points.ResumeUpdates();
            points.Clear();
        }
    }
}
