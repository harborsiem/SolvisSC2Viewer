using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public partial class HeatCurve : BaseForm {
        public const decimal SetTemperatureMaximum = 28.0M;
        public const decimal SetTemperatureMinimum = 12.0M;
        public const decimal GradientIncrement = 0.05M;
        public const decimal GradientMaximum = 2.0M;
        public const decimal GradientMinimum = 0.5M;

        private CheckState curve1State;
        private CheckState curve2State;
        private static readonly string runCurve = Resources.HeatCurveRunCurve; //@Language Resource
        public FormWindowState LastWindowState {
            get;
            private set;
        }

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
            InitializeComponent();
            chartMain.ChartAreas[0].AxisX.Title = Resources.HeatCurveAxisXTitle; //@Language Resource
            chartMain.ChartAreas[0].AxisY2.Title = Resources.HeatCurveAxisYTitle; //@Language Resource
            this.Icon = AppManager.IconManager.AppIcon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new FormClosingEventHandler(HeatCurve_FormClosing);
            LastWindowState = this.WindowState;
            Init();
        }

        private void Init() {
            decimal temperature = ConfigManager.Temperature;
            decimal niveau = ConfigManager.Niveau;
            decimal gradient = (decimal)(Math.Round(ConfigManager.Gradient * 2, 1) / 2D);
            temperatureUpDown1.Maximum = SetTemperatureMaximum;
            temperatureUpDown1.Minimum = SetTemperatureMinimum;
            temperatureUpDown1.Value = temperature;
            temperatureUpDown2.Maximum = SetTemperatureMaximum;
            temperatureUpDown2.Minimum = SetTemperatureMinimum;
            temperatureUpDown2.Value = temperature;
            temperatureUpDown3.Maximum = SetTemperatureMaximum;
            temperatureUpDown3.Minimum = SetTemperatureMinimum;
            temperatureUpDown3.Value = temperature;
            niveauUpDown1.Value = niveau;
            niveauUpDown2.Value = niveau;
            niveauUpDown3.Increment = 1.0M;
            niveauUpDown3.Value = niveau;
            gradientUpDown1.Increment = GradientIncrement;
            gradientUpDown1.Maximum = GradientMaximum;
            gradientUpDown1.Value = gradient;
            gradientUpDown1.Minimum = GradientMinimum;
            gradientUpDown2.Increment = GradientIncrement;
            gradientUpDown2.Maximum = GradientMaximum;
            gradientUpDown2.Value = gradient;
            gradientUpDown2.Minimum = GradientMinimum;
            gradientUpDown3.Maximum = GradientMaximum;
            gradientUpDown3.Value = gradient;
            gradientUpDown3.Minimum = GradientMinimum;
            gradientUpDown3.Increment = GradientIncrement;
            this.temperatureUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.niveauUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.gradientUpDown1.ValueChanged += new System.EventHandler(this.UpDown1_ValueChanged);
            this.temperatureUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.niveauUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.gradientUpDown2.ValueChanged += new System.EventHandler(this.UpDown2_ValueChanged);
            this.temperatureUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);
            this.niveauUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);
            this.gradientUpDown3.ValueChanged += new System.EventHandler(this.UpDown3_ValueChanged);

            ShowCurve(0, curve1State);
            ShowCurve(1, curve2State);
            IdealCurve(2, (double)temperatureUpDown3.Value, (double)niveauUpDown3.Value, (double)gradientUpDown3.Value);
        }

        //Wenn bei der Kurve mehr Bauch nach oben gehen soll, dann ist Exponent (0.8) zu verkleinern und Faktor (1.8207) zu
        //vergrößern
        public static double SolvisCurve(double commandTemperature, double niveau, double gradient, double outdoorTemperature) {
            double result = (gradient * 1.8207 * Math.Pow((commandTemperature - outdoorTemperature), 0.8) + commandTemperature + niveau); //Solvis Curve ?
            return result;
        }

#if Test
        //not used
        private static double IdealCurve(double commandTemperature, double niveau, double gradient, double outdoorTemperature) {
            //double result = (gradient * 1.8317984 * Math.Pow((commandTemperature - outdoorTemperature), 0.8281902) + commandTemperature + niveau);
            double result = (gradient * 1.8207 * Math.Pow((commandTemperature - outdoorTemperature), 0.8) + commandTemperature + niveau); //Solvis Curve ?
            return result;
        }

        private static double IdealCurveTest(double commandTemperature, double niveau, double gradient, double outdoorTemperature) {
            //double result = (gradient * 1.8317984 * Math.Pow((commandTemperature - outdoorTemperature), 0.8281902) + commandTemperature + niveau);
            double result = (gradient * 1.76 * Math.Pow((commandTemperature - outdoorTemperature), 0.81) + commandTemperature + niveau); //Solvis Curve ?
            return result;
        }

        private void Curve(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)(int)SolvisCurve(commandTemperature, niveau, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }
