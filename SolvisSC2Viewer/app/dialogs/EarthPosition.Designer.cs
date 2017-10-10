namespace SolvisSC2Viewer {
    partial class EarthPosition {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EarthPosition));
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.group = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupLayout.SuspendLayout();
            this.group.SuspendLayout();
            this.buttons.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLayout
            // 
            resources.ApplyResources(this.groupLayout, "groupLayout");
            this.groupLayout.Controls.Add(this.longitudeLabel, 0, 0);
            this.groupLayout.Controls.Add(this.longitudeTextBox, 1, 0);
            this.groupLayout.Controls.Add(this.latitudeLabel, 0, 1);
            this.groupLayout.Controls.Add(this.latitudeTextBox, 1, 1);
            this.groupLayout.Name = "groupLayout";
            // 
            // longitudeLabel
            // 
            resources.ApplyResources(this.longitudeLabel, "longitudeLabel");
            this.longitudeLabel.Name = "longitudeLabel";
            // 
            // longitudeTextBox
            // 
            resources.ApplyResources(this.longitudeTextBox, "longitudeTextBox");
            this.longitudeTextBox.Name = "longitudeTextBox";
            // 
            // latitudeLabel
            // 
            resources.ApplyResources(this.latitudeLabel, "latitudeLabel");
            this.latitudeLabel.Name = "latitudeLabel";
            // 
            // latitudeTextBox
            // 
            resources.ApplyResources(this.latitudeTextBox, "latitudeTextBox");
            this.latitudeTextBox.Name = "latitudeTextBox";
            // 
            // group
            // 
            resources.ApplyResources(this.group, "group");
            this.group.Controls.Add(this.groupLayout);
            this.group.Name = "group";
            this.group.TabStop = false;
            // 
            // buttons
            // 
            resources.ApplyResources(this.buttons, "buttons");
            this.buttons.Controls.Add(this.buttonOK, 0, 0);
            this.buttons.Controls.Add(this.buttonCancel, 1, 0);
            this.buttons.Name = "buttons";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dialogLayout
            // 
            resources.ApplyResources(this.dialogLayout, "dialogLayout");
            this.dialogLayout.Controls.Add(this.group, 0, 0);
            this.dialogLayout.Controls.Add(this.buttons, 0, 1);
            this.dialogLayout.Name = "dialogLayout";
            // 
            // EarthPosition
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EarthPosition";
            this.ShowInTaskbar = false;
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.TextBox latitudeTextBox;

    }
}