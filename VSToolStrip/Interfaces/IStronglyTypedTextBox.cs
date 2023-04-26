using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.TextBoxes
{
    public interface IStronglyTypedTextBox<TInput>: IStronglyTypedControl<TInput> where TInput : struct, IEquatable<TInput> 
    {
    }
}
