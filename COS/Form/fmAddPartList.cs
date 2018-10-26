using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmAddPartList : Form
    {
        private bool Edit;
        private int rowIndex = 0;

        public fmAddPartList()
        {
            InitializeComponent();
        }

        private void fmAddPartList_Load(object sender, EventArgs e)
        {
            ShowData1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxST_NAME.Text == "")
            {
                MessageBox.Show("กรุณาเลือกหน่วยของพัสดุ", "คำเตือน");
                return;
            }
            var text = "ประเภทผู้ใช้";
            if (Edit == false)
            {
                //try
                //{
                for (int i = 0; i < dgv1.RowCount; i++)
                {
                    if (dgv1.Rows[i].Cells[1].Value.ToString() == txtPL_NAM.Text)
                    {
                        MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                        return;
                    }
                }
                if (MessageBox.Show("คุณต้องการเพิ่ม" + text + txtPL_NAM.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var save = "insert into COS_PART_LIST (PL_NAME,PL_UNIT,PL_DEPT,HIDE)VALUES ('" + txtPL_NAM.Text + "','" + cbxST_NAME.SelectedValue + "','" + User._U_DEPT + "','N'" + ")";
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
                    string HIDE = "";
                    if (cbxST_NAME.Text != dgv1.SelectedCells[1].Value.ToString())
                    {
                        HIDE = ",PL_UNIT='" + cbxST_NAME.SelectedValue + "";
                    }
                    else
                    {
                        HIDE = "";
                    }
                    if (MessageBox.Show("คุณต้องการแก้ไข" + text + txtPL_NAM.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var edit = "update COS_PART_LIST set PL_NAME='" + txtPL_NAM.Text + "'" + HIDE + "' WHERE PL_ID='" + dgv1.SelectedCells[0].Value + "'";
                        int isave = new DBClass().SqlExecute(edit);
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
            txtPL_NAM.Text = "";
            ShowData1();
        }

        private void ShowData1()
        {
            var sql = "SELECT [PL_ID],[PL_NAME],U.ST_NAME,PL.[HIDE]"
                        + " FROM[COS_PART_LIST] PL LEFT JOIN COS_UNIT U ON PL.PL_UNIT = U.ST_UNIT"
                        + " WHERE PL_DEPT = '" + User._U_DEPT + "' AND PL_NAME LIKE '%" + txtPL_NAM.Text + "%'"
                        + " ORDER BY [PL_NAME]";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "รหัส";
            dgv1.Columns[1].HeaderText = "ชื่อพัสดุ";
            dgv1.Columns[2].HeaderText = "หน่วย";
            dgv1.Columns[3].HeaderText = "สถานะ";

            dgv1.Columns[0].Width = 40;
            dgv1.Columns[1].Width = 200;
            dgv1.Columns[2].Width = 80;
            dgv1.Columns[3].Width = 80;
        }

        private void cbxST_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "SELECT [ST_UNIT],[ST_NAME] FROM [COS_UNIT]WHERE HIDE='N'  ORDER BY ST_NAME";
                var dt = new DBClass().SqlGetData(sql);
                cbxST_NAME.DataSource = dt;
                cbxST_NAME.ValueMember = "ST_UNIT";
                cbxST_NAME.DisplayMember = "ST_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
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
                txtPL_NAM.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbxST_NAME.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void txtPL_NAM_KeyUp(object sender, KeyEventArgs e)
        {
            if (Edit == false)
            {
                ShowData1();
            }
            if (txtPL_NAM.TextLength > 0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                txtPL_NAM.Text = dgv1.SelectedCells[1].Value.ToString();
                button1.Focus();
                Edit = true;
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Edit = false;
            dgv1.ClearSelection();
            txtPL_NAM.Text = "";
            txtPL_NAM.Focus();
            ShowData1();
        }

        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv1.ClearSelection();
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //if (!this.dgv1.Rows[rowIndex].IsNewRow)
            //{
            //    //try
            //    //{
            //    if (ctmHide.Visible == true)
            //    {
            //        dgv1[3, rowIndex].Value = "N";
            //    }
            //    else if (ctmHide.Visible == false)
            //    {
            //        dgv1[3, rowIndex].Value = "Y";
            //    }
            //    dgv1.UpdateCellValue(3, rowIndex);
            //    var update = "update COS_PART_LIST set HIDE='" + dgv1.SelectedCells[3].Value + "' WHERE PL_ID='" + dgv1.SelectedCells[0].Value + "'";
            //    int i2 = new DBClass().SqlExecute(update);
            //    dgv1.Rows[rowIndex].Selected = true;
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    MessageBox.Show(ex.Message);
            //    //}
            //}
        }

        private void contextMenuStrip1_Click_1(object sender, EventArgs e)
        {
            var dgv = dgv1;
            var cell = 3;
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