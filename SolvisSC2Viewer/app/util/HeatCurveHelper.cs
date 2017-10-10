using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    class HeatCurveHelper {

        private HeatCurveHelper() {
        }

        public static bool IsInitialised {
            get;
            set;
        }

        public static decimal Temperature1 {
            get;
            set;
        }

        public static decimal Level1 {
            get;
            set;
        }

        public static decimal Gradient1 {
            get;
            set;
        }

        public static decimal Temperature2 {
            get;
            set;
        }

        public static decimal Level2 {
            get;
            set;
        }

        public static decimal Gradient2 {
            get;
            set;
        }

        public static decimal Temperature3 {
            get;
            set;
        }

        public static decimal Level3 {
            get;
            set;
        }

        public static decimal Gradient3 {
            get;
            set;
        }

        public static CheckState Curve1State {
            get;
            set;
        }

        public static CheckState Curve2State {
            get;
            set;
        }

        public static FormWindowState LastWindowState {
            get;
            set;
        }

        public static HeatCurve HeatCurve {
            get;
            set;
        }
    }
}
