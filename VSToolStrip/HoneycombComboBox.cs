using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Honeycomb.UI
{

    public class HoneycombComboBox : ValidateOnEnterComboBox
    {

        //This is only used for ComboBoxes with DropDownStyle = DropDown
        private readonly Dictionary<int, bool> AllowHighlights = new();

        //This is only used for ComboBoxes with DropDownStyle = DropDownList
        private (int Index, string Text, Rectangle Bounds) _lastHighlighted = (-1, string.Empty, Rectangle.Empty);
        private bool _openingDropdown;
        private bool _dropdownOpen;

        private Action<EventArgs> _onDropDownClosedAction = delegate { };
        private Action<EventArgs> _onDropDownAction = delegate { };
        private Action<DrawItemEventArgs> _onDrawItemAction = delegate { };

        public HoneycombComboBox()
        {  
            OnDropDownStyleChanged(EventArgs.Empty); //Initialize event handlers
        }

        protected override void OnDropDownStyleChanged(EventArgs e)
        {
            base.OnDropDownStyleChanged(e);

            switch (DropDownStyle)
            {
                case ComboBoxStyle.DropDownList:
                    DrawMode = DrawMode.OwnerDrawFixed;
                    _onDropDownAction = OnDropDown_DropDownList;
                    _onDrawItemAction = OnDrawItem_DropDownList;
                    _onDropDownClosedAction = OnDropDownClosed_DropDownList;
                    break;

                default:
                    DrawMode = default;
                    _onDropDownAction = base.OnDropDown;
                    _onDrawItemAction = base.OnDrawItem; 
                    _onDropDownClosedAction = base.OnDropDownClosed;
                    break;
            }

        }


        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
        }

        protected override void OnDropDown(EventArgs e)
        {
            _onDropDownAction(e);
        }
      

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            _onDrawItemAction(e);
        }

        protected virtual void OnDropDown_DropDownList(EventArgs e)
        {
            base.OnDropDown(e);
            _openingDropdown = true;
            _dropdownOpen = true;
        }

        protected virtual void OnDropDownClosed_DropDownList(EventArgs e)
        {
            base.OnDropDownClosed(e);
            _dropdownOpen = false;
        }

        protected virtual void OnDrawItem_DropDownList(DrawItemEventArgs e)
        {

            var Brush = Brushes.Black;
            Color _backColor;

            string _text = e.Index != -1 ? Items[e.Index].ToString()! : this.Text;



            
            if (e.Index != _lastHighlighted.Index)
            {
                SuspendLayout();
                //If we are opening the dropdown, we prevent the control from highlighting the last item
                if (_openingDropdown & e.Index == Items.Count-1)
                {
                    _openingDropdown = false; 
                    _backColor = Color.White;
                }
                else
                {
                    _backColor = Color.LightBlue;
                }
               
                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);

                e.Graphics.FillRectangle(new SolidBrush(Color.White), _lastHighlighted.Bounds);
                e.Graphics.DrawString(_lastHighlighted.Text, Font, Brush, _lastHighlighted.Bounds, StringFormat.GenericDefault);

                _lastHighlighted = (e.Index, _text, e.Bounds);
                ResumeLayout();
            }
            else if (e.Bounds != _lastHighlighted.Bounds)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);
            }

            //Console.WriteLine($"currentIndex: {e.Index} \t hasMouse: ");
          
            
            

        }

    }

}
