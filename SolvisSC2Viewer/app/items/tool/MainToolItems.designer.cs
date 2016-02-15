namespace SolvisSC2Viewer {
    partial class MainToolItems {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainToolItems));
            this.open = new System.Windows.Forms.ToolStripButton();
            this.print = new System.Windows.Forms.ToolStripButton();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fromLabelDateTime = new System.Windows.Forms.ToolStripLabel();
            this.toLabelDateTime = new System.Windows.Forms.ToolStripLabel();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.firstDay = new System.Windows.Forms.ToolStripButton();
            this.previousDay = new System.Windows.Forms.ToolStripButton();
            this.nextDay = new System.Windows.Forms.ToolStripButton();
            this.lastDay = new System.Windows.Forms.ToolStripButton();
            this.separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.crosshair = new System.Windows.Forms.ToolStripButton();
            this.separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.previousFile = new System.Windows.Forms.ToolStripButton();
            this.nextFile = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Name = "open";
            resources.ApplyResources(this.open, "open");
            // 
            // print
            // 
            this.print.Name = "print";
            resources.ApplyResources(this.print, "print");
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            resources.ApplyResources(this.separator1, "separator1");
            // 
            // fromLabelDateTime
            // 
            this.fromLabelDateTime.Name = "fromLabelDateTime";
            resources.ApplyResources(this.fromLabelDateTime, "fromLabelDateTime");
            // 
            // toLabelDateTime
            // 
            this.toLabelDateTime.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toLabelDateTime.Name = "toLabelDateTime";
            resources.ApplyResources(this.toLabelDateTime, "toLabelDateTime");
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            resources.ApplyResources(this.separator2, "separator2");
            // 
            // firstDay
            // 
            this.firstDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.firstDay, "firstDay");
            this.firstDay.Margin = new System.Windows.Forms.Padding(16, 1, 0, 2);
            this.firstDay.Name = "firstDay";
            // 
            // previousDay
            // 
            this.previousDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.previousDay, "previousDay");
            this.previousDay.Name = "previousDay";
            // 
            // nextDay
            // 
            this.nextDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.nextDay, "nextDay");
            this.nextDay.Name = "nextDay";
            // 
            // lastDay
            // 
            this.lastDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.lastDay, "lastDay");
            this.lastDay.Name = "lastDay";
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            resources.ApplyResources(this.separator3, "separator3");
            // 
            // crosshair
            // 
            this.crosshair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.crosshair, "crosshair");
            this.crosshair.Margin = new System.Windows.Forms.Padding(16, 1, 0, 2);
            this.crosshair.Name = "crosshair";
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            resources.ApplyResources(this.separator4, "separator4");
            // 
            // previousFile
            // 
            this.previousFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.previousFile, "previousFile");
            this.previousFile.Name = "previousFile";
            // 
            // nextFile
            // 
            this.nextFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.nextFile, "nextFile");
            this.nextFile.Name = "nextFile";
            // 
            // MainToolItems
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.print,
            this.separator1,
            this.fromLabelDateTime,
            this.toLabelDateTime,
            this.separator2,
            this.firstDay,
            this.previousDay,
            this.nextDay,
            this.lastDay,
            this.separator3,
            this.previousFile,
            this.nextFile,
            this.separator4,
            this.crosshair});
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton print;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripLabel fromLabelDateTime;
        private System.Windows.Forms.ToolStripLabel toLabelDateTime;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripButton firstDay;
        private System.Windows.Forms.ToolStripButton previousDay;
        private System.Windows.Forms.ToolStripButton nextDay;
        private System.Windows.Forms.ToolStripButton lastDay;
        private System.Windows.Forms.ToolStripSeparator separator3;
        private System.Windows.Forms.ToolStripButton crosshair;
        private System.Windows.Forms.ToolStripSeparator separator4;
        private System.Windows.Forms.ToolStripButton previousFile;
        private System.Windows.Forms.ToolStripButton nextFile;
    }
}
