using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace SystemX.Windows.Forms {

    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(resfinder), "SolvisSC2Viewer.files.ToolStripDateTimePicker.bmp")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripDateTimePicker : ToolStripControlHost {
        public event DateTimeHasChangedHandler DateTimeHasChanged;
        private DateTimePicker control;

        public ToolStripDateTimePicker()
            : base(CreateControlInstance()) {
            this.DisplayStyle = ToolStripItemDisplayStyle.Text;
        }

        private static Control CreateControlInstance() {
            DateTimePicker control = new DateTimePicker();
            control.Format = DateTimePickerFormat.Short;
            control.Name = "dateTimePicker";
            return control;
        }

        public DateTimePicker DateTimePicker {
            get {
                if (control == null) {
                    control = Control as DateTimePicker;
                }
                return control;
            }
        }

        public override string Text {
            get {
                return String.Empty;
            }
            set {
                base.Text = String.Empty;
            }
        }

        public DateTime Value {
            get { return DateTimePicker.Value; }
            set { DateTimePicker.Value = value; }
        }

        public DateTime MinDate {
            get { return DateTimePicker.MinDate; }
            set { DateTimePicker.MinDate = value; }
        }

        public DateTime MaxDate {
            get { return DateTimePicker.MaxDate; }
            set { DateTimePicker.MaxDate = value; }
        }

        protected override void OnSubscribeControlEvents(Control control) {
            base.OnSubscribeControlEvents(control);
            DateTimePicker.ValueChanged += DateTimeValueHasChanged;
        }

        protected override void OnLayout(LayoutEventArgs e) {
            base.OnLayout(e);
            DateTimePicker.Size = this.DefaultSize;
        }

        protected override void OnUnsubscribeControlEvents(Control control) {
            base.OnUnsubscribeControlEvents(control);
            DateTimePicker.ValueChanged -= DateTimeValueHasChanged;
        }

        void DateTimeValueHasChanged(object sender, EventArgs e) {
            if (this.DateTimeHasChanged != null) {
                DateTimeHasChanged(DateTimePicker.Value);
            }
        }

        protected override Size DefaultSize {
            get {
                if (base.Control != null && this.Font != null) {
                    Size s = TextRenderer.MeasureText("99.99.9999", this.Font);
                    return new Size(s.Width + SystemInformation.VerticalScrollBarWidth, 23);
                } else {
                    return new Size(80, 23);
                }
                //float dpiX = (new Control()).CreateGraphics().DpiX;
                //float factor = dpiX / 96f;
                //return new Size((int)(78 * factor), 23);
            }
        }

    }
    public delegate void DateTimeHasChangedHandler(DateTime newDateTime);
}
internal class resfinder { }
