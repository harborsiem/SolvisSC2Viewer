using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;

namespace SolvisSC2Viewer {
    internal class PrintAction : Action {
        public const string Name = "action.file.print";

        public PrintAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            try {
                PrintingManager manager = AppManager.MainForm.ChartControl.ChartMain.Printing;
                manager.PrintDocument.DefaultPageSettings.Landscape = true;
                manager.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
                manager.Print(true);
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
