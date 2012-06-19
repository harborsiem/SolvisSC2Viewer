using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SolvisSC2Viewer {
    public enum GroupIdent {
        Sensor,
        Actor,
        Option
    }

    [Serializable]
    public class RowValues {
        private const int MaxNumColumns = 46;
        private const int MinNumColumns = 37;
        public DateTime DateAndTime { get; private set; }
        public DateTime UtcPlus1DateTime { get { return DateAndTime.ToUniversalTime().AddHours(1); } }
        private double[] sensors;
        private double[] actors;

        public double S01 { get { return sensors[0]; } } //Speicher oben
        public double S02 { get { return sensors[1]; } } //Warmwasser
        public double S03 { get { return sensors[2]; } } //Speicher Referenz
        public double S04 { get { return sensors[3]; } } //Heizungspuffer oben
        public double S05 { get { return sensors[4]; } } //Solar VL2
        public double S06 { get { return sensors[5]; } } //Solar RL2
        public double S07 { get { return sensors[6]; } } //Solar Druck
        public double S08 { get { return sensors[7]; } } //Kollektor-Temp.
        public double S09 { get { return sensors[8]; } } //Heizungspuffer unten
        public double S10 { get { return sensors[9]; } } //Außen-Temp.
        public double S11 { get { return sensors[10]; } } //Zirkulations-Temp.
        public double S12 { get { return sensors[11]; } } //Vorlauf HK1
        public double S13 { get { return sensors[12]; } } //Vorlauf HK2
        public double S14 { get { return sensors[13]; } } //Vorlauf HK3
        public double S15 { get { return sensors[14]; } } //Solar VL1
        public double S16 { get { return sensors[15]; } } //Kollektor 2 oder Holzkessel
        public double S17 { get { return (double)s17Raw; } } //VSG Solar
        public double S18 { get { return sensors[17]; } } //VSG Warmwasser
        public double S19 { get { return sensors[18]; } } //Raumfühler 1
        public double S20 { get { return sensors[19]; } } //Raumfühler 2 ?
        public double S21 { get { return sensors[20]; } } //Raumfühler 3 ?
        public double S22 { get { return sensors[21]; } } //S22
        public double S23 { get { return sensors[22]; } } //S23
        public double S24 { get { return sensors[23]; } } //S24
        public double A01 { get { return actors[0]; } } //Solarpumpe %
        public double A02 { get { return actors[1]; } } //Pumpe WW l/h
        public double A03 { get { return actors[2]; } } //Pumpe HK1 %
        public double A04 { get { return actors[3]; } } //Pumpe HK2
        public double A05 { get { return actors[4]; } } //Pumpe Zirkulation
        public double A06 { get { return actors[5]; } } //Pumpe HK3
        public double A07 { get { return actors[6]; } } //Ladepumpe Holzofen
        public double A08 { get { return actors[7]; } } //HK1 Mischer auf
        public double A09 { get { return actors[8]; } } //HK1 Mischer zu
        public double A10 { get { return actors[9]; } } //HK2 Mischer auf
        public double A11 { get { return actors[10]; } } //HK2 Mischer zu
        public double A12 { get { return actors[11]; } } //Brenner Anforderung
        public double A13 { get { return actors[12]; } } //Brenner Stufe2
        public double A14 { get { return actors[13]; } } //A14 ?
        public double A15 { get { return actors[14]; } } //A15 ?
        public double A16 { get { return actors[15]; } } //Brenner P%
        public double A17 { get { return actors[16]; } } //A17 ?
        public double A18 { get { return actors[17]; } } //A18 ?
        public double A19 { get { return actors[18]; } } //A19
        public double A20 { get { return actors[19]; } } //A20
        public static double BurnerMinPower { get; set; }
        public static double BurnerMaxPower { get; set; }
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }
        public static double Temperature { get; set; }
        public static double Niveau { get; set; }
        public static double Gradient { get; set; }
        internal static MeanTemperature mean = new MeanTemperature(30);
        internal SeriesState State { get; set; } //just for the Calculate
        public double S10MeanValue { get; private set; }
        private int s17Raw; //VSG Solar

        public RowValues() {
            sensors = new double[24];
            actors = new double[20];
        }

        public RowValues(string row)
            : this() {
            string[] values = row.Split(new char[] { '\t' }, StringSplitOptions.None);
            if (values.Length > MaxNumColumns || values.Length < MinNumColumns) {
                throw new ArgumentException("Wrong count of values", "row");
            }
            try {
                DateTime date = Convert.ToDateTime(values[0]);
                DateTime time = Convert.ToDateTime(values[1]);
                DateAndTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, DateTimeKind.Local);
                int k, j;
                for (k = 2, j = 0; j < 16; k++, j++) {
                    int tmp = Convert.ToInt32(values[k]);
                    if (j == 9) { //Aussen Temperatur S10
                        int last = mean.GetLastValue(tmp);
                        if (Math.Abs(last - tmp) > 20) { //2 Grad Abweichung zulässig
                            tmp = last;
                        }
                        mean.Write(tmp);
                    }
                    sensors[j] = (double)tmp / 10.0D;
                }
                s17Raw = Convert.ToInt32(values[k++]);
                sensors[j++] = CalculateSolarVSG(s17Raw); //S17 @Todo: Umrechnung korrekt ?
                sensors[j++] = (double)Convert.ToInt32(values[k++]) / 10.0D;
                int i = 20;
                if (values.Length == MaxNumColumns) {
                    sensors[18] = (double)Convert.ToInt32(values[i]) / 10.0D;
                    i++;
                    sensors[19] = (double)Convert.ToInt32(values[i]) / 10.0D;
                    i++;
                    sensors[20] = (double)Convert.ToInt32(values[i]) / 10.0D;
                    i++;
                    sensors[21] = (double)Convert.ToInt32(values[i]);
                    i++;
                    sensors[22] = (double)Convert.ToInt32(values[i]);
                    i++;
                    sensors[23] = (double)Convert.ToInt32(values[i]);
                    i++;
                }
                for (k = i, j = 0; k < values.Length; k++, j++) {
                    actors[j] = (double)Convert.ToInt32(values[k]);
                }
                S10MeanValue = mean.GetMeanTemperature();
            }
            catch (FormatException e) {
                throw new ArgumentException("Wrong value", "row", e);
            }
        }

        public double[] GetSensors() {
            return sensors;
        }

        public double[] GetActors() {
            return actors;
        }

        public double FormulaBurner {
            get {
                if (A12 > 0) {
                    return BurnerMinPower + (A16 * (BurnerMaxPower - BurnerMinPower) / 100D);
                } else {
                    return 0.0D;
                }
            }
        }

        public double FormulaSunPosition {
            get {
                double result = SunPosition.CalcSunPosition(DateAndTime, Latitude, Longitude)[0];
                if (result >= 0D) {
                    return result;
                }
                return 0D;
            }
        }

        public double FormulaSolar {
            get {
                if (S17 > 0) {
                    return (S05 - S06) / (S17 / 100.0D) * 15D; //@Todo: Was bedeutet der Wert 15 ? Konfiguration notwendig ?
                } else {
                    return 0.0D;
                }
            }
        }

        public double FormulaIst_Soll1 {
            get {
                if (S10 <= 19) {
                    double result = S12 - HeatCurve.SolvisCurve(Temperature, Niveau, Gradient, S10);
                    if (result > -5D) {
                        return result;
                    } else {
                        return -5D;
                    }
                }
                return 0D;
            }
        }

        public double FormulaIst_Soll2 {
            get {
                if (S10 <= 19) {
                    double result = S12 - (int)HeatCurve.SolvisCurve(Temperature, Niveau, Gradient, (int)(S10MeanValue));
                    if (result > -5D) {
                        return result;
                    } else {
                        return -5D;
                    }
                }
                return 0D;
            }
        }

        public double CalculateSolarVSG(int value) {
            return (value == 0) ? 0 : (1.0 / ((double)value - 7.6365)) * 80148.4 + 4.53375; //empirisch ermittelte Formel von Vortex
        }

        public double Calculator1 {
            get {
                return CodeBuilder.Calculate1(this, State);
            }
        }

        public double Calculator2 {
            get {
                return CodeBuilder.Calculate2(this, State);
            }
        }

        public double Calculator3 {
            get {
                return CodeBuilder.Calculate3(this, State);
            }
        }
    }
}
