using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public partial class HelpMenuItem : ToolStripMenuItem, IItemBase {
        //private ToolStripMenuItem helpMenuItem;

        public HelpMenuItem() {
            InitializeComponent();
        }

        public void Init() {
            this.doc.Click += AppManager.GetAction(DocAction.Name).ProcessEvent;

            this.about.Click += AppManager.GetAction(AboutAction.Name).ProcessEvent;

            //LoadProperties();
            LoadIcons();
        }

        public void UpdateItems() {
            //Nothing to do
        }

        public void LoadProperties() {
        }

        public void LoadIcons() {
            //Nothing to do
        }
    }
}