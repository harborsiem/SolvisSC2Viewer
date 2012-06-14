using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class ExitAction : Action {
        public const string Name = "action.file.exit";

        public ExitAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            try {
                Application.Exit();
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
