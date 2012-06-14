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

namespace SolvisSC2Viewer {
    internal class DataManager {

        private static DataManager s_instance = new DataManager();

        public List<RowValues> SolvisList { get; private set; }
        public List<Series> SensorsSeriesList { get; private set; }
        public List<Series> ActorsSeriesList { get; private set; }
        public List<Series> OptionsSeriesList { get; private set; }
        private IList<CheckBox> SensorsCheckBoxes { get; set; }
        private IList<CheckBox> ActorsCheckBoxes { get; set; }
        private IList<CheckBox> OptionsCheckBoxes { get; set; }
        public Chart ChartMain { get; private set; }
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
            ChartMain = AppManager.MainForm.ChartMain;
            SensorsCheckBoxes = AppManager.MainForm.SensorsCheckBoxes;
            ActorsCheckBoxes = AppManager.MainForm.ActorsCheckBoxes;
            OptionsCheckBoxes = AppManager.MainForm.OptionsCheckBoxes;
            serializeFileName = ConfigManager.ConfigDir + Path.DirectorySeparatorChar + "solvis.bin";
            AppManager.ItemManager.ToolMenu.DateEvent += DateEvent;
            ChartMain.AxisViewChanged += new EventHandler<ViewEventArgs>(ChartMain_AxisViewChanged);
        }

        void ChartMain_AxisViewChanged(object sender, ViewEventArgs e) {
            if (e.Axis.AxisName == AxisName.X) {
                if (e.Axis.ScrollBar.IsVisible) {
                    ChartMain.ChartAreas["ChartArea2"].AxisX.MinorGrid.Enabled = true;
                    e.Axis.MinorGrid.Enabled = true;
                    e.Axis.LabelStyle.Angle = -90;
                    e.Axis.LabelStyle.Interval = 1;
                } else {
                    ResetZoom(e.Axis);
                }
            }
        }

        private void ResetZoom(Axis axisX) {
            ChartMain.ChartAreas["ChartArea2"].AxisX.MinorGrid.Enabled = false;
            axisX.MinorGrid.Enabled = false;
            axisX.LabelStyle.Angle = -90;
            axisX.LabelStyle.Interval = 6;
        }

        public void UpdateSeries() {
            if (SensorsSeriesList.Count > 0 && ActorsSeriesList.Count > 0 && OptionsSeriesList.Count > 0) {
                FillAllCheckedSeriesWithNewData(fromDateTime, toDateTime);
            }
            Axis axisX = ChartMain.ChartAreas["ChartArea1"].AxisX;
            axisX.LabelStyle.Angle = -90;
            if (axisX.ScaleView.IsZoomed) {
                ResetZoom(axisX);
                axisX.ScaleView.ZoomReset(100);
            }
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
                            ChartMain.BeginInit();
                            tag.Series.Points.Clear();
                            if (ChartMain.Series.Contains(tag.Series)) {
                                ChartMain.Series.Remove(tag.Series);
                            }
                            ChartMain.EndInit();
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
                int fromIndex = GetSolvisListIndex(from);
                int toIndex = GetSolvisListIndex(to);
                ChartMain.BeginInit();
                DataPointCollection points = tag.Series.Points;
                points.Clear();
                if (fromIndex < 0 || fromIndex >= toIndex) {
                    return;
                }
                points.SuspendUpdates();
                double[] array = null;
                for (int i = fromIndex; i <= toIndex; i++) {
                    RowValues values = SolvisList[i];
                    if (tag.Ident == GroupIdent.Sensor) {
                        array = values.GetSensors();
                        points.AddXY(values.DateAndTime, array[tag.Index]);
                    } else if (tag.Ident == GroupIdent.Actor) {
                        array = values.GetActors();
                        points.AddXY(values.DateAndTime, array[tag.Index]);
                    } else { //GroupIdent.Option
                        SetOptionsPoints(tag.Index, values, points);
                    }
                }
                points.ResumeUpdates();
                if (!ChartMain.Series.Contains(tag.Series)) {
                    ChartMain.Series.Add(tag.Series);
                }
                ChartMain.EndInit();
            }
        }

        private void FillAllCheckedSeriesWithNewData(DateTime from, DateTime to) {
            int fromIndex = GetSolvisListIndex(from);
            int toIndex = GetSolvisListIndex(to);
            ChartMain.BeginInit();
            for (int seriesIndex = 0; seriesIndex < SensorsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = SensorsCheckBoxes[seriesIndex];
                if (checkBox.Checked) {
                    Series series = SensorsSeriesList[seriesIndex];
                    DataPointCollection points = series.Points;
                    points.Clear();
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        points.AddXY(values.DateAndTime, values.GetSensors()[seriesIndex]);
                    }
                    points.ResumeUpdates();
                    if (!ChartMain.Series.Contains(series)) {
                        ChartMain.Series.Add(series);
                    }
                }
            }
            for (int seriesIndex = 0; seriesIndex < ActorsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = ActorsCheckBoxes[seriesIndex];
                Series series = ActorsSeriesList[seriesIndex];
                if (checkBox.Checked) {
                    DataPointCollection points = series.Points;
                    points.Clear();
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        points.AddXY(values.DateAndTime, values.GetActors()[seriesIndex]);
                    }
                    points.ResumeUpdates();
                    if (!ChartMain.Series.Contains(series)) {
                        ChartMain.Series.Add(series);
                    }
                }
            }
            for (int seriesIndex = 0; seriesIndex < OptionsSeriesList.Count; seriesIndex++) {
                CheckBox checkBox = OptionsCheckBoxes[seriesIndex];
                Series series = OptionsSeriesList[seriesIndex];
                if (checkBox.Checked) {
                    DataPointCollection points = series.Points;
                    points.Clear();
                    if (fromIndex < 0 || fromIndex >= toIndex) {
                        continue;
                    }
                    points.SuspendUpdates();
                    for (int i = fromIndex; i <= toIndex; i++) {
                        RowValues values = SolvisList[i];
                        SetOptionsPoints(seriesIndex, values, points);
                    }
                    points.ResumeUpdates();
                    if (!ChartMain.Series.Contains(series)) {
                        ChartMain.Series.Add(series);
                    }
                }
            }
            ChartMain.EndInit();
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

        private static void SetOptionsPoints(int index, RowValues values, DataPointCollection points) {
            switch (index) {
                case 0:
                    points.AddXY(values.DateAndTime, values.FormulaBurner);
                    break;
                case 1:
                    points.AddXY(values.DateAndTime, values.FormulaSolar);
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
                    points.AddXY(values.DateAndTime, values.Calculator1);
                    break;
                case 6:
                    points.AddXY(values.DateAndTime, values.Calculator2);
                    break;
                case 7:
                    points.AddXY(values.DateAndTime, values.Calculator3);
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