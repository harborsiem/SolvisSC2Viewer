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
                    HeatCircuitSettings heatCircuitSettings1 = new HeatCircuitSettings(paramact.ParamList, HeatCircuit.HC1);
                    HeatCircuitSettings heatCircuitSettings2 = new HeatCircuitSettings(paramact.ParamList, HeatCircuit.HC2);
                    HeatCircuitSettings heatCircuitSettings3 = new HeatCircuitSettings(paramact.ParamList, HeatCircuit.HC3);
                    HeatingSettings heatingSettings = new HeatingSettings(paramact.ParamList);
                    WaterSettings waterSettings = new WaterSettings(paramact.ParamList);
                    CirculationSettings circulationSettings = new CirculationSettings(paramact.ParamList);
                    SolarSettings solarSettings = new SolarSettings(paramact.ParamList);
                    SuppressMask suppressMask = (SuppressMask)AppManager.ConfigManager.SDCardSuppressMask;
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = Resources.ParameterListActionParameters; //@Language Resource
                    dialog.FileInfo = paramact.FileInfo;
                    List<object> objects = new List<object>();
                    objects.Add(heatCircuitSettings1);
                    if ((suppressMask & SuppressMask.HK2) == 0) {
                        objects.Add(heatCircuitSettings2);
                    }
                    if ((suppressMask & SuppressMask.HK3) == 0) {
                        objects.Add(heatCircuitSettings3);
                    }
                    //objects.Add(heatingSettings);
                    objects.Add(waterSettings);
                    objects.Add(circulationSettings);
                    //objects.Add(solarSettings);
                    object[] selectedObjects = objects.ToArray();
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
