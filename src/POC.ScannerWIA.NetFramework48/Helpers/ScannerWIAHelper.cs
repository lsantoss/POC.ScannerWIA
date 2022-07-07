using POC.ScannerWIA.NetFramework48.Enums;
using WIA;

namespace POC.ScannerWIA.NetFramework48.Helpers
{
    public class ScannerWIAHelper
    {
        private const string PNG_FORMAT_ID = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        private const string JPEG_FORMAT_ID = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        private const string TIFF_FORMAT_ID = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";
        private const string BMP_FORMAT_ID = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        private const string GIF_FORMAT_ID = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";

        private const string HORIZONTAL_RESOLUTION_DPI_PROPERTY_NAME = "6147";
        private const string VERTICAL_RESOLUTION_DPI_PROPERTY_NAME = "6148";
        private const string HORIZONTAL_START_PIXEL_PROPERTY_NAME = "6149";
        private const string VERTICAL_START_PIXEL_PROPERTY_NAME = "6150";
        private const string HORIZONTAL_SIZE_PIXELS_PROPERTY_NAME = "6151";
        private const string VERTICAL_SIZE_PIXELS_PROPERTY_NAME = "6152";
        private const string BRIGHTNESS_PERCENTS_PROPERTY_NAME = "6154";
        private const string CONTRAST_PERCENTS_PROPERTY_NAME = "6155";
        private const string COLOR_MODE_PROPERTY_NAME = "6146";

        private const int HORIZONTAL_RESOLUTION_DPI_VALUE = 300;
        private const int VERTICAL_RESOLUTION_DPI_VALUE = 300;
        private const int HORIZONTAL_START_PIXEL_VALUE = 0;
        private const int VERTICAL_START_PIXEL_VALUE = 0;
        private const int HORIZONTAL_SIZE_PIXELS_VALUE = 2500;
        private const int VERTICAL_SIZE_PIXELS_VALUE = 3400;
        private const int BRIGHTNESS_PERCENTS_VALUE = 0;
        private const int CONTRAST_PERCENTS_VALUE = 0;
        private const int COLOR_MODE_VALUE = 1;

        private readonly DeviceInfo _deviceInfo;
        private readonly Item _scanerItem;

        public ScannerWIAHelper(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
            _scanerItem = _deviceInfo.Connect().Items[1];
            ConfigureScanner(_scanerItem);
        }

        public byte[] Scan(EFileType outputTypeFile)
        {
            var imageType = outputTypeFile == EFileType.PDF ? EFileType.PNG : outputTypeFile;

            var imageFile = GetImageFile(imageType, _scanerItem);

            var image = (byte[])imageFile.FileData.get_BinaryData();

            var compressedImage = ImageCompressorHelper.Compress(imageType, image);

            if (outputTypeFile == EFileType.PDF)
                return PdfGeneratorHelper.ConvertImageToPdf(compressedImage);

            return compressedImage;           
        }

        private static ImageFile GetImageFile(EFileType fileType, Item _scanerItem)
        {
            ImageFile imageFile = null;

            switch (fileType)
            {
                case EFileType.PNG:
                    imageFile = (ImageFile)_scanerItem.Transfer(PNG_FORMAT_ID);
                    break;
                case EFileType.JPEG:
                    imageFile = (ImageFile)_scanerItem.Transfer(JPEG_FORMAT_ID);
                    break;
                case EFileType.TIFF:
                    imageFile = (ImageFile)_scanerItem.Transfer(TIFF_FORMAT_ID);
                    break;
                case EFileType.BMP:
                    imageFile = (ImageFile)_scanerItem.Transfer(BMP_FORMAT_ID);
                    break;
                case EFileType.GIF:
                    imageFile = (ImageFile)_scanerItem.Transfer(GIF_FORMAT_ID);
                    break;
            }

            return imageFile;
        }

        private static void ConfigureScanner(IItem scannnerItem)
        {
            SetProperties(scannnerItem.Properties, HORIZONTAL_RESOLUTION_DPI_PROPERTY_NAME, HORIZONTAL_RESOLUTION_DPI_VALUE);
            SetProperties(scannnerItem.Properties, VERTICAL_RESOLUTION_DPI_PROPERTY_NAME, VERTICAL_RESOLUTION_DPI_VALUE);
            SetProperties(scannnerItem.Properties, HORIZONTAL_START_PIXEL_PROPERTY_NAME, HORIZONTAL_START_PIXEL_VALUE);
            SetProperties(scannnerItem.Properties, VERTICAL_START_PIXEL_PROPERTY_NAME, VERTICAL_START_PIXEL_VALUE);
            SetProperties(scannnerItem.Properties, HORIZONTAL_SIZE_PIXELS_PROPERTY_NAME, HORIZONTAL_SIZE_PIXELS_VALUE);
            SetProperties(scannnerItem.Properties, VERTICAL_SIZE_PIXELS_PROPERTY_NAME, VERTICAL_SIZE_PIXELS_VALUE);
            SetProperties(scannnerItem.Properties, BRIGHTNESS_PERCENTS_PROPERTY_NAME, BRIGHTNESS_PERCENTS_VALUE);
            SetProperties(scannnerItem.Properties, CONTRAST_PERCENTS_PROPERTY_NAME, CONTRAST_PERCENTS_VALUE);
            SetProperties(scannnerItem.Properties, COLOR_MODE_PROPERTY_NAME, COLOR_MODE_VALUE);
        }

        private static void SetProperties(IProperties properties, object propertyName, object propertyValue)
        {
            properties.get_Item(ref propertyName).set_Value(ref propertyValue);
        }

        public override string ToString()
        {
            return (string)_deviceInfo.Properties["Name"].get_Value();
        }
    }
}