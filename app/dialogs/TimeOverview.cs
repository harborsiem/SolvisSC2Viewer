using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SolvisSC2Viewer {
    public partial class TimeOverview : BaseForm {
        private const int Gap = 42;
        private const int DayOffset = 6;
        private const string TimeRaster = "Zeitfenster";
        private const int Days = 7;
        private const int TimeRasters = 3;
        private const int TimeItems = 6;
        private static readonly string[] Names = { "HK1", "HK2", "HK3", "Zirk", "WW", "SDLad" };
        private static readonly string[] FromTo = { "von", "bis" };
        private FileToInt32List zeitPlan;

        public TimeOverview() {
            InitializeComponent();
            float factor = CreateGraphics().DpiX / 96;
            this.dataGridViewTop.RowHeadersWidth = (int)(this.dataGridViewTop.RowHeadersWidth * factor);
            InitTopDgv();
            InitBottomDgv();
        }

        public SuppressMask SuppressMask {
            get;
            set;
        }

        public bool SaveFormBitmap {
            get;
            set;
        }

        public FileToInt32List TimePlan {
            get { return zeitPlan; }
            set { zeitPlan = value; }
        }

        protected override void OnLoad(EventArgs e) {
            FillTimeValues();
            base.OnLoad(e);
        }

        private void InitTopDgv() {
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).BeginInit();
            DataGridView dgv = dataGridViewTop;
            dgv.RowCount = 1;
            DataGridViewRow dgvRow = dgv.Rows[0];
            for (int i = 0; i < Days; i++) {
                dgvRow.Cells[i].Value = TimeRaster;
            }
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).EndInit();
        }

        private void InitBottomDgv() {
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).BeginInit();
            DataGridView dgv = dataGridViewBottom;
            dgv.RowCount = TimeItems * 2; //On and Off
            for (int j = 0; j < Names.Length * 2; j++) {
                DataGridViewRow dgvRow = dgv.Rows[j];
                dgvRow.Cells[0].Value = Names[j / 2];
                dgvRow.Cells[1].Value = FromTo[j % 2];
            }
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).EndInit();
        }

        private void FillTimeValues() {
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).BeginInit();
            if (zeitPlan != null && !zeitPlan.Empty) {
                IList<int> list = zeitPlan.ParamList;
                for (int i = 0; i < TimeItems; i++) {
                    if (((1 << i) & (int)SuppressMask) != 0) { //evtl. HK2, HK3, Speicher Durchladung ausblenden
                        continue;
                    }
                    DataGridViewRow dgvRow1 = dataGridViewBottom.Rows[i * 2];
                    DataGridViewRow dgvRow2 = dataGridViewBottom.Rows[i * 2 + 1];
                    int k = i * Gap;
                    for (int j = 0; j < Days * TimeRasters; j++) {
                        dgvRow1.Cells[j + 2].Value = GetTimeString(list[j * 2 + k]);
                        dgvRow2.Cells[j + 2].Value = GetTimeString(list[j * 2 + k + 1]);
                    }
                }
            }
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottom)).EndInit();
        }

        private string GetTimeString(int value) {
            return (new DateTime((long)value * 15 * 60 * 10000000)).ToString("HH:mm");
        }

        private void TimeOverview_Shown(object sender, EventArgs e) {
            if (SaveFormBitmap) {
                FormToBitmap();
            }
        }

        private void FormToBitmap() {
            Bitmap map = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(map, new Rectangle(0, 0, this.Width, this.Height));
            map.Save(Path.Combine(ConfigManager.ConfigDir, "TimeOverview.png"), ImageFormat.Png);
        }
    }
}
