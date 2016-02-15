using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace SolvisSC2Viewer {
    internal class DisposeAction : Action {
        public const string Name = "action.system.dispose";

        public DisposeAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                AppManager.ConfigManager.WriteConfig();
                AppExtension.CloseStackTrace();
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
                AppExtension.CloseStackTrace();
            }
            return 0;
        }
    }
}
