﻿namespace SolvisSC2Viewer {
    partial class ConfigEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditor));
            this.sensorsTabPage = new System.Windows.Forms.TabPage();
            this.sensorsTabLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sensorsListBox = new System.Windows.Forms.ListBox();
            this.sensorsTextLabel = new System.Windows.Forms.Label();
            this.sensorsToolTipLabel = new System.Windows.Forms.Label();
            this.sensorsColorlabel = new System.Windows.Forms.Label();
            this.sensorsVisibleLabel = new System.Windows.Forms.Label();
            this.sensorsTextBox = new System.Windows.Forms.TextBox();
            this.sensorsToolTipTextBox = new System.Windows.Forms.TextBox();
            this.sensorsColorButton = new System.Windows.Forms.Button();
            this.sensorsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.sensorsParameterLabel = new System.Windows.Forms.Label();
            this.sensorsParameterButton = new System.Windows.Forms.Button();
            this.actorsTabPage = new System.Windows.Forms.TabPage();
            this.actorsTabLayout = new System.Windows.Forms.TableLayoutPanel();
            this.actorsListBox = new System.Windows.Forms.ListBox();
            this.actorsTextLabel = new System.Windows.Forms.Label();
            this.actorsToolTipLabel = new System.Windows.Forms.Label();
            this.actorsColorlabel = new System.Windows.Forms.Label();
            this.actorsVisibleLabel = new System.Windows.Forms.Label();
            this.actorsTextBox = new System.Windows.Forms.TextBox();
            this.actorsToolTipTextBox = new System.Windows.Forms.TextBox();
            this.actorsColorButton = new System.Windows.Forms.Button();
            this.actorsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsTabPage = new System.Windows.Forms.TabPage();
            this.optionsTabLayout = new System.Windows.Forms.TableLayoutPanel();
            this.optionsListBox = new System.Windows.Forms.ListBox();
            this.optionsTextLabel = new System.Windows.Forms.Label();
            this.optionsToolTipLabel = new System.Windows.Forms.Label();
            this.optionsColorlabel = new System.Windows.Forms.Label();
            this.optionsVisibleLabel = new System.Windows.Forms.Label();
            this.optionsTextBox = new System.Windows.Forms.TextBox();
            this.optionsToolTipTextBox = new System.Windows.Forms.TextBox();
            this.optionsColorButton = new System.Windows.Forms.Button();
            this.optionsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.parameterLabel = new System.Windows.Forms.Label();
            this.parameterButton = new System.Windows.Forms.Button();
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.temperatureUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelUpDown = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel = new System.Windows.Forms.Label();
            this.gradientUpDown = new System.Windows.Forms.NumericUpDown();
            this.heatingCurveGroup = new System.Windows.Forms.GroupBox();
            this.heatingCurveTabPage = new System.Windows.Forms.TabPage();
            this.directoryButton = new System.Windows.Forms.Button();
            this.timeTableGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.hk2CheckBox = new System.Windows.Forms.CheckBox();
            this.hk3CheckBox = new System.Windows.Forms.CheckBox();
            this.ecoCheckBox = new System.Windows.Forms.CheckBox();
            this.savePictureCheckBox = new System.Windows.Forms.CheckBox();
            this.timeTableGroup = new System.Windows.Forms.GroupBox();
            this.prototype = new System.Windows.Forms.CheckBox();
            this.sdCardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SdCardTabPage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.othersTabPage = new System.Windows.Forms.TabPage();
            this.miscLayout = new System.Windows.Forms.TableLayoutPanel();
            this.controlVersionLabel = new System.Windows.Forms.Label();
            this.controlVersionUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sensorsTabPage.SuspendLayout();
            this.sensorsTabLayout.SuspendLayout();
            this.actorsTabPage.SuspendLayout();
            this.actorsTabLayout.SuspendLayout();
            this.optionsTabPage.SuspendLayout();
            this.optionsTabLayout.SuspendLayout();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).BeginInit();
            this.heatingCurveGroup.SuspendLayout();
            this.heatingCurveTabPage.SuspendLayout();
            this.timeTableGroupLayout.SuspendLayout();
            this.timeTableGroup.SuspendLayout();
            this.sdCardLayout.SuspendLayout();
            this.SdCardTabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.othersTabPage.SuspendLayout();
            this.miscLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlVersionUpDown)).BeginInit();
            this.buttons.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // sensorsTabPage
            // 
            resources.ApplyResources(this.sensorsTabPage, "sensorsTabPage");
            this.sensorsTabPage.Controls.Add(this.sensorsTabLayout);
            this.sensorsTabPage.Name = "sensorsTabPage";
            this.sensorsTabPage.UseVisualStyleBackColor = true;
            // 
            // sensorsTabLayout
            // 
            resources.ApplyResources(this.sensorsTabLayout, "sensorsTabLayout");
            this.sensorsTabLayout.Controls.Add(this.sensorsListBox, 0, 0);
            this.sensorsTabLayout.Controls.Add(this.sensorsTextLabel, 2, 0);
            this.sensorsTabLayout.Controls.Add(this.sensorsToolTipLabel, 2, 1);
            this.sensorsTabLayout.Controls.Add(this.sensorsColorlabel, 2, 2);
            this.sensorsTabLayout.Controls.Add(this.sensorsVisibleLabel, 2, 3);
            this.sensorsTabLayout.Controls.Add(this.sensorsTextBox, 3, 0);
            this.sensorsTabLayout.Controls.Add(this.sensorsToolTipTextBox, 3, 1);
            this.sensorsTabLayout.Controls.Add(this.sensorsColorButton, 3, 2);
            this.sensorsTabLayout.Controls.Add(this.sensorsVisibleCheckBox, 3, 3);
            this.sensorsTabLayout.Controls.Add(this.sensorsParameterLabel, 2, 4);
            this.sensorsTabLayout.Controls.Add(this.sensorsParameterButton, 3, 4);
            this.sensorsTabLayout.Name = "sensorsTabLayout";
            // 
            // sensorsListBox
            // 
            resources.ApplyResources(this.sensorsListBox, "sensorsListBox");
            this.sensorsListBox.FormattingEnabled = true;
            this.sensorsListBox.Name = "sensorsListBox";
            this.sensorsTabLayout.SetRowSpan(this.sensorsListBox, 6);
            // 
            // sensorsTextLabel
            // 
            resources.ApplyResources(this.sensorsTextLabel, "sensorsTextLabel");
            this.sensorsTextLabel.Name = "sensorsTextLabel";
            // 
            // sensorsToolTipLabel
            // 
            resources.ApplyResources(this.sensorsToolTipLabel, "sensorsToolTipLabel");
            this.sensorsToolTipLabel.Name = "sensorsToolTipLabel";
            // 
            // sensorsColorlabel
            // 
            resources.ApplyResources(this.sensorsColorlabel, "sensorsColorlabel");
            this.sensorsColorlabel.Name = "sensorsColorlabel";
            // 
            // sensorsVisibleLabel
            // 
            resources.ApplyResources(this.sensorsVisibleLabel, "sensorsVisibleLabel");
            this.sensorsVisibleLabel.Name = "sensorsVisibleLabel";
            // 
            // sensorsTextBox
            // 
            resources.ApplyResources(this.sensorsTextBox, "sensorsTextBox");
            this.sensorsTextBox.Name = "sensorsTextBox";
            this.sensorsTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // sensorsToolTipTextBox
            // 
            resources.ApplyResources(this.sensorsToolTipTextBox, "sensorsToolTipTextBox");
            this.sensorsToolTipTextBox.Name = "sensorsToolTipTextBox";
            this.sensorsToolTipTextBox.TextChanged += new System.EventHandler(this.ToolTipTextBox_TextChanged);
            // 
            // sensorsColorButton
            // 
            resources.ApplyResources(this.sensorsColorButton, "sensorsColorButton");
            this.sensorsColorButton.Name = "sensorsColorButton";
            this.sensorsColorButton.UseVisualStyleBackColor = true;
            this.sensorsColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // sensorsVisibleCheckBox
            // 
            resources.ApplyResources(this.sensorsVisibleCheckBox, "sensorsVisibleCheckBox");
            this.sensorsVisibleCheckBox.Name = "sensorsVisibleCheckBox";
            this.sensorsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.sensorsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleCheckBox_CheckedChanged);
            // 
            // sensorsParameterLabel
            // 
            resources.ApplyResources(this.sensorsParameterLabel, "sensorsParameterLabel");
            this.sensorsParameterLabel.Name = "sensorsParameterLabel";
            // 
            // sensorsParameterButton
            // 
            resources.ApplyResources(this.sensorsParameterButton, "sensorsParameterButton");
            this.sensorsParameterButton.Name = "sensorsParameterButton";
            this.sensorsParameterButton.UseVisualStyleBackColor = true;
            this.sensorsParameterButton.Click += new System.EventHandler(this.parameterButton_Click);
            // 
            // actorsTabPage
            // 
            resources.ApplyResources(this.actorsTabPage, "actorsTabPage");
            this.actorsTabPage.Controls.Add(this.actorsTabLayout);
            this.actorsTabPage.Name = "actorsTabPage";
            this.actorsTabPage.UseVisualStyleBackColor = true;
            // 
            // actorsTabLayout
            // 
            resources.ApplyResources(this.actorsTabLayout, "actorsTabLayout");
            this.actorsTabLayout.Controls.Add(this.actorsListBox, 0, 0);
            this.actorsTabLayout.Controls.Add(this.actorsTextLabel, 2, 0);
            this.actorsTabLayout.Controls.Add(this.actorsToolTipLabel, 2, 1);
            this.actorsTabLayout.Controls.Add(this.actorsColorlabel, 2, 2);
            this.actorsTabLayout.Controls.Add(this.actorsVisibleLabel, 2, 3);
            this.actorsTabLayout.Controls.Add(this.actorsTextBox, 3, 0);
            this.actorsTabLayout.Controls.Add(this.actorsToolTipTextBox, 3, 1);
            this.actorsTabLayout.Controls.Add(this.actorsColorButton, 3, 2);
            this.actorsTabLayout.Controls.Add(this.actorsVisibleCheckBox, 3, 3);
            this.actorsTabLayout.Name = "actorsTabLayout";
            // 
            // actorsListBox
            // 
            resources.ApplyResources(this.actorsListBox, "actorsListBox");
            this.actorsListBox.FormattingEnabled = true;
            this.actorsListBox.Name = "actorsListBox";
            this.actorsTabLayout.SetRowSpan(this.actorsListBox, 5);
            // 
            // actorsTextLabel
            // 
            resources.ApplyResources(this.actorsTextLabel, "actorsTextLabel");
            this.actorsTextLabel.Name = "actorsTextLabel";
            // 
            // actorsToolTipLabel
            // 
            resources.ApplyResources(this.actorsToolTipLabel, "actorsToolTipLabel");
            this.actorsToolTipLabel.Name = "actorsToolTipLabel";
            // 
            // actorsColorlabel
            // 
            resources.ApplyResources(this.actorsColorlabel, "actorsColorlabel");
            this.actorsColorlabel.Name = "actorsColorlabel";
            // 
            // actorsVisibleLabel
            // 
            resources.ApplyResources(this.actorsVisibleLabel, "actorsVisibleLabel");
            this.actorsVisibleLabel.Name = "actorsVisibleLabel";
            // 
            // actorsTextBox
            // 
            resources.ApplyResources(this.actorsTextBox, "actorsTextBox");
            this.actorsTextBox.Name = "actorsTextBox";
            this.actorsTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // actorsToolTipTextBox
            // 
            resources.ApplyResources(this.actorsToolTipTextBox, "actorsToolTipTextBox");
            this.actorsToolTipTextBox.Name = "actorsToolTipTextBox";
            this.actorsToolTipTextBox.TextChanged += new System.EventHandler(this.ToolTipTextBox_TextChanged);
            // 
            // actorsColorButton
            // 
            resources.ApplyResources(this.actorsColorButton, "actorsColorButton");
            this.actorsColorButton.Name = "actorsColorButton";
            this.actorsColorButton.UseVisualStyleBackColor = true;
            this.actorsColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // actorsVisibleCheckBox
            // 
            resources.ApplyResources(this.actorsVisibleCheckBox, "actorsVisibleCheckBox");
            this.actorsVisibleCheckBox.Name = "actorsVisibleCheckBox";
            this.actorsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.actorsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleCheckBox_CheckedChanged);
            // 
            // optionsTabPage
            // 
            resources.ApplyResources(this.optionsTabPage, "optionsTabPage");
            this.optionsTabPage.Controls.Add(this.optionsTabLayout);
            this.optionsTabPage.Name = "optionsTabPage";
            this.optionsTabPage.UseVisualStyleBackColor = true;
            // 
            // optionsTabLayout
            // 
            resources.ApplyResources(this.optionsTabLayout, "optionsTabLayout");
            this.optionsTabLayout.Controls.Add(this.optionsListBox, 0, 0);
            this.optionsTabLayout.Controls.Add(this.optionsTextLabel, 2, 0);
            this.optionsTabLayout.Controls.Add(this.optionsToolTipLabel, 2, 1);
            this.optionsTabLayout.Controls.Add(this.optionsColorlabel, 2, 2);
            this.optionsTabLayout.Controls.Add(this.optionsVisibleLabel, 2, 3);
            this.optionsTabLayout.Controls.Add(this.optionsTextBox, 3, 0);
            this.optionsTabLayout.Controls.Add(this.optionsToolTipTextBox, 3, 1);
            this.optionsTabLayout.Controls.Add(this.optionsColorButton, 3, 2);
            this.optionsTabLayout.Controls.Add(this.optionsVisibleCheckBox, 3, 3);
            this.optionsTabLayout.Controls.Add(this.parameterLabel, 2, 4);
            this.optionsTabLayout.Controls.Add(this.parameterButton, 3, 4);
            this.optionsTabLayout.Name = "optionsTabLayout";
            // 
            // optionsListBox
            // 
            resources.ApplyResources(this.optionsListBox, "optionsListBox");
            this.optionsListBox.FormattingEnabled = true;
            this.optionsListBox.Name = "optionsListBox";
            this.optionsTabLayout.SetRowSpan(this.optionsListBox, 6);
            // 
            // optionsTextLabel
            // 
            resources.ApplyResources(this.optionsTextLabel, "optionsTextLabel");
            this.optionsTextLabel.Name = "optionsTextLabel";
            // 
            // optionsToolTipLabel
            // 
            resources.ApplyResources(this.optionsToolTipLabel, "optionsToolTipLabel");
            this.optionsToolTipLabel.Name = "optionsToolTipLabel";
            // 
            // optionsColorlabel
            // 
            resources.ApplyResources(this.optionsColorlabel, "optionsColorlabel");
            this.optionsColorlabel.Name = "optionsColorlabel";
            // 
            // optionsVisibleLabel
            // 
            resources.ApplyResources(this.optionsVisibleLabel, "optionsVisibleLabel");
            this.optionsVisibleLabel.Name = "optionsVisibleLabel";
            // 
            // optionsTextBox
            // 
            resources.ApplyResources(this.optionsTextBox, "optionsTextBox");
            this.optionsTextBox.Name = "optionsTextBox";
            this.optionsTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // optionsToolTipTextBox
            // 
            resources.ApplyResources(this.optionsToolTipTextBox, "optionsToolTipTextBox");
            this.optionsToolTipTextBox.Name = "optionsToolTipTextBox";
            this.optionsToolTipTextBox.TextChanged += new System.EventHandler(this.ToolTipTextBox_TextChanged);
            // 
            // optionsColorButton
            // 
            resources.ApplyResources(this.optionsColorButton, "optionsColorButton");
            this.optionsColorButton.Name = "optionsColorButton";
            this.optionsColorButton.UseVisualStyleBackColor = true;
            this.optionsColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // optionsVisibleCheckBox
            // 
            resources.ApplyResources(this.optionsVisibleCheckBox, "optionsVisibleCheckBox");
            this.optionsVisibleCheckBox.Name = "optionsVisibleCheckBox";
            this.optionsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.optionsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleCheckBox_CheckedChanged);
            // 
            // parameterLabel
            // 
            resources.ApplyResources(this.parameterLabel, "parameterLabel");
            this.parameterLabel.Name = "parameterLabel";
            // 
            // parameterButton
            // 
            resources.ApplyResources(this.parameterButton, "parameterButton");
            this.parameterButton.Name = "parameterButton";
            this.parameterButton.UseVisualStyleBackColor = true;
            this.parameterButton.Click += new System.EventHandler(this.parameterButton_Click);
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
            // heatingCurveGroup
            // 
            resources.ApplyResources(this.heatingCurveGroup, "heatingCurveGroup");
            this.heatingCurveGroup.Controls.Add(this.groupLayout);
            this.heatingCurveGroup.Name = "heatingCurveGroup";
            this.heatingCurveGroup.TabStop = false;
            // 
            // heatingCurveTabPage
            // 
            resources.ApplyResources(this.heatingCurveTabPage, "heatingCurveTabPage");
            this.heatingCurveTabPage.Controls.Add(this.heatingCurveGroup);
            this.heatingCurveTabPage.Name = "heatingCurveTabPage";
            this.heatingCurveTabPage.UseVisualStyleBackColor = true;
            // 
            // directoryButton
            // 
            resources.ApplyResources(this.directoryButton, "directoryButton");
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // timeTableGroupLayout
            // 
            resources.ApplyResources(this.timeTableGroupLayout, "timeTableGroupLayout");
            this.timeTableGroupLayout.Controls.Add(this.hk2CheckBox, 0, 0);
            this.timeTableGroupLayout.Controls.Add(this.hk3CheckBox, 0, 1);
            this.timeTableGroupLayout.Controls.Add(this.ecoCheckBox, 0, 2);
            this.timeTableGroupLayout.Controls.Add(this.savePictureCheckBox, 0, 3);
            this.timeTableGroupLayout.Name = "timeTableGroupLayout";
            // 
            // hk2CheckBox
            // 
            resources.ApplyResources(this.hk2CheckBox, "hk2CheckBox");
            this.hk2CheckBox.Name = "hk2CheckBox";
            this.hk2CheckBox.UseVisualStyleBackColor = true;
            // 
            // hk3CheckBox
            // 
            resources.ApplyResources(this.hk3CheckBox, "hk3CheckBox");
            this.hk3CheckBox.Name = "hk3CheckBox";
            this.hk3CheckBox.UseVisualStyleBackColor = true;
            // 
            // ecoCheckBox
            // 
            resources.ApplyResources(this.ecoCheckBox, "ecoCheckBox");
            this.ecoCheckBox.Name = "ecoCheckBox";
            this.ecoCheckBox.UseVisualStyleBackColor = true;
            // 
            // savePictureCheckBox
            // 
            resources.ApplyResources(this.savePictureCheckBox, "savePictureCheckBox");
            this.savePictureCheckBox.Name = "savePictureCheckBox";
            this.savePictureCheckBox.UseVisualStyleBackColor = true;
            // 
            // timeTableGroup
            // 
            resources.ApplyResources(this.timeTableGroup, "timeTableGroup");
            this.timeTableGroup.Controls.Add(this.timeTableGroupLayout);
            this.timeTableGroup.Name = "timeTableGroup";
            this.timeTableGroup.TabStop = false;
            // 
            // prototype
            // 
            resources.ApplyResources(this.prototype, "prototype");
            this.sdCardLayout.SetColumnSpan(this.prototype, 2);
            this.prototype.Name = "prototype";
            this.prototype.UseVisualStyleBackColor = true;
            this.prototype.CheckedChanged += new System.EventHandler(this.prototype_CheckedChanged);
            // 
            // sdCardLayout
            // 
            resources.ApplyResources(this.sdCardLayout, "sdCardLayout");
            this.sdCardLayout.Controls.Add(this.directoryButton, 0, 0);
            this.sdCardLayout.Controls.Add(this.timeTableGroup, 0, 1);
            this.sdCardLayout.Controls.Add(this.prototype, 0, 2);
            this.sdCardLayout.Name = "sdCardLayout";
            // 
            // SdCardTabPage
            // 
            resources.ApplyResources(this.SdCardTabPage, "SdCardTabPage");
            this.SdCardTabPage.Controls.Add(this.sdCardLayout);
            this.SdCardTabPage.Name = "SdCardTabPage";
            this.SdCardTabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.sensorsTabPage);
            this.tabControl.Controls.Add(this.actorsTabPage);
            this.tabControl.Controls.Add(this.optionsTabPage);
            this.tabControl.Controls.Add(this.heatingCurveTabPage);
            this.tabControl.Controls.Add(this.SdCardTabPage);
            this.tabControl.Controls.Add(this.othersTabPage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // othersTabPage
            // 
            resources.ApplyResources(this.othersTabPage, "othersTabPage");
            this.othersTabPage.Controls.Add(this.miscLayout);
            this.othersTabPage.Name = "othersTabPage";
            this.othersTabPage.UseVisualStyleBackColor = true;
            // 
            // miscLayout
            // 
            resources.ApplyResources(this.miscLayout, "miscLayout");
            this.miscLayout.Controls.Add(this.controlVersionLabel, 0, 0);
            this.miscLayout.Controls.Add(this.controlVersionUpDown, 1, 0);
            this.miscLayout.Name = "miscLayout";
            // 
            // controlVersionLabel
            // 
            resources.ApplyResources(this.controlVersionLabel, "controlVersionLabel");
            this.controlVersionLabel.Name = "controlVersionLabel";
            // 
            // controlVersionUpDown
            // 
            resources.ApplyResources(this.controlVersionUpDown, "controlVersionUpDown");
            this.controlVersionUpDown.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.controlVersionUpDown.Minimum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.controlVersionUpDown.Name = "controlVersionUpDown";
            this.controlVersionUpDown.Value = new decimal(new int[] {
            131,
            0,
            0,
            0});
            // 
            // buttons
            // 
            resources.ApplyResources(this.buttons, "buttons");
            this.buttons.Controls.Add(this.buttonDefault, 0, 0);
            this.buttons.Controls.Add(this.buttonOK, 1, 0);
            this.buttons.Controls.Add(this.buttonCancel, 2, 0);
            this.buttons.Name = "buttons";
            // 
            // buttonDefault
            // 
            resources.ApplyResources(this.buttonDefault, "buttonDefault");
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
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
            this.dialogLayout.Controls.Add(this.tabControl, 0, 0);
            this.dialogLayout.Controls.Add(this.buttons, 0, 1);
            this.dialogLayout.Name = "dialogLayout";
            // 
            // ConfigEditor
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigEditor";
            this.ShowInTaskbar = false;
            this.sensorsTabPage.ResumeLayout(false);
            this.sensorsTabPage.PerformLayout();
            this.sensorsTabLayout.ResumeLayout(false);
            this.sensorsTabLayout.PerformLayout();
            this.actorsTabPage.ResumeLayout(false);
            this.actorsTabPage.PerformLayout();
            this.actorsTabLayout.ResumeLayout(false);
            this.actorsTabLayout.PerformLayout();
            this.optionsTabPage.ResumeLayout(false);
            this.optionsTabPage.PerformLayout();
            this.optionsTabLayout.ResumeLayout(false);
            this.optionsTabLayout.PerformLayout();
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientUpDown)).EndInit();
            this.heatingCurveGroup.ResumeLayout(false);
            this.heatingCurveGroup.PerformLayout();
            this.heatingCurveTabPage.ResumeLayout(false);
            this.heatingCurveTabPage.PerformLayout();
            this.timeTableGroupLayout.ResumeLayout(false);
            this.timeTableGroupLayout.PerformLayout();
            this.timeTableGroup.ResumeLayout(false);
            this.timeTableGroup.PerformLayout();
            this.sdCardLayout.ResumeLayout(false);
            this.sdCardLayout.PerformLayout();
            this.SdCardTabPage.ResumeLayout(false);
            this.SdCardTabPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.othersTabPage.ResumeLayout(false);
            this.othersTabPage.PerformLayout();
            this.miscLayout.ResumeLayout(false);
            this.miscLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlVersionUpDown)).EndInit();
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage sensorsTabPage;
        private System.Windows.Forms.TableLayoutPanel sensorsTabLayout;
        private System.Windows.Forms.ListBox sensorsListBox;
        private System.Windows.Forms.Label sensorsTextLabel;
        private System.Windows.Forms.Label sensorsToolTipLabel;
        private System.Windows.Forms.Label sensorsColorlabel;
        private System.Windows.Forms.Label sensorsVisibleLabel;
        private System.Windows.Forms.TextBox sensorsTextBox;
        private System.Windows.Forms.TextBox sensorsToolTipTextBox;
        private System.Windows.Forms.Button sensorsColorButton;
        private System.Windows.Forms.CheckBox sensorsVisibleCheckBox;
        private System.Windows.Forms.TabPage actorsTabPage;
        private System.Windows.Forms.TableLayoutPanel actorsTabLayout;
        private System.Windows.Forms.ListBox actorsListBox;
        private System.Windows.Forms.Label actorsTextLabel;
        private System.Windows.Forms.Label actorsToolTipLabel;
        private System.Windows.Forms.Label actorsColorlabel;
        private System.Windows.Forms.Label actorsVisibleLabel;
        private System.Windows.Forms.TextBox actorsTextBox;
        private System.Windows.Forms.TextBox actorsToolTipTextBox;
        private System.Windows.Forms.Button actorsColorButton;
        private System.Windows.Forms.CheckBox actorsVisibleCheckBox;
        private System.Windows.Forms.TabPage optionsTabPage;
        private System.Windows.Forms.TableLayoutPanel optionsTabLayout;
        private System.Windows.Forms.ListBox optionsListBox;
        private System.Windows.Forms.Label optionsTextLabel;
        private System.Windows.Forms.Label optionsToolTipLabel;
        private System.Windows.Forms.Label optionsColorlabel;
        private System.Windows.Forms.Label optionsVisibleLabel;
        private System.Windows.Forms.TextBox optionsTextBox;
        private System.Windows.Forms.TextBox optionsToolTipTextBox;
        private System.Windows.Forms.Button optionsColorButton;
        private System.Windows.Forms.CheckBox optionsVisibleCheckBox;
        private System.Windows.Forms.TabPage heatingCurveTabPage;
        private System.Windows.Forms.GroupBox heatingCurveGroup;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.NumericUpDown temperatureUpDown;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.NumericUpDown levelUpDown;
        private System.Windows.Forms.Label gradientLabel;
        private System.Windows.Forms.NumericUpDown gradientUpDown;
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label parameterLabel;
        private System.Windows.Forms.Button parameterButton;
        private System.Windows.Forms.TabPage SdCardTabPage;
        private System.Windows.Forms.TableLayoutPanel sdCardLayout;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.GroupBox timeTableGroup;
        private System.Windows.Forms.TableLayoutPanel timeTableGroupLayout;
        private System.Windows.Forms.CheckBox savePictureCheckBox;
        private System.Windows.Forms.CheckBox ecoCheckBox;
        private System.Windows.Forms.CheckBox hk2CheckBox;
        private System.Windows.Forms.CheckBox hk3CheckBox;
        private System.Windows.Forms.Label sensorsParameterLabel;
        private System.Windows.Forms.Button sensorsParameterButton;
        private System.Windows.Forms.CheckBox prototype;
        private System.Windows.Forms.TabPage othersTabPage;
        private System.Windows.Forms.TableLayoutPanel miscLayout;
        private System.Windows.Forms.Label controlVersionLabel;
        private System.Windows.Forms.NumericUpDown controlVersionUpDown;
    }
}