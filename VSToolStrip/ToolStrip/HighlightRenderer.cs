using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;


namespace VS.ToolStrip
{
    public class ToolStripHighlightRenderer : ToolStripProfessionalRenderer
    {
        const float HOT_OPACITY = 0.33f;



        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            /*
            Pen lineBreakPen = new(SystemColors.InactiveBorder, 1);//new(e.ToolStrip.Parent != null ? e.ToolStrip.Parent.BackColor: e.ToolStrip.BackColor);

            int currentRowY = int.MinValue;  
            foreach (ToolStripItem item in e.ToolStrip.Items)
            {
                if (item.Visible && item.Bounds.Bottom > currentRowY)
                {
                    currentRowY = item.Bounds.Bottom-1;
                    e.Graphics.DrawLine(lineBreakPen, new Point(e.ToolStrip.Left, currentRowY), new Point(e.ToolStrip.Right, currentRowY));
                }
            }
            */
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {

            if (e.Item is IHighlightRenderableButton control)
            {
                Color backgroundColor;
                Color outlineColor;

                switch (control.ButtonState)
                {
                    case PushButtonState.Normal:
                        if (control.Highlighted)
                        {
                            backgroundColor = SystemColors.MenuHighlight;
                            outlineColor = control.Checked ?
                                Utils.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                                control.Owner.Parent.BackColor;
                        }
                        else
                        {
                            backgroundColor = control.BackColor;
                            outlineColor = control.Checked ?
                                ProfessionalColors.ButtonCheckedHighlightBorder :
                                control.Owner.Parent.BackColor;
                        }
                        break;

                    case PushButtonState.Hot:
                        if (control.Highlighted)
                        {
                            backgroundColor = Utils.Lerp(SystemColors.MenuHighlight, control.Owner.BackColor, HOT_OPACITY);
                            outlineColor = control.Checked ?
                                Utils.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                                backgroundColor;
                        }
                        else
                        {
                            backgroundColor = ProfessionalColors.ButtonSelectedHighlight;
                            outlineColor = control.Checked ?
                                ProfessionalColors.ButtonCheckedHighlightBorder :
                                ProfessionalColors.ButtonSelectedHighlightBorder;
                        }
                        break;

                    case PushButtonState.Pressed:
                        if (control.Highlighted)
                        {
                            backgroundColor = Utils.Lerp(SystemColors.MenuHighlight, control.Owner.BackColor, 1f - HOT_OPACITY);
                            outlineColor = SystemColors.MenuHighlight;
                        }
                        else
                        {
                            backgroundColor = ProfessionalColors.ButtonPressedHighlight;
                            outlineColor = control.Checked ?
                                ProfessionalColors.ButtonCheckedHighlightBorder :
                                ProfessionalColors.ButtonPressedBorder;
                        }
                        break;

                    default:
                        backgroundColor = ProfessionalColors.ButtonCheckedHighlight;
                        outlineColor = ProfessionalColors.ButtonCheckedHighlightBorder;
                        break;
                }

                e.Graphics.FillRectangle(
                    new SolidBrush(backgroundColor.ToOpaque()),
                    new(Point.Empty, control.Size - new Size(1, 1)));
                e.Graphics.DrawRectangle(
                    new Pen(outlineColor),
                    new(Point.Empty, control.Size - new Size(1, 1)));
            }
            else
            {
                base.OnRenderItemBackground(e);
            }

        }
    }
}
