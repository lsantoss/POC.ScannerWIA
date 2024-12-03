using ImageMagick;
using POC.ScannerWIA.Enums;
using System;

namespace POC.ScannerWIA.Helpers;

internal static class ImageHelper
{
    public static byte[] Compress(FileType fileType, byte[] imageBytes)
    {
        using var imageMagick = new MagickImage(imageBytes);
        imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
        imageMagick.Resize(2520, 3500);
        imageMagick.FilterType = FilterType.Quadratic;
        imageMagick.ColorType = ColorType.TrueColor;
        imageMagick.Format = fileType switch
        {
            FileType.PDF => MagickFormat.Png,
            FileType.PNG => MagickFormat.Png,
            FileType.JPEG => MagickFormat.Jpeg,
            FileType.TIFF => MagickFormat.Tiff,
            FileType.BMP => MagickFormat.Bmp,
            FileType.GIF => MagickFormat.Gif,
            _ => throw new Exception("FileType is not supported!"),
        };
        return imageMagick.ToByteArray();
    }
}