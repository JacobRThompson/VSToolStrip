using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.IconButtons
{
    public abstract class IconControl: PictureBox, IHighlightable
    {
        protected const string IMAGE_CATEGORY = "Image";

        private PushButtonState _buttonState = PushButtonState.Normal;
        private bool _highlighted = false;


        public IconControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);  
        }


        public event EventHandler? HighlightedChanged;
        public event EventHandler? PushButtonStateChanged;

        [Category("Appearance"), Browsable(true)]
        public Color IconColor { get; set; } = SystemColors.ControlText;

        [Category("Appearance")]
        public bool Highlighted
        {
            get => _highlighted;
            set
            {
                _highlighted = value;
                OnHighlightChanged(EventArgs.Empty);
            }
        }
      
        protected virtual PushButtonState ButtonState
        {
            get => _buttonState;
            set
            {
                if (value != ButtonState)
                {
                    _buttonState = value;
                    Invalidate();
                   
                }
            }
        }

        Color IHighlightable.ForeColor
        {
            get => IconColor;
            set => IconColor = value;
        }

        protected virtual void OnPushButtonStateChanged(EventArgs e)
        {
            Invalidate();
            PushButtonStateChanged?.Invoke(this, e);
        }

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }

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

