using DigitalizadorWIA.Enums;
using ImageMagick;

namespace DigitalizadorWIA.Compactadores
{
    public static class CompactadorImagens
    {
        public static void Compactar(ETipoArquivo tipoArquivo, string pathImagem)
        {
            MagickFormat magickFormat;
            switch (tipoArquivo)
            {
                case ETipoArquivo.PNG:
                    magickFormat = MagickFormat.Png8;
                    break;
                case ETipoArquivo.JPEG:
                    magickFormat = MagickFormat.Jpeg;
                    break;
                case ETipoArquivo.TIFF:
                    magickFormat = MagickFormat.Tiff;
                    break;
                case ETipoArquivo.BMP:
                    magickFormat = MagickFormat.Bmp;
                    break;
                case ETipoArquivo.GIF:
                    magickFormat = MagickFormat.Gif;
                    break;
                default:
                    magickFormat = MagickFormat.Png8;
                    break;
            }

            using (var imageMagick = new MagickImage(pathImagem))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Quadratic;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.TrueColor;
                imageMagick.Format = magickFormat;
                imageMagick.Write(pathImagem);
            }
        }
    }
}