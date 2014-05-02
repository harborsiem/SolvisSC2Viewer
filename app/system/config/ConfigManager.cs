using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class ConfigManager {
        public static readonly string[] DefaultOptionsToolTip = 
        {   Resources.ConfigManagerBurnerKW,
            Resources.ConfigManagerSolarKW,
            Resources.ConfigManagerSunPosition,
            Resources.ConfigManagerFlowHC1 + ", " + Resources.ConfigManagerIdealFormula,
            Resources.ConfigManagerFlowHC1 + ", " + Resources.ConfigManagerSolvisFormula,
            Resources.ConfigManagerFormula + " 1",
            Resources.ConfigManagerFormula + " 2",
            Resources.ConfigManagerFormula + " 3",
            Resources.ConfigManagerFormula + " 4",
            Resources.ConfigManagerFormula + " 5",
        }; //@Language Resource
        public static string ConfigDir { get; private set; }
        public static string DocumentsDir { get; private set; }
        private static string appConfigFile;
        private static string userConfigFile;
        private static bool userConfigExists;
        public IDictionary<String, ConfigData> ActorConfigValues { get; private set; }
        public IDictionary<String, ConfigData> SensorConfigValues { get; private set; }
        public IDictionary<String, ConfigData> OptionConfigValues { get; private set; }
        public IDictionary<String, ConfigData> ActorConfigDefault { get; private set; }
        public IDictionary<String, ConfigData> SensorConfigDefault { get; private set; }
        public IDictionary<String, ConfigData> OptionConfigDefault { get; private set; }
        public IDictionary<String, Object> Parameters { get; private set; } //@Todo
        private IDictionary<String, Object> DefaultParameters { get; set; }
        public string OpenDir { get; set; }
        public string SdCardDir { get; set; }
        public int SDCardSuppressMask { get; set; }
        public bool TimePlanBitmap { get; set; }
        public bool SuperUser { get; set; }
        public bool Prototype { get; set; }
        public bool OneDayMode { get; set; }
        //HeatCurve parameter
        public static int Temperature { get; set; }
        public static int Niveau { get; set; }
        public static double Gradient { get; set; }

        private static Color[] _colorsBrightPastel = new Color[] { Color.FromArgb(0x41, 140, 240), Color.FromArgb(0xfc, 180, 0x41), Color.FromArgb(0xe0, 0x40, 10), Color.FromArgb(5, 100, 0x92), Color.FromArgb(0xbf, 0xbf, 0xbf), Color.FromArgb(0x1a, 0x3b, 0x69), Color.FromArgb(0xff, 0xe3, 130), Color.FromArgb(0x12, 0x9c, 0xdd), Color.FromArgb(0xca, 0x6b, 0x4b), Color.FromArgb(0, 0x5c, 0xdb), Color.FromArgb(0xf3, 210, 0x88), Color.FromArgb(80, 0x63, 0x81), Color.FromArgb(0xf1, 0xb9, 0xa8), Color.FromArgb(0xe0, 0x83, 10), Color.FromArgb(120, 0x93, 190) };
        private static Color[] _colorsFire = new Color[] { Color.Gold, Color.Red, Color.DeepPink, Color.Crimson, Color.DarkOrange, Color.Magenta, Color.Yellow, Color.OrangeRed, Color.MediumVioletRed, Color.FromArgb(0xdd, 0xe2, 0x21) };
        private static Color[] _colorsSeaGreen = new Color[] { Color.SeaGreen, Color.MediumAquamarine, Color.SteelBlue, Color.DarkCyan, Color.CadetBlue, Color.MediumSeaGreen, Color.MediumTurquoise, Color.LightSteelBlue, Color.DarkSeaGreen, Color.SkyBlue };
        private static Color[] _colorsExcel = new Color[] { Color.FromArgb(0x99, 0x99, 0xff), Color.FromArgb(0x99, 0x33, 0x66), Color.FromArgb(0xff, 0xff, 0xcc), Color.FromArgb(0xcc, 0xff, 0xff), Color.FromArgb(0x66, 0, 0x66), Color.FromArgb(0xff, 0x80, 0x80), Color.FromArgb(0, 0x66, 0xcc), Color.FromArgb(0xcc, 0xcc, 0xff), Color.FromArgb(0, 0, 0x80), Color.FromArgb(0xff, 0, 0xff), Color.FromArgb(0xff, 0xff, 0), Color.FromArgb(0, 0xff, 0xff), Color.FromArgb(0x80, 0, 0x80), Color.FromArgb(0x80, 0, 0), Color.FromArgb(0, 0x80, 0x80), Color.FromArgb(0, 0, 0xff) };
        public string Version { get; set; }
        public string Formula1 { get; set; }
        public string Formula2 { get; set; }
        public string Formula3 { get; set; }
        public string Formula4 { get; set; }
        public string Formula5 { get; set; }
        public string FormulaSolarVSG { get; set; }
        public string FormulaSolarKW { get; set; }
        public bool HasFormulaDll { get; set; }
        public bool AppConfigChanged { get; set; }

        public ConfigManager() {
            AppConfigChanged = true; //@Todo: 
            Version = "1.0.0.0";
            DefaultParameters = new Dictionary<String, Object>();
            Parameters = new Dictionary<String, Object>();
            InitDefaultParameter();
            SuperUser = false;
            OpenDir = AppManager.BaseDir;
            SetParametersDefault();
            ActorConfigValues = new Dictionary<String, ConfigData>();
            SensorConfigValues = new Dictionary<String, ConfigData>();
            OptionConfigValues = new Dictionary<String, ConfigData>();
            ActorConfigDefault = new Dictionary<String, ConfigData>();
            SensorConfigDefault = new Dictionary<String, ConfigData>();
            OptionConfigDefault = new Dictionary<String, ConfigData>();
            ConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar
                + AppManager.ConfigPath;
            if (!Directory.Exists(ConfigDir)) {
                Directory.CreateDirectory(ConfigDir);
            }
            DocumentsDir = GetDocumentsDirectory();
            userConfigFile = ConfigDir + Path.DirectorySeparatorChar + "User.config";
            userConfigExists = File.Exists(userConfigFile);
            appConfigFile = ConfigDir + Path.DirectorySeparatorChar + "App.config"; //@Todo
        }

        public void Init() {
            SetDefaults();
            ReadConfig();
#if DEBUG
            SuperUser = true;
#endif
            CreateFormulas();
            bool newVersionDetected = Application.ProductVersion.CompareTo(Version) == 1;
            //bool newVersionDetected = string.Compare(Application.ProductVersion, Version, StringComparison.OrdinalIgnoreCase) == 1;
            if (newVersionDetected) {
                ParameterUpdateForNewVersion();
            }
            ConfigureActors();
            ConfigureSensors();
            ConfigureOptions();
            AppManager.ItemManager.UpdateItems();
        }

        private void ParameterUpdateForNewVersion() {
            if (userConfigExists) {
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
            DefaultParameters[ConfigXml.LatitudeTag] = 52.3175;
            DefaultParameters[ConfigXml.LongitudeTag] = 10.4905; //Position Solvis Braunschweig
            DefaultParameters[ConfigXml.TemperatureTag] = 21;
            DefaultParameters[ConfigXml.NiveauTag] = 2;
            DefaultParameters[ConfigXml.GradientTag] = 1.2;
            DefaultParameters[ConfigXml.TemperatureVLTag] = 21;
            DefaultParameters[ConfigXml.NiveauVLTag] = 3;
            DefaultParameters[ConfigXml.GradientVLTag] = 1.15;
            DefaultParameters[ConfigXml.BurnerMinPowerTag] = 5.0;
            DefaultParameters[ConfigXml.BurnerMaxPowerTag] = 20.0;
            DefaultParameters[ConfigXml.SDCardSuppressMaskTag] = 38;
            DefaultParameters[ConfigXml.TimePlanBitmapTag] = false;
            DefaultParameters[ConfigXml.PrototypeTag] = false;
            DefaultParameters[ConfigXml.OneDayModeTag] = false;
            DefaultParameters[ConfigXml.HasFormulaDllTag] = false;
            DefaultParameters[ConfigXml.SolvisControlVersionTag] = 131;
            DefaultParameters[ConfigXml.SolarPulseTag] = 42;
            DefaultParameters[ConfigXml.HeatCapacityTag] = 3.65; //bei 20°C, alle +10K + 0.04 mehr
        }

        public void UpdateMainForm() {
            CreateFormulas();
            ConfigureActors();
            ConfigureSensors();
            ConfigureOptions();
            AppManager.MainForm.UpdateSeriesColors();
            AppManager.DataManager.UpdateSeries();
            AppManager.MainForm.UpdateToolTips();
            AppManager.ItemManager.UpdateItems();
        }

        private void CreateFormulas() {
            if (HasFormulaDll) {
                if (ExternCode.MakeProxy()) {
                    return;
                }
            }
            Dictionary<FreeFormulas, string> formulas = new Dictionary<FreeFormulas, string>();
            formulas.Add(FreeFormulas.Formula1, Formula1);
            formulas.Add(FreeFormulas.Formula2, Formula2);
            formulas.Add(FreeFormulas.Formula3, Formula3);
            formulas.Add(FreeFormulas.Formula4, Formula4);
            formulas.Add(FreeFormulas.Formula5, Formula5);
            formulas.Add(FreeFormulas.SolarVSG, FormulaSolarVSG);
            formulas.Add(FreeFormulas.SolarKW, FormulaSolarKW);
            new CodeBuilder().Calculate(formulas);
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
                } else if (index < _colorsBrightPastel.Length + _colorsFire.Length) {
                    colorTab = _colorsFire;
                    i = index - _colorsBrightPastel.Length;
                } else {
                    colorTab = _colorsSeaGreen;
                    i = index - _colorsBrightPastel.Length - _colorsFire.Length;
                }
            }
            return colorTab[i];
        }

        public void SetParametersDefault() {
            RowValues.Longitude = (double)DefaultParameters[ConfigXml.LongitudeTag];
            RowValues.Latitude = (double)DefaultParameters[ConfigXml.LatitudeTag];
            RowValues.BurnerMinPower = (double)DefaultParameters[ConfigXml.BurnerMinPowerTag];
            RowValues.BurnerMaxPower = (double)DefaultParameters[ConfigXml.BurnerMaxPowerTag];

            RowValues.Temperature = (int)DefaultParameters[ConfigXml.TemperatureVLTag];
            RowValues.Niveau = (int)DefaultParameters[ConfigXml.NiveauVLTag];
            RowValues.Gradient = (double)DefaultParameters[ConfigXml.GradientVLTag];
            SDCardSuppressMask = (int)DefaultParameters[ConfigXml.SDCardSuppressMaskTag];
            TimePlanBitmap = (bool)DefaultParameters[ConfigXml.TimePlanBitmapTag];
            Temperature = (int)DefaultParameters[ConfigXml.TemperatureTag];
            Niveau = (int)DefaultParameters[ConfigXml.NiveauTag];
            Gradient = (double)DefaultParameters[ConfigXml.GradientTag];
            Prototype = (bool)DefaultParameters[ConfigXml.PrototypeTag];
            HasFormulaDll = (bool)DefaultParameters[ConfigXml.HasFormulaDllTag];
            RowValues.SolvisControlVersion = (int)DefaultParameters[ConfigXml.SolvisControlVersionTag];
            RowValues.SolarPulse = (int)DefaultParameters[ConfigXml.SolarPulseTag];
            RowValues.HeatCapacity20 = (double)DefaultParameters[ConfigXml.HeatCapacityTag];
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
            if (AppConfigChanged || userConfigExists == false) {
                ConfigWriter writer = new ConfigWriter(this);
                writer.Write(userConfigFile);
            }
        }

        private void ReadConfig() {
            if (userConfigExists) {
                ConfigReader reader = new ConfigReader(this);
                reader.Parse(userConfigFile);
            }
            if (ActorConfigValues.Count == 0) {
                ActorConfigValues = GetDefault(ActorConfigDefault);
            }
            if (ActorConfigValues.Count != ActorConfigDefault.Count) {
                foreach (KeyValuePair<String, ConfigData> pair in ActorConfigDefault) {
                    if (!ActorConfigValues.ContainsKey(pair.Key)) {
                        ConfigData value = pair.Value;
                        ActorConfigValues.Add(pair.Key, value.Clone());
                        AppConfigChanged = true;
                    }
                }
            }
            if (SensorConfigValues.Count == 0) {
                SensorConfigValues = GetDefault(SensorConfigDefault);
            }
            if (SensorConfigValues.Count != SensorConfigDefault.Count) {
                foreach (KeyValuePair<String, ConfigData> pair in SensorConfigDefault) {
                    if (!SensorConfigValues.ContainsKey(pair.Key)) {
                        ConfigData value = pair.Value;
                        SensorConfigValues.Add(pair.Key, value.Clone());
                        AppConfigChanged = true;
                    }
                }
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

        private static string GetDocumentsDirectory() {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppManager.ConfigPath);
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

    }
}
