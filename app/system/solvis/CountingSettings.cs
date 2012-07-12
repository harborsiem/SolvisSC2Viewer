using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SolvisSC2Viewer {
    class CountingSettings {
        public CountingSettings(IList<int> list) {
            SolarPumpSpan = list[0];
            BurnerSpan = list[1];
            BurnerStarts = list[2];
            //@Todo: 3 weitere Werte: Bedeutung ?
            DontKnow1 = list[3];
            DontKnow2 = list[4];
            DontKnow3 = list[5];
        }

        [DisplayName("Laufzeit Solarpumpe")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int SolarPumpSpan { get; set; }

        [DisplayName("Laufzeit Brenner")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int BurnerSpan { get; set; }

        [DisplayName("Starts Brenner")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int BurnerStarts { get; set; }

        [DisplayName("Keine Ahnung 1")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int DontKnow1 { get; set; }

        [DisplayName("Keine Ahnung 2")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int DontKnow2 { get; set; }

        [DisplayName("Keine Ahnung 3")]
        [Category("Counting")]
        [ReadOnly(true)]
        public int DontKnow3 { get; set; }
    }
}
