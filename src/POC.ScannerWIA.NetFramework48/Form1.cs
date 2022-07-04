using POC.ScannerWIA.NetFramework48.Enums;
using POC.ScannerWIA.NetFramework48.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIA;

namespace POC.ScannerWIA.NetFramework48
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listScannerList.Items.Clear();
            var deviceManager = new DeviceManager();

            foreach (DeviceInfo device in deviceManager.DeviceInfos)
                if (device.Type == WiaDeviceType.ScannerDeviceType)
                    listScannerList.Items.Add(new ScannerWIAHelper(device));

            dropDownFileType.SelectedIndex = 0;
        }

        private void ButtonModifyPath_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            var result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
                textBoxDestinationPath.Text = folderDlg.SelectedPath;
        }

        private void ButtonScan_Click(object sender, EventArgs e)
        {
            pictureBoxOutputFile.Image = null;

            var scanner = listScannerList.SelectedItem as ScannerWIAHelper;

            var fileType = (EFileType)dropDownFileType.SelectedIndex;

            var fileExtension = $".{fileType.ToString().ToLower()}";

            var filePath = $"{textBoxDestinationPath.Text}{textBoxFileName.Text}{fileExtension}";

            if (scanner == null)
            {
                MessageBox.Show("Select a scanner from the list!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxFileName.Text))
            {
                MessageBox.Show("Enter a name for the file!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (File.Exists(filePath))
            {
                MessageBox.Show("There is currently a file with the same name and format in the destination location!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (fileType == EFileType.PDF)
                {
                    var tempImagePath = $"{textBoxDestinationPath.Text}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.png";

                    scanner.Scan(EFileType.PNG, tempImagePath);

                    var fileBytes = File.ReadAllBytes(tempImagePath);

                    File.Delete(tempImagePath);

                    var stream = new MemoryStream(fileBytes);

                    pictureBoxOutputFile.Image = new Bitmap(stream);

                    PdfGeneratorHelper.ConvertImageToPdf(filePath, fileBytes);
                }
                else
                {
                    scanner.Scan(fileType, filePath);

                    pictureBoxOutputFile.Image = new Bitmap(filePath);
                }

                MessageBox.Show("Document scanned successfully!", "Success!");
            }
            catch
            {
                MessageBox.Show("Unable to save document", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}