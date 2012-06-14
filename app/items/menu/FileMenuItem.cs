using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class FileMenuItem : ToolStripMenuItem, IItemBase {
        //private ToolStripMenuItem fileMenuItem;

        public FileMenuItem() {
            InitializeComponent();
        }

        public void Init() {
            this.open.ShortcutKeys = Keys.Control | Keys.O;
            this.open.Click += AppManager.GetAction(OpenFileAction.Name).ProcessEvent;

            this.printPreview.Click += AppManager.GetAction(PrintPreviewAction.Name).ProcessEvent;

            this.print.Click += AppManager.GetAction(PrintAction.Name).ProcessEvent;

            this.exit.ShortcutKeys = Keys.Alt | Keys.F4;
            this.exit.Click += AppManager.GetAction(ExitAction.Name).ProcessEvent;

            //LoadProperties();
            LoadIcons();
        }

        private void MenuProjectExit_Click(object sender, System.EventArgs e) {
            Application.Exit();
        }

        public void UpdateItems() {
            this.printPreview.Enabled = true;
            this.print.Enabled = true;
        }

        public void LoadProperties() {
        }

        public void LoadIcons() {
            IconManager iconManager = AppManager.IconManager;
            this.open.Image = iconManager.FileOpen;
            this.printPreview.Image = iconManager.PrintPreview;
            this.print.Image = iconManager.Print;
        }
    }
}