using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Tricentis.TCAddIns.BufferArea.TCObjects;
using Tricentis.TCCore.BusinessObjects.Folders;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.Tasks;

namespace Tricentis.TCAddIns.BufferArea.Tasks {
    public class ReloadBuffersTask : Task {
        public override string Name => "Reload Buffers";

        public static bool IsTaskPossible(TCFolder folder) {
            if (folder == null) {
                return false;
            }
            return true;
        }

        public override object Execute(PersistableObject obj, ITaskContext context) {
            TCFolder folder = obj as TCFolder;
            if (!IsTaskPossible(folder)) {
                return null;
            }
            folder.Items.Clear();
            GetBuffersFromSettings(folder);
            return null;
        }

        private void GetBuffersFromSettings(TCFolder folder) {
            XDocument doc = XDocument.Load(@"C:\ProgramData\TRICENTIS\TOSCA Testsuite\7.0.0\Settings\XML\Settings.xml");
            var bufferRoot = doc.Root.Descendants().FirstOrDefault(IsXmlBufferNode);
            if(bufferRoot == null) {
                return;
            }
            foreach(var element in bufferRoot.Elements()) {
                var buffer = CreateToscaBuffer(element);
                if(buffer != null) {
                    folder.Items.Add(buffer);
                }
            }
        }

        private bool IsXmlBufferNode(XElement element) {
            if (element.Name.LocalName != "Collection") {
                return false;
            }
            XAttribute attr = element.Attribute("name");
            return attr != null && attr.Value == "Buffer";
        }

        private Buffer CreateToscaBuffer(XElement element) {
            XAttribute attr = element.Attribute("name");
            if(attr == null) {
                return null;
            }
            var buffer = Buffer.Create();
            buffer.Name = attr.Value;
            buffer.Value = element.Value;
            return buffer;
        }
    }
}
