using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    [Flags]
    public enum CircMode {
        Aus,
        Pulse = 1,
        Time = 2,
    }

    public enum WaterMode { //?
        Aus,
        Ein,
        Alt,
    }

    public enum SolarMode { //?
        dt, Ziel
    }

    public enum HeatingCircuitMode { //?
        Absenk, Tag, Auto, Unknown1, Unknown2, Standby = 5, Unknown3
    }

    public enum Mode { //?
        Aus,
        Auto, Ein,
    }

    public enum OnOffSwitch {
        Aus, Ein
    }

    public enum FlowTemperatureMode {
        Kurve, Fixed 
    }

    [Flags]
    public enum SuppressMask {
        HK2 = 2,
        HK3 = 4,
        Eco = 32
    }

    public enum S01S04State {
        None,
        S01S04Ok,
        S01S04InterChanged
    }
}
