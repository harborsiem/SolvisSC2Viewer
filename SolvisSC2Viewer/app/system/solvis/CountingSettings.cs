using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SolvisSC2Viewer {
    public class CountingSettings {

        public const string CategoryCount = "Counting";

        public CountingSettings(IList<int> list) {
            SolarPumpSpan = list[0].ToString() + Unit.Hours;
            BurnerSpan = list[1].ToString() + Unit.Hours;
            BurnerStarts = list[2];
            //@Todo: 3 weitere Werte: Bedeutung ?
            Value4 = list[3];
            Value5 = list[4];
            Value6 = list[5];
        }

        [DisplayName("Laufzeit Solarpumpe")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public string SolarPumpSpan { get; set; }

        [DisplayName("Laufzeit Brenner")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public string BurnerSpan { get; set; }

        [DisplayName("Starts Brenner")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public int BurnerStarts { get; set; }

        [DisplayName("Wert 4")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public int Value4 { get; set; }

        [DisplayName("Wert 5")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public int Value5 { get; set; }

        [DisplayName("Wert 6")]
        [Category(CategoryCount)]
        [ReadOnly(true)]
        public int Value6 { get; set; }
    }
}
