using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            // Set the DropDownList style
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Call the base implementation first
            base.OnDrawItem(e);

            if (e.Index < 0)
            {
                return;
            }

            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
            {
                return;
            }

            // Get the text of the item being drawn
            string text = this.GetItemText(this.Items[e.Index]);

            // Draw a rectangle around the text
            Rectangle rect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Height - 4);
            e.Graphics.DrawRectangle(Pens.Black, rect);

            // Draw the text inside the rectangle
            e.Graphics.DrawString(text, e.Font, Brushes.Black, rect);

            Console.WriteLine($"currentIndex: {e.Index}");
        }
    }
}
