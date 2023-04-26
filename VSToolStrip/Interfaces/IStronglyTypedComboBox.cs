using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    public interface IStronglyTypedComboBox<TInput>: IStronglyTypedControl<TInput> where TInput : struct, IEquatable<TInput>
    {
        public List<TInput> Values { get; set;}
    }
}
