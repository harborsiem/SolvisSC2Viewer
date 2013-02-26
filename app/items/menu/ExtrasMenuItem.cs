using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class ExtrasMenuItem : ToolStripMenuItem, IItemBase {
        //private ToolStripMenuItem extrasMenuItem;

        public ExtrasMenuItem() {
            InitializeComponent();
        }

        public void Init() {
            this.heatCurve.Click += AppManager.GetAction(HeatCurveAction.Name).ProcessEvent;
            this.sensorsCheck.Click += AppManager.GetAction(SensorsCheckAction.Name).ProcessEvent;
            this.configEditor.Click += AppManager.GetAction(ConfigEditorAction.Name).ProcessEvent;
            this.timePlan.Click += AppManager.GetAction(TimePlanAction.Name).ProcessEvent;
            this.countingList.Click += AppManager.GetAction(CountingListAction.Name).ProcessEvent;
            this.parameterList.Click += AppManager.GetAction(ParameterListAction.Name).ProcessEvent;
            //LoadProperties();
            LoadIcons();
        }

        public void UpdateItems() {
            if (AppManager.ConfigManager.Prototype) {
                countingList.Visible = true;
                parameterList.Visible = true;
            }
            this.sensorsCheck.Enabled = !AppManager.DataManager.IsSolvisListEmpty;
        }

        public void LoadProperties() {
        }

        public void LoadIcons() {
            //Nothing to do
        }
    }
}