using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class DataManager {

        private static DataManager s_instance = new DataManager();
        private static readonly string rFile = " --- " + Resources.AllClassesFile + ": "; //@Language Resource
        private List<RowValues> SolvisList { get; set; }
        private List<Series> SensorsSeriesList { get; set; }
        private List<Series> ActorsSeriesList { get; set; }
        private List<Series> OptionsSeriesList { get; set; }
        private DateTime fromDateTime;
        private DateTime toDateTime;
        private string serializeFileName;

        private DataManager() {
            SolvisList = new List<RowValues>();
            SensorsSeriesList = new List<Series>();
            ActorsSeriesList = new List<Series>();
            OptionsSeriesList = new List<Series>();
        }

        public static DataManager Instance {
            get { return s_instance; }
        }

        public void Init() {
            serializeFileName = ConfigManager.ConfigDir + Path.DirectorySeparatorChar + "solvis.bin";
            AppManager.ItemManager.ToolMenu.DateEvent += DateEvent;
        }

        public void FillSolvisList(string fileName) {
            if (!File.Exists(fileName)) {
                return;
            }
            try {
                AppManager.MainForm.Cursor = Cursors.WaitCursor;
                AppManager.MainForm.SetStatusLabel(string.Empty);
                RowValues.mean.Reset();
                SolvisList.Clear();
                StreamReader reader = File.OpenText(fileName);
                try {
                    while (!reader.EndOfStream) {
                        RowValues item = new RowValues(reader.ReadLine());
                        SolvisList.Add(item);
                    }
                    DateTime min = (SolvisList[0].DateAndTime);
                    DateTime max = (SolvisList[SolvisList.Count - 1].DateAndTime);
                    AppManager.ItemManager.ToolMenu.SetMinMaxDate(min, max);
                    AppManager.MainForm.Text = MainForm.ApplicationText + rFile + Path.GetFileNameWithoutExtension(fileName);
                }
                finally {
                    if (reader != null) {
                        reader.Close();
                    }
                }
                //Serialize();
                //DeSerialize();
            }
            catch (ArgumentException ex) {
                AppManager.MainForm.Text = MainForm.ApplicationText;
                SolvisList.Clear();
                DateTime now = DateTime.Now;
                AppManager.ItemManager.ToolMenu.SetMinMaxDate(now, now);
                AppManager.ItemManager.ToolMenu.SetDayItemsDisabled();
                AppManager.MainForm.SetStatusLabel(Resources.DataManagerSolvisFileError); //@Language Resource
                AppExtension.PrintStackTrace(ex);
            }
            finally {
                AppManager.ItemManager.UpdateItems();
                AppManager.MainForm.Cursor = Cursors.Default;
            }
        }

        public bool IsSolvisListEmpty {
            get { return SolvisList.Count == 0; }
        }

        public S01S04State CheckS01S04() {
            if (SolvisList.Count > 0) {
                double s01Values = 0;
                double s04Values = 0;
                for (int i = 0; i < SolvisList.Count; i++) {
                    s01Values += SolvisList[i].S01;
                    s04Values += SolvisList[i].S04;
                }
                if (s01Values < s04Values) {
                    return S01S04State.S01S04InterChanged;
                } else {
                    return S01S04State.S01S04Ok;
                }
            }
            return S01S04State.None;
        }

        public void UpdateSeries() {
            if (SensorsSeriesList.Count > 0 && ActorsSeriesList.Count > 0 && OptionsSeriesList.Count > 0) {
                FillAllCheckedSeriesWithNewData(fromDateTime, toDateTime);
            }
            AppManager.MainForm.ChartControl.ResetZoom();
        }

        private void DateEvent(object sender, DateEventArgs e) {
            fromDateTime = e.FromDate;
            toDateTime = e.ToDate;
            UpdateSeries();
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null) {
                if (checkBox.Tag != null) {
                    CheckBoxTag tag = checkBox.Tag as CheckBoxTag;
                    if (tag != null) {
                        AppManager.ConfigManager.SetConfigData(tag);
                        if (checkBox.Checked) {
                            FillSeriesWithNewData(tag, fromDateTime, toDateTime);
                        } else {
                            Chart chartMain = AppManager.MainForm.ChartControl.ChartMain;
                            chartMain.BeginInit();
                            DataPointCollection points = tag.Series.Points;
                            points.ClearFast(); //MsChartExtension
                            if (chartMain.Series.Contains(tag.Series)) {
                                chartMain.Series.Remove(tag.Series);
                            }
                            chartMain.EndInit();
                        }
                    }
                }
            }
        }

        public void InitSensorsSeries(IList<CheckBox> list) {
            for (int i = 0; i < list.Count; i++) {
                string key = "S" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                Series series = new Series(key);
                series.ChartType = SeriesChartType.FastLine;
                series.ChartArea = "ChartArea1";
                series.Legend = "Legend1";
                series.Color = checkBox.ForeColor;
                SensorsSeriesList.Add(series);
                CheckBoxTag tag = new CheckBoxTag(series, GroupIdent.Sensor, i, checkBox, key);
                checkBox.Tag = tag;
                checkBox.CheckedChanged += CheckBoxCheckedChanged;
            }
        }

        public void InitActorsSeries(IList<CheckBox> list) {
            for (int i = 0; i < list.Count; i++) {
                string key = "A" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                Series series = new Series(key);
                series.ChartType = SeriesChartType.FastLine;
                series.ChartArea = "ChartArea2";
                series.Legend = "Legend2";
                series.Color = checkBox.ForeColor;
                ActorsSeriesList.Add(series);
                CheckBoxTag tag = new CheckBoxTag(series, GroupIdent.Actor, i, checkBox, key);
                checkBox.Tag = tag;
                checkBox.CheckedChanged += CheckBoxCheckedChanged;
            }
        }

        public void InitOptionsSeries(IList<CheckBox> list) {
            for (int i = 0; i < list.Count; i++) {
                string key = "P" + (i + 1).ToString("00");
                CheckBox checkBox = list[i];
                Series series = new Series(key);
                series.ChartType = SeriesChartType.FastLine;
                series.ChartArea = "ChartArea1";
                series.Legend = "Legend1";
                series.Color = checkBox.ForeColor;
                OptionsSeriesList.Add(series);
                CheckBoxTag tag = new CheckBoxTag(series, GroupIdent.Option, i, checkBox, key);
                checkBox.Tag = tag;
                checkBox.CheckedChanged += CheckBoxCheckedChanged;
            }
        }

        private void FillSeriesWithNewData(CheckBoxTag tag, DateTime from, DateTime to) {
            if (tag != null) {
                Chart chartMain = AppManager.MainForm.ChartControl.ChartMain;
                int fromIndex = GetSolvisListIndex(from);
                int toIndex = GetSolvisListIndex(to);
                chartMain.BeginInit();
                DataPointCollection points = tag.Series.Points;
                points.ClearFast(); //MsChartExtension
                if (fromIndex < 0 || fromIndex >= toIndex) {
                    return;
                }
                points.SuspendUpdates();
                double[] array = null;
                for (int i = fromIndex; i <= toIndex; i++) {
                    RowValues values = SolvisList[i];
                    if (tag.Ident == GroupIdent.Sensor) {
                        array = values.GetSensors();
                        if (tag.Index != RowValues.SolarVSGIndex) {
                            points.AddXY(values.DateAndTime, array[tag.Index]);
                        } else {
                            points.AddXY(values.DateAndTime, values.FormulaSolarVSG);
                        }
                    } else if (tag.Ident == GroupIdent.Actor) {
                        array = values.GetActors();
                        points.AddXY(values.DateAndTime, array[tag.Index]);
                    } else { //GroupIdent.Option
                        SeriesState state = SeriesState.Inner;
                        if (i == fromIndex) {
                            state = SeriesState.First;
                        } else if (i == toIndex) {
                            state = SeriesState.Last;
                        }
                        SetOptionsPoints(tag.Index, values, points, state);
                    }
                }
                points.ResumeUpdates();
                if (!chartMain.Series.Contains(tag.Series)) {
                    chartMain.Series.Add(tag.Series);
                }
                chartMain.EndInit();
            }
        }

        private void FillAllCheckedSeriesWithNewData(DateTime from, DateTime to) {
            Chart chartMain = AppManager.MainForm.ChartControl.ChartMain;
            int fromIndex = GetSolvisListIndex(from);
            int toIndex = GetSolvisListIndex(to);
            chartMain.BeginInit();
            AppManager.MainForm.ChartControl.SetIntervals(new TimeSpan(to.Ticks - from.Ticks));
            for (int seriesIndex = 0; seriesIndex < SensorsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = AppManager.MainForm.SensorsCheckBoxes[seriesIndex];
                if (checkBox.Checked) {
                    Series series = SensorsSeriesList[seriesIndex];
                    DataPointCollection points = series.Points;
                    points.ClearFast(); //MsChartExtension
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        if (seriesIndex != RowValues.SolarVSGIndex) {
                            points.AddXY(values.DateAndTime, values.GetSensors()[seriesIndex]);
                        } else {
                            points.AddXY(values.DateAndTime, values.FormulaSolarVSG);
                        }
                    }
                    points.ResumeUpdates();
                    if (!chartMain.Series.Contains(series)) {
                        chartMain.Series.Add(series);
                    }
                }
            }
            for (int seriesIndex = 0; seriesIndex < ActorsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = AppManager.MainForm.ActorsCheckBoxes[seriesIndex];
                Series series = ActorsSeriesList[seriesIndex];
                if (checkBox.Checked) {
                    DataPointCollection points = series.Points;
                    points.ClearFast(); //MsChartExtension
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        points.AddXY(values.DateAndTime, values.GetActors()[seriesIndex]);
                    }
                    points.ResumeUpdates();
                    if (!chartMain.Series.Contains(series)) {
                        chartMain.Series.Add(series);
                    }
                }
            }
            for (int seriesIndex = 0; seriesIndex < OptionsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = AppManager.MainForm.OptionsCheckBoxes[seriesIndex];
                Series series = OptionsSeriesList[seriesIndex];
                if (checkBox.Checked) {
                    DataPointCollection points = series.Points;
                    points.ClearFast(); //MsChartExtension
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        SeriesState state = SeriesState.Inner;
                        if (i == fromIndex) {
                            state = SeriesState.First;
                        } else if (i == toIndex) {
                            state = SeriesState.Last;
                        }
                        SetOptionsPoints(seriesIndex, values, points, state);
                    }
                    points.ResumeUpdates();
                    if (!chartMain.Series.Contains(series)) {
                        chartMain.Series.Add(series);
                    }
                }
            }
            chartMain.EndInit();
        }

        private int GetSolvisListIndex(DateTime value) {
            if (SolvisList.Count == 0) {
                return -1;
            }
            for (int i = 0; i < SolvisList.Count; i++) {
                if (SolvisList[i].DateAndTime.CompareTo(value) >= 0) {
                    return i;
                }
            }
            return SolvisList.Count - 1;
        }

        private static void SetOptionsPoints(int index, RowValues values, DataPointCollection points, SeriesState state) {
            switch (index) {
                case 0:
                    points.AddXY(values.DateAndTime, values.FormulaBurner);
                    break;
                case 1:
                    points.AddXY(values.DateAndTime, values.FormulaSolarKW);
                    break;
                case 2:
                    points.AddXY(values.DateAndTime, values.FormulaSunPosition);
                    break;
                case 3:
                    points.AddXY(values.DateAndTime, values.FormulaIst_Soll1);
                    break;
                case 4:
                    points.AddXY(values.DateAndTime, values.FormulaIst_Soll2);
                    break;
                case 5:
                    points.AddXY(values.DateAndTime, CalculatorProxy.Formula1(values, state));
                    break;
                case 6:
                    points.AddXY(values.DateAndTime, CalculatorProxy.Formula2(values, state));
                    break;
                case 7:
                    points.AddXY(values.DateAndTime, CalculatorProxy.Formula3(values, state));
                    break;
                case 8:
                    points.AddXY(values.DateAndTime, CalculatorProxy.Formula4(values, state));
                    break;
                case 9:
                    points.AddXY(values.DateAndTime, CalculatorProxy.Formula5(values, state));
                    break;
                default:
                    break;
            }
        }

        public void Serialize() {
            Stream stream = null;
            try {
                stream = new FileStream(serializeFileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, SolvisList);
            }
            finally {
                if (stream != null) {
                    stream.Close();
                }
            }
        }

        public void DeSerialize() {
            Stream stream = null;
            try {
                if (File.Exists(serializeFileName)) {
                    stream = new FileStream(serializeFileName, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<RowValues> list = (List<RowValues>)formatter.Deserialize(stream);
                }
            }
            finally {
                if (stream != null) {
                    stream.Close();
                }
            }
        }
    }
}