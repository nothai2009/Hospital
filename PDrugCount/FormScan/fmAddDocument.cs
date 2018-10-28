using Manina.Windows.Forms;
using ReadWriteIniFileExample;
using Saraff.Twain;
using ScanDocument;
using Spire.Pdf;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAddDocument : Form
    {
        private fmSettingConfig f = new fmSettingConfig();
        private static string _abbr, itemPic;
        private DBClass dc = new DBClass();

        public fmAddDocument(string abbr)
        {
            InitializeComponent();

            ReadPrinter();


            try
            {
                //    //setting form to 80% of screen resolution:
                //    const int _const = 90;
                //    int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                //    int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                //    this.Size = new Size((screenWidth * _const) / 100, (screenHeight * _const) / 100);

                //    _abbr = abbr;
                //    this._twain.OpenDSM();
                //    this._twain.OpenDataSource();
                //    this._twain.Capabilities.XResolution.Set(150f);//set XResolution :this._twain.SetResolutions(600f); ตั้งค่าความละเอียดของภาพที่แสกน
                //    this._twain.Capabilities.YResolution.Set(150f);//set YResolution  ตั้งค่าความละเอียดของภาพที่แสกน
                //    this._twain.ShowUI = true;//not show UI driver scan ตั้งค่าไม่ให้แสดง UI ของ Driver ตอนสั้งแสกน
                //    this._twain.Capabilities.PixelType.Set(TwPixelType.RGB); //ตั้งค่าสีของไฟล์ที่แสกน
                //    var _supportedSizesCap = this._twain.IsCapSupported(TwCap.SupportedSizes);

                //    //#region Get list supported sizes (as sample)

                //    if ((_supportedSizesCap & TwQC.Get) != 0)
                //    {
                //        var _supportedSizes = this._twain.GetCap(TwCap.SupportedSizes) as Twain32.Enumeration;
                //        var _currentSize = (TwSS)_supportedSizes[_supportedSizes.CurrentIndex];
                //        for (int i = 0; i < _supportedSizes.Count; i++)
                //        {
                //            System.Diagnostics.Debug.WriteLine((TwSS)_supportedSizes[i]); //show supported sizes
                //        }
                //    }

                //    //#endregion

                //    if ((_supportedSizesCap & TwQC.Set) != 0)
                //    {
                //        this._twain.SetCap(TwCap.SupportedSizes, (ushort)TwSS.A4);//set size A4
                //        this._twain.SetCap(TwCap.FeederEnabled, true);//set scanner use Feeder
                //    }

                //    this._twain.CloseDataSource();
                //}
                //catch
                //{
                //    //MessageBox.Show("ยังไม่ไดเปิดเครื่องสแกน");
                //}

                //bool showui = false;
                //if (chkShowUI.Checked == false)
                //{
                //    showui = false;
                //}
                //else
                //{
                //    showui = true;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "scan not completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadIni()
        {
            try
            {
                string value = IniFileHelper.ReadValue("Printer", "Printer", Path.GetFullPath(dc.pathIni));

                cbxPrinter.ComboBox.DataSource = new object[] { value };
                cbxPrinter.ComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                // throw;
            }
            
        }

        private void ReadPrinter()
        {
            try
            {
                string value = IniFileHelper.ReadValue("Printer", "Printer", Path.GetFullPath(dc.pathIni));

                cbxPrinter.ComboBox.DataSource = new object[] { value };
                cbxPrinter.ComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                // throw;
            }
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            try
            {
                this._twain.Acquire();// เรียกใช้ function Acquire จาก lib ให้ทำการแสนก
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "scan not completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSelectScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (Environment.OSVersion.Platform == PlatformID.Unix)// เช็ค driver เครื่องแสกน
                {
                    SelectSourceForm _dlg = new SelectSourceForm { Twain = this._twain };
                    if (_dlg.ShowDialog() == DialogResult.OK)
                    {
                        _twain.SetDefaultSource(_dlg.SourceIndex);
                        _twain.SourceIndex = _dlg.SourceIndex;
                    }
                }
                else
                {
                    _twain.CloseDataSource();
                    _twain.SelectSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "select driver not completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            fmSettingScanner f = new fmSettingScanner();
            f.Show();
        }

        private void ShowcbxDOC_TYPE()
        {
            var cbx = tscbxDOC_TYPE;
            var sql = "SELECT [id],[doc_name]FROM [doc_type]WHERE [hide]='N'";
            var dt = new DBClass().SqlGetData(sql);
            cbx.ComboBox.DataSource = dt;
            cbx.ComboBox.ValueMember = "id";
            cbx.ComboBox.DisplayMember = "doc_name";
            cbx.SelectedIndex = 0;
        }

        private void fmAddDocument_Load(object sender, EventArgs e)
        {
            ShowcbxDOC_TYPE();
            ////MongoDB
            //ReadIni();
            ////ShowDataCombobox();
            ////tscbxDOC_TYPE.ComboBox.SelectedIndex = 0;

            //imageListView1.Items.Clear();
            //imageListView1.Items.ImageListView.Refresh();

            ////Create Folder pathShow
            //if (!Directory.Exists(dc.pathShow))
            //    Directory.CreateDirectory(dc.pathShow);

            ////Create Folder pathFileUpload
            //if (!Directory.Exists(dc.pathFileUpload))
            //    Directory.CreateDirectory(dc.pathFileUpload);

            ////Create Folder pathScan
            //if (!Directory.Exists(dc.pathScan))
            //    Directory.CreateDirectory(dc.pathScan);

            ////Delete File ALL Old
            //DirectoryInfo di = new DirectoryInfo(dc.pathShow);
            //foreach (FileInfo file in di.GetFiles())
            //{
            //    file.Delete();
            //}

            //FTP
            //ReadPrinter();
            ////ShowDataCombobox();
            ////tscbxDOC_TYPE.ComboBox.SelectedIndex = 0;

            //imageListView1.Items.Clear();
            //imageListView1.Items.ImageListView.Refresh();

            ////Create Folder pathShow
            //if (!Directory.Exists(dc.pathShow))
            //    Directory.CreateDirectory(dc.pathShow);

            ////Create Folder pathFileUpload
            //if (!Directory.Exists(dc.pathFileUpload))
            //    Directory.CreateDirectory(dc.pathFileUpload);

            ////Create Folder pathScan
            //if (!Directory.Exists(dc.pathScan))
            //    Directory.CreateDirectory(dc.pathScan);

            ////Delete File ALL Old
            //DirectoryInfo di = new DirectoryInfo(dc.pathShow);
            //foreach (FileInfo file in di.GetFiles())
            //{
            //    file.Delete();
            //}

            //ShowData();
        }

        //private void ShowData()
        //{
        //    var queryFID = Query.And(Query<Entity>.EQ(p => p.JOB_ID, _abbr));//query select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
        //    var chkFID = collection.Find(queryFID);//select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
        //    var i = 0;
        //    foreach (var lt in chkFID)//to display the parent document
        //    {
        //        var path = dc.pathShow + lt.FID + ".jpg";
        //        ObjectId oid = new ObjectId(lt.FID.ToString());
        //        var file1 = db.GridFS.FindOne(Query.EQ("_id", oid));
        //        using (var stream = file1.OpenRead())
        //        {
        //            var bytes = new byte[stream.Length];
        //            stream.Read(bytes, 0, (int)stream.Length);
        //            using (var newFs = new FileStream(path, FileMode.Create))
        //            {
        //                newFs.Write(bytes, 0, bytes.Length);
        //            }
        //        }
        //        i++;
        //    }
        //    string[] pdfFiles = Directory.GetFiles(dc.pathShow, "*.jpg");
        //    string[] arr4 = new string[pdfFiles.Length];
        //    for (int j = 0; j < pdfFiles.Length; j++)
        //    {
        //        arr4[j] = pdfFiles[j].ToString();
        //    }

        //    imageListView1.Items.AddRange(arr4);
        //    imageListView1.Items.ImageListView.Refresh();
        //}

        private void _twain_AcquireCompleted(object sender, EventArgs e)
        {
            int i = 0;

            if (_twain.ImageCount > 0)//ถ้าไฟล์ที่แสนกเข้ามา มากกว่า 0
            {
                while (i < _twain.ImageCount)// i = 0 น้อยกว่า จำนวนเอกสารที่แสกนเข้ามา
                {
                    DateTime time = DateTime.Now;                   // Use current time
                    string format = "d-M-yy_h-mm-ss";                  // Use this format

                    bool exists = Directory.Exists(dc.pathScan);

                    if (!exists)
                        Directory.CreateDirectory(dc.pathScan);

                    var path = dc.pathScan + i + time.ToString(format) + ".jpg"; //ตัวแปร path ตั้งเป็นชื่อไฟล์
                    this._twain.GetImage(i).Save(path, ImageFormat.Jpeg);//save รูปที่แสกนไว้ในได C:\\

                    InsertPicMongo(path, _abbr, tscbxDOC_TYPE.ComboBox.SelectedValue.ToString());
                    i++;
                }
            }
            //ShowData();
        }

        private void tsbAddFiles_Click(object sender, EventArgs e)
        {
            //Create Folder FileUpload
            var name_folder = "FileUpload";
            if (!Directory.Exists(name_folder))
                Directory.CreateDirectory(name_folder);

            //Delete File ALL Old
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory + @"\FileUpload\");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            string folder = Properties.Settings.Default.LastFolder;
            if (Directory.Exists(folder))
                opfd1.InitialDirectory = folder;

            if (opfd1.ShowDialog() == DialogResult.OK)
            {
                folder = Path.GetDirectoryName(opfd1.FileName);
                Properties.Settings.Default.LastFolder = folder;
                Properties.Settings.Default.Save();

                PdfDocument doc = new PdfDocument();
                var path = opfd1.FileName;
                doc.LoadFromFile(path);

                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    Image emf = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile);
                    var file = Environment.CurrentDirectory + @"\FileUpload\Pic_" + _abbr + 1 + ".tif";
                    emf.Save(file, ImageFormat.Tiff);

                    WebClient client = new WebClient();
                    client.Credentials = new NetworkCredential("it", "it");
                    //var ftp = "ftp://192.168.0.14/OPSERS/"+ file;
                    var ftp = f._serverFTP + f._passFTP + file;
                    client.UploadFile(ftp, WebRequestMethods.Ftp.UploadFile, file);
                }
            }

            //ShowData();
        }

        private void thumbnailsToolStripButton_Click(object sender, EventArgs e)
        {
            imageListView1.View = Manina.Windows.Forms.View.Thumbnails;
        }

        private void galleryToolStripButton_Click(object sender, EventArgs e)
        {
            imageListView1.View = Manina.Windows.Forms.View.Gallery;
        }

        private void paneToolStripButton_Click(object sender, EventArgs e)
        {
            imageListView1.View = Manina.Windows.Forms.View.Pane;
        }

        private void detailsToolStripButton_Click(object sender, EventArgs e)
        {
            imageListView1.View = Manina.Windows.Forms.View.Details;
        }

        private void rotateCCWToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ImageListViewItem item in imageListView1.SelectedItems)
            {
                item.BeginEdit();
                using (Image img = Image.FromFile(item.FileName))
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    img.Save(item.FileName);
                }
                item.Update();
                item.EndEdit();
            }
            //UpdateMongo();
        }

        private void rotateCWToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ImageListViewItem item in imageListView1.SelectedItems)
            {
                item.BeginEdit();
                using (Image img = Image.FromFile(item.FileName))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    img.Save(item.FileName);
                }
                item.Update();
                item.EndEdit();
            }
            //UpdateMongo();
        }

        private void UpdateMongo()
        {
            //ยังเขียนไม่เสร็จ
            //using (var fs = new FileStream(, FileMode.Open))//insert ไฟล์ภาพไปยัง mongodb ในตาราง fs.files และ fs.chunks
            //{
            //    var gridFsInfo = db.GridFS.Upload(fs, );
            //    //string fileID = gridFsInfo.Id.ToString();
            //    //FID = new ObjectId(fileID);
            //    //var file = db.GridFS.FindOne(Query.EQ("_id", FID));//select id ของไฟล์ภาพกลับมาไว้ไปเก็บในตาราง docs
            //}
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (imageListView1.Items.Count > 0)
            {
                if (imageListView1.SelectedItems.Count > 0)
                {
                    var objPrintDoc = new PrintDocument();
                    objPrintDoc.PrintPage += (obj, eve) =>
                    {
                        Image img = System.Drawing.Image.FromFile(label2.Text);
                        Point loc = new Point(0, 0);
                        eve.Graphics.DrawImage(img, loc);
                    };
                    objPrintDoc.PrinterSettings.PrinterName = cbxPrinter.SelectedItem.ToString();
                    objPrintDoc.Print();
                }
            }
        }

        private void cbxPrinter_Click(object sender, EventArgs e)
        {
            cbxPrinter.Items.Clear();
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                var cbx = cbxPrinter;
                cbxPrinter.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cbx.SelectedIndex = cbx.Items.IndexOf(strPrinter);
                }
            }
        }

        private void ReadIniFile()
        {
            try
            {
                string text = File.ReadAllText(dc.pathIni);
            }
            catch (Exception)
            {
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (imageListView1.Items.Count > 0)
            {
                if (imageListView1.SelectedItems.Count > 0)
                {
                    var files = Directory.GetFiles(dc.pathShow, "*.jpg");
                    foreach (var i in files)
                    {
                        var objPrintDoc = new PrintDocument();
                        objPrintDoc.PrintPage += (obj, eve) =>
                        {
                            Image img = System.Drawing.Image.FromFile(i);
                            Point loc = new Point(0, 0);
                            eve.Graphics.DrawImage(img, loc);
                        };
                        objPrintDoc.PrinterSettings.PrinterName = cbxPrinter.SelectedItem.ToString();
                        objPrintDoc.Print();
                    }
                }
            }
        }

        private void cbxPrinter_DropDownClosed(object sender, EventArgs e)
        {
            bool result = IniFileHelper.WriteValue("Printer", "Printer", cbxPrinter.SelectedItem.ToString(), Path.GetFullPath(dc.pathIni));
            ReadIniFile();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxPrinter_DropDown(object sender, EventArgs e)
        {
            cbxPrinter.ComboBox.DataSource = null;
            cbxPrinter.ComboBox.Items.Clear();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบไฟล์ : " + itemPic + " ใช่หรือไม่?", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Delete File All ON Folder Old
                DirectoryInfo di = new DirectoryInfo(dc.pathShow);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                DeletePicMongo(itemPic);
                imageListView1.Items.Clear();
                //imageListView1.Items.ImageListView.Refresh();
                //ShowData();
            }
        }

        private void tslDeletePicAll_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("คุณต้องการลบไฟล์ : " + itemPic + " ใช่หรือไม่?", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    //Delete File All ON Folder Old
            //    DirectoryInfo di = new DirectoryInfo(dc.pathShow);
            //    foreach (FileInfo file in di.GetFiles())
            //    {
            //        file.Delete();
            //    }

            //    dc.DeletePicMongo(itemPic);
            //    imageListView1.Items.Clear();
            //    //imageListView1.Items.ImageListView.Refresh();
            //    ShowData();
            //}
        }

        private void imageListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            int selected = e.Item.Index;
            label2.Text = imageListView1.Items[selected].FileName;
            itemPic = imageListView1.Items[selected].Text;
        }

        public void InsertPicMongo(string path, string _JOB_ID, string DOC_TYPE)
        {
            //ObjectId FID_Pic;
            //var db = dc.connectMongoDB();
            //using (FileStream fs = new FileStream(path, FileMode.Open))//insert ไฟล์ภาพไปยัง mongodb ในตาราง fs.files และ fs.chunks
            //{
            //    MongoGridFSFileInfo gridFsInfo = db.GridFS.Upload(fs, path);
            //    String fileID = gridFsInfo.Id.ToString();
            //    FID_Pic = new ObjectId(fileID);
            //    MongoGridFSFileInfo file = db.GridFS.FindOne(Query.EQ("_id", FID_Pic));//select id ของไฟล์ภาพกลับมาไว้ไปเก็บในตาราง docs
            //}//end gridFS insert file img

            //MongoCollection<Entity> docs = db.GetCollection<Entity>("pics");
            //Entity doc = new Entity //กำหนดค่า ที่จะ insert to db
            //{
            //    JOB_ID = _JOB_ID,
            //    //DEPT_ID = User._U_DEPT,
            //    FID = FID_Pic,
            //    HIDE = "N",
            //    TYPE_DOC = DOC_TYPE,
            //};
            //docs.Insert(doc);//insert ข้อมูล to mongo
        }

        private void tscbxDOC_TYPE_Click(object sender, EventArgs e)
        {
            ShowcbxDOC_TYPE();
        }

        public void DeletePicMongo(string itemPic)
        {
            //var db = dc.connectMongoDB();
            //MongoCollection<Entity> collection = db.GetCollection<Entity>("pics");
            //string[] words = itemPic.Split('.');
            //var query = Query.And(Query<Entity>.EQ(p => p.JOB_ID, words[0]));//query select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
            //var chkFile = collection.Find(query);//select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
            //foreach (var lt in chkFile)//to display the parent document
            //{
            //    Console.WriteLine(lt._id.ToString());
            //    //dgvFID.Rows.Add(lt.FID.ToString());
            //}

            //MongoCollection cl = db.GetCollection<Entity>("pics");
            //var query1 = Query<Entity>.EQ(fd => fd.FID, new ObjectId(words[0]));
            //cl.Remove(query1);

            //MongoCollection cl2 = db.GetCollection<Entity>("fs.files");
            //var query2 = Query<Entity>.EQ(fd => fd._id, new ObjectId(words[0]));
            //cl2.Remove(query2);

            //MongoCollection cl3 = db.GetCollection<Entity>("fs.chunks");
            //var query3 = Query<Entity>.EQ(fd => fd.files_id, new ObjectId(words[0]));
            //cl3.Remove(query3);
        }
    }
}