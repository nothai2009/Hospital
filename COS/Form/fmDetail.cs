using System;
using System.Windows.Forms;

namespace UDH
{
    public partial class fm : Form
    {
        public fm(string ID)
        {
            InitializeComponent();
            this.Text = ID;
            var sql = "SELECT DISTINCT NJ.OWNER, NJ.TEL, dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE,"
+ " dbo.dmy_hm(NJ.ASSIGN_DATE) AS ASSIGN_DATE, dbo.dmy(NJ.EXPECT_DATE) AS EXPECT_DATE,"
+ " dbo.dmy_hm(NJ.ACCEPT_DATE) AS ACCEPT_DATE, NJ.MOTIVE,  NJ.FIXED_DETAIL,"
+ " NJ.RECEIVE_BY, JWT.JW_NAME, NJ.REMARK, NJ.CARUCODE, NJ.CARUNO,"
+ " NJ.SPEC, D.DEPT AS[GROUP], RTRIM(D.deptname)AS DEPTNAME, CARUT.CT_NAME,"
+ " CT.CAUSE_NAME, U.U_NAME, SF.SF_NAME, FT.FT_NAME"
+ " FROM COS_JOB NJ"
+ " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
+ " LEFT JOIN COS_NEW_DEPT D ON NJ.DEPT_ID = D.DEPT"
+ " LEFT JOIN CARU2_COS_NEW_CARU_TYPE CARUT ON NJ.CARUCODE = CARUT.CT_ID"
+ " LEFT JOIN COS_JOB_WENT_TYPE JWT ON NJ.JOB_WANT_ID = JWT.JW_ID"
+ " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
+ " LEFT JOIN COS_STATUS_FIXED SF ON NJ.STATUS_FIX_ID = SF.SF_ID"
+ " LEFT JOIN COS_FIXED_TYPE FT ON NJ.FIX_TYPE_ID = FT.FT_ID"
+ " where NJ.JOBID='" + ID + "'";
            var t = new DBClass().SqlGetData(sql);
            label_ACCEPT_DATE.Text = t.Rows[0]["ACCEPT_DATE"].ToString();
            label_OWNER.Text = t.Rows[0]["OWNER"].ToString();
            label_TEL.Text = t.Rows[0]["TEL"].ToString();
            label_REQ_DATE.Text = t.Rows[0]["REQ_DATE"].ToString();
            label_ASSIGN_DATE.Text = t.Rows[0]["ASSIGN_DATE"].ToString();
            label_EXPECT_DATE.Text = t.Rows[0]["EXPECT_DATE"].ToString();
            label_ACCEPT_DATE.Text = t.Rows[0]["ACCEPT_DATE"].ToString();
            label_MOTIVE.Text = t.Rows[0]["MOTIVE"].ToString();
            label_FIXED_DETAIL.Text = t.Rows[0]["FIXED_DETAIL"].ToString();
            label_CARUCODE.Text = t.Rows[0]["CARUCODE"].ToString();
            label_CARUNO.Text = t.Rows[0]["CARUNO"].ToString();
            label_SPEC.Text = t.Rows[0]["SPEC"].ToString();
            label_group_.Text = t.Rows[0]["GROUP"].ToString();
            label_deptname.Text = t.Rows[0]["DEPTNAME"].ToString();
            label_CT_NAME.Text = t.Rows[0]["CT_NAME"].ToString();
            label_CAUSE_NAME.Text = t.Rows[0]["CAUSE_NAME"].ToString();
            label_U_NAME.Text = t.Rows[0]["U_NAME"].ToString();
            label_SF_NAME.Text = t.Rows[0]["SF_NAME"].ToString();
            label_FT_NAME.Text = t.Rows[0]["FT_NAME"].ToString();
            Console.WriteLine();
        }

        private void fmDetail_Load(object sender, EventArgs e)
        {
        }
    }
}