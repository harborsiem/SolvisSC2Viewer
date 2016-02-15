using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class MainMenu : MenuStrip {

        public MainMenu() {
            InitializeComponent();
        }

        private void Initialize() {
            this.Location = new System.Drawing.Point(0, 0);
        }
    }
}