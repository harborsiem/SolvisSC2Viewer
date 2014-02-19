using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SolvisSC2Viewer {
    internal static class AppManager {
        public static string BaseDir { get { return Application.StartupPath; } }
        public const string ApplicationName = "SolvisSC2Viewer";
        public const string ApplicationText = "SolvisControl II Viewer";
        public static readonly string ConfigPath = "Solvis" + Path.DirectorySeparatorChar + "SolvisViewer";

        private static ActionManager actionManager = new ActionManager();
        private static DataManager dataManager = GetDataManager();
        private static ItemManager itemManager = new ItemManager();
        private static IconManager iconManager = GetIconManager();
        private static ConfigManager configManager = new ConfigManager();
        private static HelpManager helpManager = new HelpManager();
        private static PrintManager printManager = new PrintManager();
        private static SolvisFileManager solvisFileManager = new SolvisFileManager();
        private static MainForm form;


        public static void Init(MainForm mainForm) {
            form = mainForm;
            itemManager.Init();
            dataManager.Init();
        }

        private static IconManager GetIconManager() {
            IconManager manager = new IconManager();
            manager.LoadIcons();
            return manager;
        }

        private static DataManager GetDataManager() {
            return DataManager.Instance;
        }

        public static DataManager DataManager {
            get { return dataManager; }
        }

        public static PrintManager PrintManager {
            get { return printManager; }
        }

        public static ActionManager ActionManager {
            get { return actionManager; }
        }

        public static Action GetAction(string name) {
            return ActionManager.GetAction(name);
        }

        public static ItemManager ItemManager {
            get { return itemManager; }
        }

        public static IconManager IconManager {
            get { return iconManager; }
        }

        public static ConfigManager ConfigManager {
            get { return configManager; }
        }

        public static HelpManager HelpManager {
            get { return helpManager; }
        }

        public static SolvisFileManager SolvisFileManager {
            get { return solvisFileManager; }
        }

        public static MainForm MainForm {
            get { return form; }
        }

    }
}
