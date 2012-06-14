using System;
using System.Collections.Generic;
using System.Text;

namespace SolvisSC2Viewer {
    public class ActionData {

        private Dictionary<String, Object> data;
        private Object sender;
        private EventArgs e;

        public ActionData() {
        }

        public void Set(String key, Object value) {
            if (data == null) {
                this.data = new Dictionary<String, Object>();
            }
            this.data[key] = value;
        }

        public Object Get(String key) {
            if (this.data != null && this.data.ContainsKey(key)) {
                return this.data[key];
            }
            return null;
        }

        public Object Sender {
            get { return sender; }
            set { sender = value; }
        }

        public EventArgs EventArgs {
            get { return e; }
            set { e = value; }
        }
    }
}
