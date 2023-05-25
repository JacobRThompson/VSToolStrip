using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.Interfaces
{
    public interface IHoverable
    {
        public PushButtonState ButtonState { get; set; }

        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }


        /// <summary>  Color used for background when the user is hovering over the control with a mouse, etc. </summary>
        public Color HotBackColor { get; set; }

        /// <summary>  Color used for foreground when the user is hovering over the control with a mouse, etc. </summary>
        public Color HotForeColor { get; set; }

    }

    public static class IHighlightablePushButtonExtensions
    {
        public static Color GetBackColor(this IHoverable obj)
        {
            return obj.ButtonState switch
            {
                PushButtonState.Hot => obj.HotBackColor,
                _ => obj.BackColor,
            };
        }
    }
}
