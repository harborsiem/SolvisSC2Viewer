using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace SolvisSC2Viewer {
    public class HeatingSettings {

        public const string CategoryHC = "Heizkreis";
        public const string CategoryHeating = "Heizung";
        public const string CategoryModulation = "Heizung Modulation";
        public const string CategoryRoomTemp = "Raum-Solltemp.";
        public const string CategoryDay = "Tagbetrieb-Solltemp.";
        public const string CategoryNight = "Absenkbetrieb-Solltemp.";
        public const string Fachnutzer = "Einstellbar durch Fachnutzer";
        public const string Installateur = "Einstellbar durch Installateur";

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

        [DisplayName("Heizung Temperatur Wippe")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Niveau { get; set; }

        [DisplayName("Warmwasser-Vorrang")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public WaterMode WaterPriority { get; set; }

        [DisplayName("Betriebsart Heizkreis")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public HeatingCircuitMode ModeHeatingCircuit { get; set; }

        //[DisplayName("Aktor Heizungspumpe Modus")]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public Mode HeatPumpMode { get; set; }

        //[DisplayName("Aktor Brenner Modus")]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public Mode BurnerMode { get; set; }

        //[DisplayName("Laufzeit WW-Bereitung")]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public int RunWater { get; set; }

        //[DisplayName("Laufzeit Heizkreise")]
        //[Category(CategoryHC)]
        //[ReadOnly(true)]
        //public int RunHeatingCircuit { get; set; }

        [DisplayName("Betriebsart VL Temp.")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public FlowTemperatureMode ModeFlowTemperature { get; set; }

        [DisplayName("Fix Vorlauf Tag")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowDay { get; set; }

        [DisplayName("Fix Vorlauf Absenk")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string FixFlowLowering { get; set; }

        [DisplayName("Steilheit")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public double Gradient { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 1")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature1 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 2")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature2 { get; set; }

        [DisplayName("Tag-Temp. Zeitfenster 3")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string Temperature3 { get; set; }

        [DisplayName("Absenk-Temperatur")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringTemperature { get; set; }

        [DisplayName("Einschaltüberhöhung HK")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RaisingSetpoint { get; set; }

        [DisplayName("Raumeinfluss HK")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string RoomInfluence { get; set; }

        [DisplayName("Vorhaltezeit HK")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string HoldTime { get; set; }

        [DisplayName("Max. Vorlauf-Temperatur")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMax { get; set; }

        [DisplayName("Min. Vorlauf-Temperatur")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FlowTemperatureMin { get; set; }

        [DisplayName("Offset")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Offset { get; set; }

        [DisplayName("Mittelwertzeitraum")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string S10MeanTime { get; set; }

        [DisplayName("Abschaltbedingung wenn Raum-Solltemp. erreicht ist")]
        [Description(Installateur)]
        [Category(CategoryRoomTemp)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch RoomShutDown { get; set; }

        [DisplayName("Raum Temp. Hysterese")]
        [Description(Installateur)]
        [Category(CategoryRoomTemp)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string RoomHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Tagbetrieb größer als max. Außentemp")]
        [Description(Installateur)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideDayShutDown { get; set; }

        [DisplayName("Max. Außentemp. Tagbetrieb")]
        [Description(Fachnutzer)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideDayTemperature { get; set; }

        [DisplayName("Tag Temp. Hysterese")]
        [Description(Installateur)]
        [Category(CategoryDay)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideDayHysterese { get; set; }

        [DisplayName("wenn Außentemp. im Absenkbetrieb größer als max. Außentemp")]
        [Description(Installateur)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public OnOffSwitch OutsideLoweringShutDown { get; set; }

        [DisplayName("Max. Außentemp. Absenkbetrieb")]
        [Description(Fachnutzer)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string OutsideLoweringTemperature { get; set; }

        [DisplayName("Absenk Temp. Hysterese")]
        [Description(Installateur)]
        [Category(CategoryNight)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string OutsideLoweringHysterese { get; set; }

        [DisplayName("Frostschutztemp.")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeTemperature { get; set; }

        [DisplayName("Frostschutz Raumtemp.")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string FreezeRoomTemperature { get; set; }

        [DisplayName("Mischer Gesamtlaufzeit")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerTime { get; set; }

        [DisplayName("Mischer Taktzeit")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerInterval { get; set; }

        [DisplayName("Mischer Faktor")]
        [Description(Installateur)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string MixerFactor { get; set; }

        [DisplayName("Tagbetrieb Temperatur")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeTemperature { get; set; }

        [DisplayName("Tagbetrieb Stunden")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string DayModeHours { get; set; }

        [DisplayName("Absenkbetrieb Temperatur")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeTemperature { get; set; }

        [DisplayName("Absenkbetrieb Stunden")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LoweringModeHours { get; set; }

        [DisplayName("Urlaub zu Hause Temperatur")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTemperature { get; set; }

        [DisplayName("Urlaub zu Hause Tage")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeDuration { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit von")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeFrom { get; set; }

        [DisplayName("Urlaub zu Hause Heizzeit bis")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveHomeTimeTo { get; set; }

        [DisplayName("Urlaub abwesend Temperatur")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string LeaveAwayTemperature { get; set; }

        [DisplayName("Datum Urlaubs Ende")]
        [Description(Fachnutzer)]
        [Category(CategoryHC)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public DateTime LeaveEndDate { get; set; }

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
