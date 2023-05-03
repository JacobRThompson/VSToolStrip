﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.IconButtons
{
    public class IconToggleButton : IconPushButton
    {
        private bool _checked = false;

        public event EventHandler? CheckedChanged;

        [Category("Appearance")] public Image CheckedImage { get; set; } = new Bitmap(1, 1);
        [Category("Appearance")] public Image UncheckedImage { get; set; } = new Bitmap(1, 1);

        [Category("Appearance")] public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        public override Image BackgroundImage 
        {
            get => Checked? CheckedImage : UncheckedImage;
            set => base.BackgroundImage = value; 
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BackgroundImage = Checked ? CheckedImage : UncheckedImage;
        }
    }
}
