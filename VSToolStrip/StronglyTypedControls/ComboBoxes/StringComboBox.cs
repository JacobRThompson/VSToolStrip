using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class StringComboBox: HoneycombComboBox
    {
        private List<string> _values = new();
        private string _value = string.Empty;

        protected virtual string FAILED_VALIDATION { get => string.Empty; }

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY)]
        public virtual List<string> Values
        {
            get => this.Enabled ? _values : new();
            set  
            {
                var prevSelectedItem = SelectedItem;

                Items.Clear();
                Items.AddRange(
                     value
                    .Select(GenText)
                    .ToArray());

                if (Items.Contains(prevSelectedItem))
                {
                    SelectedItem = prevSelectedItem;
                }

                _values = value;

#if !DEBUG 
                OnIsEmptyChanged(new(_values.Count == 0));
#endif
            }
        }

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

        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(true)]  public bool DisableOnEmpty { get; set; } = true;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)]  public bool RequiredLocally { get; set; }
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue(false)]  public bool RequiredGlobally { get; set; } = false;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Suffix { get; set; } = String.Empty;
        [Category(Globals.TYPED_CONTROL_ROOT_CATEGORY), DefaultValue("")] public string Prefix { get; set; } = String.Empty;

        public string Trim(string input) => TrimPrefix(TrimSuffix(input));



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
            base.OnValidating(e);
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            //We check if the user was the one who caused the index to change by checking mouse position. Raise validation if it was.
            if (this.HasMouse() | this.DropDownOpened) { OnValidating(new()); }
            base.OnSelectedIndexChanged(e);
        }

        
    }
}
