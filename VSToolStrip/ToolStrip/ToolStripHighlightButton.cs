using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

namespace VS.ToolStrip
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripHighlightButton : ToolStripButton, IHighlightRenderableButton
    {
        private bool _highlighted = false;

        public event EventHandler? HighlightedChanged;



        public virtual Color DefaultForeColor { get; set; } = SystemColors.ControlText;
        public virtual Font DefaultFont { get; set; } = new("Segoe UI", 9F, FontStyle.Regular);

        public PushButtonState ButtonState { get; set; } = PushButtonState.Normal;

        public virtual bool Highlighted
        {
            get => _highlighted;
            set
            {
                _highlighted = value;
                OnHighlightedChanged(EventArgs.Empty);
            }
        }

        public bool HasMouse => Bounds.Contains(Parent.PointToClient(Cursor.Position));

        protected virtual void OnHighlightedChanged(EventArgs e)
        {
            if (Highlighted)
            {
                Font = new Font(DefaultFont.FontFamily, DefaultFont.Size, FontStyle.Bold);
                ForeColor = SystemColors.HighlightText;
            }
            else
            {
                Font = DefaultFont;
                ForeColor = DefaultForeColor;
            }
            HighlightedChanged?.Invoke(this, e);
        }



        protected override void OnMouseLeave(EventArgs e)
        {
            if (!HasMouse)
            {
                base.OnMouseLeave(e);
                ButtonState = PushButtonState.Normal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (HasMouse)
            {
                base.OnMouseEnter(e);
                ButtonState = PushButtonState.Hot;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ButtonState = PushButtonState.Hot;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ButtonState = PushButtonState.Pressed;
        }


    }
}
