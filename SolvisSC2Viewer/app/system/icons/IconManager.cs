using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace SolvisSC2Viewer {

    public class IconManager {
        private static Assembly exeAssembly;
        public Image FileOpen { get; private set; }
        public Image Print { get; private set; }
        public Image PrintPreview { get; private set; }
        public Icon PrintPreviewIcon { get; private set; }
        public Icon AppIcon { get; private set; }
        public Image Splash { get; private set; }
        public Image AboutDescription { get; private set; }
        public Image AboutLicense { get; private set; }
        public Image AboutAuthors { get; private set; }
        public Image FirstDay { get; private set; }
        public Image LastDay { get; private set; }
        public Image NextDay { get; private set; }
        public Image PreviousDay { get; private set; }
        public Image NextFile { get; private set; }
        public Image PreviousFile { get; private set; }
        public Image CrossHair { get; private set; }

        public IconManager() {
            exeAssembly = Assembly.GetExecutingAssembly();
        }

        public void LoadIcons() {
            FileOpen = LoadImage("openHS.png");
            Print = LoadImage("PrintHS.png");
            PrintPreview = LoadImage("PrintPreviewHS.png");
            if (PrintPreview != null) {
                PrintPreviewIcon = Icon.FromHandle(((Bitmap)PrintPreview).GetHicon());
            }
            AppIcon = LoadIcon("Lupe.ico");
            Splash = LoadImage("Solvis_splash1.jpg");
            //AppIcon = LoadIcon("favicon.ico");
            //Splash = LoadImage("Solvis_logo2.jpg");
            //AboutDescription = LoadImage("about_description.png");
            AboutLicense = LoadImage("about_license.png");
            AboutAuthors = LoadImage("about_authors.png");
            Icon sun = LoadIcon("TheSun.ico");
            if (sun != null) {
                AboutDescription = sun.ToBitmap();
            }
            FirstDay = LoadImage("DataContainer_MoveFirst.bmp");
            LastDay = LoadImage("DataContainer_MoveLast.bmp");
            NextDay = LoadImage("DataContainer_MoveNext.bmp");
            PreviousDay = LoadImage("DataContainer_MovePrevious.bmp");
            NextFile = LoadImage("GoToNext.bmp");
            PreviousFile = LoadImage("GoToPrevious.bmp");
            CrossHair = LoadImage("crosshair.bmp");
        }

        private static Icon LoadIcon(string name) {
            Icon icon = null;
            try {
                Stream stream = GetResourceStream(name);
                if (stream != null) {
                    icon = new Icon(stream);
                }
            }
            catch (ArgumentException ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return icon;
        }

        private static Image LoadImage(string name) {
            Image image = null;
            try {
                Stream stream = GetResourceStream(name);
                if (stream != null) {
                    image = new Bitmap(stream);
                }
            }
            catch (ArgumentException ex) {
                AppExtension.PrintStackTrace(ex);
            }
            return image;
        }

        private static Stream GetResourceStream(string resource) {
            return exeAssembly.GetManifestResourceStream(AppManager.ApplicationName + ".files." + resource);
        }
    }
}
