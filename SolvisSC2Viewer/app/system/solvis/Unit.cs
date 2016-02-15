using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    public sealed class Unit {
        public const string DegreeCelsius = "°C";
        public const string Second = "s";
        public static readonly string Minute = " " + Resources.UnitMinutes;
        public static readonly string Hours = " " + Resources.UnitHours;
        public static readonly string Days = " " + Resources.UnitDays;
        public const string Volt = "V";
        public const string Kelvin = "K";
        public const string Percent = "%";
        public const string SecondsPerKelvin = "s/K";
        public const string PulsePerLitre = "P/l";

        private Unit() {
        }
    }
}
