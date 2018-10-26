using COS;
using COS.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using TutUpdater;
using UDH;

namespace CSWinFormSingleInstanceApp
{
    public partial class MainForm : Form
    {
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            if (this.WindowState == FormWindowState.Minimized && forms["LoginForm"] == null)
            {
                LoginForm loginEntry = new LoginForm();
                if (loginEntry.ShowDialog() == DialogResult.OK)
                {
                    Login();
                    show();
                    CloseAllChildForm();
                }
            }
            else
            {
                //LoginForm loginEntry = new LoginForm();
                //if (loginEntry.ShowDialog() == DialogResult.OK)
                //{
                //    Login();
                //    show();
                //    CloseAllChildForm();
                //}
            }
        }

        private void show()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            fmDashboard f = new fmDashboard();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.MinimizeBox =false;
            f.Show();
        }

        private void _hide()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        public MainForm()
        {
            InitializeComponent();

            Updater up = new Updater();
            var serverUp = "192.168.0.5";
            var pathUp = "cos_update";
            var fileUp = "UpdateInfo.dat";
            var urlUpdate = "http://" + serverUp + "/" + pathUp + "/" + fileUp + "";
            //var urlUpdate = "http://192.168.0.5/cos_update/UpdateInfo.dat";
            up.CheckForUpdates(urlUpdate);

            if (string.IsNullOrEmpty(User._U_NAME))
            {
                this.notifyIcon1.Text = "โปรแกรมแจ้งซ่อม - ยังไม่ได้ล็อกอิน";
            }
            else
            {
                this.notifyIcon1.Text = "โปรแกรมแจ้งซ่อม - " + User._U_NAME;
            }

            this.notifyIcon1.BalloonTipClicked += new EventHandler(notifyIcon1_BalloonTipClicked);

            try
            {
                string pathUser = @".\user.txt";
                if (File.Exists(pathUser))
                {
                    string text = File.ReadAllText(pathUser);
                    var user = new Encoding().Decrypt(text);
                    var r = user.Split('|');
                    User._U_NAME = r[0];
                    User._U_LOGIN = r[1];
                    User._U_PASSWORD = r[2];
                    User._U_POSITION = r[3];
                    User._U_ID = r[4];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //IP Computer
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == AddressFamily.InterNetwork).ToArray();
            labelIP.Text = addresses[0].ToString();
            this.Load += new EventHandler(MainForm_Load);
        }

        private void CheckEligibility()
        {
            //if (User._U_USERGROUP == "2")
            //{
            //    //ช่าง
            //    MenuAssignmentsWork.Enabled = false;
            //    MenuGetWork.Enabled = true;
            //    MenuProcurementManager.Enabled = false;
            //    MenuUser.Enabled = false;
            //}
            //else if (User._U_USERGROUP == "3")
            //{
            //    //หัวหน้าพัสดุ
            //    MenuAssignmentsWork.Enabled = true;
            //    MenuItemAssignmentsWork.Enabled = false;
            //    //MenuItemAssignmentsStock.Enabled = true;
            //    MenuItemAdminApproveBuyPart.Enabled = false;
            //    //MenuItemAdminApproveUsePart.Enabled = false;
            //    MenuItemScore.Enabled = false;
            //    MenuItemDatamanagement.Enabled = false;
            //    MenuGetWork.Enabled = false;
            //    MenuProcurementManager.Enabled = true;
            //    MenuUser.Enabled = false;
            //    //MenuItemSent.Enabled = false;
            //}
            //else if (User._U_USERGROUP == "4")
            //{
            //    //พัสดุ
            //    MenuAssignmentsWork.Enabled = false;
            //    MenuItemAssignmentsWork.Enabled = false;
            //    //MenuItemAssignmentsStock.Enabled = true;
            //    MenuItemAdminApproveBuyPart.Enabled = false;
            //    //MenuItemAdminApproveUsePart.Enabled = false;
            //    MenuItemScore.Enabled = false;
            //    MenuItemDatamanagement.Enabled = false;
            //    MenuGetWork.Enabled = false;
            //    MenuProcurementManager.Enabled = true;
            //    MenuUser.Enabled = false;
            //}
            //else if (User._U_USERGROUP == "5")
            //{
            //    //หัวหน้าเครื่องมือแพทย์
            //    MenuAssignmentsWork.Enabled = true;
            //    MenuItemAssignmentsWork.Enabled = false;
            //    //MenuItemAssignmentsStock.Enabled = true;
            //    MenuItemAdminApproveBuyPart.Enabled = false;
            //    //MenuItemAdminApproveUsePart.Enabled = false;
            //    MenuItemScore.Enabled = false;
            //    MenuItemDatamanagement.Enabled = false;
            //    MenuGetWork.Enabled = false;
            //    MenuProcurementManager.Enabled = true;
            //    MenuUser.Enabled = false;
            //}
            //else if (User._U_USERGROUP == "6")
            //{
            //    //เครื่องมือแพทย์
            //    MenuAssignmentsWork.Enabled = false;
            //    MenuItemAssignmentsWork.Enabled = false;
            //    //MenuItemAssignmentsStock.Enabled = true;
            //    MenuItemAdminApproveBuyPart.Enabled = false;
            //    //MenuItemAdminApproveUsePart.Enabled = false;
            //    MenuItemScore.Enabled = false;
            //    MenuItemDatamanagement.Enabled = false;
            //    MenuGetWork.Enabled = false;
            //    MenuProcurementManager.Enabled = true;
            //    MenuUser.Enabled = false;
            //}
            //else
            //{
            //    MenuItemAssignmentsWork.Enabled = true;
            //    //MenuItemAssignmentsStock.Enabled = true;
            //    MenuItemAdminApproveBuyPart.Enabled = true;
            //    //MenuItemAdminApproveUsePart.Enabled = true;
            //    MenuItemScore.Enabled = true;
            //    MenuItemDatamanagement.Enabled = true;
            //    MenuAssignmentsWork.Enabled = true;
            //    MenuGetWork.Enabled = true;
            //    MenuProcurementManager.Enabled = true;
            //    MenuUser.Enabled = false;
            //}
            //if (User._U_USERGROUP == "8" || User._U_USERGROUP == "9")
            //{
            //    MenuAdmin.Visible = true;
            //    MenuUser.Enabled = false;
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _hide();

            LoginForm loginEntry = new LoginForm();
            if (loginEntry.ShowDialog() == DialogResult.OK)
            {
                Login();
                show();
            }
            if (GlobleData.IsUserLoggedIn == false)
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    _hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide();
            if (MessageBox.Show("คุณต้องการออกโปรแกรม ใช่หรือไม่?", "ออกโปรแกรม", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuLogout_Click(object sender, EventArgs e)
        {
            GlobleData.IsUserLoggedIn = false;
            LoginForm loginEntry = new LoginForm();
            if (loginEntry.ShowDialog() == DialogResult.OK)
            {
                Login();
                show();
                CloseAllChildForm();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
            else if (e.Button == MouseButtons.Left)
            {
                FormCollection forms = Application.OpenForms;
                if (this.WindowState == FormWindowState.Minimized && forms["LoginForm"] == null)
                {
                    LoginForm loginEntry = new LoginForm();
                    if (loginEntry.ShowDialog() == DialogResult.OK)
                    {
                        Login();
                        show();
                        CloseAllChildForm();
                    }
                }
            }
        }

        private void Login()
        {
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Text = "โปรแกรมแจ้งซ่อม - " + User._U_NAME;
            this.lableName.Text = User._U_NAME;
            this.labelPositions.Text = User._U_POSITION;
            this.labelVersion.Text = ProductVersion;
            CheckEligibility();
        }

        private DataTable WorkNew()
        {
            //มอบหมายงาน
            var sqlNewJob = "SELECT COUNT(*) AS COUNT FROM COS_JOB WHERE(OPEN_DATE IS NULL)";
            DataTable dt = new DBClass().SqlGetData(sqlNewJob);
            return dt;
        }

        private DataTable Work1()
        {
            //มอบหมายงาน
            var sqlNewJob = "SELECT  COUNT( NJ.STATUS_FIX_ID) AS COUNT FROM COS_JOB NJ WHERE(NJ.STATUS_FIX_ID = 1)";
            DataTable dt = new DBClass().SqlGetData(sqlNewJob);
            return dt;
        }

        private DataTable Work2()
        {
            //มอบหมายงาน
            var sqlNewJob = "SELECT COUNT(*) AS COUNT FROM COS_JOB  WHERE (STATUS_FIX_ID ='2') AND USER_ID=" + User._U_ID;
            DataTable dt = new DBClass().SqlGetData(sqlNewJob);
            return dt;
        }

        private DataTable Work3()
        {
            //มอบหมายงาน
            var sqlNewJob = "SELECT COUNT(*) AS COUNT FROM COS_JOB  WHERE (STATUS_FIX_ID ='3') AND USER_ID=" + User._U_ID;
            DataTable dt = new DBClass().SqlGetData(sqlNewJob);
            return dt;
        }

        private DataTable Work4()
        {
            //มอบหมายงาน
            var sqlNewJob = "SELECT  COUNT(DISTINCT NJ.STATUS_FIX_ID) AS COUNT FROM COS_JOB NJ LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID LEFT JOIN COS_USER U ON U.U_ID = NJ.[USER_ID] WHERE(NJ.STATUS_FIX_ID = 4) AND U.U_USERGROUP = 1  AND PO.SPL_ID=1";
            DataTable dt = new DBClass().SqlGetData(sqlNewJob);
            return dt;
        }

        private List<string> lw1 = new List<string>();
        private string lw1_1;

        // แจ้งเตือนงาน
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (User._U_USERGROUP == "1" || User._U_USERGROUP == "8")
            //{
            //    var worknew = WorkNew();
            //    if (worknew.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("แจ้งซ่อมใหม่ " + worknew.Rows[0][0].ToString() + " งาน");
            //    }

            //    var work1 = Work1();
            //    if (work1.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("รอหัวหน้าช่างมอบหมายงาน " + work1.Rows[0][0].ToString() + " งาน");
            //    }

            //    var work2 = Work2();
            //    if (work2.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("รอช่างรับงาน " + work2.Rows[0][0].ToString() + " งาน");
            //    }

            //    var work3 = Work3();
            //    if (work3.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("กำลังดำเนินการซ่อม " + work3.Rows[0][0].ToString() + " งาน");
            //    }

            //    var work4 = Work4();
            //    if (work4.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("รออนุมัติสั่งซื้ออะไหล่ " + work4.Rows[0][0].ToString() + " งาน");
            //    }
            //    Notification();
            //}
            //else if (User._U_USERGROUP == "2")
            //{
            //    var work2 = Work2();
            //    if (work2.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("รอช่างรับงาน " + work2.Rows[0][0].ToString() + " งาน");
            //    }

            //    var work3 = Work3();
            //    if (work3.Rows[0][0].ToString() != "0")
            //    {
            //        lw1.Add("กำลังดำเนินการซ่อม " + work3.Rows[0][0].ToString() + " งาน");
            //    }
            //    Notification();
            //}
            //else
            //{
            //}
        }

        private void Notification()
        {
            for (int i = 0; i < lw1.Count; i++)
            {
                lw1_1 += lw1[i].ToString() + "\n";
            }
            if (!(string.IsNullOrEmpty(lw1_1)))
            {
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "แจ้งเตือนงานซ่อม";
                notifyIcon1.BalloonTipText = lw1_1;
                notifyIcon1.ShowBalloonTip(1000);
                lw1.Clear();
                lw1_1 = "";
            }
        }

        public void CloseAllChildForm()
        {
            foreach (Form showf in this.MdiChildren)
            {
                showf.Close();
            }
        }

        private void MenuExitProgram_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกโปรแกรม ใช่หรือไม่?", "ออกโปรแกรม", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void มอบหมายงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "มอบหมายงาน")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmAssignmentsWork w2 = new fmAssignmentsWork();
                w2.MdiParent = this;
                w2.Dock = DockStyle.Fill;
                w2.Show();
            }
        }

        private void อนมสToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "หัวหน้าช่างอนุมัติซ่อม")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmAdminApproveBuyPart f = new fmAdminApproveBuyPart();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void อนมตใชอะไหลในสตอกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "อนุมัติใช้อะไหล่ในสต๊อก")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmAdminApproveUsePart f = new fmAdminApproveUsePart();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void ใหคะแนนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ให้คะแนนการทำงาน")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmScore sc = new fmScore();
                sc.MdiParent = this;
                sc.Dock = DockStyle.Fill;
                sc.Show();
            }
        }

        private void MenuGetWork_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "รับงาน")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmGetWork w1 = new fmGetWork();
                w1.MdiParent = this;
                w1.Dock = DockStyle.Fill;
                w1.Show();
            }
        }

        private void MenuProcurementManager_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ฝ่ายพัสดุ")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmGroupSupplies f = new fmGroupSupplies();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void ขอมลบนเวบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "จัดการข้อมูลบนเว็บ")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmOnWeb f = new fmOnWeb();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void ขอมลในโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "จัดการข้อมูลบนโปรแกรม")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmOnProgram f = new fmOnProgram();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "พัสดุมอบหมายงาน")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmAssignmentsStock f = new fmAssignmentsStock();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                fmAdmin f = new fmAdmin();
                f.Show();
            }
        }

        private void รายงานคางซอมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmDateTimePicker f = new fmDateTimePicker();
            f.Show();
        }

        private void อตราการสงมอบตามนดToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void MenuReport_Click(object sender, EventArgs e)
        {
        }

        private void ผใชงานToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ผู้ใช้งานโปรแกรม")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmC f = new fmC();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void สรปภาระงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmReportWork f = new fmReportWork();
            f.Show();
        }

        private void อนมตสงซอมเอกชนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "อนุมัติส่งซ่อมเอกชน")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmWARRANTY f = new fmWARRANTY();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void MenuAdmin_Click(object sender, EventArgs e)
        {
            RpFixAll f = new RpFixAll();
            f.Show();
        }

        private void MunuPrintDoc_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ใบแจ้งซ่อม")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                RpFixAll f = new RpFixAll();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void MenuAssignmentsWork_Click(object sender, EventArgs e)
        {
        }

        private void MenuItemBoss_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "หัวหน้าหน่วยงานอนุมัติซ่อม")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmAssignmentsBoss f = new fmAssignmentsBoss();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void MenuItemReceive_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "รับพัสดุที่สั่งซื้อ")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CloseAllChildForm();
                fmReceive f = new fmReceive();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }
    }
}