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
            RowValues.SelectedSolvisControlVersion = 131;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "txt";
            dialog.FileName = "";
            string solvisFiles = "Solvis Files"; //@Language Resource ?
            if (RowValues.SolvisControlVersion < 132) {
                dialog.Filter = solvisFiles + " (so*.txt)|so*.txt|" + solvisFiles + " (mi*.txt)|mi*.txt";
            } else {
                dialog.Filter = solvisFiles + " (mi*.txt)|mi*.txt|" + solvisFiles + " (so*.txt)|so*.txt";
            }
            dialog.InitialDirectory = AppManager.ConfigManager.OpenDir;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ReadOnlyChecked = true;
            dialog.Multiselect = true;
            if (dialog.ShowDialog(AppManager.MainForm) == DialogResult.OK) {
                AppManager.ConfigManager.OpenDir = Path.GetDirectoryName(dialog.FileName);
                string fileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                if (fileName.StartsWith("MI", StringComparison.OrdinalIgnoreCase)) {
                    RowValues.SelectedSolvisControlVersion = 132;
                }
                string[] names = dialog.FileNames;
                if (names.Length > 0) {
                    Array.Sort(names);

                    AppManager.SolvisFileManager.NewFileSelection(names);
                    AppManager.DataManager.FillSolvisList(names[0]);
                }
            }
            return 0;
        }
    }
}
