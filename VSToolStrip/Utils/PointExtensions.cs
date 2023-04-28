using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public static partial class Utils 
    {
        public static Point Subtract(this Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
        public static Point  Add(this Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
    }
}
