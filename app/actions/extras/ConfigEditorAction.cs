using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class ConfigEditorAction : Action {
        public const string Name = "action.extras.configeditor";

        public ConfigEditorAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                ConfigEditor dialog = new ConfigEditor();
                dialog.ShowDialog(AppManager.MainForm);
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
