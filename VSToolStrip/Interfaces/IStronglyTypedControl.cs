using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls
{
    public interface IStronglyTypedControl<TInput> where TInput : struct, IEquatable<TInput>
    {

        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public TInput Value { get; set; } 
        public bool RequiredLocally { get; set; }
        public bool RequiredGlobally { get; set; }
    }
}
