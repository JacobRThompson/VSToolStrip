using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Honeycomb.UI.StronglyTypedControls.TextBoxes
{
    public abstract class NumericTextBox<TInput> : BaseComponents.MessageTextBox, INumericControl<TInput>, IStronglyTypedTextBox<TInput> where TInput: struct, IFormattable, IEquatable<TInput>
    {
       
        private TInput _value = new();
     
        protected virtual TInput FAILED_VALIDATION { get => throw new NotImplementedException(); }
        protected virtual Func<TInput, bool> IsGreaterThanMin { get; } = (x) => throw new NotImplementedException();
        protected virtual Func<TInput, bool> IsLessThanMax { get; } = (x) => throw new NotImplementedException();
        protected virtual Func<TInput, bool> IsDivisibleByModulo { get; } = (x) => throw new NotImplementedException();

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public virtual TInput Value
        {
            get => this.Enabled ? _value: FAILED_VALIDATION;
            set{

                if (!value.Equals(_value))
                {
                    _value = value;

                    if (value.Equals(FAILED_VALIDATION))
                    {
                        Text = String.Empty;
                    }
                    else
                    {
                        Text = GenText(value);
                    }
                }
            }
        }

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)] public bool RequiredLocally { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)] public bool RequiredGlobally{get; set; } = false;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string FormatPattern { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Suffix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Prefix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? MinValue { get; set; } 
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? MaxValue { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? Modulus {get; set; }



        protected string GenText(TInput input)
        {
            string prefixPadding = (Prefix == string.Empty) ? string.Empty : " ";
            string suffixPadding = (Suffix == string.Empty) ? string.Empty : " ";

            return $"{Prefix}{prefixPadding}{Trim(input.ToString(FormatPattern,default))}{suffixPadding}{Suffix}";
        }

        public string Trim(string input) => TrimPrefix(TrimSuffix(input));

        protected string TrimPrefix(string input)
        {
            if (Prefix != string.Empty)
            {
                int prefixIndex = input.IndexOf(Prefix);
                if (prefixIndex != -1)
                {
                    return input.Remove(prefixIndex, Prefix.Length);
                }
            }
            return input;
        }

        protected string TrimSuffix(string input)
        {
            if (Suffix != string.Empty)
            {
                int suffixIndex = input.LastIndexOf(Suffix);
                if (suffixIndex != -1)
                {
                    return input.Remove(suffixIndex, Suffix.Length);
                }
            }
            return input;
        }

        protected TInput ApplyRangeValidation(TInput input)
        {
            TInput output = input;
            List<string> msgs = new();

            if (IsGreaterThanMin(input))
            {
                output = FAILED_VALIDATION;
                msgs.Add($"Value must be greater than {MinValue}");
            }
            if (IsLessThanMax(input))
            {
                output = FAILED_VALIDATION;
                msgs.Add($"Value must be less than {MaxValue}");
            }
            if (IsDivisibleByModulo(input))
            {
                output = FAILED_VALIDATION;
                msgs.Add($"Value must be divisible by {Modulus}");
            }

            Globals.SetErrorValidationFailed?.Invoke(this, string.Join("/n", msgs));
            return output;
        }
    }
}
