using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public partial class ConfigEditor : BaseForm {
        public static readonly string FolderDescription = Resources.ConfigEditorSearch; //@Language Resource
        private ColorDialog colorDialog = new ColorDialog();
        private IDictionary<String, ConfigData> sensorDatas;
        private IDictionary<String, ConfigData> actorDatas;
        private IDictionary<String, ConfigData> optionDatas;
        private int temperature;
        private int niveau;
        private double gradient;
        private int timePlanSuppressMask;
        private bool timePlanBitmap;

        public bool Changed { get; set; }

        public ConfigEditor() {
            InitializeComponent();
            sensorDatas = new Dictionary<String, ConfigData>();
            foreach (KeyValuePair<String, ConfigData> pair in AppManager.ConfigManager.SensorConfigValues) {
                ConfigData value = pair.Value;
                sensorDatas.Add(pair.Key, value.Clone());
            }
            actorDatas = new Dictionary<String, ConfigData>();
            foreach (KeyValuePair<String, ConfigData> pair in AppManager.ConfigManager.ActorConfigValues) {
                ConfigData value = pair.Value;
                actorDatas.Add(pair.Key, value.Clone());
            }
            optionDatas = new Dictionary<String, ConfigData>();
            foreach (KeyValuePair<String, ConfigData> pair in AppManager.ConfigManager.OptionConfigValues) {
                ConfigData value = pair.Value;
                optionDatas.Add(pair.Key, value.Clone());
            }
            temperature = ConfigManager.Temperature;
            temperatureUpDown.Maximum = HeatCurve.SetTemperatureMaximum;
            temperatureUpDown.Minimum = HeatCurve.SetTemperatureMinimum;
            temperatureUpDown.Value = ConfigManager.Temperature;
            niveau = ConfigManager.Niveau;
            niveauUpDown.Value = ConfigManager.Niveau;
            gradient = ConfigManager.Gradient;
            gradientUpDown.Increment = HeatCurve.GradientIncrement;
            gradientUpDown.Value = (decimal)ConfigManager.Gradient;
            gradientUpDown.Maximum = HeatCurve.GradientMaximum;
            gradientUpDown.Minimum = HeatCurve.GradientMinimum;
            timePlanSuppressMask = AppManager.ConfigManager.TimePlanSuppressMask;
            timePlanBitmap = AppManager.ConfigManager.TimePlanBitmap;
            savePictureCheckBox.Checked = timePlanBitmap;
            hk2CheckBox.Checked = (timePlanSuppressMask & (int)SuppressMask.HK2) == 0;
            hk3CheckBox.Checked = (timePlanSuppressMask & (int)SuppressMask.HK3) == 0;
            ecoCheckBox.Checked = (timePlanSuppressMask & (int)SuppressMask.Eco) == 0;
            prototype.Checked = AppManager.ConfigManager.Prototype;
            this.temperatureUpDown.ValueChanged += new System.EventHandler(this.temperatureUpDown_ValueChanged);
            this.niveauUpDown.ValueChanged += new System.EventHandler(this.niveauUpDown_ValueChanged);
            this.gradientUpDown.ValueChanged += new System.EventHandler(this.gradientUpDown_ValueChanged);
            this.hk2CheckBox.CheckedChanged += new System.EventHandler(this.hk2CheckBox_CheckedChanged);
            this.hk3CheckBox.CheckedChanged += new System.EventHandler(this.hk3CheckBox_CheckedChanged);
            this.ecoCheckBox.CheckedChanged += new System.EventHandler(this.ecoCheckBox_CheckedChanged);
            this.savePictureCheckBox.CheckedChanged += new System.EventHandler(this.savePictureCheckBox_CheckedChanged);

            sensorsListBox.SelectedIndex = 0;
            actorsListBox.SelectedIndex = 0;
            optionsListBox.SelectedIndex = 0;
        }

        private void buttonDefault_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            ConfigManager manager = AppManager.ConfigManager;
            foreach (KeyValuePair<String, ConfigData> pair in manager.SensorConfigValues) {
                ConfigData value = pair.Value;
                manager.SensorConfigDefault[pair.Key].Copy(value);
            }
            foreach (KeyValuePair<String, ConfigData> pair in manager.ActorConfigValues) {
                ConfigData value = pair.Value;
                manager.ActorConfigDefault[pair.Key].Copy(value);
            }
            foreach (KeyValuePair<String, ConfigData> pair in manager.OptionConfigValues) {
                ConfigData value = pair.Value;
                manager.OptionConfigDefault[pair.Key].Copy(value);
            }

            manager.SetParametersDefault();

            manager.UpdateMainForm();
            this.Cursor = Cursors.Default;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (Changed) {
                this.Cursor = Cursors.WaitCursor;
                ConfigManager manager = AppManager.ConfigManager;
                manager.AppConfigChanged = true;
                foreach (KeyValuePair<String, ConfigData> pair in manager.SensorConfigValues) {
                    ConfigData value = pair.Value;
                    sensorDatas[pair.Key].Copy(value);
                }
                foreach (KeyValuePair<String, ConfigData> pair in manager.ActorConfigValues) {
                    ConfigData value = pair.Value;
                    actorDatas[pair.Key].Copy(value);
                }
                foreach (KeyValuePair<String, ConfigData> pair in manager.OptionConfigValues) {
                    ConfigData value = pair.Value;
                    optionDatas[pair.Key].Copy(value);
                }

                ConfigManager.Temperature = temperature;
                ConfigManager.Niveau = niveau;
                ConfigManager.Gradient = gradient;
                manager.TimePlanSuppressMask = timePlanSuppressMask;
                manager.TimePlanBitmap = timePlanBitmap;
                manager.Prototype = prototype.Checked;

                manager.UpdateMainForm();
                this.Cursor = Cursors.Default;
            }
            Close();
        }

        private void sensorsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string key = (string)sensorsListBox.SelectedItem;
            if (sensorDatas.ContainsKey(key)) {
                ConfigData data = sensorDatas[key];
                sensorsTextBox.Tag = data;
                sensorsTextBox.Text = data.Text;
                sensorsToolTipTextBox.Tag = data;
                sensorsToolTipTextBox.Text = data.ToolTipText;
                sensorsColorButton.Tag = data;
                sensorsColorButton.ForeColor = data.Color;
                sensorsVisibleCheckBox.Tag = data;
                sensorsVisibleCheckBox.Checked = data.Visible;
                sensorsParameterButton.Tag = key;
                switch (key) {
                    case "S17":
                        sensorsParameterLabel.Visible = true;
                        sensorsParameterButton.Visible = true;
                        sensorsParameterButton.Enabled = true;
                        break;
                    default:
                        sensorsParameterLabel.Visible = false;
                        sensorsParameterButton.Visible = false;
                        sensorsParameterButton.Enabled = false;
                        break;
                }
            }
        }

        private void actorsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string key = (string)actorsListBox.SelectedItem;
            if (actorDatas.ContainsKey(key)) {
                ConfigData data = actorDatas[key];
                actorsTextBox.Tag = data;
                actorsTextBox.Text = data.Text;
                actorsToolTipTextBox.Tag = data;
                actorsToolTipTextBox.Text = data.ToolTipText;
                actorsColorButton.Tag = data;
                actorsColorButton.ForeColor = data.Color;
                actorsVisibleCheckBox.Tag = data;
                actorsVisibleCheckBox.Checked = data.Visible;
            }
        }

        private void optionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string key = (string)optionsListBox.SelectedItem;
            if (optionDatas.ContainsKey(key)) {
                ConfigData data = optionDatas[key];
                optionsTextBox.Tag = data;
                optionsTextBox.Text = data.Text;
                optionsToolTipTextBox.Tag = data;
                optionsToolTipTextBox.Text = data.ToolTipText;
                optionsColorButton.Tag = data;
                optionsColorButton.ForeColor = data.Color;
                optionsVisibleCheckBox.Tag = data;
                optionsVisibleCheckBox.Checked = data.Visible;
                parameterButton.Tag = key;
                switch (key) {
                    case "P01":
                    case "P02":
                    case "P03":
                    case "P04":
                    case "P06":
                    case "P07":
                    case "P08":
                    case "P09":
                    case "P10":
                        parameterButton.Enabled = true;
                        break;
                    default:
                        parameterButton.Enabled = false;
                        break;
                }
            }
        }

        private void ColorButton_Click(object sender, EventArgs e) {
            Button colorButton = sender as Button;
            if (colorButton != null) {
                colorDialog.Color = colorButton.ForeColor;
                colorDialog.FullOpen = true;
                if (colorDialog.ShowDialog(this) == DialogResult.OK) {
                    colorButton.ForeColor = colorDialog.Color;
                    ConfigData data = colorButton.Tag as ConfigData;
                    if (data != null) {
                        data.Color = colorDialog.Color;
                        Changed = true;
                    }
                }
            }
        }

        private void VisibleCheckBox_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null) {
                ConfigData data = checkBox.Tag as ConfigData;
                if (data != null) {
                    if (data.Visible != checkBox.Checked) {
                        data.Visible = checkBox.Checked;
                        if (!data.Visible) {
                            data.Checked = false;
                        }
                        Changed = true;
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox != null) {
                ConfigData data = textBox.Tag as ConfigData;
                if (data != null) {
                    if (data.Text != textBox.Text) {
                        data.Text = textBox.Text;
                        Changed = true;
                    }
                }
            }
        }

        private void ToolTipTextBox_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox != null) {
                ConfigData data = textBox.Tag as ConfigData;
                if (data != null) {
                    if (data.ToolTipText != textBox.Text) {
                        data.ToolTipText = textBox.Text;
                        Changed = true;
                    }
                }
            }
        }

        private void temperatureUpDown_ValueChanged(object sender, EventArgs e) {
            temperature = (int)temperatureUpDown.Value;
            Changed = true;
        }

        private void niveauUpDown_ValueChanged(object sender, EventArgs e) {
            niveau = (int)niveauUpDown.Value;
            Changed = true;
        }

        private void gradientUpDown_ValueChanged(object sender, EventArgs e) {
            gradient = (double)gradientUpDown.Value;
            Changed = true;
        }

        private void parameterButton_Click(object sender, EventArgs e) {
            Form dialog;
            Button parameter = sender as Button;
            if (parameter == null) {
                return;
            }
            string key = parameter.Tag as string;
            if (key != null) {
                switch (key) {
                    case "P01":
                        dialog = new BurnerPower();
                        dialog.ShowDialog(this);
                        break;
                    case "P03":
                        dialog = new EarthPosition();
                        dialog.ShowDialog(this);
                        break;
                    case "P04":
                        dialog = new VLParameters();
                        dialog.ShowDialog(this);
                        break;
                    case "S17":
                    case "P02":
                    case "P06":
                    case "P07":
                    case "P08":
                    case "P09":
                    case "P10":
                        dialog = new FormulaEditor();
                        dialog.Tag = key;
                        dialog.ShowDialog(this);
                        break;
                    default:
                        break;
                }
            }
        }

        private void directoryButton_Click(object sender, EventArgs e) {
            ConfigManager manager = AppManager.ConfigManager;
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(manager.SdCardDir)) {
                folder.SelectedPath = manager.SdCardDir;
            }
            folder.Description = FolderDescription;
            folder.ShowNewFolderButton = false;
            if (folder.ShowDialog() == DialogResult.OK) {
                manager.SdCardDir = folder.SelectedPath;
            }
        }

        private void hk2CheckBox_CheckedChanged(object sender, EventArgs e) {
            if (hk2CheckBox.Checked) {
                timePlanSuppressMask &= ~(int)SuppressMask.HK2;
            } else {
                timePlanSuppressMask |= (int)SuppressMask.HK2;
            }
            Changed = true;
        }

        private void hk3CheckBox_CheckedChanged(object sender, EventArgs e) {
            if (hk3CheckBox.Checked) {
                timePlanSuppressMask &= ~(int)SuppressMask.HK3;
            } else {
                timePlanSuppressMask |= (int)SuppressMask.HK3;
            }
            Changed = true;
        }

        private void ecoCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (ecoCheckBox.Checked) {
                timePlanSuppressMask &= ~(int)SuppressMask.Eco;
            } else {
                timePlanSuppressMask |= (int)SuppressMask.Eco;
            }
            Changed = true;
        }

        private void savePictureCheckBox_CheckedChanged(object sender, EventArgs e) {
            timePlanBitmap = savePictureCheckBox.Checked;
            Changed = true;
        }

        private void prototype_CheckedChanged(object sender, EventArgs e) {
            Changed = true;
        }
    }
}
