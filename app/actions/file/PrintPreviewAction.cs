using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Printing;

namespace SolvisSC2Viewer {
    internal class PrintPreviewAction : Action {
        public const string Name = "action.file.print-preview";

        public PrintPreviewAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            try {
                PrintingManager manager = AppManager.MainForm.ChartControl.ChartMain.Printing;
                manager.PrintDocument.DefaultPageSettings.Landscape = true;
                manager.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.ClientSize = new Size(800, 600);
                dialog.Document = manager.PrintDocument;
                dialog.Icon = AppManager.IconManager.PrintPreviewIcon;

                dialog.ShowDialog(AppManager.MainForm);


                //manager.PrintPreview();
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
