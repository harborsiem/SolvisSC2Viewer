using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace SolvisSC2Viewer {
    internal partial class AboutDialog : BaseForm {
        private readonly String ReleaseName;

        private const int ImageWidth = 100;
        private const int ImageHeight = 100;

        private Image image;
        private AboutContentReader docReader;
        private string signatureKey = String.Empty;

        public AboutDialog() {
            InitializeComponent();
            FileVersionInfo fi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            string productVersion = fi.ProductVersion;
            ReleaseName = AppManager.ApplicationName + " " + productVersion;
            signatureKey = GetSignature();
        }

        private string GetSignature() {
            byte[] keyToken = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
            StringBuilder keyTokenString = new StringBuilder();
            for (int i = 0; i < keyToken.Length; i++) {
                keyTokenString.Append(keyToken[i].ToString("X2"));
            }
            return keyTokenString.ToString();
        }

        public void Init() {

            //--------------------HEADER----------------------------------
            this.image = AppManager.IconManager.AboutDescription;

            imageComposite.Paint += delegate(object sender, PaintEventArgs e) {
                Size bounds = this.image.Size;
                e.Graphics.DrawImage(this.image, ((ImageWidth - (int)bounds.Width) / 2), ((ImageHeight - (int)bounds.Height) / 2));
            };

            title.ForeColor = Color.Gray;
            title.Font = new Font(title.Font.Name, 24, FontStyle.Italic | FontStyle.Bold);
            title.Text = (ReleaseName);

            //-------------------TABS-----------------------
            string language = string.Empty;
            CultureInfo info = CultureInfo.CurrentUICulture;
            if (info.TwoLetterISOLanguageName == "de") {
                language = "." + "de";
            }
            docReader = new AboutContentReader();

            MakeTabItem(AboutContentReader.Description, language, textDescription);
            if (!String.IsNullOrEmpty(signatureKey)) {
                textDescription.Text = textDescription.Text + Environment.NewLine + "PublicKeyToken: " + signatureKey + Environment.NewLine;
            }
            MakeTabItem(AboutContentReader.Authors, language, textAuthors);
            MakeTabItem(AboutContentReader.License, "", textLicense);

            tabFolder.SelectedIndexChanged += delegate(object sender, EventArgs e) {
                if (tabFolder.SelectedIndex == 0) {
                    this.image = AppManager.IconManager.AboutDescription;
                } else if (tabFolder.SelectedIndex == 1) {
                    this.image = AppManager.IconManager.AboutAuthors;
                } else if (tabFolder.SelectedIndex == 2) {
                    this.image = AppManager.IconManager.AboutLicense;
                }
                imageComposite.Invalidate();
            };

            //------------------BUTTONS--------------------------
            buttonClose.Click += delegate(object sender, EventArgs e) {
                Close();
            };

            tabFolder.SelectedIndex = 0;

            buttonClose.Select();
        }

        private void MakeTabItem(String itemName, string language, TextBox text) {
            text.Lines = docReader.Read(itemName.ToLowerInvariant(), language);
        }
    }
}
