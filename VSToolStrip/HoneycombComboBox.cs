﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Honeycomb.UI
{

    public class HoneycombComboBox : MsgOnDisabledComboBox
    {
        /// <summary>
        /// How long we wait after calling OnDropDownClosed before updating the DropDownOpened property. 
        /// Used to work around jank caused by how WinForms handles differing drop down styles 
        /// </summary>
        const int CLOSURE_GRACE_PERIOD_MS = 25;
        private readonly Stopwatch _stopwatch = new();
        private bool _dropDownOpened = false;

        private readonly object _lock = new();

        //This is only used for ComboBoxes with DropDownStyle = DropDownList
        private (int Index, string Text, Rectangle Bounds) _lastHighlighted = (-1, string.Empty, Rectangle.Empty);


        private Action<EventArgs> _onDropDownClosedAction = delegate { };
        private Action<EventArgs> _onDropDownAction = delegate { };
        private Action<DrawItemEventArgs> _onDrawItemAction = delegate { };

        public HoneycombComboBox()
        {
            OnDropDownStyleChanged(EventArgs.Empty); //Initialize event handlers
            _stopwatch.Start();
        }

        public event EventHandler<IsEmptyChangedEventArgs>? IsEmptyChanged;

        

        public bool DropDownOpened 
        {
            get
            {
                lock(_lock)
                {
                    if (_dropDownOpened) 
                    {
                        return true;
                    }
                    else
                    {
                        return _stopwatch.ElapsedMilliseconds <= CLOSURE_GRACE_PERIOD_MS;
                    }
                }
            }
            set 
            {
                lock (_lock)
                {
                    if (value)
                    {
                        _dropDownOpened = true;
                    }
                    else
                    {
                        _dropDownOpened = false;
                        _stopwatch.Restart();                     
                    }
                }
               
            } 
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

            AdjustControlSize();
        }


        protected virtual void OnIsEmptyChanged(IsEmptyChangedEventArgs e)
        { 
                IsEmptyChanged?.Invoke(this, e); 
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            DropDownOpened = false;
            base.OnDropDownClosed(e);        
        }

        protected override void OnDropDown(EventArgs e)
        {
            DropDownOpened = true;
            _onDropDownAction(e);
        }
      

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            _onDrawItemAction(e);
        }

        protected virtual void OnDropDown_DropDownList(EventArgs e)
        {
            base.OnDropDown(e);
            
        }

        protected virtual void OnDropDownClosed_DropDownList(EventArgs e)
        {
            base.OnDropDownClosed(e);

        }

        readonly Color HOT_COLOR = Color.LightBlue;
        readonly Color BACK_COLOR = Color.White;

        protected virtual void OnDrawItem_DropDownList(DrawItemEventArgs e)
        {

            var Brush = Brushes.Black;
            Color _backColor;

            string _text = e.Index != -1 ? Items[e.Index].ToString()! : this.Text;

            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
            {     
                _backColor = this.HasMouse()? HOT_COLOR : BACK_COLOR;

                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);
                //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
            else if (e.Index != _lastHighlighted.Index)
            {
                SuspendLayout();
                //If we are opening the dropdown, we prevent the control from highlighting the last item
                if (DropDownOpened & e.Index == Items.Count-1)
                {
                    DropDownOpened = false; 
                    _backColor = BACK_COLOR;
                }
                else
                {
                    _backColor = HOT_COLOR;
                }
               
                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);

                e.Graphics.FillRectangle(new SolidBrush(BACK_COLOR), _lastHighlighted.Bounds);
                e.Graphics.DrawString(_lastHighlighted.Text, Font, Brush, _lastHighlighted.Bounds, StringFormat.GenericDefault);

                _lastHighlighted = (e.Index, _text, e.Bounds);
                ResumeLayout();
            }
            else if (e.Bounds != _lastHighlighted.Bounds)
            {
                e.Graphics.FillRectangle(new SolidBrush(BACK_COLOR), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);
            }

            //Console.WriteLine($"currentIndex: {e.Index} \t pos: {e.Bounds.GetCenter()} ");
        }

        private void AdjustControlSize()
        {
            // Calculate the height of the control based on the font size and the padding
            ItemHeight = (int)this.Font.GetHeight() + this.Padding.Top + this.Padding.Bottom + 2;

           
        }

        public int CalcDropDownWidth()
        {
            int maxWidth = this.Width, currentWidth = 0;
            foreach (var obj in Items)
            {
                currentWidth = TextRenderer.MeasureText(obj.ToString() + "  ", Font).Width;
                if (currentWidth > maxWidth)
                {
                    maxWidth = currentWidth;
                }
            }
            return maxWidth;
        }
    }

}
