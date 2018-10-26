using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class ManagerStock : Form
    {
        private bool Edit;
        private int rowIndex = 0;

        public ManagerStock()
        {
            InitializeComponent();
        }

        private void ManagerStock_Load(object sender, EventArgs e)
        {
            ClearText2();
            ShowData2();
        }

        private void ClearText2()
        {
            cbxPL_NAME.SelectedIndex = -1;
            txtPL_BRAND.Text = "";
            txtPL_GEN.Text = "";
            txtPL_DESC_C.Text = "";
            txtPL_PRICE.Text = "";
        }

        private void ShowData2()
        {
            var sql = "select P.PL_ID,PL.PL_ID_C,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,U.ST_NAME,PL.PL_PRICE,P.HIDE"
                        + " from COS_PART_LIST P"
                        + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                        + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND PL_NAME LIKE '%" + cbxPL_NAME.Text + "%' ORDER BY PL_NAME";
            var dt = new DBClass().SqlGetData(sql);
            dgv2.DataSource = dt;
            dgv2.Columns[0].HeaderText = "รหัส PL_ID";
            dgv2.Columns[1].HeaderText = "รหัส PL_ID_C";
            dgv2.Columns[2].HeaderText = "พัสดุ";
            dgv2.Columns[3].HeaderText = "แบรนด์";
            dgv2.Columns[4].HeaderText = "รุ่น";
            dgv2.Columns[5].HeaderText = "รายละเอียด";
            dgv2.Columns[6].HeaderText = "หน่วย";
            dgv2.Columns[7].HeaderText = "ราคา";
            dgv2.Columns[8].HeaderText = "สถานะ";

            dgv2.Columns[0].Width = 50;
            dgv2.Columns[1].Width = 50;
            dgv2.Columns[2].Width = 120;
            dgv2.Columns[3].Width = 100;
            dgv2.Columns[4].Width = 130;
            dgv2.Columns[5].Width = 120;
            dgv2.Columns[6].Width = 90;
            dgv2.Columns[7].Width = 70;
            dgv2.Columns[8].Width = 60;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmAddPartList f = new fmAddPartList();
            f.Show();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (txtPL_PRICE.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกราคาพัสดุ");
                return;
            }
            var text = "พัสดุ";
            if (Edit == false)
            {
                try
                {
                    //for (int i = 0; i < dgv2.RowCount; i++)
                    //{
                    //    if (dgv2.Rows[i].Cells[1].Value.ToString() == txtST_NAME.Text)
                    //    {
                    //        MessageBox.Show("ชื่อ"+text+"ซ้ำ", "คำเตือน");
                    //        return;
                    //    }
                    //}
                    if (MessageBox.Show("คุณต้องการเพิ่มรายการ" + text + "ที่สั่งซื้อ " + cbxPL_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var autoNum = "SELECT MAX([PL_ID_C]) FROM [COS_PART_LIST_C] WHERE PL_ID='" + cbxPL_NAME.SelectedValue + "'";
                        var autoNumResult = new DBClass().AutoNunber(autoNum);
                        var save = "insert into [COS_PART_LIST_C] (PL_ID,PL_ID_C,PL_BRAND,PL_GEN,PL_DESC_C,PL_PRICE)VALUES"
                            + "('" + cbxPL_NAME.SelectedValue + "','" + autoNumResult + "','" + txtPL_BRAND.Text + "','" + txtPL_GEN.Text + "','" + txtPL_DESC_C.Text + "','" + txtPL_PRICE.Text + "')";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("บันทึกรายการ" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("บันทึกไม่ได้เนื่องจาก " + ex.Message);
                }
            }
            else if (Edit == true)
            {
                try
                {
                    if (MessageBox.Show("คุณต้องการแก้ไขรายการ" + text + " " + cbxPL_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var edit2 = "update PLC"
                                    + " set PLC.PL_BRAND = '" + txtPL_BRAND.Text + "',PL_GEN = '" + txtPL_GEN.Text + "',PL_DESC_C = '" + txtPL_DESC_C.Text + "',PL_PRICE = '" + txtPL_PRICE.Text + "'"
                                    + " FROM COS_PART_LIST PL"
                                    + " INNER JOIN COS_PART_LIST_C PLC ON PL.PL_ID = PLC.PL_ID"
                                    + " WHERE PL.PL_ID = '" + dgv2.SelectedCells[0].Value + "' AND PLC.PL_ID_C = '" + dgv2.SelectedCells[1].Value + "' AND PL.PL_DEPT = '" + User._U_DEPT + "'";
                        int iedit2 = new DBClass().SqlExecute(edit2);
                        MessageBox.Show("แก้ไขรายการ" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            btnSave2.Enabled = false;
            btnEdit2.Enabled = false;
            btnDelete2.Enabled = false;
            btnCancel2.Enabled = false;
            Edit = false;
            ClearText2();
            ShowData2();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave2.Enabled = true;
                btnEdit2.Enabled = false;
                btnDelete2.Enabled = false;
                btnCancel2.Enabled = true;
                btnSave2.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            var dgv = dgv2;
            var btnSave = btnSave2;
            var btnEdit = btnEdit2;
            var btnDelete = btnDelete2;
            var btnCancel = btnCancel2;
            if (dgv.CurrentRow.Selected == false)
            {
                return;
            }

            try
            {
                if (MessageBox.Show("คุณต้องการลบรายการอะไหล่ " + cbxPL_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var delete = "delete COS_PART_LIST_C WHERE PL_ID='" + dgv.SelectedCells[0].Value + "' AND PL_ID_C='" + dgv.SelectedCells[1].Value + "'";
                    int idelete = new DBClass().SqlExecute(delete);
                    MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearText2();
                    ShowData2();
                    cbxPL_NAME.Focus();
                    btnSave.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCancel.Enabled = false;
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

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            var dgv = dgv2;
            var btnSave = btnSave2;
            var btnEdit = btnEdit2;
            var btnDelete = btnDelete2;
            var btnCancel = btnCancel2;

            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            Edit = false;
            dgv.ClearSelection();
            ClearText2();
            cbxPL_NAME.Focus();
            ShowData2();
        }

        private void dgv2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dgv2.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dgv2.CurrentCell = this.dgv2.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgv2, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv2.SelectedCells[8].Value.ToString() == "N")
                {
                    ctmHide.Visible = true;
                    ctmShow.Visible = false;
                }
                else
                {
                    ctmHide.Visible = false;
                    ctmShow.Visible = true;
                }
                btnSave2.Enabled = false;
                btnEdit2.Enabled = true;
                btnDelete2.Enabled = true;
                btnCancel2.Enabled = false;
            }
            else
            {
                ClearText2();
                if (e.RowIndex == -1)
                {
                    return;
                }
                cbxPL_NAME.Text = dgv2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPL_BRAND.Text = dgv2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPL_GEN.Text = dgv2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPL_DESC_C.Text = dgv2.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPL_PRICE.Text = dgv2.Rows[e.RowIndex].Cells[7].Value.ToString();

                btnSave2.Enabled = false;
                btnEdit2.Enabled = true;
                btnDelete2.Enabled = true;
                btnCancel2.Enabled = false;
            }
        }

        private void dgv2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv2.ClearSelection();
        }

        private void cbxPL_NAME_Click_1(object sender, EventArgs e)
        {
            try
            {
                var cbx = "SELECT [PL_ID],[PL_NAME] FROM [COS_PART_LIST] ORDER BY PL_NAME";
                var dt = new DBClass().SqlGetData(cbx);
                cbxPL_NAME.DataSource = dt;
                cbxPL_NAME.ValueMember = "PL_ID";
                cbxPL_NAME.DisplayMember = "PL_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void cbxPL_NAME_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                var sql = "select P.PL_ID,PL.PL_ID_C,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,U.ST_NAME,PL.PL_PRICE,P.HIDE"
                        + " from COS_PART_LIST P"
                        + " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                        + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND P.PL_ID = '" + cbxPL_NAME.SelectedValue + "' ORDER BY PL_NAME";
                var dt = new DBClass().SqlGetData(sql);
                dgv2.DataSource = dt;
                dgv2.Columns[0].HeaderText = "รหัส PL_ID";
                dgv2.Columns[1].HeaderText = "รหัส PL_ID_C";
                dgv2.Columns[2].HeaderText = "พัสดุ";
                dgv2.Columns[3].HeaderText = "แบรนด์";
                dgv2.Columns[4].HeaderText = "รุ่น";
                dgv2.Columns[5].HeaderText = "รายละเอียด";
                dgv2.Columns[6].HeaderText = "หน่วย";
                dgv2.Columns[7].HeaderText = "ราคา";
                dgv2.Columns[8].HeaderText = "สถานะ";

                dgv2.Columns[0].Width = 50;
                dgv2.Columns[1].Width = 50;
                dgv2.Columns[2].Width = 120;
                dgv2.Columns[3].Width = 100;
                dgv2.Columns[4].Width = 130;
                dgv2.Columns[5].Width = 120;
                dgv2.Columns[6].Width = 90;
                dgv2.Columns[7].Width = 70;
                dgv2.Columns[8].Width = 60;
            }
            btnSave2.Enabled = true;
            btnEdit2.Enabled = false;
            btnDelete2.Enabled = false;
            btnCancel2.Enabled = true;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                var dgv = dgv2;
                var cell = 8;
                var cellID = 0;
                if (ctmHide.Visible == true)
                {
                    dgv[cell, rowIndex].Value = "Y";
                }
                else if (ctmHide.Visible == false)
                {
                    dgv[cell, rowIndex].Value = "N";
                }
                dgv.UpdateCellValue(cell, rowIndex);
                dgv.Rows[rowIndex].Selected = true;
                var update = "update COS_PART_LIST set HIDE='" + dgv.SelectedCells[cell].Value + "' WHERE PL_ID='" + dgv.SelectedCells[cellID].Value + "'";
                int i2 = new DBClass().SqlExecute(update);
            }
        }
    }
}