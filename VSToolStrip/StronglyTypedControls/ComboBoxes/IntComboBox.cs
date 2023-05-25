using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class IntComboBox : NumericComboBox<int>
    {
        protected override int FAILED_VALIDATION => int.MinValue;

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public NumberStyles InputStyle { get; set; } = NumberStyles.Currency;

        protected override Func<int, bool> IsGreaterThanMin =>
            (input) => (MinValue ?? decimal.MinValue) > input;
        protected override Func<int, bool> IsLessThanMax =>
            (input) => (MaxValue ?? decimal.MaxValue) < input;
        protected override Func<int, bool> IsNotDivisibleByModulo => 
            (input) =>
            {
                var m = Modulus ?? input; 
                return m != 0  && input % (m) != 0; //the m!=0 check is used to prevent division by zero
            };
           
        protected override void OnValidating(CancelEventArgs e)
        {

            if (int.TryParse(Trim(Text), InputStyle, CultureInfo.CurrentCulture, out int newValue))
            {
                if (RequiredLocally) { Globals.SetErrorRequiredLocally?.Invoke(this, string.Empty); }
                if (RequiredGlobally) { Globals.SetErrorRequiredGlobally?.Invoke(this, string.Empty); }

                newValue = ApplyRangeValidation(newValue);
            }
            else
            {
                if (RequiredLocally) { Globals.SetErrorRequiredLocally?.Invoke(this, Globals.RequiredLocallyMsg); }
                if (RequiredGlobally) { Globals.SetErrorRequiredGlobally?.Invoke(this, Globals.RequiredGloballyMsg); }
                newValue = FAILED_VALIDATION;
            }

            if (newValue == FAILED_VALIDATION)
            {
                e.Cancel = true;
            }
            this.Value = newValue;

            base.OnValidating(e);
        }

       
    }

   
}
