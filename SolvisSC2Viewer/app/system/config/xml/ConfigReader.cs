﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Globalization;

namespace SolvisSC2Viewer {
    internal class ConfigReader {
        private ConfigManager manager;
        private XmlDocument document;

        public ConfigReader(ConfigManager manager) {
            if (manager == null) {
                throw new ArgumentNullException("manager");
            }
            this.manager = manager;
        }

        public bool Parse(String fileName) {
            try {
                FileInfo file = new FileInfo(fileName);
                if (file.Exists) {
                    document = GetDocument(file);
                    XmlNodeList xList = document.SelectNodes("configuration");
                    XmlNode node0 = xList.Item(0);
                    foreach (XmlNode node1 in node0.ChildNodes) {
                        switch (node1.Name) {
                            case ConfigXml.ActorsTag:
                                ParseActors(node1);
                                break;
                            case ConfigXml.SensorsTag:
                                ParseSensors(node1);
                                break;
                            case ConfigXml.OptionsTag:
                                ParseOptions(node1);
                                break;
                            case ConfigXml.OpenDirTag:
                                manager.OpenDir = node1.InnerText;
                                break;
                            case ConfigXml.BurnerMinPowerTag:
                                RowValues.BurnerMinPower = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.BurnerMaxPowerTag:
                                RowValues.BurnerMaxPower = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.LatitudeTag:
                                RowValues.Latitude = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.LongitudeTag:
                                RowValues.Longitude = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.TemperatureTag:
                                ConfigManager.Temperature = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.LevelTag:
                                ConfigManager.Level = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.GradientTag:
                                ConfigManager.Gradient = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.TemperatureVLTag:
                                RowValues.Temperature = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.LevelFlowTag:
                                RowValues.Level = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.GradientVLTag:
                                RowValues.Gradient = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.VersionTag:
                                manager.Version = node1.InnerText;
                                break;
                            case ConfigXml.SuperUserTag:
                                manager.SuperUser = XmlConvert.ToBoolean(node1.InnerText.ToLowerInvariant());
                                break;
                            case ConfigXml.Formula1Tag:
                                manager.Formula1 = node1.InnerText;
                                break;
                            case ConfigXml.Formula2Tag:
                                manager.Formula2 = node1.InnerText;
                                break;
                            case ConfigXml.Formula3Tag:
                                manager.Formula3 = node1.InnerText;
                                break;
                            case ConfigXml.Formula4Tag:
                                manager.Formula4 = node1.InnerText;
                                break;
                            case ConfigXml.Formula5Tag:
                                manager.Formula5 = node1.InnerText;
                                break;
                            case ConfigXml.HasFormulaDllTag:
                                manager.HasFormulaDll = XmlConvert.ToBoolean(node1.InnerText.ToLowerInvariant());
                                break;
                            case ConfigXml.SolarVSGTag:
                                manager.FormulaSolarVSG = node1.InnerText;
                                break;
                            case ConfigXml.SolarKWTag:
                                manager.FormulaSolarKW = node1.InnerText;
                                break;
                            case ConfigXml.SolvisControlVersionTag:
                                RowValues.SolvisControlVersion = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.SolarPulseTag:
                                RowValues.SolarPulse = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.HeatCapacityTag:
                                RowValues.HeatCapacity20 = XmlConvert.ToDouble(node1.InnerText);
                                break;
                            case ConfigXml.SdCardDirTag:
                                manager.SdCardDir = node1.InnerText;
                                break;
                            case ConfigXml.TimeTableSuppressMaskTag: //Compatibility Tag
                                manager.SDCardSuppressMask = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.SDCardSuppressMaskTag:
                                manager.SDCardSuppressMask = XmlConvert.ToInt32(node1.InnerText);
                                break;
                            case ConfigXml.TimeTableBitmapTag:
                                manager.TimeTableBitmap = XmlConvert.ToBoolean(node1.InnerText.ToLowerInvariant());
                                break;
                            case ConfigXml.OneDayModeTag:
                                manager.OneDayMode = XmlConvert.ToBoolean(node1.InnerText.ToLowerInvariant());
                                break;
                            case ConfigXml.PrototypeTag:
                                manager.Prototype = XmlConvert.ToBoolean(node1.InnerText.ToLowerInvariant());
                                break;
                            default:
                                break;
                        }
                    }
                    return true;
                }
            }
            catch (Exception e) {
                AppExtension.PrintStackTrace(e);
            }
            return false;
        }

        //private static string ParseConfigs(XmlNode child) {
        //    XmlNamedNodeMap param = child.Attributes;

        //    XmlNode nodeValue = param.GetNamedItem(ConfigXml.AttributeValue);
        //    return nodeValue.Value;
        //}

        private void ParseActors(XmlNode node) {
            if (manager.ActorConfigValues != null && node != null) {
                ParseElements(manager.ActorConfigValues, node, ConfigXml.ActorTag);
            }
        }

        private void ParseSensors(XmlNode node) {
            if (manager.SensorConfigValues != null && node != null) {
                ParseElements(manager.SensorConfigValues, node, ConfigXml.SensorTag);
            }
        }

        private void ParseOptions(XmlNode node) {
            if (manager.OptionConfigValues != null && node != null) {
                ParseElements(manager.OptionConfigValues, node, ConfigXml.OptionTag);
            }
        }

        private static void ParseElements(IDictionary<String, ConfigData> config, XmlNode node, string tag) {
            XmlNodeList nodeList = node.ChildNodes;
            for (int i = 0; i < nodeList.Count; i++) {
                XmlNode child = nodeList.Item(i);
                String nodeName = child.Name;

                if (nodeName.Equals(tag)) {
                    XmlNamedNodeMap param = child.Attributes;

                    XmlNode nodeKey = param.GetNamedItem(ConfigXml.AttributeKey);
                    XmlNode nodeText = param.GetNamedItem(ConfigXml.AttributeText);
                    XmlNode nodeToolTipText = param.GetNamedItem(ConfigXml.AttributeToolTipText);
                    XmlNode nodeVisible = param.GetNamedItem(ConfigXml.AttributeVisible);
                    XmlNode nodeChecked = param.GetNamedItem(ConfigXml.AttributeChecked);
                    XmlNode nodeColor = param.GetNamedItem(ConfigXml.AttributeColor);
                    if (nodeKey != null && nodeText != null && nodeVisible != null && nodeChecked != null && nodeColor != null) {
                        string key = nodeKey.Value;
                        string text = nodeText.Value;
                        string visible = nodeVisible.Value;
                        string checked0 = nodeChecked.Value;
                        string color = nodeColor.Value;
                        string toolTipText;
                        if (nodeToolTipText == null) {
                            toolTipText = string.Copy(text);
                        } else {
                            toolTipText = nodeToolTipText.Value;
                        }
                        if (key != null && text != null && visible != null && checked0 != null && color != null) {
                            ConfigData data = new ConfigData();
                            data.Text = text;
                            data.ToolTipText = toolTipText;
                            data.Visible = XmlConvert.ToBoolean(visible.ToLowerInvariant());
                            data.Checked = XmlConvert.ToBoolean(checked0.ToLowerInvariant());
                            data.Color = ConfigManager.GetColor(color);

                            config.Add(key, data);
                        }
                    }
                }
            }
        }

        private static XmlDocument GetDocument(FileInfo file) {
            XmlDocument document = new XmlDocument();
            try {
                document.Load(file.FullName);
            }
            catch (IOException ioe) {
                AppExtension.PrintStackTrace(ioe);
            }
            return document;
        }
    }
}
