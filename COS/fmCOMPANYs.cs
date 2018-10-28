using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmCompanys : Form
    {
        public fmCompanys()
        {
            InitializeComponent();
        }

        private void fmAddUnit_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void ShowData1()
        {
            var sql = "SELECT [ID],[COMPANY_NAME],[HIDE] FROM [COS_COMPANY] ORDER BY COMPANY_NAME";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "รหัส";
            dgv1.Columns[1].HeaderText = "ชื่อบริษัท";
            dgv1.Columns[2].HeaderText = "แสดง";

            dgv1.Columns[0].Width = 100;
            dgv1.Columns[1].Width = 80;
            dgv1.Columns[2].Width = 80;
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private bool Edit;

        private void button1_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                //try
                //{
                for (int i = 0; i < dgv1.RowCount; i++)
                {
                    if (dgv1.Rows[i].Cells[1].Value.ToString() == txtCOMPANY_NAME.Text)
                    {
                        MessageBox.Show("ชื่อบริษัทซ้ำ", "คำเตือน");
                        return;
                    }
                }
                if (MessageBox.Show("คุณต้องการเพิ่มบริษัท " + txtCOMPANY_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "insert into [COS_COMPANY] ([COMPANY_NAME],[HIDE])VALUES ('" + txtCOMPANY_NAME.Text + "','N')";
                    int isave = new DBClass().SqlExecute(save);
                    MessageBox.Show("บันทึกชื่อบริษัทเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขชื่อบริษัท " + txtCOMPANY_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update [COS_UNIT] set [ST_NAME]='" + txtCOMPANY_NAME.Text + "' WHERE [ST_UNIT]='" + dgv1.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไขชื่อบริษัทเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCOMPANY_NAME.Text = "";
            ShowData1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                txtCOMPANY_NAME.Text = dgv1.SelectedCells[1].Value.ToString();
                button1.Focus();
                Edit = true;
            }
            catch
            {
            }
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Edit = false;
            dgv1.ClearSelection();
            txtCOMPANY_NAME.Text = "";
            txtCOMPANY_NAME.Focus();
            ShowData1();
        }

        private void txtST_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                var sql = "SELECT [ID],[COMPANY_NAME],[HIDE] FROM [COS_COMPANY] WHERE [COMPANY_NAME] LIKE '%" + txtCOMPANY_NAME.Text + "%' ORDER BY COMPANY_NAME ASC";
                var dt = new DBClass().SqlGetData(sql);
                dgv1.DataSource = dt;
                dgv1.Columns[0].HeaderText = "รหัส";
                dgv1.Columns[1].HeaderText = "ชื่อบริษัท";
                dgv1.Columns[2].HeaderText = "แสดง";

                dgv1.Columns[0].Width = 100;
                dgv1.Columns[1].Width = 80;
                dgv1.Columns[2].Width = 80;
            }
            if (txtCOMPANY_NAME.TextLength > 0)
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
                txtCOMPANY_NAME.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                var update = "update COS_COMPANY set HIDE='" + dgv1.SelectedCells[2].Value + "' WHERE COMPANY_NAME='" + dgv1.SelectedCells[0].Value + "'";
                int i2 = new DBClass().SqlExecute(update);
                dgv1.Rows[rowIndex].Selected = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }
    }
}