using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class OpenFileAction : Action {
        public const string Name = "action.file.openfile";

        public OpenFileAction()
            : base(Name, AutoLock | AutoUnlock | AutoUpdate | KeyBindingAvailable) {
        }

        protected override int Execute(ActionData data) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = "txt";
                dialog.FileName = "so*.txt";
                dialog.InitialDirectory = AppManager.ConfigManager.OpenDir;
                dialog.Filter = "Solvis File (*.txt)|*.txt";
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ReadOnlyChecked = true;
                if (dialog.ShowDialog(AppManager.MainForm) == DialogResult.OK) {
                    AppManager.MainForm.Cursor = Cursors.WaitCursor;
                    RowValues.mean.Reset();
                    AppManager.ConfigManager.OpenDir = Path.GetDirectoryName(dialog.FileName);
                    AppManager.DataManager.SolvisList.Clear();
                    StreamReader reader = File.OpenText(dialog.FileName);
                    try {
                        List<RowValues> list = AppManager.DataManager.SolvisList;
                        while (!reader.EndOfStream) {
                            RowValues item = new RowValues(reader.ReadLine());
                            list.Add(item);
                        }
                        DateTime min = (list[0].DateAndTime);
                        DateTime max = (list[list.Count - 1].DateAndTime);
                        AppManager.ItemManager.ToolMenu.SetMinMaxDate(min, max);
                        //AppManager.MainForm.Text = MainForm.ApplicationText + "; Datei: " + Path.GetFileNameWithoutExtension(dialog.FileName);
                    }
                    finally {
                        if (reader != null) {
                            reader.Close();
                        }
                        AppManager.MainForm.Cursor = Cursors.Default;
                    }
                    //AppManager.DataManager.Serialize();
                    //AppManager.DataManager.DeSerialize();
                    AppManager.ItemManager.UpdateItems();
                }
            }
            catch (ArgumentException ex) {
                AppManager.DataManager.SolvisList.Clear();
                DateTime now = DateTime.Now;
                AppManager.ItemManager.ToolMenu.SetMinMaxDate(now, now);
                AppManager.ItemManager.UpdateItems();
                AppExtension.PrintStackTrace(ex);
            }
            return 0;
        }
    }
}
