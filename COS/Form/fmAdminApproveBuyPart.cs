using COS;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmAdminApproveBuyPart : Form
    {
        private User.FIXED_TYPE uf = new User.FIXED_TYPE();
        private User.STATUS_FIXED sf = new User.STATUS_FIXED();
        private List<string> PART_ID = new List<string>();
        private List<int> lt = new List<int>();
        private printReport pr = new printReport();
        private DBClass dc = new DBClass();
       
        private string FIX_TYPE_ID;
        private double tmpNetTotal;
        private int PART_STOCK = 1;
        private int PART_ID_MAX;
        private int PL_ID_C = 0;
        private string JOBID, Carucode, Caruno, Pritername;
        private string REQ_DATE;
        public static string Report2 { get; set; }


        public fmAdminApproveBuyPart()
        {
            InitializeComponent();
            dc.LoadPrinter(cbxPrinter);
            dc.LoadPrinter(cbxPrinterOld);
        }

        private void dgvAdminApproveBuyPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            FIX_TYPE_ID = dgvAdminApproveBuyPart.SelectedCells[16].Value.ToString();

            gbStock.Enabled = true;

            if (FIX_TYPE_ID == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIX_TYPE_ID == uf._ขออนุมัติซื้อทดแทน)
            {
                ShowPART_ORDER();
            }
            else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนในประกัน)
            {
                gbStock.Enabled = false;
                dgvStock.Enabled = false;
            }
            else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนนอกประกัน)
            {
                gbStock.Enabled = false;
                dgvStock.Enabled = false;
            }
        }

        private void fmAdminApproveBuyPart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uHDATADataSet.COS_JOB' table. You can move, or remove it, as needed.
            // this.COS_JOBTableAdapter.Fill(this.uHDATADataSet.COS_JOB);
            ShowAdminApproveBuyPart();
            gbStock.Enabled = false;
        }

        private void ShowAdminApproveBuyPart()
        {
            //try
            //{
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
            "WHERE NO='4' AND NJ.DEPT='" + User._U_DEPT + "'"; // AND NJ.FIXED_DATE IS NOT NULL";

            DataTable dt = new DBClass().SqlGetData(sql);
            var dgv = dgvAdminApproveBuyPart;
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

            dgv.Columns[0].Width = 110;
            dgv.Columns[1].Width = 170;
            dgv.Columns[2].Width = 130;
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].Width = 95;
            dgv.Columns[5].Width = 55;
            dgv.Columns[6].Width = 230;
            dgv.Columns[7].Width = 230;
            dgv.Columns[8].Width = 230;
            dgv.Columns[9].Width = 65;
            dgv.Columns[10].Width = 108;
            dgv.Columns[11].Width = 108;
            dgv.Columns[12].Width = 119;
            dgv.Columns[13].Width = 114;
            dgv.Columns[14].Width = 114;
            dgv.Columns[15].Visible = false;
            dgv.Columns[16].Visible = false;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void dgvAdminApproveBuyPart_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            //e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            //e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
        }

        private void dgvAdminApproveBuyPart_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAdminApproveBuyPart.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var JOBID = dgvAdminApproveBuyPart.CurrentRow.Cells[0].Value.ToString();
            string[] row = new string[] { JOBID, PART_STOCK.ToString(), cbxPART_NAME.SelectedValue.ToString(), PL_ID_C.ToString(), cbxPART_NAME.Text, nud1.Value.ToString(), labelUNIT.Text, txtREF_PRICE.Text, txtTotal.Text };
            dgvStock.ColumnCount = 8;
            dgvStock.Rows.Add(row);
            PART_STOCK++;
            dgvStock.ClearSelection();

            tmpNetTotal = 0;
            for (int rows = 0; rows < dgvStock.Rows.Count; rows++)
            {
                tmpNetTotal += Convert.ToDouble(dgvStock.Rows[rows].Cells[7].Value.ToString());
            }
            txtTotal.Text = txtTotal.ToString();
            cbxPART_NAME.SelectedIndex = -1;
            ClearStock();
            dgvStock.Columns[4].Name = "ชื่อพัสดุ";
            dgvStock.Columns[5].Name = "จำนวน";
            dgvStock.Columns[5].Name = "หน่วย";
            dgvStock.Columns[7].Name = "ราคา";

            dgvStock.Columns[0].Visible = false;
            dgvStock.Columns[1].Visible = false;
            dgvStock.Columns[2].Visible = false;
            dgvStock.Columns[3].Visible = false;
            dgvStock.Columns[4].Width = 599;
            dgvStock.Columns[5].Width = 70;
            dgvStock.Columns[6].Width = 70;
            dgvStock.Columns[7].Width = 70;
        }

        private void ClearStock()
        {
            cbxPART_NAME.SelectedIndex = -1;
            nud1.Value = 1;
            txtREF_PRICE.Clear();
            labelUNIT.Text = "";
            txtTotal.Clear();
        }

        private void ShowPART_USED()
        {
            try
            {
                string sql = "select JOB_ID,PART_ID,PART_NAME,QTY,UNIT,STANDARD_PRICE,TOTAL_STANDARD_PRICE"
                    + " from CARU2_COS_PART_USED where JOB_ID = '" + dgvAdminApproveBuyPart.CurrentRow.Cells[0].Value.ToString() + "' order by (CAST(PART_ID AS Int)) desc";
                DataTable dt = new DBClass().SqlGetData(sql);
                dgvStock.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowPART_ORDER()
        {
            string sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C,"
                                + " ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART,"
                                + " PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE"
                                + " from COS_PART_LIST P"
                                + " INNER JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                                + " INNER JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                                + " INNER JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C"
                                + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N' AND PO.JOB_ID = '" + dgvAdminApproveBuyPart.CurrentRow.Cells[0].Value.ToString() + "' AND PO.SPL_ID='1'";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);

            var sql = "SELECT MAX(po.PO_ID) FROM COS_JOB as nj join COS_PART_ORDER as po on po.JOB_ID = nj.JOBID where nj.JOBID = '" + dgvAdminApproveBuyPart.CurrentRow.Cells[0].Value.ToString() + "'";
            PART_ID_MAX = new DBClass().AutoNunber(sql);

            dgvStock.DataSource = dt;
            dgvStock.Columns[4].Name = "ชื่อพัสดุ";
            dgvStock.Columns[5].Name = "จำนวน";
            dgvStock.Columns[5].Name = "หน่วย";
            dgvStock.Columns[7].Name = "ราคา";

            dgvStock.Columns[0].Visible = false;
            dgvStock.Columns[1].Visible = false;
            dgvStock.Columns[2].Visible = false;
            dgvStock.Columns[3].Visible = false;
            dgvStock.Columns[4].Width = 599;
            dgvStock.Columns[5].Width = 70;
            dgvStock.Columns[6].Width = 70;
            dgvStock.Columns[7].Width = 70;
        }

        private void cbxPART_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1;
                var sql = "select P.PL_ID,PL.PL_ID_C,ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART,"
                                    + " U.ST_NAME,PL.PL_PRICE"
                                    + " from COS_PART_LIST P"
                                    + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                                    + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                                    + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N'"
                                    + " ORDER BY PL_NAME";
                dt1 = new DBClass().SqlGetData(sql);
                cbxPART_NAME.DataSource = dt1;
                cbxPART_NAME.ValueMember = "PL_ID";
                cbxPART_NAME.DisplayMember = "PART";

                lt.Clear();
                for (int i = 0; i < dt1.Rows.Count - 1; i++)
                {
                    lt.Add(Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbxPART_NAME_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PL_ID_C = lt[cbxPART_NAME.SelectedIndex];
                var sql = "select U.ST_NAME,PL.PL_PRICE from COS_PART_LIST P"
                            + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                            + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                            + " WHERE(P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N') AND(P.PL_ID = '" + cbxPART_NAME.SelectedValue + "' AND PL_ID_C = '" + PL_ID_C + "')";
                DataTable dt = new DBClass().SqlGetData(sql);
                labelUNIT.Text = dt.Rows[0]["ST_NAME"].ToString();
                txtREF_PRICE.Text = dt.Rows[0]["PL_PRICE"].ToString();
                txtTotal.Text = Convert.ToString(nud1.Value * Convert.ToDecimal(txtREF_PRICE.Text));
                nud1.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void nud1_ValueChanged(object sender, EventArgs e)
        {
            Cal();
        }

        private void dgvStock_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
        }

        private void dgvStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStock.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvStock.SelectedRows)
            {
                dgvStock.Rows.RemoveAt(item.Index);
            }
            ClearStock();
            dgvStock.ClearSelection();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            dgvStock.Rows.Clear();
            ClearStock();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvAdminApproveBuyPart;
            FIX_TYPE_ID = dgv.SelectedCells[16].Value.ToString();
            var JOB_ID = dgv.CurrentRow.Cells[0].Value.ToString();
            var Carucode = dgv.SelectedCells[4].Value.ToString();
            var Caruno = dgv.SelectedCells[5].Value.ToString();
            var Pritername = cbxPrinter.SelectedItem.ToString();

            if (dgvAdminApproveBuyPart.SelectedRows.Count < 1)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกงาน");
                return;
            }

            if (MessageBox.Show("คุณต้องการอนุมัติสั่งซื้อพัสดุใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (FIX_TYPE_ID == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIX_TYPE_ID == uf._ขออนุมัติซื้อทดแทน)
                {
                    var status_fix = "";
                    //ลบข้อมูลเดิมใน Gridview ก่อน
                    var delete = "DELETE FROM COS_PART_ORDER WHERE JOB_ID=@JOB_ID";
                    SqlParameterCollection param_delete = new SqlCommand().Parameters;
                    param_delete.AddWithValue("@JOB_ID", SqlDbType.NVarChar).Value = JOB_ID;
                    var r = new DBClass().SqlExecute(delete, param_delete);

                    //บันทึกข้อมูลลงไปทั้งหมด
                    for (int k = 0; k < dgvStock.Rows.Count; k++)
                    {
                        var sql_order = "INSERT INTO COS_PART_ORDER (JOB_ID,PO_ID,PL_ID,PL_ID_C,SPL_ID,PO_QTY_REQUIRED,PO_ASSIGN_DATE)VALUES"
                                        + "(@JOB_ID,@PO_ID,@PL_ID,@PL_ID_C,@SPL_ID,@PO_QTY_REQUIRED,@PO_ASSIGN_DATE)";
                        SqlParameterCollection param_order = new SqlCommand().Parameters;
                        param_order.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = dgvStock.Rows[k].Cells[0].Value;
                        param_order.AddWithValue("@PO_ID", SqlDbType.Int).Value = dgvStock.Rows[k].Cells[1].Value;
                        param_order.AddWithValue("@PL_ID", SqlDbType.Int).Value = dgvStock.Rows[k].Cells[2].Value;
                        param_order.AddWithValue("@PL_ID_C", SqlDbType.Int).Value = dgvStock.Rows[k].Cells[3].Value;
                        param_order.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 3;
                        param_order.AddWithValue("@PO_QTY_REQUIRED", SqlDbType.Int).Value = dgvStock.Rows[k].Cells[5].Value;
                        param_order.AddWithValue("@PO_ASSIGN_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                        int i_ = new DBClass().SqlExecute(sql_order, param_order);
                    }

                    if (FIX_TYPE_ID == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ)
                    {
                        status_fix = sf._รอพัสดุรับรายการสั่งซื้อ;
                        
                    }
                    else if (FIX_TYPE_ID == uf._ขออนุมัติซื้อทดแทน)
                    {
                        status_fix = sf._รอหัวหน้าหน่วยงานอนุมัติสั่งซื้อทดแทน;
                    }
                    var sql_update = "UPDATE COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,SUB_BOSS_DATE=@SUB_BOSS_DATE where JOBID='" + JOB_ID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = status_fix;
                    param.AddWithValue("@SUB_BOSS_DATE", SqlDbType.NVarChar).Value = dc.GetDate();
                    int i = new DBClass().SqlExecute(sql_update, param);
                }
                else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนในประกัน)
                {
                    var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,SUB_BOSS_DATE=@SUB_BOSS_DATE where JOBID='" + JOB_ID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอหัวหน้าหน่วยงานอนุมัติส่งซ่อมเอกชนในประกัน;
                    param.AddWithValue("@SUB_BOSS_DATE", SqlDbType.NVarChar).Value = dc.GetDate();

                    int i = new DBClass().SqlExecute(sql_update, param);
                }
                else if (FIX_TYPE_ID == uf._ส่งซ่อมเอกชนนอกประกัน)
                {
                    var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,SUB_BOSS_DATE=@SUB_BOSS_DATE where JOBID='" + JOB_ID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอหัวหน้าหน่วยงานอนุมัติส่งซ่อมเอกชนนอกประกัน;
                    param.AddWithValue("@SUB_BOSS_DATE", SqlDbType.NVarChar).Value = dc.GetDate();

                    int i = new DBClass().SqlExecute(sql_update, param);
                }

                MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ////ปริ้นใบแจ้งซ่อม
                if (rdoPreview.Checked == true)
                {
                    PrintPreview(sqlReport(JOB_ID), Carucode, Caruno,JOB_ID);
                }
                else
                {
                    PrintNoPreview();
                }

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

                ShowAdminApproveBuyPart();
                ClearData();
            }
        }

        private void PrintNoPreview()
        {
            DataGridView dgv;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = dgvAdminApproveBuyPart;
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

        private string sqlReport(string _JOB_ID)
        {
            var _report = "SELECT DISTINCT NJ.JOBID,RTRIM(D.DEPNAME)AS DEPTNAME,"
                   + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, c2c.NAME AS CT_NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
                   + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + '' + ISNULL(PL_BRAND, '') + '' + ISNULL(PL_GEN, '') + '' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
                   + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
                   + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, NJ.MOTIVE,NJ.FIXED_DETAIL,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE,BD.name as BOSS_DEPT"
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
                   + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT" +
                   " LEFT JOIN COS_BOSS_DEPT BD ON BD.dept=NJ.DEPT"
                   + " CROSS JOIN COS_COS C"
                   + " where NJ.JOBID =  '" + _JOB_ID + "'";
            return _report;
        }

        private void PrintPreview(string _Report, string _Carucode, string _caruno,string _JOB_ID)
        {
            try
            {
                if (dgvAdminApproveBuyPart.SelectedRows.Count > 1)
                {
                }

                if (tabControl1.SelectedIndex == 0)
                {
                    var sql = "update COS_JOB set STATUS_FIX_ID=@STATUS_FIX_ID,BOSS_DATE=@BOSS_DATE"
                                    + " where JOB_ID = '" + _JOB_ID + "'";
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
                MessageBox.Show("ผิดพลาด " + ex.Message + "กรุณาปริ้น JOB " + _JOB_ID + "ใหม่อีกที!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            dgvStock.DataSource = null;
            cbxPART_NAME.SelectedIndex = -1;
            nud1.Value = 1;
            labelUNIT.Text = "";
            txtREF_PRICE.Text = "";
            txtTotal.Text = "";
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tb1)
            {
                ShowAdminApproveBuyPart();
            }
            else if (tabControl1.SelectedTab == tb2)
            {
                ShowPrintOld();
            }
            //else if (tabControl1.SelectedTab == tb3)
            //{
            //    ShowPrint();
            //}
        }

        private void ShowPrintOld()
        {
            if (cbx1.SelectedItem != null && cbx1.SelectedIndex >= 0)
            {
                REQ_DATE = "AND dbo.dmy(REQ_DATE) BETWEEN '" + dtp1_1.Value + "' AND '" + dtp1_2.Value + "'";
            }
            else
            {
                REQ_DATE = "";
                //DEPT = "";
            }

            var sql = "SELECT DISTINCT NJ.JOBID,FT.FT_NAME,RTRIM(MUHDEP.DEPNAME)AS DEPRNAME,c2c.NAME,NJ.CARUCODE,NJ.CARUNO,SPEC," +
                "CT.CAUSE_NAME,NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE, dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE, " +
            " COS_LEVEL_TYPE.LEVEL_NAME, U.U_NAME, NJ.STATUS_FIX_ID, FT_ID " +
            " FROM COS_JOB NJ " +
            " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID " +
            " LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE " +
            " LEFT JOIN [CARU2CODE] c2c ON c2c.CARUCODE=NJ.CARUCODE " +
            " LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO " +
            " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID " +
            " LEFT JOIN COS_FIXED_TYPE FT ON NJ.FIX_TYPE_ID = FT.FT_ID " +
            " LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID " +
            " LEFT JOIN COS_STATUS_FIXED SF ON NJ.STATUS_FIX_ID = SF.SF_ID " +
            " LEFT JOIN COS_USER U ON U.U_ID=NJ.[USER_ID] " +
            " WHERE NO='5' AND NJ.DEPT='" + User._U_DEPT + "'" + REQ_DATE; // AND NJ.FIXED_DATE IS NOT NULL";

            DataTable dt = new DBClass().SqlGetData(sql);
            var dgv = dgvPrintOld;
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
            dgv.Columns[13].HeaderText = "ความเร่งด่วน";
            dgv.Columns[14].HeaderText = "ช่างผู้รับผิดชอบ";
            dgv.Columns[15].HeaderText = "";

            dgv.Columns[0].Width = 110;
            dgv.Columns[1].Width = 170;
            dgv.Columns[2].Width = 130;
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].Width = 95;
            dgv.Columns[5].Width = 55;
            dgv.Columns[6].Width = 230;
            dgv.Columns[7].Width = 230;
            dgv.Columns[8].Width = 230;
            dgv.Columns[9].Width = 65;
            dgv.Columns[10].Width = 108;
            dgv.Columns[11].Width = 108;
            dgv.Columns[12].Width = 95;
            dgv.Columns[13].Width = 80;
            dgv.Columns[14].Width = 150;
            dgv.Columns[15].Width = 300;
            //dgv.Columns[15].Visible = false;
            //dgv.Columns[16].Visible = false;

            Dictionary<string, string> test = new Dictionary<string, string>();
            var cbx = cbx1;
            test.Add(dgv.Columns[12].Name, dgv.Columns[12].HeaderText);
            test.Add(dgv.Columns[3].Name, dgv.Columns[3].HeaderText);
            test.Add(dgv.Columns[4].Name, dgv.Columns[4].HeaderText);
            test.Add(dgv.Columns[10].Name, dgv.Columns[10].HeaderText);
            cbx.DataSource = new BindingSource(test, null);
            cbx.DisplayMember = "Value";
            cbx.ValueMember = "Key";
        }

        private void ShowPrint()
        {
            //var dgv = dgvShowPrint;
            ////try
            ////{
            //var sql = "SELECT DISTINCT NJ.JOBID,FT.FT_NAME,RTRIM(MUHDEP.DEPNAME)AS DEPRNAME,c2c.NAME,NJ.CARUCODE,NJ.CARUNO,SPEC," +
            //    "CT.CAUSE_NAME,NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE, dbo.dmy_hm(NJ.ASSIGN_DATE)AS ASSIGN_DATE," +
            //"dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE, COS_LEVEL_TYPE.LEVEL_NAME,NJ.STATUS_FIX_ID,FT_ID " +
            //"FROM COS_JOB NJ " +
            //"LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID " +
            //"LEFT JOIN MUHDEP ON NJ.DEPT_ID = MUHDEP.DEPCODE " +
            //"LEFT JOIN [CARU2CODE] c2c ON c2c.CARUCODE=NJ.CARUCODE " +
            //"LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO " +
            //"LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID " +
            //"LEFT JOIN COS_FIXED_TYPE FT ON NJ.FIX_TYPE_ID = FT.FT_ID " +
            //"LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID " +
            //"LEFT JOIN COS_STATUS_FIXED SF ON NJ.STATUS_FIX_ID = SF.SF_ID " +
            //"WHERE NO >5 AND NJ.SEND_DATE IS NULL";

            //DataTable dt = new DBClass().SqlGetData(sql);
            //dgv.DataSource = dt;

            //dgv.Columns[0].HeaderText = "JOB_ID";
            //dgv.Columns[1].HeaderText = "ประเภทซ่อม";
            //dgv.Columns[2].HeaderText = "หน่วยงาน";
            //dgv.Columns[3].HeaderText = "ประเภทครุภัณฑ์";
            //dgv.Columns[4].HeaderText = "เลขครุภัณฑ์";
            //dgv.Columns[5].HeaderText = "ตัวย่อ";
            //dgv.Columns[6].HeaderText = "สเปก";
            //dgv.Columns[7].HeaderText = "อาการเสีย";
            //dgv.Columns[8].HeaderText = "คำอธิบาย";
            //dgv.Columns[9].HeaderText = "ผู้แจ้ง";
            //dgv.Columns[10].HeaderText = "เบอร์โทร";
            //dgv.Columns[11].HeaderText = "วันที่แจ้ง";
            //dgv.Columns[12].HeaderText = "วันกำหนดเสร็จ";
            //dgv.Columns[13].HeaderText = "ผู้รับผิดชอบ";
            //dgv.Columns[14].HeaderText = "หมายเหตุประเภทการซ่อม";
            //dgv.Columns[15].HeaderText = "หมายเหตุประเภทการซ่อม";
            //dgv.Columns[16].HeaderText = "หมายเหตุประเภทการซ่อม";

            //dgv.Columns[0].Width = 120;
            //dgv.Columns[1].Width = 170;
            //dgv.Columns[2].Width = 130;
            //dgv.Columns[3].Width = 118;
            //dgv.Columns[4].Width = 100;
            //dgv.Columns[5].Width = 100;
            //dgv.Columns[6].Width = 120;
            //dgv.Columns[7].Width = 85;
            //dgv.Columns[8].Width = 65;
            //dgv.Columns[9].Width = 65;
            //dgv.Columns[10].Width = 108;
            //dgv.Columns[11].Width = 108;
            //dgv.Columns[12].Width = 119;
            //dgv.Columns[13].Width = 114;
            //dgv.Columns[14].Width = 114;
            //dgv.Columns[15].Visible = false;
            //dgv.Columns[16].Visible = false;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void ShowConfirmSupplies()
        {
            try
            {
                var sql = "SELECT DISTINCT"
                             + " NJ.JOBID, RTRIM(D.DEPNAME) AS DEPNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO, "
                             + " SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL, "
                             + " dbo.dmy_hm(NJ.REQ_DATE) AS REQ_DATE, dbo.dmy_hm(NJ.EXPECT_DATE) AS EXPECT_DATE, JW.JW_NAME, "
                             + " NJ.REMARK,PO.PO_NO,PO.INVOICE_NO"
                             + " FROM COS_JOB NJ"
                             + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                             + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                             + " LEFT JOIN CARU2CODE c2c ON NJ.CARUCODE = c2c.CARUCODE"
                             + " LEFT JOIN CARU2CARU c2 ON NJ.CARUCODE = c2.CARUCODE AND c2.CARUNO=NJ.CARUNO"
                             + " LEFT JOIN COS_JOB_WENT_TYPE JW ON NJ.JOB_WANT_ID = JW.JW_ID"
                             + " LEFT JOIN COS_PART_ORDER PO ON NJ.JOBID = PO.JOB_ID"
                             + " LEFT JOIN COS_USER U ON U.U_ID=PO.U_ID"
                             + " WHERE (NJ.STATUS_FIX_ID='3')"
                             + " AND NJ.DEPT='" + User._U_DEPT + "' AND NJ.HIDE IS NULL";
                var dt = new DBClass().SqlGetData(sql);
                var dgv = dgvAdminApproveBuyPart;
                dgv.DataSource = dt;
                dgv.Columns[0].HeaderText = "พัสดุ";
                dgv.Columns[1].HeaderText = "จำนวน";
                dgv.Columns[2].HeaderText = "หน่วย";
                dgv.Columns[3].HeaderText = "ราคาต่อชิ้น";
                dgv.Columns[4].HeaderText = "ราคารวม";
                dgv.Columns[5].HeaderText = "จำนวน";
                dgv.Columns[6].HeaderText = "หน่วย";
                dgv.Columns[7].HeaderText = "ราคาต่อชิ้น";
                dgv.Columns[8].HeaderText = "ราคารวม";
                dgv.Columns[0].Width = 80;
                dgv.Columns[1].Width = 75;
                dgv.Columns[2].Width = 95;
                dgv.Columns[3].Width = 95;
                dgv.Columns[4].Width = 95;
                dgv.Columns[5].Width = 75;
                dgv.Columns[6].Width = 95;
                dgv.Columns[7].Width = 95;
                dgv.Columns[8].Width = 95;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvConfirmSupplies_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dgvConfirmSupplies.ClearSelection();
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < PART_ID.Count; i++)
            //{
            //    if (PART_ID[i] != "" && JOB_ID[i] != "")
            //    {
            //if (dgvConfirmSupplies.CurrentRow.Cells[0].Value.ToString() != "")
            //{
            //    if (MessageBox.Show("คุณต้องการบันทึกรับสินค้าใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        var JOBID = dgvConfirmSupplies.CurrentRow.Cells[0].Value.ToString();
            //        var sql2 = "update COS_PART_ORDER set SPL_ID=@SPL_ID,PO_CONFIRM_DATE=@PO_CONFIRM_DATE"
            //                    + " where JOB_ID = '" + dgvConfirmSupplies.CurrentRow.Cells[0].Value.ToString() + "'";
            //        SqlParameterCollection param2 = new SqlCommand().Parameters;
            //        param2.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 8;
            //        param2.AddWithValue("@PO_CONFIRM_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
            //        int i = new DBClass().SqlExecute(sql2, param2);

            //        string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID where JOBID='" + JOBID + "'";
            //        SqlParameterCollection param = new SqlCommand().Parameters;
            //        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 5;
            //        int i2 = new DBClass().SqlExecute(sql_update, param);
            //    }

            //    ShowConfirmSupplies();
            //    ////ถ้า 6 ทุกตัว ให้อัพเดท STATUS_FIX_ID เป็น 6 อะไหล่ครบ
            //    //var sql1 = "SELECT SPL_ID FROM COS_PART_ORDER WHERE(JOB_ID = '" + JOB_ID[i] + "')";

            //    //var dt = new DBClass().SqlGetData(sql1);
            //    //int count = 0;
            //    //for (int ii = 0; ii < dt.Rows.Count; ii++)
            //    //{
            //    //    if ((int)dt.Rows[ii][0] == 6)
            //    //    {
            //    //        count = count + 1;
            //    //    }
            //    //}
            //    //if (count == dt.Rows.Count)
            //    //{
            //    //}
            //}

            //    }
            //}
            PART_ID.Clear();
        }

        private void dgvConfirmSupplies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)         //ถ้าไม่มีแถวจะไม่เกิดอะไรขึ้น
            {
                return;
            }
        }

        private void dgvConfirmSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvConfirmSupplies_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
        }

        private void fmAdminApproveBuyPart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ShowAdminApproveBuyPart();
                ShowConfirmSupplies();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerStock f = new ManagerStock();
            f.Show();
        }

        private void cbxPART_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
        }

        private void Cal()
        {
            try
            {
                if (nud1.Value == 0)
                {
                    txtTotal.Text = "";
                }
                else
                {
                    txtTotal.Text = (Convert.ToDouble(nud1.Value) * Convert.ToDouble(txtREF_PRICE.Text)).ToString("0.00");
                }
            }
            catch
            {
            }
        }

        private void dgvAdminApproveBuyPart_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = dgvAdminApproveBuyPart;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                FIX_TYPE_ID = Convert.ToString(row.Cells[16].Value);
                if (FIX_TYPE_ID == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 208, 208);
                }
                else if (FIX_TYPE_ID == "3")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 208, 255);
                }
                else if (FIX_TYPE_ID == "4")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(208, 250, 255);
                }
                else if (FIX_TYPE_ID == "5")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(208, 255, 222);
                }
                else if (FIX_TYPE_ID == "6")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 253, 208);
                }
            }
        }

        private void ctmJOB_Click(object sender, EventArgs e)
        {
            var tabControl = tabControl1;
            if (tabControl.SelectedTab == tb1)
            {
                //var collum = 2;
                //fmEditJOB fm = new fmEditJOB(dgv1.SelectedCells[collum].Value.ToString());
                //fm.ShowDialog();
            }
            //else if (tabControl.SelectedTab == tb2)
            //{
            //    //var collum = 0;
            //    //fmEditJOB fm = new fmEditJOB(dgvMain.SelectedCells[collum].Value.ToString());
            //    //fm.ShowDialog();
            //}
        }

        #region Printer Name

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

        #endregion

        private void dgvPrintOld_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPrintOld.ClearSelection();
        }

        private void cbxPrinterOld_DropDown(object sender, EventArgs e)
        {
            dc.cbxPrinterDropDown(cbxPrinterOld);
        }

        private void cbxPrinterOld_DropDownClosed(object sender, EventArgs e)
        {
            dc.cbxPrinter_DropDownClosed(cbxPrinterOld);
        }

        private void cbxPrinterOld_TextChanged(object sender, EventArgs e)
        {
            dc.cbxPrinter_DropDownClosed(cbxPrinterOld);
        }

        private void button7_Click(object sender, EventArgs e)
        {          
            ShowPrintOld();
        }

        private void cbxPrinterOld_MouseClick(object sender, MouseEventArgs e)
        {
            dc.cbxPrinter_MouseClick(cbxPrinterOld);

        }

        private void btnPrintOld_Click(object sender, EventArgs e)
        {
            var dgv = dgvPrintOld;
            JOBID = dgv.SelectedCells[0].Value.ToString();
            Carucode = dgv.SelectedCells[4].Value.ToString();
            Caruno = dgv.SelectedCells[5].Value.ToString();
            Pritername = cbxPrinterOld.SelectedItem.ToString();

            pr.noPreview(JOBID, Carucode, Caruno, Pritername);
        }

        private void dgvPrintOld_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            
           
        }
    }
}