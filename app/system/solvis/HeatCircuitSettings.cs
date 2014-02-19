using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public enum HeatCircuit {
        HC1, HC2, HC3
    }

    public class HeatCircuitSettings {

        public const string CategoryHC = "Heizkreis";
        public const string CategoryRoomTemp = "Raum-Solltemp.";
        public const string CategoryDay = "Tagbetrieb-Solltemp.";
        public const string CategoryNight = "Absenkbetrieb-Solltemp.";
        private static readonly int[] HeatCircuitTableIndex = { 185, 231, 277 };
        private static readonly string[] HeatCircuitStrings = { Resources.TimeOverviewHC + "1: ", Resources.TimeOverviewHC + "2: ", Resources.TimeOverviewHC + "3: " };
        //Beginn: HK1 = 185; HK2 = 231; HK3 = 277 (HK1 evtl. schon ab 184 ?)

        private HeatCircuit heatCircuit;

        public HeatCircuitSettings(IList<int> list, HeatCircuit heatCircuit) {
            this.heatCircuit = heatCircuit;
            int index = HeatCircuitTableIndex[(int)heatCircuit];

            Title = HeatingSettings.Titlevalue;
            //RunWater = ?
            //RunHeatCircuit = ?
            WaterPriority = (WaterMode)list[index++];
            ModeHeatingCircuit = (HeatingCircuitMode)list[index++];
            ModeFlowTemperature = (FlowTemperatureMode)list[index++];
            FixFlowDay = list[index++].ToString() + Unit.DegreeCelsius;
            FixFlowLowering = list[index++].ToString() + Unit.DegreeCelsius;
            Temperature1 = list[index++].ToString() + Unit.DegreeCelsius;
            Temperature2 = list[index++].ToString() + Unit.DegreeCelsius;
            Temperature3 = list[index++].ToString() + Unit.DegreeCelsius;
            LoweringTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            Gradient = list[index++] / 100.0;
            RoomInfluence = list[index++].ToString() + Unit.Percent; // ? Raumeinfluss
            RaisingSetpoint = list[index++].ToString() + Unit.Percent; // ? Einschaltüberhöhung
            HoldTime = list[index++].ToString() + Unit.Minute;
            FlowTemperatureMax = list[index++].ToString() + Unit.DegreeCelsius;
            FlowTemperatureMin = list[index++].ToString() + Unit.DegreeCelsius;
            Offset = list[index++].ToString() + Unit.Kelvin;
            Niveau = list[index++].ToString() + Unit.Kelvin;
            S10MeanTime = list[index++].ToString() + Unit.Minute;
            RoomShutDown = (OnOffSwitch)list[index++];
            RoomHysterese = list[index++].ToString() + Unit.Kelvin;
            OutsideDayShutDown = (OnOffSwitch)list[index++];
            OutsideDayTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            OutsideDayHysterese = list[index++].ToString() + Unit.Kelvin;
            OutsideLoweringShutDown = (OnOffSwitch)list[index++];
            OutsideLoweringTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            OutsideLoweringHysterese = list[index++].ToString() + Unit.Kelvin;

            index += 2; //@Todo: index = 211, 212
            //? HeatPumpMode, BurnerMode ?

            FreezeTemperature = "<" + list[index++].ToString() + Unit.DegreeCelsius;
            FreezeRoomTemperature = "<" + list[index++].ToString() + Unit.DegreeCelsius;
            MixerTime = list[index++].ToString() + Unit.Second;
            MixerInterval = list[index++].ToString() + Unit.Second;
            MixerFactor = (list[index++] / 10.0).ToString("f1") + Unit.SecondsPerKelvin;
            DayModeTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            DayModeHours = list[index++].ToString() + Unit.Hours;
            LoweringModeTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            LoweringModeHours = list[index++].ToString() + Unit.Hours;
            LeaveHomeTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            LeaveHomeDuration = list[index++].ToString() + Unit.Days;
            string tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeFrom = tmpTime;
            tmpTime = new DateTime((long)list[index++] * 15 * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            LeaveHomeTimeTo = tmpTime;
            LeaveAwayTemperature = list[index++].ToString() + Unit.DegreeCelsius;
            int day = list[index++];
            int month = list[index++];
            int year = list[index++];
            LeaveEndDate = new DateTime(year, month, day);
        }

        public string GetHeatCircuit() {
            return HeatCircuitStrings[(int)heatCircuit];
        }

        [DisplayName("Heizkreis Parameter")]
        [Category(CategoryHC)]
        public string Title { get; set; }

        [DisplayName("Heizung Temperatur Wippe")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Niveau { get; set; }

        [DisplayName("Warmwasser-Vorrang")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public WaterMode WaterPriority { get; set; }

        [DisplayName("Betriebsart Heizkreis")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public HeatingCircuitMode ModeHeatingCircuit { get; set; }

        //[DisplayName("Aktor Heizungspumpe Modus")]
        //[Description(HeatingSettings.Installateur)]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public Mode HeatPumpMode { get; set; }

        //[DisplayName("Aktor Brenner Modus")]
        //[Description(HeatingSettings.Installateur)]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public Mode BurnerMode { get; set; }

        //[DisplayName("Laufzeit WW-Bereitung")]
        //[Description(HeatingSettings.Installateur)]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public int RunWater { get; set; }

        //[DisplayName("Laufzeit Heizkreise")]
        //[Description(HeatingSettings.Installateur)]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public int RunHeatCircuit { get; set; }

        [DisplayName("Betriebsart VL Temp.")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public FlowTemperatureMode ModeFlowTemperature { get; set; }

        [DisplayName("Fix Vorlauf Tag")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowDay { get; set; }

        [DisplayName("Fix Vorlauf Absenk")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowLowering { get; set; }

        [DisplayName("Steilheit")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public double Gradient { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 1")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature1 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 2")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature2 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 3")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature3 { get; set; }

        [DisplayName("Absenk-Temperatur")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringTemperature { get; set; }

        [DisplayName("Einschaltüberhöhung HK")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RaisingSetpoint { get; set; }

        [DisplayName("Raumeinfluss HK")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string RoomInfluence { get; set; }

        [DisplayName("Vorhaltezeit HK")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string HoldTime { get; set; }

        [DisplayName("Max. Vorlauf-Temperatur")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMax { get; set; }

        [DisplayName("Min. Vorlauf-Temperatur")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMin { get; set; }

        [DisplayName("Offset")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Offset { get; set; }

        [DisplayName("Mittelwertzeitraum")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string S10MeanTime { get; set; }

        [DisplayName("Abschaltbedingung wenn Raum-Solltemp. erreicht ist")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryRoomTemp)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch RoomShutDown { get; set; }

        [DisplayName("Raum Temp. Hysterese")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryRoomTemp)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RoomHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Tagbetrieb größer als max. Außentemp")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideDayShutDown { get; set; }

        [DisplayName("Max. Außentemp. Tagbetrieb")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideDayTemperature { get; set; }

        [DisplayName("Tag Temp. Hysterese")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideDayHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Absenkbetrieb größer als max. Außentemp")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideLoweringShutDown { get; set; }

        [DisplayName("Max. Außentemp. Absenkbetrieb")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideLoweringTemperature { get; set; }

        [DisplayName("Absenk Temp. Hysterese")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideLoweringHysterese { get; set; }

        [DisplayName("Frostschutztemp.")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeTemperature { get; set; }

        [DisplayName("Frostschutz Raumtemp.")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeRoomTemperature { get; set; }

        [DisplayName("Mischer Gesamtlaufzeit")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerTime { get; set; }

        [DisplayName("Mischer Taktzeit")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerInterval { get; set; }

        [DisplayName("Mischer Faktor")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerFactor { get; set; }

        [DisplayName("Tagbetrieb Temperatur")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeTemperature { get; set; }

        [DisplayName("Tagbetrieb Stunden")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeHours { get; set; }

        [DisplayName("Absenkbetrieb Temperatur")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeTemperature { get; set; }

        [DisplayName("Absenkbetrieb Stunden")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeHours { get; set; }

        [DisplayName("Urlaub zu Hause Temperatur")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTemperature { get; set; }

        [DisplayName("Urlaub zu Hause Tage")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeDuration { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit von")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeFrom { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit bis")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeTo { get; set; }

        [DisplayName("Urlaub abwesend Temperatur")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveAwayTemperature { get; set; }

        [DisplayName("Datum Urlaubs Ende")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public DateTime LeaveEndDate { get; set; }

    }
}
