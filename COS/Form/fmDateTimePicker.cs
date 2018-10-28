using System;
using System.Windows.Forms;

namespace COS
{
    public partial class fmDateTimePicker : Form
    {
        public fmDateTimePicker()
        {
            InitializeComponent();
        }

        private void fmDateTimePicker_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            dateTimePicker1.Value = new DateTime(dt.Year, dt.Month, 1);
            dateTimePicker2.Value = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sql = "SELECT JOBID, SF.SF_NAME ,D.deptname, CARUCODE, CARUNO,  CT.CAUSE_NAME, DESC_, OWNER, TEL,dbo.dmy_hm(REQ_DATE)AS REQ_DATE,  dbo.dmy(EXPECT_DATE)AS EXPECT_DATE, U.U_NAME"
                    + " FROM COS_JOB NJ"
                    + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                    + " LEFT JOIN COS_STATUS_FIXED SF ON SF.SF_ID = NJ.STATUS_FIX_ID"
                    + " LEFT JOIN COS_USER U ON U.U_ID = NJ.USER_ID"
                    + " LEFT JOIN COS_NEW_DEPT D ON D.DEPT = NJ.DEPT_ID"
                    + " WHERE(SEND_DATE IS NULL) AND(OWNER <> 'ทดสอบระบบ')AND(CANCEL is null) AND SUBSTRING(REQ_DATE,1, 8) BETWEEN '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' AND '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "'"
                    + " ORDER BY NJ.STATUS_FIX_ID";
            fmReportFix f = new fmReportFix(sql);
            f.Show();
        }
    }
}