#endif

        private void CurveStep(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = (double)(int)SolvisCurve(commandTemperature, niveau, gradient, (int)i);
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepRoundOptimized(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = Math.Round(SolvisCurve(commandTemperature, niveau, gradient, Math.Round(i * 2) / 2));
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepOptimized(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = Math.Round(SolvisCurve(commandTemperature, niveau, gradient, (i))); //
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void CurveStepFloorOptimized(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (double i = -20; i <= max; i = i + 0.1D) {
                double result = (int)(SolvisCurve(commandTemperature, niveau, gradient, Math.Floor(i))); //Math.Round
                points.AddXY((double)i, result);
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

        private void IdealCurve(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)SolvisCurve(commandTemperature, niveau, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }

#if Test
        private void IdealCurveTest(int serieIndex, double commandTemperature, double niveau, double gradient) {
            int max = (commandTemperature < 20) ? (int)commandTemperature : 20;
            chartMain.BeginInit();
            DataPointCollection points = chartMain.Series[serieIndex].Points;
            points.ClearFast(); //MsChartExtension
            points.SuspendUpdates();
            for (int i = -20; i <= max; i++) {
                points.AddXY((double)i, (double)IdealCurveTest(commandTemperature, niveau, gradient, i));
            }
            points.ResumeUpdates();
            chartMain.EndInit();
        }
#endif

        private void HeatCurve_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                closeButton_Click(sender, e);
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized) {
                LastWindowState = this.WindowState;
            }
            this.Hide();
        }

        private void UpDown1_ValueChanged(object sender, EventArgs e) {
            ShowCurve(0, curve1State);
        }

        private void UpDown2_ValueChanged(object sender, EventArgs e) {
            ShowCurve(1, curve2State);
        }

        private void UpDown3_ValueChanged(object sender, EventArgs e) {
            IdealCurve(2, (double)temperatureUpDown3.Value, (double)niveauUpDown3.Value, (double)gradientUpDown3.Value);
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

        private void curve1RoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve1RoundItem.Checked = false;
                    curve1NotRoundItem.Checked = false;
                }
            }
            curve1State = GetState(curve1FloorItem.Checked, curve1RoundItem.Checked, curve1NotRoundItem.Checked);
            ShowCurve(0, curve1State);
        }

        private void curve2RoundItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve2RoundItem.Checked = false;
                    curve2NotRoundItem.Checked = false;
                }
            }
            curve2State = GetState(curve2FloorItem.Checked, curve2RoundItem.Checked, curve2NotRoundItem.Checked);
            ShowCurve(1, curve2State);
        }

        private void curve1FloorItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve1FloorItem.Checked = false;
                    curve1NotRoundItem.Checked = false;
                }
            }
            curve1State = GetState(curve1FloorItem.Checked, curve1RoundItem.Checked, curve1NotRoundItem.Checked);
            ShowCurve(0, curve1State);
        }

        private void curve2FloorItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null) {
                item.Checked = !item.Checked;
                if (item.Checked) {
                    curve2FloorItem.Checked = false;
                    curve2NotRoundItem.Checked = false;
                }
            }
            curve2State = GetState(curve2FloorItem.Checked, curve2RoundItem.Checked, curve2NotRoundItem.Checked);
            ShowCurve(1, curve2State);
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
            curve1State = GetState(curve1FloorItem.Checked, curve1RoundItem.Checked, curve1NotRoundItem.Checked);
            ShowCurve(0, curve1State);
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
            curve2State = GetState(curve2FloorItem.Checked, curve2RoundItem.Checked, curve2NotRoundItem.Checked);
            ShowCurve(1, curve2State);
        }

        private void ShowCurve(int index, CheckState state) {
            if (index < 0 || index > 1) {
                throw new ArgumentException("Wrong value", "index");
            }
            double temperature;
            double niveau;
            double gradient;
            if (index == 0) {
                temperature = (double)temperatureUpDown1.Value;
                niveau = (double)niveauUpDown1.Value;
                gradient = (double)gradientUpDown1.Value;
            } else {
                temperature = (double)temperatureUpDown2.Value;
                niveau = (double)niveauUpDown2.Value;
                gradient = (double)gradientUpDown2.Value;
            }
            switch (state) {
                case CheckState.Solvis:
                    CurveStep(index, temperature, niveau, gradient);
                    break;
                case CheckState.TemperatureFloor:
                    CurveStepFloorOptimized(index, temperature, niveau, gradient);
                    break;
                case CheckState.TemperatureRound:
                    CurveStepRoundOptimized(index, temperature, niveau, gradient);
                    break;
                case CheckState.TemperatureNotRounded:
                    CurveStepOptimized(index, temperature, niveau, gradient);
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
            chartMain.Titles[0].Text = " " + temperatureLabel1.Text + " " + niveauLabel1.Text + " " + gradientLabel1.Text + "      " + runCurve
                + "\nCurve1: " + temperatureUpDown1.Value + ";         " + niveauUpDown1.Value + ";         " + gradientUpDown1.Value.ToString("0.00") + ";       " + GetStateText(curve1State)
                + "\nCurve2: " + temperatureUpDown2.Value + ";         " + niveauUpDown2.Value + ";         " + gradientUpDown2.Value.ToString("0.00") + ";       " + GetStateText(curve2State);
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
