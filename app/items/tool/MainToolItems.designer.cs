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
            this.previousWeek = new System.Windows.Forms.ToolStripButton();
            this.previousDay = new System.Windows.Forms.ToolStripButton();
            this.nextDay = new System.Windows.Forms.ToolStripButton();
            this.nextWeek = new System.Windows.Forms.ToolStripButton();
            this.lastDay = new System.Windows.Forms.ToolStripButton();
            this.separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // open
            // 
            resources.ApplyResources(this.open, "open");
            this.open.Name = "open";
            // 
            // print
            // 
            resources.ApplyResources(this.print, "print");
            this.print.Name = "print";
            // 
            // separator1
            // 
            resources.ApplyResources(this.separator1, "separator1");
            this.separator1.Name = "separator1";
            // 
            // fromLabelDateTime
            // 
            resources.ApplyResources(this.fromLabelDateTime, "fromLabelDateTime");
            this.fromLabelDateTime.Name = "fromLabelDateTime";
            // 
            // toLabelDateTime
            // 
            resources.ApplyResources(this.toLabelDateTime, "toLabelDateTime");
            this.toLabelDateTime.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toLabelDateTime.Name = "toLabelDateTime";
            // 
            // separator2
            // 
            resources.ApplyResources(this.separator2, "separator2");
            this.separator2.Name = "separator2";
            // 
            // firstDay
            // 
            resources.ApplyResources(this.firstDay, "firstDay");
            this.firstDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstDay.Margin = new System.Windows.Forms.Padding(16, 1, 0, 2);
            this.firstDay.Name = "firstDay";
            // 
            // previousWeek
            // 
            resources.ApplyResources(this.previousWeek, "previousWeek");
            this.previousWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousWeek.Name = "previousWeek";
            // 
            // previousDay
            // 
            resources.ApplyResources(this.previousDay, "previousDay");
            this.previousDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousDay.Name = "previousDay";
            // 
            // nextDay
            // 
            resources.ApplyResources(this.nextDay, "nextDay");
            this.nextDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextDay.Name = "nextDay";
            // 
            // nextWeek
            // 
            resources.ApplyResources(this.nextWeek, "nextWeek");
            this.nextWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextWeek.Name = "nextWeek";
            // 
            // lastDay
            // 
            resources.ApplyResources(this.lastDay, "lastDay");
            this.lastDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastDay.Name = "lastDay";
            // 
            // separator3
            // 
            resources.ApplyResources(this.separator3, "separator3");
            this.separator3.Name = "separator3";
            // 
            // MainToolItems
            // 
            resources.ApplyResources(this, "$this");
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.print,
            this.separator1,
            this.fromLabelDateTime,
            this.toLabelDateTime,
            this.separator2,
            this.firstDay,
            this.previousWeek,
            this.previousDay,
            this.nextDay,
            this.nextWeek,
            this.lastDay,
            this.separator3});
            this.TabStop = false;
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
        private System.Windows.Forms.ToolStripButton previousWeek;
        private System.Windows.Forms.ToolStripButton previousDay;
        private System.Windows.Forms.ToolStripButton nextDay;
        private System.Windows.Forms.ToolStripButton nextWeek;
        private System.Windows.Forms.ToolStripButton lastDay;
        private System.Windows.Forms.ToolStripSeparator separator3;
    }
}
