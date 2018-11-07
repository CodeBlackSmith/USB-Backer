namespace Backer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileSizeNum = new System.Windows.Forms.NumericUpDown();
            this.totalSizeNum = new System.Windows.Forms.NumericUpDown();
            this.mbLabel2 = new System.Windows.Forms.Label();
            this.mbLabel = new System.Windows.Forms.Label();
            this.totalSizeLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.fileSizeLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.extensionsDataGrid = new System.Windows.Forms.DataGridView();
            this.columnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTypesCheckBox = new System.Windows.Forms.CheckBox();
            this.exceptionsRadio = new System.Windows.Forms.RadioButton();
            this.onlyTypesRadio = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.outputLocationBrowseBtn = new System.Windows.Forms.Button();
            this.outputLocationTxt = new System.Windows.Forms.TextBox();
            this.outputLocationLbl = new System.Windows.Forms.Label();
            this.startOnLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.myDevicesGrid = new System.Windows.Forms.DataGridView();
            this.Checkboxes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Drives = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.outputLocationTt = new System.Windows.Forms.ToolTip(this.components);
            this.aboutTt = new System.Windows.Forms.ToolTip(this.components);
            this.extensionsTt = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openBtn = new System.Windows.Forms.Button();
            this.totalSizeTt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSizeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSizeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDevicesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSizeNum
            // 
            this.fileSizeNum.DecimalPlaces = 1;
            this.fileSizeNum.Location = new System.Drawing.Point(99, 49);
            this.fileSizeNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fileSizeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.fileSizeNum.Name = "fileSizeNum";
            this.fileSizeNum.Size = new System.Drawing.Size(58, 20);
            this.fileSizeNum.TabIndex = 47;
            this.fileSizeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fileSizeNum.ValueChanged += new System.EventHandler(this.fileSizeNum_ValueChanged);
            // 
            // totalSizeNum
            // 
            this.totalSizeNum.DecimalPlaces = 1;
            this.totalSizeNum.Location = new System.Drawing.Point(99, 82);
            this.totalSizeNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.totalSizeNum.Name = "totalSizeNum";
            this.totalSizeNum.Size = new System.Drawing.Size(58, 20);
            this.totalSizeNum.TabIndex = 46;
            this.totalSizeTt.SetToolTip(this.totalSizeNum, "You can set total size limit. In Demo version, you can\'t set more than 10 MB.");
            this.totalSizeNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.totalSizeNum.ValueChanged += new System.EventHandler(this.totalSizeNum_ValueChanged);
            this.totalSizeNum.Resize += new System.EventHandler(this.Form1_Resize);
            // 
            // mbLabel2
            // 
            this.mbLabel2.AutoSize = true;
            this.mbLabel2.Location = new System.Drawing.Point(163, 87);
            this.mbLabel2.Name = "mbLabel2";
            this.mbLabel2.Size = new System.Drawing.Size(23, 13);
            this.mbLabel2.TabIndex = 44;
            this.mbLabel2.Text = "MB";
            // 
            // mbLabel
            // 
            this.mbLabel.AutoSize = true;
            this.mbLabel.Location = new System.Drawing.Point(163, 52);
            this.mbLabel.Name = "mbLabel";
            this.mbLabel.Size = new System.Drawing.Size(23, 13);
            this.mbLabel.TabIndex = 45;
            this.mbLabel.Text = "MB";
            // 
            // totalSizeLimitCheckBox
            // 
            this.totalSizeLimitCheckBox.AutoSize = true;
            this.totalSizeLimitCheckBox.Location = new System.Drawing.Point(11, 84);
            this.totalSizeLimitCheckBox.Name = "totalSizeLimitCheckBox";
            this.totalSizeLimitCheckBox.Size = new System.Drawing.Size(91, 17);
            this.totalSizeLimitCheckBox.TabIndex = 42;
            this.totalSizeLimitCheckBox.Text = "Total size limit";
            this.totalSizeLimitCheckBox.UseVisualStyleBackColor = true;
            this.totalSizeLimitCheckBox.CheckedChanged += new System.EventHandler(this.totalSizeLimitCheckBox_CheckedChanged);
            // 
            // fileSizeLimitCheckBox
            // 
            this.fileSizeLimitCheckBox.AutoSize = true;
            this.fileSizeLimitCheckBox.Location = new System.Drawing.Point(12, 49);
            this.fileSizeLimitCheckBox.Name = "fileSizeLimitCheckBox";
            this.fileSizeLimitCheckBox.Size = new System.Drawing.Size(83, 17);
            this.fileSizeLimitCheckBox.TabIndex = 43;
            this.fileSizeLimitCheckBox.Text = "File size limit";
            this.fileSizeLimitCheckBox.UseVisualStyleBackColor = true;
            this.fileSizeLimitCheckBox.CheckedChanged += new System.EventHandler(this.fileSizeLimitCheckBox_CheckedChanged);
            // 
            // extensionsDataGrid
            // 
            this.extensionsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.extensionsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extensionsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnExtension});
            this.extensionsDataGrid.Location = new System.Drawing.Point(15, 223);
            this.extensionsDataGrid.Name = "extensionsDataGrid";
            this.extensionsDataGrid.RowHeadersVisible = false;
            this.extensionsDataGrid.ShowCellToolTips = false;
            this.extensionsDataGrid.Size = new System.Drawing.Size(206, 97);
            this.extensionsDataGrid.TabIndex = 41;
            this.extensionsTt.SetToolTip(this.extensionsDataGrid, "Specify file extensions (types) that you want to\r\ncopy only, or the types that yo" +
        "u want to exclude.\r\nFor example: .txt, .docx, .mp3");
            this.extensionsDataGrid.EnabledChanged += new System.EventHandler(this.DataGridView_EnabledChanged);
            // 
            // columnExtension
            // 
            this.columnExtension.HeaderText = "Extension";
            this.columnExtension.Name = "columnExtension";
            // 
            // allTypesCheckBox
            // 
            this.allTypesCheckBox.AutoSize = true;
            this.allTypesCheckBox.Location = new System.Drawing.Point(12, 119);
            this.allTypesCheckBox.Name = "allTypesCheckBox";
            this.allTypesCheckBox.Size = new System.Drawing.Size(65, 17);
            this.allTypesCheckBox.TabIndex = 40;
            this.allTypesCheckBox.Text = "All types";
            this.allTypesCheckBox.UseVisualStyleBackColor = true;
            this.allTypesCheckBox.CheckedChanged += new System.EventHandler(this.allTypesCheckBox_CheckedChanged);
            // 
            // exceptionsRadio
            // 
            this.exceptionsRadio.AutoSize = true;
            this.exceptionsRadio.Location = new System.Drawing.Point(28, 180);
            this.exceptionsRadio.Name = "exceptionsRadio";
            this.exceptionsRadio.Size = new System.Drawing.Size(115, 17);
            this.exceptionsRadio.TabIndex = 39;
            this.exceptionsRadio.TabStop = true;
            this.exceptionsRadio.Text = "Except these types";
            this.exceptionsRadio.UseVisualStyleBackColor = true;
            // 
            // onlyTypesRadio
            // 
            this.onlyTypesRadio.AutoSize = true;
            this.onlyTypesRadio.Location = new System.Drawing.Point(28, 147);
            this.onlyTypesRadio.Name = "onlyTypesRadio";
            this.onlyTypesRadio.Size = new System.Drawing.Size(103, 17);
            this.onlyTypesRadio.TabIndex = 38;
            this.onlyTypesRadio.TabStop = true;
            this.onlyTypesRadio.Text = "Only these types";
            this.onlyTypesRadio.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 722);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(13, 551);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(294, 69);
            this.startBtn.TabIndex = 52;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // outputLocationBrowseBtn
            // 
            this.outputLocationBrowseBtn.Location = new System.Drawing.Point(12, 507);
            this.outputLocationBrowseBtn.Name = "outputLocationBrowseBtn";
            this.outputLocationBrowseBtn.Size = new System.Drawing.Size(83, 23);
            this.outputLocationBrowseBtn.TabIndex = 51;
            this.outputLocationBrowseBtn.Text = "Browse";
            this.extensionsTt.SetToolTip(this.outputLocationBrowseBtn, "The directory of the copied USB files");
            this.outputLocationBrowseBtn.UseVisualStyleBackColor = true;
            this.outputLocationBrowseBtn.Click += new System.EventHandler(this.outputLocationBrowseBtn_Click);
            // 
            // outputLocationTxt
            // 
            this.outputLocationTxt.Location = new System.Drawing.Point(12, 481);
            this.outputLocationTxt.Name = "outputLocationTxt";
            this.outputLocationTxt.Size = new System.Drawing.Size(295, 20);
            this.outputLocationTxt.TabIndex = 50;
            this.extensionsTt.SetToolTip(this.outputLocationTxt, "The directory of the copied USB files");
            // 
            // outputLocationLbl
            // 
            this.outputLocationLbl.AutoSize = true;
            this.outputLocationLbl.Location = new System.Drawing.Point(9, 465);
            this.outputLocationLbl.Name = "outputLocationLbl";
            this.outputLocationLbl.Size = new System.Drawing.Size(121, 13);
            this.outputLocationLbl.TabIndex = 49;
            this.outputLocationLbl.Text = "Backup copies location:";
            this.outputLocationTt.SetToolTip(this.outputLocationLbl, "The directory of the copied USB files");
            // 
            // startOnLoginCheckBox
            // 
            this.startOnLoginCheckBox.AutoSize = true;
            this.startOnLoginCheckBox.Location = new System.Drawing.Point(12, 17);
            this.startOnLoginCheckBox.Name = "startOnLoginCheckBox";
            this.startOnLoginCheckBox.Size = new System.Drawing.Size(88, 17);
            this.startOnLoginCheckBox.TabIndex = 53;
            this.startOnLoginCheckBox.Text = "Start on login";
            this.startOnLoginCheckBox.UseVisualStyleBackColor = true;
            this.startOnLoginCheckBox.CheckedChanged += new System.EventHandler(this.startOnLoginCheckBox_CheckedChanged);
            // 
            // myDevicesGrid
            // 
            this.myDevicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDevicesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checkboxes,
            this.Drives});
            this.myDevicesGrid.Location = new System.Drawing.Point(15, 351);
            this.myDevicesGrid.Name = "myDevicesGrid";
            this.myDevicesGrid.RowHeadersVisible = false;
            this.myDevicesGrid.ShowCellToolTips = false;
            this.myDevicesGrid.Size = new System.Drawing.Size(206, 92);
            this.myDevicesGrid.TabIndex = 54;
            this.myDevicesGrid.EnabledChanged += new System.EventHandler(this.DataGridView_EnabledChanged);
            this.myDevicesGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myDevicesGrid_KeyPress);
            // 
            // Checkboxes
            // 
            this.Checkboxes.HeaderText = "";
            this.Checkboxes.Name = "Checkboxes";
            this.Checkboxes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Checkboxes.Width = 25;
            // 
            // Drives
            // 
            this.Drives.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Drives.HeaderText = "My devices";
            this.Drives.Name = "Drives";
            this.Drives.ReadOnly = true;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.BackgroundImage")));
            this.aboutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.aboutBtn.Location = new System.Drawing.Point(500, 4);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(30, 30);
            this.aboutBtn.TabIndex = 55;
            this.aboutTt.SetToolTip(this.aboutBtn, "About");
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "USB Backer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(111, 507);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 56;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 639);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.myDevicesGrid);
            this.Controls.Add(this.startOnLoginCheckBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.outputLocationBrowseBtn);
            this.Controls.Add(this.outputLocationTxt);
            this.Controls.Add(this.outputLocationLbl);
            this.Controls.Add(this.fileSizeNum);
            this.Controls.Add(this.totalSizeNum);
            this.Controls.Add(this.mbLabel2);
            this.Controls.Add(this.mbLabel);
            this.Controls.Add(this.totalSizeLimitCheckBox);
            this.Controls.Add(this.fileSizeLimitCheckBox);
            this.Controls.Add(this.extensionsDataGrid);
            this.Controls.Add(this.allTypesCheckBox);
            this.Controls.Add(this.exceptionsRadio);
            this.Controls.Add(this.onlyTypesRadio);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "USB Backer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fileSizeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSizeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDevicesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown fileSizeNum;
        private System.Windows.Forms.NumericUpDown totalSizeNum;
        private System.Windows.Forms.Label mbLabel2;
        private System.Windows.Forms.Label mbLabel;
        private System.Windows.Forms.CheckBox totalSizeLimitCheckBox;
        private System.Windows.Forms.CheckBox fileSizeLimitCheckBox;
        private System.Windows.Forms.DataGridView extensionsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExtension;
        private System.Windows.Forms.CheckBox allTypesCheckBox;
        private System.Windows.Forms.RadioButton exceptionsRadio;
        private System.Windows.Forms.RadioButton onlyTypesRadio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button outputLocationBrowseBtn;
        private System.Windows.Forms.TextBox outputLocationTxt;
        private System.Windows.Forms.Label outputLocationLbl;
        private System.Windows.Forms.CheckBox startOnLoginCheckBox;
        private System.Windows.Forms.DataGridView myDevicesGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checkboxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drives;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolTip outputLocationTt;
        private System.Windows.Forms.ToolTip aboutTt;
        private System.Windows.Forms.ToolTip extensionsTt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ToolTip totalSizeTt;
    }
}

