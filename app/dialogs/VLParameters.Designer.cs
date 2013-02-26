namespace SolvisSC2Viewer {
    partial class VLParameters {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLParameters));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.group = new System.Windows.Forms.GroupBox();
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.temperatureUpDown = new System.Windows.Forms.NumericUpDown();
            this.niveauLabel = new System.Windows.Forms.Label();
            this.niveauUpDown = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel = new System.Windows.Forms.Label();
            this.gradientUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.dialogLayout.SuspendLayout();
            this.group.SuspendLayout();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).BeginInit();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
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
            // group
            // 
            resources.ApplyResources(this.group, "group");
            this.group.Controls.Add(this.groupLayout);
            this.group.Name = "group";
            this.group.TabStop = false;
            // 
            // groupLayout
            // 
            resources.ApplyResources(this.groupLayout, "groupLayout");
            this.groupLayout.Controls.Add(this.temperatureLabel, 0, 0);
            this.groupLayout.Controls.Add(this.temperatureUpDown, 1, 0);
            this.groupLayout.Controls.Add(this.niveauLabel, 0, 1);
            this.groupLayout.Controls.Add(this.niveauUpDown, 1, 1);
            this.groupLayout.Controls.Add(this.gradientLabel, 0, 2);
            this.groupLayout.Controls.Add(this.gradientUpDown, 1, 2);
            this.groupLayout.Name = "groupLayout";
            // 
            // temperatureLabel
            // 
            resources.ApplyResources(this.temperatureLabel, "temperatureLabel");
            this.temperatureLabel.MinimumSize = new System.Drawing.Size(69, 0);
            this.temperatureLabel.Name = "temperatureLabel";
            // 
            // temperatureUpDown
            // 
            resources.ApplyResources(this.temperatureUpDown, "temperatureUpDown");
            this.temperatureUpDown.Name = "temperatureUpDown";
            this.temperatureUpDown.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // niveauLabel
            // 
            resources.ApplyResources(this.niveauLabel, "niveauLabel");
            this.niveauLabel.Name = "niveauLabel";
            // 
            // niveauUpDown
            // 
            resources.ApplyResources(this.niveauUpDown, "niveauUpDown");
            this.niveauUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.niveauUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.niveauUpDown.Name = "niveauUpDown";
            // 
            // gradientLabel
            // 
            resources.ApplyResources(this.gradientLabel, "gradientLabel");
            this.gradientLabel.Name = "gradientLabel";
            // 
            // gradientUpDown
            // 
            resources.ApplyResources(this.gradientUpDown, "gradientUpDown");
            this.gradientUpDown.DecimalPlaces = 2;
            this.gradientUpDown.Name = "gradientUpDown";
            // 
            // buttons
            // 
            resources.ApplyResources(this.buttons, "buttons");
            this.buttons.Controls.Add(this.buttonOK, 0, 0);
            this.buttons.Controls.Add(this.buttonCancel, 1, 0);
            this.buttons.Name = "buttons";
            // 
            // VLParameters
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VLParameters";
            this.ShowInTaskbar = false;
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niveauUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).EndInit();
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.NumericUpDown temperatureUpDown;
        private System.Windows.Forms.Label niveauLabel;
        private System.Windows.Forms.NumericUpDown niveauUpDown;
        private System.Windows.Forms.Label gradientLabel;
        private System.Windows.Forms.NumericUpDown gradientUpDown;
    }
}