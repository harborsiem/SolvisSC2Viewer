using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace SolvisSC2Viewer {
    public enum PrintCategory {
        None,
        Water,
        Circulation,
        Heating1,
        Counting
    }

    class PrintProperty {
        public PrintCategory PrintCategory { get; private set; }
        public string Category { get; private set; }
        public string DisplayName { get; private set; }
        public string ValueString { get; private set; }
        public string HeatingUser { get; private set; }

        private PrintProperty(Object obj, PropertyInfo info) {
            Object[] att = info.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            DisplayName = info.Name;
            if (att.Length > 0) {
                DisplayName = ((DisplayNameAttribute)att[0]).DisplayName;
            }
            att = info.GetCustomAttributes(typeof(HeatingUserAttribute), true);
            HeatingUser = string.Empty;
            if (att.Length > 0) {
                HeatingUser = ((HeatingUserAttribute)att[0]).HeatingUser.ToString();
            }
            att = info.GetCustomAttributes(typeof(CategoryAttribute), true);
            Category = string.Empty;
            if (att.Length > 0) {
                Category = ((CategoryAttribute)att[0]).Category;
            }
            switch (Category) {
                case "Zirkular":
                    PrintCategory = PrintCategory.Circulation;
                    break;
                case "Wasser":
                    PrintCategory = PrintCategory.Water;
                    break;
                case "Heizkreis":
                    PrintCategory = PrintCategory.Heating1;
                    break;
                case "Raum-Solltemp.":
                    PrintCategory = PrintCategory.Heating1;
                    break;
                case "Tagbetrieb-Solltemp.":
                    PrintCategory = PrintCategory.Heating1;
                    break;
                case "Absenkbetrieb-Solltemp.":
                    PrintCategory = PrintCategory.Heating1;
                    break;
                case "Counting":
                    PrintCategory = PrintCategory.Counting;
                    break;
                default:
                    PrintCategory = PrintCategory.None;
                    break;
            }
            Object value = info.GetValue(obj, null);
            if (value is string) {
                ValueString = (string)value;
            } else if (value is DateTime) {
                ValueString = ((DateTime)value).ToShortDateString();
            } else {
                ValueString = value.ToString();
            }
        }

        public static IList<PrintProperty> GetPrintProperties(Object obj) {
            List<PrintProperty> result = new List<PrintProperty>();
            Type type = obj.GetType();
            PropertyInfo[] infos = type.GetProperties();
            for (int i = 0; i < infos.Length; i++) {
                PrintProperty item = new PrintProperty(obj, infos[i]);
                result.Add(item);
            }
            return result;
        }

        public override string ToString() {
            return PrintCategory.ToString(); //Category + ", " + DisplayName + ", " + ValueString;
        }
    }
}
