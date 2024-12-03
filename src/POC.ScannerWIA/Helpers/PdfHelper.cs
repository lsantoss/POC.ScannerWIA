using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace POC.ScannerWIA.Helpers;

internal static class PdfHelper
{
    public static byte[] ConvertImageToPdf(byte[] imageBytes)
    {
        using var memoryStream = new MemoryStream();
        var document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
        var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

        var attachedImage = Image.GetInstance(imageBytes);
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