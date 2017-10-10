using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public partial class HeatCurve : Form {
        public const decimal SetTemperatureMaximum = 28.0M;
        public const decimal SetTemperatureMinimum = 12.0M;
        public const decimal LevelMaximum = 5M;
        public const decimal LevelMinimum = -5M;
        public const decimal GradientIncrement = 0.05M;
        public const decimal GradientMaximum = 2.0M;
        public const decimal GradientMinimum = 0.5M;

        private CheckState curve1State;
        private CheckState curve2State;
        private static readonly string runCurve = Resources.HeatCurveRunCurve; //@Language Resource

        private static HeatCurve instance;

        public static HeatCurve Instance {
            get {
                if (instance == null) {
                    instance = new HeatCurve();
                }
                return instance;
            }
        }

        public HeatCurve() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            ReadConfigToHelper();
            HeatCurveHelper.HeatCurve = this;
            chartMain.ChartAreas[0].AxisX.Title = Resources.HeatCurveAxisXTitle; //@Language Resource
            chartMain.ChartAreas[0].AxisY2.Title = Resources.HeatCurveAxisYTitle; //@Language Resource
            this.Icon = AppManager.IconManager.AppIcon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new FormClosingEventHandler(HeatCurve_FormClosing);
            this.WindowState = HeatCurveHelper.LastWindowState;
            Init();
        }

        private void ReadConfigToHelper() {
            if (HeatCurveHelper.IsInitialised) {
                return;
            }
            decimal temperature = ConfigManager.Temperature;
            decimal level = ConfigManager.Level;
            decimal gradient = (decimal)(Math.Round(ConfigManager.Gradient * 2, 1) / 2D);
            HeatCurveHelper.Temperature1 = temperature;
            HeatCurveHelper.Temperature2 = temperature;
            HeatCurveHelper.Temperature3 = temperature;
            HeatCurveHelper.Level1 = level;
            HeatCurveHelper.Level2 = level;
            HeatCurveHelper.Level3 = level;
            HeatCurveHelper.Gradient1 = gradient;
            HeatCurveHelper.Gradient2 = gradient;
            HeatCurveHelper.Gradient3 = gradient;
            HeatCurveHelper.Curve1State = CheckState.Solvis;
            HeatCurveHelper.Curve2State = CheckState.Solvis;
            HeatCurveHelper.LastWindowState = this.WindowState;
            HeatCurveHelper.IsInitialised = true;
        }

        private void StoreValuesToHelper() {
            HeatCurveHelper.Temperature1 = temperatureUpDown1.Value;
            HeatCurveHelper.Temperature2 = temperatureUpDown2.Value;
            HeatCurveHelper.Temperature3 = temperatureUpDown3.Value;
            HeatCurveHelper.Level1 = levelUpDown1.Value;
            HeatCurveHelper.Level2 = levelUpDown2.Value;
            HeatCurveHelper.Level3 = levelUpDown3.Value;
            HeatCurveHelper.Gradient1 = gradientUpDown1.Value;
            HeatCurveHelper.Gradient2 = gradientUpDown2.Value;
            HeatCurveHelper.Gradient3 = gradientUpDown3.Value;
            HeatCurveHelper.Curve1State = curve1State;
            HeatCurveHelper.Curve2State = curve2State;
        }

        private void Init() {
            curve1State = HeatCurveHelper.Curve1State;
            curve2State = HeatCurveHelper.Curve2State;
            InitCheckedMenuItems();
            temperatureUpDown1.Maximum = SetTemperatureMaximum;
            temperatureUpDown1.Minimum = SetTemperatureMinimum;
            temperatureUpDown1.Value = HeatCurveHelper.Temperature1;
            temperatureUpDown2.Maximum = SetTemperatureMaximum;
            temperatureUpDown2.Minimum = SetTemperatureMinimum;
            temperatureUpDown2.Value = HeatCurveHelper.Temperature2;
            temperatureUpDown3.Maximum = SetTemperatureMaximum;
            temperatureUpDown3.Minimum = SetTemperatureMinimum;
            temperatureUpDown3.Value = HeatCurveHelper.Temperature3;
            levelUpDown1.Maximum = LevelMaximum;
            levelUpDown1.Minimum = LevelMinimum;
            levelUpDown1.Value = HeatCurveHelper.Level1;
            levelUpDown2.Maximum = LevelMaximum;
            levelUpDown2.Minimum = LevelMinimum;
            levelUpDown2.Value = HeatCurveHelper.Level2;
            levelUpDown3.Increment = 1.0M;
            levelUpDown3.Maximum = LevelMaximum;
            levelUpDown3.Minimum = LevelMinimum;
            levelUpDown3.Value = HeatCurveHelper.Level3;
            gradientUpDown1.Increment = GradientIncrement;
            gradientUpDown1.Maximum = GradientMaximum;
            gradientUpDown1.Value = HeatCurveHelper.Gradient1;
            gradientUpDown1.Minimum = GradientMinimum;
            gradientUpDown2.Increment = GradientIncrement;
            gradientUpDown2.Maximum = GradientMaximum;
            gradientUpDown2.Value = HeatCurveHelper.Gradient2;
            gradientUpDown2.Minimum = GradientMinimum;
            gradientUpDown3.Maximum = GradientMaximum;
            gradientUpDown3.Value = HeatCurveHelper.Gradient3;
            gradientUpDown3.Minimum = GradientMinimum;
            gradientUpDown3.Increment = GradientIncrement;
            this.temperatureUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.levelUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.gradientUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.temperatureUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.levelUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.gradientUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.temperatureUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);
            this.levelUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);
            this.gradientUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);

            ShowCurve(0, curve1State);
            ShowCurve(1, curve2State);
            IdealCurve(2, (double)temperatureUpDown3.Value, (double)levelUpDown3.Value, (double)gradientUpDown3.Value);
        }

        //Wenn bei der Kurve mehr Bauch nach oben gehen soll, dann ist Exponent (0.8) zu verkleinern und Faktor (1.8207) zu
        //vergrößern
        public static double SolvisCurve(double commandTemperature, double level, double gradient, double outdoorTemperature) {
            double result = (gradient * 1.8207 * Math.Pow((commandTemperature - outdoorTemperature), 0.8) + commandTemperature + level); //Solvis Curve ?
            return result;
        }

