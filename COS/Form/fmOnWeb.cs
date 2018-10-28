using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmOnWeb : Form
    {
        private bool Edit = false;

        public fmOnWeb()
        {
            InitializeComponent();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tP1)
            {
                ShowData1();
                txtCAUSE_NAME.Text = "";
                txtCT_ID.Text = "";
                txtCT_NAME.Text = "";
                txtDeptName.Focus();
            }
            else if (tabControl1.SelectedTab == tP2)
            {
                //ShowData2();
                txtDeptName.Text = "";
                txtCAUSE_NAME.Text = "";
                txtCT_ID.Focus();
            }
            else if (tabControl1.SelectedTab == tP3)
            {
                ShowData3();
                txtDeptName.Text = "";
                txtCT_ID.Text = "";
                txtCT_NAME.Text = "";
                txtCAUSE_NAME.Focus();
            }
        }

        private void ShowData1()
        {
            var sql = "SELECT DEPCODE,RTRIM(DEPNAME),HIDE FROM MUHDEP WHERE (HIDE='N' OR HIDE IS NULL) ORDER BY DEPNAME ASC";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "รหัส";
            dgv1.Columns[1].HeaderText = "ชื่อหน่วยงาน";
            dgv1.Columns[2].HeaderText = "สถานะ";

            dgv1.Columns[0].Width = 100;
            dgv1.Columns[1].Width = 350;
            dgv1.Columns[2].Width = 100;
        }

        private void ShowData2()
        {
            var sql = "SELECT [CT_ID],[CT_NAME],[HIDE] FROM [CARU2_COS_NEW_CARU_TYPE] WHERE HIDE='N' ORDER BY CT_NAME ASC";
            var dt = new DBClass().SqlGetData(sql);
            dgv2.DataSource = dt;
            dgv2.Columns[0].HeaderText = "รหัส";
            dgv2.Columns[1].HeaderText = "ชื่อครุภัณฑ์";
            dgv2.Columns[2].HeaderText = "สถานะ";

            dgv2.Columns[0].Width = 100;
            dgv2.Columns[1].Width = 350;
            dgv2.Columns[2].Width = 100;
        }

        private void ShowData3()
        {
            var sql = "SELECT CAUSE_ID,CAUSE_NAME,HIDE FROM COS_CAUSE_TYPE WHERE HIDE='N' AND DEPT='" + User._U_DEPT + "'ORDER BY CAUSE_NAME ASC";
            var dt = new DBClass().SqlGetData(sql);
            dgv3.DataSource = dt;
            dgv3.Columns[0].HeaderText = "รหัส";
            dgv3.Columns[1].HeaderText = "ชื่ออาการเสีย";
            dgv3.Columns[2].HeaderText = "สถานะ";

            dgv3.Columns[0].Width = 100;
            dgv3.Columns[1].Width = 350;
            dgv3.Columns[2].Width = 100;
        }

        private void fmOnWeb_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
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
                if (dgv1.SelectedCells[2].Value.ToString() == "N")
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
                btnCancel1.Enabled = true;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                txtDeptName.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;
                btnDelete1.Enabled = true;
                btnCancel1.Enabled = true;
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dgv1.Rows[this.rowIndex].IsNewRow)
            {
                if (tabControl1.SelectedTab == tP1)
                {
                    try
                    {
                        if (ctmHide.Visible == true)
                        {
                            dgv1[2, rowIndex].Value = "Y";
                        }
                        else if (ctmHide.Visible == false)
                        {
                            dgv1[2, rowIndex].Value = "N";
                        }
                        dgv1.UpdateCellValue(2, rowIndex);
                        dgv1.Rows[rowIndex].Selected = true;
                        var update = "update MUHDEP set HIDE='" + dgv1.SelectedCells[2].Value + "' WHERE DEPT='" + dgv1.SelectedCells[0].Value + "'";
                        //int i2 = new DBClass().SqlExecute(update);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tP2)
                {
                    try
                    {
                        if (ctmHide.Visible == true)
                        {
                            dgv2[2, rowIndex].Value = "Y";
                        }
                        else if (ctmHide.Visible == false)
                        {
                            dgv2[2, rowIndex].Value = "N";
                        }
                        dgv2.UpdateCellValue(2, rowIndex);
                        dgv2.Rows[rowIndex].Selected = true;
                        var update = "update CARU2_COS_NEW_CARU_TYPE set HIDE='" + dgv2.SelectedCells[2].Value + "' WHERE CT_ID='" + dgv2.SelectedCells[0].Value + "'";
                        //int i2 = new DBClass().SqlExecute(update);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tP3)
                {
                    try
                    {
                        if (ctmHide.Visible == true)
                        {
                            dgv3[2, rowIndex].Value = "Y";
                        }
                        else if (ctmHide.Visible == false)
                        {
                            dgv3[2, rowIndex].Value = "N";
                        }
                        dgv3.UpdateCellValue(2, rowIndex);
                        dgv3.Rows[rowIndex].Selected = true;
                        var update = "update COS_CAUSE_TYPE set HIDE='" + dgv3.SelectedCells[2].Value + "' WHERE CAUSE_ID='" + dgv3.SelectedCells[0].Value + "'";
                        int i2 = new DBClass().SqlExecute(update);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    for (int i = 0; i < dgv1.RowCount; i++)
                    {
                        if (dgv1.Rows[i].Cells[1].Value.ToString() == txtDeptName.Text)
                        {
                            MessageBox.Show("ชื่อหน่วยงานซ้ำ", "คำเตือน");
                            return;
                        }
                    }

                    //start เช็คชื่อหน่วยงานในฐานว่าซ้ำกับที่จะเพิ่มหรือไม่
                    var deptName = "SELECT DEPNAME from MUHDEP WHERE DEPNAME = '" + txtDeptName.Text + "' GROUP BY DEPNAME HAVING  COUNT(DEPNAME) > 1";
                    var d = new DBClass().SqlGetData(deptName);
                    deptName = d.Rows[0][0].ToString();
                    if (deptName == txtDeptName.Text)
                    {
                        MessageBox.Show("ชื่อหน่วยงานซ้ำ", "คำเตือน");
                        return;
                    }
                    //end

                    if (MessageBox.Show("คุณต้องการเพิ่มหน่วยงาน " + txtDeptName.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var id = "SELECT MAX(DEPT) FROM MUHDEP";
                        int dept_id = new DBClass().AutoNunber(id);
                        var save = "insert into COS_NEW_DEPT (DEPT,deptname,HIDE)VALUES ('" + dept_id + "','" + txtDeptName.Text + "','N')";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("บันทึกหน่วยงานเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขหน่วยงาน " + txtDeptName.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update COS_NEW_DEPT set deptname='" + txtDeptName.Text + "' WHERE DEPT='" + dgv1.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไขหน่วยงานเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtDeptName.Text = "";
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
                txtDeptName.Text = dgv1.SelectedCells[1].Value.ToString();
                btnSave1.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (MessageBox.Show("คุณต้องการลบหน่วยงาน " + txtDeptName.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "delete MUHDEP WHERE DEPT='" + dgv1.SelectedCells[0].Value + "'";
                    //int isave = new DBClass().SqlExecute(save);
                    //MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData1();
                    txtDeptName.Text = "";
                    txtDeptName.Focus();
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

        private void txtDeptName_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                var sql = "SELECT DEPCODE,RTRIM(DEPNAME)AS DEPTNAME,HIDE " +
                    "FROM MUHDEP WHERE DEPNAME LIKE '%" + txtDeptName.Text + "%' AND (HIDE='N' OR HIDE IS NULL) ORDER BY DEPNAME ASC ";
                var dt = new DBClass().SqlGetData(sql);
                dgv1.DataSource = dt;
                dgv1.Columns[0].HeaderText = "รหัส";
                dgv1.Columns[1].HeaderText = "ชื่อหน่วยงาน";
                dgv1.Columns[2].HeaderText = "สถานะ";

                dgv1.Columns[0].Width = 100;
                dgv1.Columns[1].Width = 150;
                dgv1.Columns[2].Width = 100;
            }
            if (txtDeptName.TextLength > 0)
            {
                btnSave1.Enabled = true;
                btnEdit1.Enabled = false;
                btnDelete1.Enabled = false;
                btnCancel1.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnEdit1.Enabled = false;
            btnDelete1.Enabled = false;
            btnCancel1.Enabled = false;
            Edit = false;
            dgv1.ClearSelection();
            txtDeptName.Text = "";
            txtDeptName.Focus();
            ShowData1();
        }

        private void txtDeptName_MouseClick(object sender, MouseEventArgs e)
        {
            if (Edit == false)
            {
                txtDeptName.Text = "";
                txtDeptName.Focus();
                dgv1.ClearSelection();
            }
        }

        private void dgv2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv2.ClearSelection();
        }

        private void dgv3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv3.ClearSelection();
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
                if (dgv2.SelectedCells[2].Value.ToString() == "N")
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
                btnCancel2.Enabled = true;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                txtDeptName.Text = dgv2.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnSave2.Enabled = false;
                btnEdit2.Enabled = true;
                btnDelete2.Enabled = true;
                btnCancel2.Enabled = true;
            }
        }

        private void dgv3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dgv3.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dgv3.CurrentCell = this.dgv3.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgv3, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv3.SelectedCells[2].Value.ToString() == "N")
                {
                    ctmHide.Visible = true;
                    ctmShow.Visible = false;
                }
                else
                {
                    ctmHide.Visible = false;
                    ctmShow.Visible = true;
                }
                btnSave3.Enabled = false;
                btnEdit3.Enabled = true;
                btnDelete3.Enabled = true;
                btnCancel3.Enabled = true;
            }
            else
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                txtCAUSE_NAME.Text = dgv3.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnSave3.Enabled = false;
                btnEdit3.Enabled = true;
                btnDelete3.Enabled = true;
                btnCancel3.Enabled = true;
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            btnSave2.Enabled = false;
            btnEdit2.Enabled = false;
            btnDelete2.Enabled = false;
            btnCancel2.Enabled = false;
            Edit = false;
            dgv2.ClearSelection();
            txtCT_ID.Text = "";
            txtCT_NAME.Text = "";
            txtCT_ID.Focus();
            ShowData2();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            btnSave3.Enabled = false;
            btnEdit3.Enabled = false;
            btnDelete3.Enabled = false;
            btnCancel3.Enabled = false;
            Edit = false;
            dgv3.ClearSelection();
            txtCAUSE_NAME.Text = "";
            txtCAUSE_NAME.Focus();
            ShowData3();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    for (int i = 0; i < dgv2.RowCount; i++)
                    {
                        if (dgv2.Rows[i].Cells[1].Value.ToString() == txtDeptName.Text)
                        {
                            MessageBox.Show("ชื่อครุภัณฑ์ซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่มครุภัณฑ์ " + txtDeptName.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "insert into [CARU2_COS_NEW_CARU_TYPE] (CT_ID,CT_NAME,HIDE)VALUES ('" + txtCT_ID.Text + "','" + txtCT_NAME.Text + "','N')";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("บันทึกครุภัณฑ์เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขครุภัณฑ์ " + txtDeptName.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update CARU2_COS_NEW_CARU_TYPE set CT_NAME='" + txtCT_NAME.Text + "' WHERE CT_ID='" + dgv2.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไขครุภัณฑ์เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCT_ID.Text = "";
            txtCT_NAME.Text = "";
            ShowData2();
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            var txtcauseName = txtCAUSE_NAME.Text;
            if (Edit == false)
            {
                //try
                //{
                for (int i = 0; i < dgv3.RowCount; i++)
                {
                    if (dgv3.Rows[i].Cells[1].Value.ToString() == txtcauseName)
                    {
                        MessageBox.Show("ชื่ออาการซ้ำ", "คำเตือน");
                        return;
                    }
                }

                //start เช็คชื่อหน่วยงานในฐานว่าซ้ำกับที่จะเพิ่มหรือไม่
                try
                {
                    var causeName = "SELECT CAUSE_NAME FROM COS_CAUSE_TYPE WHERE CAUSE_NAME = '" + txtcauseName + "' AND DEPT='" + User._U_DEPT + "' GROUP BY CAUSE_NAME HAVING  COUNT(CAUSE_NAME) > 1";
                    var d = new DBClass().SqlGetData(causeName);
                    causeName = d.Rows[0][0].ToString();
                    if (causeName == txtcauseName)
                    {
                        MessageBox.Show("ชื่อหน่วยงานซ้ำ", "คำเตือน");
                        return;
                    }
                    //end
                }
                catch
                {
                }
                if (MessageBox.Show("คุณต้องการเพิ่มอาการ " + txtcauseName + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = "SELECT MAX(CAUSE_ID) FROM COS_CAUSE_TYPE";
                    int ct_id = new DBClass().AutoNunber(id);
                    var save = "insert into [COS_CAUSE_TYPE] (CAUSE_ID,CAUSE_NAME,HIDE,DEPT)VALUES ('" + ct_id + "','" + txtcauseName + "','N','" + User._U_DEPT + "')";
                    int isave = new DBClass().SqlExecute(save);
                    MessageBox.Show("บันทึกอาการเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show("คุณต้องการแก้ไขอาการ " + txtcauseName + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "update COS_CAUSE_TYPE set CAUSE_NAME='" + txtcauseName + "' WHERE CAUSE_ID='" + dgv3.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(save);
                        MessageBox.Show("แก้ไขอาการเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtcauseName = "";
            ShowData3();
        }

        private void txtCT_ID_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                var sql = "SELECT CT_ID,CT_NAME,HIDE FROM [CARU2_COS_NEW_CARU_TYPE] WHERE CT_NAME LIKE '%" + txtCT_NAME.Text + "%' AND HIDE='N' ORDER BY CT_NAME ASC ";
                var dt = new DBClass().SqlGetData(sql);
                dgv2.DataSource = dt;
                dgv2.Columns[0].HeaderText = "รหัส";
                dgv2.Columns[1].HeaderText = "ชื่อครุภัณฑ์";
                dgv2.Columns[2].HeaderText = "สถานะ";

                dgv2.Columns[0].Width = 100;
                dgv2.Columns[1].Width = 150;
                dgv2.Columns[2].Width = 100;
            }
            if (txtCT_ID.TextLength > 0)
            {
                btnSave2.Enabled = true;
                btnEdit2.Enabled = false;
                btnDelete2.Enabled = false;
                btnCancel2.Enabled = true;
            }
        }

        private void txtCAUSE_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                var sql = "SELECT CAUSE_ID,CAUSE_NAME,HIDE FROM [COS_CAUSE_TYPE] WHERE CAUSE_NAME LIKE '%" + txtCAUSE_NAME.Text + "%' AND HIDE='N' AND DEPT='" + User._U_DEPT + "' ORDER BY CAUSE_NAME ASC ";
                var dt = new DBClass().SqlGetData(sql);
                dgv3.DataSource = dt;
                dgv3.Columns[0].HeaderText = "รหัส";
                dgv3.Columns[1].HeaderText = "ชื่ออาการ";
                dgv3.Columns[2].HeaderText = "สถานะ";

                dgv3.Columns[0].Width = 100;
                dgv3.Columns[1].Width = 150;
                dgv3.Columns[2].Width = 100;
            }
            if (txtCAUSE_NAME.TextLength > 0)
            {
                btnSave3.Enabled = true;
                btnEdit3.Enabled = false;
                btnDelete3.Enabled = false;
                btnCancel3.Enabled = true;
            }
        }

        private void txtCT_ID_MouseClick(object sender, MouseEventArgs e)
        {
            if (Edit == false)
            {
                txtCT_ID.Text = "";
                txtCT_NAME.Text = "";
                txtCT_ID.Focus();
                dgv2.ClearSelection();
            }
        }

        private void txtCAUSE_NAME_MouseClick(object sender, MouseEventArgs e)
        {
            if (Edit == false)
            {
                txtCAUSE_NAME.Text = "";
                txtCAUSE_NAME.Focus();
                dgv3.ClearSelection();
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
                txtCT_ID.Text = dgv2.SelectedCells[0].Value.ToString();
                txtCT_NAME.Text = dgv2.SelectedCells[1].Value.ToString();
                btnSave2.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                txtCAUSE_NAME.Text = dgv3.SelectedCells[1].Value.ToString();
                btnSave3.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (dgv2.CurrentRow.Selected == false)
            {
                return;
            }
            try
            {
                if (MessageBox.Show("คุณต้องการลบครุภัณฑ์ " + txtCT_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var delete = "delete [CARU2_COS_NEW_CARU_TYPE] WHERE CT_ID='" + dgv2.SelectedCells[0].Value + "'";
                    //int isave = new DBClass().SqlExecute(delete);
                    //MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData2();
                    txtCT_ID.Text = "";
                    txtCT_NAME.Text = "";
                    txtCT_ID.Focus();
                    btnSave2.Enabled = false;
                    btnEdit2.Enabled = false;
                    btnDelete2.Enabled = false;
                    btnCancel2.Enabled = false;
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

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (dgv3.CurrentRow.Selected == false)
            {
                return;
            }
            try
            {
                if (MessageBox.Show("คุณต้องการลบอาการ " + txtCAUSE_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var delete = "delete [COS_CAUSE_TYPE] WHERE CAUSE_ID='" + dgv3.SelectedCells[0].Value + "'";
                    //int isave = new DBClass().SqlExecute(delete);
                    //MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData3();
                    txtCAUSE_NAME.Text = "";
                    txtCAUSE_NAME.Focus();
                    btnSave3.Enabled = false;
                    btnEdit3.Enabled = false;
                    btnDelete3.Enabled = false;
                    btnCancel3.Enabled = false;
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
    }
}