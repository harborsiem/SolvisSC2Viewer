using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class CounterListAction : Action {
        public const string Name = "action.extras.counterlist";

        public CounterListAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                ConfigManager manager = AppManager.ConfigManager;
                FileToInt32List zaehlstand = new FileToInt32List(manager.SdCardDir, "zaehlst.txt");
                CounterSettings counterSettings = null;
                if (!zaehlstand.Empty) {
                    AppManager.MainForm.Cursor = Cursors.WaitCursor;
                    counterSettings = new CounterSettings(zaehlstand.ParamList);
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = Resources.CounterListActionCounter; //@Language Resource
                    dialog.FileInfo = zaehlstand.FileInfo;
                    BasicPropertyBag bag = new BasicPropertyBag(new object[] { counterSettings });
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
