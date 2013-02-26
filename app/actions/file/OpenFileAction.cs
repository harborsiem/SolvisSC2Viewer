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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "txt";
            dialog.FileName = "so*.txt";
            dialog.InitialDirectory = AppManager.ConfigManager.OpenDir;
            dialog.Filter = "Solvis File (*.txt)|*.txt"; //@Language Resource ?
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ReadOnlyChecked = true;
            dialog.Multiselect = true;
            if (dialog.ShowDialog(AppManager.MainForm) == DialogResult.OK) {
                AppManager.ConfigManager.OpenDir = Path.GetDirectoryName(dialog.FileName);
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
