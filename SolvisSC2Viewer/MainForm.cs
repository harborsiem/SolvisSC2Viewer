﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolvisSC2Viewer {
    public partial class MainForm : Form {

        public MainForm() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            this.Text = AppManager.ApplicationText;
            AppManager.Init(this);
        }

        public static bool IsLocked {
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

        public void UpdateSeriesColors() {
            for (int i = 0; i < SensorsCheckBoxes.Count; i++) {
                CheckBoxTag tag = SensorsCheckBoxes[i].Tag as CheckBoxTag;
                if (tag != null) {
                    tag.Series.Color = tag.CheckBox.ForeColor;
                }
            }

            for (int i = 0; i < ActorsCheckBoxes.Count; i++) {
                CheckBoxTag tag = ActorsCheckBoxes[i].Tag as CheckBoxTag;
                if (tag != null) {
                    tag.Series.Color = tag.CheckBox.ForeColor;
                }
            }
            for (int i = 0; i < OptionsCheckBoxes.Count; i++) {
                CheckBoxTag tag = OptionsCheckBoxes[i].Tag as CheckBoxTag;
                if (tag != null) {
                    tag.Series.Color = tag.CheckBox.ForeColor;
                }
            }
        }

        public void UpdateToolTips() {
            sensorsActors.MakeTips();
        }

        public ChartControl ChartControl {
            get { return chartControl; }
        }

        public void SetStatusLabel(string text) {
            statusLabel.Text = text;
        }
    }
}