#if Test
        //not used
        private static double IdealCurve(double commandTemperature, double level, double gradient, double outdoorTemperature) {
            //double result = (gradient * 1.8317984 * Math.Pow((commandTemperature - outdoorTemperature), 0.8281902) + commandTemperature + level);
            double result = (gradient * 1.8207 * Math.Pow((commandTemperature - outdoorTemperature), 0.8) + commandTemperature + level); //Solvis Curve ?
            return result;
        }

        private static double IdealCurveTest(double commandTemperature, double level, double gradient, double outdoorTemperature) {
            //double result = (gradient * 1.8317984 * Math.Pow((commandTemperature - outdoorTemperature), 0.8281902) + commandTemperature + level);
            double result = (gradient * 1.76 * Math.Pow((commandTemperature - outdoorTemperature), 0.81) + commandTemperature + level); //Solvis Curve ?
            return result;
        }

        private void Curve(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)(int)SolvisCurve(commandTemperature, level, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }
#endif

        private void CurveStep(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = (double)(int)SolvisCurve(commandTemperature, level, gradient, (int)i);
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepRoundOptimized(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = Math.Round(SolvisCurve(commandTemperature, level, gradient, Math.Round(i * 2) / 2));
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepOptimized(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = Math.Round(SolvisCurve(commandTemperature, level, gradient, (i))); //
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepFloorOptimized(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = (int)(SolvisCurve(commandTemperature, level, gradient, Math.Floor(i))); //Math.Round
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void IdealCurve(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)SolvisCurve(commandTemperature, level, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

#if Test
        private void IdealCurveTest(int serieIndex, double commandTemperature, double level, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)IdealCurveTest(commandTemperature, level, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }
#endif

        protected override void WndProc(ref Message m) {
            //FormWindowState org = this.WindowState;
            base.WndProc(ref m);
            if (this.WindowState != FormWindowState.Minimized) {
                HeatCurveHelper.LastWindowState = this.WindowState;
            }
            //if (this.WindowState != org) {
            //    //this.OnFormWindowStateChanged(EventArgs.Empty);
            //}
        }

        private void HeatCurve_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                StoreValuesToHelper();
                this.Hide();
            }
            //instance = null;
            //HeatCurveHelper.HeatCurve = null;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            StoreValuesToHelper();
            this.Hide();
            //this.Close();
        }

        private void UpDown1_ValueChanged(object sender, EventArgs e) {
            ShowCurve(0, curve1State);
        }

        private void UpDown2_ValueChanged(object sender, EventArgs e) {
            ShowCurve(1, curve2State);
        }

        private void UpDown3_ValueChanged(object sender, EventArgs e) {
            IdealCurve(2, (double)temperatureUpDown3.Value, (double)levelUpDown3.Value, (double)gradientUpDown3.Value);
        }

        private static CheckState GetState(bool floor, bool round, bool notRound) {
            if (floor)
                return CheckState.TemperatureFloor;
            if (round)
                return CheckState.TemperatureRound;
            if (notRound)
                return CheckState.TemperatureNotRounded;
            return CheckState.Solvis;
        }

        private void curve1FloorItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve1RoundItem.Checked = false;
                    curve1NotRoundItem.Checked = false;
                }
            }
            ShowCurve1();
        }

        private void curve2FloorItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve2RoundItem.Checked = false;
                    curve2NotRoundItem.Checked = false;
                }
            }
            ShowCurve2();
        }

        private void curve1RoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve1FloorItem.Checked = false;
                    curve1NotRoundItem.Checked = false;
                }
            }
            ShowCurve1();
        }

        private void curve2RoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve2FloorItem.Checked = false;
                    curve2NotRoundItem.Checked = false;
                }
            }
            ShowCurve2();
        }

        private void curve1NotRoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve1FloorItem.Checked = false;
                    curve1RoundItem.Checked = false;
                }
            }
            ShowCurve1();
        }

        private void curve2NotRoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve2FloorItem.Checked = false;
                    curve2RoundItem.Checked = false;
                }
            }
            ShowCurve2();
        }

        private void InitCheckedMenuItems() {
            switch (curve1State) {
                case CheckState.Solvis:
                    break;
                case CheckState.TemperatureFloor:
                    curve1FloorItem.Checked = true;
                    break;
                case CheckState.TemperatureRound:
                    curve1RoundItem.Checked = true;
                    break;
                case CheckState.TemperatureNotRounded:
                    curve1NotRoundItem.Checked = true;
                    break;
                default:
                    break;
            }
            switch (curve2State) {
                case CheckState.Solvis:
                    break;
                case CheckState.TemperatureFloor:
                    curve2FloorItem.Checked = true;
                    break;
                case CheckState.TemperatureRound:
                    curve2RoundItem.Checked = true;
                    break;
                case CheckState.TemperatureNotRounded:
                    curve2NotRoundItem.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void ShowCurve1() {
            curve1State = GetState(curve1FloorItem.Checked, curve1RoundItem.Checked, curve1NotRoundItem.Checked);
            ShowCurve(0, curve1State);
        }

        private void ShowCurve2() {
            curve2State = GetState(curve2FloorItem.Checked, curve2RoundItem.Checked, curve2NotRoundItem.Checked);
            ShowCurve(1, curve2State);
        }

        private void ShowCurve(int index, CheckState state) {
            if (index < 0 || index > 1) {
                throw new ArgumentException("Wrong value", "index");
            }
            double temperature;
            double level;
            double gradient;
            if (index == 0) {
                temperature = (double)temperatureUpDown1.Value;
                level = (double)levelUpDown1.Value;
                gradient = (double)gradientUpDown1.Value;
            } else {
                temperature = (double)temperatureUpDown2.Value;
                level = (double)levelUpDown2.Value;
                gradient = (double)gradientUpDown2.Value;
            }
            switch (state) {
                case CheckState.Solvis:
                    CurveStep(index, temperature, level, gradient);
                    break;
                case CheckState.TemperatureFloor:
                    CurveStepFloorOptimized(index, temperature, level, gradient);
                    break;
                case CheckState.TemperatureRound:
                    CurveStepRoundOptimized(index, temperature, level, gradient);
                    break;
                case CheckState.TemperatureNotRounded:
                    CurveStepOptimized(index, temperature, level, gradient);
                    break;
                default:
                    break;
            }
            SetTitle();
        }

        private void printPreviewItem_Click(object sender, EventArgs e) {
            PrintingManager manager = chartMain.Printing;
            //manager.PageSetup();
            manager.PrintDocument.DefaultPageSettings.Landscape = true;
            manager.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);

            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.ClientSize = new Size(800, 600);
            dialog.Document = manager.PrintDocument;
            dialog.Icon = AppManager.IconManager.PrintPreviewIcon;

            dialog.ShowDialog(AppManager.MainForm);

            //manager.PrintPreview();
        }

        private void printItem_Click(object sender, EventArgs e) {
            PrintingManager manager = chartMain.Printing;
            manager.PrintDocument.DefaultPageSettings.Landscape = true;
            manager.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            manager.Print(true);
        }

        private void SetTitle() {
            chartMain.Titles[0].Font = new System.Drawing.Font("Courier", 8);
            chartMain.Titles[0].Text = " " + temperatureLabel1.Text + " " + levelLabel1.Text + " " + gradientLabel1.Text + "      " + runCurve
                + "\nCurve1: " + temperatureUpDown1.Value + ";         " + levelUpDown1.Value + ";         " + gradientUpDown1.Value.ToString("0.00", CultureInfo.CurrentCulture) + ";       " + GetStateText(curve1State)
                + "\nCurve2: " + temperatureUpDown2.Value + ";         " + levelUpDown2.Value + ";         " + gradientUpDown2.Value.ToString("0.00", CultureInfo.CurrentCulture) + ";       " + GetStateText(curve2State);
            chartMain.Titles[0].Alignment = ContentAlignment.TopLeft;
            chartMain.Titles[0].TextStyle = TextStyle.Default;
        }

        private static string GetStateText(CheckState state) {
            if (state == CheckState.Solvis) {
                return "Solvis";
            }
            if (state == CheckState.TemperatureFloor) {
                return "Temp. floor";
            }
            if (state == CheckState.TemperatureRound) {
                return "Temp. round";
            }
            if (state == CheckState.TemperatureNotRounded) {
                return "Temp. not rounded";
            }
            return String.Empty;
        }
    }

    public enum CheckState {
        Solvis,
        TemperatureRound,
        TemperatureFloor,
        TemperatureNotRounded
    }
}
