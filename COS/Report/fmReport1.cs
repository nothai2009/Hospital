using CrystalDecisions.CrystalReports.Engine;
using System;
using System.IO;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmReport1 : Form
    {
        private static string sql, carucode, caruno;
        private DBClass dc = new DBClass();

        public fmReport1(string _SQL, string _CARUCODE, string _CARUNO)
        {
            InitializeComponent();

            sql = _SQL;
            carucode = _CARUCODE;
            caruno = _CARUNO;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var pathReport = dc.pathReport + "RpRepairDoc.rpt";
                var File = new FileInfo(pathReport);
                var text = "ติดต่อโปรแกรมเมอร์ 1126";

                if (!File.Exists)
                {
                    MessageBox.Show("ไม่มีไฟล์ใบสั่งซ่อม " + text, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (File.Length == 0)
                {
                    MessageBox.Show("ไฟล์ใบส่งซ่อมไม่สมบูรณ์ " + text, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = new DBClass().SqlGetData(sql);
                ReportDocument rpt = new ReportDocument();
                rpt.Load(pathReport);
                rpt.SetDataSource(dt);

                //ประวัติการซ่อม
                var sqlHisFix = "SELECT HisFix,[DESC_],dbo.dmy([FIXED_DATE])AS [FIXED_DATE],[MOTIVE],[FIXED_DETAIL],U.U_NAME,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                    + " FROM COS_JOB NJ"
                    + " INNER JOIN"
                    + " ("
                        + " SELECT COUNT(CARUCODE)AS HisFix, [CARUCODE], [CARUNO]"
                        + " FROM[COS_JOB]"
                        + " WHERE CARUCODE <> '' AND([USER_ID] <> '1' OR[USER_ID] <> '9')"
                        + "  AND SEND_DATE IS NOT NULL"
                        + " GROUP BY CARUCODE, CARUNO, [CARUNO]"
                       + "  HAVING COUNT([CARUCODE]) > 0 AND COUNT([CARUNO]) > 0"
                    + " )AS F ON NJ.[CARUCODE]= F.[CARUCODE] AND NJ.CARUNO= F.[CARUNO]"
                    + " INNER JOIN COS_USER U WITH (NOLOCK) ON U.U_ID=NJ.[USER_ID]"
                    + " WHERE (NJ.[USER_ID] <> '1' AND NJ.[USER_ID] <> '9')"
                    + " AND NJ.CARUCODE='" + carucode + "' AND NJ.CARUNO= '" + caruno + "'"
                    + " GROUP BY HisFix, [DESC_], [FIXED_DATE], [MOTIVE], [FIXED_DETAIL], U.U_NAME";

                //รายละเอียดครุภัณฑ์
                var sqlCaru = "SELECT dbo.dmySlash(DATEIN)AS DATEIN,PRICE,CT.BGNAME,CM.METHODNAME,BGYEAR,SPEC,COMPANY"
                + " FROM CARU2CARU C"
                + " LEFT JOIN CARU2BGTYPE CT ON CT.BGCODE = C.BGCODE"
                + " LEFT JOIN CARU2METHOD CM ON CM.METHODCODE = C.METHODCODE"
                + " WHERE CARUCODE = '" + carucode + "' AND CARUNO = '" + caruno + "'";
                var dtHisFix = new DBClass().SqlGetData(sqlHisFix);
                var dtCaru = new DBClass().SqlGetData(sqlCaru);
                rpt.Subreports["HisFix"].Database.Tables[0].SetDataSource(dtHisFix);
                rpt.Subreports["Caru"].Database.Tables[0].SetDataSource(dtCaru);
                rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");
                crystalReportViewer1.ReportSource = rpt;

                //crystalReportViewer1.PrintReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}