﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class ValidateOnEnterComboBox: ComboBox
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

       
    }
}
