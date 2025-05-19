using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using NAudio.Mixer;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    internal class Image
    {
        Mat rgbImage = CvInvoke.Imread(ReadAndWrite.imagePath, ImreadModes.Color);

        public void RGBToBinary()
        {
            ReadAndWrite readAndWrite = new ReadAndWrite();
            Mat grayscaleImage = new Mat();
            CvInvoke.CvtColor(rgbImage, grayscaleImage, ColorConversion.Bgr2Gray);
            // Convert the grayscale image to a binary
            Mat binaryImage = new Mat();
            CvInvoke.Threshold(grayscaleImage, binaryImage, 127, 255, ThresholdType.Binary);
            // CvInvoke.Imshow("Binary Image", binaryImage);
            CvInvoke.Imshow("HSV Image", binaryImage);
            CvInvoke.WaitKey(0);
        }
        public void RGBtoGrayScale()
        {
            Mat grayscaleImage = new Mat();
            CvInvoke.CvtColor(rgbImage, grayscaleImage, ColorConversion.Bgr2Gray);
            CvInvoke.Imshow("Gray Image", grayscaleImage);
            CvInvoke.WaitKey(0);
        }
        public void IndexedImage()
        {
            Bitmap indexedImage = new Bitmap(ReadAndWrite.imagePath);
            // Extract the color palette
            ColorPalette colorPalette = indexedImage.Palette;
            // Extract one color from the colormapand its corresponding index
            int sampleIndex = 5; // Sample index
            Color sampleColor = colorPalette.Entries[sampleIndex];
            // Print the sampled color and its index
            Console.WriteLine($"Color at index {sampleIndex}: R={sampleColor.R}, G={sampleColor.G}, B={sampleColor.B}");
        }
    }
}
