using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;

namespace SolvisSC2Viewer {
    public enum GroupIdent {
        Sensor,
        Actor,
        Option
    }

    [Serializable]
    public class RowValues {
        private const int SolarVSGIndex = 16;
        private const int S10Index = 9;
        private const double HeatCapacityTemperature = 20.0;
        private const double HeatCapacityAccelerationPerKelvin = 0.004;
        private const int MaxNumColumns = 46; //2 date + time, 24 sensors, 20 actors
        private const int MinNumColumns = 36; //maybe 39 columns; 2 date + time, 18 sensors ?, 19 actors ?
        private static readonly CultureInfo locale = new CultureInfo("de");

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
        public double S17 { get { return sensors[16]; } } //VSG Solar
        public double S18 { get { return sensors[17]; } } //VSG Warmwasser
        public double S19 { get { return sensors[18]; } } //Raumfühler 1
        public double S20 { get { return sensors[19]; } } //Raumfühler 2
        public double S21 { get { return sensors[20]; } } //Raumfühler 3
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
        public static int SolvisControlVersion { get; set; }
        public static int SelectedSolvisControlVersion { get; set; }
        public static int SolarPulse { get; set; }
        public static double HeatCapacity20 { get; set; }
        internal static MeanTemperature mean = new MeanTemperature(30);
        public double S10Raw { get; private set; }
        public double S10MeanValue { get; private set; }

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
                double multiplier = 1.0;
                if (SelectedSolvisControlVersion >= 132) {
                    multiplier = 0.1;
                }
                DateTime date = Convert.ToDateTime(values[0], locale);
                DateTime time = Convert.ToDateTime(values[1], locale);
                DateAndTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, DateTimeKind.Local);
                int k, j;
                for (k = 2, j = 0; j < 16; k++, j++) {
                    int tmp = Convert.ToInt32(values[k]);
                    if (j == S10Index) { //Aussen Temperatur
                        S10Raw = (double)tmp / 10.0D;
                        int last = mean.GetLastValue(tmp);
                        if (Math.Abs(last - tmp) > 40) { //4 Grad Abweichung zulässig
                            tmp = last;
                        }
                        mean.Write(tmp);
                    }
                    sensors[j] = (double)tmp / 10.0D;
                }
                int s17Raw = Convert.ToInt32(values[k++]);
                sensors[j++] = (double)s17Raw;
                sensors[j++] = (double)Convert.ToInt32(values[k++]) / 10.0D;
                int i = 20;
                if (values.Length == MaxNumColumns) {
                    sensors[18] = (double)Convert.ToInt32(values[i]) * multiplier;
                    i++;
                    sensors[19] = (double)Convert.ToInt32(values[i]) * multiplier;
                    i++;
                    sensors[20] = (double)Convert.ToInt32(values[i]) * multiplier;
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

        public double GetSensorValue(int index) {
            if (index != SolarVSGIndex) {
                return sensors[index];
            } else {
                return FormulaSolarVSG;
            }
        }

        private double FormulaSolarVSG {
            get {
                if (CalculatorProxy.HasFormulaSolarVSG) {
                    if (S17 > 0) {
                        return CalculatorProxy.FormulaSolarVSG(this);
                    }
                    return 0.0;
                }
                return SolarVSG;
            }
        }

        public double SolarVSG { //@Todo: Umrechnung korrekt ? Einheit [l/h]
            get {
                if (S17 > 0.0) {
                    if (SelectedSolvisControlVersion >= 132) {
                        return S17;
                    } else {
                        return (1000.0 / S17) * 3600.0 / SolarPulse;
                        //return ((1000.0 / rowValues.S17) * 3600.0 / RowValues.SolarPulse);
                    }
                }
                return 0.0;
            }
        }

        public double FormulaSolarKW {
            get {
                if (CalculatorProxy.HasFormulaSolarKW) {
                    if (S17 > 0) {
                        return CalculatorProxy.FormulaSolarKW(this);
                    }
                    return 0.0D;
                }
                return SolarKW;
            }
        }

        private double SolarKW {
            get {
                double deltaTemperature = S05 - S06;
                if ((deltaTemperature > 0) && (S17 > 0)) {
                    return deltaTemperature * SolarVSG / 3600.0 * GetHeatCapacity(S05, S06);
                }
                return 0.0D;
            }
        }

        public static double GetHeatCapacity(double highTemperature, double lowTemperature) {
            double deltaTemperature = highTemperature - lowTemperature;
            double temperature = lowTemperature + (deltaTemperature / 2.0);
            return (HeatCapacity20 + (temperature - HeatCapacityTemperature) * HeatCapacityAccelerationPerKelvin);
        }

        public double FormulaIst_Soll1 {
            get {
                if (S10 <= 20) {
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
                if (S10MeanValue <= 20) {
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
    }
}
