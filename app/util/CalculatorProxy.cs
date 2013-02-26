using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class CalculatorProxy {

        private static ICalculator iCalculator;

        public static bool HasFormulaSolarVSG {
            get {
                if (iCalculator != null) {
                    return iCalculator.HasFormulaSolarVSG;
                }
                return false;
            }
        }

        public static bool HasFormulaSolarKW {
            get {
                if (iCalculator != null) {
                    return iCalculator.HasFormulaSolarKW;
                }
                return false;
            }
        }

        public CalculatorProxy(ICalculator calculator) {
            iCalculator = calculator;
        }

        internal static double Formula1(RowValues rowValues, SeriesState state) {
            if (iCalculator != null) {
                try {
                    return iCalculator.Formula1(rowValues, state);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P06: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double Formula2(RowValues rowValues, SeriesState state) {
            if (iCalculator != null) {
                try {
                    return iCalculator.Formula2(rowValues, state);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P07: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double Formula3(RowValues rowValues, SeriesState state) {
            if (iCalculator != null) {
                try {
                    return iCalculator.Formula3(rowValues, state);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P08: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double Formula4(RowValues rowValues, SeriesState state) {
            if (iCalculator != null) {
                try {
                    return iCalculator.Formula4(rowValues, state);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P09: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double Formula5(RowValues rowValues, SeriesState state) {
            if (iCalculator != null) {
                try {
                    return iCalculator.Formula5(rowValues, state);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P10: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double FormulaSolarVSG(RowValues rowValues) {
            if (iCalculator != null && HasFormulaSolarVSG) {
                try {
                    return iCalculator.FormulaSolarVSG(rowValues);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("S17: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }

        internal static double FormulaSolarKW(RowValues rowValues) {
            if (iCalculator != null && HasFormulaSolarKW) {
                try {
                    return iCalculator.FormulaSolarKW(rowValues);
                }
                catch (Exception ex) {
                    AppManager.MainForm.SetStatusLabel("P02: " + Resources.CalculatorProxyRuntimeError); //@Language Resource
                    AppExtension.PrintStackTrace(ex);
                }
            }
            return 0.0;
        }
    }
}
