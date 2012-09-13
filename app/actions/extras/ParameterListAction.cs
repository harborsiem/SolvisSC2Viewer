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
                HeatingSettings heatingSettings = null;
                if (!paramact.Empty) {
                    AppManager.MainForm.Cursor = Cursors.WaitCursor;
                    heatingSettings = new HeatingSettings(paramact.ParamList, 185); //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = "Parameter";
                    dialog.DateTime = paramact.DateTime;
                    dialog.SelectedObject = heatingSettings;
                    dialog.PrintProperties = PrintProperty.GetPrintProperties(dialog.SelectedObject);
                    dialog.ShowDialog(AppManager.MainForm);
                }
            }
            catch (Exception ex) {
                AppExtension.PrintStackTrace(ex);
            }
            finally {
                AppManager.MainForm.Cursor = Cursors.Default;
            }
            return 0;
        }
    }
}
