namespace SolvisSC2Viewer {
    partial class S17Dialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S17Dialog));
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.heatCapacityText = new System.Windows.Forms.TextBox();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.pulseUpDown = new System.Windows.Forms.NumericUpDown();
            this.heatCapacityLabel = new System.Windows.Forms.Label();
            this.editLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pulseUpDown)).BeginInit();
            this.group.SuspendLayout();
            this.buttons.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLayout
            // 
            resources.ApplyResources(this.groupLayout, "groupLayout");
            this.groupLayout.Controls.Add(this.heatCapacityText, 1, 1);
            this.groupLayout.Controls.Add(this.pulseLabel, 0, 0);
            this.groupLayout.Controls.Add(this.pulseUpDown, 1, 0);
            this.groupLayout.Controls.Add(this.heatCapacityLabel, 0, 1);
            this.groupLayout.Controls.Add(this.editLabel, 0, 2);
            this.groupLayout.Controls.Add(this.editButton, 1, 2);
            this.groupLayout.Name = "groupLayout";
            // 
            // heatCapacityText
            // 
            resources.ApplyResources(this.heatCapacityText, "heatCapacityText");
            this.heatCapacityText.Name = "heatCapacityText";
            this.heatCapacityText.TextChanged += new System.EventHandler(this.heatCapacityText_TextChanged);
            // 
            // pulseLabel
            // 
            resources.ApplyResources(this.pulseLabel, "pulseLabel");
            this.pulseLabel.MinimumSize = new System.Drawing.Size(69, 0);
            this.pulseLabel.Name = "pulseLabel";
            // 
            // pulseUpDown
            // 
            resources.ApplyResources(this.pulseUpDown, "pulseUpDown");
            this.pulseUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pulseUpDown.Name = "pulseUpDown";
            this.pulseUpDown.Value = new decimal(new int[] {
            42,
            0,
            0,
            0});
            // 
            // heatCapacityLabel
            // 
            resources.ApplyResources(this.heatCapacityLabel, "heatCapacityLabel");
            this.heatCapacityLabel.Name = "heatCapacityLabel";
            // 
            // editLabel
            // 
            resources.ApplyResources(this.editLabel, "editLabel");
            this.editLabel.Name = "editLabel";
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
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
            // S17Dialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "S17Dialog";
            this.ShowInTaskbar = false;
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pulseUpDown)).EndInit();
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
        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.NumericUpDown pulseUpDown;
        private System.Windows.Forms.Label heatCapacityLabel;
        private System.Windows.Forms.TextBox heatCapacityText;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label editLabel;
    }
}