using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace SolvisSC2Viewer {
    internal class ConfigManager {
        public static readonly string[] DefaultOptionsToolTip = 
        {   "Brenner kW",
            "Solar kW",
            "Sonnenstand",
            "Vorlauf HK1 (Ist - Soll), Ideale Formel",
            "Vorlauf HK1 (Ist - Soll), Solvis Formel",
            "Formel 1",
            "Formel 2",
            "Formel 3",
        };
        public static string ConfigDir { get; set; }
        private static string appConfigFile;
        private static string userConfigFile;
        public IDictionary<String, ConfigData> ActorConfigValues { get; private set; }
        public IDictionary<String, ConfigData> SensorConfigValues { get; private set; }
        public IDictionary<String, ConfigData> OptionConfigValues { get; private set; }
        public IDictionary<String, ConfigData> ActorConfigDefault { get; private set; }
        public IDictionary<String, ConfigData> SensorConfigDefault { get; private set; }
        public IDictionary<String, ConfigData> OptionConfigDefault { get; private set; }
        public IDictionary<String, Object> Parameters { get; private set; } //@Todo
        public IDictionary<String, Object> ParametersDefault { get; private set; }
        public string OpenDir { get; set; }
        public string SdCardDir { get; set; }
        public int TimePlanSuppressMask { get; set; }
        public bool TimePlanBitmap { get; set; }
        public bool SuperUser { get; set; }
        //HeatCurve parameter
        public static int Temperature { get; set; }
        public static int Niveau { get; set; }
        public static double Gradient { get; set; }

        private static Color[] _colorsBrightPastel = new Color[] { Color.FromArgb(0x41, 140, 240), Color.FromArgb(0xfc, 180, 0x41), Color.FromArgb(0xe0, 0x40, 10), Color.FromArgb(5, 100, 0x92), Color.FromArgb(0xbf, 0xbf, 0xbf), Color.FromArgb(0x1a, 0x3b, 0x69), Color.FromArgb(0xff, 0xe3, 130), Color.FromArgb(0x12, 0x9c, 0xdd), Color.FromArgb(0xca, 0x6b, 0x4b), Color.FromArgb(0, 0x5c, 0xdb), Color.FromArgb(0xf3, 210, 0x88), Color.FromArgb(80, 0x63, 0x81), Color.FromArgb(0xf1, 0xb9, 0xa8), Color.FromArgb(0xe0, 0x83, 10), Color.FromArgb(120, 0x93, 190) };
        private static Color[] _colorsFire = new Color[] { Color.Gold, Color.Red, Color.DeepPink, Color.Crimson, Color.DarkOrange, Color.Magenta, Color.Yellow, Color.OrangeRed, Color.MediumVioletRed, Color.FromArgb(0xdd, 0xe2, 0x21) };
        private static Color[] _colorsExcel = new Color[] { Color.FromArgb(0x99, 0x99, 0xff), Color.FromArgb(0x99, 0x33, 0x66), Color.FromArgb(0xff, 0xff, 0xcc), Color.FromArgb(0xcc, 0xff, 0xff), Color.FromArgb(0x66, 0, 0x66), Color.FromArgb(0xff, 0x80, 0x80), Color.FromArgb(0, 0x66, 0xcc), Color.FromArgb(0xcc, 0xcc, 0xff), Color.FromArgb(0, 0, 0x80), Color.FromArgb(0xff, 0, 0xff), Color.FromArgb(0xff, 0xff, 0), Color.FromArgb(0, 0xff, 0xff), Color.FromArgb(0x80, 0, 0x80), Color.FromArgb(0x80, 0, 0), Color.FromArgb(0, 0x80, 0x80), Color.FromArgb(0, 0, 0xff) };
        public string Version { get; set; }
        public string Formula1 { get; set; }
        public string Formula2 { get; set; }
        public string Formula3 { get; set; }
        public bool AppConfigChanged { get; set; }

        public ConfigManager() {
            AppConfigChanged = true; //@Todo: 
            Version = "1.0.0.0";
            ParametersDefault = new Dictionary<String, Object>();
            Parameters = new Dictionary<String, Object>();
            InitDefaultParameter();
            RowValues.Longitude = (double)ParametersDefault[ConfigXml.LongitudeTag];
            RowValues.Latitude = (double)ParametersDefault[ConfigXml.LatitudeTag];
            RowValues.BurnerMinPower = (double)ParametersDefault[ConfigXml.BurnerMinPowerTag];
            RowValues.BurnerMaxPower = (double)ParametersDefault[ConfigXml.BurnerMaxPowerTag];

            RowValues.Temperature = (int)ParametersDefault[ConfigXml.TemperatureVLTag];
            RowValues.Niveau = (int)ParametersDefault[ConfigXml.NiveauVLTag];
            RowValues.Gradient = (double)ParametersDefault[ConfigXml.GradientVLTag];
            TimePlanSuppressMask = (int)ParametersDefault[ConfigXml.TimePlanSuppressMaskTag];
            SuperUser = false;
            OpenDir = AppManager.BaseDir;
            Temperature = (int)ParametersDefault[ConfigXml.TemperatureTag];
            Niveau = (int)ParametersDefault[ConfigXml.NiveauTag];
            Gradient = (double)ParametersDefault[ConfigXml.GradientTag];
            ActorConfigValues = new Dictionary<String, ConfigData>();
            SensorConfigValues = new Dictionary<String, ConfigData>();
            OptionConfigValues = new Dictionary<String, ConfigData>();
            ActorConfigDefault = new Dictionary<String, ConfigData>();
            SensorConfigDefault = new Dictionary<String, ConfigData>();
            OptionConfigDefault = new Dictionary<String, ConfigData>();
            ConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar
                + MainForm.ConfigPath;
            if (!Directory.Exists(ConfigDir)) {
                Directory.CreateDirectory(ConfigDir);
            }
            userConfigFile = ConfigDir + Path.DirectorySeparatorChar + "User.config";
            appConfigFile = ConfigDir + Path.DirectorySeparatorChar + "App.config"; //@Todo
        }

        public void Init() {
            SetDefaults();
            ReadConfig();
            new CodeBuilder().Calculate(Formula1, Formula2, Formula3);
            bool newVersionDetected = Application.ProductVersion.CompareTo(Version) == 1;
            if (newVersionDetected) {
                ParameterUpdateForNewVersion();
            }
            ConfigureActors();
            ConfigureSensors();
            ConfigureOptions();
            AppManager.ItemManager.UpdateItems();
        }

        private void ParameterUpdateForNewVersion() {
            string lastVersion = Version;
            string destFileName = Path.GetDirectoryName(userConfigFile) + Path.DirectorySeparatorChar + "User" + lastVersion + ".Config";
            if (!File.Exists(destFileName)) {
                //File.Delete(destFileName);
                File.Move(userConfigFile, destFileName);
            }
            if (lastVersion == "1.0.0.0") {
                IDictionary<String, ConfigData> data = ActorConfigValues;
                ActorConfigValues = GetDefault(ActorConfigDefault);
                UpdateParameters(data, ActorConfigValues, false);
                data = SensorConfigValues;
                SensorConfigValues = GetDefault(SensorConfigDefault);
                UpdateParameters(data, SensorConfigValues, false);
                data = OptionConfigValues;
                OptionConfigValues = GetDefault(OptionConfigDefault);
                UpdateParameters(data, OptionConfigValues, true);
            }
            Version = Application.ProductVersion;
            AppConfigChanged = true;
        }

        private static void UpdateParameters(IDictionary<String, ConfigData> oldDict, IDictionary<String, ConfigData> newDict, bool options) {
            IEnumerator<KeyValuePair<String, ConfigData>> it = oldDict.GetEnumerator();
            while (it.MoveNext()) {
                KeyValuePair<String, ConfigData> pair = it.Current;
                ConfigData oldData = pair.Value;
                ConfigData newData = newDict[pair.Key];
                newData.Visible = oldData.Visible;
                newData.Checked = oldData.Checked;
                if (!options) {
                    newData.Text = oldData.Text;
                    newData.ToolTipText = oldData.Text;
                }
            }
        }

        private void InitDefaultParameter() {
            ParametersDefault[ConfigXml.LatitudeTag] = 52.3175;
            ParametersDefault[ConfigXml.LongitudeTag] = 10.4905; //Position Solvis Braunschweig
            ParametersDefault[ConfigXml.TemperatureTag] = 21;
            ParametersDefault[ConfigXml.NiveauTag] = 2;
            ParametersDefault[ConfigXml.GradientTag] = 1.2;
            ParametersDefault[ConfigXml.TemperatureVLTag] = 21;
            ParametersDefault[ConfigXml.NiveauVLTag] = 3;
            ParametersDefault[ConfigXml.GradientVLTag] = 1.15;
            ParametersDefault[ConfigXml.BurnerMinPowerTag] = 5.0;
            ParametersDefault[ConfigXml.BurnerMaxPowerTag] = 20.0;
            ParametersDefault[ConfigXml.TimePlanSuppressMaskTag] = 38;
            ParametersDefault[ConfigXml.TimePlanBitmapTag] = false;
        }

        public void UpdateMainForm() {
            ConfigureActors();
            ConfigureSensors();
            ConfigureOptions();
            AppManager.DataManager.UpdateSeries();
            AppManager.MainForm.UpdateToolTips();
        }

        private static Color GetColor(GroupIdent ident, int index) {
            int i;
            Color[] colorTab;
            if (ident == GroupIdent.Option) {
                colorTab = _colorsExcel;
                i = index;
            } else {
                if (index < _colorsBrightPastel.Length) {
                    colorTab = _colorsBrightPastel;
                    i = index;
                } else {
                    colorTab = _colorsFire;
                    i = index - _colorsBrightPastel.Length;
                }
            }
            return colorTab[i];
        }

        private void SetDefaults() {
            IList<CheckBox> list = AppManager.MainForm.SensorsCheckBoxes;
            for (int i = 0; i < list.Count; i++) {
                string key = "S" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = new ConfigData();
                data.Text = checkBox.Text;
                data.ToolTipText = checkBox.Text;
                data.Visible = checkBox.Visible;
                data.Checked = checkBox.Checked;
                data.Color = GetColor(GroupIdent.Sensor, i);
                //checkBox.ForeColor;
                SensorConfigDefault.Add(key, data);
            }
            list = AppManager.MainForm.ActorsCheckBoxes;
            for (int i = 0; i < list.Count; i++) {
                string key = "A" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = new ConfigData();
                data.Text = checkBox.Text;
                data.ToolTipText = checkBox.Text;
                data.Visible = checkBox.Visible;
                data.Checked = checkBox.Checked;
                data.Color = GetColor(GroupIdent.Actor, i);
                //checkBox.ForeColor;
                ActorConfigDefault.Add(key, data);
            }
            list = AppManager.MainForm.OptionsCheckBoxes;
            for (int i = 0; i < list.Count; i++) {
                string key = "P" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = new ConfigData();
                data.Text = checkBox.Text;
                data.ToolTipText = DefaultOptionsToolTip[i];
                data.Visible = checkBox.Visible;
                data.Checked = checkBox.Checked;
                data.Color = GetColor(GroupIdent.Option, i);
                //checkBox.ForeColor;
                OptionConfigDefault.Add(key, data);
            }
        }

        public void WriteConfig() {
            if (AppConfigChanged) {
                ConfigWriter writer = new ConfigWriter(this);
                writer.Write(userConfigFile);
            }
        }

        private void ReadConfig() {
            ConfigReader reader = new ConfigReader(this);
            reader.Parse(userConfigFile);
            if (ActorConfigValues.Count == 0) {
                ActorConfigValues = GetDefault(ActorConfigDefault);
            }
            if (SensorConfigValues.Count == 0) {
                SensorConfigValues = GetDefault(SensorConfigDefault);
            }
            if (OptionConfigValues.Count == 0) {
                OptionConfigValues = GetDefault(OptionConfigDefault);
            }
            if (OptionConfigValues.Count != OptionConfigDefault.Count) {
                foreach (KeyValuePair<String, ConfigData> pair in OptionConfigDefault) {
                    if (!OptionConfigValues.ContainsKey(pair.Key)) {
                        ConfigData value = pair.Value;
                        OptionConfigValues.Add(pair.Key, value.Clone());
                        AppConfigChanged = true;
                    }
                }
            }
        }

        private IDictionary<string, ConfigData> GetDefault(IDictionary<string, ConfigData> defaultDict) {
            IDictionary<String, ConfigData> configDatas = new Dictionary<String, ConfigData>();
            foreach (KeyValuePair<String, ConfigData> pair in defaultDict) {
                ConfigData value = pair.Value;
                configDatas.Add(pair.Key, value.Clone());
            }
            AppConfigChanged = true;
            return configDatas;
        }

        private void ConfigureActors() {
            IDictionary<String, ConfigData> config = ActorConfigValues;
            Control parent = null;
            IList<CheckBox> list = AppManager.MainForm.ActorsCheckBoxes;
            if (list.Count > 0) {
                parent = list[0].Parent;
                parent.SuspendLayout();
            }
            for (int i = 0; i < list.Count; i++) {
                string key = "A" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = null;
                if (config.ContainsKey(key)) {
                    data = config[key];
                }
                if (data != null) {
                    checkBox.Text = data.Text;
                    checkBox.Visible = data.Visible;
                    checkBox.Checked = data.Checked;
                    checkBox.ForeColor = data.Color;
                }
            }
            if (parent != null) {
                parent.ResumeLayout();
            }
        }

        private void ConfigureSensors() {
            IDictionary<String, ConfigData> config = SensorConfigValues;
            Control parent = null;
            IList<CheckBox> list = AppManager.MainForm.SensorsCheckBoxes;
            if (list.Count > 0) {
                parent = list[0].Parent;
                parent.SuspendLayout();
            }
            for (int i = 0; i < list.Count; i++) {
                string key = "S" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = null;
                if (config.ContainsKey(key)) {
                    data = config[key];
                }
                if (data != null) {
                    checkBox.Text = data.Text;
                    checkBox.Visible = data.Visible;
                    checkBox.Checked = data.Checked;
                    checkBox.ForeColor = data.Color;
                }
            }
            if (parent != null) {
                parent.ResumeLayout();
            }
        }

        private void ConfigureOptions() {
            IDictionary<String, ConfigData> config = OptionConfigValues;
            Control parent = null;
            IList<CheckBox> list = AppManager.MainForm.OptionsCheckBoxes;
            if (list.Count > 0) {
                parent = list[0].Parent;
                parent.SuspendLayout();
            }
            for (int i = 0; i < list.Count; i++) {
                string key = "P" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                ConfigData data = null;
                if (config.ContainsKey(key)) {
                    data = config[key];
                }
                if (data != null) {
                    checkBox.Text = data.Text;
                    checkBox.Visible = data.Visible;
                    checkBox.Checked = data.Checked;
                    checkBox.ForeColor = data.Color;
                }
            }
            if (parent != null) {
                parent.ResumeLayout();
            }
        }

        public void SetConfigData(CheckBoxTag tag) {
            if (SensorConfigValues.ContainsKey(tag.ConfigKey)) {
                ConfigData data = SensorConfigValues[tag.ConfigKey];
                data.Checked = tag.CheckBox.Checked;
            } else if (ActorConfigValues.ContainsKey(tag.ConfigKey)) {
                ConfigData data = ActorConfigValues[tag.ConfigKey];
                data.Checked = tag.CheckBox.Checked;
            } else if (OptionConfigValues.ContainsKey(tag.ConfigKey)) {
                ConfigData data = OptionConfigValues[tag.ConfigKey];
                data.Checked = tag.CheckBox.Checked;
            }
        }

        public static Color GetColor(string colorRGB) {
            string[] values = colorRGB.Trim().Split(',');
            if (values != null && values.Length == 3) {
                try {
                    int red = (byte)Int32.Parse(values[0].Trim());
                    int green = (byte)Int32.Parse(values[1].Trim());
                    int blue = (byte)Int32.Parse(values[2].Trim());
                    return Color.FromArgb(red, green, blue);
                }
                catch (FormatException e) {
                    AppExtension.PrintStackTrace(e);
                }
            }
            return Color.DeepPink;
        }

        public static string GetColorString(Color color) {
            return color.R + "," + color.G + "," + color.B;
        }
    }
}
