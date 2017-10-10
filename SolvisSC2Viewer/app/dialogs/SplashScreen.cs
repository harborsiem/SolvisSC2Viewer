using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SolvisSC2Viewer {
    public partial class SplashScreen : Form {
        private String fullName = "SolvisSC2Viewer.files.Solvis_splash1.jpg";
        private static SplashScreen _instance;

        private Bitmap image;

        private SplashScreen() {
            InitializeComponent();
            Assembly ourAssembly = Assembly.GetExecutingAssembly();
            image = new Bitmap(ourAssembly.GetManifestResourceStream(fullName));
            this.Size = image.Size;
        }

        public static SplashScreen Instance() {
            if (_instance == null) {
                _instance = new SplashScreen();
            }
            return _instance;
        }

        public void Finish() {
            if (this != null && !this.IsDisposed) {
                this.Close();
                //this.Dispose();
            }
            _instance = null;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImageUnscaledAndClipped(image, e.ClipRectangle);
        }
    }
}
