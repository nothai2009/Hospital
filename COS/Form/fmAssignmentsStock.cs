using ReadWriteIniFileExample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAssignmentsStock : Form
    {
        private printReport pr = new printReport();
        public static Boolean showPreview = true;
        public static string CARUCODE { get; set; }
        public static string CARUNO { get; set; }
        private DBClass dc = new DBClass();

        public fmAssignmentsStock()
        {
            InitializeComponent();
            ReadIni();
        }

        private void ShowStock()
        {
            //try
            //{
            var sql = "SELECT DISTINCT"
                          + " NJ.JOBID,FT.FT_NAME, RTRIM(MUHDEP.DEPNAME) AS DEPNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO, "
                          + " SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL, "
                          + " dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy_hm(NJ.ACCEPT_DATE) AS ACCEPT_DATE, JWT.JW_NAME, "
                          + " NJ.REMARK,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                          + " FROM COS_JOB NJ " +
                          " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID " +
                          " LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE " +
                          " LEFT JOIN [CARU2CODE] c2c ON NJ.CARUCODE = c2c.CARUCODE " +
                          " LEFT JOIN [CARU2CARU] c2 ON NJ.CARUCODE = c2.CARUCODE AND NJ.CARUNO=c2.CARUNO" +
                          " LEFT JOIN COS_JOB_WENT_TYPE JWT ON NJ.JOB_WANT_ID = JWT.JW_ID " +
                          " LEFT JOIN COS_PART_ORDER ON NJ.JOBID = COS_PART_ORDER.JOB_ID " +
                          " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID=NJ.FIX_TYPE_ID" +
                          " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
                          + " WHERE(COS_PART_ORDER.SPL_ID = 2) AND (COS_PART_ORDER.U_ID is null)";
            DataTable dt = new DBClass().SqlGetData(sql);
            dgvAssignmentsStock.DataSource = dt;
            dgvAssignmentsStock.Columns[0].HeaderText = "JOB_ID";
            dgvAssignmentsStock.Columns[1].HeaderText = "วิธีการซ่อม";
            dgvAssignmentsStock.Columns[2].HeaderText = "หน่วยงาน";
            dgvAssignmentsStock.Columns[3].HeaderText = "ประเภท";
            dgvAssignmentsStock.Columns[4].HeaderText = "ครุภัณฑ์";
            dgvAssignmentsStock.Columns[5].HeaderText = "เลขท้าย";
            dgvAssignmentsStock.Columns[6].HeaderText = "สเปก";
            dgvAssignmentsStock.Columns[7].HeaderText = "อาการ";
            dgvAssignmentsStock.Columns[8].HeaderText = "รายละเอียด";
            dgvAssignmentsStock.Columns[9].HeaderText = "ผู้แจ้ง";
            dgvAssignmentsStock.Columns[10].HeaderText = "เบอร์โทร";
            dgvAssignmentsStock.Columns[11].HeaderText = "วันที่แจ้งซ่อม";
            dgvAssignmentsStock.Columns[12].HeaderText = "วันขอซื้อ";
            dgvAssignmentsStock.Columns[13].HeaderText = "ความต้องการ";
            dgvAssignmentsStock.Columns[14].HeaderText = "หมายเหตุ";

            dgvAssignmentsStock.Columns[0].Width = 120;
            dgvAssignmentsStock.Columns[1].Width = 120;
            dgvAssignmentsStock.Columns[2].Width = 120;
            dgvAssignmentsStock.Columns[3].Width = 100;
            dgvAssignmentsStock.Columns[4].Width = 100;
            dgvAssignmentsStock.Columns[5].Width = 60;
            dgvAssignmentsStock.Columns[6].Width = 95;
            dgvAssignmentsStock.Columns[7].Width = 90;
            dgvAssignmentsStock.Columns[8].Width = 90;
            dgvAssignmentsStock.Columns[9].Width = 90;
            dgvAssignmentsStock.Columns[10].Width = 110;
            dgvAssignmentsStock.Columns[11].Width = 110;
            dgvAssignmentsStock.Columns[12].Width = 110;
            dgvAssignmentsStock.Columns[13].Width = 90;
            dgvAssignmentsStock.Columns[14].Width = 90;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkShowPreview.Checked == true)
            {
                PrintPreview();
            }
            else
            {
                PrintNoPreview();
            }
        }

        private void cbxRESPONSE_JOB_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "select U_ID,U_NAME from COS_USER WHERE [U_DEPT]='9'";
                var dt = new DBClass().SqlGetData(sql);
                cbxU_ID.DataSource = dt;
                cbxU_ID.ValueMember = "U_ID";
                cbxU_ID.DisplayMember = "U_NAME";
                cbxU_ID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvAssignmentsStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAssignmentsStock.ClearSelection();
        }

        private void dgvAssignmentsStock_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvAssignmentsStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgvAssignmentsStock;
            CARUCODE = dgv.SelectedCells[4].Value.ToString();
            CARUNO = dgv.SelectedCells[5].Value.ToString();
        }

        private void ReadIni()
        {
            string value = IniFileHelper.ReadValue("Printer", "Printer", Path.GetFullPath(dc.pathIni));
            cbxPrinter.Items.Add(value);
            cbxPrinter.SelectedIndex = 0;

            var cbx = comboBox1;
            cbx.Items.Add(value);
            cbx.SelectedIndex = 0;
        }

        private void fmAssignmentsStock_Load(object sender, EventArgs e)
        {
            ReadIni();
            ShowStock();
        }

        private void cbxPrinter_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ShowPrinter()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            var dgv = dgvPrinted;
            var cbx = cbxSelect2;

            //try
            //{
            var sql = "SELECT DISTINCT"
                          + " NJ.JOBID,FT.FT_NAME, RTRIM(MUHDEP.DEPNAME) AS DEPNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO, "
                          + " SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL, "
                          + " dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy_hm(NJ.ACCEPT_DATE) AS ACCEPT_DATE, JWT.JW_NAME, "
                          + " NJ.REMARK,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                          + " FROM COS_JOB NJ"
                          + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                          + " LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE"
                          + " LEFT JOIN [CARU2CODE]c2c ON NJ.CARUCODE = c2c.CARUCODE"
                          + " LEFT JOIN [CARU2CARU] c2 ON NJ.CARUCODE = c2.CARUCODE AND NJ.CARUNO=c2.CARUNO"
                          + " LEFT JOIN COS_JOB_WENT_TYPE JWT ON NJ.JOB_WANT_ID = JWT.JW_ID"
                          + " LEFT JOIN COS_PART_ORDER ON NJ.JOBID = COS_PART_ORDER.JOB_ID"
                          + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID=NJ.FIX_TYPE_ID"
                          + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
                          + " WHERE(COS_PART_ORDER.SPL_ID > 2) AND (NJ.FINISH_DATE IS NOT NULL)";
            DataTable dt = new DBClass().SqlGetData(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "JOB_ID";
            dgv.Columns[1].HeaderText = "วิธีการซ่อม";
            dgv.Columns[2].HeaderText = "หน่วยงาน";
            dgv.Columns[3].HeaderText = "ประเภท";
            dgv.Columns[4].HeaderText = "ครุภัณฑ์";
            dgv.Columns[5].HeaderText = "เลขท้าย";
            dgv.Columns[6].HeaderText = "สเปก";
            dgv.Columns[7].HeaderText = "อาการ";
            dgv.Columns[8].HeaderText = "รายละเอียด";
            dgv.Columns[9].HeaderText = "ผู้แจ้ง";
            dgv.Columns[10].HeaderText = "เบอร์โทร";
            dgv.Columns[11].HeaderText = "วันที่แจ้งซ่อม";
            dgv.Columns[12].HeaderText = "วันขอซื้อ";
            dgv.Columns[13].HeaderText = "ความต้องการ";
            dgv.Columns[14].HeaderText = "หมายเหตุ";

            dgv.Columns[0].Width = 120;
            dgv.Columns[1].Width = 120;
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 100;
            dgv.Columns[5].Width = 60;
            dgv.Columns[6].Width = 95;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 90;
            dgv.Columns[10].Width = 110;
            dgv.Columns[11].Width = 110;
            dgv.Columns[12].Width = 110;
            dgv.Columns[13].Width = 90;
            dgv.Columns[14].Width = 90;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            test.Add(dgv.Columns[2].Name, dgv.Columns[2].HeaderText);
            test.Add(dgv.Columns[3].Name, dgv.Columns[3].HeaderText);
            test.Add(dgv.Columns[4].Name, dgv.Columns[4].HeaderText);
            test.Add(dgv.Columns[10].Name, dgv.Columns[10].HeaderText);
            cbx.DataSource = new BindingSource(test, null);
            cbx.DisplayMember = "Value";
            cbx.ValueMember = "Key";
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            var tab = tabControl1;
            if (tab.SelectedTab == tp1)
            {
                ShowStock();
                cbxSelect1.SelectedIndex = -1;
            }
            else if (tab.SelectedTab == tp2)
            {
                ShowPrinter();
                cbxSelect2.SelectedIndex = -1;
            }
        }

        private void PrintNoPreview()
        {
            DataGridView dgv;
            string JOB_ID, Carucode, Caruno, Pritername;

            if (tabControl1.SelectedIndex == 0)
            {
                dgv = dgvAssignmentsStock;
            }
            else
            {
                dgv = dgvPrinted;
            }

            JOB_ID = dgv.SelectedCells[0].Value.ToString();
            Carucode = dgv.SelectedCells[4].Value.ToString();
            Caruno = dgv.SelectedCells[5].Value.ToString();
            Pritername = cbxPrinter.SelectedItem.ToString();

            if (tabControl1.SelectedIndex == 0)
            {
                var sqlCOS_JOB = "UPDATE COS_JOB set USER_BOSS=@USER_BOSS"
                                + " WHERE JOB_ID = '" + JOB_ID + "'";
                SqlParameterCollection paramCOS_JOB = new SqlCommand().Parameters;
                paramCOS_JOB.AddWithValue("@USER_BOSS", SqlDbType.Int).Value = 3;
                int i1 = new DBClass().SqlExecute(sqlCOS_JOB, paramCOS_JOB);

                var sql = "UPDATE COS_PART_ORDER set SPL_ID=@SPL_ID"
                                + " WHEREs JOB_ID = '" + JOB_ID + "'";

                //var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID,U_ID=@U_ID,EXPECT_DATE=@EXPECT_DATE,PO_ASSIGN_DATE_SOTCK=@PO_ASSIGN_DATE_SOTCK"
                //                + " where JOB_ID = '" + JOB_ID + "'";
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
                //param.AddWithValue("@U_ID", SqlDbType.Int).Value = cbxU_ID.SelectedValue;
                //param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = dtpEXPECT_DATE.Value.ToString("yyyyMMdd");
                //param.AddWithValue("@PO_ASSIGN_DATE_SOTCK", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                int i = new DBClass().SqlExecute(sql, param);
            }

            pr.noPreview(JOB_ID,Carucode,Caruno, Pritername);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    Error = true;
            //}

            ShowStock();
            cbxU_ID.SelectedIndex = -1;
        }

        private void PrintPreview()
        {
            //DataGridView dgv;
            //if (tabControl1.SelectedIndex == 0)
            //{
            //    dgv = dgvAssignmentsStock;
            //}
            //else
            //{
            //    dgv = dgvPrinted;
            //}

            //var JOB_ID = dgv.SelectedCells[0].Value.ToString();

            //try
            //{
            //    if (dgvAssignmentsStock.SelectedRows.Count > 1)
            //    {
            //    }
            //    if (cbxU_ID.Text == "" && tabControl1.SelectedIndex == 0)
            //    {
            //        MessageBox.Show("กรุณาเลือกพัสดุที่จะมอบหมายให้", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (tabControl1.SelectedIndex == 0)
            //    {
            //        var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID,U_ID=@U_ID,EXPECT_DATE=@EXPECT_DATE,PO_ASSIGN_DATE_SOTCK=@PO_ASSIGN_DATE_SOTCK"
            //                        + " where JOB_ID = '" + JOB_ID + "'";
            //        SqlParameterCollection param = new SqlCommand().Parameters;
            //        param.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
            //        param.AddWithValue("@U_ID", SqlDbType.Int).Value = cbxU_ID.SelectedValue;
            //        param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = dtpEXPECT_DATE.Value.ToString("yyyyMMdd");
            //        param.AddWithValue("@PO_ASSIGN_DATE_SOTCK", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
            //        int i = new DBClass().SqlExecute(sql, param);
            //    }

            //    //ปริ้นใบแจ้งซ่อม
            //    Report1 = "SELECT DISTINCT NJ.JOBID,"
            //        + " (select U_NAME from COS_USER WHERE U_ID = PO.U_ID)AS NAME, RTRIM(D.DEPNAME)AS DEPTNAME, "
            //        + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, c2c.NAME AS CT_NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
            //        + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + '' + ISNULL(PL_BRAND, '') + '' + ISNULL(PL_GEN, '') + '' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
            //        + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
            //        + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE_SOTCK, 1, 8))AS PO_ASSIGN_DATE_SOTCK,NJ.MOTIVE,NJ.FIXED_DETAIL,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
            //        + " FROM COS_JOB NJ"
            //        + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
            //        + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
            //        + " LEFT JOIN [CARU2CODE]c2c ON NJ.CARUCODE = c2c.CARUCODE"
            //        + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
            //        + " LEFT JOIN COS_FIXED_TYPE ON NJ.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
            //        + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
            //        + " LEFT JOIN COS_PART_ORDER PO ON PO.JOB_ID = NJ.JOBID"
            //        + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID = NJ.FIX_TYPE_ID"
            //        + " LEFT JOIN COS_PART_LIST_C PLC ON PLC.PL_ID = PO.PL_ID AND PLC.PL_ID_C = PO.PL_ID_C"
            //        + " LEFT JOIN COS_PART_LIST PL ON PL.PL_ID = PO.PL_ID "
            //        + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT"
            //        + " CROSS JOIN COS_COS C"
            //        + " where NJ.JOBID = (SELECT distinct COS_JOB.JOBID FROM COS_JOB where COS_JOB.JOBID = '" + JOB_ID + "')";
            //    CARUCODE = dgv.SelectedCells[4].Value.ToString();
            //    CARUNO = dgv.SelectedCells[5].Value.ToString();

            //    fmReport1 f = new fmReport1(Report1, CARUCODE, CARUNO);
            //    f.Dock = DockStyle.Fill;
            //    f.ShowDialog();

            //    ShowStock();
            //    cbxU_ID.SelectedIndex = -1;
            //}
            //catch (Exception ex)
            //{
            //    //ถ้างานผิดพลาดให้สั่งปริ้นใหม่
            //    //var sql = "update COS_PART_ORDER set SPL_ID=@SPL_ID,U_ID=@U_ID,EXPECT_DATE=@EXPECT_DATE,PO_ASSIGN_DATE_SOTCK=@PO_ASSIGN_DATE_SOTCK"
            //    //                    + " where JOB_ID = '" + JOB_ID + "'";
            //    //SqlParameterCollection param = new SqlCommand().Parameters;
            //    //param.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 2;
            //    //param.AddWithValue("@U_ID", SqlDbType.Int).Value = null;
            //    //param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = null;
            //    //param.AddWithValue("@PO_ASSIGN_DATE_SOTCK", SqlDbType.VarChar).Value = null;
            //    //int i = new DBClass().SqlExecute(sql, param);
            //    MessageBox.Show("ผิดพลาด " + ex.Message + "กรุณาปริ้น JOB " + JOB_ID + "ใหม่อีกที!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //var objPrintDoc = new PrintDocument();
            //objPrintDoc.PrintPage += (obj, eve) =>
            //{
            //    Image img = Image.FromFile(label2.Text);
            //    Point loc = new Point(0, 0);
            //    eve.Graphics.DrawImage(img, loc);
            //};
            //objPrintDoc.PrinterSettings.PrinterName = cbxPrinter.SelectedItem.ToString();
            //objPrintDoc.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                PrintPreview();
            }
            else
            {
                PrintNoPreview();
            }
        }

        private void cbxPrinter_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cbxPrinter_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            var cbx = comboBox1;
            cbx.DataSource = null;
            cbx.Items.Clear();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            var cbx = comboBox1;
            bool result = IniFileHelper.WriteValue("Printer", "Printer", cbx.SelectedItem.ToString(), Path.GetFullPath(dc.pathIni));
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var cbx = comboBox1;
            cbx.Items.Clear();
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbx.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cbx.SelectedIndex = cbx.Items.IndexOf(strPrinter);
                }
            }
        }
    }
}