using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tricentis.Data.Model;
using Tricentis.TCAddIns.BufferArea.Tasks;
using Tricentis.TCCore.Base.Folders;
using Tricentis.TCCore.Base.Ownership;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.Commands;
using Tricentis.TCCore.Persistency.Commands.Generic;
using Tricentis.TCCore.Persistency.MetaInfo;

namespace Tricentis.TCAddIns.BufferArea.TCObjects {
    [TypeMetaInfo]
    [TCSupportedFolderPolicy("TestCaseDesign")]
    public class Buffer : OwnedItem {
        #region Fields

        private string bufferValue = "";

        #endregion

        #region Aspects

        public new class Aspects {
            public static ChangeAspect Value = new ChangeAspect("Buffer.Value");
        }

        #endregion

        #region Properties

        [AttributeMetaInfo(true, DisplayFormat.String)]
        public string Value {
            get { return bufferValue; }
            set {
                if(bufferValue == value) { return; }
                using(Transaction t = CommandHandler.Instance.BeginTransaction(new CommandDescription("Set Value", "Set Value"))) {
                    Command c = new GenericSetCommand<string>(SetBufferValueOperation, value, bufferValue, this);
                    c.Execute();
                }
            }
        }

        private void SetBufferValueOperation(string val) {
            bufferValue = val;
            AspectChanged(Aspects.Value);
        }

        #endregion

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

            taskList.Add(TaskFactory.Instance.GetTask(typeof(SearchAllTestStepUsages)));
        }
    }
}
