using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SystemX.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class MainToolItems : ToolStrip, IItemBase {
        public const String Name0 = "file.items";
        private const int FromDateTimeIndex = 4;
        private const int ToDateTimeIndex = FromDateTimeIndex + 2;
        private const int OverlapMaxDateMinutes = 3;
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
            this.Items.Insert(FromDateTimeIndex, fromDateTime);
            this.Items.Insert(ToDateTimeIndex, toDateTime);
            minDate = now;
            maxDate = now;
            actMinDate = now;
            actMaxDate = now;
            fromDateTime.DateTimeHasChanged += fromDateTime_DateTimeHasChanged;
            toDateTime.DateTimeHasChanged += toDateTime_DateTimeHasChanged;
        }

        private void toDateTime_DateTimeHasChanged(object sender, DateTimeEventArgs e) {
            if (e.NewDateTime.CompareTo(maxDate) == 1) {
                toDateTime.Value = maxDate;
            } else if (e.NewDateTime.CompareTo(actMinDate) == -1) {
                toDateTime.Value = actMinDate;
                actMaxDate = actMinDate;
            } else {
                actMaxDate = e.NewDateTime;
            }
            if (actMaxDate == maxDate) {
                nextDay.Enabled = false;
                lastDay.Enabled = false;
            } else {
                nextDay.Enabled = true;
                lastDay.Enabled = true;
            }
            if (!newMinMaxDate) {
                DateEventArgs args = new DateEventArgs(fromDateTime.Value, toDateTime.Value);
                OnDateChanged(args);
            }
            newMinMaxDate = false;
        }

        private void fromDateTime_DateTimeHasChanged(object sender, DateTimeEventArgs e) {
            if (e.NewDateTime.CompareTo(minDate) == -1) {
                fromDateTime.Value = minDate;
            } else if (e.NewDateTime.CompareTo(actMaxDate) == 1) {
                fromDateTime.Value = actMaxDate;
                actMinDate = actMaxDate;
            } else {
                actMinDate = e.NewDateTime;
            }
            if (actMinDate == minDate) {
                previousDay.Enabled = false;
                firstDay.Enabled = false;
            } else {
                previousDay.Enabled = true;
                firstDay.Enabled = true;
            }
            if (!newMinMaxDate) {
                DateEventArgs args = new DateEventArgs(fromDateTime.Value, toDateTime.Value);
                OnDateChanged(args);
            }
            newMinMaxDate = false;
        }

        private void OnDateChanged(DateEventArgs e) {
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

        private void PreviousFile_Click(object sender, EventArgs e) {
            AppManager.SolvisFileManager.PreviousFileClick();
        }

        private void NextFile_Click(object sender, EventArgs e) {
            AppManager.SolvisFileManager.NextFileClick();
        }

        private void crosshair_Click(object sender, EventArgs e) {
            crosshair.Checked = crosshair.Checked ? false : true;
            if (crosshair.Checked) {
                AppManager.MainForm.ChartControl.SetCursorCrossHairState();
            } else {
                AppManager.MainForm.ChartControl.SetCursorSelectionState();
            }
        }

        public void SetFileItemsVisible(bool visible) {
            separator4.Visible = visible;
            previousFile.Visible = visible;
            nextFile.Visible = visible;
        }

        public void SetFileItemsEnabled(bool previousEnabled, bool nextEnabled) {
            previousFile.Enabled = previousEnabled;
            nextFile.Enabled = nextEnabled;
        }

        public void SetDayItemsDisabled() {
            firstDay.Enabled = false;
            lastDay.Enabled = false;
            previousDay.Enabled = false;
            nextDay.Enabled = false;
        }

        public void Init() {
            SetDayItemsDisabled();
            this.open.Click += AppManager.GetAction(OpenFileAction.Name).ProcessEvent;
            this.print.Click += AppManager.GetAction(PrintAction.Name).ProcessEvent;
            this.firstDay.Click += FirstDay_Click;
            this.lastDay.Click += LastDay_Click;
            this.previousDay.Click += PreviousDay_Click;
            this.nextDay.Click += NextDay_Click;
            this.previousFile.Click += PreviousFile_Click;
            this.nextFile.Click += NextFile_Click;
            this.crosshair.Click += crosshair_Click;

            //
            //LoadProperties();
            LoadIcons();
        }

        public void UpdateItems() {
            this.print.Enabled = !AppManager.DataManager.IsSolvisListEmpty;
        }

        public void LoadProperties() {
        }

        public void LoadIcons() {
            IconManager iconManager = AppManager.IconManager;
            this.open.Image = iconManager.FileOpen;
            this.print.Image = iconManager.Print;
            this.firstDay.Image = iconManager.FirstDay;
            this.previousFile.Image = iconManager.PreviousFile;
            this.previousDay.Image = iconManager.PreviousDay;
            this.nextDay.Image = iconManager.NextDay;
            this.nextFile.Image = iconManager.NextFile;
            this.lastDay.Image = iconManager.LastDay;
            this.crosshair.Image = iconManager.CrossHair;
        }

        public void SetMinMaxDate(DateTime min, DateTime max) {
            DateTime lMin = new DateTime(min.Year, min.Month, min.Day);
            DateTime lMax = new DateTime(max.Year, max.Month, max.Day, 0, OverlapMaxDateMinutes, 0);
            if (fromDateTime.Value != lMin && toDateTime.Value != lMax) {
                newMinMaxDate = true;
            }
            if (max > lMax) {
                lMax = lMax.AddDays(1);
            }
            minDate = lMin;
            maxDate = lMax;
            actMinDate = lMin;
            actMaxDate = lMax;
            if (AppManager.ConfigManager.OneDayMode) {
                DateTime tryActMaxDate = actMinDate.Add(new TimeSpan(1, 0, OverlapMaxDateMinutes, 0));
                if (tryActMaxDate < actMaxDate) {
                    actMaxDate = tryActMaxDate;
                }
            }
            fromDateTime.MinDate = DateTimePicker.MinimumDateTime;
            fromDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            fromDateTime.Value = actMinDate;
            //fromDateTime.MinDate = lMin;
            //fromDateTime.MaxDate = lMax;
            toDateTime.MinDate = DateTimePicker.MinimumDateTime;
            toDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            toDateTime.Value = actMaxDate;
            //toDateTime.MinDate = lMin;
            //toDateTime.MaxDate = lMax;
        }
    }
}
