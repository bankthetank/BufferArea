using DevExpress.XtraTreeList.Columns;
using System.Collections.Generic;
using Tricentis.TCCore.GUI.DetailView;
using Tricentis.TCCore.ModelViewConnector;
using Tricentis.TCCore.ModelViewConnector.Columns;
using Tricentis.TCCore.Persistency;

namespace Tricentis.TCAddIns.BufferArea.GUI.DetailView {
    public class CustomTreeListSettings {
        public const string Column_Name = "Name";
        public const string Column_Value = "Value";
        public const string Column_Description = "Description";
        public const string Column_IsUsed = "IsUsed";

        private static CustomTreeListSettings instance;

        private Dictionary<ColumnsSetting, List<ColumnParameter>> columnSettings = new Dictionary<ColumnsSetting, List<ColumnParameter>>(3);

        private CustomTreeListSettings() {
            InitializeBufferColumns();
        }

        public static CustomTreeListSettings Instance {
            get {
                if (instance == null) {
                    instance = new CustomTreeListSettings();
                }
                return instance;
            }
        }

        public Dictionary<ColumnsSetting, List<ColumnParameter>> ColumnSettings {
            get { return columnSettings; }
        }

        public List<object> GetColumnSettingsFor(object columnSetting) {
            ColumnsSetting colSetting;
            try {
                colSetting = (ColumnsSetting)columnSetting;
            } catch {
                return null;
            }

            if (ColumnSettings.ContainsKey(colSetting)) {
                List<object> retVal = new List<object>();
                foreach (ColumnParameter parameter in ColumnSettings[colSetting]) {
                    retVal.Add(parameter);
                }
                return retVal;
            }
            return null;
        }

        private void InitializeBufferColumns() {
            List<ColumnParameter> columnList = new List<ColumnParameter>();
            columnList.Add(new ColumnParameter(Column_Name, 1));
            columnList.Add(new ColumnParameter(Column_Value, -1));
            columnList.Add(new ColumnParameter(Column_Description, -1));
            columnList.Add(new ColumnParameter(Column_IsUsed, -1));
            columnSettings.Add(ColumnsSetting.TestCaseDesign, columnList);
        }

        public void ShowCustomColumns(PersistableObject obj, object currentTreeList) {
            CustomTreeList treeList = currentTreeList as CustomTreeList;
            if (treeList == null) { return; }

            List<TreeListColumn> columnsToAdd = new List<TreeListColumn>();
            foreach (TreeListColumn column in CreateColumns(ColumnsSetting.TestCaseDesign)) {
                bool alreadyFound = (treeList.Columns.ColumnByFieldName(column.FieldName) != null);
                if (!alreadyFound) {
                    columnsToAdd.Add(column);
                }
            }
            treeList.Columns.AddRange(columnsToAdd.ToArray());
            // treeList.Columns.AddRange(CreateColumns(ColumnsSetting.TestCaseDesigns));
        }

        private TreeListColumn[] CreateColumns(ColumnsSetting current) {
            List<ColumnParameter> currentColumns = columnSettings[current];
            TreeListColumn[] retVal = new TreeListColumn[currentColumns.Count];

            int counter = 0;
            foreach (ColumnParameter parameter in currentColumns) {
                switch (parameter.FieldName) {
                    case Column_Name:
                        retVal[counter] = GetNameColumn();
                        break;
                    case Column_Description:
                        retVal[counter] = GetDescriptionColumn();
                        break;
                    case Column_Value:
                        retVal[counter] = GetValueColumn();
                        break;
                    case Column_IsUsed:
                        retVal[counter] = GetIsUsedColumn();
                        break;
                    default:
                        break;
                }
                retVal[counter].VisibleIndex = parameter.VisibleIndex;
                counter++;
            }
            return retVal;
        }

        public static TreeListColumn GetNameColumn() {
            NameTreeListColumn column = new NameTreeListColumn();
            column.Caption = "Name";
            column.FieldName = Column_Name;
            column.Width = 220;
            column.MinWidth = 30;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowMove = false;
            column.VisibleIndex = 1;
            column.Fixed = FixedStyle.Left;
            return column;
        }

        public static TreeListColumn GetValueColumn() {
            TreeListColumn column = new TreeListColumn();
            column.Caption = "Value";
            column.FieldName = Column_Value;
            column.Width = 220;
            column.MinWidth = 30;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowMove = false;
            column.Fixed = FixedStyle.Left;
            column.AppearanceCell.Options.UseTextOptions = true;
            column.VisibleIndex = 2;
            return column;
        }

        public static TreeListColumn GetDescriptionColumn() {
            TreeListColumn column = new TreeListColumn();
            column.Caption = "Description";
            column.FieldName = Column_Description;
            column.Width = 220;
            column.MinWidth = 30;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowMove = false;
            column.Fixed = FixedStyle.Left;
            column.AppearanceCell.Options.UseTextOptions = true;
            column.VisibleIndex = 3;
            return column;
        }

        public static TreeListColumn GetIsUsedColumn() {
            TreeListColumn column = new TreeListColumn();
            column.Caption = "Is Used";
            column.FieldName = Column_IsUsed;
            column.Width = 220;
            column.MinWidth = 30;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowMove = true;
            column.Fixed = FixedStyle.Left;
            column.AppearanceCell.Options.UseTextOptions = true;
            column.VisibleIndex = 4;
            return column;
        }
    }
}
