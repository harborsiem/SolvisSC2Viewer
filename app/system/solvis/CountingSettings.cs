using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SolvisSC2Viewer {
    class CountingSettings {
        private const string Hours = " Std.";

        public CountingSettings(IList<int> list) {
            SolarPumpSpan = list[0].ToString() + Hours;
            BurnerSpan = list[1].ToString() + Hours;
            BurnerStarts = list[2];
            //@Todo: 3 weitere Werte: Bedeutung ?
            Unknown1 = list[3];
            Unknown2 = list[4];
            Unknown3 = list[5];
        }

        [DisplayName("Laufzeit Solarpumpe")]
        [Category("Counting")]
        [ReadOnly(true)]
        public string SolarPumpSpan { get; set; }

        [DisplayName("Laufzeit Brenner")]
        [Category("Counting")]
        [ReadOnly(true)]
        public string BurnerSpan { get; set; }

        [DisplayName("Starts Brenner")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int BurnerStarts { get; set; }

        [DisplayName("Unbekannt 1")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int Unknown1 { get; set; }

        [DisplayName("Unbekannt 2")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int Unknown2 { get; set; }

        [DisplayName("Unbekannt 3")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int Unknown3 { get; set; }
    }
}
