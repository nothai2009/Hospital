using CrystalDecisions.CrystalReports.Engine;
using System;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmReportWork : Form
    {
        public fmReportWork()
        {
            InitializeComponent();
            //MessageBox.Show(User._U_DEPT);
            var sql = "SELECT DISTINCT U.U_NAME,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 2 AND[USER_ID] = NJ.USER_ID)AS SF2,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 3 AND[USER_ID] = NJ.USER_ID)AS SF3,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 4 AND[USER_ID] = NJ.USER_ID)AS SF4,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 5 AND[USER_ID] = NJ.USER_ID)AS SF5,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 6 AND[USER_ID] = NJ.USER_ID)AS SF6,"
+ " (SELECT COUNT(JOBID) FROM[COS_JOB] WHERE STATUS_FIX_ID = 7 AND[USER_ID] = NJ.USER_ID)AS SF7,"

+ " (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '1' AND JOB_ID IN("
+ "     SELECT[JOBID]"

+ "     FROM[COS_JOB]"

+ "     LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

+ "     WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL1,"
+ "  (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '2' AND JOB_ID IN("
+ "      SELECT[JOBID]"

+ "      FROM[COS_JOB]"

+ "      LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

+ "      WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL2,"
+ "   (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '3' AND JOB_ID IN("
 + "      SELECT[JOBID]"

     + "  FROM[COS_JOB]"

      + " LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

     + "  WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL3,"
   + " (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '4' AND JOB_ID IN("
    + "    SELECT[JOBID]"

     + "   FROM[COS_JOB]"

     + "   LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

    + "    WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL4,"
   + "  (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '5' AND JOB_ID IN("
   + "      SELECT[JOBID]"

    + "     FROM[COS_JOB]"

     + "    LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

     + "    WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL5,"
   + "   (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '6' AND JOB_ID IN("
    + "      SELECT[JOBID]"

     + "     FROM[COS_JOB]"

    + "      LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

     + "     WHERE[USER_ID] = NJ.[USER_ID]  AND PO.HIDE IS NULL))AS SPL6,"
    + "   (SELECT COUNT(JOB_ID)AS COUNTS FROM[COS_PART_ORDER] PO WHERE SPL_ID = '8' AND JOB_ID IN("
    + "       SELECT[JOBID]"

    + "       FROM[COS_JOB]"

     + "      LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK) ON JOBID = PO.JOB_ID"

+ "           WHERE[USER_ID] = NJ.[USER_ID] AND PO.HIDE IS NULL))AS SPL8,"
+ " DEPT_NAME"
+ " FROM[COS_JOB] NJ"
+ " LEFT JOIN COS_USER U WITH (NOLOCK)ON NJ.[USER_ID] = U.U_ID"
+ " LEFT JOIN COS_DEPT_COS DC WITH (NOLOCK) ON DC.ID=U.U_DEPT"
+ " WHERE U.U_TEST = 'N' AND U.[U_DEPT] = '" + User._U_DEPT + "'"
+ " ORDER BY U.U_NAME";
            try
            {
                var path = @"C:\COS\RpWork.rpt";
                var File = new FileInfo(path);
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
                rpt.Load(path);

                rpt.SetDataSource(dt);
                rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}