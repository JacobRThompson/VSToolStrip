using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
namespace Honeycomb.UI
{
    public class HoneycombListBox:ListBox
    {
        int _dummyIndex = 0;
        int _hoverIndex = -1;
        int _prevSelectedIndex = -1;

        bool _mouseDown = false;

        public HoneycombListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DoubleBuffered = true;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {        
            _dummyIndex++;
          
            PushButtonState itemState = 
                e.Index != _hoverIndex ? PushButtonState.Normal:
                    _mouseDown ? PushButtonState.Pressed : PushButtonState.Hot;

            e.Graphics.DrawButtonBackground(itemState, false, IsOutlinedOnDraw(e.Index), this.BackColor, this.BackColor, e.Bounds , outlineByDefault:false);
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds, System.Drawing.StringFormat.GenericDefault);
            base.OnDrawItem(e);
        }

        public override int SelectedIndex {
            get => base.SelectedIndex;
            set 
            { 
                _prevSelectedIndex = base.SelectedIndex;
                base.SelectedIndex = value; 
            } 
        }
        /// <summary> Returns true if the item at the specified index is outlined </summary>
        bool IsOutlinedOnDraw(int index) => index == SelectedIndex | index == _prevSelectedIndex;
        

        protected override void OnClick(EventArgs e)
        {
            //Check the item we are currently hovering over if we are hovering over an item
            if (_hoverIndex != -1){SelectedIndex = _hoverIndex;}
            base.OnClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            base.OnMouseDown(e);
            _mouseDown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            
            base.OnMouseUp(e);
            _mouseDown = false;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int index = IndexFromPoint(e.Location);
            if (index != _hoverIndex)
            {

                _hoverIndex = index;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hoverIndex = -1;
            Invalidate();
        }
    }
}
