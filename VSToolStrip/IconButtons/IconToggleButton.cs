using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace VSToolStrip.IconButtons
{
    public class IconToggleButton : IconControl
    {
        private bool _checked = false;

        [Category(IMAGE_CATEGORY)] public Image DefaultCheckedImage { get; set; } = new Bitmap(1, 1);
        [Category(IMAGE_CATEGORY)] public Image DefaultUncheckedImage { get; set; } = new Bitmap(1, 1);


        [Category(IMAGE_CATEGORY)] public Image HotCheckedImage { get; set; } = new Bitmap(1, 1);
        [Category(IMAGE_CATEGORY)] public Image HotUncheckedImage { get; set; } = new Bitmap(1, 1);

        [Category(IMAGE_CATEGORY)] public Image PressedCheckedImage { get; set; } = new Bitmap(1, 1);
        [Category(IMAGE_CATEGORY)] public Image PressedUncheckedImage { get; set; } = new Bitmap(1, 1);

        [Category(IMAGE_CATEGORY)] public Image DisabledCheckedImage { get; set; } = new Bitmap(1, 1);
        [Category(IMAGE_CATEGORY)] public Image DisabledUncheckedImage { get; set; } = new Bitmap(1, 1);

        public event EventHandler? CheckedChanged;

        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                OnCheckedChanged(EventArgs.Empty);
                
            }
        }

        protected override void PaintState()
        {
            switch (ButtonState)
            {
                case PushButtonState.Normal:
                    base.BackgroundImage = Checked ? DefaultCheckedImage : DefaultUncheckedImage;
                    break;

                case PushButtonState.Hot:
                    base.BackgroundImage = Checked ? HotCheckedImage : HotUncheckedImage;
                    break;

                case PushButtonState.Pressed:
                    base.BackgroundImage = Checked ? PressedCheckedImage : PressedUncheckedImage;
                    break;

                case PushButtonState.Disabled:
                    base.BackgroundImage = Checked ? DisabledCheckedImage : DisabledUncheckedImage;
                    break;
            }
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
            PaintState();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BackgroundImage = Checked ? DefaultCheckedImage : DefaultUncheckedImage;
        }
    }
}
