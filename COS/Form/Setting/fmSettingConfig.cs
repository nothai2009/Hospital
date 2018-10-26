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
        public string _Database1 { get; set; }
        public string _ServerName1 { get; set; }
        public string _UserName1 { get; set; }
        public string _Password1 { get; set; }
        public string _DatabaseName1 { get; set; }
        public string _Database2 { get; set; }
        public string _ServerName2 { get; set; }
        public string _UserName2 { get; set; }
        public string _Password2 { get; set; }
        public string _DatabaseName2 { get; set; }

        public fmSettingConfig()
        {
            InitializeComponent();
        }

        private void fmSettingConfig_Load(object sender, EventArgs e)
        {
            ReadINI();
        }

        public void ReadINI()
        {
            //try
            //{
            var fileconfig = "config.ini";

            var Database1 = "Database";
            var ServerName1 = "ServerName";
            var UserName1 = "UserName";
            var Password1 = "Password";
            var DatabaseName1 = "DatabaseName";
            _ServerName1 = txtServerName1.Text = new Encoding().Decrypt(IniFileHelper.ReadValue(Database1, ServerName1, Path.GetFullPath(fileconfig)));
            _UserName1 = txtUserName1.Text = IniFileHelper.ReadValue(Database1, UserName1, Path.GetFullPath(fileconfig));
            _Password1 = txtPassword1.Text = IniFileHelper.ReadValue(Database1, Password1, Path.GetFullPath(fileconfig));
            _DatabaseName1 = cbxDatabaseName1.Text = IniFileHelper.ReadValue(Database1, DatabaseName1, Path.GetFullPath(fileconfig));

            var Database2 = "DatabaseMongoDB";
            var ServerName2 = "ServerName";
            var UserName2 = "UserName";
            var Password2 = "Password";
            var DatabaseName2 = "DatabaseName";
            _ServerName2 = txtServerName2.Text = IniFileHelper.ReadValue(Database2, ServerName2, Path.GetFullPath(fileconfig));
            _UserName2 = txtUserName2.Text = IniFileHelper.ReadValue(Database2, UserName2, Path.GetFullPath(fileconfig));
            _Password2 = txtPassword2.Text = IniFileHelper.ReadValue(Database2, Password2, Path.GetFullPath(fileconfig));
            _DatabaseName2 = cbxDatabaseName2.Text = IniFileHelper.ReadValue(Database2, DatabaseName2, Path.GetFullPath(fileconfig));
            //}
            //catch (Exception)
            //{
            //}
        }

        private void cbxDatabaseName1_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection("Data Source=192.168.0.5;User ID=homc;Password=homc"))
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
            //var ServerName1 = new Encoding().Encrypt(txtServerName1.Text);
            //var ServerName1 = new Encoding().Encrypt(txtServerName1.Text);
            //var ServerName1 = new Encoding().Encrypt(txtServerName1.Text);
            //var ServerName1 = new Encoding().Encrypt(txtServerName1.Text);

            var fileconfig = "config.ini";

            var Database1 = "Database";
            var ServerName1 = "ServerName";
            var UserName1 = "UserName";
            var Password1 = "Password";
            var DatabaseName1 = "DatabaseName";
            var test = Path.GetFullPath(fileconfig);
            _ServerName1 = IniFileHelper.ReadValue(Database1, ServerName1, test);
            _UserName1 = IniFileHelper.ReadValue(Database1, UserName1, Path.GetFullPath(fileconfig));
            _Password1 = IniFileHelper.ReadValue(Database1, Password1, Path.GetFullPath(fileconfig));
            _DatabaseName1 = IniFileHelper.ReadValue(Database1, DatabaseName1, Path.GetFullPath(fileconfig));

            bool result = IniFileHelper.WriteValue(Database1, ServerName1, new Encoding().Encrypt(txtServerName1.Text), Path.GetFullPath(fileconfig));
        }

        private void cbxDatabaseName2_Click(object sender, EventArgs e)
        {
            //var connectionString = "mongodb://u_cos:P@ssw0rd@172.16.254.213:27017";

            ////take database name from connection string
            //var _databaseName = MongoUrl.Create(connectionString).DatabaseName;
            //var _server = MongoServer.Create(connectionString);

            ////and then get database by database name:
            //_server.GetDatabase(_databaseName);

            //var tt = _server.GetDatabase(_databaseName);

            ////cbxDatabaseName1.Items.Add(dtDatabases.Rows[i].ItemArray[0]);
        }
    }
}