namespace SolvisSC2Viewer {
    partial class MainMenu {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.fileMenu = new SolvisSC2Viewer.FileMenuItem();
            this.extrasMenu = new SolvisSC2Viewer.ExtrasMenuItem();
            this.helpMenu = new SolvisSC2Viewer.HelpMenuItem();
            this.SuspendLayout();
            // 
            // fileMenu
            // 
            resources.ApplyResources(this.fileMenu, "fileMenu");
            this.fileMenu.Name = "fileMenu";
            // 
            // extrasMenu
            // 
            resources.ApplyResources(this.extrasMenu, "extrasMenu");
            this.extrasMenu.Name = "extrasMenu";
            // 
            // helpMenu
            // 
            resources.ApplyResources(this.helpMenu, "helpMenu");
            this.helpMenu.Name = "helpMenu";
            // 
            // MainMenu
            // 
            resources.ApplyResources(this, "$this");
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.extrasMenu,
            this.helpMenu});
            this.TabStop = true;
            this.ResumeLayout(false);

        }

        #endregion

        private FileMenuItem fileMenu;
        private ExtrasMenuItem extrasMenu;
        private HelpMenuItem helpMenu;
    }
}
