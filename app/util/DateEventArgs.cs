using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    internal class DateEventArgs : EventArgs {
        public DateEventArgs(DateTime from, DateTime to) {
            FromDate = from;
            ToDate = to;
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
    }
}
