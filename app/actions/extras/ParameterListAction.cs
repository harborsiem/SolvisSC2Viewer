using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class ParameterListAction : Action {
        public const string Name = "action.extras.parameterlist";

        public ParameterListAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                ConfigManager manager = AppManager.ConfigManager;
                FileToInt32List paramact = new FileToInt32List(manager.SdCardDir, "paramact.txt");
                HeatSettings heatSettings = null;
                if (!paramact.Empty) {
                    heatSettings = new HeatSettings(paramact.ParamList, 187); //Beginn: HK1 = 187; HK2 = 233; HK3 = 279 (HK1 evtl. schon ab 184 ?)
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = "Parameter";
                    dialog.DateTime = paramact.DateTime;
                    dialog.SelectedObject = heatSettings;
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
