using COS;
using Saraff.Twain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmGetWork : Form
    {
        private User.FIXED_TYPE uf = new User.FIXED_TYPE();
        private User.STATUS_FIXED sf = new User.STATUS_FIXED();
        private User u = new User();
        private bool _isEnable = false;
        private int PL_ID_C = 0;
        private int PART_STOCK = 1;
        private int rowIndex = 0;
        private double tmpNetTotal;

        public fmGetWork()
        {
            InitializeComponent();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            dgvStock.Rows.Clear();
            ClearStock();
        }

        #region ColumnAdded

        private void dgvFinishFix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvFinishFix);
        }

        private void dgvFinishFix_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFinishFix.ClearSelection();
        }

        private void dgvMain_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvMain);
        }

        private void dgvStock_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvStock);
        }

        private void dgvHisFix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvHisFix);
        }

        private void dgv1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgv1);
        }

        private void dgvReceive_ColumnAdded_1(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvReceive);
        }

        private void dgvFollows_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvFollows);
        }

        private void dgvHistoryFix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            u.formatGridView(dgvHistoryFix);
        }

        #endregion ColumnAdded

        #region DataBindingComplete

        private void dgvHisFix_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvHisFix.ClearSelection();
        }

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMain.ClearSelection();
        }

        private void dgvHistoryFix_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvHistoryFix.ClearSelection();
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private void dgvReceive_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReceive.ClearSelection();
        }

        private void dgvFollows_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFollows.ClearSelection();
        }

        #endregion DataBindingComplete

        private void cbxPART_NAME_Click(object sender, EventArgs e)
        {
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();
            if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ)
            {
            }
            else if (FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน)
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
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        lt.Add(Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private List<int> lt = new List<int>();

        private void cbxPART_NAME_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();

            if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ)
            {
            }
            //else if (FIXED_TYPE == "ซ่อมเองโดยใช้วัสดุในสต๊อก")
            //{
            //    try
            //    {
            //        string sql = "select ST_UNIT,ST_IN from COS_STOCK where ST_NAME = '" + cbxPART_NAME.Text + "'";
            //        var dt = new DBClass().SqlGetData(sql);
            //        labelUNIT.Text = dt.Rows[0]["ST_UNIT"].ToString();
            //        nud1.Maximum = (int)dt.Rows[0]["ST_IN"];
            //        txtREF_PRICE.Text = "";
            //        txtTotal.Text = "";
            //        nud1.Value = 1;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
            else if (FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน)
            {
                //try
                //{
                PL_ID_C = lt[cbxPART_NAME.SelectedIndex];
                var sql = "select U.ST_NAME,PL.PL_PRICE from COS_PART_LIST P"
                            + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                            + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                            + " WHERE(P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N') AND(P.PL_ID = '" + cbxPART_NAME.SelectedValue + "' AND PL_ID_C = '" + PL_ID_C + "')";
                DataTable dt = new DBClass().SqlGetData(sql);
                labelUNIT.Text = dt.Rows[0]["ST_NAME"].ToString();
                txtREF_PRICE.Text = dt.Rows[0]["PL_PRICE"].ToString();
                nud1.Value = 1;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var JOBID = dgvMain.CurrentRow.Cells[0].Value.ToString();
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();

            if (FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน)
            {
                dgvStock.ColumnCount = 8;
                string[] row = new string[] { JOBID, PART_STOCK.ToString(), cbxPART_NAME.SelectedValue.ToString(), PL_ID_C.ToString(), cbxPART_NAME.Text, nud1.Value.ToString(), labelUNIT.Text, txtREF_PRICE.Text, txtTotal.Text };
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

        private void ClearStock()
        {
            nud1.Value = 1;
            txtREF_PRICE.Clear();
            labelUNIT.Text = "";
            txtTotal.Clear();
            cbxPART_NAME.SelectedIndex = -1;
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

        private void nud1_ValueChanged(object sender, EventArgs e)
        {
            Cal();
        }

        private List<string> PART_ID = new List<string>();

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(dgvStock.SelectedRows != dgvStock.SelectedRows)
            //{
            //}
            //    foreach (DataGridViewRow item in this.dgvStock.SelectedRows)
            //    {
            //        dgvStock.Rows.RemoveAt(item.Index);
            //    }
            var w = dgvStock.SelectedRows;
        }

        private void cbxCARU2_COS_FIXED_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();

            if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ || FIXED_TYPE == uf._ส่งซ่อมเอกชนนอกประกัน)
            {
                gbStock.Visible = false;
                groupBox1.Visible = false;
            }
            else if (FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ)
            {
                groupBox1.Visible = false;
                gbStock.Visible = true;
                gbStock.Enabled = true;
            }
            else if (FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน)
            {
                groupBox1.Visible = false;
                gbStock.Visible = true;
                gbStock.Enabled = true;
            }
            else if (FIXED_TYPE == uf._ส่งซ่อมเอกชนในประกัน)
            {
                if (dgvMain.CurrentRow.Cells[3].Value.ToString() != "")
                {
                    gbStock.Visible = false;
                    groupBox1.Visible = true;

                    //ดึงข้อมล วันที่รับประกัน,บริษัทที่รับประกัน,ระยะเวลาประกันที่เหลือ
                    var sql = "SELECT dbo.dmySlash(DATEIN)AS [DATEIN],[WARRANTY]"
                            + " ,dbo.dmySlash(DATEADD(YEAR, (CAST(WARRANTY AS int)), DATEIN)) AS[ENDWARRANTY]"
                            + " ,(DATEDIFF(DAY, GETDATE(), (DATEADD(YEAR, (CAST(ISNULL(WARRANTY,1) AS int)), DATEIN))))AS D"
                            + " , CASE WHEN DATEADD(YEAR,3, DATEIN)< GETDATE() THEN '0' WHEN DATEADD(YEAR,3, DATEIN)> GETDATE() THEN '1' ELSE '3' END AS[WARRANTYTEXT]"
                            + " ,[COMPANY]FROM[CARU2CARU]WHERE CARUCODE = '" + (string)dgvMain.SelectedCells[3].Value + "' AND CARUNO = '" + (string)dgvMain.SelectedCells[4].Value + "'";
                    var dt = new DBClass().SqlGetData(sql);
                    txtDATEIN.Text = dt.Rows[0]["DATEIN"].ToString();
                    nudWARRANTY.Text = dt.Rows[0]["WARRANTY"].ToString();
                    txtD.Text = dt.Rows[0]["D"].ToString();
                    txtCOMPANY.Text = dt.Rows[0]["COMPANY"].ToString();
                    txtENDWARRANTY.Text = dt.Rows[0]["ENDWARRANTY"].ToString();

                    if (Convert.ToInt32(dt.Rows[0]["D"].ToString()) > 1)
                    {
                        txtDATEIN.BackColor = Color.Green;
                    }
                    else if (dt.Rows[0]["WARRANTY"].ToString() == "")
                    {
                        txtDATEIN.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt32(dt.Rows[0]["D"].ToString()) < 0)
                    {
                        txtDATEIN.BackColor = Color.Red;
                    }
                }
            }
        }

        private void dgvHisFix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (dgvReceive.SelectedRows.Count == 0)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกงาน");
                return;
            }
            if (MessageBox.Show("คุณต้องการบันทึกส่งเครื่องคืนใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectedRows = dgvReceive.SelectedRows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow).ToArray();

                for (int i = 0; i < dgvReceive.SelectedRows.Count; i++)
                {
                    try
                    {
                        string sql_update = "update COS_JOB SET SEND_DATE=@SEND_DATE,STATUS_FIX_ID=@STATUS_FIX_ID,RECEIVE_BY=@RECEIVE_BY where JOBID='" + selectedRows[i].Cells[0].Value + "'";

                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@SEND_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 7;
                        param.AddWithValue("@RECEIVE_BY", SqlDbType.NVarChar).Value = txtRECEIVE_BY.Text;
                        int i2 = new DBClass().SqlExecute(sql_update, param);
                        if (dgvReceive.SelectedRows.Count - 1 == i)
                        {
                            MessageBox.Show("บันทึกส่งเครื่องคืนเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowDataReceive();
                            txtRECEIVE_BY.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("บันทึกส่งเครื่องคืนไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            btnReceive.Enabled = false;
        }

        private void cbxCARU2_COS_FIXED_TYPE_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count < 1)
            {
                MessageBox.Show("กรุณาเลือก JOB งานก่อนเลือกวิธีซ่อมด้วยครับ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbxPART_NAME.DataSource = null;
            txtREF_PRICE.Text = "";
            txtTotal.Text = "";
            dgvStock.Rows.Clear();
            try
            {
                string sql = "select * from COS_FIXED_TYPE WHERE HIDE='N' order by[FT_NAME] desc";
                var dt = new DBClass().SqlGetData(sql);
                cbxCARU2_COS_FIXED_TYPE.DataSource = dt;
                cbxCARU2_COS_FIXED_TYPE.DisplayMember = "FT_NAME";
                cbxCARU2_COS_FIXED_TYPE.ValueMember = "FT_ID";
                cbxCARU2_COS_FIXED_TYPE.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSaveHowFixed_Click(object sender, EventArgs e)
        {
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();
            var JOBID = dgvMain.CurrentRow.Cells[0].Value.ToString();

            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกงาน");
                return;
            }

            if (MessageBox.Show("คุณต้องการบันทึกวิธีการส่งซ่อมใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ)
                {
                    #region ซ่อมเองโดยไม่ใช้วัสดุ | ขออนุมัติจ้างเอกชน
                    try
                    {
                        if (chkFinish.Checked == true)
                        {
                            string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE,FINISH_DATE=@FINISH_DATE,SEND_DATE=@SEND_DATE where JOBID='" + JOBID + "'";

                            SqlParameterCollection param = new SqlCommand().Parameters;
                            param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._ซ่อมเสร็จ;
                            param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                            param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                            param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                            param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                            param.AddWithValue("@FINISH_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                            param.AddWithValue("@SEND_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                            int i2 = new DBClass().SqlExecute(sql_update, param);
                            MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE where JOBID='" + JOBID + "'";

                            SqlParameterCollection param = new SqlCommand().Parameters;
                            param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 5;
                            param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                            param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                            param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                            param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                            int i2 = new DBClass().SqlExecute(sql_update, param);
                            MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    #endregion ซ่อมเองโดยไม่ใช้วัสดุ | ขออนุมัติจ้างเอกชน
                }
                else if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ)
                {
                    #region ซ่อมเองโดยใช้วัสดุในสต๊อก
                    try
                    {
                        //PART_COM
                        for (int j = 0; j < dgvStock.Rows.Count; j++)
                        {
                            var sql_order = "INSERT INTO COS_PART_COM (JOB_ID,PC_ID,SPL_ID,PC_NAME,PC_QTY_REQUIRED,PC_QTY_RECEIVED,PC_UNIT)VALUES"
                                            + "(@JOB_ID,@PC_ID,@SPL_ID,@PC_NAME,@PC_QTY_REQUIRED,@PC_QTY_RECEIVED,@PC_UNIT)";
                            SqlParameterCollection param_order = new SqlCommand().Parameters;
                            param_order.AddWithValue("@JOB_ID", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[0].Value;
                            param_order.AddWithValue("@PC_ID", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[1].Value;
                            param_order.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 1;
                            param_order.AddWithValue("@PC_NAME", SqlDbType.NVarChar).Value = dgvStock.Rows[j].Cells[2].Value;
                            param_order.AddWithValue("@PC_QTY_REQUIRED", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[3].Value;
                            param_order.AddWithValue("@PC_QTY_RECEIVED", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[3].Value;
                            param_order.AddWithValue("@PC_UNIT", SqlDbType.VarChar).Value = dgvStock.Rows[j].Cells[4].Value;
                            int i_order = new DBClass().SqlExecute(sql_order, param_order);
                        }
                        string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE"
                   + " where JOBID='" + JOBID + "'";
                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 4;
                        param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                        param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                        param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                        param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                        int i = new DBClass().SqlExecute(sql_update, param);
                        MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("try again" + ex);
                    }
                    #endregion ซ่อมเองโดยใช้วัสดุในสต๊อก
                }
                else if (FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน || FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ)
                {
                    if (FIXED_TYPE == "ขออนุมัติซื้อทดแทน")
                    {
                        #region ซื้อทดแทน
                        string PL_ID = "";
                        if (dgvMain.CurrentRow.Cells[2].Value.ToString() == "เครื่องสำรองไฟ (UPS)")
                        {
                            PL_ID = "65";
                        }
                        else if (dgvMain.CurrentRow.Cells[2].Value.ToString() == "เครื่องคอมพิวเตอร์(PC)")
                        {
                            PL_ID = "64";
                        }
                        else if (dgvMain.CurrentRow.Cells[2].Value.ToString() == "เครื่องคอมพิวเตอร์(PC)")
                        {
                            PL_ID = "70";
                        }

                        var PO_ID = "1";                //1 ลำดับที่ 1 ของคอมพิวเตอร์
                        var PL_ID_C = "1";              //1 ลำดับที่ 1 ของคอมพิวเตอร์
                        var SPL_ID = "1";               //1 รอหัวหน้าช่างอนุมัติ
                        var PO_QTY_REQUIRED = "1";      //จำนวน

                        var sql_order = "INSERT INTO COS_PART_ORDER (JOB_ID,PO_ID,PL_ID,PL_ID_C,SPL_ID,PO_QTY_REQUIRED)VALUES"
                                            + "(@JOB_ID,@PO_ID,@PL_ID,@PL_ID_C,@SPL_ID,@PO_QTY_REQUIRED)";
                        SqlParameterCollection param_order = new SqlCommand().Parameters;
                        param_order.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = JOBID;
                        param_order.AddWithValue("@PO_ID", SqlDbType.Int).Value = PO_ID;
                        param_order.AddWithValue("@PL_ID", SqlDbType.Int).Value = PL_ID;
                        param_order.AddWithValue("@PL_ID_C", SqlDbType.Int).Value = PL_ID_C;
                        param_order.AddWithValue("@SPL_ID", SqlDbType.Int).Value = SPL_ID;
                        param_order.AddWithValue("@PO_QTY_REQUIRED", SqlDbType.Int).Value = PO_QTY_REQUIRED;
                        int i_order = new DBClass().SqlExecute(sql_order, param_order);
                        #endregion ซื้อทดแทน
                    }
                    else
                    {
                        #region ซ่อมเองโดยขออนุมัติซื้อวัสดุ
                        //PART_ORDER
                        for (int j = 0; j < dgvStock.Rows.Count; j++)
                        {
                            var sql_order = "INSERT INTO COS_PART_ORDER (JOB_ID,PO_ID,PL_ID,PL_ID_C,SPL_ID,PO_QTY_REQUIRED)VALUES"
                                            + "(@JOB_ID,@PO_ID,@PL_ID,@PL_ID_C,@SPL_ID,@PO_QTY_REQUIRED)";
                            SqlParameterCollection param_order = new SqlCommand().Parameters;
                            param_order.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = dgvStock.Rows[j].Cells[0].Value;
                            param_order.AddWithValue("@PO_ID", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[1].Value;
                            param_order.AddWithValue("@PL_ID", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[2].Value;
                            param_order.AddWithValue("@PL_ID_C", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[3].Value;
                            param_order.AddWithValue("@SPL_ID", SqlDbType.Int).Value = 1;
                            param_order.AddWithValue("@PO_QTY_REQUIRED", SqlDbType.Int).Value = dgvStock.Rows[j].Cells[5].Value;
                            int i_order = new DBClass().SqlExecute(sql_order, param_order);
                        }
                        #endregion ซ่อมเองโดยขออนุมัติซื้อวัสดุ
                    }

                    try
                    {
                        string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE"
                    + " where JOBID='" + JOBID + "'";
                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอหัวหน้าช่างอนุมัติสั่งซื้อพัสดุ;
                        param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                        param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                        param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                        param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                        int i = new DBClass().SqlExecute(sql_update, param);
                        MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (FIXED_TYPE == uf._ส่งซ่อมเอกชนในประกัน)
                {
                    #region
                    var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE"
                    + " where JOBID='" + JOBID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอหัวหน้าช่างอนุมัติส่งซ่อมเอกชนในประกัน;
                    param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                    param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                    param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                    param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    int i = new DBClass().SqlExecute(sql_update, param);
                    MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion
                }
                else if (FIXED_TYPE == uf._ส่งซ่อมเอกชนนอกประกัน)
                {
                    #region
                    var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,MOTIVE=@MOTIVE,FIXED_DETAIL=@FIXED_DETAIL,FIX_TYPE_ID=@FIX_TYPE_ID,FIXED_DATE=@FIXED_DATE"
                    + " where JOBID='" + JOBID + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอหัวหน้าช่างอนุมัติส่งซ่อมเอกชนนอกประกัน;
                    param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                    param.AddWithValue("@FIXED_DETAIL", SqlDbType.VarChar).Value = txtFIXED_DETAIL.Text;
                    param.AddWithValue("@FIX_TYPE_ID", SqlDbType.Int).Value = cbxCARU2_COS_FIXED_TYPE.SelectedValue;
                    param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    int i = new DBClass().SqlExecute(sql_update, param);
                    MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion
                }

                if (chkFinish.Checked == true)
                {
                    string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID, FIXED_DATE=@FIXED_DATE, FINISH_DATE=@FINISH_DATE, SEND_DATE=@SEND_DATE where JOBID='" + JOBID + "'";

                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._ซ่อมเสร็จ;
                    param.AddWithValue("@FIXED_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@FINISH_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@SEND_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    int i2 = new DBClass().SqlExecute(sql_update, param);
                    MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #region Clear
                cbxCARU2_COS_FIXED_TYPE.SelectedIndex = -1;
                txtMOTIVE.Text = "";
                txtFIXED_DETAIL.Text = "";

                ClearStock();
                dgvStock.Rows.Clear();
                ShowDataHowToRepair();
                #endregion

                if (FIXED_TYPE == uf._ซ่อมเองโดยไม่ใช้วัสดุ)
                {
                    tabControl2.SelectedTab = tP3;
                    ShowDataFinishFix();
                }
            }
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tPmain)
            {
                //เลือกวิธีการซ่อม
                Showdgv1();
                cbx1.SelectedIndex = -1;
            }
            else if (tabControl2.SelectedTab == tP2)
            {
                //เลือกวิธีการซ่อม
                ShowDataHowToRepair();
            }
            else if (tabControl2.SelectedTab == tP3)
            {
                //บันทึกซ่อมเสร็จ
                ShowDataFinishFix();
            }
            else if (tabControl2.SelectedTab == tP4)
            {
                //บันทึกส่งคืน
                ShowDataReceive();
            }
            else if (tabControl2.SelectedTab == tP5)
            {
                //รอพัสดุ
                ShowDataFollow();
            }
            else if (tabControl2.SelectedTab == tP6)
            {
                //ประวัติการซ่อม
                ShowDataHistoryFix();
            }
            else if (tabControl2.SelectedTab == tabPage2)
            {
                //รออนุมัติสั่งซื้อ
                ShowData2();
            }
        }

        private void ShowData2()
        {
            //try
            //{
            var sql = "select PO.JOB_ID,RTRIM(D.DEPNAME)AS DEPTNAME,US.U_NAME,SPL.SPL_NAME,"
                        + " ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART,"
                        + " PO.PO_QTY_REQUIRED,PO.PO_QTY_RECEIVED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE,"
                        + " dbo.dmy_hm(PO_ASSIGN_DATE)AS PO_ASSIGN_DATE,dbo.dmy(PO_EXPECT_DATE)AS PO_EXPECT_DATE, dbo.dmy_hm(PO_GET_DATE)AS PO_GET_DATE"
                        + " from COS_PART_LIST P"
                        + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                        + " LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C"
                        + " LEFT JOIN COS_JOB NJ ON NJ.JOBID = PO.JOB_ID"
                        + " LEFT JOIN MUHDEP D ON D.DEPCODE = NJ.DEPT_ID"
                        + " LEFT JOIN COS_USER US ON US.U_ID = PO.U_ID"
                        + " LEFT JOIN COS_STATUS_PART_LIST SPL ON SPL.SPL_ID = PO.SPL_ID"
                        + " LEFT JOIN COS_USER U2 ON U2.U_ID = NJ.USER_ID"
                        + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N' AND PO.SPL_ID = '1'"
                         + " AND NJ.USER_ID='" + User._U_ID + "'"
                        + " GROUP BY PO.JOB_ID,D.DEPNAME,US.U_NAME,SPL.SPL_NAME,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,"
                        + " PO.PO_QTY_REQUIRED,PO.PO_QTY_RECEIVED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED, PL.PL_PRICE,"
                        + " PO_ASSIGN_DATE,PO_EXPECT_DATE, PO_GET_DATE,U2.U_NAME,NJ.USER_ID,PO.SPL_ID"
                        + " ORDER BY PO.SPL_ID ASC, PO_ASSIGN_DATE DESC";
            var dt = new DBClass().SqlGetData(sql);
            var dgv = dgv2;

            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "JOB_ID";
            dgv.Columns[1].HeaderText = "หน่วยงาน";
            dgv.Columns[2].HeaderText = "พัสดุผู้รับผิดชอบ";
            dgv.Columns[3].HeaderText = "สถานะพัสดุ";
            dgv.Columns[4].HeaderText = "รายการพัสดุ";
            dgv.Columns[5].HeaderText = "ต้องการ";
            dgv.Columns[6].HeaderText = "ค้างรับ";
            dgv.Columns[7].HeaderText = "หน่วย";
            dgv.Columns[8].HeaderText = "ราคาต่อหน่วย";
            dgv.Columns[9].HeaderText = "ราคารวม";
            dgv.Columns[10].HeaderText = "วันที่อนุมัติซื้อ";
            dgv.Columns[11].HeaderText = "กำหนดส่งมอบ";
            dgv.Columns[12].HeaderText = "วันที่รับของ";

            dgv.Columns[0].Width = 115;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 170;
            dgv.Columns[3].Width = 137;
            dgv.Columns[4].Width = 260;
            dgv.Columns[5].Width = 60;
            dgv.Columns[6].Width = 60;
            dgv.Columns[7].Width = 60;
            dgv.Columns[8].Width = 60;
            dgv.Columns[9].Width = 70;
            dgv.Columns[10].Width = 108;
            dgv.Columns[11].Width = 80;
            dgv.Columns[12].Width = 100;
            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void Showdgv1()
        {
            var REQ_DATE = "";
            var DEPT = "";

            if (cbx1.SelectedItem != null && cbx1.SelectedIndex >= 0)
            {
                REQ_DATE = "AND dbo.dmy(REQ_DATE) BETWEEN '" + dtp1_1.Value + "' AND '" + dtp1_2.Value + "'";
            }
            else if (cbx1.SelectedIndex == 1)
            {
                DEPT = "AND DEPT_ID='" + comboBox1.SelectedValue + "'";
            }
            else
            {
                REQ_DATE = "";
                DEPT = "";
            }

            var sql = "SELECT SF.SF_NAME,"
                + " CASE WHEN  NJ.CARUCODE ='' THEN '0'"
                + " ELSE(select COUNT([CARUCODE]) as CARUCODE from COS_JOB where STATUS_FIX_ID = '7' AND CARUCODE = NJ.CARUCODE AND CARUNO = NJ.CARUNO) END AS COUNT_FIX, "
                + " NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE,"
                + " dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE, JW.JW_NAME"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN [CARU2CODE] c2c ON NJ.CARUCODE = c2c.CARUCODE"
                + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                + " LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO"
                + " LEFT JOIN COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID"
                + " LEFT JOIN COS_STATUS_FIXED SF ON SF.SF_ID = NJ.STATUS_FIX_ID"
                + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
                + " WHERE (NJ.STATUS_FIX_ID BETWEEN '2' AND '6') " + REQ_DATE + DEPT
                + " AND NJ.USER_ID='" + User._U_ID + "'"
                + " GROUP BY SF.SF_NAME,NJ.CARUCODE,NJ.CARUNO,JOBID,DEPNAME,NAME,SPEC,CAUSE_NAME,DESC_,OWNER,TEl,EXPECT_DATE,REQ_DATE,JW_NAME,SF_ID,U_NAME"
                + " ORDER BY SF_ID ASC,NJ.REQ_DATE DESC";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "สถานะงาน";
            dgv1.Columns[1].HeaderText = "ซ่อมไปแล้ว";
            dgv1.Columns[2].HeaderText = "JOB_ID";
            dgv1.Columns[3].HeaderText = "หน่วยงาน";
            dgv1.Columns[4].HeaderText = "ประเภทครุภัณฑ์";
            dgv1.Columns[5].HeaderText = "ครุภัณฑ์	";
            dgv1.Columns[6].HeaderText = "ตัวย่อ";
            dgv1.Columns[7].HeaderText = "สเปก";
            dgv1.Columns[8].HeaderText = "อาการ";
            dgv1.Columns[9].HeaderText = "สาเหตุ";
            dgv1.Columns[10].HeaderText = "ผู้แจ้ง";
            dgv1.Columns[11].HeaderText = "เบอร์โทร";
            dgv1.Columns[12].HeaderText = "วันที่แจ้งซ่อม";
            dgv1.Columns[13].HeaderText = "กำหนดเสร็จ";
            dgv1.Columns[14].HeaderText = "ต้องการ";

            dgv1.Columns[0].Width = 130;
            dgv1.Columns[1].Width = 40;
            dgv1.Columns[2].Width = 100;
            dgv1.Columns[3].Width = 135;
            dgv1.Columns[4].Width = 160;
            dgv1.Columns[5].Width = 93;
            dgv1.Columns[6].Width = 50;
            dgv1.Columns[7].Width = 300;
            dgv1.Columns[8].Width = 150;
            dgv1.Columns[9].Width = 300;
            dgv1.Columns[10].Width = 75;
            dgv1.Columns[11].Width = 75;
            dgv1.Columns[12].Width = 105;
            dgv1.Columns[13].Width = 80;
            dgv1.Columns[14].Width = 70;

            Dictionary<string, string> test = new Dictionary<string, string>();
            var dgv = dgv1;
            var cbx = cbx1;
            test.Add(dgv.Columns[12].Name, dgv.Columns[12].HeaderText);
            test.Add(dgv.Columns[3].Name, dgv.Columns[3].HeaderText);
            test.Add(dgv.Columns[4].Name, dgv.Columns[4].HeaderText);
            test.Add(dgv.Columns[10].Name, dgv.Columns[10].HeaderText);
            cbx.DataSource = new BindingSource(test, null);
            cbx.DisplayMember = "Value";
            cbx.ValueMember = "Key";
        }

        //เลือกวิธีการซ่อม
        private void ShowDataHowToRepair()
        {
            //try
            //{
            string sql = "SELECT NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,"
            + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE,"
            + " dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE, JW.JW_NAME"
            + " FROM COS_JOB NJ"
            + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
            + " LEFT JOIN [CARU2CODE] c2c ON NJ.CARUCODE = c2c.CARUCODE"
            + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
            + " LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO"
            + " LEFT JOIN COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID"
            + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
            + " WHERE(NJ.STATUS_FIX_ID = 3) AND NJ.FIXED_DATE IS NULL"
             + " AND NJ.USER_ID='" + User._U_ID + "'"
            + " GROUP BY NJ.JOBID,D.DEPNAME,c2c.NAME, NJ.CARUCODE, NJ.CARUNO,SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,NJ.REQ_DATE, NJ.EXPECT_DATE, JW.JW_NAME,U.U_NAME"
            + " ORDER BY NJ.REQ_DATE DESC";                       /*มอบหมายงาน*/

            DataTable dt = new DBClass().SqlGetData(sql);
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "JOB_ID";
            dgvMain.Columns[1].HeaderText = "หน่วยงาน";
            dgvMain.Columns[2].HeaderText = "ประเภทครุภัณฑ์";
            dgvMain.Columns[3].HeaderText = "ครุภัณฑ์	";
            dgvMain.Columns[4].HeaderText = "ตัวย่อ";
            dgvMain.Columns[5].HeaderText = "สเปก";
            dgvMain.Columns[6].HeaderText = "อาการ";
            dgvMain.Columns[7].HeaderText = "สาเหตุ";
            dgvMain.Columns[8].HeaderText = "ผู้แจ้ง";
            dgvMain.Columns[9].HeaderText = "เบอร์โทร";
            dgvMain.Columns[10].HeaderText = "วันที่แจ้งซ่อม";
            dgvMain.Columns[11].HeaderText = "กำหนดเสร็จ";
            dgvMain.Columns[12].HeaderText = "ต้องการ";

            dgvMain.Columns[0].Width = 107;
            dgvMain.Columns[1].Width = 120;
            dgvMain.Columns[2].Width = 130;
            dgvMain.Columns[3].Width = 88;
            dgvMain.Columns[4].Width = 43;
            dgvMain.Columns[5].Width = 190;
            dgvMain.Columns[6].Width = 110;
            dgvMain.Columns[7].Width = 120;
            dgvMain.Columns[8].Width = 75;
            dgvMain.Columns[9].Width = 75;
            dgvMain.Columns[10].Width = 105;
            dgvMain.Columns[11].Width = 77;
            dgvMain.Columns[12].Width = 70;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        //บันทึกซ่อมเสร็จ
        private void ShowDataFinishFix()
        {
            try
            {
                string sql = "SELECT NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE,"
                + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE,dbo.dmy(NJ.FIXED_DATE)AS FIXED_DATE,NJ.MOTIVE,NJ.FIXED_DETAIL,JW.JW_NAME"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN CARU2CODE c2 ON NJ.CARUCODE = c2.CARUCODE"
                + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                + " LEFT JOIN COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID"
                + " LEFT JOIN CARU2CARU c2c ON NJ.CARUCODE = c2c.CARUCODE AND NJ.CARUNO=c2c.CARUNO"
                + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID " +
                " LEFT JOIN COS_PART_ORDER PO WITH(NOLOCK)ON PO.JOB_ID=NJ.JOBID"
                + " WHERE STATUS_FIX_ID = 20 AND SPL_ID='4' AND PO.PO_QTY_REQUIRED = PO.PO_QTY_RECEIVED"
                 //+ " AND NJ.USER_ID='" + User._U_ID + "'"
                + " GROUP BY NJ.JOBID,D.DEPNAME,NAME, NJ.CARUCODE, NJ.CARUNO,SPEC, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,NJ.REQ_DATE, NJ.EXPECT_DATE, JW.JW_NAME,U.U_NAME,NJ.FIXED_DATE,NJ.MOTIVE,NJ.FIXED_DETAIL"
                + " ORDER BY NJ.REQ_DATE DESC";                       /*มอบหมายงาน*/

                var dt = new DBClass().SqlGetData(sql);
                dgvFinishFix.DataSource = dt;
                dgvFinishFix.Columns[0].HeaderText = "JOB_ID";
                dgvFinishFix.Columns[1].HeaderText = "หน่วยงาน";
                dgvFinishFix.Columns[2].HeaderText = "ประเภทครุภัณฑ์";
                dgvFinishFix.Columns[3].HeaderText = "ครุภัณฑ์	";
                dgvFinishFix.Columns[4].HeaderText = "ตัวย่อ";
                dgvFinishFix.Columns[5].HeaderText = "สเปก";
                dgvFinishFix.Columns[6].HeaderText = "อาการ";
                dgvFinishFix.Columns[7].HeaderText = "สาเหตุ";
                dgvFinishFix.Columns[8].HeaderText = "ผู้แจ้ง";
                dgvFinishFix.Columns[9].HeaderText = "เบอร์โทร";
                dgvFinishFix.Columns[10].HeaderText = "วันที่แจ้งซ่อม";
                dgvFinishFix.Columns[11].HeaderText = "กำหนดเสร็จ";
                dgvFinishFix.Columns[12].HeaderText = "ซ่อมเสร็จ";
                dgvFinishFix.Columns[13].HeaderText = "วิธีการแก้ไข";
                dgvFinishFix.Columns[14].HeaderText = "สาเหตุ";
                dgvFinishFix.Columns[15].HeaderText = "ต้องการ";

                dgvFinishFix.Columns[0].Width = 105;
                dgvFinishFix.Columns[1].Width = 70;
                dgvFinishFix.Columns[2].Width = 140;
                dgvFinishFix.Columns[3].Width = 85;
                dgvFinishFix.Columns[4].Width = 49;
                dgvFinishFix.Columns[5].Width = 190;
                dgvFinishFix.Columns[6].Width = 95;
                dgvFinishFix.Columns[7].Width = 90;
                dgvFinishFix.Columns[8].Width = 75;
                dgvFinishFix.Columns[9].Width = 75;
                dgvFinishFix.Columns[10].Width = 75;
                dgvFinishFix.Columns[11].Width = 105;
                dgvFinishFix.Columns[12].Width = 75;
                dgvFinishFix.Columns[13].Width = 70;
                dgvFinishFix.Columns[14].Width = 110;
                dgvFinishFix.Columns[15].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //ประวัติการซ่อมเสร็จ
        private void ShowDataHistoryFix()
        {
            try
            {
                string sql = "SELECT NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE,"
                + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE,dbo.dmy(NJ.FIXED_DATE)AS FIXED_DATE,dbo.dmy(NJ.FINISH_DATE)AS FINISH_DATE,NJ.MOTIVE,NJ.FIXED_DETAIL,JW.JW_NAME"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN CARU2CODE c2 ON NJ.CARUCODE = c2.CARUCODE"
                + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                + " LEFT JOIN CARU2CARU c2c ON NJ.CARUCODE = c2c.CARUCODE AND NJ.CARUNO=c2c.CARUNO "
                + " LEFT JOIN COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID"
                + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
                + " WHERE(NJ.STATUS_FIX_ID = 7)"
                 + " AND NJ.USER_ID='" + User._U_ID + "'"
                + " ORDER BY NJ.REQ_DATE DESC";                       /*ประวัติการซ่อม*/

                var dt = new DBClass().SqlGetData(sql);
                dgvHistoryFix.DataSource = dt;
                dgvHistoryFix.Columns[0].HeaderText = "JOB_ID";
                dgvHistoryFix.Columns[1].HeaderText = "หน่วยงาน";
                dgvHistoryFix.Columns[2].HeaderText = "ประเภทครุภัณฑ์";
                dgvHistoryFix.Columns[3].HeaderText = "ครุภัณฑ์";
                dgvHistoryFix.Columns[4].HeaderText = "ตัวย่อ";
                dgvHistoryFix.Columns[5].HeaderText = "สเปก";
                dgvHistoryFix.Columns[6].HeaderText = "อาการ";
                dgvHistoryFix.Columns[7].HeaderText = "สาเหตุ";
                dgvHistoryFix.Columns[8].HeaderText = "ผู้แจ้ง";
                dgvHistoryFix.Columns[9].HeaderText = "เบอร์โทร";
                dgvHistoryFix.Columns[10].HeaderText = "วันที่แจ้งซ่อม";
                dgvHistoryFix.Columns[11].HeaderText = "กำหนดเสร็จ";
                dgvHistoryFix.Columns[12].HeaderText = "วันที่ซ่อม";
                dgvHistoryFix.Columns[13].HeaderText = "ซ่อมเสร็จ";
                dgvHistoryFix.Columns[14].HeaderText = "สาเหตุ";
                dgvHistoryFix.Columns[15].HeaderText = "วิธีการแก้ไข";
                dgvHistoryFix.Columns[16].HeaderText = "ต้องการ";

                dgvHistoryFix.Columns[0].Width = 109;
                dgvHistoryFix.Columns[1].Width = 70;
                dgvHistoryFix.Columns[2].Width = 110;
                dgvHistoryFix.Columns[3].Width = 88;
                dgvHistoryFix.Columns[4].Width = 50;
                dgvHistoryFix.Columns[5].Width = 190;
                dgvHistoryFix.Columns[6].Width = 95;
                dgvHistoryFix.Columns[7].Width = 90;
                dgvHistoryFix.Columns[8].Width = 75;
                dgvHistoryFix.Columns[9].Width = 75;
                dgvHistoryFix.Columns[10].Width = 105;
                dgvHistoryFix.Columns[11].Width = 77;
                dgvHistoryFix.Columns[12].Width = 77;
                dgvHistoryFix.Columns[13].Width = 70;
                dgvHistoryFix.Columns[14].Width = 110;
                dgvHistoryFix.Columns[15].Width = 110;
                dgvHistoryFix.Columns[16].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //รอพัสดุ
        private void ShowDataFollow()
        {
            //try
            //{
            var sql = "select PO.JOB_ID,RTRIM(D.DEPNAME)AS DEPTNAME,SPL.SPL_NAME,"
                        + " ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART,"
                        + " PO.PO_QTY_REQUIRED,PO.PO_QTY_RECEIVED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE,"
                        + " dbo.dmy_hm(PO_ASSIGN_DATE)AS PO_ASSIGN_DATE,dbo.dmy(PO_EXPECT_DATE)AS PO_EXPECT_DATE, dbo.dmy_hm(PO_GET_DATE)AS PO_GET_DATE"
                        + " from COS_PART_LIST P"
                        + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                        + " LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C"
                        + " LEFT JOIN COS_JOB NJ ON NJ.JOBID = PO.JOB_ID"
                        + " LEFT JOIN MUHDEP D ON D.DEPCODE = NJ.DEPT_ID"
                        + " LEFT JOIN COS_USER US ON US.U_ID = PO.U_ID"
                        + " LEFT JOIN COS_STATUS_PART_LIST SPL ON SPL.SPL_ID = PO.SPL_ID"
                        + " LEFT JOIN COS_USER U2 ON U2.U_ID = NJ.USER_ID"
                        + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND P.HIDE = 'N' AND PO.SPL_ID <> '6'"
                         + " AND NJ.USER_ID='" + User._U_ID + "'"
                        + " GROUP BY PO.JOB_ID,D.DEPNAME,US.U_NAME,SPL.SPL_NAME,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,"
                        + " PO.PO_QTY_REQUIRED,PO.PO_QTY_RECEIVED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED, PL.PL_PRICE,"
                        + " PO_ASSIGN_DATE,PO_EXPECT_DATE, PO_GET_DATE,U2.U_NAME,NJ.USER_ID,PO.SPL_ID"
                        + " ORDER BY PO.SPL_ID ASC, PO_ASSIGN_DATE DESC";
            var dt = new DBClass().SqlGetData(sql);
            var dgv = dgvFollows;
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "JOB_ID";
            dgv.Columns[1].HeaderText = "หน่วยงาน";
            //dgv.Columns[2].HeaderText = "พัสดุผู้รับผิดชอบ";
            dgv.Columns[2].HeaderText = "สถานะพัสดุ";
            dgv.Columns[3].HeaderText = "รายการพัสดุ";
            dgv.Columns[4].HeaderText = "ต้องการ";
            dgv.Columns[5].HeaderText = "ค้างรับ";
            dgv.Columns[6].HeaderText = "หน่วย";
            dgv.Columns[7].HeaderText = "ราคาต่อหน่วย";
            dgv.Columns[8].HeaderText = "ราคารวม";
            dgv.Columns[9].HeaderText = "วันที่อนุมัติซื้อ";
            dgv.Columns[10].HeaderText = "กำหนดส่งมอบ";
            dgv.Columns[11].HeaderText = "วันที่รับของ";

            dgv.Columns[0].Width = 115;
            dgv.Columns[1].Width = 150;
            //dgv.Columns[2].Width = 170;
            dgv.Columns[2].Width = 137;
            dgv.Columns[3].Width = 260;
            dgv.Columns[4].Width = 60;
            dgv.Columns[5].Width = 60;
            dgv.Columns[6].Width = 60;
            dgv.Columns[7].Width = 60;
            dgv.Columns[8].Width = 70;
            dgv.Columns[9].Width = 108;
            dgv.Columns[10].Width = 80;
            dgv.Columns[11].Width = 100;
            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void dgvFollows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //if ((e.Value != null) && (e.ColumnIndex == 4))
            //{
            //    if (Convert.ToString(e.Value) == "รอส่งมอบอะไหล่ให้ช่าง" || Convert.ToString(e.Value) == "รอพัสดุรับรายการสั่งซื้อ")
            //    {
            //        if ((e.Value != null) && (e.ColumnIndex == 11))
            //        {
            //            if (Convert.ToDateTime(e.Value) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
            //            {
            //                e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
            //            }
            //            else
            //            {
            //                e.CellStyle.BackColor = Color.White;
            //            }
            //        }
            //    }
            //}
            try
            {
                //if (dgvFollows.Rows[e.RowIndex].Cells[11].Value != null)
                //{
                //    var date1 = Convert.ToDateTime(dgvFollows.Rows[e.RowIndex].Cells[11].Value);
                //    if (date1 <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                //    {
                //        e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
                //    }
                //    else
                //    {
                //        e.CellStyle.BackColor = Color.White;
                //    }
                //}
            }
            catch (Exception)
            {
                //throw;
            }

            //if ((dgvFollows.Rows[e.RowIndex].Cells[10].Value != null) && dgvFollows.Rows[e.RowIndex].Cells[11].Value != null)
            //{
            //    var date1 = Convert.ToDateTime(dgvFollows.Rows[e.RowIndex].Cells[10].Value);
            //    var date2 = Convert.ToDateTime(dgvFollows.Rows[e.RowIndex].Cells[11].Value);
            //    if (date1 <= date2)
            //    {
            //        e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
            //    }
            //    else
            //    {
            //        e.CellStyle.BackColor = Color.White;
            //    }
            //}
            //}
            //catch
            //{
            //}
        }

        //บันทึกส่งเครื่องกลับ
        private void ShowDataReceive()
        {
            try
            {
                string sql = "SELECT NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,"
                + " CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,dbo.dmy(NJ.EXPECT_DATE)AS EXPECT_DATE,"
                + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE,dbo.dmy(NJ.FIXED_DATE)AS FIXED_DATE,dbo.dmy(NJ.FINISH_DATE)AS FINISH_DATE,NJ.MOTIVE,NJ.FIXED_DETAIL,JW.JW_NAME"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN CARU2CODE c2 ON NJ.CARUCODE = c2.CARUCODE"
                + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                + " LEFT JOIN COS_JOB_WENT_TYPE JW ON JW.JW_ID = NJ.JOB_WANT_ID"
                + " LEFT JOIN CARU2CARU c2c ON NJ.CARUCODE = c2c.CARUCODE AND NJ.CARUNO=c2c.CARUNO"
                + " LEFT JOIN COS_USER U ON U.U_ID=NJ.USER_ID"
                + " WHERE(NJ.STATUS_FIX_ID = 6)"
                 //+ " AND NJ.USER_ID='" + User._U_ID + "'"
                + " GROUP BY NJ.JOBID, D.DEPNAME, NAME, NJ.CARUCODE, NJ.CARUNO,SPEC,CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,NJ.EXPECT_DATE,"
                + " NJ.REQ_DATE,NJ.FIXED_DATE,NJ.FINISH_DATE,NJ.MOTIVE,NJ.FIXED_DETAIL,JW.JW_NAME,NJ.USER_ID,U.U_NAME"
                + " ORDER BY NJ.REQ_DATE DESC";

                var dt = new DBClass().SqlGetData(sql);
                dgvReceive.DataSource = dt;
                dgvReceive.Columns[0].HeaderText = "JOB_ID";
                dgvReceive.Columns[1].HeaderText = "หน่วยงาน";
                dgvReceive.Columns[2].HeaderText = "ประเภทครุภัณฑ์";
                dgvReceive.Columns[3].HeaderText = "ครุภัณฑ์";
                dgvReceive.Columns[4].HeaderText = "ตัวย่อ";
                dgvReceive.Columns[5].HeaderText = "สเปก";
                dgvReceive.Columns[6].HeaderText = "อาการ";
                dgvReceive.Columns[7].HeaderText = "สาเหตุ";
                dgvReceive.Columns[8].HeaderText = "ผู้แจ้ง";
                dgvReceive.Columns[9].HeaderText = "เบอร์โทร";
                dgvReceive.Columns[10].HeaderText = "วันที่แจ้งซ่อม";
                dgvReceive.Columns[11].HeaderText = "กำหนดเสร็จ";
                dgvReceive.Columns[12].HeaderText = "ซ่อมเสร็จ";
                dgvReceive.Columns[13].HeaderText = "ต้องการ";
                dgvReceive.Columns[14].HeaderText = "สาเหตุ";
                dgvReceive.Columns[15].HeaderText = "วิธีการแก้ไข";

                dgvReceive.Columns[0].Width = 109;
                dgvReceive.Columns[1].Width = 70;
                dgvReceive.Columns[2].Width = 110;
                dgvReceive.Columns[3].Width = 88;
                dgvReceive.Columns[4].Width = 50;
                dgvReceive.Columns[5].Width = 190;
                dgvReceive.Columns[6].Width = 95;
                dgvReceive.Columns[7].Width = 90;
                dgvReceive.Columns[8].Width = 75;
                dgvReceive.Columns[9].Width = 75;
                dgvReceive.Columns[10].Width = 105;
                dgvReceive.Columns[11].Width = 77;
                dgvReceive.Columns[12].Width = 77;
                dgvReceive.Columns[13].Width = 70;
                dgvReceive.Columns[14].Width = 110;
                dgvReceive.Columns[15].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvFinishFix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFinishFix.SelectedRows.Count > 0)
            {
                btnFinishFix.Enabled = true;
            }
            else
            {
                btnFinishFix.Enabled = false;
            }
        }

        private void btnFinishFix_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการบันทึกซ่อมเสร็จใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectedRows = dgvFinishFix.SelectedRows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow).ToArray();

                for (int i = 0; i < dgvFinishFix.SelectedRows.Count; i++)
                {
                    try
                    {
                        var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,FINISH_DATE=@FINISH_DATE where JOBID='" + selectedRows[i].Cells[0].Value + "'";

                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 6;
                        param.AddWithValue("@FINISH_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");    //วันที่รับงาน
                        int i2 = new DBClass().SqlExecute(sql_update, param);
                        if (dgvFinishFix.SelectedRows.Count - 1 == i)
                        {
                            MessageBox.Show("บันทึกซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //tabControl2.SelectedTab = tP4;
                            ShowDataReceive();
                            ShowDataFinishFix();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("รับงาน " + selectedRows[i].Cells[0].Value + " ไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //DBClass.tr.Rollback();
                    }
                    //    }
                    //}
                }
            }
            btnFinishFix.Enabled = false;
        }

        private void fmGetWork_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //{
            //    ShowDataGetWork();
            //    ShowDataHowToRepair();
            //    ShowDataFinishFix();
            //    ShowDataReceive();
            //    ShowDataFollow();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการปิดงานโดยไม่ใช้วัสดุ ใช่หรือไม่?", "ปิดงานด่วน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                User._JOB_Now = dgv1.CurrentRow.Cells[2].Value.ToString();
                fmFastJob f = new fmFastJob();
                f.ShowDialog();
                Showdgv1();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgv1.SelectedCells[0].Value.ToString() == "รอช่างรับงาน")
            {
                btnJobFast.Enabled = true;
            }
            else
            {
                btnJobFast.Enabled = false;
            }

            if (dgv1.SelectedCells[1].Value.ToString() != "0")
            {
                btnViewHis.Enabled = true;
            }
            else
            {
                btnViewHis.Enabled = false;
            }
        }

        private void btnViewHis_Click(object sender, EventArgs e)
        {
            fmHis f = new fmHis(dgv1.CurrentRow.Cells[5].Value.ToString(), dgv1.CurrentRow.Cells[6].Value.ToString());
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Cells[0].Value.ToString() == "กำลังดำเนินการซ่อม")
            {
                tabControl2.SelectedTab = tP2;
                ShowDataHowToRepair();
                return;
            }
            else if (dgv1.CurrentRow.Cells[0].Value.ToString() == "รออะไหล่")
            {
                tabControl2.SelectedTab = tP5;
                ShowDataFollow();
                return;
            }
            else if (dgv1.CurrentRow.Cells[0].Value.ToString() == "รอบันทึกซ่อมเสร็จ")
            {
                tabControl2.SelectedTab = tP3;
                ShowDataFinishFix();
                return;
            }
            else if (dgv1.CurrentRow.Cells[0].Value.ToString() == "ซ่อมเสร็จ")
            {
                tabControl2.SelectedTab = tP4;
                ShowDataReceive();
                return;
            }
            else if (dgv1.CurrentRow.Cells[0].Value.ToString() == "รออนุมัติซั่งซื้ออะไหล่")
            {
                return;
            }
            if (MessageBox.Show("คุณต้องการรับงานใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgv1.CurrentRow.Cells[0].Value.ToString() == "รอช่างรับงาน")
                {
                    string sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,ACCEPT_DATE=@ACCEPT_DATE where JOBID='" + dgv1.CurrentRow.Cells[2].Value.ToString() + "'";

                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = 3;
                    param.AddWithValue("@ACCEPT_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");    //วันที่รับงาน
                    int i2 = new DBClass().SqlExecute(sql_update, param);
                    MessageBox.Show("รับงานเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataHowToRepair();
                }
                else if (dgv1.CurrentRow.Cells[15].Value.ToString() == "3")
                {
                    tabControl2.SelectedTab = tP3;
                }
                else if (dgv1.CurrentRow.Cells[15].Value.ToString() == "5")
                {
                    tabControl2.SelectedTab = tP5;
                }
                else if (dgv1.CurrentRow.Cells[15].Value.ToString() == "6")
                {
                    tabControl2.SelectedTab = tP6;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var FIXED_TYPE = cbxCARU2_COS_FIXED_TYPE.SelectedValue.ToString();
            if (FIXED_TYPE == uf._ซ่อมเองโดยขออนุมัติซื้อพัสดุ || FIXED_TYPE == uf._ขออนุมัติซื้อทดแทน)
            {
                ManagerStock f = new ManagerStock();
                f.Show();
            }
        }

        private void _twain_AcquireError(object sender, Twain32.AcquireErrorEventArgs e)
        {
            MessageBox.Show("Error");
        }

        private void _twain_TwainStateChanged(object sender, Twain32.TwainStateEventArgs e)
        {
            try
            {
                if ((e.TwainState & Twain32.TwainStateFlag.DSEnabled) == 0 && this._isEnable)
                {
                    this._isEnable = false;
                    // <<< scaning finished (or closed)
                }
                this._isEnable = (e.TwainState & Twain32.TwainStateFlag.DSEnabled) != 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAMPLE1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count < 1)
            {
                return;
            }
            else
            {
                fmAddDocument f = new fmAddDocument(dgvMain.SelectedCells[0].Value.ToString());
                f.ShowDialog();
            }
        }

        private void dgvReceive_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReceive.SelectedRows.Count > 0)
            {
                btnReceive.Enabled = true;
            }
            else
            {
                btnReceive.Enabled = false;
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxCARU2_COS_FIXED_TYPE.SelectedIndex = -1;
            cbxPART_NAME.SelectedIndex = -1;
            groupBox1.Visible = false;
            gbStock.Visible = true;

            if (dgvMain.SelectedRows.Count > 0)
            {
                btnAdddoccument.Enabled = true;
                btnSaveHowFixed.Enabled = true;
            }
            else
            {
                btnAdddoccument.Enabled = false;
                btnSaveHowFixed.Enabled = false;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx1.SelectedIndex == 1)
                {
                    var cbx = comboBox1;
                    string sql = "SELECT  DEPCODE ,DEPNAME ,HIDE " +
                        "FROM MUHDEP " +
                        "WHERE DEPTYPE<>'H' " +
                        "ORDER BY DEPNAME ";
                    var dt = new DBClass().SqlGetData(sql);
                    cbx.DataSource = dt;
                    cbx.DisplayMember = "DEPNAME";
                    cbx.ValueMember = "DEPCODE";
                    cbx.SelectedIndex = -1;
                }
                else if (cbx1.SelectedIndex == 2)
                {
                    var cbx = comboBox1;
                    string sql = "SELECT [CARUCODE]AS CT_ID,[CARUCODE]+' '+[NAME] AS CARU"
                                + " FROM [CARU2CODE]"
                                + " ORDER BY NAME ASC";
                    var dt = new DBClass().SqlGetData(sql);
                    cbx.DataSource = dt;
                    cbx.DisplayMember = "CARU";
                    cbx.ValueMember = "CT_ID";
                    cbx.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fmGetWork_Load(object sender, EventArgs e)
        {
            Showdgv1();
            gbStock.Enabled = false;
            cbx1.SelectedIndex = -1;
        }

        private void dtp1_1_ValueChanged(object sender, EventArgs e)
        {
            Showdgv1();
        }

        private void dtp1_2_ValueChanged(object sender, EventArgs e)
        {
            Showdgv1();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Showdgv1();
            cbx1.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Showdgv1();
        }

        private void tsmEditJOB_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tPmain)
            {
                var collum = 2;
                fmEditJOB fm = new fmEditJOB(dgv1.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
            else if (tabControl2.SelectedTab == tP2)
            {
                var collum = 0;
                fmEditJOB fm = new fmEditJOB(dgvMain.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
            else if (tabControl2.SelectedTab == tP3)
            {
                var collum = 0;
                fmEditJOB fm = new fmEditJOB(dgvFinishFix.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
            else if (tabControl2.SelectedTab == tP4)
            {
                var collum = 0;
                fmEditJOB fm = new fmEditJOB(dgvReceive.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
            else if (tabControl2.SelectedTab == tP5)
            {
                var collum = 0;
                fmEditJOB fm = new fmEditJOB(dgv2.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
            else if (tabControl2.SelectedTab == tP6)
            {
                var collum = 0;
                fmEditJOB fm = new fmEditJOB(dgvFollows.SelectedCells[collum].Value.ToString());
                fm.ShowDialog();
            }
        }

        private void ShowctmJOBEDIT(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            var ctm = ctmJOB;
            if (e.Button == MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                ctmJOB.Show(dgv, e.Location);
                ctm.Show(Cursor.Position);
            }
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgv1, e);
        }

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgvMain, e);
        }

        private void dgvFinishFix_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgvFinishFix, e);
        }

        private void dgvReceive_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgvReceive, e);
        }

        private void dgv2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgv2, e);
        }

        private void dgvFollows_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowctmJOBEDIT(dgvFollows, e);
        }
    }
}