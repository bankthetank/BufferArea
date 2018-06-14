using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tricentis.TCCore.Base.Folders;

namespace Tricentis.TCAddIns.BufferArea.Utils
{
    public class Helper
    {
        private Helper() { }

        public static readonly string SETTINGS_PATH = @"C:\ProgramData\TRICENTIS\TOSCA Testsuite\7.0.0\Settings\XML\Settings.xml";

        public static bool BufferExists(string bufferName)
        {
            XDocument doc = XDocument.Load(SETTINGS_PATH);
            XElement bufferRoot = doc.Root.Descendants().FirstOrDefault(IsXmlBufferNode);
            if (bufferRoot == null) {
                return false;
            }

            foreach (XElement element in bufferRoot.Elements()) {
                if (element.FirstAttribute.Value == bufferName) {
                    return true;
                }
            }

            return false;
        }

        public static void UpdateBufferValue(string bufferName, string newBufferValue)
        {
            XDocument doc = XDocument.Load(SETTINGS_PATH);
            XElement bufferRoot = doc.Root.Descendants().FirstOrDefault(IsXmlBufferNode);
            if (bufferRoot == null) {
                return;
            }

            foreach (XElement element in bufferRoot.Elements()) {
                if (element.FirstAttribute.Value == bufferName) {
                    element.Value = newBufferValue;
                    doc.Save(SETTINGS_PATH);
                    return;
                }
            }
        }

        public static void DeleteBuffer(string bufferName)
        {
            XDocument doc = XDocument.Load(SETTINGS_PATH);
            XElement bufferRoot = doc.Root.Descendants().FirstOrDefault(IsXmlBufferNode);
            if (bufferRoot == null) {
                return;
            }

            foreach (XElement element in bufferRoot.Elements()) {
                if (element.FirstAttribute.Value == bufferName) {
                    element.Remove();
                    doc.Save(SETTINGS_PATH);
                    return;
                }
            }
        }

        public static void SaveNewBuffer(string bufferName, string bufferValue)
        {
            XDocument doc = XDocument.Load(SETTINGS_PATH);
            var bufferRoot = doc.Root.Descendants().FirstOrDefault(IsXmlBufferNode);
            if (bufferRoot == null) {
                return;
            }
            XElement element = new XElement("none");
            element.Value = bufferValue;
            element.Name = bufferRoot.Name + "Entry";
            element.Add(new XAttribute("name", bufferName));

            bufferRoot.Add(element);
            doc.Save(SETTINGS_PATH);
        }

        public static bool IsXmlBufferNode(XElement element)
        {
            if (element.Name.LocalName != "Collection") {
                return false;
            }
            XAttribute attr = element.Attribute("name");
            return attr != null && attr.Value == "Buffer";
        }
    }
}
