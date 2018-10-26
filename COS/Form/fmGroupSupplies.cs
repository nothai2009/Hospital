using COS;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmGroupSupplies : Form
    {
        private User.FIXED_TYPE ft = new User.FIXED_TYPE();
        private User.STATUS_FIXED sf = new User.STATUS_FIXED();
        private DBClass dc = new DBClass();
        public static string JOB_Now;
        private static string JOB_New;
        private string JOB_ID_Now, JOB_ID_New;
        public static string Report1 { get; set; }
        public static string JOBID { get; set; }
        public static string CARUCODE { get; set; }
        public static string CARUNO { get; set; }
        public static string HisFix { get; set; }
        public static string Report2 { get; set; }
        public static string _JOB_Print_Report_Now { get; set; }

        public fmGroupSupplies()
        {
            InitializeComponent();
            btnSaveAcceptRequest.Enabled = false;
        }

        private void fmGroupSupplies_Load(object sender, EventArgs e)
        {
            ShowdgvAssignmentsStock();
        }

        private void ShowdgvAssignmentsStock()
        {
            //try
            //{
            var sql = "SELECT DISTINCT"
                         + " NJ.JOBID,DS.DEPT_NAME,FT.FT_NAME, RTRIM(D.DEPNAME) AS DEPTNAME, C2C.NAME, NJ.CARUCODE, NJ.CARUNO, "
                         + " SPEC, COS_CAUSE_TYPE.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL, "
                         + " dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy(NJ.BOSS_DATE) AS BOSS_DATE, JWT.JW_NAME, NJ.REMARK"
                         + " FROM COS_JOB NJ LEFT JOIN"
                         + " COS_CAUSE_TYPE ON NJ.CAUSE_ID = COS_CAUSE_TYPE.CAUSE_ID LEFT JOIN"
                         + " MUHDEP D ON NJ.DEPT_ID = D.DEPCODE LEFT JOIN"
                         + " [CARU2CODE] C2C ON NJ.CARUCODE = C2C.CARUCODE LEFT JOIN " +
                         "CARU2CARU c2 on c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO LEFT JOIN"
                         + " COS_JOB_WENT_TYPE JWT ON NJ.JOB_WANT_ID = JWT.JW_ID LEFT JOIN"
                         + " COS_PART_ORDER ON NJ.JOBID = COS_PART_ORDER.JOB_ID"
                         + " LEFT JOIN COS_USER U ON U.U_ID=COS_PART_ORDER.U_ID"
                         + " LEFT JOIN COS_DEPT_COS DS WITH (NOLOCK)ON DS.DEPT_ID=NJ.DEPT"
                         + " LEFT JOIN COS_FIXED_TYPE FT WITH (NOLOCK) ON FT.FT_ID=NJ.FIX_TYPE_ID"
                         + " WHERE (NJ.STATUS_FIX_ID = " + sf._รอพัสดุรับรายการสั่งซื้อ + " OR NJ.STATUS_FIX_ID = " + sf._ขออนุมัติซื้อทดแทน + ")";
            var dt = new DBClass().SqlGetData(sql);
            var dgv = dgvAssignmentsStock;
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "JOB_ID";
            dgv.Columns[1].HeaderText = "หน่วยงานซ่อม";
            dgv.Columns[2].HeaderText = "ประเภทซ่อม";
            dgv.Columns[3].HeaderText = "หน่วยงานส่งซ่อม";
            dgv.Columns[4].HeaderText = "ประเภทครุภัณฑ์";
            dgv.Columns[5].HeaderText = "เลขครุภัณฑ์";
            dgv.Columns[6].HeaderText = "ตัวย่อ";
            dgv.Columns[7].HeaderText = "สเปก";
            dgv.Columns[8].HeaderText = "อาการเสีย";
            dgv.Columns[9].HeaderText = "รายละเอียด";
            dgv.Columns[10].HeaderText = "ผู้แจ้งซ่อม";
            dgv.Columns[11].HeaderText = "เบอร์โทร";
            dgv.Columns[12].HeaderText = "วันที่ส่งซ่อม";
            dgv.Columns[13].HeaderText = "ขออนุมัตซื้อ";
            dgv.Columns[14].HeaderText = "ความต้องการ";
            dgv.Columns[15].HeaderText = "หมายเหตุ";

            dgv.Columns[0].Width = 120;
            dgv.Columns[1].Width = 120;
            dgv.Columns[2].Width = 160;
            dgv.Columns[3].Width = 120;
            dgv.Columns[4].Width = 200;
            dgv.Columns[5].Width = 130;
            dgv.Columns[6].Width = 80;
            dgv.Columns[7].Width = 200;
            dgv.Columns[8].Width = 150;
            dgv.Columns[9].Width = 130;
            dgv.Columns[10].Width = 70;
            dgv.Columns[11].Width = 50;
            dgv.Columns[12].Width = 110;
            dgv.Columns[13].Width = 120;
            dgv.Columns[14].Width = 70;
            dgv.Columns[15].Width = 70;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private int PART_ID_MAX;

        private void ShowOrder()
        {
            var sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C, ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART, PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE " +
                "from COS_PART_LIST P " +
                "LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID " +
                "LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT " +
                "LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C " +
                "LEFT JOIN COS_JOB NJ WITH(NOLOCK) ON NJ.JOBID = PO.JOB_ID " +
                "WHERE NJ.STATUS_FIX_ID = '20' AND SPL_ID='3'";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);

            dgvStock1.DataSource = dt;
            dgvStock1.Columns[0].Visible = true;
            dgvStock1.Columns[1].Visible = false;
            dgvStock1.Columns[2].Visible = false;
            dgvStock1.Columns[3].Visible = false;
            dgvStock1.Columns[4].HeaderText = "พัสดุ";
            dgvStock1.Columns[5].HeaderText = "จำนวน";
            dgvStock1.Columns[6].HeaderText = "หน่วย";
            dgvStock1.Columns[7].HeaderText = "ราคาต่อชิ้น";
            dgvStock1.Columns[8].HeaderText = "ราคารวม";
            dgvStock1.Columns[4].Width = 351;
            dgvStock1.Columns[5].Width = 75;
            dgvStock1.Columns[6].Width = 95;
            dgvStock1.Columns[7].Width = 95;
            dgvStock1.Columns[8].Width = 95;
        }

        private void ShowdgvStock3()
        {
            var sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C, ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART, PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE " +
                "from COS_PART_LIST P " +
                "LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID " +
                "LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT " +
                "LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C " +
                "LEFT JOIN COS_JOB NJ WITH(NOLOCK) ON NJ.JOBID = PO.JOB_ID " +
                "WHERE NJ.STATUS_FIX_ID = '20' AND SPL_ID='4' AND JOB_ID NOT IN (SELECT JOB_ID FROM COS_PO)";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);
            var dgv = dgvStock3;
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = true;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "พัสดุ";
            dgv.Columns[5].HeaderText = "จำนวน";
            dgv.Columns[6].HeaderText = "หน่วย";
            dgv.Columns[7].HeaderText = "ราคาต่อชิ้น";
            dgv.Columns[8].HeaderText = "ราคารวม";
            dgv.Columns[4].Width = 351;
            dgv.Columns[5].Width = 75;
            dgv.Columns[6].Width = 95;
            dgv.Columns[7].Width = 95;
            dgv.Columns[8].Width = 95;
        }

        private void ShowStock1()
        {
            var sql1 = "SELECT U_DEPT FROM [COS_JOB] NJ LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID WHERE JOBID = '" + JOB_Now + "'";
            var result = new DBClass().SqlGetData(sql1);
            var sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C,"
                                + " ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART,"
                                + " PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE"
                                + " from COS_PART_LIST P"
                                + " INNER JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                                + " INNER JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                                + " INNER JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C"
                                + " WHERE P.PL_DEPT = '" + result.Rows[0]["U_DEPT"].ToString() + "' AND P.HIDE = 'N' AND PO.JOB_ID = '" + JOB_Now + "' AND PO.SPL_ID='3'";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);

            var sql = "SELECT MAX(po.PO_ID) FROM COS_JOB as nj join COS_PART_ORDER as po on po.JOB_ID = nj.JOBID where nj.JOBID = '" + JOB_Now + "'";
            PART_ID_MAX = new DBClass().AutoNunber(sql);

            dgvStock1.DataSource = dt;
            dgvStock1.Columns[0].Visible = false;
            dgvStock1.Columns[1].Visible = false;
            dgvStock1.Columns[2].Visible = false;
            dgvStock1.Columns[3].Visible = false;
            dgvStock1.Columns[4].HeaderText = "พัสดุ";
            dgvStock1.Columns[5].HeaderText = "จำนวน";
            dgvStock1.Columns[6].HeaderText = "หน่วย";
            dgvStock1.Columns[7].HeaderText = "ราคาต่อชิ้น";
            dgvStock1.Columns[8].HeaderText = "ราคารวม";
            dgvStock1.Columns[4].Width = 351;
            dgvStock1.Columns[5].Width = 75;
            dgvStock1.Columns[6].Width = 95;
            dgvStock1.Columns[7].Width = 95;
            dgvStock1.Columns[8].Width = 95;

            //   var sql_PART_ORDER = "SELECT [JOB_ID],[PO_ID],[PO_NAME],[PO_QTY_REQUIRED],[PO_QTY_RECEIVED],[PO_UNIT],[PO_STANDARD_PRICE],PO_QTY_RECEIVED * PO_STANDARD_PRICE"
            //+ " FROM COS_PART_ORDER WHERE JOB_ID='" + JOB_Now + "' AND SPL_ID='2'";
            //   DataTable dt = new DBClass().SqlGetData(sql_PART_ORDER);

            //   dgvStock1.ColumnCount = 7;
            //   for (int j = 0; j < dt.Rows.Count; j++)
            //   {
            //       string[] row = new string[] { dt.Rows[j][0].ToString(), dt.Rows[j][1].ToString(), dt.Rows[j][2].ToString(), dt.Rows[j][3].ToString(), dt.Rows[j][4].ToString(), dt.Rows[j][5].ToString(), dt.Rows[j][6].ToString(), dt.Rows[j][7].ToString() };
            //       dgvStock1.Rows.Add(row);
            //   }
            //formatdgvStock1();
        }

        //private void formatdgvStock1()
        //{
        //    dgvStock1.Columns[0].HeaderText = "JOB_ID";
        //    dgvStock1.Columns[1].HeaderText = "PART_ID";
        //    dgvStock1.Columns[2].HeaderText = "ชื่ออะไหล่";
        //    dgvStock1.Columns[3].HeaderText = "จำนวน";
        //    dgvStock1.Columns[4].HeaderText = "หน่วย";
        //    dgvStock1.Columns[5].HeaderText = "ราคาต่อชิ้น";
        //    dgvStock1.Columns[6].HeaderText = "ราคารวม";

        //    dgvStock1.Columns[0].Width = 130;
        //    dgvStock1.Columns[1].Width = 60;
        //    dgvStock1.Columns[2].Width = 150;
        //    dgvStock1.Columns[3].Width = 80;
        //    dgvStock1.Columns[4].Width = 80;
        //    dgvStock1.Columns[5].Width = 75;
        //    dgvStock1.Columns[6].Width = 95;
        //    dgvStock1.ClearSelection();
        //}

        private void btnSaveAcceptRequest_Click(object sender, EventArgs e)
        {
            if (dgvStock1.SelectedRows.Count > 0)
            {
                var JOB_ID = dgvStock1.SelectedCells[0].Value.ToString();
                var PO_ID = dgvStock1.SelectedCells[1].Value.ToString();
                var PL_ID = dgvStock1.SelectedCells[2].Value.ToString();
                var PL_ID_C = dgvStock1.SelectedCells[3].Value.ToString();
                var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID"
                + " where JOB_ID = '" + JOB_ID + "'  AND PO_ID='" + PO_ID + "'";
                SqlParameterCollection param1 = new SqlCommand().Parameters;
                param1.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 4;
                int i1 = new DBClass().SqlExecute(sql, param1);
                ShowOrder();
                ShowdgvStock3();
            }
        }

        private string _id(DataTable dt)
        {
            var t = dt.Rows[0][0].ToString().Split('_');
            var s = Convert.ToInt32(t[1]) + 1;
            return s.ToString();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            string PO_NO = "";
            if (tabControl1.SelectedTab == tP0)
            {
                ShowdgvAssignmentsStock();
            }
            else if (tabControl1.SelectedTab == tP1)
            {
                ShowOrder();
                ShowdgvStock3();

                var sql = "SELECT TOP 1 PO_NO FROM COS_PO ORDER BY PO_NO DESC";
                var dt = new DBClass().SqlGetData(sql);
                if (dt.Rows.Count > 0)
                {
                    PO_NO = "PO_" + _id(dt);
                }
                else
                {
                    PO_NO = "PO_1";
                }
                txtPO.Text = PO_NO;
            }

            if (tabControl1.SelectedTab != tP1)
            {
                JOB_New = null;
                JOB_Now = null;
            }
            else if (tabControl1.SelectedTab == tP3)
            {
                ShowReport();
                btn1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tP5)
            {
                ShowData5();
            }
            else
            {
            }
        }

        private void ShowData5()
        {
        }

        private string PART_Now;
        private string PART_New;
        private int SPL_ID;
        private int QTY_VALUE;

        private void dgvStock1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvStock1.SelectedRows.Count > 0)
            {
                btnSaveAcceptRequest.Enabled = true;
            }
            else if (dgvStock1.SelectedRows.Count == 0)
            {
                btnSaveAcceptRequest.Enabled = false;
            }

            if (dgvStock3.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else if (dgvStock3.SelectedRows.Count == 0)
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            var sql1 = "SELECT DISTINCT NJ.JOBID, RTRIM(D.DEPNAME) AS DEPTNAME, C2C.NAME, U2.U_NAME,NJ.CARUCODE,"
                    + " NJ.CARUNO, SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL, "
                    + " dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy(NJ.EXPECT_DATE) AS EXPECT_DATE, NJ.PRINT_STATUS,NJ.PRINT_DATE,PO.U_ID,U.U_NAME"
                    + " FROM COS_JOB NJ"
                    + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                    + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                    + " LEFT JOIN [CARU2CODE] C2C ON NJ.CARUCODE = C2C.CARUCODE" +
                    " LEFT JOIN CARU2CARU c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO"
                    + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
                    + " LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID"
                    + " LEFT JOIN COS_USER U ON U.U_ID = PO.U_ID"
                    + " LEFT JOIN COS_USER U2 ON U2.U_ID = NJ.USER_ID"
                    + " WHERE(PO.SPL_ID = '2' OR PO.SPL_ID = '3' OR PO.SPL_ID = '4' OR PO.SPL_ID = '5' OR PO.SPL_ID = '6')"
                    + " AND NJ.PRINT_HIDE IS NULL"
                    + " AND(NJ.CARUCODE like '%" + txtCARUCODE.Text + "%' AND NJ.CARUNO like '%" + txtCARUNO.Text + "%')";

            var dt = new DBClass().SqlGetData(sql1);
            dgvPrintReports.DataSource = dt;
            dgvPrintReports.Columns[0].HeaderText = "JOB_ID";
            dgvPrintReports.Columns[1].HeaderText = "หน่วยงาน";
            dgvPrintReports.Columns[2].HeaderText = "ประเภท";
            dgvPrintReports.Columns[3].HeaderText = "ช่างผู้รับผิดชอบ";
            dgvPrintReports.Columns[4].HeaderText = "ครุภัณฑ์";
            dgvPrintReports.Columns[5].HeaderText = "ตัวย่อ";
            dgvPrintReports.Columns[6].HeaderText = "สเปก";
            dgvPrintReports.Columns[7].HeaderText = "อาการ";
            dgvPrintReports.Columns[8].HeaderText = "สาเหตุ";
            dgvPrintReports.Columns[9].HeaderText = "ผู้แจ้ง";
            dgvPrintReports.Columns[10].HeaderText = "เบอร์โทรกลับ";
            dgvPrintReports.Columns[11].HeaderText = "วันที่แจ้งซ่อม";
            dgvPrintReports.Columns[12].HeaderText = "วันกำหนดเสร็จ";
            dgvPrintReports.Columns[13].HeaderText = "ปริ้น";
            dgvPrintReports.Columns[14].HeaderText = "วันที่ปริ้น";

            dgvPrintReports.Columns[0].Width = 125;
            dgvPrintReports.Columns[1].Width = 85;
            dgvPrintReports.Columns[2].Width = 130;
            dgvPrintReports.Columns[3].Width = 130;
            dgvPrintReports.Columns[4].Width = 102;
            dgvPrintReports.Columns[5].Width = 70;
            dgvPrintReports.Columns[6].Width = 190;
            dgvPrintReports.Columns[7].Width = 95;
            dgvPrintReports.Columns[8].Width = 90;
            dgvPrintReports.Columns[9].Width = 90;
            dgvPrintReports.Columns[10].Width = 90;
            dgvPrintReports.Columns[11].Width = 110;
            dgvPrintReports.Columns[12].Width = 90;
            dgvPrintReports.Columns[13].Width = 60;
            dgvPrintReports.Columns[14].Width = 120;

            if (User._U_ID != "8")
            {
                dgvPrintReports.Columns[15].HeaderText = "U_ID";
                dgvPrintReports.Columns[16].HeaderText = "พัสดุผู้รับผิดชอบ";
                dgvPrintReports.Columns[15].Visible = true;
                dgvPrintReports.Columns[16].Visible = true;
                dgvPrintReports.Columns[15].Width = 120;
                dgvPrintReports.Columns[16].Width = 120;
            }
            else
            {
                dgvPrintReports.Columns[15].HeaderText = "U_ID";
                dgvPrintReports.Columns[16].HeaderText = "พัสดุผู้รับผิดชอบ";
                dgvPrintReports.Columns[15].Visible = false;
                dgvPrintReports.Columns[16].Visible = false;
                dgvPrintReports.Columns[15].Width = 120;
                dgvPrintReports.Columns[16].Width = 120;
            }

            dgvPrintReports.ClearSelection();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var dgv = dgvPrintReports;

            CARUCODE = dgv.SelectedCells[4].Value.ToString();
            CARUNO = dgv.SelectedCells[5].Value.ToString();

            if (JOB_ID_Now == "" || JOB_ID_Now == null)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกรายการที่จะปริ้น", "ผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Interaction.InputBox("ใส่รหัสความปลอดภัย", "ทำการยืนยัน", null) == User._U_PASSWORD)
            {
                Report1 = "SELECT DISTINCT NJ.JOBID,dbo.dmyCOS(SUBSTRING(PO_ACCEPT_DATE,1,8))AS PO_ACCEPT_DATE,"
                    + " (select U_NAME from COS_USER WHERE U_ID = PO.U_ID)AS NAME, RTRIM(D.DEPNAME)AS DEPTNAME, "
                    + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, C2C.NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
                    + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
                    + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
                    + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE_SOTCK, 1, 8))AS PO_ASSIGN_DATE_SOTCK,MOTIVE,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                    + " FROM COS_JOB NJ"
                    + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                    + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                    + " LEFT JOIN [CARU2CODE]C2C ON NJ.CARUCODE = C2C.CARUCODE"
                    + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
                    + " LEFT JOIN COS_FIXED_TYPE ON NJ.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
                    + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
                    + " LEFT JOIN COS_PART_ORDER PO ON PO.JOB_ID = NJ.JOBID"
                    + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID = NJ.FIX_TYPE_ID"
                    + " LEFT JOIN COS_PART_LIST_C PLC ON PLC.PL_ID = PO.PL_ID"
                    + " LEFT JOIN COS_PART_LIST PL ON PL.PL_ID = PO.PL_ID AND PLC.PL_ID_C = PO.PL_ID_C"
                    + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT"
                    + " CROSS JOIN COS_COS C"
                    + " where NJ.JOBID = (SELECT distinct NJ.JOBID FROM COS_JOB where NJ.JOBID = '" + dgvPrintReports.SelectedCells[0].Value + "') AND PL.PL_ID IS NOT NULL";

                //fmReport1 f1 = new fmReport1();
                //f1.Dock = DockStyle.Fill;
                //f1.Show();

                var sqlupdate = "update COS_JOB set PRINT_STATUS=@PRINT_STATUS,PRINT_DATE=@PRINT_DATE where JOBID = '" + JOB_ID_Now + "'";
                SqlParameterCollection param2 = new SqlCommand().Parameters;
                param2.AddWithValue("@PRINT_STATUS", SqlDbType.Char).Value = "Y";              //กำลังดำเนินการสั่งซื้อ
                param2.AddWithValue("@PRINT_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");//วันที่ปริ้น
                int i2 = new DBClass().SqlExecute(sqlupdate, param2);

                JOB_ID_Now = "";
                dgvPrintReports.ClearSelection();
            }
        }

        private void fmGroupSupplies_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgvPrintReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            JOB_ID_New = dgvPrintReports.Rows[dgvPrintReports.Rows[e.RowIndex].Index].Cells[0].Value.ToString();
            if (JOB_ID_Now == JOB_ID_New)
            {
                dgvPrintReports.ClearSelection();
                JOB_ID_New = "";
                JOB_ID_Now = "";
                btn1.Enabled = false;
            }
            else
            {
                dgvPrintReports.Rows[dgvPrintReports.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvPrintReports.Rows[dgvPrintReports.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                JOB_ID_Now = JOB_ID_New;
                btn1.Enabled = true;
            }
        }

        private void dgv5_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv5.ClearSelection();
        }

        private void txtCARUCODE_TextChanged(object sender, EventArgs e)
        {
            if (txtCARUCODE.Text.Length > 0)
            {
                btnPrintReport.Enabled = true;
            }
        }

        private void txtCARUNO_TextChanged(object sender, EventArgs e)
        {
            if (txtCARUNO.Text.Length > 0)
            {
                btnPrintReport.Enabled = true;
            }
        }

        private void dgvStock1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStock1.ClearSelection();
        }

        private void dgv5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 11))
            {
                var value = (Convert.ToString(e.Value)).Substring(1, 2);
                if (Convert.ToInt32(value) <= 20)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dgvPrintReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 13))
            {
                if (Convert.ToString(e.Value) == "Y")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvAssignmentsStock.Rows.Count > 0)
            {
                var dgv = dgvAssignmentsStock;
                var JOB_ID = dgv.SelectedCells[0].Value.ToString();
                var FT = dgv.SelectedCells[2].Value.ToString();
                string status_fix_id = "";

                if ("ซ่อมเองโดยขออนุมัติซื้อพัสดุ" == FT)
                {
                    status_fix_id = sf._ขออนุมัติพัสดุสั่งซื้อ;
                }
                else if ("ขออนุมัติซื้อทดแทน" == FT)
                {
                    status_fix_id = sf._ขออนุมัติซื้อทดแทน;
                }
                var getDate = dc.GetDate();

                var sql = "UPDATE COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,SUPPLIES_DATE=@SUPPLIES_DATE"
                                        + " where JOBID = '" + JOB_ID + "'";
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = status_fix_id;
                param.AddWithValue("@SUPPLIES_DATE", SqlDbType.VarChar).Value = getDate;
                int i = new DBClass().SqlExecute(sql, param);

                var sql_PO = "UPDATE COS_PART_ORDER SET SPL_ID=@SPL_ID"
                                       + " where JOB_ID = '" + JOB_ID + "'";
                SqlParameterCollection param_PO = new SqlCommand().Parameters;
                param_PO.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
                int i2 = new DBClass().SqlExecute(sql_PO, param_PO);

                ShowdgvAssignmentsStock();
            }

            //MessageBox.Show("ผิดพลาด " + ex.Message + "กรุณาปริ้น JOB " + JOB_ID + "ใหม่อีกที!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvAssignmentsStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAssignmentsStock.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fmCompanys f2 = new fmCompanys();
            f2.Dock = DockStyle.Fill;
            f2.Show();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //if (dgvMain.SelectedRows.Count < 1)
            //{
            //    MessageBox.Show("กรุณาเลือก JOB งานก่อนเลือกวิธีซ่อมด้วยครับ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //cbxPART_NAME.DataSource = null;
            //txtREF_PRICE.Text = "";
            //txtTotal.Text = "";
            //dgvStock.Rows.Clear();
            try
            {
                string sql = "select * from COS_COMPANY WHERE HIDE='N' order by [COMPANY_NAME] desc";
                var dt = new DBClass().SqlGetData(sql);
                cbxCOMPANY.DataSource = dt;
                cbxCOMPANY.DisplayMember = "COMPANY_NAME";
                cbxCOMPANY.ValueMember = "ID";
                cbxCOMPANY.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dgv = dgvStock3;
            if (dgv.SelectedRows.Count > 0)
            {
                var JOB_ID = dgv.SelectedCells[0].Value.ToString();
                var PO_ID = dgv.SelectedCells[1].Value.ToString();
                var PL_ID = dgv.SelectedCells[2].Value.ToString();
                var PL_ID_C = dgv.SelectedCells[3].Value.ToString();
                var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID"
                + " where JOB_ID = '" + JOB_ID + "'  AND PO_ID='" + PO_ID + "'";
                SqlParameterCollection param1 = new SqlCommand().Parameters;
                param1.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
                int i1 = new DBClass().SqlExecute(sql, param1);
                ShowOrder();
                ShowdgvStock3();
            }
        }

        private void dgvStock3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStock3.ClearSelection();
        }

        private void dgvStock3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            //if (dgvStock1.SelectedRows.Count > 0)
            //{
            //    btnSaveAcceptRequest.Enabled = false;
            //}
            //else if (dgvStock1.SelectedRows.Count == 0)
            //{
            //    btnSaveAcceptRequest.Enabled = true;
            //}

            if (dgvStock3.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else if (dgvStock3.SelectedRows.Count == 0)
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStock3.Rows.Count; i++)
            {
                var JOB_ID = dgvStock3.Rows[i].Cells[0].Value.ToString();

                var date = dc.GetDate();
                var sql_order = "INSERT INTO COS_PO (PO_NO, JOB_ID, DATE, COMPANY)VALUES"
                                                + "(@PO_NO, @JOB_ID, @DATE, @COMPANY)";
                SqlParameterCollection param_order = new SqlCommand().Parameters;
                param_order.AddWithValue("@PO_NO", SqlDbType.VarChar).Value = txtPO.Text;
                param_order.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = JOB_ID;
                param_order.AddWithValue("@DATE", SqlDbType.VarChar).Value = dc.GetDate();
                param_order.AddWithValue("@COMPANY", SqlDbType.Int).Value = cbxCOMPANY.SelectedValue.ToString();
                int i_order = new DBClass().SqlExecute(sql_order, param_order);
            }
            ShowOrder();
            ShowdgvStock3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (Interaction.InputBox("ใส่รหัสความปลอดภัย", "ทำการยืนยัน", null) == User._U_PASSWORD)
            {
                fmReport2 f2 = new fmReport2(JOB_ID_Now);
                f2.Dock = DockStyle.Fill;
                f2.Show();
            }
        }
    }
}