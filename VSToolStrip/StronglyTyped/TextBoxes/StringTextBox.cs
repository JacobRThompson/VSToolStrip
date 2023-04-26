using StronglyTypedControls.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedControls.TextBoxes
{
    [ToolboxItem(Globals.SHOW_IN_TOOLBOX)]
    public class StringTextBox: MessageTextBox
    {
        private string _value = string.Empty;

        protected virtual string FAILED_VALIDATION { get => string.Empty; }

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public virtual string Value
        {
            get => this.Enabled ? _value : FAILED_VALIDATION;
            set
            {
                value ??= String.Empty; //Filter out null values
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
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)] public bool RequiredGlobally { get; set; } = false;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Suffix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Prefix { get; set; } = String.Empty;

        public string Trim(string input) => TrimPrefix(TrimSuffix(input));

        protected override void OnValidating(CancelEventArgs e)
        {
            var newValue = Trim(Text);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                if (RequiredLocally) { Globals.SetErrorRequiredLocally?.Invoke(this, Globals.RequiredLocallyMsg); }
                if (RequiredGlobally) { Globals.SetErrorRequiredGlobally?.Invoke(this, Globals.RequiredGloballyMsg); }

                newValue = FAILED_VALIDATION;
            }
            else
            {
                if (RequiredLocally) { Globals.SetErrorRequiredLocally?.Invoke(this, string.Empty); }
                if (RequiredGlobally) { Globals.SetErrorRequiredGlobally?.Invoke(this, string.Empty); }
            }

            this.Value = newValue;

            if (this.Value == FAILED_VALIDATION)
            {
                e.Cancel = true;
            }
        }

        protected string GenText(string input)
        {
            string prefixPadding = (Prefix == string.Empty) ? string.Empty : " ";
            string suffixPadding = (Suffix == string.Empty) ? string.Empty : " ";

            return $"{Prefix}{prefixPadding}{Trim(input)}{suffixPadding}{Suffix}";
        }

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
    }
}

