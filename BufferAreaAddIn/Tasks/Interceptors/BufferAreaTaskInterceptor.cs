using System;
using System.Collections.Generic;
using Tricentis.TCCore.BusinessObjects.Folders;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.AddInManager;

namespace Tricentis.TCAddIns.BufferArea.Tasks.Interceptors {
    public class BufferAreaTaskInterceptor : TaskInterceptor {
        public BufferAreaTaskInterceptor(TCFolder folder) { }

        public override void GetTasks(PersistableObject obj, List<TCCore.Persistency.Task> tasks) {
            if(CreateBufferTask.IsTaskPossible(obj as TCFolder)) {
                tasks.Add(TaskFactory.Instance.GetTask(typeof(CreateBufferTask)));
                tasks.Add(TaskFactory.Instance.GetTask(typeof(ReloadBuffersTask)));
            }
        }
    }
}
