using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public interface IHighlightable
    {

        public event EventHandler HighlightedChanged;

        public bool Highlighted { get; set; }

    }
}
