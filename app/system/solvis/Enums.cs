using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    [Flags]
    internal enum CircMode {
        Aus,
        Pulse = 1,
        Time = 2,
    }

    internal enum WaterMode { //?
        Aus,
        Ein,
        Alt,
    }

    internal enum HeatingCircuitMode { //?
        Absenk, Tag, Auto, unknown1, unknown2, Standby = 5, unknown3
    }

    internal enum Mode { //?
        Aus,
        Auto, Ein,
    }

    internal enum OnOffSwitch {
        Aus, Ein
    }

    internal enum FlowTemperatureMode {
        Kurve, Fixed 
    }

    [Flags]
    public enum SuppressMask {
        HK2 = 2,
        HK3 = 4,
        DLad = 32 // Speicher Durchladung
    }
}
