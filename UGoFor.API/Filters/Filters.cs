using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace UGoFor.API.Filters
{

    public static class BitmapFilter
    {
        public class HSL
        {
            private float h;
            private double s;
            private float l;

            public float Hue
            {
                get
                {
                    return h;
                }
                set
                {
                    h = (float)(Math.Abs(value) % 360);
                }
            }

            public double Saturation
            {
                get
                {
                    return s;
                }
                set
                {
                    s = (double)Math.Max(Math.Min(1.0, value), 0.0);
                }
            }

            public float Luminance
            {
                get
                {
                    return l;
                }
                set
                {
                    l = (float)Math.Max(Math.Min(1.0, value), 0.0);
                }
            }

            private HSL()
            {
            }

            public HSL(float hue, float saturation, float luminance)
            {
                Hue = hue;
                Saturation = saturation;
                Luminance = luminance;
            }

            public Color RGB
            {
                get
                {
                    double r = 0, g = 0, b = 0;

                    double temp1, temp2;

                    double normalisedH = h / 360.0;

                    if (l == 0)
                    {
                        r = g = b = 0;
                    }
                    else
                    {
                        if (s == 0)
                        {
                            r = g = b = l;
                        }
                        else
                        {
                            temp2 = ((l <= 0.5) ? l * (1.0 + s) : l + s - (l * s));

                            temp1 = 2.0 * l - temp2;

                            double[] t3 = new double[] { normalisedH + 1.0 / 3.0, normalisedH, normalisedH - 1.0 / 3.0 };

                            double[] clr = new double[] { 0, 0, 0 };

                            for (int i = 0; i < 3; ++i)
                            {
                                if (t3[i] < 0)
                                    t3[i] += 1.0;

                                if (t3[i] > 1)
                                    t3[i] -= 1.0;

                                if (6.0 * t3[i] < 1.0)
                                    clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
                                else if (2.0 * t3[i] < 1.0)
                                    clr[i] = temp2;
                                else if (3.0 * t3[i] < 2.0)
                                    clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                                else
                                    clr[i] = temp1;

                            }

                            r = clr[0];
                            g = clr[1];
                            b = clr[2];
                        }

                    }
                    return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
                }
            }

            private static byte toRGB(float rm1, float rm2, float rh)
            {
                if (rh > 360) rh -= 360;
                else if (rh < 0) rh += 360;

                if (rh < 60) rm1 = rm1 + (rm2 - rm1) * rh / 60;
                else if (rh < 180) rm1 = rm2;
                else if (rh < 240) rm1 = rm1 + (rm2 - rm1) * (240 - rh) / 60;

                return (byte)(rm1 * 255);
            }

            public static HSL FromRGB(byte red, byte green, byte blue)
            {
                return FromRGB(Color.FromArgb(red, green, blue));
            }

            public static HSL FromRGB(Color c)
            {
                return new HSL(c.GetHue(), c.GetSaturation(), c.GetBrightness());
            }
        }
  
        private static Bitmap GetArgbCopy(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);


            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }


            return bmpNew;
        }

        public static Bitmap SepiaTone(this Image sourceImage,double value)
        {
            Bitmap bmpNew = GetArgbCopy(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            IntPtr ptr = bmpData.Scan0;


            byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];


            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);


            byte maxValue = 255;
            double r = 0;
            double g = 0;
            double b = 0;
        

            for (int k = 0; k < byteBuffer.Length; k += 4)
            {
                r = byteBuffer[k] * 0.189f + byteBuffer[k + 1] * 0.769f + byteBuffer[k + 2] * 0.393f;
                g = byteBuffer[k] * 0.168f + byteBuffer[k + 1] * 0.686f + byteBuffer[k + 2] * 0.349f;
                b = byteBuffer[k] * 0.131f + byteBuffer[k + 1] * 0.534f + byteBuffer[k + 2] * 0.272f;
                r = r - value;
                g = g - value;
                b = b - value;

                byteBuffer[k + 2] = (r > maxValue ? maxValue : (byte)r);
                byteBuffer[k + 1] = (g > maxValue ? maxValue : (byte)g);
                byteBuffer[k] = (b > maxValue ? maxValue : (byte)b);
            }

         

            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);


            bmpNew.UnlockBits(bmpData);


            //bmpData = null;
            //byteBuffer = null;

            //return true;
            return bmpNew;
        }

        public static Bitmap DrawAsSepiaTone(this Image sourceImage, float amount)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                                                {
                                                    new float[] {.393f + 0.607f * (1 - amount), .349f - 0.349f * (1 - amount), .272f - 0.272f * (1 - amount), 0, 0},
                                                    new float[] {.769f - 0.769f * (1 - amount), .686f + 0.314f * (1 - amount), .534f - 0.534f * (1 - amount), 0, 0},
                                                    new float[] {.189f - 0.189f * (1 - amount), .168f - 0.168f * (1 - amount), .131f + 0.869f * (1 - amount), 0, 0},
                                                    new float[] {0, 0, 0, 1, 0},
                                                    new float[] {0, 0, 0, 0, 1}
                                                });

            return ApplyColorMatrix(sourceImage, colorMatrix);
        }

        public static Bitmap DrawAsContrast(this Image sourceImage, float value)
        {
            float c = value;
            float t = (1.0f - c) / 2.0f;
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                                                            {
                                                    new float[] {c,0,0,0,0},
                                                    new float[] {0,c,0,0,0},
                                                    new float[] {0,0,c,0,0},
                                                    new float[] {0,0,0,1,0},
                                                    new float[] {t,t,t,0,1}
                                                            });

            return ApplyColorMatrix(sourceImage, colorMatrix);
        }

        public static Bitmap DrawAsBrightness(this Image sourceImage, float value)
        {
            value = (value == 0) ? 1 : value;

            float contrast = value; 
            float FinalValue = 0f;
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                new float[] { contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, contrast, 0}, // don't scale alpha
                new float[] { FinalValue, FinalValue, FinalValue, 1, 1}
            });

            return ApplyColorMatrix(sourceImage, colorMatrix);
        }

        public static Bitmap GrayScale(this Image sourceImage)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
            });

            return ApplyColorMatrix(sourceImage, colorMatrix);
        }

        public static Bitmap HueRotate(Bitmap source, double value)
        {            
            var radians = Math.PI * (double)value / 180.0;
            var cos = (float)Math.Cos(radians);
            var sin = (float)Math.Sin(radians);

            // Create an image attributes object from a hue rotation color matrix
            var colorMatrix =
                new ColorMatrix(
                    new[]
                        {
                    new[] { 0.213f + cos * 0.787f - sin * 0.213f, 0.213f - cos * 0.213f + sin * 0.143f, 0.213f - cos * 0.213f - sin * 0.787f, 0f, 0f },
                    new[] { 0.715f - cos * 0.715f - sin * 0.715f, 0.715f + cos * 0.285f + sin * 0.140f, 0.715f - cos * 0.715f + sin * 0.715f, 0f, 0f },
                    new[] { 0.072f - cos * 0.072f + sin * 0.928f, 0.072f - cos * 0.072f - sin * 0.283f, 0.072f + cos * 0.928f + sin * 0.072f, 0f, 0f },
                    new[] { 0f, 0f, 0f, 1f, 0f },
                    new[] { 0f, 0f, 0f, 0f, 1f }
                        });
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);

            // Get the current image from the picture box control
            var bitmap = source;
            var width = bitmap.Width;
            var height = bitmap.Height;

            // Get a graphics object of the bitmap and draw the hue rotation
            // transformed image on the bitmap area
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(
                bitmap,
                new Rectangle(0, 0, width, height),
                0,
                0,
                width,
                height,
                GraphicsUnit.Pixel,
                imageAttributes);

            // Update the image in the picutre box
           return bitmap;
        }

        public static Bitmap DrawAsSaturation(this Image sourceImage, float saturation)
        {

            saturation = (saturation == 0 ? 1 : saturation);

            float rWeight = 0.3086f;
            float gWeight = 0.6094f;
            float bWeight = 0.0820f;

            float a = (1.0f - saturation) * rWeight + saturation;
            float b = (1.0f - saturation) * rWeight;
            float c = (1.0f - saturation) * rWeight;
            float d = (1.0f - saturation) * gWeight;
            float e = (1.0f - saturation) * gWeight + saturation;
            float f = (1.0f - saturation) * gWeight;
            float g = (1.0f - saturation) * bWeight;
            float h = (1.0f - saturation) * bWeight;
            float i = (1.0f - saturation) * bWeight + saturation;

            float[][] ptsArray = {
                                     new float[] {a,  b,  c,  0, 0},
                                     new float[] {d,  e,  f,  0, 0},
                                     new float[] {g,  h,  i,  0, 0},
                                     new float[] {0,  0,  0,  1, 0},
                                     new float[] {0, 0, 0, 0, 1}
                                 };
            // Create ColorMatrix
            ColorMatrix clrMatrix = new ColorMatrix(ptsArray);

            return ApplyColorMatrix(sourceImage, clrMatrix);
        }

        private static Bitmap ApplyColorMatrix(Image sourceImage, ColorMatrix colorMatrix)
        {
            Bitmap bmp32BppSource = GetArgbCopy(sourceImage);
            Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width,
                      bmp32BppSource.Height),
                      0, 0, bmp32BppSource.Width,
                      bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);

            }

            bmp32BppSource.Dispose();

            return bmp32BppDest;
        }
    }
}
