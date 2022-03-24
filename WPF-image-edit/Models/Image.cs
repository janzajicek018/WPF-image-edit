using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_image_edit.Models
{
    internal class Image
    {
        private string path;

        private int[,] pixels;

        public void Unnamed()
        {
            int color = (a << 24) + (r << 16) + (g << 8) + b;
            for (int x = 0; x < pixels.GetLength(0); ++x)
            {
                for(int y = 0; y < pixels.GetLength(1); ++y)
                {
                    pixels[x, y] = pixels[x, y] & color;
                }
            }
        }
    }
}
