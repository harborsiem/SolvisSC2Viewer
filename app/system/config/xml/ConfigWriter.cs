using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Globalization;

namespace SolvisSC2Viewer {
    internal class ConfigWriter {
        private ConfigManager manager;
        private XmlDocument document;
        private XmlNode configNode;

        public ConfigWriter(ConfigManager manager) {
            if (manager == null) {
                throw new ArgumentNullException("manager");
            }
            this.manager = manager;
        }

        public bool Write(String fileName) {
            FileInfo file = new FileInfo(fileName);
            document = CreateDocument();
            configNode = document.CreateElement(ConfigXml.Configuration);
            if (manager.ActorConfigValues != null) {
                SetActors();
            }
            if (manager.SensorConfigValues != null) {
                SetSensors();
            }
            if (manager.OptionConfigValues != null) {
                SetOptions();
            }
            SetSimpleNodeValue(ConfigXml.OpenDirTag, manager.OpenDir);
            SetSimpleNodeValue(ConfigXml.BurnerMinPowerTag, RowValues.BurnerMinPower.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.BurnerMaxPowerTag, RowValues.BurnerMaxPower.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.LatitudeTag, RowValues.Latitude.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.LongitudeTag, RowValues.Longitude.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.TemperatureTag, ConfigManager.Temperature.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.NiveauTag, ConfigManager.Niveau.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.GradientTag, ConfigManager.Gradient.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.TemperatureVLTag, RowValues.Temperature.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.NiveauVLTag, RowValues.Niveau.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.GradientVLTag, RowValues.Gradient.ToString(CultureInfo.InvariantCulture));
            SetSimpleNodeValue(ConfigXml.VersionTag, manager.Version);
            SetSimpleNodeValue(ConfigXml.Formula1Tag, manager.Formula1);
            SetSimpleNodeValue(ConfigXml.Formula2Tag, manager.Formula2);
            SetSimpleNodeValue(ConfigXml.Formula3Tag, manager.Formula3);
            if (manager.SuperUser) {
                SetSimpleNodeValue(ConfigXml.SuperUserTag, manager.SuperUser.ToString(CultureInfo.InvariantCulture));
            }
            document.AppendChild(configNode);
            SaveDocument(document, file);
            return true;
        }

        private void SetSimpleNodeValue(string tag, string value) {
            XmlNode node = document.CreateElement(tag);
            node.InnerText = value;
            configNode.AppendChild(node);
        }

        private void SetConfigs(string tag, string value) {
            XmlNode node = document.CreateElement(tag);
            configNode.AppendChild(node);
            XmlAttribute attrValue = document.CreateAttribute(ConfigXml.AttributeValue);
            attrValue.Value = value;
            node.Attributes.SetNamedItem(attrValue);
        }

        private void SetActors() {
            XmlNode actorsNode = document.CreateElement(ConfigXml.ActorsTag);
            SetElements(manager.ActorConfigValues, actorsNode, ConfigXml.ActorTag);
            configNode.AppendChild(actorsNode);
        }

        private void SetSensors() {
            XmlNode sensorsNode = document.CreateElement(ConfigXml.SensorsTag);
            SetElements(manager.SensorConfigValues, sensorsNode, ConfigXml.SensorTag);
            configNode.AppendChild(sensorsNode);
        }

        private void SetOptions() {
            XmlNode optionsNode = document.CreateElement(ConfigXml.OptionsTag);
            SetElements(manager.OptionConfigValues, optionsNode, ConfigXml.OptionTag);
            configNode.AppendChild(optionsNode);
        }

        private void SetElements(IDictionary<String, ConfigData> list, XmlNode node, string tag) {
            IEnumerator<KeyValuePair<string, ConfigData>> it = list.GetEnumerator();
            while (it.MoveNext()) {
                KeyValuePair<string, ConfigData> config = (KeyValuePair<string, ConfigData>)it.Current;

                XmlNode node1 = document.CreateElement(tag);
                node.AppendChild(node1);

                XmlAttribute attrKey = document.CreateAttribute(ConfigXml.AttributeKey);
                XmlAttribute attrText = document.CreateAttribute(ConfigXml.AttributeText);
                XmlAttribute attrToolTipText = document.CreateAttribute(ConfigXml.AttributeToolTipText);
                XmlAttribute attrVisible = document.CreateAttribute(ConfigXml.AttributeVisible);
                XmlAttribute attrChecked = document.CreateAttribute(ConfigXml.AttributeChecked);
                XmlAttribute attrColor = document.CreateAttribute(ConfigXml.AttributeColor);

                attrKey.Value = config.Key;
                attrText.Value = config.Value.Text;
                attrToolTipText.Value = config.Value.ToolTipText;
                attrVisible.Value = config.Value.Visible.ToString();
                attrChecked.Value = config.Value.Checked.ToString();
                attrColor.Value = ConfigManager.GetColorString(config.Value.Color);

                node1.Attributes.SetNamedItem(attrKey);
                node1.Attributes.SetNamedItem(attrText);
                node1.Attributes.SetNamedItem(attrToolTipText);
                node1.Attributes.SetNamedItem(attrVisible);
                node1.Attributes.SetNamedItem(attrChecked);
                node1.Attributes.SetNamedItem(attrColor);
            }
        }

        public static XmlDocument CreateDocument() {
            XmlDocument document = new XmlDocument();
            //Create an XML declaration. 
            XmlDeclaration xmldecl;
            xmldecl = document.CreateXmlDeclaration("1.0", "UTF-8", "no");
            xmldecl.Encoding = "UTF-8";
            document.AppendChild(xmldecl);

            return document;
        }

        public static void SaveDocument(XmlDocument document, FileInfo file) {
            try {
                document.Save(file.FullName);
            }
            catch (XmlException e) {
                AppExtension.PrintStackTrace(e);
            }
        }
    }
}
