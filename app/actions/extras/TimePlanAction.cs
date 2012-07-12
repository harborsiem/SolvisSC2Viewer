using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class TimePlanAction : Action {
        public const string Name = "action.extras.timeplan";

        public TimePlanAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                ConfigManager manager = AppManager.ConfigManager;
                if (string.IsNullOrWhiteSpace(manager.SdCardDir)) {
                    FolderBrowserDialog folder = new FolderBrowserDialog();
                    if (folder.ShowDialog() == DialogResult.OK) {
                        manager.SdCardDir = folder.SelectedPath;
                    } else {
                        return 0;
                    }
                }
                FileToInt32List timePlan = new FileToInt32List(manager.SdCardDir, "zeitplan.txt");
                if (!timePlan.Empty) {
                    TimeOverview dialog = new TimeOverview();
                    dialog.TimePlan = timePlan;
                    dialog.SaveFormBitmap = manager.TimePlanBitmap;
                    dialog.SuppressMask = (SuppressMask)manager.TimePlanSuppressMask;
                    dialog.ShowDialog(AppManager.MainForm);
                }
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
