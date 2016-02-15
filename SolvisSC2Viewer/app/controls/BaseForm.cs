using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace System.Windows.Forms {
    public class BaseForm : Form {
        public BaseForm() {
            this.Font = SystemFonts.DialogFont;
        }
    }
}
