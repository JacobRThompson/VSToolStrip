using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedControls.MikesEnterKey
{
    [ToolboxItem(Globals.SHOW_IN_TOOLBOX)]
    public  class MikesEnterKeyTextBox: TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    OnValidating(new());
                break;
            }

            base.OnKeyPress(e);
        }
    }
}
