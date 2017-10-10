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
        Counter,
        Solar
    }

    internal class PrintProperty {
        public PrintCategory PrintCategory { get; private set; }
        public string Category { get; private set; }
        public string DisplayName { get; private set; }
        public string ValueString { get; private set; }
        public string HeatingUser { get; private set; }

        private PrintProperty(MetaProp prop, BasicPropertyBag bag) {
            Attribute[] attributes = prop.Attributes;
            Attribute att = GetAttribute(attributes, typeof(DisplayNameAttribute));
            DisplayName = prop.Name;
            if (att != null) {
                DisplayName = ((DisplayNameAttribute)att).DisplayName;
            }
            att = GetAttribute(attributes, typeof(HeatingUserAttribute));
            HeatingUser = string.Empty;
            if (att != null) {
                HeatingUser = ((HeatingUserAttribute)att).HeatingUser.ToString();
            }
            att = GetAttribute(attributes, typeof(CategoryAttribute));
            Category = string.Empty;
            if (att != null) {
                Category = ((CategoryAttribute)att).Category;
            }
            SetPrintCategory(Category);
            object value = bag[prop.Name];
            SetValueString(value);
        }

        private static Attribute GetAttribute(Attribute[] attributes, Type type) {
            for (int i = 0; i < attributes.Length; i++) {
                if (attributes[i].GetType() == type) {
                    return attributes[i];
                }
            }
            return null;
        }

        private void SetPrintCategory(string value) {
            switch (value) {
                case CirculationSettings.CategoryCirc:
                    PrintCategory = PrintCategory.Circulation;
                    break;
                case WaterSettings.CategoryWater:
                    PrintCategory = PrintCategory.Water;
                    break;
                case SolarSettings.CategorySolar:
                    PrintCategory = PrintCategory.Solar;
                    break;
                case HeatCircuitSettings.CategoryHC:
                case HeatingSettings.CategoryHeating:
                case HeatCircuitSettings.CategoryRoomTemp:
                case HeatCircuitSettings.CategoryDay:
                case HeatCircuitSettings.CategoryNight:
                case HeatingSettings.CategoryModulation:
                    PrintCategory = PrintCategory.Heating1;
                    break;
                case CounterSettings.CategoryCounter:
                    PrintCategory = PrintCategory.Counter;
                    break;
                default:
                    PrintCategory = PrintCategory.None;
                    break;
            }
        }

        private void SetValueString(object value) {
            if (value == null) {
                ValueString = "Unknown";
                return;
            }
            ValueString = value as string;
            if (ValueString != null) {
                return;
            }
            if (value is DateTime) {
                ValueString = ((DateTime)value).ToShortDateString();
            } else {
                ValueString = value.ToString();
            }
        }

        public static IList<PrintProperty> GetPrintProperties(BasicPropertyBag bag) {
            List<PrintProperty> result = new List<PrintProperty>();
            if (bag != null) {
                List<MetaProp> properties = bag.Properties;
                for (int i = 0; i < properties.Count; i++) {
                    try {
                        PrintProperty item = new PrintProperty(properties[i], bag);
                        result.Add(item);
                    }
                    catch (NullReferenceException ex) {
                        AppExtension.PrintStackTrace(ex);
                    }
                }
            }
            return result;
        }

        public override string ToString() {
            return PrintCategory.ToString(); //Category + ", " + DisplayName + ", " + ValueString;
        }
    }
}
