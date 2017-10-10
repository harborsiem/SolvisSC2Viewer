namespace SolvisSC2Viewer {
    partial class ExtrasMenuItem {
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtrasMenuItem));
            this.heatCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sensorsCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.sdCardInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.counterList = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.configEditor = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // heatCurve
            // 
            this.heatCurve.Name = "heatCurve";
            resources.ApplyResources(this.heatCurve, "heatCurve");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // sensorsCheck
            // 
            this.sensorsCheck.Name = "sensorsCheck";
            resources.ApplyResources(this.sensorsCheck, "sensorsCheck");
            // 
            // sdCardInfo
            // 
            this.sdCardInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeTable,
            this.counterList,
            this.parameterList});
            this.sdCardInfo.Name = "sdCardInfo";
            resources.ApplyResources(this.sdCardInfo, "sdCardInfo");
            // 
            // timeTable
            // 
            this.timeTable.Name = "timeTable";
            resources.ApplyResources(this.timeTable, "timeTable");
            // 
            // counterList
            // 
            this.counterList.Name = "counterList";
            resources.ApplyResources(this.counterList, "counterList");
            // 
            // parameterList
            // 
            this.parameterList.Name = "parameterList";
            resources.ApplyResources(this.parameterList, "parameterList");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // configEditor
            // 
            this.configEditor.Name = "configEditor";
            resources.ApplyResources(this.configEditor, "configEditor");
            // 
            // ExtrasMenuItem
            // 
            this.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heatCurve,
            this.toolStripSeparator1,
            this.sensorsCheck,
            this.sdCardInfo,
            this.toolStripSeparator2,
            this.configEditor});
            resources.ApplyResources(this, "$this");

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem heatCurve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sensorsCheck;
        private System.Windows.Forms.ToolStripMenuItem sdCardInfo;
        private System.Windows.Forms.ToolStripMenuItem timeTable;
        private System.Windows.Forms.ToolStripMenuItem counterList;
        private System.Windows.Forms.ToolStripMenuItem parameterList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem configEditor;
    }
}
