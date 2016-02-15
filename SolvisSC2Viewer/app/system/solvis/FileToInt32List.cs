using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public class FileToInt32List {
        public IList<int> ParamList { get; private set; }
        public bool Empty { get; private set; }
        public FileInfo FileInfo { get; private set; }

        public FileToInt32List(string path, string fileName) {
            bool error = false;
            ParamList = new List<int>();
            Empty = true;
            if (Directory.Exists(path)) {
                string filePath = Path.Combine(path, fileName);
                if (File.Exists(filePath)) {
                    FileInfo = new FileInfo(filePath);
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    //DateTime = File.GetLastWriteTime(filePath);
                    StreamReader reader = new StreamReader(stream);
                    try {
                        while (!reader.EndOfStream) {
                            string line = reader.ReadLine().Trim();
                            int value = int.Parse(line);
                            ParamList.Add(value);
                        }
                        Empty = false;
                    }
                    catch (FormatException) {
                        ParamList.Clear();
                        error = true;
                    }
                    finally {
                        reader.Close();
                    }
                } else {
                    error = true;
                }
            } else {
                error = true;
            }
            if (error) {
                Error(fileName);
            }
        }

        private static void Error(string fileName) {
            MessageBox.Show(Resources.AllClassesFile + ": " + fileName, Resources.FileToInt32ListError, MessageBoxButtons.OK, MessageBoxIcon.Error); //@Language Resource
        }
    }
}
