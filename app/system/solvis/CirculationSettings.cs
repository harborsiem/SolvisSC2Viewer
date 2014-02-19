using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace SolvisSC2Viewer {
    public class CirculationSettings {

        public const string CategoryCirc = "Zirkular";

        public CirculationSettings(IList<int> list) {
            Title = HeatingSettings.Titlevalue;
            CircOffTime = list[326].ToString() + Unit.Minute;
            CircPump = (Mode)list[327];
            CircCommandTemperature = list[328].ToString() + Unit.DegreeCelsius;
            CircMode = (CircMode)list[329];
            CircDeltaForOn = list[330].ToString() + Unit.Kelvin;
            CircMinRuntime = list[332].ToString() + Unit.Second;
        }

        [DisplayName("Zirkulation Parameter")]
        [Category(CategoryCirc)]
        public string Title { get; set; }

        [DisplayName("Zirkulations Betriebsart")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public CircMode CircMode { get; set; }

        [DisplayName("Zirkulationspumpe")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public Mode CircPump { get; set; }

        [DisplayName("Zirkulationstemp.SOLL")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircCommandTemperature { get; set; }

        [DisplayName("Zirk. Laufzeit")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string CircMinRuntime { get; set; }

        [DisplayName("Zirk. Ruhezeit")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircOffTime { get; set; }

        [DisplayName("Zirk. Differenz ein")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryCirc)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircDeltaForOn { get; set; }
    }
}
