using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SolvisSC2Viewer {
    public class FileToInt32List {
        public List<int> ParamList { get; private set; }
        public bool Empty { get; private set; }

        public FileToInt32List(string path, string fileName) {
            ParamList = new List<int>();
            Empty = true;
            if (Directory.Exists(path)) {
                string filePath = Path.Combine(path, fileName);
                if (File.Exists(filePath)) {
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
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
                    }
                    finally {
                        reader.Close();
                    }
                }
            }
        }
    }
}
