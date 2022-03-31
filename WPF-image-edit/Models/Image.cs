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
                    int a = (int)(pixels[x, y] & 0xFF000000);
                    int r = (pixels[x, y] >> 16) & 0xFF;
                    int g = (pixels[x, y] >> 8) & 0xFF;
                    int b = pixels[x, y] & 0xFF;
                    int pr = (r + g + b) / 3;
                    pixels[x, y] = (a << 24) + (pr << 16) + (pr << 8) + pr;
                }
            }
            wbm = Array2DBMIConverter.Array2DToWriteableBitmap(pixels, src);
            src = Array2DBMIConverter.ConvertWriteableBitmapToBitmapImage(wbm);
            return src;
        }
    }
}
