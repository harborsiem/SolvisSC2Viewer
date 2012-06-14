using System;
using System.Collections.Generic;
using System.Text;

namespace SolvisSC2Viewer {

    public interface IItemBase {
        void Init();
        void UpdateItems();
        void LoadProperties();
    }
}
