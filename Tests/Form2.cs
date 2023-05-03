using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //Allows us to write to console while inside a form
            Program.AllocConsole();
            InitializeComponent();

        }

        public static Color GenerateRandomColor()
        {
            Random random = new Random();
            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            return Color.FromArgb(red, green, blue);
        }

        public static Bitmap ChangeColor(Image image, Color newColor)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Lock the bits of the new Bitmap for reading and writing
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get a pointer to the first byte of the bitmap data
            IntPtr ptr = bitmapData.Scan0;

            // Calculate the number of bytes per pixel and the stride of the bitmap data
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int stride = bitmapData.Stride;

            byte[] pixelValues = new byte[Math.Abs(stride) * bitmap.Height];

            // Copy the bitmap data to the byte array
            Marshal.Copy(ptr, pixelValues, 0, pixelValues.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index = y * stride + x * bytesPerPixel;

                    pixelValues[index] = newColor.B;
                    pixelValues[index + 1] = newColor.G;
                    pixelValues[index + 2] = newColor.R;

                }
            }

            // Copy the modified pixel values back to the bitmap data
            Marshal.Copy(pixelValues, 0, ptr, pixelValues.Length);

            // Unlock the bits of the bitmap data
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = ChangeColor(pictureBox2.BackgroundImage, GenerateRandomColor());
        }
    }
}
