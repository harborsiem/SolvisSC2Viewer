using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class Open1DayModeAction : Action {
        public const string Name = "action.file.open1daymode";

        public Open1DayModeAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            ToolStripMenuItem item = data.Sender as ToolStripMenuItem;
            if (item != null) {
                AppManager.ConfigManager.OneDayMode = item.Checked;
            }
            return 0;
        }
    }
}
