using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAddUserGroups : Form
    {
        public fmAddUserGroups()
        {
            InitializeComponent();
        }

        private void fmAddUserGroups_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void ShowData1()
        {
            var sql = "SELECT U_USERGROUP,U_USERGROUP_NAME,U.HIDE,D.DEPT_NAME"
                + " FROM COS_USERGROUP U"
                + " LEFT JOIN COS_DEPT_COS D ON U.DEPT=D.ID"
                + " ORDER BY U_USERGROUP_NAME";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "รหัส";
            dgv1.Columns[1].HeaderText = "ชื่อประเภท";
            dgv1.Columns[2].HeaderText = "แสดง";
            dgv1.Columns[3].HeaderText = "หน่วยงาน";

            dgv1.Columns[0].Width = 100;
            dgv1.Columns[1].Width = 80;
            dgv1.Columns[2].Width = 80;
            dgv1.Columns[3].Width = 80;
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private bool Edit;

        private void button1_Click(object sender, EventArgs e)
        {
            var text = "ประเภทผู้ใช้";
            if (Edit == false)
            {
                //try
                //{
                for (int i = 0; i < dgv1.RowCount; i++)
                {
                    if (dgv1.Rows[i].Cells[1].Value.ToString() == txtU_USERGROUP_NAME.Text)
                    {
                        MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                        return;
                    }
                }
                if (MessageBox.Show("คุณต้องการเพิ่ม" + text + txtU_USERGROUP_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "insert into COS_USERGROUP (U_USERGROUP_NAME,HIDE,DEPT)VALUES ('" + txtU_USERGROUP_NAME.Text + "','N'," + cbxDEPT_NAME.SelectedValue + ")";
                    int isave = new DBClass().SqlExecute(save);
                    MessageBox.Show("บันทึก" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("บันทึกไม่ได้เนื่องจาก " + ex.Message);
                //}
            }
            else if (Edit == true)
            {
                try
                {
                    if (MessageBox.Show("คุณต้องการแก้ไข" + text + txtU_USERGROUP_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update COS_USERGROUP set U_USERGROUP_NAME='" + txtU_USERGROUP_NAME.Text + "',DEPT='" + cbxDEPT_NAME.SelectedValue + "' WHERE [U_USERGROUP]='" + dgv1.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไข" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("แก้ไขไม่ได้เนื่องจาก " + ex.Message);
                }
            }

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Edit = false;
            txtU_USERGROUP_NAME.Text = "";
            ShowData1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                txtU_USERGROUP_NAME.Text = dgv1.SelectedCells[1].Value.ToString();
                button1.Focus();
                Edit = true;
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var text = "ประเภทผู้ใช้";
            if (dgv1.CurrentRow.Selected == false)
            {
                return;
            }
            try
            {
                if (MessageBox.Show("คุณต้องการลบ" + text + txtU_USERGROUP_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "delete COS_USERGROUP WHERE [U_USERGROUP]='" + dgv1.SelectedCells[0].Value + "'";
                    int isave = new DBClass().SqlExecute(save);
                    MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData1();
                    txtU_USERGROUP_NAME.Text = "";
                    txtU_USERGROUP_NAME.Focus();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ลบข้อมูลไม่ได้เนื่องจาก " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Edit = false;
            dgv1.ClearSelection();
            txtU_USERGROUP_NAME.Text = "";
            txtU_USERGROUP_NAME.Focus();
            ShowData1();
        }

        private void txtST_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            var text = "ประเภทผู้ใช้";
            if (Edit == false)
            {
                var sql = "SELECT [U_USERGROUP],[U_USERGROUP_NAME],[HIDE] FROM [COS_USERGROUP] WHERE [U_USERGROUP] LIKE '%" + txtU_USERGROUP_NAME.Text + "%' ORDER BY U_USERGROUP_NAME ASC";
                var dt = new DBClass().SqlGetData(sql);
                dgv1.DataSource = dt;
                dgv1.Columns[0].HeaderText = "รหัส";
                dgv1.Columns[1].HeaderText = text;
                dgv1.Columns[2].HeaderText = "แสดง";

                dgv1.Columns[0].Width = 100;
                dgv1.Columns[1].Width = 80;
                dgv1.Columns[2].Width = 80;
            }
            if (txtU_USERGROUP_NAME.TextLength > 0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
            }
        }

        private int rowIndex = 0;

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dgv1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dgv1.CurrentCell = this.dgv1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgv1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv1.SelectedCells[2].Value.ToString() == "Y")
                {
                    ctmHide.Visible = true;
                    ctmShow.Visible = false;
                }
                else
                {
                    ctmHide.Visible = false;
                    ctmShow.Visible = true;
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
                txtU_USERGROUP_NAME.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbxDEPT_NAME.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dgv1.Rows[rowIndex].IsNewRow)
            {
                //try
                //{
                if (ctmHide.Visible == true)
                {
                    dgv1[2, rowIndex].Value = "N";
                }
                else if (ctmHide.Visible == false)
                {
                    dgv1[2, rowIndex].Value = "Y";
                }
                dgv1.UpdateCellValue(2, rowIndex);
                var update = "update COS_USERGROUP set HIDE='" + dgv1.SelectedCells[2].Value + "' WHERE U_USERGROUP='" + dgv1.SelectedCells[0].Value + "'";
                int i2 = new DBClass().SqlExecute(update);
                dgv1.Rows[rowIndex].Selected = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "SELECT [ID],[DEPT_NAME] FROM[COS_DEPT_COS] ORDER BY DEPT_NAME";
                var dt = new DBClass().SqlGetData(sql);
                cbxDEPT_NAME.DataSource = dt;
                cbxDEPT_NAME.ValueMember = "ID";
                cbxDEPT_NAME.DisplayMember = "DEPT_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}