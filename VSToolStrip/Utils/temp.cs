using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public static class temp
    {
        public static Image ChangeColor(Image image, Color newColor)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bitmapData.Scan0;
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int stride = bitmapData.Stride;

            byte[] pixelValues = new byte[Math.Abs(stride) * bitmap.Height];
            Marshal.Copy(ptr, pixelValues, 0, pixelValues.Length);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index = y * stride + x * bytesPerPixel;
                    byte alpha = pixelValues[index + 3];
                    if (alpha != 0)
                    {
                        pixelValues[index] = newColor.B;
                        pixelValues[index + 1] = newColor.G;
                        pixelValues[index + 2] = newColor.R;
                    }
                }
            }

            Marshal.Copy(pixelValues, 0, ptr, pixelValues.Length);
            bitmap.UnlockBits(bitmapData);

            Image result = Image.FromHbitmap(bitmap.GetHbitmap());
            bitmap.Dispose();

            return result;
        }
    }
}
