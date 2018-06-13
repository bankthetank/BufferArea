using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Tricentis.TCCore.Icons;

namespace Tricentis.TCAddIns.BufferArea.Icons {
    public class AddInIcon : BaseIcon {
        #region Static Fields

        public static readonly AddInIcon BufferAreaFolder = new AddInIcon("BufferAreaFolder");
        public static readonly AddInIcon Buffer = new AddInIcon("Buffer");

        #endregion

        #region Constructors and Destructors

        public AddInIcon(string name) {
            this.name = name;
            BufferAreaAddIn.AddInIcons.Add(this);
        }

        #endregion
    }
}