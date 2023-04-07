using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace VSToolStrip.IconButtons
{
    public class IconPushButton: IconControl
    {       
       

        [Category(IMAGE_CATEGORY)]
        public Image DefaultImage { get; set; } = new Bitmap(1, 1);

        [Category(IMAGE_CATEGORY)]
        public Image HotImage { get; set; } = new Bitmap(1, 1);

        [Category(IMAGE_CATEGORY)]
        public Image PressedImage { get; set; } = new Bitmap(1, 1);

        [Category(IMAGE_CATEGORY)]
        public Image DisabledImage { get; set; } = new Bitmap(1, 1);

        
        protected override void PaintState()
        {
            this.SuspendLayout();
            switch (ButtonState)
            {
                case PushButtonState.Normal:
                    base.BackgroundImage = DefaultImage;
                    break;

                case PushButtonState.Hot:
                    base.BackgroundImage = HotImage;
                    break;

                case PushButtonState.Pressed:
                    base.BackgroundImage = PressedImage;
                    break;

                case PushButtonState.Disabled:
                    base.BackgroundImage = DisabledImage;
                    break;
            }
            this.ResumeLayout(false);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BackgroundImage = DefaultImage;
        }
    }

    
}
