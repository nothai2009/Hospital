using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using ReadWriteIniFileExample;
using ScanDocument;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace UDH
{
    internal class DBClass
    {
        private string strCon = "Data Source=192.168.0.5;User ID=homc;Password=homc;Initial Catalog=UHDATA";
        public string pathScan = Environment.CurrentDirectory + @"\Scan\";
        public string pathFileUpload = Environment.CurrentDirectory + @"\FileUpload\";
        public string pathShow = Environment.CurrentDirectory + @"\Show\";
        public string pathIni = Environment.CurrentDirectory + @"\Setting.ini";
        public string pathReport = Environment.CurrentDirectory + @"\Report\";
        private DataTable dt = new DataTable();

        //MongoDB
        #region

        public MongoDatabase connectMongoDB()
        {
            //string connS = "mongodb://[cosR:P@ssw0rd]172.16.254.213[:27017/cos]"; //mongodb://[username:password@]hostname[:port][/[database][?options]]
            var conS = "mongodb://172.16.254.213:27017";
            MongoClient client = new MongoClient(conS);
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("cos");
            return db;
        }

        public void InsertPicMongo(string path, string _JOB_ID, string DOC_TYPE)
        {
            ObjectId FID_Pic;
            var db = connectMongoDB();
            using (FileStream fs = new FileStream(path, FileMode.Open))//insert ไฟล์ภาพไปยัง mongodb ในตาราง fs.files และ fs.chunks
            {
                MongoGridFSFileInfo gridFsInfo = db.GridFS.Upload(fs, path);
                String fileID = gridFsInfo.Id.ToString();
                FID_Pic = new ObjectId(fileID);
                MongoGridFSFileInfo file = db.GridFS.FindOne(Query.EQ("_id", FID_Pic));//select id ของไฟล์ภาพกลับมาไว้ไปเก็บในตาราง docs
            }//end gridFS insert file img

            MongoCollection<Entity> docs = db.GetCollection<Entity>("pics");
            Entity doc = new Entity //กำหนดค่า ที่จะ insert to db
            {
                JOB_ID = _JOB_ID,
                DEPT_ID = User._U_DEPT,
                FID = FID_Pic,
                HIDE = "N",
                TYPE_DOC = DOC_TYPE,
            };
            docs.Insert(doc);//insert ข้อมูล to mongo
        }

        public void DeletePicMongo(string itemPic)
        {
            var db = connectMongoDB();
            MongoCollection<Entity> collection = db.GetCollection<Entity>("pics");
            string[] words = itemPic.Split('.');
            var query = Query.And(Query<Entity>.EQ(p => p.JOB_ID, words[0]));//query select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
            var chkFile = collection.Find(query);//select ค่าจาก mongo ว่ามีไฟล์นี้แล้วหรือไม่
            foreach (var lt in chkFile)//to display the parent document
            {
                Console.WriteLine(lt._id.ToString());
                //dgvFID.Rows.Add(lt.FID.ToString());
            }

            MongoCollection cl = db.GetCollection<Entity>("pics");
            var query1 = Query<Entity>.EQ(fd => fd.FID, new ObjectId(words[0]));
            cl.Remove(query1);

            MongoCollection cl2 = db.GetCollection<Entity>("fs.files");
            var query2 = Query<Entity>.EQ(fd => fd._id, new ObjectId(words[0]));
            cl2.Remove(query2);

            MongoCollection cl3 = db.GetCollection<Entity>("fs.chunks");
            var query3 = Query<Entity>.EQ(fd => fd.files_id, new ObjectId(words[0]));
            cl3.Remove(query3);
        }

        #endregion

        //SQL Server Class
        #region
        public static SqlTransaction tr;
        private int i;

        //New
        public DataTable SqlGetData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ผิดพลาด sql" + ex.Message);
                }
            }
            return dt;
        }

        public DataTable SqlConfig()
        {
            using (var connection = new SqlConnection())
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT name FROM master.sys.databases ORDER BY name";

                var adapter = new SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                DataTable dt = dataset.Tables[0];
                return dt;
                //for (int i = 0; i < dtDatabases.Rows.Count; i++)
                //{
                //    cbxDatabaseName1.Items.Add(dtDatabases.Rows[i].ItemArray[0]);
                //}
            }
        }

        public int SqlExecute(string sql, SqlParameterCollection parameters)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    tr = conn.BeginTransaction();

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Transaction = tr;

                    cmd.Parameters.Clear();

                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
                    }
                    i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error SqlExecute " + ex.Message);
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    // Attempt to roll back the transaction.
                    try
                    {
                        tr.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                finally
                {
                    conn.Close();
                }
                return i;
            }
        }

        public int SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                tr = conn.BeginTransaction();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = tr;

                i = cmd.ExecuteNonQuery();
                tr.Commit();
                conn.Close();
                return i;
            }
        }

        public int AutoNunber(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());

                if (value == "")
                {
                    i = 1;
                }
                else
                {
                    value = value.Replace("ST", "");
                    i = Convert.ToInt32(value) + 1;
                }
                return i;
            }
        }

        public int AutoNunberInt(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());

                if (value == "")
                {
                    i = 1;
                }
                else
                {
                    i = Convert.ToInt32(value) + 1;
                }
                return i;
            }
        }

        public string AutoNunberNew(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());
                if (value == "")
                {
                    value = 'ค' + DateTime.Now.ToString("yy") + "00001";
                }
                return value;
            }
        }

        public int TOTAL_STANDARD_PRICE(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                try
                {
                    i = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
                catch
                {
                    i = 0;
                }

                return i;
            }
        }

        #endregion

        #region Printer

        public void LoadPrinter(ComboBox cbx)
        {
            string value = IniFileHelper.ReadValue("Printer", "Printer", Path.GetFullPath(pathIni));
            cbx.Items.Add(value);
            cbx.SelectedIndex = 0;
        }

        public void cbxPrinterDropDown(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();
        }

        public void cbxPrinter_DropDownClosed(ComboBox cbx)
        {
            try
            {
                bool result = IniFileHelper.WriteValue("Printer", "Printer", cbx.SelectedItem.ToString(), Path.GetFullPath(pathIni));
            }
            catch
            {
            }
        }

        public void cbxPrinter_MouseClick(ComboBox cbx)
        {
            cbx.Items.Clear();
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbx.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cbx.SelectedIndex = cbx.Items.IndexOf(strPrinter);
                }
            }
        }

        #endregion

        #region Getdata

        public string GetDate()
        {
            var sql = "SELECT dbo.GETymd_time()";
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt.Rows[0].ItemArray[0].ToString();
                }
            }
        }

        #endregion
    }
}