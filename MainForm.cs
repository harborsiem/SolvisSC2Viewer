using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolvisSC2Viewer {
    public partial class MainForm : BaseForm {
        public const string ApplicationName = "SolvisSC2Viewer";
        public const string ApplicationText = "Solvis Control II Viewer";
        public static string ConfigPath = "Solvis" + Path.DirectorySeparatorChar + "SolvisViewer";

        public MainForm() {
            InitializeComponent();
            AppManager.Init(this);
        }

        public bool IsLocked {
            get { return false; }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Icon = AppManager.IconManager.AppIcon;
            //chartMain.Size = new System.Drawing.Size(10000, chartMain.Height);
            AppManager.ConfigManager.Init();
            AppManager.DataManager.InitSensorsSeries(SensorsCheckBoxes);
            AppManager.DataManager.InitActorsSeries(ActorsCheckBoxes);
            AppManager.DataManager.InitOptionsSeries(OptionsCheckBoxes);
            UpdateToolTips();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            SplashScreen.Instance().Finish();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            ActionLock.Unlock();
            AppManager.GetAction(DisposeAction.Name).ProcessEvent(sender, e);
        }

        private void dialogLayout_Resize(object sender, EventArgs e) {
            dialogLayout.SuspendLayout();
            scrollPanel.Size = new Size(scrollPanel.Width, toolStripContainer.ContentPanel.Height - scrollPanel.Margin.Top - scrollPanel.Margin.Bottom);
            chartControl.Size = new Size(chartControl.Width, toolStripContainer.ContentPanel.Height - chartControl.Margin.Top - chartControl.Margin.Bottom);
            dialogLayout.ResumeLayout();
        }

        public IList<CheckBox> SensorsCheckBoxes {
            get { return sensorsActors.SensorsCheckBoxes; }
        }

        public IList<CheckBox> ActorsCheckBoxes {
            get { return sensorsActors.ActorsCheckBoxes; }
        }

        public IList<CheckBox> OptionsCheckBoxes {
            get { return sensorsActors.OptionsCheckBoxes; }
        }

        public void UpdateToolTips() {
            sensorsActors.MakeTips();
        }

        public ChartControl ChartControl {
            get { return chartControl; }
        }
    }
}
