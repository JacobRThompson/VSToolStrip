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


        public override Image BackgroundImage 
        {
            get => ButtonState switch
            {
                PushButtonState.Hot => HotImage,
                PushButtonState.Pressed => PressedImage,
                PushButtonState.Disabled => DisabledImage,
                _ => base.BackgroundImage
            }; 
            set => base.BackgroundImage = value; 
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BackgroundImage = DefaultImage;
        }

        
    }

    
}
