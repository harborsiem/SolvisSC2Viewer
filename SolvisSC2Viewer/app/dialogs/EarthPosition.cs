﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SolvisSC2Viewer {
    public partial class EarthPosition : Form {
        public EarthPosition() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            longitudeTextBox.Text = RowValues.Longitude.ToString(CultureInfo.CurrentCulture);
            latitudeTextBox.Text = RowValues.Latitude.ToString(CultureInfo.CurrentCulture);
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            double longitude;
            double latitude;
            if ((double.TryParse(longitudeTextBox.Text, out longitude) && (double.TryParse(longitudeTextBox.Text, out latitude)))) {
                ConfigEditor editor = this.Owner as ConfigEditor;
                if (editor != null) {
                    editor.Changed = true;
                    AppManager.ConfigManager.AppConfigChanged = true;
                }
                RowValues.Longitude = longitude;
                RowValues.Latitude = latitude;
                Close();
            } else {
                longitudeTextBox.Text = RowValues.Longitude.ToString(CultureInfo.CurrentCulture);
                latitudeTextBox.Text = RowValues.Latitude.ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}
