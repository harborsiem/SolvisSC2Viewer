using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public class Formulas : ICalculator {
        private bool hasFormulaSolarVSG;
        private bool hasFormulaSolarKW;

        private bool bVal1;
        private bool bVal2;
        private bool bVal3;
        private bool bVal4;
        private bool bVal5;
        private int iVal1;
        private int iVal2;
        private int iVal3;
        private int iVal4;
        private int iVal5;
        private double dVal1;
        private double dVal2;
        private double dVal3;
        private double dVal4;
        private double dVal5;
        private double dVal6;
        private double dVal7;
        private double dVal8;
        private double dVal9;
        private double dVal10;

        public Formulas() {
            hasFormulaSolarVSG = false; //auf "true" setzen, wenn eigene SolarVSG Formel vorhanden
            hasFormulaSolarKW = false; //auf "true" setzen, wenn eigene SolarKW Formel vorhanden
        }

        public virtual bool HasFormulaSolarVSG {
            get {
                return this.hasFormulaSolarVSG;
            }
        }

        public virtual bool HasFormulaSolarKW {
            get {
                return this.hasFormulaSolarKW;
            }
        }

        public double Formula1(RowValues rowValues, SeriesState state) {
            return 0.0;
        }

        public double Formula2(RowValues rowValues, SeriesState state) {
            return 0.0;
        }

        public double Formula3(RowValues rowValues, SeriesState state) {
            return 0.0;
        }

        public double Formula4(RowValues rowValues, SeriesState state) {
            return 0.0;
        }

        public double Formula5(RowValues rowValues, SeriesState state) {
            return 0.0;
        }

        public double FormulaSolarVSG(RowValues rowValues) {
            double result;
            result = SolarVSG(rowValues);
            //return result;
            
            return 0.0;
        }

        public double FormulaSolarKW(RowValues rowValues) {
            double result = 0.0;
            double deltaTemperature = rowValues.S05 - rowValues.S06;
            if ((deltaTemperature > 0) && (rowValues.S17 > 0)) {
                result = deltaTemperature * SolarVSG(rowValues) / 3600.0 * RowValues.GetHeatCapacity(rowValues.S05, rowValues.S06);
            }
            //return result;

            return 0.0;
        }

        private double SolarVSG(RowValues rowValues) {
            if (GetSelectedSolvisControlVersion() >= 132) {
                return rowValues.S17;
            } else {
                return (1000.0 / rowValues.S17) * 3600.0 / RowValues.SolarPulse;
            }
        }

        private static double SolvisFlowCurve(RowValues rowValues) {
            if (rowValues.S10MeanValue <= 20) {
                return (int)HeatCurve.SolvisCurve(RowValues.Temperature, RowValues.Niveau, RowValues.Gradient, (int)rowValues.S10MeanValue);
            } else {
                return 20;
            }
        }

        private static double SmoothFlowCurve(RowValues rowValues) {
            if (rowValues.S10MeanValue <= 20) {
                return HeatCurve.SolvisCurve(RowValues.Temperature, RowValues.Niveau, RowValues.Gradient, rowValues.S10MeanValue);
            } else {
                return 20;
            }
        }

        private static string GetDocumentsDirectory() {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Solvis");
            path = Path.Combine(path, "SolvisViewer");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        private static int GetSelectedSolvisControlVersion() {
            return RowValues.SelectedSolvisControlVersion;
        }
    }
}
