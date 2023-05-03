using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.Interfaces
{
    public interface IHighlightableHoverable: IHighlightable
    {

        const float HOT_OPACITY = 0.33f;

        public PushButtonState ButtonState { get; set; }

    }

    public static class IHighlightablePushButtonExtensions
    {
        //public static Color GetBackColor(this IHighlightableHoverable obj)
        //{
           

        //}
    }
}
