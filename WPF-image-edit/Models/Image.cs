using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WPF_image_edit.Models;

namespace WPF_image_edit.Models
{
    internal class Image
    {
        private string path;

        private int[,] pixels;

        WriteableBitmap wbm;
        public BitmapImage Color2Grayscale(BitmapImage src)
        {
            pixels = Array2DBMIConverter.BitmapImageToArray2D(src);
            
            //int color = (a << 24) + (r << 16) + (g << 8) + b;
            for (int x = 0; x < pixels.GetLength(0); ++x)
            {
                for(int y = 0; y < pixels.GetLength(1); ++y)
                {
                    //pixels[x, y] = pixels[x, y] & color;
                    int a = (pixels[x, y] >> 24) & 0xFF;
                    int r = (pixels[x, y] >> 16) & 0xFF;
                    int g = (pixels[x, y] >> 8) & 0xFF;
                    int b = pixels[x, y] & 0xFF;
                    int average = (r + g + b) / 3; //0.333 * r + 0.5 * g + 0.27 * b
                    pixels[x, y] = (a << 24) + (average << 16) + (average << 8) + average;
                }
            }
            wbm = Array2DBMIConverter.Array2DToWriteableBitmap(pixels, src);
            src = Array2DBMIConverter.ConvertWriteableBitmapToBitmapImage(wbm);
            return src;
        }
        public BitmapImage ReduceColor(BitmapImage src)
        {
            pixels = Array2DBMIConverter.BitmapImageToArray2D(src);
            for (int x = 0; x < pixels.GetLength(0); ++x)
            {
                for (int y = 0; y < pixels.GetLength(1); ++y)
                {
                    int color = pixels[x, y];
                    //pixels[x, y] = (int)(color & 0xfffefefe); //0b111111111111111011111110111111110 //try 0xff808080 or something idk
                    pixels[x, y] = (int)(color & 0xfffefefe);
                }
            }
            wbm = Array2DBMIConverter.Array2DToWriteableBitmap(pixels, src);
            src = Array2DBMIConverter.ConvertWriteableBitmapToBitmapImage(wbm);
            return src;
        }
        public BitmapImage Negative(BitmapImage src)
        {
            pixels = Array2DBMIConverter.BitmapImageToArray2D(src);

            //int color = (a << 24) + (r << 16) + (g << 8) + b;
            for (int x = 0; x < pixels.GetLength(0); ++x)
            {
                for (int y = 0; y < pixels.GetLength(1); ++y)
                {
                    //pixels[x, y] = pixels[x, y] & color;
                    int a = (pixels[x, y] >> 24) & 0xFF;
                    int r = 255 - (pixels[x, y] >> 16) & 0xFF;
                    int g = 255 - (pixels[x, y] >> 8) & 0xFF;
                    int b = 255 - pixels[x, y] & 0xFF;
                    pixels[x, y] = (a << 24) + (r << 16) + (g << 8) + b;
                }
            }
            wbm = Array2DBMIConverter.Array2DToWriteableBitmap(pixels, src);
            src = Array2DBMIConverter.ConvertWriteableBitmapToBitmapImage(wbm);
            return src;
        }
    }
}
