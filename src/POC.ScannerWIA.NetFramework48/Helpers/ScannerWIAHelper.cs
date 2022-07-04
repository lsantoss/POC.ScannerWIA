using POC.ScannerWIA.NetFramework48.Enums;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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

        private const int RESOLUTION_DPI = 300;
        private const int HORIZONTAL_SCAN_START_PIXEL = 0;
        private const int VERTICAL_SCAN_START_PIXEL = 0;
        private const int HORIZONTAL_SCAN_SIZE_PIXELS = 2500;
        private const int VERTICAL_SCAN_SIZE_PIXELS = 3400;
        private const int SCAN_BRIGHTNESS_PERCENTS = 0;
        private const int SCAN_CONTRAST_PERCENTS = 0;
        private const int SCAN_COLOR_MODE = 1;

        private const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
        private const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
        private const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
        private const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
        private const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
        private const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
        private const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
        private const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
        private const string WIA_SCAN_COLOR_MODE = "6146";

        private readonly DeviceInfo _deviceInfo;

        public ScannerWIAHelper(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public void Scan(EFileType fileType, string destinationPath)
        {
            try
            {
                // Connect with device
                var device = _deviceInfo.Connect();

                // Select scanner
                var scanerItem = device.Items[1]; 

                ConfigureScanner(scanerItem);

                ImageFile imageFile = null;

                switch (fileType)
                {
                    case EFileType.PNG:
                        imageFile = (ImageFile)scanerItem.Transfer(PNG_FORMAT_ID);
                        break;
                    case EFileType.JPEG:
                        imageFile = (ImageFile)scanerItem.Transfer(JPEG_FORMAT_ID);
                        break;
                    case EFileType.TIFF:
                        imageFile = (ImageFile)scanerItem.Transfer(TIFF_FORMAT_ID);
                        break;
                    case EFileType.BMP:
                        imageFile = (ImageFile)scanerItem.Transfer(BMP_FORMAT_ID);
                        break;
                    case EFileType.GIF:
                        imageFile = (ImageFile)scanerItem.Transfer(GIF_FORMAT_ID);
                        break;
                }

                imageFile.SaveFile(destinationPath);
            }
            catch (COMException e)
            {
                switch ((uint)e.ErrorCode)
                {
                    case 0x80210006:
                        MessageBox.Show("The scanner is not ready or is busy!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0x80210064:
                        MessageBox.Show("The scanning process has been canceled!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("An unknown error has occurred!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("An unknown error has occurred!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureScanner(IItem scannnerItem)
        {
            try
            {
                SetProperties(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, RESOLUTION_DPI);
                SetProperties(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, RESOLUTION_DPI);
                SetProperties(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, HORIZONTAL_SCAN_START_PIXEL);
                SetProperties(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, VERTICAL_SCAN_START_PIXEL);
                SetProperties(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, HORIZONTAL_SCAN_SIZE_PIXELS);
                SetProperties(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, VERTICAL_SCAN_SIZE_PIXELS);
                SetProperties(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, SCAN_BRIGHTNESS_PERCENTS);
                SetProperties(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, SCAN_CONTRAST_PERCENTS);
                SetProperties(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, SCAN_COLOR_MODE);
            }
            catch
            {
                MessageBox.Show("Error configuring scanner", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetProperties(IProperties properties, object propertyName, object propertyValue)
        {
            var property = properties.get_Item(ref propertyName);
            property.set_Value(ref propertyValue);
        }

        public override string ToString()
        {
            return (string)_deviceInfo.Properties["Name"].get_Value();
        }
    }
}