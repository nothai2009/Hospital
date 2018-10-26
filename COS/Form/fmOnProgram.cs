using System;
using System.Data;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmOnProgram : Form
    {
        private bool Edit;

        public fmOnProgram()
        {
            InitializeComponent();
        }

        private void ShowData1()
        {
            try
            {
                var sql = "SELECT [ST_ID],S.[ST_NAME],U.ST_NAME,[ST_IN],[ST_PRICE],S.[HIDE]"
            + " FROM[COS_STOCK] S LEFT JOIN COS_UNIT U"
            + " ON S.ST_UNIT = U.ST_UNIT WHERE S.DEPT='" + User._U_DEPT + "'  ORDER BY S.ST_NAME ASC";
                var dt = new DBClass().SqlGetData(sql);
                dgv1.DataSource = dt;
                dgv1.Columns[0].HeaderText = "รหัส";
                dgv1.Columns[1].HeaderText = "ชื่ออะไหล่";
                dgv1.Columns[2].HeaderText = "หน่วย";
                dgv1.Columns[3].HeaderText = "จำนวนในสต๊อก";
                dgv1.Columns[4].HeaderText = "ราคา";
                dgv1.Columns[5].HeaderText = "สถานะ";

                dgv1.Columns[0].Width = 40;
                dgv1.Columns[1].Width = 150;
                dgv1.Columns[2].Width = 100;
                dgv1.Columns[3].Width = 100;
                dgv1.Columns[4].Width = 100;
                dgv1.Columns[5].Width = 100;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void fmOnProgram_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    for (int i = 0; i < dgv1.RowCount; i++)
                    {
                        if (dgv1.Rows[i].Cells[1].Value.ToString() == txtST_NAME.Text)
                        {
                            MessageBox.Show("ชื่ออะไหล่ซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่มรายการอะไหล่ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var id = "SELECT MAX([ST_ID]) FROM [COS_STOCK]";
                        int ST_ID = new DBClass().AutoNunber(id);
                        var save = "insert into [COS_STOCK] ([ST_NAME],[ST_UNIT],[ST_IN],[ST_PRICE],[HIDE])VALUES ('" + txtST_NAME.Text + "','" + cbxST_UNIT.SelectedValue + "','" + nudST_IN.Value + "','" + txtST_PRICE.Text + "','Y')";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("บันทึกรายการอะไหล่เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขรายการอะไหล่ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update [COS_STOCK] set [ST_NAME]='" + txtST_NAME.Text + "',[ST_UNIT]='" + cbxST_UNIT.SelectedValue + "',[ST_IN]='" + nudST_IN.Value + "',[ST_PRICE]='" + txtST_PRICE.Text + "' WHERE [ST_ID]='" + dgv1.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไขรายการอะไหล่เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            btnSave1.Enabled = false;
            btnEdit1.Enabled = false;
            btnDelete1.Enabled = false;
            btnCancel1.Enabled = false;
            Edit = false;
            ClearText1();
            ShowData1();
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave1.Enabled = true;
                btnEdit1.Enabled = false;
                btnDelete1.Enabled = false;
                btnCancel1.Enabled = true;
                btnSave1.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int rowIndex = 0;

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tP1)
            {
                var dgv = dgv1;
                var cell = 5;
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
                var update = "update COS_STOCK set HIDE='" + dgv.SelectedCells[cell].Value + "' WHERE ST_ID='" + dgv.SelectedCells[cellID].Value + "'";
                int i2 = new DBClass().SqlExecute(update);
            }
            else if (tabControl1.SelectedTab == tP2)
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
                //else
                //{
                //    var dgv = dgv2_1;
                //    var cell = 6;
                //    var cellID0 = 0;
                //    var cellID1 = 1;
                //    if (ctmHide.Visible == true)
                //    {
                //        dgv[cell, rowIndex].Value = "Y";
                //    }
                //    else if (ctmHide.Visible == false)
                //    {
                //        dgv[cell, rowIndex].Value = "N";
                //    }
                //    dgv.UpdateCellValue(cell, rowIndex);
                //    dgv.Rows[rowIndex].Selected = true;
                //    var update = "update COS_PART_LIST_C set HIDE='" + dgv.SelectedCells[cell].Value + "' WHERE PL_ID='" + dgv.SelectedCells[cellID0].Value + "' AND PL_ID_C='"+dgv.SelectedCells[cellID1].Value+"'";
                //    int i2 = new DBClass().SqlExecute(update);
                //}
            }
            else if (tabControl1.SelectedTab == tP3)
            {
                var dgv = dgv3;
                var cell = 5;
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
                var update = "update COS_USER set U_HIDE='" + dgv.SelectedCells[cell].Value + "' WHERE U_ID='" + dgv.SelectedCells[cellID].Value + "'";
                int i2 = new DBClass().SqlExecute(update);
            }
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private void txtST_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                var sql = "SELECT [ST_ID],[ST_NAME],[ST_UNIT],[ST_IN],[ST_PRICE],[HIDE] FROM [COS_STOCK] WHERE ST_NAME LIKE '%" + txtST_NAME.Text + "%' ORDER BY ST_NAME ASC";
                var dt = new DBClass().SqlGetData(sql);
                dgv1.DataSource = dt;
                dgv1.Columns[0].HeaderText = "รหัส";
                dgv1.Columns[1].HeaderText = "ชื่ออะไหล่";
                dgv1.Columns[2].HeaderText = "หน่วย";
                dgv1.Columns[3].HeaderText = "จำนวนในสต๊อก";
                dgv1.Columns[4].HeaderText = "ราคา";
                dgv1.Columns[5].HeaderText = "สถานะ";

                dgv1.Columns[0].Width = 100;
                dgv1.Columns[1].Width = 150;
                dgv1.Columns[2].Width = 100;
                dgv1.Columns[3].Width = 100;
                dgv1.Columns[4].Width = 100;
                dgv1.Columns[5].Width = 100;
            }
            if (txtST_NAME.TextLength > 0)
            {
                btnSave1.Enabled = true;
                btnEdit1.Enabled = false;
                btnDelete1.Enabled = false;
                btnCancel1.Enabled = true;
            }
        }

        private void cbxST_UNIT_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "SELECT [ST_UNIT],[ST_NAME] FROM [COS_UNIT] WHERE HIDE='N'";
                DataTable dt1 = new DBClass().SqlGetData(sql);
                cbxST_UNIT.DataSource = dt1;
                cbxST_UNIT.ValueMember = "ST_UNIT";
                cbxST_UNIT.DisplayMember = "ST_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DBClass.tr.Rollback();
            }
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dgv1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dgv1.CurrentCell = this.dgv1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgv1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv1.SelectedCells[5].Value.ToString() == "N")
                {
                    ctmHide.Visible = true;
                    ctmShow.Visible = false;
                }
                else
                {
                    ctmHide.Visible = false;
                    ctmShow.Visible = true;
                }
                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;
                btnDelete1.Enabled = true;
                btnCancel1.Enabled = false;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                txtST_NAME.Text = dgv1.SelectedCells[1].Value.ToString();
                cbxST_UNIT.Text = dgv1.SelectedCells[2].Value.ToString();
                nudST_IN.Text = dgv1.SelectedCells[3].Value.ToString();
                txtST_PRICE.Text = dgv1.SelectedCells[4].Value.ToString();
                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;
                btnDelete1.Enabled = true;
                btnCancel1.Enabled = false;
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Selected == false)
            {
                return;
            }
            try
            {
                if (MessageBox.Show("คุณต้องการลบรายการอะไหล่ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "delete COS_STOCK WHERE ST_ID='" + dgv1.SelectedCells[0].Value + "'";
                    int isave = new DBClass().SqlExecute(save);
                    MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData1();
                    txtST_NAME.Text = "";
                    cbxST_UNIT.SelectedIndex = -1;
                    nudST_IN.Value = 1;
                    txtST_PRICE.Text = "";
                    txtST_NAME.Focus();
                    btnSave1.Enabled = false;
                    btnEdit1.Enabled = false;
                    btnDelete1.Enabled = false;
                    btnCancel1.Enabled = false;
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

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnEdit1.Enabled = false;
            btnDelete1.Enabled = false;
            btnCancel1.Enabled = false;
            Edit = false;
            dgv1.ClearSelection();
            ClearText1();
            txtST_NAME.Focus();
            ShowData1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddUnit f = new fmAddUnit();
            f.ShowDialog();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tP1)
            {
                ClearText1();
                ShowData1();
            }
            else if (tabControl1.SelectedTab == tP2)
            {
                ClearText2();
                ShowData2();
            }
            else if (tabControl1.SelectedTab == tP3)
            {
                ClearText3();
                ShowData3();
            }
        }

        private void ClearText1()
        {
            txtST_NAME.Text = "";
            cbxST_UNIT.SelectedIndex = -1;
            nudST_IN.Value = 1;
            txtST_PRICE.Text = "";
        }

        private void ClearText2()
        {
            cbxPL_NAME.SelectedIndex = -1;
            txtPL_BRAND.Text = "";
            txtPL_GEN.Text = "";
            txtPL_DESC_C.Text = "";
            txtPL_PRICE.Text = "";
        }

        private void ClearText3()
        {
            txtU_NAME.Text = "";
            txtU_NAME3.Text = "";
            txtU_PASSWORD.Text = "";
            cbxDEPT_NAME.SelectedIndex = -1;
        }

        private void ShowData3()
        {
            try
            {
                var dgv = dgv3;
                var sql = "SELECT [U_ID],[U_NAME],[U_LOGIN],UG.[U_USERGROUP_NAME],DC.DEPT_NAME,[U_HIDE]"
                        + " FROM [COS_USER] U"
                        + " LEFT JOIN COS_USERGROUP UG ON U.U_USERGROUP=UG.U_USERGROUP"
                        + " LEFT JOIN COS_DEPT_COS DC ON DC.ID=U.U_DEPT"
                        + " WHERE U_DEPT='" + User._U_DEPT + "' AND U_NAME LIKE '%" + txtU_NAME.Text + "%'"
                        + " ORDER BY U_NAME";
                var dt = new DBClass().SqlGetData(sql);
                dgv.DataSource = dt;
                dgv.Columns[0].HeaderText = "รหัส";
                dgv.Columns[1].HeaderText = "ชื่อผู้ใช้งานโปรแกรม";
                dgv.Columns[2].HeaderText = "ชื่อล็อกอิน";
                dgv.Columns[3].HeaderText = "ประเภทผู้ใช้งาน";
                dgv.Columns[4].HeaderText = "กลุ่มงาน";
                dgv.Columns[5].HeaderText = "สถานะ";

                dgv.Columns[0].Width = 40;
                dgv.Columns[1].Width = 220;
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].Width = 150;
                dgv.Columns[4].Width = 150;
                dgv.Columns[5].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Show Data " + ex.Message);
                //throw;
            }
            
        }

        private void ShowData2()
        {
            try
            {
                var sql = "select P.PL_ID,PL.PL_ID_C,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,U.ST_NAME,PL.PL_PRICE,P.HIDE"
                        + " from COS_PART_LIST P"
                        + " INNER JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " INNER JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
                        + " WHERE P.PL_DEPT = '" + User._U_DEPT + "' AND PL_NAME LIKE '%" + cbxPL_NAME.Text + "%' ORDER BY PL_NAME";
                var dt = new DBClass().SqlGetData(sql);
                dgv2.DataSource = dt;
                dgv2.Columns[0].Visible = false;
                dgv2.Columns[1].Visible = false;
                dgv2.Columns[0].HeaderText = "รหัส PL_ID";
                dgv2.Columns[1].HeaderText = "รหัส PL_ID_C";
                dgv2.Columns[2].HeaderText = "พัสดุ";
                dgv2.Columns[3].HeaderText = "แบรนด์";
                dgv2.Columns[4].HeaderText = "รุ่น";
                dgv2.Columns[5].HeaderText = "รายละเอียด";
                dgv2.Columns[6].HeaderText = "หน่วย";
                dgv2.Columns[7].HeaderText = "ราคา";
                dgv2.Columns[8].HeaderText = "สถานะ";

                dgv2.Columns[0].Width = 40;
                dgv2.Columns[1].Width = 40;
                dgv2.Columns[2].Width = 210;
                dgv2.Columns[3].Width = 134;
                dgv2.Columns[4].Width = 130;
                dgv2.Columns[5].Width = 150;
                dgv2.Columns[6].Width = 50;
                dgv2.Columns[7].Width = 70;
                dgv2.Columns[8].Width = 50;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    for (int i = 0; i < dgv2.RowCount; i++)
                    {
                        if (dgv2.Rows[i].Cells[1].Value.ToString() == txtST_NAME.Text)
                        {
                            MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่มรายการ" + text + "ที่สั่งซื้อ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    if (MessageBox.Show("คุณต้องการแก้ไขรายการ" + text + " " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void txtPL_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                ShowData2();
            }
            if (cbxPL_NAME.Text.Length > 0)
            {
                btnSave2.Enabled = true;
                btnEdit2.Enabled = false;
                btnDelete2.Enabled = false;
                btnCancel2.Enabled = true;
            }
        }

        private void dgv2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv2.ClearSelection();
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

        private void btnU_DEPT_Click(object sender, EventArgs e)
        {
            fmAddDEPT_COS f = new fmAddDEPT_COS();
            f.Show();
        }

        private void dgv3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv3.ClearSelection();
        }

        private void dgv3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = dgv3;
            var btnSave = btnSave3;
            var btnEdit = btnEdit3;
            var btnDelete = btnDelete3;
            var btnCancel = btnCancel3;
            if (e.Button == MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(dgv, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv.SelectedCells[5].Value.ToString() == "N")
                {
                    ctmHide.Visible = true;
                    ctmShow.Visible = false;
                }
                else
                {
                    ctmHide.Visible = false;
                    ctmShow.Visible = true;
                }
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                txtU_NAME.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtU_NAME3.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();

                try
                {
                    var sql = "SELECT U_USERGROUP,U_USERGROUP_NAME FROM COS_USERGROUP WHERE U_USERGROUP_NAME='" + dgv.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                    DataTable dt1 = new DBClass().SqlGetData(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                try
                {
                    var sql = "SELECT ID,DEPT_NAME FROM COS_DEPT_COS WHERE HIDE='N' AND  DEPT_NAME='" + dgv.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                    DataTable dt = new DBClass().SqlGetData(sql);
                    cbxDEPT_NAME.DataSource = dt;
                    cbxDEPT_NAME.ValueMember = "ID";
                    cbxDEPT_NAME.DisplayMember = "DEPT_NAME";
                    cbxDEPT_NAME.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void btnEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave3.Enabled = true;
                btnEdit3.Enabled = false;
                btnDelete3.Enabled = false;
                btnCancel3.Enabled = true;
                btnSave3.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            var dgv = dgv3;
            var btnSave = btnSave3;
            var btnEdit = btnEdit3;
            var btnDelete = btnDelete3;
            var btnCancel = btnCancel3;
            if (dgv.CurrentRow.Selected == false)
            {
                return;
            }

            try
            {
                if (MessageBox.Show("คุณต้องการลบ" + cbxPL_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var delete = "delete COS_USER WHERE U_ID='" + dgv.SelectedCells[0].Value + "'";
                    int idelete = new DBClass().SqlExecute(delete);
                    MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData3();
                    ClearText3();
                    txtU_NAME.Focus();
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

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            var dgv = dgv3;
            var btnSave = btnSave3;
            var btnEdit = btnEdit3;
            var btnDelete = btnDelete3;
            var btnCancel = btnCancel3;

            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            Edit = false;
            dgv.ClearSelection();
            ShowData3();
            txtU_NAME.Focus();
            ClearText3();
        }

        private void cbxDEPT_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "SELECT ID,DEPT_NAME FROM COS_DEPT_COS WHERE HIDE='N'";
                DataTable dt = new DBClass().SqlGetData(sql);
                cbxDEPT_NAME.DataSource = dt;
                cbxDEPT_NAME.ValueMember = "ID";
                cbxDEPT_NAME.DisplayMember = "DEPT_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbxDEPT_NAME_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void txtU_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                ShowData3();
            }
            if (txtU_NAME.TextLength > 0)
            {
                btnSave3.Enabled = true;
                btnEdit3.Enabled = false;
                btnDelete3.Enabled = false;
                btnCancel3.Enabled = true;
            }
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            var dgv = dgv3;
            var text = "ผู้ใช้งาน";
            if (Edit == false)
            {
                try
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (dgv.Rows[i].Cells[1].Value.ToString() == txtST_NAME.Text)
                        {
                            MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่ม" + text + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "insert into COS_USER (U_NAME,U_LOGIN,U_PASSWORD,U_DEPT,U_HIDE,U_TEST)VALUES"
                            + "('" + txtU_NAME.Text + "','" + txtU_NAME3.Text + "','" + txtU_PASSWORD.Text + "','" + cbxDEPT_NAME.SelectedValue + "','N','N')";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("บันทึกรายการอะไหล่เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขรายการอะไหล่ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var edit = "";
                        if (txtU_PASSWORD.TextLength > 0)
                        {
                            edit = "update COS_USER set U_NAME='" + txtU_NAME.Text + "',U_LOGIN='" + txtU_NAME3.Text + "',U_PASSWORD='" + txtU_PASSWORD.Text + "' WHERE [U_ID]='" + dgv.SelectedCells[0].Value + "'";
                        }
                        else
                        {
                            edit = "update COS_USER set U_NAME='" + txtU_NAME.Text + "',U_LOGIN='" + txtU_NAME3.Text + "' WHERE [U_ID]='" + dgv.SelectedCells[0].Value + "'";
                        }
                        int iedit = new DBClass().SqlExecute(edit);
                        MessageBox.Show("แก้ไขรายการอะไหล่เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            btnSave3.Enabled = false;
            btnEdit3.Enabled = false;
            btnDelete3.Enabled = false;
            btnCancel3.Enabled = false;
            Edit = false;
            ClearText3();
            ShowData3();
        }

        private void cbxPL_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var cbx = "SELECT [PL_ID],[PL_NAME] FROM [COS_PART_LIST] WHERE PL_DEPT='"+User._U_DEPT+"' ORDER BY PL_NAME";
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

        private void cbxPL_NAME_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                var sql = "select P.PL_ID,PL.PL_ID_C,PL_NAME,PL_BRAND,PL_GEN,PL_DESC_C,U.ST_NAME,PL.PL_PRICE,P.HIDE"
                        + " from COS_PART_LIST P"
                        + " INNER JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID"
                        + " INNER JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT"
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
            if (txtST_NAME.TextLength > 0)
            {
                btnSave1.Enabled = true;
                btnEdit1.Enabled = false;
                btnDelete1.Enabled = false;
                btnCancel1.Enabled = true;
            }
            btnSave2.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fmAddPartList f = new fmAddPartList();
            f.Show();
        }

        private void dgv2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgv2.ClearSelection();
        }
    }
}