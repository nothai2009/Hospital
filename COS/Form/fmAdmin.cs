using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAdmin : Form
    {
        public fmAdmin()
        {
            InitializeComponent();
            ShowData1();
        }

        private void ShowData1()
        {
            var sql = "SELECT SF.SF_NAME,(select COUNT([CARUCODE]) as CARUCODE from COS_JOB"
                + " where STATUS_FIX_ID = '7' AND CARUCODE = NJ.CARUCODE AND CARUNO = NJ.CARUNO),"
                + " NJ.JOBID, RTRIM(D.deptname)AS DEPTNAME, CAT.CT_NAME, NJ.CARUCODE, NJ.CARUNO,NJ.SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE,"
                + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE, JW.JW_NAME,SF.SF_ID"
                + " FROM COS_JOB NJ LEFT JOIN"
                + " COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID LEFT JOIN"
                + " COS_NEW_CARU_TYPE CAT ON NJ.CARUCODE = CAT.CT_ID LEFT JOIN"
                + " COS_NEW_DEPT D ON NJ.DEPT_ID = D.DEPT LEFT JOIN"
                + " COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID LEFT JOIN"
                + " COS_STATUS_FIXED SF ON SF.SF_ID = NJ.STATUS_FIX_ID"
                + " WHERE(NJ.USER_ID = '" + comboBox1.SelectedValue + "') AND(NJ.STATUS_FIX_ID <> 2)";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "สถานะงาน";
            dgv1.Columns[1].HeaderText = "ซ่อมไปแล้ว";
            dgv1.Columns[2].HeaderText = "JOB_ID";
            dgv1.Columns[3].HeaderText = "หน่วยงาน";
            dgv1.Columns[4].HeaderText = "ประเภทครุภัณฑ์";
            dgv1.Columns[5].HeaderText = "ครุภัณฑ์	";
            dgv1.Columns[6].HeaderText = "ตัวย่อ";
            dgv1.Columns[7].HeaderText = "สเปก";
            dgv1.Columns[8].HeaderText = "อาการ";
            dgv1.Columns[9].HeaderText = "สาเหตุ";
            dgv1.Columns[10].HeaderText = "ผู้แจ้ง";
            dgv1.Columns[11].HeaderText = "เบอร์โทร";
            dgv1.Columns[12].HeaderText = "วันที่แจ้งซ่อม";
            dgv1.Columns[13].HeaderText = "กำหนดเสร็จ";
            dgv1.Columns[14].HeaderText = "ต้องการ";

            dgv1.Columns[0].Width = 130;
            dgv1.Columns[1].Width = 40;
            dgv1.Columns[2].Width = 115;
            dgv1.Columns[3].Width = 70;
            dgv1.Columns[4].Width = 160;
            dgv1.Columns[5].Width = 93;
            dgv1.Columns[6].Width = 50;
            dgv1.Columns[7].Width = 150;
            dgv1.Columns[8].Width = 95;
            dgv1.Columns[9].Width = 90;
            dgv1.Columns[10].Width = 75;
            dgv1.Columns[11].Width = 75;
            dgv1.Columns[12].Width = 105;
            dgv1.Columns[13].Width = 115;
        }

        private void dgv1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
            e.Column.HeaderCell.Style.Font = new Font("Thai Sans Lite", 12);                    //ตัวอักษร ขนาดตัวอักษร
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string sql = "select U_ID,U_NAME from COS_USER WHERE [U_DEPT]='1'";
                DataTable dt = new DBClass().SqlGetData(sql);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "U_ID";
                comboBox1.DisplayMember = "U_NAME";
                comboBox1.SelectedIndex = -1;
                ShowData1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DBClass.tr.Rollback();
            }
        }
    }
}