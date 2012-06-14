using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal class HelpManager {
        public static void ShowHelp() {
            string fileName = AppManager.BaseDir + Path.DirectorySeparatorChar + "SolvisViewer.chm";
            Help.ShowHelp(AppManager.MainForm, fileName);
        }
    }
}
