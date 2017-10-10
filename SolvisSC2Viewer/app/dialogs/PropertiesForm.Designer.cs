namespace SolvisSC2Viewer {
    partial class PropertiesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesForm));
            this.heatingPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.printHeadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // heatingPropertyGrid
            // 
            resources.ApplyResources(this.heatingPropertyGrid, "heatingPropertyGrid");
            this.heatingPropertyGrid.Name = "heatingPropertyGrid";
            this.heatingPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.heatingPropertyGrid.ToolbarVisible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printHeadItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // printHeadItem
            // 
            this.printHeadItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewItem,
            this.printItem});
            this.printHeadItem.Name = "printHeadItem";
            resources.ApplyResources(this.printHeadItem, "printHeadItem");
            // 
            // printPreviewItem
            // 
            this.printPreviewItem.Name = "printPreviewItem";
            resources.ApplyResources(this.printPreviewItem, "printPreviewItem");
            this.printPreviewItem.Click += new System.EventHandler(this.printPreviewItem_Click);
            // 
            // printItem
            // 
            this.printItem.Name = "printItem";
            resources.ApplyResources(this.printItem, "printItem");
            this.printItem.Click += new System.EventHandler(this.printItem_Click);
            // 
            // PropertiesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heatingPropertyGrid);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid heatingPropertyGrid;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem printHeadItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewItem;
        private System.Windows.Forms.ToolStripMenuItem printItem;
    }
}

