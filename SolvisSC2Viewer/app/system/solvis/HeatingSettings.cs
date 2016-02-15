using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace SolvisSC2Viewer {
    public class HeatingSettings {

        public const string CategoryHeating = "Heizung";
        public const string CategoryModulation = "Heizung Modulation";
        public const string Fachnutzer = "Einstellbar durch Fachnutzer";
        public const string Installateur = "Einstellbar durch Installateur";
        public const string Titlevalue = "--------";

        //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)
        //Zirkular Index: Ruhezeit: 326, Funkt. Ein :327, Temp: 328, Betriebsart: 329, Diff Ein: 330, Laufzeit: 332,
        //Wasser Index: Temp: 45, NachheizL. : 58, dT Start: 59, dt Ende: 60
        //Solar Index: Max. Koll.Temp.: 3 usw.
        //Temp.Sensor Korrekturwerte Index: ab 164 ? S10 ist auf 173
        //Eco Betrieb: ab Index: 359, 4 Werte ?
        //Index 372 bis 374: Checksum ?

        public HeatingSettings(IList<int> list) {
            Title = HeatingSettings.Titlevalue;
            //Gebläsedrehzahl (index = 108 ?) mit Formel %-Wert für Brenner Stufe 2 ?

            //Burner2Start = list[113].ToString() + Kelvin;
            //Burner2Stop = list[114].ToString() + Kelvin;
            //ModulationTMin = list[115].ToString() + DegreeCelsius;
            //ModulationVMin = (list[116] / 10.0).ToString("f1") + Volt;
            //ModulationTMax = list[117].ToString() + DegreeCelsius;
            //ModulationVMax = (list[118] / 10.0).ToString("f1") + Volt;
            //EcoWater = list[359].ToString() + DegreeCelsius;
            //EcoHC1Temperature = list[360].ToString() + DegreeCelsius;
            //EcoHC2Temperature = list[361].ToString() + DegreeCelsius;
            //EcoHC3Temperature = list[362].ToString() + DegreeCelsius;
        }


        [DisplayName("Heizung Parameter")]
        [Category(CategoryHeating)]
        public string Title { get; set; }

        //[DisplayName("Brenner 2 Start")]
        //[Description(Installateur)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string Burner2Start { get; set; }

        //[DisplayName("Brenner 2 Stop")]
        //[Description(Installateur)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string Burner2Stop { get; set; }

        //[DisplayName("Modulation T Min")]
        //[Description(Installateur)]
        //[Category(CategoryModulation)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationTMin { get; set; }

        //[DisplayName("Modulation V Min")]
        //[Description(Installateur)]
        //[Category(CategoryModulation)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationVMin { get; set; }

        //[DisplayName("Modulation T Max")]
        //[Description(Installateur)]
        //[Category(CategoryModulation)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationTMax { get; set; }

        //[DisplayName("Modulation V Max")]
        //[Description(Installateur)]
        //[Category(CategoryModulation)]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationVMax { get; set; }

        //[DisplayName("Eco Warmwasser Temp.")]
        //[Description(Fachnutzer)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoWater { get; set; }

        //[DisplayName("Eco Heizkreis 1 Temperatur")]
        //[Description(Fachnutzer)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoHC1Temperature { get; set; }

        //[DisplayName("Eco Heizkreis 2 Temperatur")]
        //[Description(Fachnutzer)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoHC2Temperature { get; set; }

        //[DisplayName("Eco Heizkreis 3 Temperatur")]
        //[Description(Fachnutzer)]
        //[Category(CategoryHeating)]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoHC3Temperature { get; set; }

    }
}
