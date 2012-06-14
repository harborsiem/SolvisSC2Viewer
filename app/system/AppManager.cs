using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    internal static class AppManager {
        private static string baseDir = Application.StartupPath;
        private static ActionManager actionManager = new ActionManager();
        private static DataManager dataManager = GetDataManager();
        private static ItemManager itemManager = new ItemManager();
        private static IconManager iconManager = GetIconManager();
        private static ConfigManager configManager = new ConfigManager();
        private static HelpManager helpManager = new HelpManager();
        private static PrintManager printManager = new PrintManager();
        private static MainForm form;
        public static string BaseDir { get { return baseDir; } }

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

        public static MainForm MainForm {
            get { return form; }
        }

    }
}
