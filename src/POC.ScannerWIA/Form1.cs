using POC.ScannerWIA.Enums;
using POC.ScannerWIA.Helpers;
using POC.ScannerWIA.Scanners;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WIA;

namespace POC.ScannerWIA;

internal partial class Form1 : Form
{
    private readonly BackgroundWorker _backgroundWorker = new();

    public Form1()
    {
        InitializeComponent();
        _backgroundWorker.DoWork += BackgroundWorker_DoWork;
        _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        SearchScanners();
        dropDownFileType.SelectedIndex = 0;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        ValidateScanners();
    }

    private void BtnSearchForScanners_Click(object sender, EventArgs e)
    {
        SearchScanners();
        ValidateScanners();
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

        var scanner = (Scanner)listScannerList.SelectedItem;
        if (scanner == null)
        {
            MessageBox.Show("Select a scanner from the list!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var fileType = (FileType)dropDownFileType.SelectedIndex;
        var filePath = $"{textBoxDestinationPath.Text}{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}.{fileType.ToString().ToLower()}";
        if (File.Exists(filePath))
        {
            MessageBox.Show("There is currently a file with the same name and format in the destination location!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Enabled = false;
        pictureBoxLoad.Visible = true;
        ImageAnimator.Animate(pictureBoxLoad.Image, OnFrameChanged);

        _backgroundWorker.RunWorkerAsync(new { scanner, fileType, filePath });
    }

    private void SearchScanners()
    {
        listScannerList.Items.Clear();

        var deviceManager = new DeviceManager();
        foreach (DeviceInfo device in deviceManager.DeviceInfos)
        {
            if (device.Type == WiaDeviceType.ScannerDeviceType)
            {
                try
                {
                    var scanner = new Scanner(device);
                    listScannerList.Items.Add(scanner);
                }
                catch { }
            }
        }

        if (listScannerList.Items.Count > 0)
            listScannerList.SelectedIndex = 0;
    }

    private void ValidateScanners()
    {
        if (listScannerList.Items.Count == 0)
            MessageBox.Show("No scanner devices were found.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void OnFrameChanged(object sender, EventArgs e)
    {
        pictureBoxLoad.Invalidate();
    }

    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            var args = e.Argument as dynamic;
            var scanner = args.scanner;
            var fileType = args.fileType;
            var filePath = args.filePath;

            var scannedImageFile = scanner.Scan(fileType);

            var fileToSave = fileType == FileType.PDF 
                ? PdfHelper.ConvertImageToPdf(scannedImageFile) 
                : scannedImageFile;

            File.WriteAllBytes(filePath, fileToSave);

            pictureBoxOutputFile.Image = new Bitmap(new MemoryStream(scannedImageFile));
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

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        pictureBoxLoad.Visible = false;
        Enabled = true;
        Activate();
    }
}