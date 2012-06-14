using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolvisSC2Viewer {
    internal class CheckBoxTag {
        public Series Series { get; private set; }
        public GroupIdent Ident { get; private set; }
        public int Index { get; private set; }
        public CheckBox CheckBox { get; private set; }
        public string ConfigKey { get; private set; }

        public CheckBoxTag(Series series, GroupIdent ident, int index, CheckBox checkBox, string configKey) {
            Series = series;
            Ident = ident;
            Index = index;
            CheckBox = checkBox;
            ConfigKey = configKey;
        }
    }
}
