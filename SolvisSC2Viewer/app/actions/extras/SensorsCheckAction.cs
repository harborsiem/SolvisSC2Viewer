using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class SensorsCheckAction : Action {
        public const string Name = "action.extras.sensorscheck";
        private static readonly string sensorsOk = Resources.SensorsCheckActionSensorsOK; //@Language Resource
        private static readonly string sensorsNotOk = Resources.SensorsCheckActionSensorsNotOK; //@Language Resource
        private static readonly string info = Resources.SensorsCheckActionInfo; //@Language Resource

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
            switch (AppManager.DataManager.CheckS01S04()) {
                case S01S04State.S01S04Ok:
                    MessageBox.Show(sensorsOk, info, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    break;
                case S01S04State.S01S04InterChanged:
                    MessageBox.Show(sensorsNotOk, info, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    break;
                default:
                    break;
            }
        }
    }
}
