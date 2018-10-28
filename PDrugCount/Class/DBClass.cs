using COS;
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
        private fmSettingConfig f = new fmSettingConfig();
        private string strCon = "";

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

       

        #endregion

        //SQL Server Class
        #region
        public static SqlTransaction tr;
        private int i;

        private void strConn()
        {
            f.ReadINI();
            strCon = "Data Source=" + f._servername + ";User ID=" + f._username + ";Password=" + f._password + ";Initial Catalog=" + f._database + "";
        }

        //New
        public DataTable SqlGetData(string sql)
        {
            strConn();
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
            strConn();

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
            strConn();

            using (SqlConnection conn = new SqlConnection(strCon))
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
                conn.Close();
                return i;
            }
        }

        public int SqlExecute(string sql)
        {
            strConn();

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
            strConn();

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
            strConn();

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
            strConn();

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
            strConn();

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