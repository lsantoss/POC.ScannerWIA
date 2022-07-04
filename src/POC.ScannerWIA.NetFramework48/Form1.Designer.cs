namespace POC.ScannerWIA.NetFramework48
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
            this.groupBoxConfigurations = new System.Windows.Forms.GroupBox();
            this.dropDownFileType = new System.Windows.Forms.ComboBox();
            this.labelFileType = new System.Windows.Forms.Label();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonModifyPath = new System.Windows.Forms.Button();
            this.textBoxDestinationPath = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.labelDestinationPath = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelScannerList = new System.Windows.Forms.Label();
            this.listScannerList = new System.Windows.Forms.ListBox();
            this.groupBoxOutputFile = new System.Windows.Forms.GroupBox();
            this.pictureBoxOutputFile = new System.Windows.Forms.PictureBox();
            this.groupBoxConfigurations.SuspendLayout();
            this.groupBoxOutputFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutputFile)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxConfigurations
            // 
            this.groupBoxConfigurations.Controls.Add(this.labelFileType);
            this.groupBoxConfigurations.Controls.Add(this.dropDownFileType);
            this.groupBoxConfigurations.Controls.Add(this.buttonScan);
            this.groupBoxConfigurations.Controls.Add(this.buttonModifyPath);
            this.groupBoxConfigurations.Controls.Add(this.textBoxDestinationPath);
            this.groupBoxConfigurations.Controls.Add(this.textBoxFileName);
            this.groupBoxConfigurations.Controls.Add(this.labelDestinationPath);
            this.groupBoxConfigurations.Controls.Add(this.labelFileName);
            this.groupBoxConfigurations.Controls.Add(this.labelScannerList);
            this.groupBoxConfigurations.Controls.Add(this.listScannerList);
            this.groupBoxConfigurations.Location = new System.Drawing.Point(13, 13);
            this.groupBoxConfigurations.Name = "groupBoxConfigurations";
            this.groupBoxConfigurations.Size = new System.Drawing.Size(224, 662);
            this.groupBoxConfigurations.TabIndex = 0;
            this.groupBoxConfigurations.TabStop = false;
            this.groupBoxConfigurations.Text = "Configurations";
            // 
            // dropDownFileType
            // 
            this.dropDownFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownFileType.FormattingEnabled = true;
            this.dropDownFileType.Items.AddRange(new object[] {
            "PDF",
            "PNG",
            "JPEG",
            "TIFF",
            "BMP",
            "GIF"});
            this.dropDownFileType.Location = new System.Drawing.Point(16, 505);
            this.dropDownFileType.Name = "dropDownFileType";
            this.dropDownFileType.Size = new System.Drawing.Size(188, 21);
            this.dropDownFileType.TabIndex = 7;
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(13, 489);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(50, 13);
            this.labelFileType.TabIndex = 3;
            this.labelFileType.Text = "File Type";
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(16, 605);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(188, 39);
            this.buttonScan.TabIndex = 9;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.ButtonScan_Click);
            // 
            // buttonModifyPath
            // 
            this.buttonModifyPath.Location = new System.Drawing.Point(16, 576);
            this.buttonModifyPath.Name = "buttonModifyPath";
            this.buttonModifyPath.Size = new System.Drawing.Size(188, 23);
            this.buttonModifyPath.TabIndex = 8;
            this.buttonModifyPath.Text = "Modify Path";
            this.buttonModifyPath.UseVisualStyleBackColor = true;
            this.buttonModifyPath.Click += new System.EventHandler(this.ButtonModifyPath_Click);
            // 
            // textBoxDestinationPath
            // 
            this.textBoxDestinationPath.Enabled = false;
            this.textBoxDestinationPath.Location = new System.Drawing.Point(16, 550);
            this.textBoxDestinationPath.Name = "textBoxDestinationPath";
            this.textBoxDestinationPath.Size = new System.Drawing.Size(188, 20);
            this.textBoxDestinationPath.TabIndex = 6;
            this.textBoxDestinationPath.Text = "D:\\";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(16, 462);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(188, 20);
            this.textBoxFileName.TabIndex = 5;
            // 
            // labelDestinationPath
            // 
            this.labelDestinationPath.AutoSize = true;
            this.labelDestinationPath.Location = new System.Drawing.Point(13, 534);
            this.labelDestinationPath.Name = "labelDestinationPath";
            this.labelDestinationPath.Size = new System.Drawing.Size(85, 13);
            this.labelDestinationPath.TabIndex = 4;
            this.labelDestinationPath.Text = "Destination Path";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(13, 446);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(54, 13);
            this.labelFileName.TabIndex = 2;
            this.labelFileName.Text = "File Name";
            // 
            // labelScannerList
            // 
            this.labelScannerList.AutoSize = true;
            this.labelScannerList.Location = new System.Drawing.Point(13, 31);
            this.labelScannerList.Name = "labelScannerList";
            this.labelScannerList.Size = new System.Drawing.Size(66, 13);
            this.labelScannerList.TabIndex = 1;
            this.labelScannerList.Text = "Scanner List";
            // 
            // listScannerList
            // 
            this.listScannerList.FormattingEnabled = true;
            this.listScannerList.Location = new System.Drawing.Point(16, 47);
            this.listScannerList.Name = "listScannerList";
            this.listScannerList.Size = new System.Drawing.Size(188, 381);
            this.listScannerList.TabIndex = 0;
            // 
            // groupBoxOutputFile
            // 
            this.groupBoxOutputFile.Controls.Add(this.pictureBoxOutputFile);
            this.groupBoxOutputFile.Location = new System.Drawing.Point(253, 13);
            this.groupBoxOutputFile.Name = "groupBoxOutputFile";
            this.groupBoxOutputFile.Size = new System.Drawing.Size(535, 662);
            this.groupBoxOutputFile.TabIndex = 1;
            this.groupBoxOutputFile.TabStop = false;
            this.groupBoxOutputFile.Text = "Output File";
            // 
            // pictureBoxOutputFile
            // 
            this.pictureBoxOutputFile.Location = new System.Drawing.Point(19, 31);
            this.pictureBoxOutputFile.Name = "pictureBoxOutputFile";
            this.pictureBoxOutputFile.Size = new System.Drawing.Size(498, 613);
            this.pictureBoxOutputFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOutputFile.TabIndex = 0;
            this.pictureBoxOutputFile.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 687);
            this.Controls.Add(this.groupBoxOutputFile);
            this.Controls.Add(this.groupBoxConfigurations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POC.ScannerWIA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxConfigurations.ResumeLayout(false);
            this.groupBoxConfigurations.PerformLayout();
            this.groupBoxOutputFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutputFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConfigurations;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonModifyPath;
        private System.Windows.Forms.ComboBox dropDownFileType;
        private System.Windows.Forms.TextBox textBoxDestinationPath;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelDestinationPath;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelScannerList;
        private System.Windows.Forms.ListBox listScannerList;
        private System.Windows.Forms.GroupBox groupBoxOutputFile;
        private System.Windows.Forms.PictureBox pictureBoxOutputFile;
    }
}