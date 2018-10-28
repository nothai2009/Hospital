using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmReport2 : Form
    {
        private static string job_id;

        private DBClass dc = new DBClass();

        public fmReport2(string JOB_ID)
        {
            job_id = JOB_ID;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var sql = "SELECT DISTINCT PLC.[PL_BRAND]+' '+PLC.[PL_GEN]+' '+PLC.[PL_DESC_C]AS PO_NAME,"
                    + " 'ตามใบส่งซ่อมเลขที่ ' + NJ.JOBID + ' หน่วยงาน = ' + RTRIM(D.DEPNAME) AS[NAME],"
                    + " PO.PO_QTY_REQUIRED, [PL_PRICE],"
                    + " PO.PO_QTY_REQUIRED*[PL_PRICE] AS TOTAL, NJ.REMARK,NJ.MOTIVE,NJ.FIXED_DETAIL"
                    + " ,(SELECT[U_NAME] FROM [UHDATA].[dbo].[COS_USER] U INNER JOIN COS_POSITION P WITH(NOLOCK) ON U.U_POSITION=P.ID WHERE U_DEPT= NJ.DEPT AND BOSS = 'Y')AS NAME_BOSS"
                    + " , dbo.GETday()AS DATEBOSS,[DEPT_NAME],[DEPT_TEL],[Boss_Stock],[DeputyDirector],[Director]"
                    + " FROM COS_JOB NJ"
                    + " INNER JOIN COS_PART_ORDER PO WITH(NOLOCK) ON NJ.JOBID=PO.JOB_ID"
                    + " INNER JOIN COS_PART_LIST PL WITH(NOLOCK) ON PO.PL_ID = PL.PL_ID"
                    + " INNER JOIN COS_PART_LIST_C PLC WITH(NOLOCK) ON PL.PL_ID = PLC.PL_ID AND PO.PL_ID_C = PLC.PL_ID_C"
                    + " INNER JOIN COS_USER WITH(NOLOCK) ON NJ.LEVEL_ID = COS_USER.U_ID"
                    + " INNER JOIN MUHDEP D WITH(NOLOCK) ON NJ.DEPT_ID = D.DEPCODE"
                    + " INNER JOIN COS_DEPT_COS DS WITH(NOLOCK) ON DS.DEPT_ID= NJ.DEPT"
                    + " CROSS JOIN [COS_COS]"
                    + " WHERE NJ.JOBID IN('UDH_610000848','UDH_610000849')";

            //try
            //{
                if (!(string.IsNullOrEmpty(fmAdminApproveBuyPart.Report2)))
                {
                    var dt = new DBClass().SqlGetData(sql);
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load(dc.pathReport + @"\CrystalReport2.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    var dt = new DBClass().SqlGetData(sql);
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load(dc.pathReport + @"\CrystalReport2.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");
                    crystalReportViewer1.ReportSource = rpt;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("กรุณาติดตั้งแบบรายงาน " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}