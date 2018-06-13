using Tricentis.TCAddIns.BufferArea.TCObjects;
using Tricentis.TCCore.BusinessObjects.Folders;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.Tasks;

namespace Tricentis.TCAddIns.BufferArea.Tasks {
    [TCTask(ReturnValue = typeof(Buffer))]
    public class CreateBufferTask : Task {
        public override string Name => "Create Buffer";

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
            Buffer buffer = Buffer.Create();
            buffer.Name = "Buffer";
            folder.Items.Add(buffer);
            buffer.EnsureUniqueNameIfNecessary();
            return buffer;
        }
    }
}
