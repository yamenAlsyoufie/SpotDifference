using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
//using SixLabors.ImageSharp.PixelFormats;
using Emgu.CV.CvEnum;
using Emgu.CV;
namespace PracticeProject;
internal class ColorSystem
{
    public Bitmap RemoveGreenColor()
    {
        Bitmap rgbImage = new Bitmap(ReadAndWrite.imagePath);
        Bitmap noGreenImage = new Bitmap(rgbImage.Width, rgbImage.Height);

        // Process each pixel to remove green component
        for (int y = 0; y < rgbImage.Height; y++)
        {
            for (int x = 0; x < rgbImage.Width; x++)
            {
                // Get RGB color of current pixel
                Color pixelColor = rgbImage.GetPixel(x, y);

                // Remove green component (set it to 0)
                Color newColor = Color.FromArgb(pixelColor.R, 0, pixelColor.B);

                noGreenImage.SetPixel(x, y, newColor);
            }
        }
        // Save the image with green removed
        noGreenImage.Save("no_green_image.jpg");
        Console.WriteLine("Image with green color removed saved as 'no_green_image.jpg'");

        return noGreenImage;
    }
    public Bitmap RemoveBlueColor()
    {
        Bitmap rgbImage = new Bitmap(ReadAndWrite.imagePath);
        Bitmap noBlueImage = new Bitmap(rgbImage.Width, rgbImage.Height);

        // Process each pixel to remove green component
        for (int y = 0; y < rgbImage.Height; y++)
        {
            for (int x = 0; x < rgbImage.Width; x++)
            {
                // Get RGB color of current pixel
                Color pixelColor = rgbImage.GetPixel(x, y);
                // Remove green component (set it to 0)
                Color newColor = Color.FromArgb(0, 0, pixelColor.B);

                noBlueImage.SetPixel(x, y, newColor);
            }
        }

        // Save the image with green removed
        noBlueImage.Save("no_Blue_image.jpg");
        Console.WriteLine("Image with Blue color removed saved as 'no_Blue_image.jpg'");

        return noBlueImage;
    }
    public Bitmap RemoveRedColor()
    {
        Bitmap rgbImage = new Bitmap(ReadAndWrite.imagePath);
        Bitmap noRedImage = new Bitmap(rgbImage.Width, rgbImage.Height);

        // Process each pixel to remove green component
        for (int y = 0; y < rgbImage.Height; y++)
        {
            for (int x = 0; x < rgbImage.Width; x++)
            {
                // Get RGB color of current pixel
                Color pixelColor = rgbImage.GetPixel(x, y);

                // Remove green component (set it to 0)
                Color newColor = Color.FromArgb(0, pixelColor.G, pixelColor.B);

                noRedImage.SetPixel(x, y, newColor);
            }
        }

        // Save the image with green removed
        noRedImage.Save("no_Red_image.jpg");
        Console.WriteLine("Image with Red color removed saved as 'no_Red_image.jpg'");

        return noRedImage;
    }
    public Bitmap DisplayPhotoWithAllColor()
    {
        // your original implementation
        Bitmap rgbImage = new Bitmap(ReadAndWrite.imagePath);
        Bitmap redComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
        Bitmap greenComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
        Bitmap blueComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
        // Extract components pixel by pixel
        for (int y = 0; y < rgbImage.Height; y++)
        {
            for (int x = 0; x < rgbImage.Width; x++)
            {
                // Get RGB color of current pixel
                Color pixelColor = rgbImage.GetPixel(x, y);
                // Extract components
                int redComponent = pixelColor.R;
                int greenComponent = pixelColor.G;
                int blueComponent = pixelColor.B;
                // Create colors for each component
                Color redColor = Color.FromArgb(redComponent, 0, 0);
                Color greenColor = Color.FromArgb(0, greenComponent, 0);
                Color blueColor = Color.FromArgb(0, 0, blueComponent);
                redComponentImage.SetPixel(x, y, redColor);
                greenComponentImage.SetPixel(x, y, greenColor);
                blueComponentImage.SetPixel(x, y, blueColor);
            }
        }
        // Save component images
        redComponentImage.Save("red_component.jpg");
        greenComponentImage.Save("green_component.jpg");
        blueComponentImage.Save("blue_component.jpg");
        return rgbImage;
    }
    public Bitmap ConvertRGBtoCMY()
    {
        Bitmap rgbImage = new Bitmap(ReadAndWrite.imagePath);
        Bitmap cmyImage = new Bitmap(ReadAndWrite.imagePath);
        for (int i = 0; i < rgbImage.Height; i++)
        {
            for (int j = 0; j < rgbImage.Width; j++)
            {
                // Get RGB color of current pixel
                Color pixelColor = rgbImage.GetPixel(j, i);
                // Calculate CMY values
                int c = 255 - pixelColor.R; // Cyan
                int m = 255 - pixelColor.G; // Magenta
                int y = 255 - pixelColor.B; // Yellow
                                            // Create CMY color using the calculated values
                Color cmyColor = Color.FromArgb(c, m, y);
                // Set the corresponding pixel in the CMY image
                cmyImage.SetPixel(j, i, cmyColor);
            }
        }
        // Save the CMY image
        cmyImage.Save("cmy_image.jpg");
        return cmyImage;
    }
    public void RGBToHSV()
    {
        Mat rgbImage = CvInvoke.Imread(ReadAndWrite.imagePath);
        // Convert RGB to HSV
        Mat hsvImage = new Mat();
        CvInvoke.CvtColor(rgbImage, hsvImage, ColorConversion.Bgr2Hsv);
        CvInvoke.Imshow("HSV Image", hsvImage);
        CvInvoke.WaitKey(0);
    }
    public void RGBToYbr()
    {
        Mat rgbImage = CvInvoke.Imread(ReadAndWrite.imagePath);
        // Convert RGB to YCbCr
        Mat ycbcrImage = new Mat();
        CvInvoke.CvtColor(rgbImage, ycbcrImage, ColorConversion.Bgr2YCrCb);
        CvInvoke.Imshow("YCbCrImage", ycbcrImage);
        CvInvoke.WaitKey(0);
    }
    public void RGBToYuv()
    {
        Mat rgbImage = CvInvoke.Imread(ReadAndWrite.imagePath);
        // Convert RGB to YUV
        Mat yuvImage = new Mat();
        CvInvoke.CvtColor(rgbImage, yuvImage, ColorConversion.Bgr2Yuv);
        CvInvoke.Imshow("yuvImage", yuvImage);
        CvInvoke.WaitKey(0);
    }
    public void RGBToLab()
    {
        Mat rgbImage = CvInvoke.Imread(ReadAndWrite.imagePath);
        // Convert RGB to Lab
        Mat labImage = new Mat();
        CvInvoke.CvtColor(rgbImage, labImage, ColorConversion.Bgr2Lab);
        CvInvoke.Imshow("labImage", labImage);
        CvInvoke.WaitKey(0);
    }
}