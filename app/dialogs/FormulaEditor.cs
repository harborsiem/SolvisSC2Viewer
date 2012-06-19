using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class FormulaEditor : BaseForm {
        public FormulaEditor() {
            InitializeComponent();
        }

        private void FormulaEditor_Shown(object sender, EventArgs e) {
            string key = this.Tag as string;
            ConfigManager manager = AppManager.ConfigManager;
            if (key != null) {
                switch (key) {
                    case "P06":
                        formulaTextBox.Text = manager.Formula1;
                        break;
                    case "P07":
                        formulaTextBox.Text = manager.Formula2;
                        break;
                    case "P08":
                        formulaTextBox.Text = manager.Formula3;
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            string key = this.Tag as string;
            ConfigManager manager = AppManager.ConfigManager;
            ConfigEditor editor = this.Owner as ConfigEditor;
            if (editor != null) {
                //editor.Changed = true;
                AppManager.ConfigManager.AppConfigChanged = true;
            }
            StringBuilder formula = new StringBuilder();
            string[] lines = formulaTextBox.Lines;
            for (int i = 0; i < lines.Length; i++) {
                formula.Append(lines[i]); 
            }
            if (key != null) {
                switch (key) {
                    case "P06":
                        manager.Formula1 = formula.ToString();
                        break;
                    case "P07":
                        manager.Formula2 = formula.ToString();
                        break;
                    case "P08":
                        manager.Formula3 = formula.ToString();
                        break;
                    default:
                        break;
                }
            }
            Close();
        }
    }
}
