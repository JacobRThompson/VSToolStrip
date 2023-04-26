using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace StronglyTypedControls.ComboBoxes
{
    public  class NumericComboBox<TInput> : Message.MessageComboBox, INumericControl<TInput>, IStronglyTypedComboBox<TInput> where TInput :struct, IFormattable, IEquatable<TInput>
    {
        private List<TInput> _values = new();
        private TInput _value = new();

        protected virtual TInput FAILED_VALIDATION { get => throw new NotImplementedException(); }      
        protected virtual Func<TInput, bool> IsGreaterThanMin { get; } = (x) => throw new NotImplementedException();
        protected virtual Func<TInput, bool> IsLessThanMax { get; } = (x) => throw new NotImplementedException();
        protected virtual Func<TInput, bool> IsNotDivisibleByModulo { get; } = (x) => throw new NotImplementedException();

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public virtual TInput Value
        {
            get => this.Enabled? _value : FAILED_VALIDATION;
            set
            {
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

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public virtual List<TInput> Values
        {
            get => this.Enabled ? _values : new();
            set
            {
                _values = value;
                Items.Clear();
                Items.AddRange(
                     Values
                    .Select(GenText)
                    .ToArray());
            }
        }

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)] public bool RequiredLocally { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)] public bool RequiredGlobally { get; set; } = false;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string FormatPattern { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Suffix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Prefix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? MinValue { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? MaxValue { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(null)] public TInput? Modulus { get; set; }

        private bool HasMouse { get; set; }
        

        protected string GenText(TInput input)
        {
            string prefixPadding = (Prefix == string.Empty) ? string.Empty : " ";
            string suffixPadding = (Suffix == string.Empty) ? string.Empty : " ";

            return $"{Prefix}{prefixPadding}{Trim(input.ToString(FormatPattern, default))}{suffixPadding}{Suffix}";
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
            List<string> errorMessages = new();

            if (IsGreaterThanMin(input))
            {
                output = FAILED_VALIDATION;
                errorMessages.Add($"Value must be greater than {MinValue}");
            }
            if (IsLessThanMax(input))
            {
                output = FAILED_VALIDATION;
                errorMessages.Add($"Value must be less than {MaxValue}");
            }
            if (IsNotDivisibleByModulo(input))
            {
                output = FAILED_VALIDATION;
                errorMessages.Add($"Value must be divisible by {Modulus}");
            }

            Globals.SetErrorValidationFailed?.Invoke(this, string.Join("/n", errorMessages));
            return output;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            //We check if the user was the one who caused the index to change by checking mouse position. Raise validation if it was.
            if (HasMouse) { OnValidating(new()); }
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            HasMouse = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HasMouse = false;
            base.OnMouseLeave(e);
        }
    }
}
