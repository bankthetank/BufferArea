using DevExpress.XtraTreeList.Nodes;
using Tricentis.TCAddIns.BufferArea.GUI.DetailView;
using Tricentis.TCCore.ModelViewConnector.Nodes;
using Tricentis.TCCore.ModelViewConnector.Nodes.DetailAndNavigationView;
using Tricentis.TCCore.Persistency;

namespace Tricentis.TCAddIns.BufferArea.GUI.Nodes {
    public class BufferNode : AbstractGenericDetailView {
        protected BufferNode(TCObjects.Buffer obj, int id, AbstractNode owner) : base(obj, id, owner) {
        }

        public static BufferNode Create(TCObjects.Buffer obj, int id, AbstractNode owner) {
            BufferNode newNode = new BufferNode(obj, id, owner);
            return newNode;
        }

        protected TCObjects.Buffer ModelAsBuffer {
            get { return Model as TCObjects.Buffer; }
        }

        public override void ObjectChanged(PersistableObject sender, ChangeAspect changeAspect) {
            base.ObjectChanged(sender, changeAspect);
        }

        public override void UpdateYourColumns() {
            base.UpdateYourColumns();

            if (IsColumnVisible(CustomTreeListSettings.Column_Value)) {
                SetColumnValue(CustomTreeListSettings.Column_Value, ModelAsBuffer.Value);
            }
        }

        protected override bool IsCellEditable(string fieldName) {
            if(ModelAsBuffer == null) {
                return false;
            }
            if(fieldName == CustomTreeListSettings.Column_Value) {
                return true;
            }
            return base.IsCellEditable(fieldName);
        }

        //override Column
    }
}
