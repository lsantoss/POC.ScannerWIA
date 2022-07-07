using ImageMagick;
using POC.ScannerWIA.NetFramework48.Enums;
using System;

namespace POC.ScannerWIA.NetFramework48.Helpers
{
    public static class ImageCompressorHelper
    {
        private const int WIDTH = 2520;
        private const int HEIGHT = 3500;

        public static byte[] Compress(EFileType fileType, byte[] imageBytes)
        {
            using (var imageMagick = new MagickImage(imageBytes))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Quadratic;
                imageMagick.Resize(WIDTH, HEIGHT);
                imageMagick.ColorType = ColorType.TrueColor;
                imageMagick.Format = GetMagickFormat(fileType);
                return imageMagick.ToByteArray();
            }
        }

        public static void CompressAndSave(EFileType fileType, byte[] imageBytes, string imagePath)
        {
            using (var imageMagick = new MagickImage(imageBytes))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Quadratic;
                imageMagick.Resize(WIDTH, HEIGHT);
                imageMagick.ColorType = ColorType.TrueColor;
                imageMagick.Format = GetMagickFormat(fileType);
                imageMagick.Write(imagePath);
            }
        }

        private static MagickFormat GetMagickFormat(EFileType fileType)
        {
            switch (fileType)
            {
                case EFileType.PNG:
                    return MagickFormat.Png8;
                case EFileType.JPEG:
                    return MagickFormat.Jpeg;
                case EFileType.TIFF:
                    return MagickFormat.Tiff;
                case EFileType.BMP:
                    return MagickFormat.Bmp;
                case EFileType.GIF:
                    return MagickFormat.Gif;
                default:
                    throw new Exception("The chosen file type is not supported!");
            }
        }
    }
}