using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace UGoFor.API.Filters
{
    public static class Compression
    {
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            return encoders.FirstOrDefault(t => t.MimeType == mimeType);
        }

        public static Stream ToStream(this Image image, ImageFormat formaw)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Save an Image as a JPeg with a given compression
        ///  Note: Filename suffix will not affect mime type which will be Jpeg.
        /// </summary>
        /// <param name="image">Image: Image to save</param>
        /// <param name="fileName">String: File name to save the image as. Note: suffix will not affect mime type which will be Jpeg.</param>
        /// <param name="compression">Long: Value between 0 and 100.</param>
        private static void SaveJpegWithCompressionSetting(Image image, string fileName, long compression)
        {
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compression);
            var ici = GetEncoderInfo("image/jpeg");
            image.Save(fileName, ici, eps);
        }

        /// <summary>
        /// Save an Image as a JPeg with a given compression
        /// Note: Filename suffix will not affect mime type which will be Jpeg.
        /// </summary>
        /// <param name="image">Image: This image</param>
        /// <param name="fileName">String: File name to save the image as. Note: suffix will not affect mime type which will be Jpeg.</param>
        /// <param name="compression">Long: Value between 0 and 100.</param>
        public static void SaveJpegWithCompression(this Image image, string fileName, long compression)
        {
            SaveJpegWithCompressionSetting(image, fileName, compression);
        }

        public static void SaveJpegToStreamWithCompressionSetting(Image image, long compression, Stream savestream)
        {
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compression);
            var ici = GetEncoderInfo("image/jpeg");
            image.Save(savestream, ici, eps);
        }
    }
}
