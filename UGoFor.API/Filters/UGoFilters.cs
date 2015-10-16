using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UGoFor.API.Filters
{
    public class UGoFilters
    {
        //public static Image ApplyFilter(Filters filter, Image thisImage, string saveLocation, long compression)
        public static Image ApplyFilter(Filters filter, Image thisImage)
        {
            switch (filter)
            {
                case (Filters.Inkwell):
                    thisImage = BitmapFilter.GrayScale((Bitmap)thisImage);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 1.2f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, 1.05f);
                    break;
            }
            return thisImage;
            //Compression.SaveJpegWithCompression(thisImage, saveLocation, compression);
        }

        public enum Filters
        {
            Inkwell
        }
    }
}
