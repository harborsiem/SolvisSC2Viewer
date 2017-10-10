namespace SolvisSC2Viewer {
    partial class FlowParameters {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlowParameters));
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.temperatureUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelUpDown = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel = new System.Windows.Forms.Label();
            this.gradientUpDown = new System.Windows.Forms.NumericUpDown();
            this.group = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).BeginInit();
            this.group.SuspendLayout();
            this.buttons.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLayout
            // 
            resources.ApplyResources(this.groupLayout, "groupLayout");
            this.groupLayout.Controls.Add(this.temperatureLabel, 0, 0);
            this.groupLayout.Controls.Add(this.temperatureUpDown, 1, 0);
            this.groupLayout.Controls.Add(this.levelLabel, 0, 1);
            this.groupLayout.Controls.Add(this.levelUpDown, 1, 1);
            this.groupLayout.Controls.Add(this.gradientLabel, 0, 2);
            this.groupLayout.Controls.Add(this.gradientUpDown, 1, 2);
            this.groupLayout.Name = "groupLayout";
            // 
            // temperatureLabel
            // 
            resources.ApplyResources(this.temperatureLabel, "temperatureLabel");
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
            // levelLabel
            // 
            resources.ApplyResources(this.levelLabel, "levelLabel");
            this.levelLabel.Name = "levelLabel";
            // 
            // levelUpDown
            // 
            resources.ApplyResources(this.levelUpDown, "levelUpDown");
            this.levelUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.levelUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.levelUpDown.Name = "levelUpDown";
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
            // FlowParameters
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlowParameters";
            this.ShowInTaskbar = false;
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.NumericUpDown temperatureUpDown;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.NumericUpDown levelUpDown;
        private System.Windows.Forms.Label gradientLabel;
        private System.Windows.Forms.NumericUpDown gradientUpDown;
    }
}