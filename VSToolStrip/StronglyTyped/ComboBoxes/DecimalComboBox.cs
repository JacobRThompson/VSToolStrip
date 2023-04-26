using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;

namespace StronglyTypedControls.ComboBoxes
{
    [ToolboxItem(Globals.SHOW_IN_TOOLBOX)]
    public class DecimalComboBox : NumericComboBox<decimal>
    {
        protected override decimal FAILED_VALIDATION => decimal.MinValue;

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public NumberStyles InputStyle { get; set; } = NumberStyles.Currency;

        protected override Func<decimal, bool> IsGreaterThanMin =>
            (input) => (MinValue ?? decimal.MinValue) > input;
        protected override Func<decimal, bool> IsLessThanMax =>
            (input) => (MaxValue ?? decimal.MaxValue) < input;
        protected override Func<decimal, bool> IsNotDivisibleByModulo =>
             (input) =>
             {
                 var m = Modulus ?? input;
                 return m != 0 && (input % m != 0); //the m!=0 check is used to prevent division by zero
             };

        protected override void OnValidating(CancelEventArgs e)
        {

            if (decimal.TryParse(Trim(Text), InputStyle, CultureInfo.CurrentCulture, out decimal newValue))
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

            if (this.Value != FAILED_VALIDATION)
            {
                this.Value = newValue;
            }
            else
            {
                e.Cancel = true;
            }

            base.OnValidating(e);
        }
    }
}
