using COS;
using System;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace CSWinFormSingleInstanceApp
{
    public partial class LoginForm : Form
    {
        private Boolean isWrongPassword = false;

        public LoginForm()
        {
            InitializeComponent();

            Load += new EventHandler(LoginForm_Load);
            FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
            FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
            labelStatus.Text = "";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AcceptButton = buttonLogin;
            CancelButton = buttonCancel;
            txtUsername.Text = User._U_LOGIN;
            if (txtUsername.Text.Length > 0)
            {
                txtPassword.Select();
            }
            else
            {
                txtUsername.Focus();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isWrongPassword == true)
            {
                e.Cancel = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User._U_ID = "";
            User._U_NAME = "";
            User._U_LOGIN = "";
            User._U_PASSWORD = "";
            User._U_DEPT = "";
            User._U_POSITION = "";

            var uname = txtUsername.Text;
            var pw = txtPassword.Text;
            if (uname == "" && pw == "")
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และรหัสผ่าน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                isWrongPassword = true;
                return;
            }

            if (uname == "")
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                isWrongPassword = true;
                return;
            }

            if (pw == "")
            {
                MessageBox.Show("กรุณากรอกรหัสผ่าน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                isWrongPassword = true;
                return;
            }
            try
            {
                string sql = "";
                sql = "select * from COS_USER u LEFT JOIN COS_POSITION so ON u.U_POSITION=so.ID where u.U_LOGIN='" + uname + "' and u.U_PASSWORD='" + pw + "'";
                var dt = new DBClass().SqlGetData(sql);

                if (txtPassword.Text == dt.Rows[0]["U_PASSWORD"].ToString())
                {
                    User._U_ID = dt.Rows[0]["U_ID"].ToString();
                    User._U_NAME = dt.Rows[0]["U_NAME"].ToString();
                    User._U_LOGIN = dt.Rows[0]["U_LOGIN"].ToString();
                    User._U_PASSWORD = dt.Rows[0]["U_PASSWORD"].ToString();
                    User._U_POSITION = dt.Rows[0]["POSITION"].ToString();
                    User._U_DEPT = dt.Rows[0]["U_DEPT"].ToString();

                    string pathUser = @".\user.txt";
                    string createText = User._U_NAME + "|" + User._U_LOGIN + "|" + User._U_PASSWORD + "|" + User._U_POSITION + "|" + User._U_ID;
                    var ss = new Encoding().Encrypt(createText);
                    File.WriteAllText(pathUser, ss);

                    GlobleData.IsUserLoggedIn = true;
                    DialogResult = DialogResult.OK;
                    isWrongPassword = false;
                }
                else
                {
                    isWrongPassword = true;
                    labelStatus.Text = "รหัสผิดพลาด";
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch
            {
                isWrongPassword = true;
                labelStatus.Text = "รหัสผิดพลาด";
                DialogResult = DialogResult.Cancel;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowIcon = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }
    }
}