namespace SolvisSC2Viewer {
    partial class AboutDialog {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.header = new System.Windows.Forms.TableLayoutPanel();
            this.imageComposite = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.tabFolder = new System.Windows.Forms.TabControl();
            this.description = new System.Windows.Forms.TabPage();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.authors = new System.Windows.Forms.TabPage();
            this.textAuthors = new System.Windows.Forms.TextBox();
            this.license = new System.Windows.Forms.TabPage();
            this.textLicense = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dialogLayout.SuspendLayout();
            this.header.SuspendLayout();
            this.tabFolder.SuspendLayout();
            this.description.SuspendLayout();
            this.authors.SuspendLayout();
            this.license.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogLayout
            // 
            resources.ApplyResources(this.dialogLayout, "dialogLayout");
            this.dialogLayout.Controls.Add(this.header, 0, 0);
            this.dialogLayout.Controls.Add(this.tabFolder, 0, 1);
            this.dialogLayout.Controls.Add(this.buttons, 0, 2);
            this.dialogLayout.Name = "dialogLayout";
            // 
            // header
            // 
            resources.ApplyResources(this.header, "header");
            this.header.Controls.Add(this.imageComposite, 0, 0);
            this.header.Controls.Add(this.title, 1, 0);
            this.header.Name = "header";
            // 
            // imageComposite
            // 
            resources.ApplyResources(this.imageComposite, "imageComposite");
            this.imageComposite.BackColor = System.Drawing.SystemColors.Control;
            this.imageComposite.Name = "imageComposite";
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.Name = "title";
            // 
            // tabFolder
            // 
            resources.ApplyResources(this.tabFolder, "tabFolder");
            this.tabFolder.Controls.Add(this.description);
            this.tabFolder.Controls.Add(this.authors);
            this.tabFolder.Controls.Add(this.license);
            this.tabFolder.Name = "tabFolder";
            this.tabFolder.SelectedIndex = 0;
            // 
            // description
            // 
            this.description.Controls.Add(this.textDescription);
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            this.description.UseVisualStyleBackColor = true;
            // 
            // textDescription
            // 
            resources.ApplyResources(this.textDescription, "textDescription");
            this.textDescription.Name = "textDescription";
            this.textDescription.ReadOnly = true;
            // 
            // authors
            // 
            this.authors.Controls.Add(this.textAuthors);
            resources.ApplyResources(this.authors, "authors");
            this.authors.Name = "authors";
            this.authors.UseVisualStyleBackColor = true;
            // 
            // textAuthors
            // 
            resources.ApplyResources(this.textAuthors, "textAuthors");
            this.textAuthors.Name = "textAuthors";
            this.textAuthors.ReadOnly = true;
            // 
            // license
            // 
            this.license.Controls.Add(this.textLicense);
            resources.ApplyResources(this.license, "license");
            this.license.Name = "license";
            this.license.UseVisualStyleBackColor = true;
            // 
            // textLicense
            // 
            resources.ApplyResources(this.textLicense, "textLicense");
            this.textLicense.Name = "textLicense";
            this.textLicense.ReadOnly = true;
            // 
            // buttons
            // 
            resources.ApplyResources(this.buttons, "buttons");
            this.buttons.Controls.Add(this.buttonClose, 0, 0);
            this.buttons.Name = "buttons";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.MinimumSize = new System.Drawing.Size(80, 25);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.tabFolder.ResumeLayout(false);
            this.description.ResumeLayout(false);
            this.description.PerformLayout();
            this.authors.ResumeLayout(false);
            this.authors.PerformLayout();
            this.license.ResumeLayout(false);
            this.license.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.TableLayoutPanel header;
        public System.Windows.Forms.Panel imageComposite;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.TabControl tabFolder;
        public System.Windows.Forms.TabPage description;
        public System.Windows.Forms.TextBox textDescription;
        public System.Windows.Forms.TabPage authors;
        public System.Windows.Forms.TextBox textAuthors;
        public System.Windows.Forms.TabPage license;
        public System.Windows.Forms.TextBox textLicense;
        private System.Windows.Forms.TableLayoutPanel buttons;
        public System.Windows.Forms.Button buttonClose;
    }
}