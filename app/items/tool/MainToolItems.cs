using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SystemX.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class MainToolItems : ToolStrip, IItemBase {
        public const String Name0 = "file.items";
        internal event EventHandler<DateEventArgs> DateEvent;
        private ToolStripDateTimePicker fromDateTime;
        private ToolStripDateTimePicker toDateTime;
        private DateTime minDate;
        private DateTime maxDate;
        private DateTime actMinDate;
        private DateTime actMaxDate;
        private bool newMinMaxDate;

        public MainToolItems() {
            InitializeComponent();
            fromDateTime = new ToolStripDateTimePicker();
            fromDateTime.AutoSize = true;
            fromDateTime.Name = "fromDateTime";
            fromDateTime.Size = new System.Drawing.Size(80, 23);
            DateTime now = DateTime.Now;
            fromDateTime.Value = now;
            toDateTime = new ToolStripDateTimePicker();
            toDateTime.AutoSize = true;
            toDateTime.Name = "toDateTime";
            toDateTime.Size = new System.Drawing.Size(80, 23);
            toDateTime.Value = now;
            this.Items.Insert(4, fromDateTime);
            this.Items.Insert(6, toDateTime);
            minDate = now;
            maxDate = now;
            actMinDate = now;
            actMaxDate = now;
            fromDateTime.DateTimeHasChanged += new DateTimeHasChangedHandler(fromDateTime_DateTimeHasChanged);
            toDateTime.DateTimeHasChanged += new DateTimeHasChangedHandler(toDateTime_DateTimeHasChanged);
        }

        private void toDateTime_DateTimeHasChanged(DateTime newDateTime) {
            if (newDateTime.CompareTo(maxDate) == 1) {
                toDateTime.Value = maxDate;
            } else if (newDateTime.CompareTo(actMinDate) == -1) {
                toDateTime.Value = actMinDate;
                actMaxDate = actMinDate;
            } else {
                actMaxDate = newDateTime;
            }
            if (!newMinMaxDate) {
                DateEventArgs args = new DateEventArgs(fromDateTime.Value, toDateTime.Value);
                OnDateChanged(args);
            }
            newMinMaxDate = false;
        }

        private void fromDateTime_DateTimeHasChanged(DateTime newDateTime) {
            if (newDateTime.CompareTo(minDate) == -1) {
                fromDateTime.Value = minDate;
            } else if (newDateTime.CompareTo(actMaxDate) == 1) {
                fromDateTime.Value = actMaxDate;
                actMinDate = actMaxDate;
            } else {
                actMinDate = newDateTime;
            }
            if (!newMinMaxDate) {
                DateEventArgs args = new DateEventArgs(fromDateTime.Value, toDateTime.Value);
                OnDateChanged(args);
            }
            newMinMaxDate = false;
        }

        //int eventCount;

        private void OnDateChanged(DateEventArgs e) {
            //eventCount++;
            EventHandler<DateEventArgs> handler = DateEvent;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void FirstDay_Click(object sender, EventArgs e) {
            TimeSpan delta = toDateTime.Value - fromDateTime.Value;
            if (fromDateTime.Value > minDate) {
                newMinMaxDate = true;
                fromDateTime.Value = minDate;
                toDateTime.Value = minDate + delta;
            }
        }

        private void LastDay_Click(object sender, EventArgs e) {
            TimeSpan delta = toDateTime.Value - fromDateTime.Value;
            if (toDateTime.Value < maxDate) {
                newMinMaxDate = true;
                toDateTime.Value = maxDate;
                fromDateTime.Value = maxDate - delta;
            }
        }

        private void PreviousDay_Click(object sender, EventArgs e) {
            TimeSpan delta = new TimeSpan(1, 0, 0, 0);
            if (fromDateTime.Value > minDate) {
                newMinMaxDate = true;
                fromDateTime.Value = fromDateTime.Value - delta;
                toDateTime.Value = toDateTime.Value - delta;
            }
        }

        private void NextDay_Click(object sender, EventArgs e) {
            TimeSpan delta = new TimeSpan(1, 0, 0, 0);
            if (toDateTime.Value < maxDate) {
                newMinMaxDate = true;
                toDateTime.Value = toDateTime.Value + delta;
                fromDateTime.Value = fromDateTime.Value + delta;
            }
        }

        private void PreviousWeek_Click(object sender, EventArgs e) {
            //TimeSpan delta = new TimeSpan(7, 0, 0, 0);
            newMinMaxDate = false;
        }

        private void NextWeek_Click(object sender, EventArgs e) {
            //TimeSpan delta = new TimeSpan(7, 0, 0, 0);
        }

        private void crosshair_Click(object sender, EventArgs e) {
            crosshair.Checked = crosshair.Checked ? false : true;
            if (crosshair.Checked) {
                AppManager.MainForm.ChartControl.SetCursorCrossHairState();
            } else {
                AppManager.MainForm.ChartControl.SetCursorSelectionState();
            }
        }

        public void Init() {
            this.open.Click += AppManager.GetAction(OpenFileAction.Name).ProcessEvent;
            this.print.Click += AppManager.GetAction(PrintAction.Name).ProcessEvent;
            this.firstDay.Click += FirstDay_Click;
            this.lastDay.Click += LastDay_Click;
            this.previousDay.Click += PreviousDay_Click;
            this.nextDay.Click += NextDay_Click;
            this.previousWeek.Click += PreviousWeek_Click;
            this.nextWeek.Click += NextWeek_Click;
            this.crosshair.Click += crosshair_Click;

            //
            //LoadProperties();
            LoadIcons();
        }

        public void UpdateItems() {
            this.print.Enabled = true;
        }

        public void LoadProperties() {
        }

        public void LoadIcons() {
            IconManager iconManager = AppManager.IconManager;
            this.open.Image = iconManager.FileOpen;
            this.print.Image = iconManager.Print;
            this.firstDay.Image = iconManager.FirstDay;
            this.previousWeek.Image = iconManager.PreviousWeek;
            this.previousDay.Image = iconManager.PreviousDay;
            this.nextDay.Image = iconManager.NextDay;
            this.nextWeek.Image = iconManager.NextWeek;
            this.lastDay.Image = iconManager.LastDay;
            this.crosshair.Image = iconManager.CrossHair;
        }

        public void SetMinMaxDate(DateTime min, DateTime max) {
            if (fromDateTime.Value != min && toDateTime.Value != max) {
                newMinMaxDate = true;
            }
            minDate = min;
            maxDate = max;
            actMinDate = min;
            actMaxDate = max;
            fromDateTime.MinDate = DateTimePicker.MinimumDateTime;
            fromDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            fromDateTime.Value = min;
            //fromDateTime.MinDate = min;
            //fromDateTime.MaxDate = max;
            toDateTime.MinDate = DateTimePicker.MinimumDateTime;
            toDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            toDateTime.Value = max;
            //toDateTime.MinDate = min;
            //toDateTime.MaxDate = max;
        }
    }
}
