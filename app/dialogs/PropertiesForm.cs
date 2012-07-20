using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SolvisSC2Viewer {
    public partial class PropertiesForm : BaseForm {
        private Control propertyGridView;
        private MethodInfo MoveSplitterTo;
        private PropertyInfo InternalLabelWidth;

        public PropertiesForm() {
            InitializeComponent();
            GetPropertyGridViewInfos();

            //heatPropertyGrid.Controls[2].GotFocus += new EventHandler(Form1_GotFocus);
        }

        protected override void OnLoad(EventArgs e) {
            this.Text = Description + " -- " + DateTime.ToString();
            base.OnLoad(e);
        }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public object SelectedObject {
            get { return heatPropertyGrid.SelectedObject; }
            set { heatPropertyGrid.SelectedObject = value; }
        }

        private void GetPropertyGridViewInfos() {
            propertyGridView = heatPropertyGrid.Controls[2];
            Type type = propertyGridView.GetType();
            MoveSplitterTo = type.GetMethod("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic);
            InternalLabelWidth = type.GetProperty("InternalLabelWidth", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        private void Form1_GotFocus(object sender, EventArgs e) {
            int count = (int)((heatPropertyGrid.Controls[2].Width - 16 -
                SystemInformation.VerticalScrollBarWidth) * 0.25 / 3);
            NativeMethods.keybd_event(0x11 /*VK_CONTROL*/, 0x9d, 0, UIntPtr.Zero); // Ctrl Press 
            for (int i = 0; i < count; i++) {
                NativeMethods.keybd_event(0x27 /*VK_RIGHT*/, 0x9e, 0, UIntPtr.Zero); // RIGHT arrow Press 
                NativeMethods.keybd_event(0x27 /*VK_RIGHT*/, 0x9e, 0x0002/*KEYEVENTF_KEYUP*/, UIntPtr.Zero); // RIGHT arrow Press Release 
            }
            NativeMethods.keybd_event(0x11 /*VK_CONTROL*/, 0x9d, 0x0002/*KEYEVENTF_KEYUP*/, UIntPtr.Zero); // Ctrl Release 
        }

        private void Form1_Shown(object sender, EventArgs e) {
            //mit Reflection wird der PropertyGrid in der Spaltenbreite eingestellt.
            int labelWidth = (int)InternalLabelWidth.GetValue(propertyGridView, null);
            labelWidth = (int)((labelWidth * 2) / 4.0 * 3.0);
            MoveSplitterTo.Invoke(propertyGridView, new object[] { labelWidth });
            //heatPropertyGrid.Controls[2].Focus();
        }

        private class NativeMethods {

            private NativeMethods() {
            }

            [DllImport("user32.dll")]
            //[CLSCompliant(false)]
            public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        }
    }
}
