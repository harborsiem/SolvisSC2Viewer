using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace SolvisSC2Viewer {
    class HeatingSettings {

        private const string DegreeCelsius = "°C";
        private const string Minute = " Min.";
        private const string Hours = " Std.";
        private const string Days = " Tage";

        //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)
        //Zirkular Index: Ruhezeit: 326, Funkt. Ein :327, Temp: 328, Betriebsart: 329, Diff Ein: 330, Laufzeit: 332,
        //Wasser Index: Temp: 45, NachheizL. : 58, dT Start: 59, dt Ende: 60
        //Solar Index: Max. Koll.Temp.: 3 usw.
        //Temp.Sensor Korrekturwerte Index: ab 164 ? S10 ist auf 173
        //Eco Betrieb: ab Index: 359, 4 Werte ?
        //Index 372 bis 374: Checksum ?

        public HeatingSettings(IList<int> list, int index) {
            //Gebläsedrehzahl (index = 108 ?) mit Formel %-Wert für Brenner Stufe 2 ?
            //RunWater
            //RunHeatingCircuit
            WaterPriority = (WaterMode)list[index++];
            ModeHeatingCircuit = (HeatingCircuitMode)list[index++];
            ModeFlowTemperature = (FlowTemperatureMode)list[index++];
            FixFlowDay = list[index++].ToString() + DegreeCelsius;
            FixFlowLowering = list[index++].ToString() + DegreeCelsius;
            Temperature1 = list[index++].ToString() + DegreeCelsius;
            Temperature2 = list[index++].ToString() + DegreeCelsius;
            Temperature3 = list[index++].ToString() + DegreeCelsius;
            LoweringTemperature = list[index++].ToString() + DegreeCelsius;
            Gradient = list[index++] / 100.0;
            RaisingSetpoint = list[index++].ToString() + "%"; // ? Einschaltüberhöhung
            RoomInfluence = list[index++].ToString() + "%"; // ? Raumeinfluss
            HoldTime = list[index++].ToString() + Minute;
            FlowTemperatureMax = list[index++].ToString() + DegreeCelsius;
            FlowTemperatureMin = list[index++].ToString() + DegreeCelsius;
            Offset = list[index++].ToString() + "K";
            Niveau = list[index++].ToString() + "K";
            S10MeanTime = list[index++].ToString() + Minute;
            RoomShutDown = (OnOffSwitch)list[index++];
            RoomHysterese = list[index++].ToString() + "K";
            OutsideDayShutDown = (OnOffSwitch)list[index++];
            OutsideDayTemperature = list[index++].ToString() + DegreeCelsius;
            OutsideDayHysterese = list[index++].ToString() + "K";
            OutsideLoweringShutDown = (OnOffSwitch)list[index++];
            OutsideLoweringTemperature = list[index++].ToString() + DegreeCelsius;
            OutsideLoweringHysterese = list[index++].ToString() + "K";

            index += 2; //@Todo: index = 211, 212
            //? HeatPumpMode, BurnerMode ?

            FreezeTemperature = "<" + list[index++].ToString() + DegreeCelsius;
            FreezeRoomTemperature = "<" + list[index++].ToString() + DegreeCelsius;
            MixerTime = list[index++].ToString() + "s";
            MixerInterval = list[index++].ToString() + "s";
            MixerFactor = (list[index++] / 10.0).ToString("f1") + "s/K";
            DayModeTemperature = list[index++].ToString() + DegreeCelsius;
            DayModeHours = list[index++].ToString() + Hours;
            LoweringModeTemperature = list[index++].ToString() + DegreeCelsius;
            LoweringModeHours = list[index++].ToString() + Hours;
            LeaveHomeTemperature = list[index++].ToString() + DegreeCelsius;
            LeaveHomeDuration = list[index++].ToString() + Days;
            string tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeFrom = tmpTime;
            tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeTo = tmpTime;
            LeaveAwayTemperature = list[index++].ToString() + DegreeCelsius;
            int day = list[index++];
            int month = list[index++];
            int year = list[index++];
            LeaveEndDate = new DateTime(year, month, day);

            //Burner2Start = list[113].ToString() + "K";
            //Burner2Stop = list[114].ToString() + "K";
            //ModulationTMin = list[115].ToString() + DegreeCelsius;
            //ModulationVMin = (list[116] / 10.0).ToString("f1") + "V";
            //ModulationTMax = list[117].ToString() + DegreeCelsius;
            //ModulationVMax = (list[118] / 10.0).ToString("f1") + "V";
            //EcoWater = list[359].ToString() + DegreeCelsius;
            //EcoTemperature1 = list[360].ToString() + DegreeCelsius;
            //EcoTemperature2 = list[361].ToString() + DegreeCelsius;
            //EcoTemperature3 = list[362].ToString() + DegreeCelsius;

            WaterPumpMode = (Mode)list[44]; //?
            WaterTargetTemperature = list[45].ToString() + DegreeCelsius;
            WaterBufferTmin = list[53].ToString() + DegreeCelsius; //oder index = 61
            WaterAuxHeatingStart = list[54].ToString() + "K";
            WaterAuxHeatingSperrzeit = list[55].ToString() + Minute;
            WaterAuxHeatingRuntime = list[56].ToString() + "s";
            WaterAuxHeatingPower = list[58].ToString() + "%";
            WaterDTStart = list[59].ToString() + "K";
            WaterDTEnd = list[60].ToString() + "K";

            CircOffTime = list[326].ToString() + Minute;
            CircPump = (Mode)list[327];
            CircCommandTemperature = list[328].ToString() + DegreeCelsius;
            CircMode = (CircMode)list[329];
            CircDeltaForOn = list[330].ToString() + "K";
            CircMinRuntime = list[332].ToString() + "s";
        }

        [DisplayName("Heizung Temperatur Wippe")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Niveau { get; set; }

        [DisplayName("Warmwasser-Vorrang")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public WaterMode WaterPriority { get; set; }

        [DisplayName("Betriebsart Heizkreis")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public HeatingCircuitMode ModeHeatingCircuit { get; set; }

        //[DisplayName("Aktor Heizungspumpe Modus")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public Mode HeatPumpMode { get; set; }

        //[DisplayName("Aktor Brenner Modus")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public Mode BurnerMode { get; set; }

        //[DisplayName("Laufzeit WW-Bereitung")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public int RunWater { get; set; }

        //[DisplayName("Laufzeit Heizkreise")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public int RunHeatingCircuit { get; set; }

        [DisplayName("Betriebsart VL Temp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public FlowTemperatureMode ModeFlowTemperature { get; set; }

        [DisplayName("Fix Vorlauf Tag")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowDay { get; set; }

        [DisplayName("Fix Vorlauf Absenk")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowLowering { get; set; }

        [DisplayName("Steilheit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public double Gradient { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 1")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature1 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 2")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature2 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 3")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature3 { get; set; }

        [DisplayName("Absenk-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringTemperature { get; set; }

        [DisplayName("Einschaltüberhöhung HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RaisingSetpoint { get; set; }

        [DisplayName("Raumeinfluss HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string RoomInfluence { get; set; }

        [DisplayName("Vorhaltezeit HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string HoldTime { get; set; }

        [DisplayName("Max. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMax { get; set; }

        [DisplayName("Min. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMin { get; set; }

        [DisplayName("Offset")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Offset { get; set; }

        [DisplayName("Mittelwertzeitraum")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string S10MeanTime { get; set; }

        [DisplayName("Abschaltbedingung wenn Raum-Solltemp. erreicht ist")]
        [Category("Raum-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch RoomShutDown { get; set; }

        [DisplayName("Raum Temp. Hysterese")]
        [Category("Raum-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RoomHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Tagbetrieb größer als max. Außentemp")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideDayShutDown { get; set; }

        [DisplayName("Max. Außentemp. Tagbetrieb")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideDayTemperature { get; set; }

        [DisplayName("Tag Temp. Hysterese")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideDayHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Absenkbetrieb größer als max. Außentemp")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideLoweringShutDown { get; set; }

        [DisplayName("Max. Außentemp. Absenkbetrieb")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideLoweringTemperature { get; set; }

        [DisplayName("Absenk Temp. Hysterese")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideLoweringHysterese { get; set; }

        [DisplayName("Frostschutztemp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeTemperature { get; set; }

        [DisplayName("Frostschutz Raumtemp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeRoomTemperature { get; set; }

        [DisplayName("Mischer Gesamtlaufzeit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerTime { get; set; }

        [DisplayName("Mischer Taktzeit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerInterval { get; set; }

        [DisplayName("Mischer Faktor")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerFactor { get; set; }

        [DisplayName("Tagbetrieb Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeTemperature { get; set; }

        [DisplayName("Tagbetrieb Stunden")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeHours { get; set; }

        [DisplayName("Absenkbetrieb Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeTemperature { get; set; }

        [DisplayName("Absenkbetrieb Stunden")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeHours { get; set; }

        [DisplayName("Urlaub zu Hause Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTemperature { get; set; }

        [DisplayName("Urlaub zu Hause Tage")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeDuration { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit von")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeFrom { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit bis")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeTo { get; set; }

        [DisplayName("Urlaub abwesend Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveAwayTemperature { get; set; }

        [DisplayName("Datum Urlaubs Ende")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public DateTime LeaveEndDate { get; set; }

        //[DisplayName("Brenner 2 Start")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string Burner2Start { get; set; }

        //[DisplayName("Brenner 2 Stop")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string Burner2Stop { get; set; }

        //[DisplayName("Modulation T Min")]
        //[Category("Heizung Modulation")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationTMin { get; set; }

        //[DisplayName("Modulation V Min")]
        //[Category("Heizung Modulation")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationVMin { get; set; }

        //[DisplayName("Modulation T Max")]
        //[Category("Heizung Modulation")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationTMax { get; set; }

        //[DisplayName("Modulation V Max")]
        //[Category("Heizung Modulation")]
        //[HeatingUser(HeatingUser.Installateur)]
        //[ReadOnly(true)]
        //public string ModulationVMax { get; set; }

        //[DisplayName("Eco Warmwasser Temp.")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoWater { get; set; }

        //[DisplayName("Eco Temperatur 1")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoTemperature1 { get; set; }

        //[DisplayName("Eco Temperatur 2")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoTemperature2 { get; set; }

        //[DisplayName("Eco Temperatur 3")]
        //[Category("Heizung")]
        //[HeatingUser(HeatingUser.FachNutzer)]
        //[ReadOnly(true)]
        //public string EcoTemperature3 { get; set; }

        [DisplayName("Wasserpumpe Betriebsart")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public Mode WaterPumpMode { get; set; }

        [DisplayName("Wasser Sollwert")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string WaterTargetTemperature { get; set; }

        [DisplayName("Wasser Puffer Tmin")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterBufferTmin { get; set; }

        [DisplayName("Wasser Nachheizleistung")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingPower { get; set; }

        [DisplayName("Wasser dT Start")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterDTStart { get; set; }

        [DisplayName("Wasser dT Ende")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterDTEnd { get; set; }

        [DisplayName("Wasser Nachheiz Start")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingStart { get; set; }

        [DisplayName("Wasser Nachheiz Sperrzeit")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingSperrzeit { get; set; }

        [DisplayName("Wasser Nachheiz Laufzeit")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingRuntime { get; set; }

        [DisplayName("Zirkulations Betriebsart")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public CircMode CircMode { get; set; }

        [DisplayName("Zirkulationspumpe")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public Mode CircPump { get; set; }

        [DisplayName("Zirkulationstemp.SOLL")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircCommandTemperature { get; set; }

        [DisplayName("Zirk. Laufzeit")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string CircMinRuntime { get; set; }

        [DisplayName("Zirk. Ruhezeit")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircOffTime { get; set; }

        [DisplayName("Zirk. Differenz ein")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string CircDeltaForOn { get; set; }

    }
}
