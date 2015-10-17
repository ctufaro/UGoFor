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
        public static Image ApplyFilter(string filterName, Image thisImage)
        {
            switch (filterName.Trim())
            {
                case ("uginkwell"):
                    thisImage = BitmapFilter.GrayScale(thisImage);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 1.2f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, 1.05f);
                    break;
                case ("ug1977"):
                    thisImage = BitmapFilter.DrawAsSepiaTone(thisImage, .5f);
                    thisImage = BitmapFilter.HueRotate((Bitmap)thisImage, -30);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, 1.2f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, .8f);
                    break;
                case ("ugamaro"):
                    thisImage = BitmapFilter.HueRotate((Bitmap)thisImage, -10);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 1.1f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, .9f);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, 1.5f);
                    break;
                case ("ugkelvin"):
                    thisImage = BitmapFilter.DrawAsSepiaTone(thisImage, .4f);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 1.3f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, 1f);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, 2.4f);
                    break;
                case ("ugearlybird"):
                    thisImage = BitmapFilter.DrawAsSepiaTone(thisImage, .4f);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, 1.6f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, 1.1f);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 0.9f);
                    thisImage = BitmapFilter.HueRotate((Bitmap)thisImage, -10);
                    break;
                case ("ugtoaster"):
                    thisImage = BitmapFilter.DrawAsSepiaTone(thisImage, .4f);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, 2.5f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, .67f);
                    thisImage = BitmapFilter.HueRotate((Bitmap)thisImage, -30);
                    break;
                case ("ugwillow"):
                    thisImage = BitmapFilter.DrawAsSepiaTone(thisImage, .02f);
                    thisImage = BitmapFilter.DrawAsSaturation(thisImage, .02f);
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, .85f);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 1.2f);
                    break;
                case ("ughudson"):
                    thisImage = BitmapFilter.DrawAsContrast(thisImage, 1.2f);
                    thisImage = BitmapFilter.DrawAsBrightness(thisImage, 0.9f);
                    thisImage = BitmapFilter.HueRotate((Bitmap)thisImage, -10);
                    break;
                default:
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
