using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public class IsEmptyChangedEventArgs: EventArgs
    {
        public IsEmptyChangedEventArgs(bool isEmpty)
        {
            this.IsEmpty = isEmpty;
        }

        public readonly bool IsEmpty;
    }
}
