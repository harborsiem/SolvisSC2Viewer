using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace SolvisSC2Viewer {
    public class WaterSettings {

        public const string CategoryWater = "Wasser";

        public WaterSettings(IList<int> list) {
            Title = HeatingSettings.Titlevalue;
            WaterPumpMode = (Mode)list[44]; //?
            WaterTargetTemperature = list[45].ToString() + Unit.DegreeCelsius;
            WaterBufferTmin = list[53].ToString() + Unit.DegreeCelsius; //oder index = 61 ?
            WaterAuxHeatingStart = list[54].ToString() + Unit.Kelvin;
            WaterAuxHeatingSperrzeit = list[55].ToString() + Unit.Minute;
            WaterAuxHeatingRuntime = list[56].ToString() + Unit.Second;
            WaterAuxHeatingPower = list[58].ToString() + Unit.Percent;
            WaterDTStart = list[59].ToString() + Unit.Kelvin;
            WaterDTEnd = list[60].ToString() + Unit.Kelvin;
        }

        [DisplayName("Wasser Parameter")]
        [Category(CategoryWater)]
        public string Title { get; set; }

        [DisplayName("Wasserpumpe Betriebsart")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public Mode WaterPumpMode { get; set; }

        [DisplayName("Wasser Sollwert")]
        [Description(HeatingSettings.Fachnutzer)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.FachNutzer)]
        [ReadOnly(true)]
        public string WaterTargetTemperature { get; set; }

        [DisplayName("Wasser Puffer Tmin")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterBufferTmin { get; set; }

        [DisplayName("Wasser Nachheizleistung")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingPower { get; set; }

        [DisplayName("Wasser dT Start")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterDTStart { get; set; }

        [DisplayName("Wasser dT Ende")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterDTEnd { get; set; }

        [DisplayName("Wasser Nachheiz Start")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingStart { get; set; }

        [DisplayName("Wasser Nachheiz Sperrzeit")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingSperrzeit { get; set; }

        [DisplayName("Wasser Nachheiz Laufzeit")]
        [Description(HeatingSettings.Installateur)]
        [Category(CategoryWater)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string WaterAuxHeatingRuntime { get; set; }
    }
}
