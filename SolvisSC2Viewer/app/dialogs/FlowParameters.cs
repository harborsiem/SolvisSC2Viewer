using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class FlowParameters : Form {
        public FlowParameters() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            temperatureUpDown.Maximum = HeatCurve.SetTemperatureMaximum;
            temperatureUpDown.Minimum = HeatCurve.SetTemperatureMinimum;
            temperatureUpDown.Value = (decimal)RowValues.Temperature;
            levelUpDown.Value = (decimal)RowValues.Level;
            gradientUpDown.Increment = HeatCurve.GradientIncrement;
            gradientUpDown.Maximum = HeatCurve.GradientMaximum;
            gradientUpDown.Value = (decimal)RowValues.Gradient;
            gradientUpDown.Minimum = HeatCurve.GradientMinimum;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            ConfigEditor editor = this.Owner as ConfigEditor;
            if (editor != null) {
                editor.Changed = true;
                AppManager.ConfigManager.AppConfigChanged = true;
            }
            RowValues.Temperature = (double)temperatureUpDown.Value;
            RowValues.Level = (double)levelUpDown.Value;
            RowValues.Gradient = (double)gradientUpDown.Value;
            Close();
        }
    }
}
