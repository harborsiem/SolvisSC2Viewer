using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class SensorsCheckAction : Action {
        public const string Name = "action.extras.sensorscheck";

        public SensorsCheckAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                CheckS01S04();
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }

        private static void CheckS01S04() {
            List<RowValues> list = AppManager.DataManager.SolvisList;
            if (list.Count > 0) {
                double s01Values = 0;
                double s04Values = 0;
                for (int i = 0; i < list.Count; i++) {
                    s01Values += list[i].S01;
                    s04Values += list[i].S04;
                }
                if (s01Values < s04Values) {
                    MessageBox.Show("Temperatur Sensoren S01 und S04 vertauscht", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                } else {
                    MessageBox.Show("Temperatur Sensoren S01 und S04 Ok", "Info", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
    }
}
