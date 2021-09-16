using DigitalizadorWIA.Enums;
using DigitalizadorWIA.Scanners;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIA;

namespace DigitalizadorWIA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarScanners();
            txtLocalDestino.Text = @"D:\";
            cbFormato.SelectedIndex = 0;
        }

        private void BtnLocalDestino_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            var result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
                txtLocalDestino.Text = folderDlg.SelectedPath;
        }

        private void BtnScanner_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            var scanner = lstScanners.SelectedItem as ScannerWIA;
            var imagem = new ImageFile();
            var path = string.Empty;

            if (scanner == null)
            {
                MessageBox.Show("Selecione um scanner na lista!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtNomeArquivo.Text))
            {
                MessageBox.Show("Digite um nome para o arquivo!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var imagemExtensao = DefinirExtensaoArquivo(cbFormato.SelectedIndex);
                path = Path.Combine(txtLocalDestino.Text, txtNomeArquivo.Text + imagemExtensao);

                if (File.Exists(path))
                {
                    MessageBox.Show("Atualmente existe um arquivo com mesmo nome e formato no local de destino!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                imagem = scanner.Escanear((ETipoArquivo)cbFormato.SelectedIndex);
                imagem.SaveFile(path);
                pictureBox.Image = new Bitmap(path);
                MessageBox.Show("Documento digitalizado com sucesso!", "Sucesso!");
            }
            catch
            {
                MessageBox.Show("Não foi possível salvar o documento", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGerarPDF_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            var scanner = lstScanners.SelectedItem as ScannerWIA;
            var path = $"{txtLocalDestino.Text}{txtNomeArquivo.Text}.pdf";

            if (scanner == null)
            {
                MessageBox.Show("Selecionar um scanner na lista!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtNomeArquivo.Text))
            {
                MessageBox.Show("Digite um nome para o arquivo!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (File.Exists(path))
                {
                    MessageBox.Show("Atualmente existe um arquivo com mesmo nome e formato no local de destino!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                var nomeImagemTemp = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.png";
                var pathImagemTemp = Path.Combine(txtLocalDestino.Text, nomeImagemTemp);
                var imagemTemp = scanner.Escanear(ETipoArquivo.PNG);
                imagemTemp.SaveFile(pathImagemTemp);

                using (var pdf = new Document(PageSize.LETTER, 5f, 5f, 5f, 5f))
                {
                    PdfWriter.GetInstance(pdf, new FileStream(path, FileMode.Create));
                    pdf.Open();
                    var imagemAnexadaPdf = iTextSharp.text.Image.GetInstance(pathImagemTemp);
                    imagemAnexadaPdf.ScaleToFit(650f, 780f);
                    imagemAnexadaPdf.Alignment = Element.ALIGN_CENTER;
                    pdf.Add(imagemAnexadaPdf);
                }

                File.Delete(pathImagemTemp);
                MessageBox.Show("Documento PDF criado com sucesso!", "Sucesso!");
            }
            catch
            {
                MessageBox.Show("Não foi possível criar arquivo PDF!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Eventos

        #region Metodos Privados

        private void ListarScanners()
        {
            lstScanners.Items.Clear();
            var deviceManager = new DeviceManager();

            foreach (DeviceInfo dispositivo in deviceManager.DeviceInfos)
                if (dispositivo.Type == WiaDeviceType.ScannerDeviceType)
                    lstScanners.Items.Add(new ScannerWIA(dispositivo));
        }

        private string DefinirExtensaoArquivo(int index)
        {
            switch (index)
            {
                case 0:
                    return ".png";

                case 1:
                    return ".jpeg";

                case 2:
                    return ".tiff";

                case 3:
                    return ".bmp";

                case 4:
                    return ".gif";
                default:
                    return ".png";
            }
        }

        #endregion Metodos Privados
    }
}