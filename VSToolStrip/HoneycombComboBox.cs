using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{

    public class HoneycombComboBox : ValidateOnEnterComboBox
    {

        private List<Rectangle> itemRectangles = new List<Rectangle>();
        private int lastHighlightedIndex;




        static bool IS_BOOMER_MODE = true;
        public HoneycombComboBox()
        {
            if (IS_BOOMER_MODE) { DrawMode = DrawMode.OwnerDrawVariable; }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                SizeF stringSize = e.Graphics.MeasureString(Items[e.Index].ToString(), Font);
                e.ItemHeight = (int)stringSize.Height;

                int itemTop = 0;
                if (e.Index > 0)
                {
                    itemTop = itemRectangles[e.Index - 1].Bottom;
                }
                Rectangle itemRectangle = new Rectangle(0, itemTop, Width - SystemInformation.VerticalScrollBarWidth, e.ItemHeight);
                itemRectangles.Add(itemRectangle);
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IS_BOOMER_MODE && Items.Count > 0)
            {
                var dropDownRect = RectangleToScreen(ClientRectangle);
                dropDownRect.Y += Height;
                dropDownRect.Height = DropDownHeight;

                if (dropDownRect.Contains(e.Location))
                {
                    int itemIndex = -1;

                    for (int i = 0; i < itemRectangles.Count; i++)
                    {
                        if (itemRectangles[i].Contains(e.Location))
                        {
                            itemIndex = i;
                            break;
                        }
                    }

                    if (itemIndex != lastHighlightedIndex)
                    {
                        lastHighlightedIndex = itemIndex;
                        Invalidate();
                    }
                }
            }

            base.OnMouseMove(e);
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {


            if (IS_BOOMER_MODE & DropDownStyle == ComboBoxStyle.DropDownList)
            {
                pevent.Graphics.Clear(Color.White);
                base.OnPaint(pevent);
            }
            else
            {
                base.OnPaintBackground(pevent);
            }

        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var Brush = Brushes.Black;

            Rectangle itemRectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);

            Brush backBrush;

            if (this.HasMouse(itemRectangle))
            {
                backBrush = new SolidBrush(
                    lastHighlightedIndex switch
                    {
                        -1=> Color.Fuchsia,
                        0 => Color.Lime,
                        1 => Color.Cyan,
                        2 => Color.Magenta,
                        3 => Color.Yellow,
                        _=> Color.Black
                    });
            }
            else
            {
                backBrush = new SolidBrush(
                    
                    e.Index switch
                    {
                        0=>Color.Orange,
                        1=>Color.Green,
                        2=>Color.Blue,
                        3=>Color.Red,
                        _=>Color.Purple

                    });
            }
           
            int index = e.Index >= 0 ? e.Index : 0;
            e.Graphics.FillRectangle(backBrush, itemRectangle);
            e.Graphics.DrawString(Items[index].ToString(), Font, Brush, e.Bounds, StringFormat.GenericDefault);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

    }

}
