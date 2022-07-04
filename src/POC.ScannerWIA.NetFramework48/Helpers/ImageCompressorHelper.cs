using ImageMagick;
using POC.ScannerWIA.NetFramework48.Enums;

namespace POC.ScannerWIA.NetFramework48.Helpers
{
    public static class ImageCompressorHelper
    {
        public static void Compress(EFileType fileType, string imagePath)
        {
            MagickFormat magickFormat;
            switch (fileType)
            {
                case EFileType.PNG:
                    magickFormat = MagickFormat.Png8;
                    break;
                case EFileType.JPEG:
                    magickFormat = MagickFormat.Jpeg;
                    break;
                case EFileType.TIFF:
                    magickFormat = MagickFormat.Tiff;
                    break;
                case EFileType.BMP:
                    magickFormat = MagickFormat.Bmp;
                    break;
                case EFileType.GIF:
                    magickFormat = MagickFormat.Gif;
                    break;
                default:
                    magickFormat = MagickFormat.Png8;
                    break;
            }

            using (var imageMagick = new MagickImage(imagePath))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Quadratic;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.TrueColor;
                imageMagick.Format = magickFormat;
                imageMagick.Write(imagePath);
            }
        }
    }
}