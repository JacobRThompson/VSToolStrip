using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace VSToolStrip
{
    public interface IHighlightRenderableButton: IHighlightable
    {
        public bool Checked { get; set; }
        public Color BackColor { get; set; }

        public Size Size { get; set; }
        public PushButtonState ButtonState { get; set; }
        public ToolStrip Owner { get; set; }

    }
}
