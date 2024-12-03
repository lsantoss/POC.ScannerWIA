using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

namespace POC.ScannerWIA.Helpers;

internal static class PdfHelper
{
    public static byte[] ConvertImageToPdf(byte[] imageBytes)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        using var memoryStream = new MemoryStream();

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);

                #pragma warning disable CS0618
                page.Content().AlignCenter().Image(imageBytes, ImageScaling.FitWidth);
                #pragma warning restore CS0618
            });
        })
        .GeneratePdf(memoryStream);

        return memoryStream.ToArray();
    }
}