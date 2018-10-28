using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmUserAdd : Form
    {
        private bool Edit;

        public fmUserAdd()
        {
            InitializeComponent();
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
                        if (dgv.Rows[i].Cells[1].Value.ToString() == txtU_NAME.Text)
                        {
                            MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่ม" + text + txtU_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    if (MessageBox.Show("คุณต้องการแก้ไขรายการอะไหล่ " + txtU_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void ClearText3()
        {
            txtU_NAME.Text = "";
            txtU_NAME3.Text = "";
            txtU_PASSWORD.Text = "";
            cbxDEPT_NAME.SelectedIndex = -1;
        }

        private void ShowData3()
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
                if (MessageBox.Show("คุณต้องการลบ" + txtU_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
    }
}