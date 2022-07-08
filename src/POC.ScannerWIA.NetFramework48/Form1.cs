using POC.ScannerWIA.NetFramework48.Enums;
using POC.ScannerWIA.NetFramework48.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
            dropDownFileType.SelectedIndex = 0;

            listScannerList.Items.Clear();

            var deviceManager = new DeviceManager();

            foreach (DeviceInfo device in deviceManager.DeviceInfos)
                if (device.Type == WiaDeviceType.ScannerDeviceType)
                    listScannerList.Items.Add(new ScannerWIAHelper(device));
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

            var scanner = (ScannerWIAHelper)listScannerList.SelectedItem;

            var fileType = (EFileType)dropDownFileType.SelectedIndex;

            var filePath = $"{textBoxDestinationPath.Text}{textBoxFileName.Text}.{fileType.ToString().ToLower()}";

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
                var scannedFile = scanner.Scan(fileType);
                File.WriteAllBytes(filePath, scannedFile);

                if (fileType != EFileType.PDF)
                    pictureBoxOutputFile.Image = new Bitmap(new MemoryStream(scannedFile));

                MessageBox.Show("Document scanned successfully!", "Success!");
            }
            catch (COMException ex)
            {
                switch ((uint)ex.ErrorCode)
                {
                    case 0x80210006:
                        MessageBox.Show("The scanner is not ready or is busy!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0x80210064:
                        MessageBox.Show("The scanning process has been canceled!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Unable to save document", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}