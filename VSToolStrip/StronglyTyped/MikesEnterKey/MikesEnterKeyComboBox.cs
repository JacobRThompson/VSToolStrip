using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedControls.MikesEnterKey
{
    [ToolboxItem(Globals.SHOW_IN_TOOLBOX)]
    public class MikesEnterKeyComboBox: ComboBox
    {
        static bool IS_BOOMER_MODE = true;
        public MikesEnterKeyComboBox()
        {  
            if (IS_BOOMER_MODE) { this.DrawMode = DrawMode.OwnerDrawFixed; }          
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    OnValidating(new());
                    break;
            }

            base.OnKeyPress(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

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

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var Brush = Brushes.Black;

            var Point = new Point(2, e.Index * e.Bounds.Height + 1);
            int index = e.Index >= 0 ? e.Index : 0;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(Point, e.Bounds.Size));
            e.Graphics.DrawString(this.Items[index].ToString(), this.Font, Brush, e.Bounds, StringFormat.GenericDefault);
        }
    }
}
