using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace SolvisSC2Viewer {
    internal class HelpManager {
        public static void ShowHelp() {
            string chmFile;
            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de") {
                chmFile = "SolvisViewer.chm";
            } else {
                chmFile = "SolvisViewer.chm";
            }
            string fileName = AppManager.BaseDir + Path.DirectorySeparatorChar + chmFile; //@Language Resource ?
            Help.ShowHelp(AppManager.MainForm, fileName);
        }
    }
}
