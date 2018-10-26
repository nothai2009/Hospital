using PDrugCount;
using ReadWriteIniFileExample;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace COS
{
    public partial class fmSettingConfig : Form
    {
        private static string fileconfig = "config.ini";

        private string Database1 = "HOMC";
        private string ServerName1 = "ServerName";
        private string UserName1 = "UserName";
        private string Password1 = "Password";
        private string DatabaseName1 = "Database";

        //ที่เก็บไฟล์ตั้งค่า
        private string pathConfig = Path.GetFullPath(fileconfig);

        public string _servername { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _database { get; set; }

        public fmSettingConfig()
        {
            InitializeComponent();
        }

        private void fmSettingConfig_Load(object sender, EventArgs e)
        {
        }

        public void ReadINI()
        {
            txtServerName1.Text = _servername = new Encoding().Decrypt(IniFileHelper.ReadValue(Database1, ServerName1, pathConfig));
            txtUserName1.Text = _username = new Encoding().Decrypt(IniFileHelper.ReadValue(Database1, UserName1, pathConfig));
            txtPassword1.Text = _password = new Encoding().Decrypt(IniFileHelper.ReadValue(Database1, Password1, pathConfig));
            cbxDatabaseName1.Items.Add(_database = new Encoding().Decrypt(IniFileHelper.ReadValue(Database1, DatabaseName1, pathConfig)));
            cbxDatabaseName1.SelectedIndex = 0;
        }

        private void WriteINI()
        {
            _servername = txtServerName1.Text;
            _username = txtUserName1.Text;
            _password = txtPassword1.Text;
            _database = cbxDatabaseName1.SelectedItem.ToString();
            bool Wserver = IniFileHelper.WriteValue(Database1, ServerName1, new Encoding().Encrypt(_servername), Path.GetFullPath(fileconfig));
            bool Wusername = IniFileHelper.WriteValue(Database1, UserName1, new Encoding().Encrypt(_username), Path.GetFullPath(fileconfig));
            bool Wpass = IniFileHelper.WriteValue(Database1, Password1, new Encoding().Encrypt(_password), Path.GetFullPath(fileconfig));
            bool Wdatabase = IniFileHelper.WriteValue(Database1, DatabaseName1, new Encoding().Encrypt(_database), Path.GetFullPath(fileconfig));
            Setlb();
            MessageBox.Show("บันทึกสำเร็จ");
            this.Close();
        }

        void Setlb()
        {
            fmMain f = new fmMain();
            f.Refresh();

            //set label server :
            //lbServer.Text = "Server : " + f._servername;
            //lbDatabase.Text = "Database : " + f._database;
        }

        private void cbxDatabaseName1_Click(object sender, EventArgs e)
        {
            var cbx = cbxDatabaseName1;
            cbx.Items.Clear();
            var con = "Data Source=" + txtServerName1.Text + ";User ID=" + txtUserName1.Text + ";Password=" + txtPassword1.Text + "";
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT name FROM master.sys.databases ORDER BY name";

                var adapter = new SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                DataTable dtDatabases = dataset.Tables[0];
                for (int i = 0; i < dtDatabases.Rows.Count; i++)
                {
                    cbxDatabaseName1.Items.Add(dtDatabases.Rows[i].ItemArray[0]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //เขียนค่า ini
            WriteINI();
        }

        private void cbxDatabaseName1_DropDown(object sender, EventArgs e)
        {
            var cbx = cbxDatabaseName1;
            cbx.DataSource = null;
            cbx.Items.Clear();
        }
    }
}