using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tricentis.TCCore.BusinessObjects;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.AddInManager;

namespace Tricentis.TCAddIns.BufferArea.Tasks.Interceptors {
    public class TCProjectTaskInterceptor : TaskInterceptor {
        public TCProjectTaskInterceptor(TCProject obj) { }

        public override void GetTasks(PersistableObject obj, List<TCCore.Persistency.Task> tasks) {
            if(!CreateBuffertopFolderTask.TaskPossibleForProject(obj)) {
                return;
            }
            tasks.Add(TaskFactory.Instance.GetTask(typeof(CreateBuffertopFolderTask)));
        }
    }
}
