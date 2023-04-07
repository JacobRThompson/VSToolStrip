using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace VSToolStrip.IconButtons
{
    public abstract class IconControl: PictureBox
    {
        protected const string IMAGE_CATEGORY = "Image";

        private PushButtonState _buttonState = PushButtonState.Normal;

        protected virtual PushButtonState ButtonState
        {
            get => _buttonState;
            set
            {
                if (value != ButtonState)
                {
                    _buttonState = value;
                    PaintState();
                }
            }
        }

        abstract protected void PaintState();
      

        protected override void OnMouseEnter(EventArgs e)
        {
            ButtonState = PushButtonState.Hot;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            ButtonState = PushButtonState.Pressed;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ButtonState = PushButtonState.Hot;
            base.OnMouseUp(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            ButtonState = PushButtonState.Normal;
            base.OnMouseLeave(e);
        }
    }
}

