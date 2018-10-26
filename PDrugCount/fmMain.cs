using COS;
using System.Drawing;
using System.Windows.Forms;
using UDH;

namespace PDrugCount
{
    public partial class fmMain : Form
    {
        private fmSettingConfig f = new fmSettingConfig();
        private DBClass db = new DBClass();

        //Menu
        #region

        private void MenuSetting_Click(object sender, System.EventArgs e)
        {
            f.ShowDialog();
        }

        #endregion

        public fmMain()
        {
            InitializeComponent();

            txtSearchabbr.Focus();
            //ความสูงของ datagridview
            dgvSearchabbr.Size = new Size(450, 350);
        }

        private void fmMain_Load(object sender, System.EventArgs e)
        {
            //อ่านการตั้งค่าการเชื่อมต่อฐานข้อมูล ไฟล์ ini
            f.ReadINI();
            if (f._servername == "" || f._username == "" || f._password == "" || f._database == "")
            {
                f.ShowDialog();
            }

            //set label server :
            lbServer.Text = "Server : " + f._servername;
            lbDatabase.Text = "Database : " + f._database;
            lbVersion.Text = ProductVersion;

            var sql = "SELECT * FROM Med_inv";
            bindingSource1.DataSource = db.SqlGetData(sql);

            bindingNavigator1.BindingSource = this.bindingSource1;
            txtabbr.DataBindings.Add(new Binding("Text", bindingSource1, "abbr", true));
            txtgen_name.DataBindings.Add(new Binding("Text", bindingSource1, "gen_name", true));
        }

        private void txtSearchabbr_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = dgvSearchabbr;
            if (e.KeyCode == Keys.Enter)
            {
                txtSearchabbr.Text = dgv.SelectedCells[0].Value.ToString();
                dgv.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                dgvSearchabbr.Focus();
            }
            else
            {
                dgv.Visible = true;
                cbxDEPT(dgv);
            }
        }

        private void txtSearchabbr_MouseClick(object sender, MouseEventArgs e)
        {
            var dgv = dgvSearchabbr;
            dgv.Visible = true;
            cbxDEPT(dgv);
        }

        private void txtSearchabbr_TextChanged(object sender, System.EventArgs e)
        {
            var dgv = dgvSearchabbr;
            cbxDEPT(dgv);
        }

        private void cbxDEPT(DataGridView dgv)
        {
            try
            {
                var txtSearch = txtSearchabbr.Text;
                var sql = "SELECT abbr, gen_name FROM Med_inv WHERE abbr  + ' ' + gen_name  LIKE '%" + txtSearch.ToUpper() + "%'";
                var dt = new DBClass().SqlGetData(sql);
                dgv.DataSource = dt;
                dgv.Columns[0].Width = 70;
                dgv.Columns[1].Width = 250;
                dgv.Columns[0].HeaderText = "รหัสยา";
                dgv.Columns[1].HeaderText = "ชื่อยา";
                //dgv.Columns[1].Visible = false;
            }
            catch
            {
            }
        }

        private void dgvSearchabbr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgvSearchabbr;
            txtSearchabbr.Text = dgv.SelectedCells[0].Value.ToString();
            dgv.Visible = false;
            btnInsert1.Focus();
        }

        private void dgvSearchabbr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtSearchabbr.Focus();
            }
            else
            {
                txtSearchabbr.Focus();
            }
        }

        private void fmMain_Click(object sender, System.EventArgs e)
        {
            var dgv = dgvSearchabbr;
            dgv.Visible = false;
        }

        private void txtabbr_TextChanged(object sender, System.EventArgs e)
        {
            var sql1 = "SELECT abbr, hideSelect,LTRIM(RTRIM(gen_name)) AS gen_name, RTRIM(dform)AS dform, RTRIM(strgth)AS strgth, RTRIM(strgth_u)AS strgth_u,ltrim(opd_prc)AS opd_prc,pt.ed_group,[ed_list],prod_type,AutoStop " +
                "FROM Med_inv inv LEFT JOIN[PRODTYPE] pt WITH(NOLOCK) ON inv.prod_type = pt.[prdTypeCode] " +
                "WHERE abbr +' ' + gen_name LIKE '%" + txtabbr.Text + "%'";
            var dt1 = new DBClass().SqlGetData(sql1);
            txtabbr.Text = dt1.Rows[0][0].ToString();
            var hideSelect = dt1.Rows[0][1].ToString();
            if (hideSelect == "Y")
            {
                rdohideSelectY.Checked = true;
                rdohideSelectN.Checked = false;
            }
            else if ((hideSelect == "N"))
            {
                rdohideSelectY.Checked = false;
                rdohideSelectN.Checked = true;
            }
            txtgen_name.Text = dt1.Rows[0][2].ToString();
            txtdform.Text = dt1.Rows[0][3].ToString();
            txtstrgth.Text = dt1.Rows[0][4].ToString();
            txtstrgth_u.Text = dt1.Rows[0][5].ToString();
            txtopd_prc.Text = dt1.Rows[0][6].ToString();
            txted.Text = dt1.Rows[0][7].ToString();
            
            if (dt1.Rows[0][8].ToString() != "")
            {
                cbxed_list.Items.Add(dt1.Rows[0][8].ToString());
                cbxed_list.SelectedIndex = 0;
            }
            else
            {
                cbxed_list.SelectedIndex = -1;
            }
            txtprod_type.Text = dt1.Rows[0][9].ToString();

            var AutoStop = dt1.Rows[0][10].ToString();
            if (AutoStop == "Y")
            {
                rdohideSelectY.Checked = true;
                rdohideSelectN.Checked = false;
            }
            else
            {
                rdohideSelectY.Checked = false;
                rdohideSelectN.Checked = true;
            }
        }

        private void cbxed_group_Click(object sender, System.EventArgs e)
        {
            var cbx = cbxed_list;
            //cbx.Items.Clear();
        }

        private void cbxed_group_DropDown(object sender, System.EventArgs e)
        {
            var cbx = cbxed_list;
            //cbx.DataSource = null;
            //cbx.Items.Clear();
        }
    }
}