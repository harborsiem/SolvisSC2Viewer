using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class CountingListAction : Action {
        public const string Name = "action.extras.countinglist";

        public CountingListAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate) {
        }

        protected override int Execute(ActionData data) {
            try {
                ConfigManager manager = AppManager.ConfigManager;
                FileToInt32List zaehlstand = new FileToInt32List(manager.SdCardDir, "zaehlst.txt");
                CountingSettings countingSettings = null;
                if (!zaehlstand.Empty) {
                    AppManager.MainForm.Cursor = Cursors.WaitCursor;
                    countingSettings = new CountingSettings(zaehlstand.ParamList);
                    PropertiesForm dialog = new PropertiesForm();
                    dialog.Description = Resources.CountingListActionCountings; //@Language Resource
                    dialog.FileInfo = zaehlstand.FileInfo;
                    BasicPropertyBag bag = new BasicPropertyBag(new object[] { countingSettings });
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
