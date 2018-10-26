using System.Drawing;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmHis : Form
    {
        public fmHis(string carucode, string caruno)
        {
            InitializeComponent();
            this.Text = carucode + "" + caruno;
            var sql = "SELECT [JOBID],NJ.CARUCODE,NJ.CARUNO,D.DEPNAME AS DEPTNAME,[SPEC],CT.CAUSE_NAME,[DESC_]AS [DESC],[OWNER],[TEL],dbo.dmy_hm(NJ.FIXED_DATE)AS FIXED_DATE,U.U_NAME"
                + " FROM [COS_JOB] NJ"
                + " LEFT JOIN [COS_USER] U ON NJ.USER_ID = U.U_ID"
                + " LEFT JOIN MUHDEP D ON D.DEPCODE=NJ.DEPT_ID"
                + " LEFT JOIN [COS_CAUSE_TYPE] CT ON CT.CAUSE_ID=NJ.CAUSE_ID"
                + " LEFT JOIN CARU2CARU C2 ON C2.CARUCODE = NJ.CARUCODE AND C2.CARUNO=NJ.CARUNO"
                + " WHERE NJ.CARUCODE='" + carucode + "' AND NJ.CARUNO = '" + caruno + "'  AND NJ.SEND_DATE is not null";
            label_ACCEPT_DATE.Text = "";
            label_ASSIGN_DATE.Text = "";
            label_CARUCODE.Text = "";
            label_CARUNO.Text = "";
            label_CAUSE_NAME.Text = "";
            label_CT_NAME.Text = "";
            label_deptname.Text = "";
            label_EXPECT_DATE.Text = "";
            label_FIXED_DETAIL.Text = "";
            label_FT_NAME.Text = "";
            label_MOTIVE.Text = "";
            label_OWNER.Text = "";
            label_REQ_DATE.Text = "";
            label_SF_NAME.Text = "";
            label_SPEC.Text = "";
            label_TEL.Text = "";
            label_U_NAME.Text = "";
            label_FINISH_DATE.Text = "";
            label23.Text = "";
            var dt = new DBClass().SqlGetData(sql);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var sql = "SELECT DISTINCT NJ.OWNER, NJ.TEL, dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy_hm(NJ.ASSIGN_DATE) AS ASSIGN_DATE, "
                    + " dbo.dmy(NJ.EXPECT_DATE) AS EXPECT_DATE, dbo.dmy_hm(NJ.ACCEPT_DATE) AS ACCEPT_DATE, NJ.FINISH_DATE, NJ.MOTIVE,  "
                    + " NJ.FIXED_DETAIL, NJ.RECEIVE_BY, JWT.JW_NAME, NJ.REMARK, NJ.CARUCODE, NJ.CARUNO, SPEC,  "
                    + " RTRIM(DEPNAME)AS DEPTNAME, C2G.GROUPNAME, CT.CAUSE_NAME, U.U_NAME, SF.SF_NAME, FT.FT_NAME,NJ.MOTIVE,NJ.FIXED_DETAIL,SF.SF_NAME,C2C.CARUNAME AS CT_NAME"
                    + " FROM COS_JOB NJ"
                    + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                    + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPGPCODE"
                    + " LEFT JOIN CARU2CODE C2C ON C2C.CARUCODE = NJ.CARUCODE"
                    + " LEFT JOIN CARU2CARU C2 ON C2.CARUCODE = NJ.CARUCODE AND C2.CARUNO = NJ.CARUNO"
                    + " LEFT JOIN CARU2GROUP C2G ON C2G.GROUPCODE = C2C.CARUCODE"
                    + " LEFT JOIN COS_JOB_WENT_TYPE JWT ON NJ.JOB_WANT_ID = JWT.JW_ID"
                    + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
                    + " LEFT JOIN COS_STATUS_FIXED SF ON NJ.STATUS_FIX_ID = SF.SF_ID"
                    + " LEFT JOIN COS_FIXED_TYPE FT ON NJ.FIX_TYPE_ID = FT.FT_ID"
                    + " where NJ.JOBID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
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
            label_deptname.Text = t.Rows[0]["DEPTNAME"].ToString();
            label_CT_NAME.Text = t.Rows[0]["CT_NAME"].ToString();
            label_CAUSE_NAME.Text = t.Rows[0]["CAUSE_NAME"].ToString();
            label_U_NAME.Text = t.Rows[0]["U_NAME"].ToString();
            label_SF_NAME.Text = t.Rows[0]["SF_NAME"].ToString();
            label_FT_NAME.Text = t.Rows[0]["FT_NAME"].ToString();
            label_FINISH_DATE.Text = t.Rows[0]["FINISH_DATE"].ToString();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
            e.Column.HeaderCell.Style.Font = new Font("Thai Sans Lite", 12);                    //ตัวอักษร ขนาดตัวอักษร
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}