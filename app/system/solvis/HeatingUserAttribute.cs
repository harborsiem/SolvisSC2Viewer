using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {

    public enum HeatingUser {
        FachNutzer,
        Installateur,
        SolvisSystem
    }

    [AttributeUsage(AttributeTargets.All)]
    public sealed class HeatingUserAttribute : Attribute {
        public static HeatingUserAttribute Default = new HeatingUserAttribute();
        private HeatingUser heatingUser;

        public HeatingUserAttribute()
            : this(HeatingUser.FachNutzer) {
        }

        public HeatingUserAttribute(HeatingUser heatingUser) {
            this.heatingUser = heatingUser;
        }

        public override bool Equals(object obj) {
            if (obj == this) {
                return true;
            }
            HeatingUserAttribute attribute = obj as HeatingUserAttribute;
            return ((attribute != null) && (attribute.HeatingUser == this.HeatingUser));
        }

        public override int GetHashCode() {
            return this.HeatingUser.GetHashCode();
        }

        public override bool IsDefaultAttribute() {
            return this.Equals(Default);
        }

        public HeatingUser HeatingUser {
            get {
                return this.heatingUser;
            }
            private set { this.heatingUser = value; }
        }
    }
}
