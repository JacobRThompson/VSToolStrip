using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace VSToolStrip
{
    public class ToolStripHighlightRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            //To Do: call OnRenderButtonBackground() when control is not highlighted
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
                            outlineColor = SystemColors.MenuHighlight;
                        }
                        else
                        {
                            backgroundColor = control.BackColor;
                            outlineColor = control.Checked ?
                                ProfessionalColors.ButtonCheckedHighlightBorder :
                                control.Owner.BackColor;
                        }
                        break;

                    case PushButtonState.Hot:
                        if (control.Highlighted)
                        {
                            backgroundColor = Color.DarkTurquoise;
                            outlineColor = SystemColors.MenuHighlight;
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
                            backgroundColor = Color.FromArgb(75, SystemColors.MenuHighlight);
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
                    new SolidBrush(backgroundColor),
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

        /*
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is IHighlightRenderableButton control && control.Highlighted)
            {
                e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(Color.Fuchsia), e.TextRectangle);
            }

            base.OnRenderItemText(e);
        }
        */
    }
}
