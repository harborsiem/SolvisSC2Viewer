using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class AboutAction : Action {
        public const string Name = "action.help.about";

        public AboutAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            try {
                AboutDialog dialog = new AboutDialog();
                dialog.Init();
                if (dialog.ShowDialog(AppManager.MainForm) == DialogResult.OK) {
                }
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
