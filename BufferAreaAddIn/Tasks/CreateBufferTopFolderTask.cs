using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.TCCore.BusinessObjects;
using Tricentis.TCCore.BusinessObjects.Folders;
using Tricentis.TCCore.BusinessObjects.Tasks;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.Tasks;

namespace Tricentis.TCAddIns.BufferArea.Tasks {
    [TCTask(ReturnValue = typeof(TCFolder))]
    public class CreateBuffertopFolderTask : CreateFolderWithSpecialPolicyTask {
        public override string Name => "Create Buffer Folder";

        protected override string InitialName => "Buffer Area";

        protected override TCFolderPolicy PolicyToUse => TCFolderPolicy.CreateTestCaseDesignOnlyPolicy();

        public static bool TaskPossibleForProject(PersistableObject obj) {
            TCProject project = obj as TCProject;

            if (project == null) { return false; }

            foreach (TCFolder fd in project.Items) {
                // if (fd.ContentPolicy.TestPlanningAllowed) {
                //     return false;
                // }
                return true;
            }
            return true;
        }

        public override object Execute(PersistableObject obj, ITaskContext context) {
            if (!TaskPossibleForProject(obj) /*&& !IsPossibleFor(obj)*/)
                return null;
            return CreateNewFolder(obj, context);
        }
    }
}
