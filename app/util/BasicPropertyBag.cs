using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace SolvisSC2Viewer {
    [TypeConverter(typeof(BasicPropertyBagConverter))]
    class BasicPropertyBag {

        private readonly List<MetaProp> properties = new List<MetaProp>();
        public List<MetaProp> Properties { get { return properties; } }
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();

        public BasicPropertyBag(object[] objects) {
            AddRange(objects);
        }

        public object this[string key] {
            get { object value; return values.TryGetValue(key, out value) ? value : null; }
            set { if (value == null) values.Remove(key); else values[key] = value; }
        }

        private void AddRange(object[] objects) {
            if (objects != null) {
                for (int i = 0; i < objects.Length; i++) {
                    string name;
                    Type propertyType;
                    Attribute[] attributes;
                    Type objectType = objects[i].GetType();
                    PropertyInfo[] infos = objectType.GetProperties();
                    for (int j = 0; j < infos.Length; j++) {
                        name = infos[j].Name;
                        propertyType = infos[j].PropertyType;
                        object value = infos[j].GetValue(objects[i], new object[0]);
                        object[] customAttributes = infos[j].GetCustomAttributes(false);
                        attributes = new Attribute[customAttributes.Length];
                        if (customAttributes.Length > 0) {
                            customAttributes.CopyTo(attributes, 0);
                        }
                        this.Properties.Add(new MetaProp(name, propertyType, attributes));
                        this[name] = value;
                    }
                }
            }
        }

        class BasicPropertyBagConverter : ExpandableObjectConverter {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
                PropertyDescriptor[] metaProps = (from prop in ((BasicPropertyBag)value).Properties
                                                  select new PropertyBagDescriptor(prop.Name, prop.ValueType, prop.Attributes)).ToArray();
                return new PropertyDescriptorCollection(metaProps);
            }
        }

        class PropertyBagDescriptor : PropertyDescriptor {
            private readonly Type type;
            public PropertyBagDescriptor(string name, Type type, Attribute[] attributes)
                : base(name, attributes) {
                this.type = type;
            }
            public override Type PropertyType { get { return type; } }
            public override object GetValue(object component) { return ((BasicPropertyBag)component)[Name]; }
            public override void SetValue(object component, object value) { ((BasicPropertyBag)component)[Name] = value; }
            public override bool ShouldSerializeValue(object component) { return false; } // GetValue(component) != null; }
            public override bool CanResetValue(object component) { return false; }
            public override void ResetValue(object component) { SetValue(component, null); }
            public override bool IsReadOnly { get { return ReadOnlyAttribute.Yes.Equals(Attributes[typeof(ReadOnlyAttribute)]); } }
            public override Type ComponentType { get { return typeof(BasicPropertyBag); } }
        }
    }
}
