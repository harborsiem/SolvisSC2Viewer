using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace SolvisSC2Viewer {
    internal class AboutContentReader {

        private const String Prefix = "about_";
        private const String Extension = ".dist";

        public const String Description = "Description";
        public const String Authors = "Authors";
        public const String License = "License";
        private const String exeNamespace = "SolvisSC2Viewer";
        private static Assembly exeAssembly = Assembly.GetExecutingAssembly();

        private AboutContentReader() {
        }

        public static Stream GetResourceStream(String fileName) {
            Stream stream = null;
            String addon = "SolvisSC2Viewer.files.";
            String fullName = addon + fileName;
            ManifestResourceInfo mri = exeAssembly.GetManifestResourceInfo(fullName);
            if (mri != null) {
                stream = exeAssembly.GetManifestResourceStream(fullName);
            }
            return stream;
        }

        public static String[] Read(String doc, string language) {
            String ressourceFileName;
            Stream stream = null;
            if (string.IsNullOrEmpty(language)) {
                ressourceFileName = Prefix + doc + Extension;
            } else {
                ressourceFileName = Prefix + doc + language;
            }
            stream = GetResourceStream(ressourceFileName);
            if (stream == null) {
                return new String[] { };
            }
            return Read(stream);
        }

        public static String[] Read(Stream stream) {
            TextReader tr = new StreamReader(stream);
            List<String> sl = new List<String>();
            int i = 0;
            try {
                while (true) {
                    String s = tr.ReadLine();
                    if (s == null) {
                        break;
                    }
                    sl.Add(s);
                    i++;
                }
            }
            catch (IOException e) {
                AppExtension.PrintStackTrace(e);
            }
            finally {
                tr.Close();
            }
            return sl.ToArray();
        }
    }
}
