using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    [Flags]
    internal enum CircMode { //?
        Aus,
        Pulse = 1,
        Time = 2,
    }

    internal enum WaterMode { //?
        Aus,
        Alt,
        Ein,
    }

    internal enum Mode { //?
        Aus,
        Auto, Ein,
    }

    internal enum OnOffSwitch {
        Aus, Ein
    }

    internal enum DayNight {
        Absenk, Tag
    }

    internal enum HeatMode {
        Kurve, Fixed 
    }

    [Flags]
    public enum SuppressMask {
        HK2 = 2,
        HK3 = 4,
        DLad = 32 // Speicher Durchladung
    }
}
