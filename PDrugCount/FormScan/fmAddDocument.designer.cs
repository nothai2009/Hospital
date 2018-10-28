namespace COS
{
    partial class fmAddDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddDocument));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tslDeletePicAll = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this._twain = new Saraff.Twain.Twain32(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.rendererToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.tscbxDOC_TYPE = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateCCWToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rotateCWToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.thumbnailsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.galleryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.paneToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbxPrinter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.label2 = new System.Windows.Forms.ToolStripLabel();
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.opfd1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightCyan;
            this.toolStrip1.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbScan,
            this.toolStripSeparator1,
            this.tsbAddFiles,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.toolStripLabel2,
            this.toolStripSeparator12,
            this.toolStripLabel5,
            this.toolStripSeparator4,
            this.tslDeletePicAll,
            this.toolStripSeparator9,
            this.tsbSelectScan,
            this.toolStripSeparator3,
            this.tsbSetting,
            this.toolStripSeparator10,
            this.toolStripLabel6,
            this.toolStripSeparator11,
            this.toolStripLabel4,
            this.toolStripSeparator14});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbScan
            // 
            this.tsbScan.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tsbScan.Image = ((System.Drawing.Image)(resources.GetObject("tsbScan.Image")));
            this.tsbScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScan.Name = "tsbScan";
            this.tsbScan.Size = new System.Drawing.Size(77, 40);
            this.tsbScan.Text = "สแกนเอกสาร";
            this.tsbScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbScan.Click += new System.EventHandler(this.tsbScan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbAddFiles
            // 
            this.tsbAddFiles.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tsbAddFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFiles.Image")));
            this.tsbAddFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddFiles.Name = "tsbAddFiles";
            this.tsbAddFiles.Size = new System.Drawing.Size(72, 40);
            this.tsbAddFiles.Text = "แนบไฟล์เพิ่ม";
            this.tsbAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAddFiles.Click += new System.EventHandler(this.tsbAddFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 40);
            this.toolStripLabel1.Text = "     ปริ้น     ";
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(84, 40);
            this.toolStripLabel2.Text = "  ปริ้นทั้งหมด  ";
            this.toolStripLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.toolStripLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel5.Image")));
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(93, 40);
            this.toolStripLabel5.Text = "     ลบไฟล์     ";
            this.toolStripLabel5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLabel5.Click += new System.EventHandler(this.toolStripLabel5_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // tslDeletePicAll
            // 
            this.tslDeletePicAll.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tslDeletePicAll.Image = ((System.Drawing.Image)(resources.GetObject("tslDeletePicAll.Image")));
            this.tslDeletePicAll.Name = "tslDeletePicAll";
            this.tslDeletePicAll.Size = new System.Drawing.Size(78, 40);
            this.tslDeletePicAll.Text = "ลบไฟล์ทั้งหมด";
            this.tslDeletePicAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslDeletePicAll.Click += new System.EventHandler(this.tslDeletePicAll_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbSelectScan
            // 
            this.tsbSelectScan.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tsbSelectScan.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectScan.Image")));
            this.tsbSelectScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectScan.Name = "tsbSelectScan";
            this.tsbSelectScan.Size = new System.Drawing.Size(96, 40);
            this.tsbSelectScan.Text = "เลือกเครื่องสแกน";
            this.tsbSelectScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSelectScan.Click += new System.EventHandler(this.tsbSelectScan_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbSetting
            // 
            this.tsbSetting.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tsbSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetting.Image")));
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(99, 40);
            this.tsbSetting.Text = "ตั้งค่าเครื่องสแกน";
            this.tsbSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(74, 40);
            this.toolStripLabel4.Text = "     ปิด     ";
            this.toolStripLabel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel4_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 43);
            // 
            // _twain
            // 
            this._twain.AppProductName = "Saraff.Twain.NET";
            this._twain.Country = Saraff.Twain.TwCountry.THAILAND;
            this._twain.IsTwain2Enable = true;
            this._twain.Language = Saraff.Twain.TwLanguage.THAI;
            this._twain.Parent = null;
            this._twain.AcquireCompleted += new System.EventHandler(this._twain_AcquireCompleted);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStrip.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rendererToolStripLabel,
            this.tscbxDOC_TYPE,
            this.toolStripSeparator8,
            this.rotateCCWToolStripButton,
            this.rotateCWToolStripButton,
            this.toolStripSeparator6,
            this.thumbnailsToolStripButton,
            this.galleryToolStripButton,
            this.paneToolStripButton,
            this.toolStripSeparator7,
            this.toolStripLabel3,
            this.cbxPrinter,
            this.toolStripSeparator13,
            this.toolStripLabel7,
            this.label2});
            this.toolStrip.Location = new System.Drawing.Point(0, 43);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(972, 28);
            this.toolStrip.TabIndex = 1;
            // 
            // rendererToolStripLabel
            // 
            this.rendererToolStripLabel.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.rendererToolStripLabel.Name = "rendererToolStripLabel";
            this.rendererToolStripLabel.Size = new System.Drawing.Size(104, 25);
            this.rendererToolStripLabel.Text = "ประเภทไฟล์สแกน : ";
            // 
            // tscbxDOC_TYPE
            // 
            this.tscbxDOC_TYPE.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tscbxDOC_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbxDOC_TYPE.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbxDOC_TYPE.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.tscbxDOC_TYPE.IntegralHeight = false;
            this.tscbxDOC_TYPE.MaxDropDownItems = 4;
            this.tscbxDOC_TYPE.Name = "tscbxDOC_TYPE";
            this.tscbxDOC_TYPE.Size = new System.Drawing.Size(150, 28);
            this.tscbxDOC_TYPE.Click += new System.EventHandler(this.tscbxDOC_TYPE_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // rotateCCWToolStripButton
            // 
            this.rotateCCWToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCCWToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCCWToolStripButton.Image")));
            this.rotateCCWToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCCWToolStripButton.Name = "rotateCCWToolStripButton";
            this.rotateCCWToolStripButton.Size = new System.Drawing.Size(23, 25);
            this.rotateCCWToolStripButton.Text = "Rotate Counter-clockwise";
            this.rotateCCWToolStripButton.Click += new System.EventHandler(this.rotateCCWToolStripButton_Click);
            // 
            // rotateCWToolStripButton
            // 
            this.rotateCWToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCWToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCWToolStripButton.Image")));
            this.rotateCWToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCWToolStripButton.Name = "rotateCWToolStripButton";
            this.rotateCWToolStripButton.Size = new System.Drawing.Size(23, 25);
            this.rotateCWToolStripButton.Text = "Rotate Clockwise";
            this.rotateCWToolStripButton.Click += new System.EventHandler(this.rotateCWToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
            // 
            // thumbnailsToolStripButton
            // 
            this.thumbnailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thumbnailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbnailsToolStripButton.Image")));
            this.thumbnailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thumbnailsToolStripButton.Name = "thumbnailsToolStripButton";
            this.thumbnailsToolStripButton.Size = new System.Drawing.Size(23, 25);
            this.thumbnailsToolStripButton.Text = "Thumbnails";
            this.thumbnailsToolStripButton.Click += new System.EventHandler(this.thumbnailsToolStripButton_Click);
            // 
            // galleryToolStripButton
            // 
            this.galleryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.galleryToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("galleryToolStripButton.Image")));
            this.galleryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.galleryToolStripButton.Name = "galleryToolStripButton";
            this.galleryToolStripButton.Size = new System.Drawing.Size(23, 25);
            this.galleryToolStripButton.Text = "Gallery";
            this.galleryToolStripButton.Click += new System.EventHandler(this.galleryToolStripButton_Click);
            // 
            // paneToolStripButton
            // 
            this.paneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paneToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paneToolStripButton.Image")));
            this.paneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paneToolStripButton.Name = "paneToolStripButton";
            this.paneToolStripButton.Size = new System.Drawing.Size(23, 25);
            this.paneToolStripButton.Text = "Pane";
            this.paneToolStripButton.Click += new System.EventHandler(this.paneToolStripButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(85, 25);
            this.toolStripLabel3.Text = "เลือกเครื่องปริ้น";
            // 
            // cbxPrinter
            // 
            this.cbxPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbxPrinter.AutoToolTip = true;
            this.cbxPrinter.BackColor = System.Drawing.Color.AntiqueWhite;
            this.cbxPrinter.DropDownHeight = 150;
            this.cbxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cbxPrinter.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.cbxPrinter.IntegralHeight = false;
            this.cbxPrinter.MaxDropDownItems = 4;
            this.cbxPrinter.Name = "cbxPrinter";
            this.cbxPrinter.Size = new System.Drawing.Size(200, 28);
            this.cbxPrinter.DropDown += new System.EventHandler(this.cbxPrinter_DropDown);
            this.cbxPrinter.DropDownClosed += new System.EventHandler(this.cbxPrinter_DropDownClosed);
            this.cbxPrinter.Click += new System.EventHandler(this.cbxPrinter_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(81, 25);
            this.toolStripLabel7.Text = "เครื่องสแกนเนอร์";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Thai Sans Lite", 12F);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.Text = "เครื่อง";
            this.label2.Visible = false;
            // 
            // imageListView1
            // 
            this.imageListView1.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.DefaultImage")));
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.ErrorImage")));
            this.imageListView1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.imageListView1.Location = new System.Drawing.Point(0, 71);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.Size = new System.Drawing.Size(972, 495);
            this.imageListView1.TabIndex = 4;
            this.imageListView1.Text = "";
            this.imageListView1.View = Manina.Windows.Forms.View.Gallery;
            this.imageListView1.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.imageListView1_ItemClick);
            this.imageListView1.SetColumnHeader(Manina.Windows.Forms.ColumnType.Name, 100, 0, false);
            this.imageListView1.SetColumnHeader(Manina.Windows.Forms.ColumnType.FileSize, 100, 1, false);
            this.imageListView1.SetColumnHeader(Manina.Windows.Forms.ColumnType.DateModified, 100, 2, false);
            this.imageListView1.SetColumnHeader(Manina.Windows.Forms.ColumnType.Dimensions, 100, 3, false);
            // 
            // opfd1
            // 
            this.opfd1.FileName = "openFileDialog1";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel6.Image")));
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(81, 40);
            this.toolStripLabel6.Text = "ประเภทเอกสาร";
            this.toolStripLabel6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 43);
            // 
            // fmAddDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 566);
            this.Controls.Add(this.imageListView1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "fmAddDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เอกสารที่แนบ";
            this.Load += new System.EventHandler(this.fmAddDocument_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbScan;
        private System.Windows.Forms.ToolStripButton tsbAddFiles;
        private System.Windows.Forms.ToolStripButton tsbSelectScan;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton rotateCCWToolStripButton;
        private System.Windows.Forms.ToolStripButton rotateCWToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton thumbnailsToolStripButton;
        private System.Windows.Forms.ToolStripButton galleryToolStripButton;
        private System.Windows.Forms.ToolStripButton paneToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel rendererToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox tscbxDOC_TYPE;
        public Saraff.Twain.Twain32 _twain;
        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.OpenFileDialog opfd1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel label2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cbxPrinter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripLabel tslDeletePicAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
    }
}