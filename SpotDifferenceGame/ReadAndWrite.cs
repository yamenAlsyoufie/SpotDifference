using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticeProject
{
    public class ReadAndWrite
    {
        public static string imagePath = @"C:\Users\yamen\Desktop\image.png";
        public void ReadWriteImage()
        {
            // Reading an image
            Bitmap image = new Bitmap(imagePath);
            Console.WriteLine($"Image loaded. Dimensions: {image.Width}x{image.Height}");

            // Writing an image
            string outputPath = "output.png";
            image.Save(outputPath);
            Console.WriteLine($"Image saved to {outputPath}");
        }

        public void ReadWritePixels()
        {
            Bitmap image = new Bitmap(imagePath);
            // Reading a pixel
            Color pixelColor = image.GetPixel(100, 100);
            Console.WriteLine($"Pixel Color at (40,78): R={pixelColor.R}, G={pixelColor.G}, B={pixelColor.B}");

            // Writing a pixel
            Color newColor = Color.Red;
            image.SetPixel(100, 100, newColor);
            image.Save("modified_image.png");
            Console.WriteLine("Pixel modified and image saved");
        }

        public void UseLockBits()
        {
            // Load an image
            Bitmap bitmap = new Bitmap(imagePath);

            // Lock the bitmap to access pixel data
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);
            // Get the address of the first line
            IntPtr ptr = bitmapData.Scan0;

            // Declare an array to hold the bytes of the bitmap
            int bytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Manipulate pixels (make image look red for 24bpp)
            for (int counter = 2; counter < rgbValues.Length; counter += 3)
            {
                rgbValues[counter] = 255;
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bitmap
            bitmap.UnlockBits(bitmapData);

            // Save the modified image
            bitmap.Save("lockedbits_modified.png");
            Console.WriteLine("Image modified using LockBits and saved");
        }


        public void DisplayImageInForm(Bitmap image)
        {
            Form form = new Form();
            form.Size = new Size(image.Width, image.Height);
            form.Text = "Image Display";

            // Handle the Paint event of the form
            form.Paint += (sender, e) =>
            {
                // Get the graphics object
                Graphics g = e.Graphics;
                // Draw the image at position (0, 0)
                g.DrawImage(image, new Point(0, 0));
            };

            // Show the form
            Application.Run(form);
        }

    }
}
