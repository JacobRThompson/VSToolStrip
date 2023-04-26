using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS.ToolStrip
{
    public interface IHighlightable
    {

        public event EventHandler HighlightedChanged;

        public bool Highlighted { get; set; }

    }
}
