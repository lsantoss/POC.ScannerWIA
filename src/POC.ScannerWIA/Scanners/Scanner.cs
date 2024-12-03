using POC.ScannerWIA.Enums;
using POC.ScannerWIA.Helpers;
using System;
using WIA;

namespace POC.ScannerWIA.Scanners;

internal class Scanner
{
    private string Name { get; }

    private readonly Item _scanner;

    public Scanner(DeviceInfo deviceInfo)
    {
        Name = (string)deviceInfo.Properties["Name"].get_Value();

        _scanner = deviceInfo.Connect().Items[1];
        _scanner.Properties.get_Item(ColorMode.INDEX).set_Value(ColorMode.VALUE);
        _scanner.Properties.get_Item(DPI.Horizontal.INDEX).set_Value(DPI.Horizontal.VALUE);
        _scanner.Properties.get_Item(DPI.Vertical.INDEX).set_Value(DPI.Vertical.VALUE);
        _scanner.Properties.get_Item(StartPixel.Horizontal.INDEX).set_Value(StartPixel.Horizontal.VALUE);
        _scanner.Properties.get_Item(StartPixel.Vertical.INDEX).set_Value(StartPixel.Vertical.VALUE);
        _scanner.Properties.get_Item(SizePixels.Horizontal.INDEX).set_Value(SizePixels.Horizontal.VALUE);
        _scanner.Properties.get_Item(SizePixels.Vertical.INDEX).set_Value(SizePixels.Vertical.VALUE);
        _scanner.Properties.get_Item(BrightnessPercents.INDEX).set_Value(BrightnessPercents.VALUE);
        _scanner.Properties.get_Item(ContrastPercents.INDEX).set_Value(ContrastPercents.VALUE);
    }

    public byte[] Scan(FileType fileType)
    {
        var imageFile = fileType switch
        {
            FileType.PDF => (ImageFile)_scanner.Transfer(FormatId.PNG),
            FileType.PNG => (ImageFile)_scanner.Transfer(FormatId.PNG),
            FileType.JPEG => (ImageFile)_scanner.Transfer(FormatId.JPEG),
            FileType.TIFF => (ImageFile)_scanner.Transfer(FormatId.TIFF),
            FileType.BMP => (ImageFile)_scanner.Transfer(FormatId.BMP),
            FileType.GIF => (ImageFile)_scanner.Transfer(FormatId.GIF),
            _ => throw new Exception("FileType is not supported!"),
        };

        var imageBytes = (byte[])imageFile.FileData.get_BinaryData();

        return ImageHelper.Compress(fileType, imageBytes);
    }

    public override string ToString() => Name;
}

file static class ColorMode
{
    public const string INDEX = "6146";
    public const int VALUE = 1;
}

file class DPI
{
    internal static class Horizontal
    {
        public const string INDEX = "6147";
        public const int VALUE = 300;
    }

    internal static class Vertical
    {
        public const string INDEX = "6148";
        public const int VALUE = 300;
    }
}

file static class StartPixel
{
    internal static class Horizontal
    {
        public const string INDEX = "6149";
        public const int VALUE = 0;
    }

    internal static class Vertical
    {
        public const string INDEX = "6150";
        public const int VALUE = 0;
    }
}

file static class SizePixels
{
    internal static class Horizontal
    {
        public const string INDEX = "6151";
        public const int VALUE = 2500;
    }

    internal static class Vertical
    {
        public const string INDEX = "6152";
        public const int VALUE = 3400;
    }
}

file static class BrightnessPercents
{
    public const string INDEX = "6154";
    public const int VALUE = 0;
}

file static class ContrastPercents
{
    public const string INDEX = "6155";
    public const int VALUE = 0;
}

file static class FormatId
{
    public const string PNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
    public const string JPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
    public const string TIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";
    public const string BMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
    public const string GIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
}