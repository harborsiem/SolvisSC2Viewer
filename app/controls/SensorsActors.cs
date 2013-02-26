using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class SensorsActors : UserControl {
        private List<CheckBox> sensors;
        private List<CheckBox> actors;
        private List<CheckBox> options;
        private ToolTip[] tips;

        public SensorsActors() {
            InitializeComponent();
            this.Size = controlLayout.Size;
            MakeSensorsList();
            MakeActorsList();
            MakeOptionsList();
        }

        public void MakeTips() {
            int i;
            if (tips == null) {
                tips = new ToolTip[sensors.Count + actors.Count + options.Count];
                for (i = 0; i < tips.Length; i++) {
                    tips[i] = new ToolTip();
                }
            }
            ConfigManager manager = AppManager.ConfigManager;
            IDictionary<string, ConfigData> datas = null;
            i = 0;
            int j = 0;
            int limit1 = sensors.Count;
            int limit2 = sensors.Count + actors.Count;
            while (i < tips.Length) {
                string toolTipText = null;
                CheckBox control;
                if (i < limit1) {
                    control = sensors[j++];
                    datas = manager.SensorConfigValues;
                } else if (i < limit2) {
                    control = actors[j++ - limit1];
                    datas = manager.ActorConfigValues;
                } else {
                    control = options[j++ - limit2];
                    datas = manager.OptionConfigValues;
                }
                CheckBoxTag tag = control.Tag as CheckBoxTag;
                if (tag != null) {
                    toolTipText = datas[tag.ConfigKey].ToolTipText;
                } else {
                    toolTipText = control.Text;
                }
                tips[i++].SetToolTip(control, toolTipText);
            }
        }

        private void MakeSensorsList() {
            sensors = new List<CheckBox>();
            sensors.Add(s1Check);
            sensors.Add(s2Check);
            sensors.Add(s3Check);
            sensors.Add(s4Check);
            sensors.Add(s5Check);
            sensors.Add(s6Check);
            sensors.Add(s7Check);
            sensors.Add(s8Check);
            sensors.Add(s9Check);
            sensors.Add(s10Check);
            sensors.Add(s11Check);
            sensors.Add(s12Check);
            sensors.Add(s13Check);
            sensors.Add(s14Check);
            sensors.Add(s15Check);
            sensors.Add(s16Check);
            sensors.Add(s17Check);
            sensors.Add(s18Check);
            sensors.Add(s19Check);
            sensors.Add(s20Check);
            sensors.Add(s21Check);
            sensors.Add(s22Check);
            sensors.Add(s23Check);
            sensors.Add(s24Check);
        }

        private void MakeActorsList() {
            actors = new List<CheckBox>();
            actors.Add(a1Check);
            actors.Add(a2Check);
            actors.Add(a3Check);
            actors.Add(a4Check);
            actors.Add(a5Check);
            actors.Add(a6Check);
            actors.Add(a7Check);
            actors.Add(a8Check);
            actors.Add(a9Check);
            actors.Add(a10Check);
            actors.Add(a11Check);
            actors.Add(a12Check);
            actors.Add(a13Check);
            actors.Add(a14Check);
            actors.Add(a15Check);
            actors.Add(a16Check);
            actors.Add(a17Check);
            actors.Add(a18Check);
            actors.Add(a19Check);
            actors.Add(a20Check);
        }

        private void MakeOptionsList() {
            options = new List<CheckBox>();
            options.Add(p01Check);
            options.Add(p02Check);
            options.Add(p03Check);
            options.Add(p04Check);
            options.Add(p05Check);
            options.Add(p06Check);
            options.Add(p07Check);
            options.Add(p08Check);
            options.Add(p09Check);
            options.Add(p10Check);
        }

        public IList<CheckBox> SensorsCheckBoxes {
            get { return new List<CheckBox>(sensors); }
        }

        public IList<CheckBox> ActorsCheckBoxes {
            get { return new List<CheckBox>(actors); }
        }

        public IList<CheckBox> OptionsCheckBoxes {
            get { return new List<CheckBox>(options); }
        }

        private void SensorsActors_Load(object sender, EventArgs e) {
            this.Size = controlLayout.Size;
        }

        private void Check_VisibleChanged(object sender, EventArgs e) {
            this.Size = new Size(this.Width, controlLayout.PreferredSize.Height);
        }

        private void controlLayout_Resize(object sender, EventArgs e) {
            this.Size = new Size(this.Width, controlLayout.PreferredSize.Height);
        }
    }
}
