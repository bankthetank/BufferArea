using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Data.Model;
using Tricentis.TCCore.Base.Folders;
using Tricentis.TCCore.Base.Ownership;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.MetaInfo;

namespace Tricentis.TCAddIns.BufferArea.TCObjects {
    [TypeMetaInfo]
    [TCSupportedFolderPolicy("TestCaseDesign")]
    public class Buffer : OwnedItem {
        private Buffer() { }

        private Buffer(Surrogate surrogate) : base(surrogate) { }

        public static Buffer Create(TCUser creator) {
            Buffer buffer = new Buffer();
            buffer.InitAssociations();
            buffer.InitializeNewOwnedItem(creator);
            return buffer;
        }

        public static Buffer Create() {
            return Create(LoginUser);
        }

        public static Buffer Create(Surrogate surrogate) {
            Buffer buffer = new Buffer(surrogate);
            buffer.InitAssociations();
            return buffer;
        }

        public override void GetTasks(List<TCCore.Persistency.Task> taskList) {
            // search all etc
            base.GetTasks(taskList);
        }
    }
}
