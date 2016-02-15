namespace SolvisSC2Viewer {
    partial class HelpMenuItem {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpMenuItem));
            this.doc = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // doc
            // 
            this.doc.Name = "doc";
            resources.ApplyResources(this.doc, "doc");
            // 
            // about
            // 
            this.about.Name = "about";
            resources.ApplyResources(this.about, "about");
            // 
            // HelpMenuItem
            // 
            this.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doc,
            this.about});
            resources.ApplyResources(this, "$this");

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem doc;
        private System.Windows.Forms.ToolStripMenuItem about;
    }
}
