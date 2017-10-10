using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class BurnerPower : Form {
        public BurnerPower() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            minUpDown.Value = (decimal)RowValues.BurnerMinPower;
            maxUpDown.Value = (decimal)RowValues.BurnerMaxPower;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            ConfigEditor editor = this.Owner as ConfigEditor;
            if (editor != null) {
                editor.Changed = true;
                AppManager.ConfigManager.AppConfigChanged = true;
            }
            RowValues.BurnerMinPower = (double)minUpDown.Value;
            RowValues.BurnerMaxPower = (double)maxUpDown.Value;
            Close();
        }
    }
}
