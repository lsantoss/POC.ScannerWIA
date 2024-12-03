namespace POC.ScannerWIA
{
    partial class Form1
    {
        /// <summary>
        /// Designer variable required.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources being used.
        /// </summary>
        /// <param name="disposing">true if it is necessary to dispose of managed resources; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBoxConfigurations = new System.Windows.Forms.GroupBox();
            btnSearchForScanners = new System.Windows.Forms.Button();
            labelFileType = new System.Windows.Forms.Label();
            dropDownFileType = new System.Windows.Forms.ComboBox();
            buttonScan = new System.Windows.Forms.Button();
            buttonModifyPath = new System.Windows.Forms.Button();
            textBoxDestinationPath = new System.Windows.Forms.TextBox();
            labelDestinationPath = new System.Windows.Forms.Label();
            labelScannerList = new System.Windows.Forms.Label();
            listScannerList = new System.Windows.Forms.ListBox();
            groupBoxOutputFile = new System.Windows.Forms.GroupBox();
            pictureBoxLoad = new System.Windows.Forms.PictureBox();
            pictureBoxOutputFile = new System.Windows.Forms.PictureBox();
            groupBoxConfigurations.SuspendLayout();
            groupBoxOutputFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOutputFile).BeginInit();
            SuspendLayout();
            // 
            // groupBoxConfigurations
            // 
            groupBoxConfigurations.Controls.Add(btnSearchForScanners);
            groupBoxConfigurations.Controls.Add(labelFileType);
            groupBoxConfigurations.Controls.Add(dropDownFileType);
            groupBoxConfigurations.Controls.Add(buttonScan);
            groupBoxConfigurations.Controls.Add(buttonModifyPath);
            groupBoxConfigurations.Controls.Add(textBoxDestinationPath);
            groupBoxConfigurations.Controls.Add(labelDestinationPath);
            groupBoxConfigurations.Controls.Add(labelScannerList);
            groupBoxConfigurations.Controls.Add(listScannerList);
            groupBoxConfigurations.Location = new System.Drawing.Point(15, 15);
            groupBoxConfigurations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigurations.Name = "groupBoxConfigurations";
            groupBoxConfigurations.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigurations.Size = new System.Drawing.Size(261, 764);
            groupBoxConfigurations.TabIndex = 0;
            groupBoxConfigurations.TabStop = false;
            groupBoxConfigurations.Text = "Configurations";
            // 
            // btnSearchForScanners
            // 
            btnSearchForScanners.Location = new System.Drawing.Point(15, 529);
            btnSearchForScanners.Name = "btnSearchForScanners";
            btnSearchForScanners.Size = new System.Drawing.Size(223, 45);
            btnSearchForScanners.TabIndex = 10;
            btnSearchForScanners.Text = "Search for scanners";
            btnSearchForScanners.UseVisualStyleBackColor = true;
            btnSearchForScanners.Click += BtnSearchForScanners_Click;
            // 
            // labelFileType
            // 
            labelFileType.AutoSize = true;
            labelFileType.Location = new System.Drawing.Point(15, 589);
            labelFileType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFileType.Name = "labelFileType";
            labelFileType.Size = new System.Drawing.Size(52, 15);
            labelFileType.TabIndex = 3;
            labelFileType.Text = "File Type";
            // 
            // dropDownFileType
            // 
            dropDownFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dropDownFileType.FormattingEnabled = true;
            dropDownFileType.Items.AddRange(new object[] { "PDF", "PNG", "JPEG", "TIFF", "BMP", "GIF" });
            dropDownFileType.Location = new System.Drawing.Point(19, 608);
            dropDownFileType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dropDownFileType.Name = "dropDownFileType";
            dropDownFileType.Size = new System.Drawing.Size(219, 23);
            dropDownFileType.TabIndex = 7;
            // 
            // buttonScan
            // 
            buttonScan.Location = new System.Drawing.Point(19, 698);
            buttonScan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonScan.Name = "buttonScan";
            buttonScan.Size = new System.Drawing.Size(219, 45);
            buttonScan.TabIndex = 9;
            buttonScan.Text = "Scan";
            buttonScan.UseVisualStyleBackColor = true;
            buttonScan.Click += ButtonScan_Click;
            // 
            // buttonModifyPath
            // 
            buttonModifyPath.Location = new System.Drawing.Point(179, 660);
            buttonModifyPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonModifyPath.Name = "buttonModifyPath";
            buttonModifyPath.Size = new System.Drawing.Size(59, 23);
            buttonModifyPath.TabIndex = 8;
            buttonModifyPath.Text = "Modify";
            buttonModifyPath.UseVisualStyleBackColor = true;
            buttonModifyPath.Click += ButtonModifyPath_Click;
            // 
            // textBoxDestinationPath
            // 
            textBoxDestinationPath.Enabled = false;
            textBoxDestinationPath.Location = new System.Drawing.Point(19, 660);
            textBoxDestinationPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxDestinationPath.Name = "textBoxDestinationPath";
            textBoxDestinationPath.Size = new System.Drawing.Size(152, 23);
            textBoxDestinationPath.TabIndex = 6;
            textBoxDestinationPath.Text = "D:\\";
            // 
            // labelDestinationPath
            // 
            labelDestinationPath.AutoSize = true;
            labelDestinationPath.Location = new System.Drawing.Point(15, 641);
            labelDestinationPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDestinationPath.Name = "labelDestinationPath";
            labelDestinationPath.Size = new System.Drawing.Size(94, 15);
            labelDestinationPath.TabIndex = 4;
            labelDestinationPath.Text = "Destination Path";
            // 
            // labelScannerList
            // 
            labelScannerList.AutoSize = true;
            labelScannerList.Location = new System.Drawing.Point(15, 36);
            labelScannerList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelScannerList.Name = "labelScannerList";
            labelScannerList.Size = new System.Drawing.Size(70, 15);
            labelScannerList.TabIndex = 1;
            labelScannerList.Text = "Scanner List";
            // 
            // listScannerList
            // 
            listScannerList.FormattingEnabled = true;
            listScannerList.Location = new System.Drawing.Point(19, 54);
            listScannerList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listScannerList.Name = "listScannerList";
            listScannerList.Size = new System.Drawing.Size(219, 469);
            listScannerList.TabIndex = 0;
            // 
            // groupBoxOutputFile
            // 
            groupBoxOutputFile.Controls.Add(pictureBoxLoad);
            groupBoxOutputFile.Controls.Add(pictureBoxOutputFile);
            groupBoxOutputFile.Location = new System.Drawing.Point(295, 15);
            groupBoxOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxOutputFile.Name = "groupBoxOutputFile";
            groupBoxOutputFile.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxOutputFile.Size = new System.Drawing.Size(624, 764);
            groupBoxOutputFile.TabIndex = 1;
            groupBoxOutputFile.TabStop = false;
            groupBoxOutputFile.Text = "Output File";
            // 
            // pictureBoxLoad
            // 
            pictureBoxLoad.BackColor = System.Drawing.Color.Transparent;
            pictureBoxLoad.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLoad.Image");
            pictureBoxLoad.Location = new System.Drawing.Point(175, 229);
            pictureBoxLoad.Name = "pictureBoxLoad";
            pictureBoxLoad.Size = new System.Drawing.Size(270, 272);
            pictureBoxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxLoad.TabIndex = 1;
            pictureBoxLoad.TabStop = false;
            pictureBoxLoad.Visible = false;
            // 
            // pictureBoxOutputFile
            // 
            pictureBoxOutputFile.Location = new System.Drawing.Point(22, 36);
            pictureBoxOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBoxOutputFile.Name = "pictureBoxOutputFile";
            pictureBoxOutputFile.Size = new System.Drawing.Size(581, 707);
            pictureBoxOutputFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxOutputFile.TabIndex = 0;
            pictureBoxOutputFile.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 793);
            Controls.Add(groupBoxOutputFile);
            Controls.Add(groupBoxConfigurations);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "POC.ScannerWIA";
            Load += Form1_Load;
            Shown += Form1_Shown;
            groupBoxConfigurations.ResumeLayout(false);
            groupBoxConfigurations.PerformLayout();
            groupBoxOutputFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOutputFile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConfigurations;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonModifyPath;
        private System.Windows.Forms.ComboBox dropDownFileType;
        private System.Windows.Forms.TextBox textBoxDestinationPath;
        private System.Windows.Forms.Label labelDestinationPath;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label labelScannerList;
        private System.Windows.Forms.ListBox listScannerList;
        private System.Windows.Forms.GroupBox groupBoxOutputFile;
        private System.Windows.Forms.PictureBox pictureBoxOutputFile;
        private System.Windows.Forms.Button btnSearchForScanners;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
    }
}