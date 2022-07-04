using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace DigitalizadorWIA.Geradores
{
    public static class GeradorPDF
    {
        public static void ConverterPngParaPDF(string pathDestino, string pathImagemPNG)
        {
            using (var pdf = new Document(PageSize.LETTER, 5f, 5f, 5f, 5f))
            {
                PdfWriter.GetInstance(pdf, new FileStream(pathDestino, FileMode.Create));
                pdf.Open();
                var imagemAnexadaPdf = iTextSharp.text.Image.GetInstance(pathImagemPNG);
                imagemAnexadaPdf.ScaleToFit(650f, 780f);
                imagemAnexadaPdf.Alignment = Element.ALIGN_CENTER;
                pdf.Add(imagemAnexadaPdf);
            }
        }
    }
}