using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tricentis.TCAddIns.BufferArea.Icons;
using Tricentis.TCAddIns.BufferArea.Tasks;
using Tricentis.TCCore.Icons;
using Tricentis.TCCore.Persistency;
using Tricentis.TCCore.Persistency.AddInManager;

namespace Tricentis.TCAddIns.BufferArea {
    public class BufferAreaAddIn : TCAddIn {
        public override string UniqueName => "BufferArea";

        public override void InitializeBeforeOpenWorkspace() {
            var test = AddInIcon.BufferAreaFolder;
            var test2 = AddInIcon.Buffer;
            InitializeIcons();
        }

        private static List<AddInIcon> icons = new List<AddInIcon>();

        public static List<AddInIcon> AddInIcons {
            get { return icons; }
        }

        private void InitializeIcons() {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string baseNameSpace = GetType().Namespace;

            foreach (BaseIcon icon in AddInIcons) {
                TCIcons.AddAddInIcon(currentAssembly, baseNameSpace + ".Icons.BaseIcons." + icon.ToString() + ".png", icon);
                TCIcons.AddAddInIcon(currentAssembly, baseNameSpace + ".Icons.BaseIcons." + icon.ToString() + "_Large.png", new BaseIcon(icon.ToString() + "_Large"));
            }
        }

        public override Dictionary<Type, object> TaskToIconDefinition {
            get {
                Dictionary<Type, object> taskToImageDict = new Dictionary<Type, object>();
                taskToImageDict.Add(typeof(CreateBuffertopFolderTask), new IconDefinition(AddInIcon.BufferAreaFolder));
                return taskToImageDict;
            }
        }

        public override void CreateTopFolder(PersistableObject obj) {
            if (CreateBuffertopFolderTask.TaskPossibleForProject(obj)) {
                Task task = TaskFactory.Instance.GetTask(typeof(CreateBuffertopFolderTask));
                task.Execute(obj, null);
            }
        }

        public override object GetIconByName(string name) {
            return AddInIcons.FirstOrDefault(icon => icon.Name == name);
        }
    }
}
