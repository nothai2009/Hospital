using COS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmAssignmentsWork : Form
    {
        private User.STATUS_FIXED sf = new User.STATUS_FIXED();
        private int LEVEL_ID;
        private int JOB_WANT_ID;
        private int rowIndex = 0;

        public fmAssignmentsWork()
        {
            InitializeComponent();
        }

        private void AssignmentsWork_Load(object sender, EventArgs e)
        {
            ShowdgvAssignmentsWork();

            //เปิดดูงานใหม่
            var sql = "SELECT JOBID FROM COS_JOB WHERE USER_OPEN IS NULL";
            DataTable dt = new DBClass().SqlGetData(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var sql_update = "update COS_JOB SET OPEN_DATE=@OPEN_DATE,USER_OPEN=@USER_OPEN where JOBID='" + dt.Rows[i]["JOBID"].ToString() + "'";
                    SqlParameterCollection param = new SqlCommand().Parameters;
                    param.AddWithValue("@OPEN_DATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    param.AddWithValue("@USER_OPEN", SqlDbType.Int).Value = User._U_ID;
                    int i2 = new DBClass().SqlExecute(sql_update, param);
                }
            }
        }

        private void ShowdgvAssignmentsWork()
        {
            //try
            //{
            var sql = "SELECT DISTINCT NJ.JOBID, RTRIM(D.DEPNAME)AS DEPTNAME, c2c.NAME, NJ.CARUCODE, NJ.CARUNO,"
            + " c2.SPEC,NJ.IP, CT.CAUSE_NAME, NJ.DESC_, NJ.OWNER, NJ.TEL,"
            + " dbo.dmy_hm(NJ.REQ_DATE)AS REQ_DATE"
            + " FROM COS_JOB NJ"
            + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
            + " LEFT JOIN [CARU2CODE] c2c ON NJ.CARUCODE = c2c.[CARUCODE]"
            + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
            + " LEFT JOIN [CARU2CARU] c2 ON c2.CARUCODE=NJ.CARUCODE AND c2.CARUNO=NJ.CARUNO"
            + " WHERE (NJ.STATUS_FIX_ID = 1) AND (NJ.CANCEL IS NULL) AND NJ.DEPT='" + User._U_DEPT + "' ";
            var dt = new DBClass().SqlGetData(sql);
            dgvAssignmentsWork.DataSource = dt;
            dgvAssignmentsWork.Columns[0].HeaderText = "JOBID";
            dgvAssignmentsWork.Columns[1].HeaderText = "หน่วยงาน";
            dgvAssignmentsWork.Columns[2].HeaderText = "ประเภท";
            dgvAssignmentsWork.Columns[3].HeaderText = "เลขครุภัณฑ์";
            dgvAssignmentsWork.Columns[4].HeaderText = "ตัวย่อ";
            dgvAssignmentsWork.Columns[5].HeaderText = "สเปก";
            dgvAssignmentsWork.Columns[6].HeaderText = "หมายเลข IP";
            dgvAssignmentsWork.Columns[7].HeaderText = "อาการเสีย";
            dgvAssignmentsWork.Columns[8].HeaderText = "รายละเอียด";
            dgvAssignmentsWork.Columns[9].HeaderText = "ผู้แจ้ง";
            dgvAssignmentsWork.Columns[10].HeaderText = "เบอร์โทร";
            dgvAssignmentsWork.Columns[11].HeaderText = "วันที่แจ้งซ่อม";

            dgvAssignmentsWork.Columns[0].Width = 110;
            dgvAssignmentsWork.Columns[1].Width = 120;
            dgvAssignmentsWork.Columns[2].Width = 140;
            dgvAssignmentsWork.Columns[3].Width = 90;
            dgvAssignmentsWork.Columns[4].Width = 75;
            dgvAssignmentsWork.Columns[5].Width = 180;
            dgvAssignmentsWork.Columns[6].Width = 83;
            dgvAssignmentsWork.Columns[7].Width = 125;
            dgvAssignmentsWork.Columns[8].Width = 130;
            dgvAssignmentsWork.Columns[9].Width = 85;
            dgvAssignmentsWork.Columns[10].Width = 60;
            dgvAssignmentsWork.Columns[11].Width = 110;

            Dictionary<string, string> test = new Dictionary<string, string>();

            for (int i = 0; i < dgvAssignmentsWork.ColumnCount; i++)
            {
                test.Add(dgvAssignmentsWork.Columns[i].Name, dgvAssignmentsWork.Columns[i].HeaderText);
            }
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndex = -1;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvAssignmentsWork.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกงาน !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbxRESPONSE_JOB_NAME.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกช่างที่ได้รับมอบหมาย !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxRESPONSE_JOB_NAME.DroppedDown = true;
                return;
            }
            if (cbxJOB_LEVEL.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกระดับความยากของงาน !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxJOB_LEVEL.Focus();
                return;
            }
            if (Convert.ToDateTime(dtpEXPECT_DATE.Value.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("วันกำหนดงานเสร็จต้องไม่ใช่อดีต !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpEXPECT_DATE.Show();
                return;
            }

            if (cbxJOB_LEVEL.Text == "งานทั่วไป")
            {
                LEVEL_ID = 1;
            }
            else if (cbxJOB_LEVEL.Text == "งานระดับยาก")
            {
                LEVEL_ID = 2;
            }
            else
            {
                LEVEL_ID = 3;
            }

            if (cbxJOB_WANT_ID.Text == "รอได้")
            {
                JOB_WANT_ID = 1;
            }
            else if (cbxJOB_WANT_ID.Text == "ด่วน")
            {
                JOB_WANT_ID = 2;
            }
            else
            {
                JOB_WANT_ID = 3;
            }

            if (MessageBox.Show("คุณต้องการบันทึกวิธีการส่งซ่อมใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectedRows = dgvAssignmentsWork.SelectedRows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow).ToArray();

                for (int i = 0; i < dgvAssignmentsWork.SelectedRows.Count; i++)
                {
                    try
                    {
                        var sql_update = "update COS_JOB SET STATUS_FIX_ID=@STATUS_FIX_ID,USER_ID=@USER_ID,LEVEL_ID=@LEVEL_ID,JOB_WANT_ID=@JOB_WANT_ID,REMARK=@REMARK,ASSIGN_DATE=@ASSIGN_DATE,EXPECT_DATE=@EXPECT_DATE, COMMENT=@COMMENT  where JOBID='" + selectedRows[i].Cells[0].Value + "'";
                        SqlParameterCollection param = new SqlCommand().Parameters;
                        param.AddWithValue("@STATUS_FIX_ID", SqlDbType.Int).Value = sf._รอช่างรับงาน;
                        param.AddWithValue("@USER_ID", SqlDbType.Int).Value = cbxRESPONSE_JOB_NAME.SelectedValue;
                        param.AddWithValue("@LEVEL_ID", SqlDbType.Int).Value = LEVEL_ID;
                        param.AddWithValue("@JOB_WANT_ID", SqlDbType.Int).Value = JOB_WANT_ID;
                        param.AddWithValue("@REMARK", SqlDbType.VarChar).Value = txtREMARK.Text;
                        param.AddWithValue("@ASSIGN_DATE", SqlDbType.VarChar).Value = User.GETymd_time();
                        param.AddWithValue("@EXPECT_DATE", SqlDbType.VarChar).Value = dtpEXPECT_DATE.Value.ToString("yyyyMMdd");
                        param.AddWithValue("@COMMENT", SqlDbType.VarChar).Value = txtCOMMENT.Text;
                        int i2 = new DBClass().SqlExecute(sql_update, param);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                ShowdgvAssignmentsWork();
            }
        }

        private void ClearData()
        {
            dgvAssignmentsWork.ClearSelection();
            cbxRESPONSE_JOB_NAME.SelectedIndex = -1;
            cbxJOB_LEVEL.SelectedIndex = -1;
            cbxJOB_WANT_ID.SelectedIndex = -1;
            txtREMARK.Text = "";
            dtpEXPECT_DATE.Text = DateTime.Now.ToString();
        }

        private void dgvAssignmentsWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbxRESPONSE_JOB_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "select U_ID,U_NAME from COS_USER WHERE U_DEPT='" + User._U_DEPT + "' ";
                var dt = new DBClass().SqlGetData(sql);
                cbxRESPONSE_JOB_NAME.DataSource = dt;
                cbxRESPONSE_JOB_NAME.ValueMember = "U_ID";
                cbxRESPONSE_JOB_NAME.DisplayMember = "U_NAME";
                cbxRESPONSE_JOB_NAME.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvAssignmentsWork_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAssignmentsWork.ClearSelection();
            //if(dgvAssignmentsWork.ColumnCount > 0)
            //{
            //    textBox1.Visible = true;
            //    textBox1.Width = dgvAssignmentsWork.Columns[0].Width;

            //}
            //List<string[]> Collum = new List<string[]>();
            //for (int i = 0; i < dgvAssignmentsWork.Columns.Count; i++)
            //{
            //    string[] d = new string[] { dgvAssignmentsWork.Columns[i].HeaderText, dgvAssignmentsWork.Columns[i].Name};
            //    Collum.Add(d);
            //}

            //List<string> Collum = new List<string>();
            //for (int i = 0; i < dgvAssignmentsWork.Columns.Count; i++)
            //{
            //    Collum.Add(dgvAssignmentsWork.Columns[i].HeaderText);
            //}
            // Bind combobox to dictionary
        }

        private void dgvAssignmentsWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            fmEditJOB fm = new fmEditJOB(dgvAssignmentsWork.SelectedCells[0].Value.ToString());
            fm.ShowDialog();

            //if (JOBID.Count != 0)
            //{
            //    JOBID[dgvAssignmentsWork.CurrentCell.RowIndex] = (string)dgvAssignmentsWork.SelectedCells[0].Value;
            //}
            //else
            //{
            //    for (int i = 0; i < dgvAssignmentsWork.Rows.Count; i++)
            //    {
            //        if (dgvAssignmentsWork.CurrentCell.RowIndex == i)
            //        {
            //            JOBID.Add((string)dgvAssignmentsWork.SelectedCells[0].Value);
            //        }
            //        else
            //        {
            //            JOBID.Add("");
            //        }
            //    }
            //}
            //ShowColor();
        }

        private void dgvAssignmentsWork_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void fmAssignmentsWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ShowdgvAssignmentsWork();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.TextLength > 0)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvAssignmentsWork.DataSource;
                    bs.Filter = comboBox1.SelectedValue + " like '%" + textBox1.Text + "%'";
                    dgvAssignmentsWork.DataSource = bs;
                }
                else
                {
                    ShowdgvAssignmentsWork();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            ShowdgvAssignmentsWork();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCOMMENT.Text.Length > 0)
            {
                MessageBox.Show("กรุณาเพิ่มความคิดเห็นก่อนยกเลิกซ่อม");
                return;
            }
            var sql_update = "update COS_JOB SET CANCEL=@CANCEL,COMMENT=@COMMENT where JOBID='" + (string)dgvAssignmentsWork.SelectedCells[0].Value + "'";
            SqlParameterCollection param = new SqlCommand().Parameters;
            param.AddWithValue("@CANCEL", SqlDbType.Char).Value = 'Y';
            param.AddWithValue("@COMMENT", SqlDbType.NVarChar).Value = txtCOMMENT.Text;
            int i2 = new DBClass().SqlExecute(sql_update, param);
            ShowdgvAssignmentsWork();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fmEditJOB fm = new fmEditJOB(dgvAssignmentsWork.SelectedCells[0].Value.ToString());
            fm.ShowDialog();
        }

        private void tsmEditJOB_Click(object sender, EventArgs e)
        {
            fmEditJOB fm = new fmEditJOB(dgvAssignmentsWork.SelectedCells[0].Value.ToString());
            fm.ShowDialog();
        }

        private void dgvAssignmentsWork_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = dgvAssignmentsWork;
            var ctm = ctmJOB;
            if (e.Button == MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                ctmJOB.Show(dgv, e.Location);
                ctm.Show(Cursor.Position);
                if (dgv.SelectedCells[2].Value.ToString() == "Y")
                {
                    //ctmHide.Visible = true;
                    //ctmShow.Visible = false;
                }
                else
                {
                    //ctmHide.Visible = false;
                    //ctmShow.Visible = true;
                }
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                //txtST_NAME.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}