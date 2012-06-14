using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SolvisSC2Viewer {
    internal partial class AboutDialog : BaseForm {
        private readonly String ReleaseName;

        private const int ImageWidth = 100;
        private const int ImageHeight = 100;

        private Image image;
        private AboutContentReader docReader;

        public AboutDialog() {
            InitializeComponent();
            FileVersionInfo fi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            string productVersion = fi.ProductVersion;
            ReleaseName = MainForm.ApplicationName + " " + productVersion;
        }

        public void Init() {
            AboutDialog dialog = this;
            //dialog.Text = "About";

            //--------------------HEADER----------------------------------
            this.image = AppManager.IconManager.AboutDescription;

            dialog.imageComposite.Paint += delegate(object sender, PaintEventArgs e) {
                Size bounds = this.image.Size;
                e.Graphics.DrawImage(this.image, ((ImageWidth - (int)bounds.Width) / 2), ((ImageHeight - (int)bounds.Height) / 2));
            };

            dialog.title.ForeColor = Color.Gray;
            dialog.title.Font = new Font(dialog.title.Font.Name, 24, FontStyle.Italic | FontStyle.Bold);
            dialog.title.Text = (ReleaseName);

            //-------------------TABS-----------------------
            docReader = new AboutContentReader();

            MakeTabItem(AboutContentReader.Description, dialog.textDescription);
            MakeTabItem(AboutContentReader.Authors, dialog.textAuthors);
            MakeTabItem(AboutContentReader.License, dialog.textLicense);

            dialog.tabFolder.SelectedIndexChanged += delegate(object sender, EventArgs e) {
                if (dialog.tabFolder.SelectedIndex == 0) {
                    this.image = AppManager.IconManager.AboutDescription;
                } else if (dialog.tabFolder.SelectedIndex == 1) {
                    this.image = AppManager.IconManager.AboutAuthors;
                } else if (dialog.tabFolder.SelectedIndex == 2) {
                    this.image = AppManager.IconManager.AboutLicense;
                }
                dialog.imageComposite.Refresh();
            };

            //------------------BUTTONS--------------------------
            //dialog.buttonClose.Text = "Close";
            dialog.buttonClose.Click += delegate(object sender, EventArgs e) {
                dialog.Dispose();
            };

            dialog.tabFolder.SelectedIndex = 0;

            dialog.buttonClose.Select();
        }

        private void MakeTabItem(String itemName, TextBox text) {
            text.Lines = docReader.Read(itemName.ToLowerInvariant());
        }
    }
}
