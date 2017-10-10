using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class FormulaEditor : Form {
        public FormulaEditor() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            this.hintLabel.Visible = false;
        }

        private void FormulaEditor_Shown(object sender, EventArgs e) {
            string key = this.Tag as string;
            ConfigManager manager = AppManager.ConfigManager;
            if (key != null) {
                switch (key) {
                    case "S17":
                        formulaTextBox.Text = manager.FormulaSolarVSG;
                        break;
                    case "P02":
                        formulaTextBox.Text = manager.FormulaSolarKW;
                        break;
                    case "P06":
                        formulaTextBox.Text = manager.Formula1;
                        break;
                    case "P07":
                        formulaTextBox.Text = manager.Formula2;
                        break;
                    case "P08":
                        formulaTextBox.Text = manager.Formula3;
                        break;
                    case "P09":
                        formulaTextBox.Text = manager.Formula4;
                        break;
                    case "P10":
                        formulaTextBox.Text = manager.Formula5;
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
                editor.Changed = true;
                AppManager.ConfigManager.AppConfigChanged = true;
            }
            StringBuilder formula = new StringBuilder();
            string[] lines = formulaTextBox.Lines;
            for (int i = 0; i < lines.Length; i++) {
                formula.Append(lines[i]); 
            }
            if (key != null) {
                switch (key) {
                    case "S17":
                        manager.FormulaSolarVSG = formula.ToString();
                        break;
                    case "P02":
                        manager.FormulaSolarKW = formula.ToString();
                        break;
                    case "P06":
                        manager.Formula1 = formula.ToString();
                        break;
                    case "P07":
                        manager.Formula2 = formula.ToString();
                        break;
                    case "P08":
                        manager.Formula3 = formula.ToString();
                        break;
                    case "P09":
                        manager.Formula4 = formula.ToString();
                        break;
                    case "P10":
                        manager.Formula5 = formula.ToString();
                        break;
                    default:
                        break;
                }
            }
            Close();
        }
    }
}
