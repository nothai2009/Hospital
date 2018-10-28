using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmHisFixed : Form
    {
        private User u = new User();
        private string JOB_New;
        private string JOB_Now;

        public fmHisFixed()
        {
            InitializeComponent();
        }

        private void HisFix_Load(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;

            //try
            //{
            ShowdgvHisFix();
            ShowlabelCountFixed();
            ShowtxtCAUSE();
            ShowcbxCARU2_COS_FIXED_TYPE();

            dgvHisFix.ClearSelection();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //finally
            //{
            new FormatGridView().FormatdgvHisFix(dgvHisFix);
            dgvHisFix.ClearSelection();
            //}
        }

        private void ShowdgvHisFix()
        {
            string sql = "SELECT [JOB_ID],[CARUCODE],[CARUNO],[CARUTYPE_NAME],[DEPTNAME],[CAUSE],[RESPONSE_JOB_NAME],[FIXED_NAME]"
                    + " FROM COS_JOBLIST WHERE [SEND_DATE] IS NOT NULL AND CARUCODE='" + User._CARUCODE + "' AND CARUNO='" + User._CARUNO + "'";
            DataTable dt = new DBClass().SqlGetData(sql);
            dgvHisFix.DataSource = dt;
        }

        private void ShowdgvPART_ORDER()
        {
            string sql_PART_ORDER = "SELECT [JOB_ID],[PART_ID],[PART_NAME],[QTY],[UNIT],[STANDARD_PRICE],[TOTAL_STANDARD_PRICE]"
                    + " FROM COS_PART_ORDER WHERE JOB_ID='" + User._JOB_Now + "'";
            DataTable dt = new DBClass().SqlGetData(sql_PART_ORDER);
            dgvStock.DataSource = dt;
            new FormatGridView().FormatdgvStock(dgvStock);
        }

        private void ShowcbxCARU2_COS_FIXED_TYPE()
        {
            try
            {
                string sql = "  select FIXED_NAME from COS_FIXED_TYPE ORDER BY FIXED_NAME ASC";
                DataTable dt = new DBClass().SqlGetData(sql);
                cbxCARU2_COS_FIXED_TYPE.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DBClass.tr.Rollback();
            }
            finally
            {
                cbxCARU2_COS_FIXED_TYPE.SelectedIndex = -1;
            }
        }

        private void ShowtxtCAUSE()
        {
            string sqlText = "SELECT [CAUSE]"
                 + " FROM CARU2_COS_JOBLIST"
                 + " WHERE JOB_ID = '" + User._JOB_Now + "'";
            DataTable dtText = new DBClass().SqlGetData(sqlText);
            txtCAUSE.Text = dtText.Rows[0]["CAUSE"].ToString();
        }

        private void ShowlabelCountFixed()
        {
            string sql_Count = "select COUNT([CARUCODE]) as CARUCODE"
                            + " from CARU2_COS_JOBLIST "
                            + " where [SEND_DATE] IS NOT NULL AND CARUCODE = '" + User._CARUCODE + "' AND CARUNO = '" + User._CARUNO + "'";
            DataTable dt = new DBClass().SqlGetData(sql_Count);
            labelCountFixed.Text = dt.Rows[0]["CARUCODE"].ToString();
        }

        private void dgvHisFix_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvHisFix.ClearSelection();
        }

        private void dgvHisFix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
            this.dgvHisFix.Columns[0].Visible = false;                                          //ซ่อน cell 0
        }

        private void dgvHisFix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            JOB_New = dgvHisFix.Rows[dgvHisFix.Rows[e.RowIndex].Index].Cells[0].Value.ToString();
            if (JOB_New == JOB_Now)
            {
                dgvHisFix.ClearSelection();
                JOB_New = "";
                JOB_Now = "";
            }
            else
            {
                JOB_Now = JOB_New;
                dgvHisFix.Rows[dgvHisFix.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvHisFix.Rows[dgvHisFix.Rows[e.RowIndex].Index].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
            if (JOB_Now != "")
            {
                string sql = "SELECT [SPEC],[DESC_],[OWNER],[TEL],[REQ_DATE],[EXPECT_DATE],[COMPLETE_DATE],[SEND_DATE],[REMARK],[FIXED_DETAIL],[HOWTOFIXED],[RECEIVE_BY]"
                            + " FROM COS_JOBLIST"
                            + " WHERE JOB_ID = '" + JOB_Now + "'";
                DataTable dt = new DBClass().SqlGetData(sql);
                txtSPEC.Text = dt.Rows[0]["SPEC"].ToString();
                txtDESC_.Text = dt.Rows[0]["DESC_"].ToString();
                txtOWNER.Text = dt.Rows[0]["OWNER"].ToString();
                txtTEL.Text = dt.Rows[0]["TEL"].ToString();
                txtREMARK.Text = dt.Rows[0]["REMARK"].ToString();

                dtpREQ_DATE.Text = dt.Rows[0]["REQ_DATE"].ToString();
                dtpEXPECT_DATE.Text = dt.Rows[0]["EXPECT_DATE"].ToString();
                dtpCOMPLETE_DATE.Text = dt.Rows[0]["COMPLETE_DATE"].ToString();
                dtpSEND_DATE.Text = dt.Rows[0]["SEND_DATE"].ToString();

                txtFIXED_DETAIL.Text = dt.Rows[0]["FIXED_DETAIL"].ToString();
                txtHOWTOFIXED_Show.Text = dt.Rows[0]["HOWTOFIXED"].ToString();
                txtRECEIVE_BY.Text = dt.Rows[0]["RECEIVE_BY"].ToString();
            }
            else
            {
                txtSPEC.Text = "";
                txtDESC_.Text = "";
                txtOWNER.Text = "";
                txtTEL.Text = "";
                txtREMARK.Text = "";
                dtpREQ_DATE.Text = DateTime.Now.ToString();
                dtpEXPECT_DATE.Text = DateTime.Now.ToString();
                dtpCOMPLETE_DATE.Text = DateTime.Now.ToString();
                dtpSEND_DATE.Text = DateTime.Now.ToString();
                txtFIXED_DETAIL.Text = "";
                txtHOWTOFIXED_Show.Text = "";
                txtRECEIVE_BY.Text = "";
            }
        }

        private void dgvHisFix_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            JOB_New = dgvHisFix.Rows[dgvHisFix.Rows[e.RowIndex].Index].Cells[0].Value.ToString();
        }

        private void ShowdgvPART_USER()
        {
            try
            {
                string sql = "select JOB_ID,PART_ID,PART_NAME,QTY,UNIT,STANDARD_PRICE,TOTAL_STANDARD_PRICE"
                    + " from COS_PART_USED where JOB_ID = '" + User._JOB_Now + "' order by (CAST(PART_ID AS Int)) desc";
                DataTable dt = new DBClass().SqlGetData(sql);
                dgvStock.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                ShowcbxPART_NAME();
            }
        }

        private void ShowcbxPART_NAME()
        {
            try
            {
                string sql = "select * from COS_PART_LIST ORDER BY PART_NAME ASC";
                DataTable dt = new DBClass().SqlGetData(sql);
                cbxPART_NAME.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DBClass.tr.Rollback();
            }
            finally
            {
                cbxPART_NAME.SelectedIndex = -1;
            }
        }

        private void cbxPART_NAME_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void Cal()
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

        private void nud1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from COS_PART_LIST where PART_NAME='" + cbxPART_NAME.Text + "'";
                DataTable dt = new DBClass().SqlGetData(sql);
                txtREF_PRICE.Text = dt.Rows[0]["REF_PRICE"].ToString();
                txtUNIT.Text = dt.Rows[0]["UNIT"].ToString();
                if (nud1.Value == 0)
                {
                    txtREF_PRICE.Text = "";
                }
                Cal();
            }
            catch
            {
            }
        }

        private void txtHOWTOFIXED_TextChanged(object sender, EventArgs e)
        {
            if (txtHOWTOFIXED.Text != "")
            {
                btnSave.Enabled = true;
            }
        }

        private void cbxPART_NAME_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = "select UNIT,REF_PRICE from COS_PART_LIST where PART_NAME = '" + cbxPART_NAME.Text + "'";
            DataTable dt = new DBClass().SqlGetData(sql);
            txtUNIT.Text = dt.Rows[0]["UNIT"].ToString();
            txtREF_PRICE.Text = dt.Rows[0]["REF_PRICE"].ToString();
            txtTotal.Text = dt.Rows[0]["REF_PRICE"].ToString();
            nud1.Value = 1;
        }

        private void nud1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxPART_NAME.ValueMember == null)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกรายการอะไหล่");
                return;
            }
            if (cbxPART_NAME.ValueMember == "")
            {
                MessageBox.Show("คุณยังไม่ได้เลือกรายการอะไหล่");
                return;
            }
            if (cbxCARU2_COS_FIXED_TYPE.Text == "ซ่อมเองโดยขออนุมัติซื้อวัสดุ")
            {
                string sql_PART_ORDER = "select MAX(CAST(PART_ID AS Int)) from COS_PART_ORDER where JOB_ID = '" + User._JOB_Now + "' ";
                int PART_ORDER = new DBClass().AutoNunber(sql_PART_ORDER);

                string insert_PART_ORDER = "insert into [COS_PART_ORDER]"
                                + "(JOB_ID, PART_ID, PART_NAME, QTY, UNIT, STATUS, REQ_DATE, STANDARD_PRICE, TOTAL_STANDARD_PRICE)"
                                + "Values(@JOB_ID, @PART_ID, @PART_NAME, @QTY, @UNIT, @STATUS, @REQ_DATE, @STANDARD_PRICE, @TOTAL_STANDARD_PRICE)";
                SqlParameterCollection param_PART_ORDER = new SqlCommand().Parameters;
                param_PART_ORDER.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = User._JOB_Now;
                param_PART_ORDER.AddWithValue("@PART_ID", SqlDbType.VarChar).Value = PART_ORDER;
                param_PART_ORDER.AddWithValue("@PART_NAME", SqlDbType.VarChar).Value = this.cbxPART_NAME.Text;
                param_PART_ORDER.AddWithValue("@QTY", SqlDbType.Int).Value = this.nud1.Value;
                param_PART_ORDER.AddWithValue("@UNIT", SqlDbType.VarChar).Value = this.txtUNIT.Text;
                param_PART_ORDER.AddWithValue("@STATUS", SqlDbType.VarChar).Value = "1";
                param_PART_ORDER.AddWithValue("@REQ_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                param_PART_ORDER.AddWithValue("@STANDARD_PRICE", SqlDbType.Float).Value = this.txtREF_PRICE.Text;
                param_PART_ORDER.AddWithValue("@TOTAL_STANDARD_PRICE", SqlDbType.Float).Value = this.txtTotal.Text;

                int i = new DBClass().SqlExecute(insert_PART_ORDER, param_PART_ORDER);

                ShowdgvPART_ORDER();
                ClearStock();
            }

            string sql = "select MAX(CAST(PART_ID AS Int)) from COS_PART_USED where JOB_ID = '" + User._JOB_Now + "' ";
            int PART_ID = new DBClass().AutoNunber(sql);

            string insert = "insert into COS_PART_USED"
                            + "(JOB_ID, PART_ID, PART_NAME, QTY, UNIT, STATUS, USED_DATE, STANDARD_PRICE, TOTAL_STANDARD_PRICE)"
                            + "Values(@JOB_ID, @PART_ID, @PART_NAME, @QTY, @UNIT, @STATUS, @USED_DATE, @STANDARD_PRICE, @TOTAL_STANDARD_PRICE)";
            SqlParameterCollection param = new SqlCommand().Parameters;
            param.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = User._JOB_Now;
            param.AddWithValue("@PART_ID", SqlDbType.VarChar).Value = PART_ID;
            param.AddWithValue("@PART_NAME", SqlDbType.VarChar).Value = this.cbxPART_NAME.Text;
            param.AddWithValue("@QTY", SqlDbType.Int).Value = this.nud1.Value;
            param.AddWithValue("@UNIT", SqlDbType.VarChar).Value = this.txtUNIT.Text;
            param.AddWithValue("@STATUS", SqlDbType.VarChar).Value = "1";
            param.AddWithValue("@USED_DATE", SqlDbType.DateTime).Value = DateTime.Now;
            param.AddWithValue("@STANDARD_PRICE", SqlDbType.Float).Value = this.txtREF_PRICE.Text;
            param.AddWithValue("@TOTAL_STANDARD_PRICE", SqlDbType.Float).Value = this.txtTotal.Text;

            int i2 = new DBClass().SqlExecute(insert, param);

            ShowdgvPART_USER();
            ClearStock();
        }

        private void ClearStock()
        {
            nud1.Value = 1;
            txtREF_PRICE.Clear();
            txtUNIT.Clear();
            txtTotal.Clear();
            cbxPART_NAME.SelectedIndex = -1;
            dgvStock.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (User._JOB_Now == null || User._PART_ID == null)
            {
                MessageBox.Show("คุณยังไม่ได้อะไหล่");
                return;
            }
            else
            {
                int i;
                for (i = 0; i < User._PART_ID.Count; i++)
                {
                    if (User._PART_ID[i] != "")
                    {
                        //try
                        //{
                        string sqlDelete = "Delete From COS_PART_USED Where JOB_ID = @JOB_ID and PART_ID = @PART_ID";
                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = User._JOB_Now;
                        param.AddWithValue("@PART_ID", SqlDbType.VarChar).Value = User._PART_ID[i];
                        int i2 = new DBClass().SqlExecute(sqlDelete, param);

                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("ลบข้อมูลไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                    }
                }
                ShowdgvPART_USER();
            }
        }

        private List<string> PART_ID_Stock = new List<string>();

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            //PART_ID_Stock = new Setting().ShowColorClick_Stock(dgvStock, PART_ID_Stock);
            //User._PART_ID = PART_ID_Stock;
        }

        private void dgvStock_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            AutoDeleteStock();
            ShowdgvPART_USER();
            dgvStock.ClearSelection();
        }

        private void AutoDeleteStock()
        {
            try
            {
                var sqlDelete = "Delete From COS_PART_USED Where JOB_ID = @JOB_ID";
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@JOB_ID", SqlDbType.VarChar).Value = User._JOB_Now;
                int i2 = new DBClass().SqlExecute(sqlDelete, param);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ลบข้อมูลไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string FIXED_TYPE, PART_LIST, FIXED_NAME;
        private float COST_PART;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (User._JOB_Now == null)
            {
                MessageBox.Show("คุณยังไม่ได้เลือกงาน");
                return;
            }

            string sql = "select SUM(TOTAL_STANDARD_PRICE)"
                            + " from COS_PART_USED"
                            + " where JOB_ID = '" + User._JOB_Now + "'";
            float TOTAL_STANDARD_PRICE = new DBClass().TOTAL_STANDARD_PRICE(sql);

            var value = (string)cbxCARU2_COS_FIXED_TYPE.SelectedValue;

            if (MessageBox.Show("คุณต้องการบันทึกวิธีการส่งซ่อมใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (value == "ซ่อมเองโดยไม่ใช้วัสดุ")
                    {
                        if (User._JOB_Now != null && User._PART_ID != null)
                        {
                            AutoDeleteStock();
                        }
                        FIXED_TYPE = "0";
                        PART_LIST = "";
                        COST_PART = TOTAL_STANDARD_PRICE;
                        FIXED_NAME = "ซ่อมเองโดยไม่ใช้วัสดุ";
                    }
                    else if (value == "ซ่อมเองโดยใช้วัสดุในสต๊อก")
                    {
                        if (dgvStock.DataSource == null)
                        {
                            MessageBox.Show("คุณยังไม่ได้เพิ่มอะไหล์ในการซ่อม");
                            return;
                        }
                        FIXED_TYPE = "5";
                        PART_LIST = "1";
                        COST_PART = TOTAL_STANDARD_PRICE;
                        FIXED_NAME = "ซ่อมเองโดยใช้วัสดุในสต๊อก";
                    }
                    else if (value == "ซ่อมเองโดยขออนุมัติซื้อวัสดุ")
                    {
                        FIXED_TYPE = "2";
                        PART_LIST = "";
                        COST_PART = TOTAL_STANDARD_PRICE;
                        FIXED_NAME = "";
                    }
                    else if (value == "ขออนุมัติจ้างเอกชน")
                    {
                        FIXED_TYPE = "3";
                        PART_LIST = "";
                        COST_PART = TOTAL_STANDARD_PRICE;
                        FIXED_NAME = "";
                    }
                    else if (value == "ขออนุมัติซื้อทดแทน")
                    {
                        FIXED_TYPE = "4";
                        PART_LIST = "";
                        COST_PART = TOTAL_STANDARD_PRICE;
                        FIXED_NAME = "";
                    }
                    if (value == "ซ่อมเองโดยไม่ใช้วัสดุ" || value == "ซ่อมเองโดยใช้วัสดุในสต๊อก" || value == "ขออนุมัติจ้างเอกชน" || value == "ขออนุมัติซื้อทดแทน")
                    {
                        string sql_update = "update COS_JOBLIST SET STATE=@STATE,PART_LIST=@PART_LIST,FIXED_TYPE=@FIXED_TYPE,FIXED_NAME=@FIXED_NAME,COST_PART=@COST_PART,MOTIVE=@MOTIVE,HOWTOFIXED=@HOWTOFIXED,PSD_SEND_REQ_BUY=@PSD_SEND_REQ_BUY"
                        + " where JOB_ID='" + User._JOB_Now + "'";
                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@STATE", SqlDbType.Int).Value = "1";
                        param.AddWithValue("@PART_LIST", SqlDbType.VarChar).Value = PART_LIST;
                        param.AddWithValue("@FIXED_TYPE", SqlDbType.VarChar).Value = FIXED_TYPE;
                        param.AddWithValue("@FIXED_NAME", SqlDbType.VarChar).Value = FIXED_NAME;
                        param.AddWithValue("@COST_PART", SqlDbType.Float).Value = COST_PART;
                        param.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                        param.AddWithValue("@HOWTOFIXED", SqlDbType.VarChar).Value = txtHOWTOFIXED.Text;
                        param.AddWithValue("@PSD_SEND_REQ_BUY", SqlDbType.DateTime).Value = DateTime.Now;

                        int i2 = new DBClass().SqlExecute(sql_update, param);

                        MessageBox.Show("เลือกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (value == "ซ่อมเองโดยขออนุมัติซื้อวัสดุ")
                    {
                        string sql_PSD = "update COS_JOBLIST SET STATE=@STATE,PART_LIST=@PART_LIST,FIXED_TYPE=@FIXED_TYPE,FIXED_NAME=@FIXED_NAME,COST_PART=@COST_PART,MOTIVE=@MOTIVE,HOWTOFIXED=@HOWTOFIXED"
                        + " where JOB_ID='" + User._JOB_Now + "'";
                        SqlParameterCollection paramsql_PSD = new SqlCommand().Parameters;
                        paramsql_PSD.AddWithValue("@STATE", SqlDbType.Int).Value = "1";
                        paramsql_PSD.AddWithValue("@PART_LIST", SqlDbType.VarChar).Value = PART_LIST;
                        paramsql_PSD.AddWithValue("@FIXED_TYPE", SqlDbType.VarChar).Value = FIXED_TYPE;
                        paramsql_PSD.AddWithValue("@FIXED_NAME", SqlDbType.VarChar).Value = FIXED_NAME;
                        paramsql_PSD.AddWithValue("@COST_PART", SqlDbType.Float).Value = COST_PART;
                        paramsql_PSD.AddWithValue("@MOTIVE", SqlDbType.VarChar).Value = txtMOTIVE.Text;
                        paramsql_PSD.AddWithValue("@HOWTOFIXED", SqlDbType.VarChar).Value = txtHOWTOFIXED.Text;

                        int i = new DBClass().SqlExecute(sql_PSD, paramsql_PSD);

                        MessageBox.Show("เลือกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //DBClass.tr.Rollback();
                }
                finally
                {
                    User._JOB_Now = "";
                    ClearHisFix();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
        }

        private void cbxCARU2_COS_FIXED_TYPE_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select FIXED_NAME from COS_FIXED_TYPE order by[FIXED_NAME] desc";
                DataTable dt = new DBClass().SqlGetData(sql);
                cbxCARU2_COS_FIXED_TYPE.DataSource = dt;
                cbxCARU2_COS_FIXED_TYPE.DisplayMember = "FIXED_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DBClass.tr.Rollback();
            }
            finally
            {
                cbxCARU2_COS_FIXED_TYPE.SelectedIndex = -1;
            }
        }

        private void cbxCARU2_COS_FIXED_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var value = cbxCARU2_COS_FIXED_TYPE.Text;
            btnSave.Focus();
            if (value == "ซ่อมเองโดยไม่ใช้วัสดุ" || value == "ขออนุมัติจ้างเอกชน")
            {
                //ไม่ใช้ตารางใด
                groupBox3_3.Visible = false;
            }
            else if (value == "ซ่อมเองโดยใช้วัสดุในสต๊อก")
            {
                //ตาราง PART_USER
                groupBox3_3.Visible = true;
                ShowdgvPART_USER();
            }
            else if (value == "ซ่อมเองโดยขออนุมัติซื้อวัสดุ" || value == "ขออนุมัติซื้อทดแทน")
            {
                //ตาราง PART_ORDER

                ShowdgvPART_ORDER();
            }
        }

        private void cbxPART_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "select PART_NAME from COS_PART_LIST ORDER BY PART_NAME ASC";
                DataTable dt = new DBClass().SqlGetData(sql);
                cbxPART_NAME.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DBClass.tr.Rollback();
            }
            finally
            {
                cbxPART_NAME.SelectedIndex = -1;
            }
        }

        private void ClearHisFix()
        {
            txtSPEC.Text = "";
            txtDESC_.Text = "";
            txtOWNER.Text = "";
            txtTEL.Text = "";
            txtREMARK.Text = "";
            txtFIXED_DETAIL.Text = "";
            txtHOWTOFIXED_Show.Text = "";
            txtRECEIVE_BY.Text = "";
            dtpCOMPLETE_DATE.Text = DateTime.Now.ToString();
            dtpEXPECT_DATE.Text = DateTime.Now.ToString();
            dtpREQ_DATE.Text = DateTime.Now.ToString();
            dtpSEND_DATE.Text = DateTime.Now.ToString();
            txtCAUSE.Text = "";
            txtMOTIVE.Text = "";
            txtHOWTOFIXED.Text = "";
        }
    }
}