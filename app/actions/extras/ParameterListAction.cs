using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

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
                if (!paramact.Empty) {
                    AppManager.MainForm.Cursor = Cursors.WaitCursor;
                    HeatingSettings heatingSettings = new HeatingSettings(paramact.ParamList, 185); //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)
                    WaterSettings waterSettings = new WaterSettings(paramact.ParamList);
                    CirculationSettings circulationSettings = new CirculationSettings(paramact.ParamList);
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = Resources.ParameterListActionParameters; //@Language Resource
                    dialog.FileInfo = paramact.FileInfo;
                    object[] selectedObjects = new object[] { heatingSettings, waterSettings, circulationSettings };
                    BasicPropertyBag bag = new BasicPropertyBag(selectedObjects);
                    dialog.SelectedObject = bag;
                    dialog.PrintProperties = PrintProperty.GetPrintProperties(bag);
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
