using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAssignmentsBoss : Form
    {
        private User.FIXED_TYPE uf = new User.FIXED_TYPE();
        private User.STATUS_FIXED sf = new User.STATUS_FIXED();
        private DBClass dc = new DBClass();

        private string FIX_TYPE_ID, JOB_ID, SQL;
        private static string Pritername = "";

        public fmAssignmentsBoss()
        {
            InitializeComponent();
            ShowAssignmentsBoss();
            tabControl1.TabPages.Remove(tp2);
        }

        private void dgvAssignmentsBoss_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAssignmentsBoss.ClearSelection();
        }

        private void ShowAssignmentsBoss()
        {
            var sql = "SELECT DISTINCT NJ.JOBID,FT.FT_NAME,RTRIM(MUHDEP.DEPNAME)AS DEPRNAME,c2c.NAME,NJ.CARUCODE,NJ.CARUNO,SPEC," +
                "CT.CAUSE_NAME,NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE, dbo.dmy_hm(NJ.ASSIGN_DATE)AS ASSIGN_DATE," +
            "dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE, COS_LEVEL_TYPE.LEVEL_NAME,NJ.STATUS_FIX_ID,FT_ID " +
            "FROM COS_JOB NJ " +
            "LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID " +
            "LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE " +
            "LEFT JOIN [CARU2CODE] c2c ON c2c.CARUCODE=NJ.CARUCODE " +
            "LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO " +
            "LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID " +
            "LEFT JOIN COS_FIXED_TYPE FT ON NJ.FIX_TYPE_ID = FT.FT_ID " +
            "LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID " +
            "LEFT JOIN COS_STATUS_FIXED SF ON NJ.STATUS_FIX_ID = SF.SF_ID " +
            "WHERE NO='5' AND NJ.DEPT='" + User._U_DEPT + "'";

            DataTable dt = new DBClass().SqlGetData(sql);
            var dgv = dgvAssignmentsBoss;
            dgv.DataSource = dt;

            dgv.Columns[0].HeaderText = "JOB_ID";
            dgv.Columns[1].HeaderText = "ประเภทซ่อม";
            dgv.Columns[2].HeaderText = "หน่วยงาน";
            dgv.Columns[3].HeaderText = "ประเภทครุภัณฑ์";
            dgv.Columns[4].HeaderText = "เลขครุภัณฑ์";
            dgv.Columns[5].HeaderText = "ตัวย่อ";
            dgv.Columns[6].HeaderText = "สเปก";
            dgv.Columns[7].HeaderText = "อาการเสีย";
            dgv.Columns[8].HeaderText = "คำอธิบาย";
            dgv.Columns[9].HeaderText = "ผู้แจ้ง";
            dgv.Columns[10].HeaderText = "เบอร์โทร";
            dgv.Columns[11].HeaderText = "วันที่แจ้ง";
            dgv.Columns[12].HeaderText = "วันกำหนดเสร็จ";
            dgv.Columns[13].HeaderText = "ผู้รับผิดชอบ";
            dgv.Columns[14].HeaderText = "หมายเหตุประเภทการซ่อม";
            dgv.Columns[15].HeaderText = "หมายเหตุประเภทการซ่อม";
            dgv.Columns[16].HeaderText = "หมายเหตุประเภทการซ่อม";

            dgv.Columns[0].Width = 120;
            dgv.Columns[1].Width = 170;
            dgv.Columns[2].Width = 130;
            dgv.Columns[3].Width = 250;
            dgv.Columns[4].Width = 100;
            dgv.Columns[5].Width = 100;
            dgv.Columns[6].Width = 120;
            dgv.Columns[7].Width = 85;
            dgv.Columns[8].Width = 65;
            dgv.Columns[9].Width = 65;
            dgv.Columns[10].Width = 108;
            dgv.Columns[11].Width = 108;
            dgv.Columns[12].Width = 119;
            dgv.Columns[13].Width = 114;
            dgv.Columns[14].Width = 114;
            dgv.Columns[15].Visible = false;
            dgv.Columns[16].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dgv = dgvAssignmentsBoss;
            JOB_ID = dgv.CurrentRow.Cells[0].Value.ToString();
            FIX_TYPE_ID = dgv.SelectedCells[16].Value.ToString();

            if (dgvAssignmentsBoss.SelectedRows.Count > 0)
            {
                try
                {
                    if (FIX_TYPE_ID == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ)
                    {
                        SQL = "UPDATE COS_JOB SET STATUS_FIX_ID='" + sf._รอพัสดุรับรายการสั่งซื้อ + "',ASSIGN_BOSS='" + User._U_ID + "',BOSS_DATE='" + dc.GetDate() + "' WHERE JOBID='" + JOB_ID + "'";
                        int i2 = new DBClass().SqlExecute(SQL);
                        //MessageBox.Show("อนุมัติซื้อพัสดุเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนในประกัน)
                    {
                        SQL = "UPDATE COS_JOB SET STATUS_FIX_ID='" + sf._ส่งซ่อมเอกชนในประกัน + "',ASSIGN_BOSS='" + User._U_ID + "',BOSS_DATE='" + dc.GetDate() + "' WHERE JOBID='" + JOB_ID + "'";
                        int i2 = new DBClass().SqlExecute(SQL);
                        //MessageBox.Show("อนุมัติส่งซ่อมเอกชนในประกันเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนนอกประกัน)
                    {
                        SQL = "UPDATE COS_JOB SET STATUS_FIX_ID='" + sf._ส่งซ่อมเอกชนนอกประกัน + "',ASSIGN_BOSS='" + User._U_ID + "',BOSS_DATE='" + dc.GetDate() + "' WHERE JOBID='" + JOB_ID + "'";
                        int i2 = new DBClass().SqlExecute(SQL);
                        //MessageBox.Show("อนุมัติส่งซ่อมเอกชนนอกปรกันเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (FIX_TYPE_ID == uf._ขออนุมัติซื้อทดแทน)
                    {
                        SQL = "UPDATE COS_JOB SET STATUS_FIX_ID='" + sf._ขออนุมัติซื้อทดแทน + "',ASSIGN_BOSS='" + User._U_ID + "',BOSS_DATE='" + dc.GetDate() + "' WHERE JOBID='" + JOB_ID + "'";
                        int i2 = new DBClass().SqlExecute(SQL);
                        //MessageBox.Show("อนุมัติส่งซ่อมเอกชนนอกปรกันเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    var CARUCODE = dgv.SelectedCells[4].Value.ToString();
                    var CARUNO = dgv.SelectedCells[5].Value.ToString();

                    ////ปริ้นใบแจ้งซ่อม
                    if (chkShowPreview.Checked == true)
                    {
                        PrintPreview(sqlReport(JOB_ID), CARUCODE, CARUNO);
                    }
                    else
                    {
                        PrintNoPreview();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                    //throw;
                }
                finally
                {
                    string sql = "";
                    if (chk1.Checked == true)
                    {
                        sql = "INSERT INTO COS_PRINT([JOB_ID],[Print_date],[Print_user],[Print_doc_type])" +
                        "VALUES('" + JOB_ID + "','" + dc.GetDate() + "','" + User._U_ID + "','1')";
                        int i2 = new DBClass().SqlExecute(sql);
                    }
                    if (chk2.Checked == true)
                    {
                        sql = "INSERT INTO COS_PRINT([JOB_ID],[Print_date],[Print_user],[Print_doc_type])" +
                        "VALUES('" + JOB_ID + "','" + dc.GetDate() + "','" + User._U_ID + "','2')";
                        int i2 = new DBClass().SqlExecute(sql);
                    }
                    if (chk3.Checked == true)
                    {
                        sql = "INSERT INTO COS_PRINT([JOB_ID],[Print_date],[Print_user],[Print_doc_type])" +
                         "VALUES('" + JOB_ID + "','" + dc.GetDate() + "','" + User._U_ID + "','3')";
                        int i2 = new DBClass().SqlExecute(sql);
                    }
                    ShowAssignmentsBoss();
                    dgv.ClearSelection();
                }
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private string sqlReport(string _job_ID)
        {
            var _report = "SELECT DISTINCT NJ.JOBID,RTRIM(D.DEPNAME)AS DEPTNAME,"
                   + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, c2c.NAME AS CT_NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
                   + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + '' + ISNULL(PL_BRAND, '') + '' + ISNULL(PL_GEN, '') + '' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
                   + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
                   + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, NJ.MOTIVE,NJ.FIXED_DETAIL,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                   + " FROM COS_JOB NJ"
                   + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                   + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                   + " LEFT JOIN [CARU2CODE]c2c ON NJ.CARUCODE = c2c.CARUCODE"
                   + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
                   + " LEFT JOIN COS_FIXED_TYPE ON NJ.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
                   + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
                   + " LEFT JOIN COS_PART_ORDER PO ON PO.JOB_ID = NJ.JOBID"
                   + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID = NJ.FIX_TYPE_ID"
                   + " LEFT JOIN COS_PART_LIST_C PLC ON PLC.PL_ID = PO.PL_ID AND PLC.PL_ID_C = PO.PL_ID_C"
                   + " LEFT JOIN COS_PART_LIST PL ON PL.PL_ID = PO.PL_ID "
                   + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT"
                   + " CROSS JOIN COS_COS C"
                   + " where NJ.JOBID =  '" + _job_ID + "'";
            return _report;
        }

        private void cbxPrinter_DropDown(object sender, EventArgs e)
        {
            dc.cbxPrinterDropDown(cbxPrinter);
        }

        private void cbxPrinter_DropDownClosed(object sender, EventArgs e)
        {
            dc.cbxPrinter_DropDownClosed(cbxPrinter);
        }

        private void cbxPrinter_MouseClick(object sender, MouseEventArgs e)
        {
            dc.cbxPrinter_MouseClick(cbxPrinter);
        }

        private void dgvAssignmentsBoss_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAssignmentsBoss.SelectedRows.Count > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void fmAssignmentsBoss_Load(object sender, EventArgs e)
        {
            dc.LoadPrinter(cbxPrinter);
        }

        private void PrintPreview(string _Report, string _Carucode, string _caruno)
        {
            try
            {
                if (dgvAssignmentsBoss.SelectedRows.Count > 1)
                {
                }

                if (tabControl1.SelectedIndex == 0)
                {
                    var sql = "update COS_JOB set STATUS_FIX_ID=@STATUS_FIX_ID,BOSS_DATE=@BOSS_DATE"
                                    + " where JOB_ID = '" + JOB_ID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอพัสดุรับรายการสั่งซื้อ;
                    param.AddWithValue("@BOSS_DATE", SqlDbType.VarChar).Value = User.GETymd_time();
                    //int i = new DBClass().SqlExecute(sql, param);
                }

                fmReport1 f = new fmReport1(_Report, _Carucode, _caruno);
                f.Dock = DockStyle.Fill;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                //ถ้างานผิดพลาดให้สั่งปริ้นใหม่
                //var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID,U_ID=@U_ID,EXPECT_DATE=@EXPECT_DATE,PO_ASSIGN_DATE_SOTCK=@PO_ASSIGN_DATE_SOTCK"
                //                    + " where JOB_ID = '" + JOB_ID + "'";
                //SqlParameterCollection param = new SqlCommand().Parameters;
                //param.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 2;
                //param.AddWithValue("@U_ID", SqlDbType.Int).Value = null;
                //param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = null;
                //param.AddWithValue("@PO_ASSIGN_DATE_SOTCK", SqlDbType.VarChar).Value = null;
                //int i = new DBClass().SqlExecute(sql, param);
                MessageBox.Show("ผิดพลาด " + ex.Message + "กรุณาปริ้น JOB " + JOB_ID + "ใหม่อีกที!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintNoPreview()
        {
            DataGridView dgv;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = dgvAssignmentsBoss;
            }
            else
            {
                dgv = dgvPrintOld;
            }

            var JOB_ID = dgv.SelectedCells[0].Value.ToString();
            string carucode = dgv.SelectedCells[4].Value.ToString();
            string caruno = dgv.SelectedCells[5].Value.ToString();
            Pritername = cbxPrinter.SelectedItem.ToString();

            if (tabControl1.SelectedIndex == 0)
            {
                var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID"
                                + " where JOB_ID = '" + JOB_ID + "'";

                //var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID,U_ID=@U_ID,EXPECT_DATE=@EXPECT_DATE,PO_ASSIGN_DATE_SOTCK=@PO_ASSIGN_DATE_SOTCK"
                //                + " where JOB_ID = '" + JOB_ID + "'";
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
                //param.AddWithValue("@U_ID", SqlDbType.Int).Value = cbxU_ID.SelectedValue;
                //param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = dtpEXPECT_DATE.Value.ToString("yyyyMMdd");
                //param.AddWithValue("@PO_ASSIGN_DATE_SOTCK", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                int i = new DBClass().SqlExecute(sql, param);
            }

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

            var dt = new DBClass().SqlGetData(sqlReport(JOB_ID));
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
            rpt.PrintToPrinter(1, false, 0, 0);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    Error = true;
            //}
        }
    }
}