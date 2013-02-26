using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SolvisSC2Viewer {
    internal class ExternCode {
        private const string FormulaDll = "Formula.dll";

        private ExternCode() {
        }

        public static bool MakeProxy() {
            if (File.Exists(FormulaDll)) {
                try {
                    Assembly ass = Assembly.LoadFrom(FormulaDll);
                    if (ass == null) {
                        return false;
                    }
                    Module[] modules = ass.GetModules();
                    if (modules.Length == 0) {
                        return false;
                    }
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types) {
                        Type iType = type.GetInterface("SolvisSC2Viewer.ICalculator");
                        if (iType != null) {
                            Object handle = Activator.CreateInstance(type);
                            ICalculator iCalc = handle as ICalculator;
                            if (iCalc != null) {
                                new CalculatorProxy(iCalc);
                                return true;
                            }
                        }
                    }
                }
                catch (Exception) {
                }
            }
            return false;
        }
    }
}
