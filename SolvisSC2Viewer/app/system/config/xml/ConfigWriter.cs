﻿using System;
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
            SetSimpleNodeValue(ConfigXml.BurnerMinPowerTag, XmlConvert.ToString(RowValues.BurnerMinPower));
            SetSimpleNodeValue(ConfigXml.BurnerMaxPowerTag, XmlConvert.ToString(RowValues.BurnerMaxPower));
            SetSimpleNodeValue(ConfigXml.LatitudeTag, XmlConvert.ToString(RowValues.Latitude));
            SetSimpleNodeValue(ConfigXml.LongitudeTag, XmlConvert.ToString(RowValues.Longitude));
            SetSimpleNodeValue(ConfigXml.TemperatureTag, XmlConvert.ToString(ConfigManager.Temperature));
            SetSimpleNodeValue(ConfigXml.LevelTag, XmlConvert.ToString(ConfigManager.Level));
            SetSimpleNodeValue(ConfigXml.GradientTag, XmlConvert.ToString(ConfigManager.Gradient));
            SetSimpleNodeValue(ConfigXml.TemperatureVLTag, XmlConvert.ToString(RowValues.Temperature));
            SetSimpleNodeValue(ConfigXml.LevelFlowTag, XmlConvert.ToString(RowValues.Level));
            SetSimpleNodeValue(ConfigXml.GradientVLTag, XmlConvert.ToString(RowValues.Gradient));
            SetSimpleNodeValue(ConfigXml.VersionTag, manager.Version);
            SetSimpleNodeValue(ConfigXml.Formula1Tag, manager.Formula1);
            SetSimpleNodeValue(ConfigXml.Formula2Tag, manager.Formula2);
            SetSimpleNodeValue(ConfigXml.Formula3Tag, manager.Formula3);
            if (!string.IsNullOrWhiteSpace(manager.Formula4)) {
                SetSimpleNodeValue(ConfigXml.Formula4Tag, manager.Formula4);
            }
            if (!string.IsNullOrWhiteSpace(manager.Formula5)) {
                SetSimpleNodeValue(ConfigXml.Formula5Tag, manager.Formula5);
            }
            if (!string.IsNullOrWhiteSpace(manager.FormulaSolarVSG)) {
                SetSimpleNodeValue(ConfigXml.SolarVSGTag, manager.FormulaSolarVSG);
            }
            if (!string.IsNullOrWhiteSpace(manager.FormulaSolarKW)) {
                SetSimpleNodeValue(ConfigXml.SolarKWTag, manager.FormulaSolarKW);
            }
            SetSimpleNodeValue(ConfigXml.HasFormulaDllTag, XmlConvert.ToString(manager.HasFormulaDll));
            SetSimpleNodeValue(ConfigXml.SolvisControlVersionTag, XmlConvert.ToString(RowValues.SolvisControlVersion));
            SetSimpleNodeValue(ConfigXml.SolarPulseTag, XmlConvert.ToString(RowValues.SolarPulse));
            SetSimpleNodeValue(ConfigXml.HeatCapacityTag, XmlConvert.ToString(RowValues.HeatCapacity20));
            SetSimpleNodeValue(ConfigXml.SdCardDirTag, manager.SdCardDir);
            SetSimpleNodeValue(ConfigXml.SDCardSuppressMaskTag, XmlConvert.ToString(manager.SDCardSuppressMask));
            SetSimpleNodeValue(ConfigXml.TimeTableBitmapTag, XmlConvert.ToString(manager.TimeTableBitmap));
            SetSimpleNodeValue(ConfigXml.OneDayModeTag, XmlConvert.ToString(manager.OneDayMode));
            SetSimpleNodeValue(ConfigXml.PrototypeTag, XmlConvert.ToString(manager.Prototype));
            if (manager.SuperUser) {
                SetSimpleNodeValue(ConfigXml.SuperUserTag, XmlConvert.ToString(manager.SuperUser));
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

        //private void SetConfigs(string tag, string value) {
        //    XmlNode node = document.CreateElement(tag);
        //    configNode.AppendChild(node);
        //    XmlAttribute attrValue = document.CreateAttribute(ConfigXml.AttributeValue);
        //    attrValue.Value = value;
        //    node.Attributes.SetNamedItem(attrValue);
        //}

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
                attrVisible.Value = XmlConvert.ToString(config.Value.Visible);
                attrChecked.Value = XmlConvert.ToString(config.Value.Checked);
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
