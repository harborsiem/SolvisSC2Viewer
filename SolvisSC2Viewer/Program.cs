using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SolvisSC2Viewer {
    static class Program {
        //The mutex is for starting the programm just once
        private static Mutex mutex;

        private static string GetGuid() {
            Assembly ass = Assembly.GetEntryAssembly();
            object[] obj = ass.GetCustomAttributes(typeof(GuidAttribute), false);
            return ((GuidAttribute)obj[0]).Value;
        }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            bool ok;
            mutex = new Mutex(true, GetGuid(), out ok); //single instance
            if (!ok) {
                return;
            }
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SplashScreen.Instance().Show();
                Application.DoEvents();
                //Thread.Sleep(200);
                Application.Run(new MainForm());
            }
            finally {
                mutex.ReleaseMutex();
            }
            GC.KeepAlive(mutex);
        }
    }
}
