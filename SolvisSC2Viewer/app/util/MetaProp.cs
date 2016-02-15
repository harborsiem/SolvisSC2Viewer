using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//class MetaProp, BasicPropertyBag based on:
//http://stackoverflow.com/questions/4091888/properties-generated-at-runtime-propertygrid-selectedobject

namespace SolvisSC2Viewer {
    public class MetaProp {
        public MetaProp(string name, Type type, params Attribute[] attributes) {
            this.Name = name;
            this.ValueType = type;
            if (attributes != null) {
                Attributes = new Attribute[attributes.Length];
                attributes.CopyTo(Attributes, 0);
            }
        }
        public string Name { get; private set; }
        public Type ValueType { get; private set; }
        public Attribute[] Attributes { get; private set; }
    }
}
