namespace SolvisSC2Viewer {
    partial class TimeOverview {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeOverview));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTop = new System.Windows.Forms.DataGridView();
            this.dataGridViewBottom = new System.Windows.Forms.DataGridView();
            this.ItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromToColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaturdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SundayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialogLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogLayout
            // 
            resources.ApplyResources(this.dialogLayout, "dialogLayout");
            this.dialogLayout.Controls.Add(this.dataGridViewTop, 0, 0);
            this.dialogLayout.Controls.Add(this.dataGridViewBottom, 0, 1);
            this.dialogLayout.Name = "dialogLayout";
            // 
            // dataGridViewTop
            // 
            resources.ApplyResources(this.dataGridViewTop, "dataGridViewTop");
            this.dataGridViewTop.AllowUserToAddRows = false;
            this.dataGridViewTop.AllowUserToDeleteRows = false;
            this.dataGridViewTop.AllowUserToResizeColumns = false;
            this.dataGridViewTop.AllowUserToResizeRows = false;
            this.dataGridViewTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MondayColumn,
            this.TuesdayColumn,
            this.WednesdayColumn,
            this.ThursdayColumn,
            this.FridayColumn,
            this.SaturdayColumn,
            this.SundayColumn});
            this.dataGridViewTop.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTop.Name = "dataGridViewTop";
            this.dataGridViewTop.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTop.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            // 
            // dataGridViewBottom
            // 
            resources.ApplyResources(this.dataGridViewBottom, "dataGridViewBottom");
            this.dataGridViewBottom.AllowUserToAddRows = false;
            this.dataGridViewBottom.AllowUserToDeleteRows = false;
            this.dataGridViewBottom.AllowUserToResizeColumns = false;
            this.dataGridViewBottom.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewBottom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBottom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBottom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBottom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemColumn,
            this.FromToColumn,
            this.Monday1,
            this.Monday2,
            this.Monday3,
            this.Tuesday1,
            this.Tuesday2,
            this.Tuesday3,
            this.Wednesday1,
            this.Wednesday2,
            this.Wednesday3,
            this.Thursday1,
            this.Thursday2,
            this.Thursday3,
            this.Friday1,
            this.Friday2,
            this.Friday3,
            this.Saturday1,
            this.Saturday2,
            this.Saturday3,
            this.Sunday1,
            this.Sunday2,
            this.Sunday3});
            this.dataGridViewBottom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewBottom.MultiSelect = false;
            this.dataGridViewBottom.Name = "dataGridViewBottom";
            this.dataGridViewBottom.ReadOnly = true;
            this.dataGridViewBottom.RowHeadersVisible = false;
            this.dataGridViewBottom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewBottom.RowTemplate.Height = 24;
            this.dataGridViewBottom.RowTemplate.ReadOnly = true;
            this.dataGridViewBottom.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ItemColumn
            // 
            resources.ApplyResources(this.ItemColumn, "ItemColumn");
            this.ItemColumn.Name = "ItemColumn";
            this.ItemColumn.ReadOnly = true;
            this.ItemColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FromToColumn
            // 
            resources.ApplyResources(this.FromToColumn, "FromToColumn");
            this.FromToColumn.Name = "FromToColumn";
            this.FromToColumn.ReadOnly = true;
            this.FromToColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Monday1
            // 
            resources.ApplyResources(this.Monday1, "Monday1");
            this.Monday1.Name = "Monday1";
            this.Monday1.ReadOnly = true;
            this.Monday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Monday2
            // 
            resources.ApplyResources(this.Monday2, "Monday2");
            this.Monday2.Name = "Monday2";
            this.Monday2.ReadOnly = true;
            this.Monday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Monday3
            // 
            resources.ApplyResources(this.Monday3, "Monday3");
            this.Monday3.Name = "Monday3";
            this.Monday3.ReadOnly = true;
            this.Monday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuesday1
            // 
            resources.ApplyResources(this.Tuesday1, "Tuesday1");
            this.Tuesday1.Name = "Tuesday1";
            this.Tuesday1.ReadOnly = true;
            this.Tuesday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuesday2
            // 
            resources.ApplyResources(this.Tuesday2, "Tuesday2");
            this.Tuesday2.Name = "Tuesday2";
            this.Tuesday2.ReadOnly = true;
            this.Tuesday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuesday3
            // 
            resources.ApplyResources(this.Tuesday3, "Tuesday3");
            this.Tuesday3.Name = "Tuesday3";
            this.Tuesday3.ReadOnly = true;
            this.Tuesday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Wednesday1
            // 
            resources.ApplyResources(this.Wednesday1, "Wednesday1");
            this.Wednesday1.Name = "Wednesday1";
            this.Wednesday1.ReadOnly = true;
            this.Wednesday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Wednesday2
            // 
            resources.ApplyResources(this.Wednesday2, "Wednesday2");
            this.Wednesday2.Name = "Wednesday2";
            this.Wednesday2.ReadOnly = true;
            this.Wednesday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Wednesday3
            // 
            resources.ApplyResources(this.Wednesday3, "Wednesday3");
            this.Wednesday3.Name = "Wednesday3";
            this.Wednesday3.ReadOnly = true;
            this.Wednesday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Thursday1
            // 
            resources.ApplyResources(this.Thursday1, "Thursday1");
            this.Thursday1.Name = "Thursday1";
            this.Thursday1.ReadOnly = true;
            this.Thursday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Thursday2
            // 
            resources.ApplyResources(this.Thursday2, "Thursday2");
            this.Thursday2.Name = "Thursday2";
            this.Thursday2.ReadOnly = true;
            this.Thursday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Thursday3
            // 
            resources.ApplyResources(this.Thursday3, "Thursday3");
            this.Thursday3.Name = "Thursday3";
            this.Thursday3.ReadOnly = true;
            this.Thursday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Friday1
            // 
            resources.ApplyResources(this.Friday1, "Friday1");
            this.Friday1.Name = "Friday1";
            this.Friday1.ReadOnly = true;
            this.Friday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Friday2
            // 
            resources.ApplyResources(this.Friday2, "Friday2");
            this.Friday2.Name = "Friday2";
            this.Friday2.ReadOnly = true;
            this.Friday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Friday3
            // 
            resources.ApplyResources(this.Friday3, "Friday3");
            this.Friday3.Name = "Friday3";
            this.Friday3.ReadOnly = true;
            this.Friday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Saturday1
            // 
            resources.ApplyResources(this.Saturday1, "Saturday1");
            this.Saturday1.Name = "Saturday1";
            this.Saturday1.ReadOnly = true;
            this.Saturday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Saturday2
            // 
            resources.ApplyResources(this.Saturday2, "Saturday2");
            this.Saturday2.Name = "Saturday2";
            this.Saturday2.ReadOnly = true;
            this.Saturday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Saturday3
            // 
            resources.ApplyResources(this.Saturday3, "Saturday3");
            this.Saturday3.Name = "Saturday3";
            this.Saturday3.ReadOnly = true;
            this.Saturday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sunday1
            // 
            resources.ApplyResources(this.Sunday1, "Sunday1");
            this.Sunday1.Name = "Sunday1";
            this.Sunday1.ReadOnly = true;
            this.Sunday1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sunday2
            // 
            resources.ApplyResources(this.Sunday2, "Sunday2");
            this.Sunday2.Name = "Sunday2";
            this.Sunday2.ReadOnly = true;
            this.Sunday2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sunday3
            // 
            resources.ApplyResources(this.Sunday3, "Sunday3");
            this.Sunday3.Name = "Sunday3";
            this.Sunday3.ReadOnly = true;
            this.Sunday3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MondayColumn
            // 
            resources.ApplyResources(this.MondayColumn, "MondayColumn");
            this.MondayColumn.Name = "MondayColumn";
            this.MondayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TuesdayColumn
            // 
            resources.ApplyResources(this.TuesdayColumn, "TuesdayColumn");
            this.TuesdayColumn.Name = "TuesdayColumn";
            this.TuesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WednesdayColumn
            // 
            resources.ApplyResources(this.WednesdayColumn, "WednesdayColumn");
            this.WednesdayColumn.Name = "WednesdayColumn";
            this.WednesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ThursdayColumn
            // 
            resources.ApplyResources(this.ThursdayColumn, "ThursdayColumn");
            this.ThursdayColumn.Name = "ThursdayColumn";
            this.ThursdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FridayColumn
            // 
            resources.ApplyResources(this.FridayColumn, "FridayColumn");
            this.FridayColumn.Name = "FridayColumn";
            this.FridayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SaturdayColumn
            // 
            resources.ApplyResources(this.SaturdayColumn, "SaturdayColumn");
            this.SaturdayColumn.Name = "SaturdayColumn";
            this.SaturdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SundayColumn
            // 
            resources.ApplyResources(this.SundayColumn, "SundayColumn");
            this.SundayColumn.Name = "SundayColumn";
            this.SundayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeOverview
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeOverview";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.TimeOverview_Shown);
            this.dialogLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.DataGridView dataGridViewTop;
        private System.Windows.Forms.DataGridView dataGridViewBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromToColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WednesdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FridayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaturdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SundayColumn;
    }
}