using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace SolvisSC2Viewer {
    class HeatSettings {

        //@Todo: Viele der unten aufgelisteten Properties als string definieren
        // Dann kann auch die Einheit im string enthalten sein.

        public HeatSettings(IList<int> list, int index) {
            HeatMode = (HeatMode)list[index++];
            FixVLDay = list[index++];
            FixVLDown = list[index++];
            Temperature1 = list[index++];
            Temperature2 = list[index++];
            Temperature3 = list[index++];
            TemperatureDown = list[index++];
            Gradient = list[index++] / 100.0;
            RaisingSetpoint = list[index++]; //? Einschaltüberhöhung
            RoomEffect = list[index++]; // ? Raumeinfluss
            RateTime = list[index++];
            TemperatureMax = list[index++];
            TemperatureMin = list[index++];
            Offset = list[index++];
            Niveau = list[index++];
            S10MeanTime = list[index++];
            RoomShutDown = (OnOffSwitch)list[index++];
            RoomHysterese = list[index++];
            OutDoorDayShutDown = (OnOffSwitch)list[index++];
            OutDoorDayTemperature = list[index++];
            OutDoorDayHysterese = list[index++];
            OutDoorNightShutDown = (OnOffSwitch)list[index++];
            OutDoorNightTemperature = list[index++];
            OutDoorNightHysterese = list[index++];

            index += 2;

            FreezeTemperature = list[index++];
            RoomTemperature = list[index++];
            MixerTime = list[index++];
            MixerInterval = list[index++];
            MixerFactor = list[index++] / 10.0;

            CircOffTime = list[326];
            CircPump = (Mode)list[327];
            CircCommandTemperature = list[328];
            CircMode = (CircMode)list[329];
            CircDeltaForOn = list[330];
            CircRuntime = list[332];

            WaterTemp = list[45];
            WaterPower = list[58];
            WaterDTStart = list[59];
            WaterDTEnd = list[60];
        }

        //Beginn: HK1 = 187; HK2 = 233; HK3 = 279 
        //Zirkular Index: Ruhezeit: 326, Funkt. Ein :327, Temp: 328, Betriebsart: 329 (Auto = 3), Diff Ein: 330, Laufzeit: 332,
        //Wasser Index: Temp: 45, NachheizL. : 58, dT Start: 59, dt Ende: 60
        //Solar Index: Max. Koll.Temp.: 3 usw.
        //Temp.Sensor Korrekturwerte Index: ab 164 ? S10 ist auf 173

        [DisplayName("Wasser Sollwert")]
        [Category("Wasser")]
        [ReadOnly(true)]
        public int WaterTemp { get; set; }

        [DisplayName("Wasser Nachheizleistung")]
        [Category("Wasser")]
        [ReadOnly(true)]
        public int WaterPower { get; set; }

        [DisplayName("Wasser dT Start")]
        [Category("Wasser")]
        [ReadOnly(true)]
        public int WaterDTStart { get; set; }

        [DisplayName("Wasser dT Ende")]
        [Category("Wasser")]
        [ReadOnly(true)]
        public int WaterDTEnd { get; set; }

        [DisplayName("Zirkulations Betriebsart")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public CircMode CircMode { get; set; }

        [DisplayName("Zirk. Ruhezeit")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public int CircOffTime { get; set; }

        [DisplayName("Zirkulationspumpe")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public Mode CircPump { get; set; }

        [DisplayName("Zirkulationstemp.SOLL")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public int CircCommandTemperature { get; set; }

        [DisplayName("Zirk. Differenz ein")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public int CircDeltaForOn { get; set; }

        [DisplayName("Zirk. Laufzeit")]
        [Category("Zirkular")]
        [ReadOnly(true)]
        public int CircRuntime { get; set; }

        //[DisplayName("Warmwasser-Vorrang")]
        ////[Description("Warmwasser-Vorrang")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public WaterMode WaterPriority { get; set; }

        //[DisplayName("Betriebsart Heizkreis")]
        ////[Description("Betriebsart Heizkreis")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public Mode ModeHK { get; set; }

        [DisplayName("Betriebsart VL Temp.")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public HeatMode HeatMode { get; set; }

        [DisplayName("Fix Vorlauf Tag")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int FixVLDay { get; set; }

        [DisplayName("Fix Vorlauf Absenk")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int FixVLDown { get; set; }

        [DisplayName("Steilheit")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public double Gradient { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 1")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int Temperature1 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 2")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int Temperature2 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 3")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int Temperature3 { get; set; }

        [DisplayName("Absenk-Temperatur")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int TemperatureDown { get; set; }

        [DisplayName("Einschaltüberhöhung HK")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int RaisingSetpoint { get; set; }

        [DisplayName("Raumeinfluss HK")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int RoomEffect { get; set; }

        [DisplayName("Vorhaltezeit HK")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int RateTime { get; set; }

        [DisplayName("Max. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int TemperatureMax { get; set; }

        [DisplayName("Min. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int TemperatureMin { get; set; }

        [DisplayName("Offset")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int Offset { get; set; }

        [DisplayName("Heizung Wippe")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int Niveau { get; set; }

        [DisplayName("Mittelwertzeitraum")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int S10MeanTime { get; set; }

        [DisplayName("Abschaltbedingung wenn Raum-Solltemp. erreicht ist")]
        [Category("Raum-Solltemp.")]
        [ReadOnly(true)]
        public OnOffSwitch RoomShutDown { get; set; }

        [DisplayName("Raum Temp. Hysterese")]
        [Category("Raum-Solltemp.")]
        [ReadOnly(true)]
        public int RoomHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Tagbetrieb größer als max. Außentemp")]
        [Category("Tagbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public OnOffSwitch OutDoorDayShutDown { get; set; }

        [DisplayName("Max. Außentemp. Tagbetrieb")]
        [Category("Tagbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public int OutDoorDayTemperature { get; set; }

        [DisplayName("Tag Temp. Hysterese")]
        [Category("Tagbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public int OutDoorDayHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Absenkbetrieb größer als max. Außentemp")]
        [Category("Absenkbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public OnOffSwitch OutDoorNightShutDown { get; set; }

        [DisplayName("Max. Außentemp. Absenkbetrieb")]
        [Category("Absenkbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public int OutDoorNightTemperature { get; set; }

        [DisplayName("Absenk Temp. Hysterese")]
        [Category("Absenkbetrieb-Solltemp.")]
        [ReadOnly(true)]
        public int OutDoorNightHysterese { get; set; }

        [DisplayName("Frostschutztemp.")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int FreezeTemperature { get; set; }

        [DisplayName("Frostschutz Raumtemp.")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int RoomTemperature { get; set; }

        [DisplayName("Mischer Gesamtlaufzeit")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int MixerTime { get; set; }

        [DisplayName("Mischer Taktzeit")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public int MixerInterval { get; set; }

        [DisplayName("Mischer Faktor")]
        [Category("Heizkreis")]
        [ReadOnly(true)]
        public double MixerFactor { get; set; }


        //[DisplayName("Status Heizkreis")]
        ////[Description("Status Heizkreis")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public DayNight Status_Heizkreis { get; set; }

    }
}
