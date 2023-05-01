using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class BooleanComboBox : HoneycombComboBox, IStronglyTypedComboBox<bool>
    {
        const string YES = "Yes";
        const string NO = "No";

        private bool _initialized = false;
        private bool? _value;
        private List<bool> _values = new();



        public BooleanComboBox()
        {
            this.Values = new List<bool> {false, true};
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public List<bool> Values 
        { 
            get => Enabled ? _values : new();
            set
            {
                _values = value;
                Items.Clear();
                Items.AddRange(
                    Values
                    .Select(x => x? YES : NO)
                    .ToArray());
            }
        }

        public string Suffix { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public bool Value 
        {
            get
            {
                if (this.Enabled && _value.HasValue)
                {
                    return _value.Value;
                }
                else
                {
                    return false;
                }
            }
            set 
            {
                if(_value != value)
                {
                    _value = value;
                    Text = value ? YES : NO;                  
                }  
            } 
        }
        public bool RequiredLocally { get ; set; }
        public bool RequiredGlobally { get; set ; }

        protected override void OnValidating(CancelEventArgs e)
        {
            this.Value = Text.Replace(" ","") switch
            {
                YES => true,
                NO => false,
                "" => false,
                _ => throw new InvalidOperationException()
            };
            
            base.OnValidating(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled &! _initialized) 
            {
                Values = new() { false, true };
                _initialized = true;
            }

            base.OnEnabledChanged(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            OnValidating(new());
            base.OnSelectedIndexChanged(e);
        }

       
    }
}
