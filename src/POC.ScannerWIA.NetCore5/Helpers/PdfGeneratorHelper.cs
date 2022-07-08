using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace POC.ScannerWIA.NetCore5.Helpers
{
    public static class PdfGeneratorHelper
    {
        public static byte[] ConvertImageToPdf(byte[] fileBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                var writer = PdfWriter.GetInstance(document, memoryStream);

                var attachedImage = Image.GetInstance(fileBytes);
                attachedImage.ScaleToFit(650f, 780f);
                attachedImage.Alignment = Element.ALIGN_LEFT;

                document.Open();
                document.Add(attachedImage);
                document.Close();

                var pdfFile = memoryStream.ToArray();
                memoryStream.Close();

                return pdfFile;
            }
        }

        public static void SaveImageAsPdf(string destinationPath, byte[] fileBytes)
        {
            var pdfFile = ConvertImageToPdf(fileBytes);
            File.WriteAllBytes(destinationPath, pdfFile);
        }
    }
}