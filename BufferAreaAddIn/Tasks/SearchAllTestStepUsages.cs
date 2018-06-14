using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.TCCore.Base;
using Tricentis.TCCore.Base.Tasks;
using Tricentis.TCCore.BusinessObjects;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.AddInManager;
using Tricentis.TCCore.Persistency.Tasks;

namespace Tricentis.TCAddIns.BufferArea.Tasks {
    public class SearchAllTestStepUsages : SearchAllTask {
        public override string Name => "Search all TestSteps";

        protected override string GetTQLSearchString => string.Empty;

        public override object Execute(List<PersistableObject> objs, ITaskContext context) {
            List<PersistableObject> objectsToDisplay = new List<PersistableObject>();
            foreach(PersistableObject obj in objs) {
                TCObjects.Buffer buffer = obj as TCObjects.Buffer;
               // TCProject project = Workspace.ActiveWorkspace.Project;

            }
            context.ShowObjectList(objectsToDisplay);
            return null;
        }
    }
}
