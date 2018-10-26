using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public class printReport
    {
        private string PrinterDefault = "";

        public void Preview()
        {
        }

        public void noPreview(string JOB_ID, string Carucode, string Caruno, string Pritername)
        {
            //Main Report

            #region รายละเอียดการแจ้งซ่อม

            var sqlReport = "SELECT DISTINCT NJ.JOBID,"
                + " (select U_NAME from COS_USER WHERE U_ID = PO.U_ID)AS NAME, RTRIM(MUHDEP.DEPNAME)AS DEPTNAME, "
                + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, c2c.NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
                + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + '' + ISNULL(PL_BRAND, '') + '' + ISNULL(PL_GEN, '') + '' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
                + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
                + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE_SOTCK, 1, 8))AS PO_ASSIGN_DATE_SOTCK,NJ.MOTIVE,NJ.FIXED_DETAIL,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE"
                + " LEFT JOIN [CARU2CODE]c2c ON NJ.CARUCODE = c2c.CARUCODE"
                + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
                + " LEFT JOIN COS_FIXED_TYPE ON NJ.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
                + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
                + " LEFT JOIN COS_PART_ORDER PO ON PO.JOB_ID = NJ.JOBID"
                + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID = NJ.FIX_TYPE_ID"
                + " LEFT JOIN COS_PART_LIST PL ON PL.PL_ID = PO.PL_ID "
                + " LEFT JOIN COS_PART_LIST_C PLC ON PLC.PL_ID = PO.PL_ID AND PLC.PL_ID_C = PO.PL_ID_C"
                + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT"
                + " CROSS JOIN COS_COS C"
                + " where NJ.JOBID = '" + JOB_ID + "'";

            //Get Name Printer Default
            PrinterSettings settings = new PrinterSettings();
            PrinterDefault = settings.PrinterName;

            #endregion รายละเอียดการแจ้งซ่อม

            //SubReport

            #region sql ประวัติการซ่อม

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
                + " AND NJ.CARUCODE='" + Carucode + "' AND NJ.CARUNO= '" + Caruno + "'"
                + " GROUP BY HisFix, [DESC_], [FIXED_DATE], [MOTIVE], [FIXED_DETAIL], U.U_NAME";

            #endregion sql ประวัติการซ่อม

            #region sql รายละเอียดครุภัณฑ์

            var sqlCaru = "SELECT dbo.dmySlash(DATEIN)AS DATEIN,PRICE,CT.BGNAME,CM.METHODNAME,BGYEAR,SPEC,COMPANY"
            + " FROM CARU2CARU C"
            + " LEFT JOIN CARU2BGTYPE CT ON CT.BGCODE = C.BGCODE"
            + " LEFT JOIN CARU2METHOD CM ON CM.METHODCODE = C.METHODCODE"
            + " WHERE CARUCODE = '" + Carucode + "' AND CARUNO = '" + Caruno + "'";

            #endregion sql รายละเอียดครุภัณฑ์

            var pathReport = Environment.CurrentDirectory + "\\Report\\RpRepairDoc.rpt";
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

            var dt = new DBClass().SqlGetData(sqlReport);
            ReportDocument rpt = new ReportDocument();
            rpt.Load(pathReport);
            rpt.SetDataSource(dt);

            var dtHisFix = new DBClass().SqlGetData(sqlHisFix);
            rpt.Subreports["HisFix"].Database.Tables[0].SetDataSource(dtHisFix);

            var dtCaru = new DBClass().SqlGetData(sqlCaru);
            rpt.Subreports["Caru"].Database.Tables[0].SetDataSource(dtCaru);

            rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");

            //fnc.SetDefaultPrinter();

            //rpt.PrintToPrinter(1, false, 0, 0);

            //myPrinters.SetDefaultPrinter(PrinterDefault);
        }
    }
}