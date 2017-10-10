using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SolvisSC2Viewer {
    public partial class S17Dialog : Form {
        public S17Dialog() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            pulseUpDown.Value = (decimal)RowValues.SolarPulse;
            heatCapacityText.Text = RowValues.HeatCapacity20.ToString(CultureInfo.CurrentCulture);
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            ConfigEditor editor = this.Owner as ConfigEditor;
            if (editor != null) {
                editor.Changed = true;
                AppManager.ConfigManager.AppConfigChanged = true;
            }
            RowValues.SolarPulse = (int)pulseUpDown.Value;
            RowValues.HeatCapacity20 = double.Parse(heatCapacityText.Text, CultureInfo.CurrentCulture);
            Close();
        }

        private void editButton_Click(object sender, EventArgs e) {
            FormulaEditor dialog = new FormulaEditor();
            dialog.Tag = this.Tag;
            dialog.ShowDialog(this.Owner);
        }

        private void heatCapacityText_TextChanged(object sender, EventArgs e) {
            double result;
            if (!double.TryParse(heatCapacityText.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out result)) {
                heatCapacityText.Text = RowValues.HeatCapacity20.ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}
