using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace SolvisSC2Viewer {
    class HeatingSettings {

        //@Todo: Viele der unten aufgelisteten Properties als string definieren
        // Dann kann auch die Einheit im string enthalten sein.

        //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)
        //Zirkular Index: Ruhezeit: 326, Funkt. Ein :327, Temp: 328, Betriebsart: 329, Diff Ein: 330, Laufzeit: 332,
        //Wasser Index: Temp: 45, NachheizL. : 58, dT Start: 59, dt Ende: 60
        //Solar Index: Max. Koll.Temp.: 3 usw.
        //Temp.Sensor Korrekturwerte Index: ab 164 ? S10 ist auf 173
        //Eco Betrieb: ab Index: 359, 4 Werte ?
        //Index 372 bis 374: Checksum ?

        public HeatingSettings(IList<int> list, int index) {
            //Gebläsedrehzahl (index = 108 ?) mit Formel %-Wert für Brenner Stufe 2 ?
            //RunWW
            //RunHK
            WaterPriority = (WaterMode)list[index++];
            ModeHeatingCircuit = (HeatingCircuitMode)list[index++];
            ModeFlowTemperature = (FlowTemperatureMode)list[index++];
            FixFlowDay = list[index++];
            FixFlowLowering = list[index++];
            Temperature1 = list[index++];
            Temperature2 = list[index++];
            Temperature3 = list[index++];
            LoweringTemperature = list[index++];
            Gradient = list[index++] / 100.0;
            RaisingSetpoint = list[index++]; // ? Einschaltüberhöhung
            RoomInfluence = list[index++]; // ? Raumeinfluss
            HoldTime = list[index++];
            FlowTemperatureMax = list[index++];
            FlowTemperatureMin = list[index++];
            Offset = list[index++];
            Niveau = list[index++];
            S10MeanTime = list[index++];
            RoomShutDown = (OnOffSwitch)list[index++];
            RoomHysterese = list[index++];
            OutsideDayShutDown = (OnOffSwitch)list[index++];
            OutsideDayTemperature = list[index++];
            OutsideDayHysterese = list[index++];
            OutsideLoweringShutDown = (OnOffSwitch)list[index++];
            OutsideLoweringTemperature = list[index++];
            OutsideLoweringHysterese = list[index++];

            index += 2; //@Todo: index = 211, 212
            //? HeatPumpMode, BurnerMode ?

            FreezeTemperature = list[index++];
            FreezeRoomTemperature = list[index++];
            MixerTime = list[index++];
            MixerInterval = list[index++];
            MixerFactor = list[index++] / 10.0;
            DayModeTemperature = list[index++];
            DayModeHours = list[index++];
            LoweringModeTemperature = list[index++];
            LoweringModeHours = list[index++];
            LeaveHomeTemperature = list[index++];
            LeaveHomeDuration = list[index++];
            string tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeFrom = tmpTime;
            tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeTo = tmpTime;
            LeaveAwayTemperature = list[index++];
            int day = list[index++];
            int month = list[index++];
            int year = list[index++];
            LeaveEndDate = new DateTime(year, month, day);

            WaterPumpMode = (Mode)list[44]; //?
            WaterTargetTemperature = list[45];
            WaterBufferTmin = list[53]; //oder index = 61
            WaterAuxHeatingStart = list[54];
            WaterAuxHeatingSperrzeit = list[55];
            WaterAuxHeatingRuntime = list[56];
            WaterAuxHeatingPower = list[58];
            WaterDTStart = list[59];
            WaterDTEnd = list[60];

            CircOffTime = list[326];
            CircPump = (Mode)list[327];
            CircCommandTemperature = list[328];
            CircMode = (CircMode)list[329];
            CircDeltaForOn = list[330];
            CircMinRuntime = list[332];
        }

        [DisplayName("Heizung Temperatur Wippe")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int Niveau { get; set; }

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
        //public int RunWW { get; set; }

        //[DisplayName("Laufzeit Heizkreise")]
        //[Category("Heizkreis")]
        //[ReadOnly(true)]
        //public int RunHK { get; set; }

        [DisplayName("Betriebsart VL Temp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public FlowTemperatureMode ModeFlowTemperature { get; set; }

        [DisplayName("Fix Vorlauf Tag")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int FixFlowDay { get; set; }

        [DisplayName("Fix Vorlauf Absenk")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int FixFlowLowering { get; set; }

        [DisplayName("Steilheit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public double Gradient { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 1")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int Temperature1 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 2")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int Temperature2 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 3")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int Temperature3 { get; set; }

        [DisplayName("Absenk-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int LoweringTemperature { get; set; }

        [DisplayName("Einschaltüberhöhung HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int RaisingSetpoint { get; set; }

        [DisplayName("Raumeinfluss HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int RoomInfluence { get; set; }

        [DisplayName("Vorhaltezeit HK")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int HoldTime { get; set; }

        [DisplayName("Max. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int FlowTemperatureMax { get; set; }

        [DisplayName("Min. Vorlauf-Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int FlowTemperatureMin { get; set; }

        [DisplayName("Offset")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int Offset { get; set; }

        [DisplayName("Mittelwertzeitraum")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int S10MeanTime { get; set; }

        [DisplayName("Abschaltbedingung wenn Raum-Solltemp. erreicht ist")]
        [Category("Raum-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch RoomShutDown { get; set; }

        [DisplayName("Raum Temp. Hysterese")]
        [Category("Raum-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int RoomHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Tagbetrieb größer als max. Außentemp")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideDayShutDown { get; set; }

        [DisplayName("Max. Außentemp. Tagbetrieb")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int OutsideDayTemperature { get; set; }

        [DisplayName("Tag Temp. Hysterese")]
        [Category("Tagbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int OutsideDayHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Absenkbetrieb größer als max. Außentemp")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideLoweringShutDown { get; set; }

        [DisplayName("Max. Außentemp. Absenkbetrieb")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int OutsideLoweringTemperature { get; set; }

        [DisplayName("Absenk Temp. Hysterese")]
        [Category("Absenkbetrieb-Solltemp.")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int OutsideLoweringHysterese { get; set; }

        [DisplayName("Frostschutztemp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int FreezeTemperature { get; set; }

        [DisplayName("Frostschutz Raumtemp.")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int FreezeRoomTemperature { get; set; }

        [DisplayName("Mischer Gesamtlaufzeit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int MixerTime { get; set; }

        [DisplayName("Mischer Taktzeit")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int MixerInterval { get; set; }

        [DisplayName("Mischer Faktor")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public double MixerFactor { get; set; }

        [DisplayName("Tagbetrieb Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int DayModeTemperature { get; set; }

        [DisplayName("Tagbetrieb Stunden")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int DayModeHours { get; set; }

        [DisplayName("Absenkbetrieb Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int LoweringModeTemperature { get; set; }

        [DisplayName("Absenkbetrieb Stunden")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int LoweringModeHours { get; set; }

        [DisplayName("Urlaub zu Hause Temperatur")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int LeaveHomeTemperature { get; set; }

        [DisplayName("Urlaub zu Hause Tage")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int LeaveHomeDuration { get; set; }

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
        public int LeaveAwayTemperature { get; set; }

        [DisplayName("Datum Urlaubs Ende")]
        [Category("Heizkreis")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public DateTime LeaveEndDate { get; set; }

        [DisplayName("Wasserpumpe Betriebsart")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public Mode WaterPumpMode { get; set; }

        [DisplayName("Wasser Sollwert")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int WaterTargetTemperature { get; set; }

        [DisplayName("Wasser Puffer Tmin")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterBufferTmin { get; set; }

        [DisplayName("Wasser Nachheizleistung")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterAuxHeatingPower { get; set; }

        [DisplayName("Wasser dT Start")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterDTStart { get; set; }

        [DisplayName("Wasser dT Ende")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterDTEnd { get; set; }

        [DisplayName("Wasser Nachheiz Start")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterAuxHeatingStart { get; set; }

        [DisplayName("Wasser Nachheiz Sperrzeit")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterAuxHeatingSperrzeit { get; set; }

        [DisplayName("Wasser Nachheiz Laufzeit")]
        [Category("Wasser")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int WaterAuxHeatingRuntime { get; set; }

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
        public int CircCommandTemperature { get; set; }

        [DisplayName("Zirk. Laufzeit")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public int CircMinRuntime { get; set; }

        [DisplayName("Zirk. Ruhezeit")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int CircOffTime { get; set; }

        [DisplayName("Zirk. Differenz ein")]
        [Category("Zirkular")]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public int CircDeltaForOn { get; set; }

    }
}
