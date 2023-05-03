using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.IconButtons
{
    public class IconPushButton: IconControl
    {       
        private Color _prevBackColor = Color.Empty;
        private Color _prevForeColor = Color.Empty;

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor, backColor;

            switch (ButtonState)
            {
                case PushButtonState.Hot: //Swap back and fore colors when user hovers over button
                    foreColor = this.GetBackColor();
                    backColor = this.GetForeColor();
                    break;

                case PushButtonState.Pressed:
                    foreColor = this.GetForeColor();
                    backColor = this.GetBackColor();
                    break;

                case PushButtonState.Disabled:
                    foreColor = SystemColors.GrayText;
                    backColor = this.GetForeColor();
                    break;

                default:
                    foreColor = this.GetForeColor();
                    backColor = this.GetBackColor();
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.ClipRectangle);

            if (BackgroundImage != null)
            {
                e.Graphics.DrawImage(
                    BackgroundImage!.ReplaceOpaquePixels(foreColor), 
                    e.ClipRectangle.ScaleToAspectRatio(BackgroundImage!.GetAspectRatio())
                );
                _prevForeColor = foreColor;
            }
            
        }


    }

    
}
