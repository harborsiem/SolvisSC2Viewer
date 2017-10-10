using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace SolvisSC2Viewer {
    public class CounterSettings {

        public const string CategoryCounter = "Counter";

        public CounterSettings(IList<int> list) {
            SolarPumpSpan = list[0].ToString(CultureInfo.CurrentCulture) + Unit.Hours;
            BurnerSpan = list[1].ToString(CultureInfo.CurrentCulture) + Unit.Hours;
            BurnerStarts = list[2];
            //@Todo: 3 weitere Werte: Bedeutung ?
            Value4 = list[3];
            Value5 = list[4];
            Value6 = list[5];
        }

        [DisplayName("Laufzeit Solarpumpe")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public string SolarPumpSpan { get; set; }

        [DisplayName("Laufzeit Brenner")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public string BurnerSpan { get; set; }

        [DisplayName("Starts Brenner")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public int BurnerStarts { get; set; }

        [DisplayName("Wert 4")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public int Value4 { get; set; }

        [DisplayName("Wert 5")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public int Value5 { get; set; }

        [DisplayName("Wert 6")]
        [Category(CategoryCounter)]
        [ReadOnly(true)]
        public int Value6 { get; set; }
    }
}
