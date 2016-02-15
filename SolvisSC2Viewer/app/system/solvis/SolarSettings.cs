using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace SolvisSC2Viewer {
    public class SolarSettings {
        public const string CategorySolar = "Solar";

        public SolarSettings(IList<int> list) {
            Title = HeatingSettings.Titlevalue;
            Temp1 = list[3].ToString() + Unit.DegreeCelsius;
            Temp2 = list[4].ToString() + Unit.Kelvin;
            Temp3 = list[5].ToString() + Unit.DegreeCelsius;
            Temp4 = list[6].ToString() + Unit.Kelvin;
            Temp5 = list[7].ToString() + Unit.DegreeCelsius;
            Temp6 = list[8].ToString() + Unit.Kelvin;
            Temp9 = list[9].ToString() + Unit.Kelvin;
            Temp10 = list[10].ToString() + Unit.Kelvin;
            //Temp7 = list[?].ToString() + Unit.Kelvin;
            //Temp8 = list[?].ToString() + Unit.Kelvin;
            //Temp11 = list[?].ToString() + Unit.Kelvin;
            //Temp12 = list[?].ToString() + Unit.Kelvin;


            DrehPriReg1 = list[15].ToString() + Unit.Percent;
            DrehPriReg2 = list[16].ToString() + Unit.Percent;
            DrehPriReg4 = list[17].ToString() + Unit.Kelvin;
            DrehPriReg5 = list[20].ToString() + Unit.Second;
            DrehPriReg6 = list[21].ToString() + Unit.Second;
            DrehPriReg3 = (SolarMode)list[14]; //?
            //DrehPriReg7 = list[?].ToString() + Unit.Kelvin;
            //DrehPriReg8 = list[?].ToString() + Unit.Kelvin;

            DrehSekReg1 = list[28].ToString() + Unit.Percent;
            DrehSekReg2 = list[29].ToString() + Unit.Percent;
            DrehSekReg4 = list[30].ToString() + Unit.Kelvin;
            DrehSekReg5 = list[33].ToString() + Unit.Second;
            DrehSekReg6 = list[34].ToString() + Unit.Second;
            DrehSekReg3 = (SolarMode)list[27]; //?
            //DrehSekReg7 = list[?].ToString() + Unit.Kelvin;
            //DrehSekReg8 = list[?].ToString() + Unit.Kelvin;
            string tmpTime;
            tmpTime = new DateTime((long)list[35] * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            KollStart1 = tmpTime;
            tmpTime = new DateTime((long)list[36] * 60 * 10000000).ToString("HH:mm", CultureInfo.InvariantCulture);
            KollStart2 = tmpTime;
            KollStart3 = list[37].ToString() + Unit.Second;
            KollStart4 = list[38].ToString() + Unit.Minute;

            AntifreezePercentage = list[42].ToString() + Unit.Percent;
            SolarPulse = list[43].ToString() + Unit.PulsePerLitre;
        }

        [DisplayName("Solar Parameter")]
        [Category(CategorySolar)]
        public string Title { get; set; }

        [DisplayName("Maximale Kollektortemp.")] //default: 120°C
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp1 { get; set; }

        [DisplayName("Hysterese Kollektortemp.")] //default: 20K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp2 { get; set; }

        [DisplayName("Maximale Referenztemp.")] //default: 80°C
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp3 { get; set; }

        [DisplayName("Hysterese Referenztemp.")] //default: 3K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp4 { get; set; }

        [DisplayName("max. Speichertemp. S1")] //default: 90°C
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp5 { get; set; }

        [DisplayName("Hysterese Begrenzung")] //default: 3K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp6 { get; set; }

        [DisplayName("Kollektordifferenz")] //*default: 15K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp7 { get; set; }

        [DisplayName("Hysterese Koll. Differenz")] //*default: 5K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp8 { get; set; }

        [DisplayName("Einschaltdifferenz")] //default: 12K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp9 { get; set; }

        [DisplayName("Ausschaltdifferenz")] //default: 8K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp10 { get; set; }

        [DisplayName("Einschaltdifferenz 2")] //**default: 12K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp11 { get; set; }

        [DisplayName("Ausschaltdifferenz 2")] //**default: 5K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string Temp12 { get; set; }


        [DisplayName("Max. Drehzahl")] //default: 100%
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg1 { get; set; }

        [DisplayName("Min. Drehzahl")] //default: 45%
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg2 { get; set; }

        [DisplayName("Modus")] //default: Ziel
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public SolarMode DrehPriReg3 { get; set; }

        [DisplayName("Delta T")] //default: 10K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg4 { get; set; }

        [DisplayName("Anlaufzeit")] //default: 90s
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg5 { get; set; }

        [DisplayName("Abschaltzeit")] //default: 5s
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg6 { get; set; }

        [DisplayName("Überhöhung Heizbetrieb")] //default: 6K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg7 { get; set; }

        [DisplayName("Überhöhung WW-Betrieb")] //default: 18K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehPriReg8 { get; set; }


        [DisplayName("Max. Drehzahl Sek.")] //default: 100%
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg1 { get; set; }

        [DisplayName("Min. Drehzahl Sek.")] //default: 45%
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg2 { get; set; }

        [DisplayName("Modus Sek.")] //default: Ziel
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public SolarMode DrehSekReg3 { get; set; }

        [DisplayName("Delta T Sek.")] //default: 10K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg4 { get; set; }

        [DisplayName("Anlaufzeit Sek.")] //default: 90s
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg5 { get; set; }

        [DisplayName("Abschaltzeit Sek.")] //default: 5s
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg6 { get; set; }

        [DisplayName("Überhöhung Heizbetrieb Sek.")] //default: 6K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg7 { get; set; }

        [DisplayName("Überhöhung WW-Betrieb Sek.")] //default: 18K
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string DrehSekReg8 { get; set; }


        [DisplayName("Aktivierungszeit Start")] //default: 06:00
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string KollStart1 { get; set; }

        [DisplayName("Aktivierungszeit Ende")] //default: 20:00
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string KollStart2 { get; set; }

        [DisplayName("Laufzeit")] //default: 15s
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string KollStart3 { get; set; }

        [DisplayName("Intervall")] //default: 15min
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string KollStart4 { get; set; }


        [DisplayName("WMZ Pulse / Liter")] //default: 42 P/l
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string SolarPulse { get; set; }

        [DisplayName("Frostschutzverhältnis")] //default: 40%
        [Description(HeatingSettings.Installateur)]
        [Category(CategorySolar)]
        [HeatingUser(HeatingUser.Installateur)]
        [ReadOnly(true)]
        public string AntifreezePercentage { get; set; }
    }
}
