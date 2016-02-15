using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SolvisSC2Viewer {

    public static class AppExtension {

        private static StreamWriter swTrace;
        private static StreamWriter swPrint;
        private static String traceFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                                                  AppManager.ConfigPath + Path.DirectorySeparatorChar + "StackTrace.txt";
        private static String printFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                                                  AppManager.ConfigPath + Path.DirectorySeparatorChar + "PrintTrace.txt";

        private static void InitStackTrace() {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar
                + AppManager.ConfigPath;
            if (!Directory.Exists(configDir)) {
                Directory.CreateDirectory(configDir);
            }
            FileStream fs = new FileStream(traceFileName, FileMode.Create, FileAccess.ReadWrite);
            try {
                swTrace = new StreamWriter(fs);
                swTrace.AutoFlush = true;
                swTrace.WriteLine("#Stacktrace " + DateTime.Now.ToString());
                swTrace.WriteLine(String.Empty);
            }
            finally {
            }
        }

        private static void InitPrintTrace() {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar
                + AppManager.ConfigPath;
            if (!Directory.Exists(configDir)) {
                Directory.CreateDirectory(configDir);
            }
            FileStream fs = new FileStream(printFileName, FileMode.Create, FileAccess.ReadWrite);
            try {
                swPrint = new StreamWriter(fs);
                swPrint.AutoFlush = true;
                swPrint.WriteLine("#Printtrace " + DateTime.Now.ToString());
                swPrint.WriteLine(String.Empty);
            }
            finally {
            }
        }

        public static void DeleteTraceFile() {
            File.Delete(traceFileName);
        }

        public static void DeletePrintFile() {
            File.Delete(printFileName);
        }

        public static void CloseStackTrace() {
            if (swTrace != null) {
                swTrace.Close();
            }
        }

        public static void ClosePrintTrace() {
            if (swPrint != null) {
                swPrint.Close();
            }
        }

        public static void Print(String data) {
            if (swPrint == null) {
                InitPrintTrace();
            }
            swPrint.Write(data);
        }

        public static void Println() {
            if (swPrint == null) {
                InitPrintTrace();
            }
            swPrint.WriteLine();
        }

        public static void Println(String data) {
            if (swPrint == null) {
                InitPrintTrace();
            }
            swPrint.WriteLine(data);
        }

        public static void PrintStackTrace(Exception ex) {
            if (swTrace == null) {
                InitStackTrace();
            }
            swTrace.Write("Message: ");
            swTrace.WriteLine(ex.Message);
            swTrace.WriteLine("Stack: ");
            swTrace.WriteLine(ex.StackTrace);
            swTrace.WriteLine();
        }

        public static void PrintExceptionMessage(string message, Exception ex) {
            if (swTrace == null) {
                InitStackTrace();
            }
            swTrace.Write("Message: ");
            swTrace.WriteLine(message);
            swTrace.WriteLine("Stack: ");
            swTrace.WriteLine(ex.StackTrace);
            swTrace.WriteLine();
        }
    }
}
