namespace SolvisSC2Viewer {
    partial class BurnerPower {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BurnerPower));
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.minPowerLabel = new System.Windows.Forms.Label();
            this.minUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxPowerLabel = new System.Windows.Forms.Label();
            this.maxUpDown = new System.Windows.Forms.NumericUpDown();
            this.group = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).BeginInit();
            this.group.SuspendLayout();
            this.buttons.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLayout
            // 
            resources.ApplyResources(this.groupLayout, "groupLayout");
            this.groupLayout.Controls.Add(this.minPowerLabel, 0, 0);
            this.groupLayout.Controls.Add(this.minUpDown, 1, 0);
            this.groupLayout.Controls.Add(this.maxPowerLabel, 0, 1);
            this.groupLayout.Controls.Add(this.maxUpDown, 1, 1);
            this.groupLayout.Name = "groupLayout";
            // 
            // minPowerLabel
            // 
            resources.ApplyResources(this.minPowerLabel, "minPowerLabel");
            this.minPowerLabel.Name = "minPowerLabel";
            // 
            // minUpDown
            // 
            resources.ApplyResources(this.minUpDown, "minUpDown");
            this.minUpDown.Name = "minUpDown";
            // 
            // maxPowerLabel
            // 
            resources.ApplyResources(this.maxPowerLabel, "maxPowerLabel");
            this.maxPowerLabel.Name = "maxPowerLabel";
            // 
            // maxUpDown
            // 
            resources.ApplyResources(this.maxUpDown, "maxUpDown");
            this.maxUpDown.Name = "maxUpDown";
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
            // BurnerPower
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BurnerPower";
            this.ShowInTaskbar = false;
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.NumericUpDown maxUpDown;
        private System.Windows.Forms.NumericUpDown minUpDown;
        private System.Windows.Forms.Label minPowerLabel;
        private System.Windows.Forms.Label maxPowerLabel;
    }
}