using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    public class HighlightLabel : Label, IHighlightable
    {

        private bool _highlighted = false;


        public event EventHandler? HighlightedChanged;

        public bool Highlighted
        {
            get => _highlighted;
            set
            {
                _highlighted = value;
                OnHighlightChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }


        public override Color ForeColor
        {
            get => Highlighted ? SystemColors.HighlightText : base.ForeColor;
            set => base.ForeColor = value;
        }

    }
}
