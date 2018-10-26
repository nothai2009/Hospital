using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmFastJob : Form
    {
        public fmFastJob()
        {
            InitializeComponent();
        }

        private void fmFastJob_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void ShowData1()
        {
            var sql1 = "SELECT [CARUCODE],[CARUNO] FROM[COS_JOB] WHERE JOBID = '" + User._JOB_Now + "'";
            var dt1 = new DBClass().SqlGetData(sql1);
            var caruCode = dt1.Rows[0][0].ToString();
            var caruNo = dt1.Rows[0][1].ToString();

            //try
            //{
            string sql = "SELECT SF.SF_NAME,(select COUNT([CARUCODE]) as CARUCODE from COS_JOB"
                + " where STATUS_FIX_ID = '7' AND CARUCODE = NJ.CARUCODE AND CARUNO = NJ.CARUNO),"
                + " NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO,(SELECT [SPEC]FROM [CARU2CARU]WHERE CARUCODE='"+caruCode+"' AND CARUNO='"+caruNo+"')AS SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE,"
                + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE, JW.JW_NAME,SF.SF_ID"
            + " FROM COS_JOB NJ LEFT JOIN"
            + " COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID LEFT JOIN " +
            "CARU2CARU c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUCODE=NJ.CARUCODE LEFT JOIN "
            + " [CARU2CODE] c2c ON NJ.CARUCODE = c2c.CARUCODE LEFT JOIN"
            + " MUHDEP D ON NJ.DEPT_ID = D.DEPCODE LEFT JOIN"
            + " COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID LEFT JOIN"
            + " COS_STATUS_FIXED SF ON SF.SF_ID = NJ.STATUS_FIX_ID"
            + " WHERE(NJ.STATUS_FIX_ID = 2) AND NJ.JOBID='" + User._JOB_Now + "'";                       /*มอบหมายงาน*/

            var dt = new DBClass().SqlGetData(sql);
            lbJOBID.Text = dt.Rows[0][2].ToString();
            lbDEPTNAME.Text = dt.Rows[0][3].ToString();
            lbCT_NAME.Text = dt.Rows[0][4].ToString();
            lbCARUCODE.Text = dt.Rows[0][5].ToString();
            lbCARUNO.Text = dt.Rows[0][6].ToString();
            lbSPEC.Text = dt.Rows[0][7].ToString();
            lbCAUSE_NAME.Text = dt.Rows[0][8].ToString();
            lbDESC_.Text = dt.Rows[0][9].ToString();
            lbOWNER.Text = dt.Rows[0][10].ToString();
            lbTEL.Text = dt.Rows[0][11].ToString();
            lbEXPECT_DATE.Text = dt.Rows[0][12].ToString();
            lbREQ_DATE.Text = dt.Rows[0][13].ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("คุณต้องการบันทึกข้อมูลปิดงานด่วน ใช่หรือไม่?", "ปิดงานด่วน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,RECEIVE_BY=@RECEIVE_BY,FIX_TYPE_ID=@FIX_TYPE_ID,ACCEPT_DATE=@ACCEPT_DATE,FIXED_DATE=@FIXED_DATE,FINISH_DATE=@FINISH_DATE,SEND_DATE=@SEND_DATE where JOBID='" + User._JOB_Now + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 7;
                    param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                    param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                    param.AddWithValue("@RECEIVE_BY", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                    param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = 1;
                    param.AddWithValue("@ACCEPT_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@FINISH_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@SEND_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    int i2 = new DBClass().SqlExecute(sql_update, param);
                    MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}