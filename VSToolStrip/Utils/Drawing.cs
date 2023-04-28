using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public static partial class Utils
    {
        private static  Random rng = new ();

        public static Color Lerp(Color a, Color b, float amount)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * amount),
                (int)(a.G + (b.G - a.G) * amount),
                (int)(a.B + (b.B - a.B) * amount));
        }

        public static Rectangle Deflate(this Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        public static Color ToOpaque(this Color c) => Color.FromArgb(255, c.R, c.G, c.B);

        public static Color GenRandomColor() => Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
    }
}
