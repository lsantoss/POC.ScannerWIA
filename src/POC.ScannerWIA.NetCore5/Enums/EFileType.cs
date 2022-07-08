using System.ComponentModel;

namespace POC.ScannerWIA.NetCore5.Enums
{
    public enum EFileType
    {
        [Description("PDF")]
        PDF = 0,

        [Description("PNG")]
        PNG = 1,

        [Description("JPEG")]
        JPEG = 2,

        [Description("TIFF")]
        TIFF = 3,

        [Description("BMP")]
        BMP = 4,

        [Description("GIF")]
        GIF = 5
    }
}