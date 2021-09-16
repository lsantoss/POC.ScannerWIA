using DigitalizadorWIA.Enums;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WIA;

namespace DigitalizadorWIA.Scanners
{
    public class ScannerWIA
    {
        private readonly DeviceInfo _deviceInfo;

        public ScannerWIA(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public ImageFile Escanear(ETipoArquivo tipoArquivo)
        {
            try
            {                
                var device = _deviceInfo.Connect(); // Conecta com o dispositivo                
                var scanerItem = device.Items[1]; // Seleciona o scanner

                ConfigurarScanner(scanerItem);

                object scanResult = null;

                switch (tipoArquivo)
                {
                    case ETipoArquivo.PNG:
                        scanResult = scanerItem.Transfer("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}");
                        break;
                    case ETipoArquivo.JPEG:
                        scanResult = scanerItem.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
                        break;
                    case ETipoArquivo.TIFF:
                        scanResult = scanerItem.Transfer("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}");
                        break;
                    case ETipoArquivo.BMP:
                        scanResult = scanerItem.Transfer("{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}");
                        break;
                    case ETipoArquivo.GIF:
                        scanResult = scanerItem.Transfer("{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}");
                        break;
                }

                return scanResult != null ? (ImageFile)scanResult : null;
            }
            catch (COMException e)
            {
                uint errorCode = (uint)e.ErrorCode;

                switch (errorCode)
                {
                    case 0x80210006:
                        MessageBox.Show("A scanner não está pronta ou está ocupada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0x80210064:
                        MessageBox.Show("O processo de digitalização foi cancelado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Ocorreu um erro não conhecido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return null;
            }
        }

        private static void ConfigurarScanner(IItem scannnerItem)
        {
            try
            {
                var resolucaoDPI = 300;
                var scannerInicioEsquerdaPixel = 0;
                var scannerInicioTopoPixel = 0;
                var larguraPixel = 2500;
                var alturaPixel = 3400;
                var iluminacaoPorcentagem = 0;
                var contrastePercentagem = 0;
                var colorMode = 1;

                const string WIA_SCAN_COLOR_MODE = "6146";
                const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
                const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
                const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
                const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
                const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
                const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
                const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
                const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

                DefinirPropriedades(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, resolucaoDPI);
                DefinirPropriedades(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, resolucaoDPI);
                DefinirPropriedades(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scannerInicioEsquerdaPixel);
                DefinirPropriedades(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scannerInicioTopoPixel);
                DefinirPropriedades(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, larguraPixel);
                DefinirPropriedades(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, alturaPixel);
                DefinirPropriedades(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, iluminacaoPorcentagem);
                DefinirPropriedades(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastePercentagem);
                DefinirPropriedades(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
            }
            catch
            {
                MessageBox.Show("Erro ao configurar scanner", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void DefinirPropriedades(IProperties propriedades, object nomePropriedade, object valorPropriedade)
        {
            var propriedade = propriedades.get_Item(ref nomePropriedade);
            propriedade.set_Value(ref valorPropriedade);
        }

        public override string ToString()
        {
            return (string)_deviceInfo.Properties["Name"].get_Value();
        }
    }
}