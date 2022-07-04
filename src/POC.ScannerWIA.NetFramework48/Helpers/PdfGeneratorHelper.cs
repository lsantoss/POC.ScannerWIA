using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace POC.ScannerWIA.NetFramework48.Helpers
{
    public static class PdfGeneratorHelper
    {
        public static void ConvertImageToPdf(string destinationPath, string imagePath)
        {
            using (var document = new Document(PageSize.LETTER, 5f, 5f, 5f, 5f))
            {
                PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create));
                document.Open();
                var attachedImage = Image.GetInstance(imagePath);
                attachedImage.ScaleToFit(650f, 780f);
                attachedImage.Alignment = Element.ALIGN_CENTER;
                document.Add(attachedImage);
            }
        }
    }
}