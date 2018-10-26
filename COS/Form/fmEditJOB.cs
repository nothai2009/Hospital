using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmEditJOB : Form
    {
        public fmEditJOB(string JOBID)
        {
            InitializeComponent();

            txtJOBID.Text = JOBID;
            txtCARUCODE.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var sql_update = "UPDATE COS_JOB SET CARUCODE=@CARUCODE, CARUNO=@CARUNO WHERE JOBID='" + txtJOBID.Text + "'";
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@CARUCODE", SqlDbType.Char).Value = txtCARUCODE.Text;
                param.AddWithValue("@CARUNO", SqlDbType.Char).Value = txtCARUNO.Text;
                int i2 = new DBClass().SqlExecute(sql_update, param);
                MessageBox.Show("แก้ไขเรียบร้อยแล้ว");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด " + ex.Message);
            }
        }

        private void btnEnabled()
        {
            if (txtCARUCODE.Text.Length > 0 && txtCARUNO.Text.Length > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void txtCARUCODE_TextChanged(object sender, EventArgs e)
        {
            btnEnabled();
            var dgv = dgv1;
            cbxDEPT(dgv);
        }

        private void txtCARUCODE_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = dgv1;
            if (e.KeyCode == Keys.Enter)
            {
                txtCARUCODE.Text = dgv.SelectedCells[1].Value.ToString();
                txtCARUNO.Text = "";
                txtSPEC.Text = "";
                txtCARUNO.Focus();
                dgv.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                dgv1.Focus();
            }
            else
            {
                dgv.Visible = true;
                cbxDEPT(dgv);
            }
        }

        private void txtCARUCODE_MouseClick(object sender, MouseEventArgs e)
        {
            txtCARUCODE.Text = "";
            var dgv = dgv1;
            dgv.Visible = true;
            cbxDEPT(dgv);
        }

        void cbxDEPT(DataGridView dgv)
        {
            var txtSearch = txtCARUCODE.Text;
            var sql = "SELECT [CARUCODE]+' '+NAME AS [CT_NAME],[CARUCODE]"
                    + " FROM[CARU2CODE] c2c with(nolock)"
                    + " LEFT JOIN[CARU2GROUP] c2g ON c2c.CARUGROUP = c2g.GROUPCODE"
                    + " WHERE[CARUGROUP] = '11' AND HIDE = 'N'"
                    + " AND [CARUCODE] + ' ' + NAME LIKE '%" + txtSearch + "%'"
                    + " GRoUP BY[CARUCODE],[CARUGROUP], GROUPNAME,[NAME],[UNIT],[REDUCE],[CARUTYPE],[HIDE]"
                    + " ORDER BY CARUCODE";
            var dt = new DBClass().SqlGetData(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 440;
            dgv.Columns[0].HeaderText = "หน่วยงาน";
            dgv.Columns[1].Visible = false;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgv1;
            txtCARUCODE.Text = dgv.SelectedCells[1].Value.ToString();
            dgv.Visible = false;
        }

        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtCARUCODE.Focus();
            }
            else
            {
                txtCARUCODE.Focus();
            }
        }

        private void txtCARUNO_TextChanged_1(object sender, EventArgs e)
        {
            btnEnabled();
            try
            {
                txtSPEC.Text = "";
                var sql = "SELECT TOP 1 [SPEC]FROM [CARU2CARU]WHERE CARUCODE='" + txtCARUCODE.Text + "' AND CARUNO='" + txtCARUNO.Text + "'";
                var dt = new DBClass().SqlGetData(sql);
                txtSPEC.Text = dt.Rows[0][0].ToString();
            }
            catch
            {
            }
        }

        private void fmEditJOB_Load(object sender, EventArgs e)
        {
            dgv1.Size = new Size(440, 410);
        }
    }
}