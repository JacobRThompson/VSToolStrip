using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
namespace StronglyTypedControls
{
    public interface INumericControl<TInput>: IStronglyTypedControl<TInput> where TInput : struct, IFormattable, IEquatable<TInput> 
    {
        public TInput? MinValue { get; set; }
        public TInput? MaxValue { get; set; }
        public TInput? Modulus { get; set; }

        public string FormatPattern { get; set; }
    }
}
