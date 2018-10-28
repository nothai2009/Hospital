using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmAdminApproveUsePart : Form
    {
        public fmAdminApproveUsePart()
        {
            InitializeComponent();
        }

        private void fmAdminApproveUsePart_Load(object sender, EventArgs e)
        {
            ShowAdminApproveUsePart();
            gbStock.Enabled = false;
            btnSave.Enabled = false;
        }

        private void ShowAdminApproveUsePart()
        {
            //try
            //{
            string sql = "SELECT DISTINCT"
                     + " COS_JOB.JOBID, RTRIM(COS_NEW_DEPT.deptname) AS DEPRNAME, COS_NEW_CARU_TYPE.CT_NAME, COS_JOB.CARUCODE, COS_JOB.CARUNO,"
                     + " COS_JOB.SPEC, COS_CAUSE_TYPE.CAUSE_NAME, COS_JOB.DESC_, COS_JOB.OWNER, COS_JOB.TEL,"
                     + " dbo.dmy_hm(COS_JOB.REQ_DATE) AS REQ_DATE, dbo.dmy_hm(COS_JOB.ASSIGN_DATE) AS ASSIGN_DATE, dbo.dmy(COS_JOB.EXPECT_DATE) AS EXPECT_DATE,"
                     + " COS_LEVEL_TYPE.LEVEL_NAME, COS_FIXED_TYPE.FT_NAME"
                     + " FROM            COS_JOB INNER JOIN"
                     + " COS_CAUSE_TYPE ON COS_JOB.CAUSE_ID = COS_CAUSE_TYPE.CAUSE_ID INNER JOIN"
                     + " COS_NEW_DEPT ON COS_JOB.DEPT_ID = CARU2_COS_NEW_DEPT.DEPT INNER JOIN"
                     + " COS_NEW_CARU_TYPE ON COS_JOB.CARUCODE = CARU2_COS_NEW_CARU_TYPE.CT_ID INNER JOIN"
                     + " COS_LEVEL_TYPE ON COS_JOB.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID INNER JOIN"
                     + " COS_FIXED_TYPE ON COS_JOB.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID INNER JOIN"
                     + " COS_PART_COM ON COS_JOB.JOBID = COS_PART_COM.JOB_ID CROSS JOIN"
                     + " COS_JOB_WENT_TYPE CROSS JOIN"
                     + " COS_STATUS_FIXED"
                     + " WHERE(COS_JOB.STATUS_FIX_ID = 4) AND(COS_PART_COM.SPL_ID = 1)";

            DataTable dt = new DBClass().SqlGetData(sql);
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "JOB_ID";
            dgvMain.Columns[1].HeaderText = "เลขครุภัณฑ์";
            dgvMain.Columns[2].HeaderText = "ตัวย่อ";
            dgvMain.Columns[3].HeaderText = "ประเภท";
            dgvMain.Columns[4].HeaderText = "หน่วยงาน";
            dgvMain.Columns[5].HeaderText = "สเปก";
            dgvMain.Columns[6].HeaderText = "อาการเสีย";
            dgvMain.Columns[7].HeaderText = "คำอธิบาย";
            dgvMain.Columns[8].HeaderText = "ผู้แจ้ง";
            dgvMain.Columns[9].HeaderText = "เบอร์โทร";
            dgvMain.Columns[10].HeaderText = "วันที่แจ้ง";
            dgvMain.Columns[11].HeaderText = "วันกำหนดเสร็จ";
            dgvMain.Columns[12].HeaderText = "ผู้รับผิดชอบ";
            dgvMain.Columns[13].HeaderText = "หมายเหตุ";
            dgvMain.Columns[14].HeaderText = "ประเภทการซ่อม";

            dgvMain.Columns[0].Width = 100;
            dgvMain.Columns[1].Width = 85;
            dgvMain.Columns[2].Width = 44;
            dgvMain.Columns[3].Width = 118;
            dgvMain.Columns[4].Width = 100;
            dgvMain.Columns[5].Width = 100;
            dgvMain.Columns[6].Width = 120;
            dgvMain.Columns[7].Width = 85;
            dgvMain.Columns[8].Width = 65;
            dgvMain.Columns[9].Width = 65;
            dgvMain.Columns[10].Width = 108;
            dgvMain.Columns[11].Width = 108;
            dgvMain.Columns[12].Width = 119;
            dgvMain.Columns[13].Width = 114;
            dgvMain.Columns[14].Width = 114;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
        }

        private string JOB_New, JOB_Now;

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            JOB_New = (string)dgvMain.SelectedCells[0].Value;

            if (JOB_Now == JOB_New)
            {
                JOB_New = "";
                JOB_Now = "";
                dgvMain.ClearSelection();
                dgvStock.DataSource = null;
            }
            else
            {
                JOB_Now = JOB_New;
                gbStock.Enabled = true;
                ShowStock();

                dgvMain.Rows[dgvMain.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvMain.Rows[dgvMain.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private int PART_ID_MAX;

        private void cbxPART_NAME_Click(object sender, EventArgs e)
        {
            //try
            //{
            var strcbxPART_NAME = "SELECT [ST_ID],[ST_NAME],[ST_UNIT] FROM [UHDATA].[dbo].[COS_STOCK] ORDER BY ST_NAME ASC";
            DataTable dt1 = new DBClass().SqlGetData(strcbxPART_NAME);
            cbxPART_NAME.DataSource = dt1;
            cbxPART_NAME.ValueMember = "ST_ID";
            cbxPART_NAME.DisplayMember = "ST_NAME";

            labelUNIT.Text = dt1.Rows[0][2].ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DBClass.tr.Rollback();
            //}
            //cbxPART_NAME.ItemHeight = 20;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxPART_NAME.Text != "")
            {
                try
                {
                    DataTable dt = dgvStock.DataSource as DataTable;
                    dt.Rows.Add(JOB_Now, PART_ID_MAX.ToString(), cbxPART_NAME.Text, nud1.Value.ToString(), labelUNIT.Text);
                    dgvStock.DataSource = dt;
                    dgvStock.ClearSelection();
                    PART_ID_MAX++;
                    PART_ID_NOW = "";
                    ClearStock();
                }
                catch
                {
                }
            }
        }

        private void ClearStock()
        {
            cbxPART_NAME.SelectedIndex = -1;
            nud1.Value = 1;
            labelUNIT.Text = "";
        }

        private string PART_ID_NOW, PART_ID_NEW;

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
            dgvStock.DataSource = null;
            ClearStock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (JOB_Now == "")
            {
                MessageBox.Show("คุณยังไม่ได้เลือกงาน");
                return;
            }

            for (int k = 0; k < dgvStock.Rows.Count; k++)
            {
                var sql = "SELECT [ST_IN] FROM [COS_STOCK] WHERE ST_NAME='" + dgvStock.Rows[k].Cells[2].Value.ToString() + "'";
                DataTable dt1 = new DBClass().SqlGetData(sql);
                var qty = dt1.Rows[0]["ST_IN"].ToString();
                if (Convert.ToInt32(dgvStock.Rows[k].Cells[3].Value) < Convert.ToInt32(qty))
                {
                    if (dgvStock.Rows.Count - 1 == k)
                    {
                        Console.WriteLine("");
                        if (MessageBox.Show("คุณต้องการอนุมัติสั่งซื้ออะไหล่ใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //ลบข้อมูลเดิมใน Gridview ก่อน
                            for (int i = 0; i < dgvStock.Rows.Count; i++)
                            {
                                var delete = "delete from COS_PART_COM where JOB_ID=@JOB_ID";
                                SqlParameterCollection param_delete = new SqlCommand().Parameters;
                                param_delete.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = JOB_Now;
                                var r = new DBClass().SqlExecute(delete, param_delete);
                            }

                            //บันทึกข้อมูลลงไปทั้งหมด
                            for (int k2 = 0; k2 < dgvStock.Rows.Count; k2++)
                            {
                                var sql_order = "INSERT INTO COS_PART_COM (JOB_ID,PC_ID,SPL_ID,PC_NAME,PC_QTY_REQUIRED,PC_QTY_RECEIVED,PC_UNIT,PC_ASSIGN_DATE)VALUES"
                                                + "(@JOB_ID,@PC_ID,@SPL_ID,@PC_NAME,@PC_QTY_REQUIRED,@PC_QTY_RECEIVED,@PC_UNIT,@PC_ASSIGN_DATE)";
                                SqlParameterCollection param_order = new SqlCommand().Parameters;
                                param_order.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = dgvStock.Rows[k2].Cells[0].Value;
                                param_order.AddWithValue("@PC_ID", SqlDbType.Int).Value = dgvStock.Rows[k2].Cells[1].Value;
                                param_order.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 2;
                                param_order.AddWithValue("@PC_NAME", SqlDbType.VarChar).Value = dgvStock.Rows[k2].Cells[2].Value;
                                param_order.AddWithValue("@PC_QTY_REQUIRED", SqlDbType.Int).Value = dgvStock.Rows[k2].Cells[3].Value;
                                param_order.AddWithValue("@PC_QTY_RECEIVED", SqlDbType.Int).Value = dgvStock.Rows[k2].Cells[3].Value;
                                param_order.AddWithValue("@PC_UNIT", SqlDbType.VarChar).Value = dgvStock.Rows[k2].Cells[4].Value;
                                param_order.AddWithValue("@PC_ASSIGN_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");

                                int i_order = new DBClass().SqlExecute(sql_order, param_order);
                            }

                            //บันทึกข้อมูลลงไปทั้งหมด
                            for (int k2 = 0; k2 < dgvStock.Rows.Count; k2++)
                            {
                                var sql2 = "SELECT [ST_IN] FROM [COS_STOCK] WHERE ST_NAME='" + dgvStock.Rows[k2].Cells[2].Value.ToString() + "'";
                                DataTable dt2 = new DBClass().SqlGetData(sql2);
                                var qty2 = dt2.Rows[0]["ST_IN"].ToString();

                                string sql_update = "update COS_STOCK SET ST_IN=@ST_IN where ST_NAME='" + dgvStock.Rows[k2].Cells[2].Value.ToString() + "'";
                                SqlParameterCollection param = new SqlCommand().Parameters;
                                param.AddWithValue("@ST_IN", SqlDbType.Int).Value = Convert.ToInt32(qty2) - Convert.ToInt32(dgvStock.Rows[k2].Cells[3].Value); //จำนวนที่ใช้
                                int i2 = new DBClass().SqlExecute(sql_update, param);
                            }

                            MessageBox.Show("รับงานเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //ถ้า 6 ทุกตัว ให้อัพเดท STATUS_FIX_ID เป็น 2 อะไหล่ครบ
                            var sql1 = "SELECT SPL_ID FROM COS_PART_COM WHERE(JOB_ID = '" + JOB_Now + "')";

                            var dt = new DBClass().SqlGetData(sql1);
                            Console.WriteLine("start");
                            int count = 0;
                            for (int ii = 0; ii < dt.Rows.Count; ii++)
                            {
                                Console.WriteLine(dt.Rows[ii][0]);
                                if ((int)dt.Rows[ii][0] == 2)
                                {
                                    count = count + 1;
                                }
                            }
                            if (count == dt.Rows.Count)
                            {
                                Console.WriteLine("บันทึก");
                                string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID where JOBID='" + JOB_Now + "'";

                                SqlParameterCollection param = new SqlCommand().Parameters;
                                param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 5;
                                int i2 = new DBClass().SqlExecute(sql_update, param);
                            }
                        }
                        ShowAdminApproveUsePart();
                        dgvStock.DataSource = null;
                    }
                }
                else
                {
                    //อะไหล่ไม่พอ
                    MessageBox.Show(dgvStock.Rows[k].Cells[2].Value.ToString() + " ยังคงเหลืออีก " + (Convert.ToInt32(dgvStock.Rows[k].Cells[3].Value) - Convert.ToInt32(qty)).ToString(), "จำนวนอะไหล่ในสต๊อกไม่พอ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dgvStock.Rows.Count - 1 == k)
                    {
                        return;
                    }
                }
            }
        }

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMain.ClearSelection();
        }

        private void dgvMain_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
        }

        private void dgvStock_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            cbxPART_NAME.Text = (dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString());
            nud1.Value = Convert.ToDecimal(dgvStock.Rows[e.RowIndex].Cells[3].Value);
            labelUNIT.Text = dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow.Selected == true)
            {
                //try
                //{
                DataTable dt = dgvStock.DataSource as DataTable;
                dt.Rows.RemoveAt(dgvStock.Rows[dgvStock.CurrentRow.Index].Index);
                dt.Rows.Add(JOB_Now, PART_ID_MAX.ToString(), cbxPART_NAME.Text, nud1.Value.ToString(), labelUNIT.Text);
                dgvStock.DataSource = dt;
                dgvStock.ClearSelection();
                PART_ID_MAX++;
                PART_ID_NOW = "";
                ClearStock();
                //}
                //catch
                //{
                //}
            }
        }

        private void fmAdminApproveUsePart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ShowAdminApproveUsePart();
            }
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            PART_ID_NEW = dgvStock.SelectedCells[1].Value.ToString();

            if (PART_ID_NOW == PART_ID_NEW)
            {
                PART_ID_NEW = "";
                PART_ID_NOW = "";
                dgvStock.ClearSelection();
            }
            else
            {
                PART_ID_NOW = PART_ID_NEW;
                dgvStock.Rows[dgvStock.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvStock.Rows[dgvStock.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
            PART_ID_NOW = PART_ID_NEW;
        }

        private void ShowStock()
        {
            string sql_PART_ORDER = "SELECT [JOB_ID],[PC_ID],[PC_NAME],[PC_QTY_REQUIRED],[PC_UNIT] FROM [UHDATA].[dbo].[COS_PART_COM] WHERE JOB_ID='" + JOB_Now + "'";

            DataTable dt = new DBClass().SqlGetData(sql_PART_ORDER);

            var sql = "SELECT MAX(po.PC_ID) FROM COS_JOB as nj join COS_PART_COM as po on po.JOB_ID = nj.JOBID where nj.JOBID = '" + JOB_Now + "'";
            PART_ID_MAX = new DBClass().AutoNunber(sql);

            dgvStock.DataSource = dt;
            dgvStock.Columns[0].HeaderText = "JOB_ID";
            dgvStock.Columns[1].HeaderText = "PC_ID";
            dgvStock.Columns[2].HeaderText = "ชื่ออะไหล่";
            dgvStock.Columns[3].HeaderText = "จำนวนที่ต้องการ";
            dgvStock.Columns[4].HeaderText = "หน่วย";

            dgvStock.Columns[0].Width = 130;
            dgvStock.Columns[1].Width = 60;
            dgvStock.Columns[2].Width = 150;
            dgvStock.Columns[3].Width = 80;
            dgvStock.Columns[4].Width = 80;
            dgvStock.ClearSelection();
        }
    }
}