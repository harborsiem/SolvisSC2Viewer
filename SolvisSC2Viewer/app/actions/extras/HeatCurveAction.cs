using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class HeatCurveAction : Action {
        public const string Name = "action.extras.heatcurve";

        public HeatCurveAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                HeatCurve dialog = HeatCurve.Instance;
                if (dialog.WindowState == FormWindowState.Minimized) {
                    dialog.WindowState = HeatCurveHelper.LastWindowState;
                }
                if (!dialog.Visible) {
                    dialog.Show(AppManager.MainForm);
                }
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
