﻿

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class MsgOnDisabledTextBox: ValidateOnEnterTextBox
    {

        private string _text = string.Empty;
        public string DisabledMsg { get; set; } = string.Empty;

        override public string Text
        {
            get => Enabled ? base.Text : _text;
            set
            {
                if (Enabled) 
                { 
                    base.Text = value; 
                }
                else
                {
                    _text = value;
                }
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                base.Text = _text;
            }
            else
            {
                base.Text = DisabledMsg;
            }
            base.OnEnabledChanged(e);
        }


        protected override void OnTextChanged(EventArgs e)
        {
            if(Enabled)
            {
                _text = base.Text;
            }

            base.OnTextChanged(e);
        }
    }
}
