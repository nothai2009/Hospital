using COS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UDH;

namespace PDrugCount
{
    public partial class fmMain : Form
    {
        private bool Edit;
        private fmSettingConfig f = new fmSettingConfig();
        private DBClass db = new DBClass();

        private DataTable dtMed_inv = new DataTable();
        private string filter_Med_inv = "code";
        private DataTable dtDform = new DataTable();
        private string filter_Dform = "dform_des";
        private DataTable dtSpec = new DataTable();
        private string filter_Spec = "code";
        private DataTable dtWard_dept = new DataTable();
        private string filter_Ward_dept = "ward_des";


        private DataTable dtcode = new DataTable();

        

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

            txtSearchcode.Focus();
            //ความสูงของ datagridview
            dgvSearchabbr.Size = new Size(450, 350);
            dgvSearch_Ward_dept.Size = new Size(450, 350);
            dgvSearch_SPEC.Size = new Size(450, 350);
            dgvDform.Size = new Size(450, 350);
        }

        private void fmMain_Load(object sender, EventArgs e)
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

            try
            {
                var sql = "SELECT code FROM Med_inv ORDER BY code";
                bscode.DataSource = db.SqlGetData(sql);

                bnavigator_code.BindingSource = bscode;
                txtSearchcode.DataBindings.Add(new Binding("Text", bscode, "code", true));
                txtcode.DataBindings.Add(new Binding("Text", bscode, "code", true));
            }
            catch (Exception)
            {
            }

            //แสดงข้อมูลยา
            cbxMed_inv();
            cbxDEPT();
            cbxSpec();
            cbxDform();
        }

        private void cbxDEPT()
        {
            try
            {
                var sql = "SELECT ward_des, ward_seq FROM Ward_dept";
                dtWard_dept = new DBClass().SqlGetData(sql);
                var dgv = dgvSearch_Ward_dept;
                dgv.DataSource = dtWard_dept;
                dgv.Columns[0].Width = 350;
                dgv.Columns[1].Width = 50;
                dgv.Columns[0].HeaderText = "แผนก";
                dgv.Columns[1].HeaderText = "รหัสแผนก";
            }
            catch
            {
            }
        }

        private void cbxDform()
        {
            try
            {
                var dgv = dgvDform;
                var sql = "SELECT dform_key,dform_des FROM dbo.Dform";
                dtDform = new DBClass().SqlGetData(sql);
                dgv.DataSource = dtDform;
                dgv.Columns[0].Width = 50;
                dgv.Columns[1].Width = 350;
                dgv.Columns[0].HeaderText = "รหัส";
                dgv.Columns[1].HeaderText = "รูปแบบ";
            }
            catch
            {
            }
        }

        private void cbxMed_inv()
        {
            try
            {
                var txtSearch = txtSearchcode.Text;
                var sql = "SELECT code, gen_name FROM Med_inv";
                dtMed_inv = new DBClass().SqlGetData(sql);
                var dgv = dgvSearchabbr;
                dgv.DataSource = dtMed_inv;
                dgv.Columns[0].Width = 70;
                dgv.Columns[1].Width = 350;
                dgv.Columns[0].HeaderText = "รหัสยา";
                dgv.Columns[1].HeaderText = "ชื่อยา";

                txtcode.Text = dtMed_inv.Rows[0][0].ToString();
            }
            catch
            {
            }
        }

        private void txtSearchabbr_MouseClick(object sender, MouseEventArgs e)
        {
            dgvSearchabbr.Visible = true;
        }

        private void txtSearchabbr_TextChanged(object sender, EventArgs e)
        {
            if (dtMed_inv.Rows.Count > 0 && dgvSearchabbr.Visible == true)
            {
                dtMed_inv.DefaultView.RowFilter = string.Format("code LIKE '%{1}%' OR gen_name LIKE '%{1}%'", filter_Med_inv, txtSearchcode.Text);
            }
            //dtMed_inv.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%' OR gen_name LIKE '%{1}%'", filter_Med_inv, txtSearchcode.Text);
        }

        private void dgvSearchabbr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var dgv = dgvSearchabbr;
            var code = dgv.CurrentRow.Cells[0].Value.ToString();
            txtSearchcode.Text = code;
            txtcode.Text = code;
            dgv.Visible = false;
            showcode();
        }

        private void fmMain_Click(object sender, System.EventArgs e)
        {
            dgvSearchabbr.Visible = false;
            dgvDform.Visible = false;
            dgvSearch_Ward_dept.Visible = false;
            dgvSearch_SPEC.Visible = false;
        }

        private void showcode()
        {
            var sql1 = "SELECT code, abbr, hideSelect,LTRIM(RTRIM(gen_name)) AS gen_name, LTRIM(RTRIM(name)) AS name, RTRIM(dform)AS dform, RTRIM(strgth)AS strgth, RTRIM(strgth_u)AS strgth_u,ltrim(opd_prc)AS opd_prc," +
                "prdTypeDesc,[Des],ed_group,AutoStop,prdTypeCode " +
                 " FROM Med_inv inv " +
                 " LEFT JOIN[PRODTYPE] pt WITH(NOLOCK) ON inv.prod_type = pt.[prdTypeCode]  " +
                 " LEFT JOIN [Med_inv_ed_List] ml WITH(NOLOCK) ON ml.id=inv.ed_list" +
                 " WHERE code ='" + txtSearchcode.Text + "'";
            dtcode = new DBClass().SqlGetData(sql1);

            if (dtcode.Rows.Count > 0)
            {
                txtcode.Text = dtcode.Rows[0]["code"].ToString();

                if (dtcode.Rows[0]["hideSelect"].ToString() == "Y")
                {
                    cbHide.Checked = true;
                }
                else
                {
                    cbHide.Checked = false;
                }
                txtname.Text = dtcode.Rows[0]["name"].ToString();
                txtgen_name.Text = dtcode.Rows[0]["gen_name"].ToString();
                txtabbr.Text = dtcode.Rows[0]["abbr"].ToString();
                txtdform.Text = dtcode.Rows[0]["dform"].ToString();
                txtstrgth.Text = dtcode.Rows[0]["strgth"].ToString();
                txtstrgth_u.Text = dtcode.Rows[0]["strgth_u"].ToString();
                txtopd_prc.Text = dtcode.Rows[0]["opd_prc"].ToString();
                txted.Text = dtcode.Rows[0]["prdTypeCode"].ToString();

                if (dtcode.Rows[0]["Des"].ToString() != "")
                {
                    cbxed_list.Text = (dtcode.Rows[0]["Des"].ToString());
                }
                else
                {
                    cbxed_list.SelectedIndex = -1;
                }

                if (dtcode.Rows[0]["prdTypeDesc"].ToString() != "")
                {
                    cbxprod_type.Text = dtcode.Rows[0]["prdTypeDesc"].ToString();
                }
                else
                {
                    cbxprod_type.SelectedIndex = -1;
                }

                var AutoStop = dtcode.Rows[0]["AutoStop"].ToString();
                if (AutoStop == "Y")
                {
                    cbAutoStop.Checked = true;
                }
                else
                {
                    cbAutoStop.Checked = false;
                }

                txtcode.Text = txtSearchcode.Text;
            }

            txtSearchcode.Focus();
            txtSearchcode.SelectionStart = txtSearchcode.TextLength;
        }

        private void btnInsert3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการเพิ่มเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var qr = "SELECT [id],[Des] FROM [Med_inv_con]WHERE[Des] = '" + txtmedCon.Text + "'";
                var dt1 = new DBClass().SqlGetData(qr);
                //txtabbr.Text = dt1.Rows[0][0].ToString();

                //ถ้าซ้ำ เงื่อนไขซ้ำ
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        var value = dt1.Rows[i][0].ToString();
                        var d = "SELECT [id] FROM [Med_inv_c]WHERE id='" + value + "' AND code='" + txtSearchcode.Text + "'";
                        var dt_d = new DBClass().SqlGetData(d);

                        //เช็คเงื่อนไขซ้ำกันรหัสนั้นไหม
                        if (dt_d.Rows.Count > 0) //ถ้าซ้ำ
                        {
                            showMed_inv_c();
                        }
                        else //ถ้าไม่ซ้ำ
                        {
                            //var num = new DBClass().AutoNunber("SELECT TOP 1 id FROM Med_inv_c WHERE code='" + txtSearchabbr.Text + "' ORDER BY id DESC");
                            var sql = "INSERT INTO[Med_inv_c](id,abbr)VALUES(" + dt1.Rows[i][0].ToString() + ",'" + txtSearchcode.Text + "')";
                            var idd = new DBClass().SqlExecute(sql);
                        }
                    }
                }
                else
                {
                    var sql_order = "INSERT INTO [Med_inv_con] (Des)VALUES(@Des)";
                    SqlParameterCollection param_order = new SqlCommand().Parameters;
                    param_order.AddWithValue("@Des", SqlDbType.VarChar).Value = txtmedCon.Text;
                    int i_order = new DBClass().SqlExecute(sql_order, param_order);

                    string q = "SELECT TOP 1 [id] FROM [Med_inv_con] WHERE Des='" + txtmedCon.Text + "'";
                    var dt = new DBClass().SqlGetData(q);
                    var code = dt.Rows[0][0].ToString();

                    var sql_1 = "INSERT INTO [Med_inv_c] (id,abbr)VALUES(@id,@abbr)";
                    SqlParameterCollection param_1 = new SqlCommand().Parameters;
                    param_1.AddWithValue("@id", SqlDbType.Int).Value = code;
                    param_1.AddWithValue("@abbr", SqlDbType.Char).Value = txtcode.Text;
                    int i_1 = new DBClass().SqlExecute(sql_1, param_1);
                }
            }

            showMed_inv_c();
            txtmedCon.Text = "";
        }

        private void showMed_inv_c()
        {
            var dgv = dgvMed_inv_c;
            var sql = "SELECT  [no], mc.Des,mc.[id] FROM[Med_inv_c] mic" +
                " LEFT JOIN[Med_inv] mi WITH(NOLOCK) ON mi.code=mic.abbr" +
                " LEFT JOIN[Med_inv_con] mc WITH (NOLOCK) ON mic.[id]= mc.[id] " +
                " WHERE mic.abbr = '" + txtcode.Text + "'" +
                " ORDER BY [no]";
            var dt = new DBClass().SqlGetData(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ลำดับ";
            dgv.Columns[1].HeaderText = "รายการ";
            dgv.Columns[2].HeaderText = "รหัส";

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 955;
            dgv.Columns[2].Width = 50;
        }

        private void dgvMed_inv_c_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMed_inv_c.ClearSelection();
        }

        private void btnInsert4_Click(object sender, EventArgs e)
        {
            var qr_ = "SELECT ward_seq FROM Ward_dept WHERE ward_des='" + txtSearch_Ward_dept.Text+"'";
            var dt_ = new DBClass().SqlGetData(qr_);

            if(dt_.Rows.Count == 0)
            {
                return;
            }

            var deptCode = dt_.Rows[0][0].ToString();

            var qr = "SELECT * FROM Med_inv_dept WHERE abbr='" + txtcode.Text + "' and deptCode='" + deptCode + "'";
            var dt1 = new DBClass().SqlGetData(qr);

            //ถ้าซ้ำ เงื่อนไขซ้ำ
            if (dt1.Rows.Count > 0)
            {
            }
            else
            {
                if (MessageBox.Show("คุณต้องการเพิ่มเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var code = txtcode.Text;
                    var sql = "INSERT INTO Med_inv_dept([deptCode],[abbr])VALUES(" + deptCode + ",'" + code + "')";
                    var idd = new DBClass().SqlExecute(sql);
                }
            }

            showWard_dept();
            dgvWard_dept.ClearSelection();
            txtSearch_Ward_dept.Focus();
            txtSearch_Ward_dept.Text = "";
        }

        private void showWard_dept()
        {
            var dgv = dgvWard_dept;
            var sql = "SELECT ward_des, deptCode " +
                " FROM Med_inv_dept md " +
                " LEFT JOIN Ward_dept wd WITH(NOLOCK) ON md.deptCode = wd.ward_seq " +
                " WHERE  abbr = '" + txtcode.Text + "'";
            var dt = new DBClass().SqlGetData(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 250;
            dgv.Columns[1].Width = 50;
            dgv.Columns[0].HeaderText = "แผนก";
            dgv.Columns[1].HeaderText = "รหัส";
        }

       

        private void txtSearch_Ward_dept_MouseClick(object sender, MouseEventArgs e)
        {
            dgvSearch_Ward_dept.Visible = true;
            txtSearch_Ward_dept.Text = "";
        }

        private void cbxWard_dept()
        {
            try
            {
                var dgv = dgvSearch_Ward_dept;
                var sql = "SELECT RTRIM([ward_des])AS ward_des,RTRIM([ward_seq])AS ward_seq FROM [Ward_dept]";
                var dt = new DBClass().SqlGetData(sql);
                dgv.DataSource = dt;
                dgv.Columns[0].Width = 250;
                dgv.Columns[1].Width = 50;
                dgv.Columns[0].HeaderText = "แผนก";
                dgv.Columns[1].HeaderText = "รหัสแผนก";
            }
            catch
            {
            }
        }

        private void txtSearch_Ward_dept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgvSearch_Ward_dept;

            txtSearch_Ward_dept.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            dgv.Visible = false;
            btnInsert4.Focus();
        }

        private void cbxSpec()
        {
            var sql = "select s.specDesc,RTRIM(s.specCode)as specCode from SPEC s";
            dtSpec = new DBClass().SqlGetData(sql);
            var dgv = dgvSearch_SPEC;
            dgv.DataSource = dtSpec;
            dgv.Columns[0].Width = 350;
            dgv.Columns[1].Width = 50;
            dgv.Columns[0].HeaderText = "ความเชี่ยวชาญของแพทย์";
            dgv.Columns[1].HeaderText = "รหัส";
        }

        private void txtSearchSPEC_MouseClick(object sender, MouseEventArgs e)
        {
            dgvSearch_SPEC.Visible = true;
            txtSearchSPEC.Text = "";
        }

        private void txtSearchSPEC_TextChanged(object sender, EventArgs e)
        {
            if (dtSpec.Rows.Count > 0)
            {
                dtSpec.DefaultView.RowFilter = string.Format("specDesc LIKE '%{1}%'", filter_Spec, txtSearchSPEC.Text);
            }

            if (txtSearchSPEC.TextLength > 0)
            {
                btnInsert5.Enabled = true;
            }
            else
            {
                btnInsert5.Enabled = false;

            }
        }

        private void dgvSearch_Ward_dept_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSearch_Ward_dept.ClearSelection();
        }

        private void dgvSearchabbr_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSearchabbr.ClearSelection();
        }

        private void dgvSearch_SPEC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgvSearch_SPEC;
            txtSearchSPEC.Text = dgv.SelectedCells[0].Value.ToString();
            dgv.Visible = false;
            btnInsert5.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtSearchcode.Text = "";
            dgvSearchabbr.Visible = false;
        }

        private void dgvMed_inv_c_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert2.Enabled = false;
            btnDelete2.Enabled = true;
            btnCancel2.Enabled = true;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var value = dgvMed_inv_c.SelectedCells[2].Value.ToString();
                var sql = "DELETE [Med_inv_c] WHERE abbr='" + txtcode.Text + "' AND id='" + value + "'";
                int i_order = new DBClass().SqlExecute(sql);
                showMed_inv_c();
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            btnInsert2.Enabled = true;
            btnDelete2.Enabled = false;
            btnCancel2.Enabled = false;
            txtmedCon.Focus();
            dgvMed_inv_c.ClearSelection();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            txtSearch_Ward_dept.Text = "";
            dgvSearch_Ward_dept.Visible = false;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            txtSearchSPEC.Text = "";
            dgvSearch_SPEC.Visible = false;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            txtmedCon.Text = "";
        }

        private void dgvWard_dept_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvWard_dept.ClearSelection();
        }

        private void dgvWard_dept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert4.Enabled = false;
            btnDelete4.Enabled = true;
            btnCancel4.Enabled = true;
        }

        private void btnCancel4_Click(object sender, EventArgs e)
        {
            btnInsert4.Enabled = true;
            btnDelete4.Enabled = false;
            btnCancel4.Enabled = false;
            dgvWard_dept.ClearSelection();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var deptCode = dgvWard_dept.CurrentRow.Cells[1].Value.ToString();
                var sql = "DELETE Med_inv_dept WHERE abbr='" + txtcode.Text + "' AND deptCode='" + deptCode + "'";
                int i_order = new DBClass().SqlExecute(sql);
                showWard_dept();
            }
        }

        private void btnInsert5_Click(object sender, EventArgs e)
        {

            var qr_ = "SELECT specCode FROM SPEC WHERE specDesc='" + txtSearchSPEC.Text + "'";
            var dt_ = new DBClass().SqlGetData(qr_);

            if (dt_.Rows.Count == 0)
            {
                return;
            }

            var specCode = dt_.Rows[0][0].ToString();

            var dgv = dgvSearch_SPEC;
            var qr = "SELECT * FROM Med_inv_Spec WHERE abbr='" + txtcode.Text + "' and specCode='" + specCode + "'";
            var dt1 = new DBClass().SqlGetData(qr);

            //ถ้าซ้ำ เงื่อนไขซ้ำ
            if (dt1.Rows.Count > 0)
            {
            }
            else
            {
                if (MessageBox.Show("คุณต้องการเพิ่มเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var abbr = txtcode.Text;
                    var sql = "INSERT INTO Med_inv_Spec([specCode],[abbr])VALUES('" + specCode + "','" + abbr + "')";
                    var idd = new DBClass().SqlExecute(sql);
                }
            }

            showSpec();
            dgv.ClearSelection();
            txtSearchSPEC.Focus();
            txtSearchSPEC.Text = "";
        }

        private void showSpec()
        {
            var dgv = dgvSPEC;
            var sql = "SELECT RTRIM(specDesc), s.specCode " +
                " FROM SPEC s " +
                " LEFT JOIN[Med_inv_Spec] ms WITH(NOLOCK) ON ms.specCode = s.specCode" +
                " WHERE abbr = '" + txtcode.Text + "'";
            var dt = new DBClass().SqlGetData(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 250;
            dgv.Columns[1].Width = 50;
            dgv.Columns[0].HeaderText = "แผนก";
            dgv.Columns[1].HeaderText = "รหัส";
        }

        private void dgvSPEC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSPEC.ClearSelection();
        }

        private void dgvSPEC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert5.Enabled = false;
            btnDelete5.Enabled = true;
            btnCancel5.Enabled = true;
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบเงื่อนไขในการสั่งยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var specCode = dgvSPEC.CurrentRow.Cells[1].Value.ToString();
                var sql = "DELETE [Med_inv_Spec] WHERE specCode='" + specCode + "' and abbr='" + txtcode.Text + "'";
                int i_order = new DBClass().SqlExecute(sql);
                showSpec();
            }
        }

        private void btnCancel5_Click(object sender, EventArgs e)
        {
            btnInsert5.Enabled = true;
            btnDelete5.Enabled = false;
            btnCancel5.Enabled = false;
            dgvSPEC.ClearSelection();
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                btnInsert1.Enabled = false;
                btnEdit1.Enabled = false;
                btnSave1.Enabled = true;
                btnCancel1.Enabled = true;
                btnSave1.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            btnInsert1.Enabled = true;
            btnEdit1.Enabled = true;
            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            txtSearchcode.Focus();
            showcode();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            //if (txtPL_PRICE.Text.Trim() == "")
            //{
            //    MessageBox.Show("กรุณากรอกราคาพัสดุ");
            //    return;
            //}
            var text = txtSearchcode.Text;
            if (Edit == false)
            {
                //try
                //{
                //    for (int i = 0; i < dgv2.RowCount; i++)
                //    {
                //        if (dgv2.Rows[i].Cells[1].Value.ToString() == txtST_NAME.Text)
                //        {
                //            MessageBox.Show("ชื่อ" + text + "ซ้ำ", "คำเตือน");
                //            return;
                //        }
                //    }
                //    if (MessageBox.Show("คุณต้องการเพิ่มรายการ" + text + "ที่สั่งซื้อ " + txtST_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        var autoNum = "SELECT MAX([PL_ID_C]) FROM [COS_PART_LIST_C] WHERE PL_ID='" + cbxPL_NAME.SelectedValue + "'";
                //        var autoNumResult = new DBClass().AutoNunber(autoNum);
                //        var save = "insert into [COS_PART_LIST_C] (PL_ID,PL_ID_C,PL_BRAND,PL_GEN,PL_DESC_C,PL_PRICE)VALUES"
                //            + "('" + cbxPL_NAME.SelectedValue + "','" + autoNumResult + "','" + txtPL_BRAND.Text + "','" + txtPL_GEN.Text + "','" + txtPL_DESC_C.Text + "','" + txtPL_PRICE.Text + "')";
                //        int isave = new DBClass().SqlExecute(save);
                //        MessageBox.Show("บันทึกรายการ" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("บันทึกไม่ได้เนื่องจาก " + ex.Message);
                //}
            }
            else if (Edit == true)
            {
                //try
                //{
                if (MessageBox.Show("คุณต้องการแก้ไขรายการ " + text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string AutoStop = "";
                    if (cbAutoStop.Checked == true)
                    {
                        AutoStop = "Y";
                    }
                    else if (cbAutoStop.Checked == true)
                    {
                        AutoStop = "N";
                    }
                    else
                    {
                        AutoStop = "N";
                    }
                    var sql = "SELECT id FROM Med_inv_ed_List WHERE Des ='" + cbxed_list.Text + "'";
                    var dt = new DBClass().SqlGetData(sql);
                    string ed_list = "";
                    if (dt.Rows.Count > 0)
                    {
                        ed_list = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        ed_list = null;
                    }

                    var sql_ = "SELECT prdTypeCode FROM PRODTYPE WHERE prdTypeDesc ='" + cbxprod_type.Text + "'";
                    var dt_ = new DBClass().SqlGetData(sql_);
                    string prdTypeCode = "";
                    if (dt_.Rows.Count > 0)
                    {
                        prdTypeCode = dt_.Rows[0][0].ToString();
                    }
                    else
                    {
                        prdTypeCode = null;
                    }

                    var edit2 = "UPDATE Med_inv SET ed_list='" + ed_list + "',AutoStop='" + AutoStop + "',prod_type='" + cbxprod_type.SelectedValue + "',strgth_u='" + txtstrgth_u.Text + "',strgth='" + txtstrgth.Text + "'" +
                        " WHERE code='" + txtcode.Text + "'";
                    int iedit2 = new DBClass().SqlExecute(edit2);
                    MessageBox.Show("แก้ไขรายการ" + text + "เสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("แก้ไขไม่ได้เนื่องจาก " + ex.Message);
                //}
            }
            btnInsert1.Enabled = true;
            btnEdit1.Enabled = true;
            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            Edit = false;
            //ClearText1();
            showcode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmAddDocument f = new fmAddDocument(txtcode.Text);
            f.ShowDialog();
        }

        private void dgvMed_inv_c_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMed_inv_c.Rows.Count > 0)
            {
                var no = dgvMed_inv_c.CurrentRow.Cells[0].Value.ToString();
                var id = dgvMed_inv_c.CurrentRow.Cells[2].Value.ToString();
                var sql = "UPDATE mic SET [no]='" + no + "' " +
                    " FROM[Med_inv_c] mic " +
                    " LEFT JOIN[Med_inv] mi WITH(NOLOCK) ON mi.code = mic.abbr " +
                    " LEFT JOIN[Med_inv_con] mc WITH(NOLOCK) ON mic.[id]= mc.[id] " +
                    " WHERE mic.abbr = '" + txtcode.Text + "' AND mic.id='" + id + "'";
                var i = new DBClass().SqlExecute(sql);
            }
        }

        private void txtmedCon_TextChanged(object sender, EventArgs e)
        {
            if (txtmedCon.TextLength > 0)
            {
                btnInsert2.Enabled = true;
            }
            else
            {
                btnInsert2.Enabled = false;
            }
        }



        private void txtdform_TextChanged(object sender, EventArgs e)
        {
            if (dtDform.Rows.Count > 0)
            {
                //กรองข้อมูล
                if (dgvDform.Visible == true)
                {
                    dtDform.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filter_Dform, txtdform.Text);
                }
            }
        }

        private void txtdform_MouseClick(object sender, MouseEventArgs e)
        {
            dgvDform.Visible = true;
            txtdform.Text = "";
        }

        private void dgvDform_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = dgvDform;
            if (e.KeyCode == Keys.Enter)
            {
                txtdform.Text = dgv.SelectedCells[0].Value.ToString();
                dgv.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                dgv.Focus();
            }
            else
            {
                dgv.Visible = true;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            txtdform.Text = dtcode.Rows[0]["dform"].ToString();

            dgvDform.Visible = false;
        }

        private void cbxprod_type_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var cbx = cbxprod_type;
                var sql = "SELECT prdTypeCode,prdTypeDesc FROM PRODTYPE WHERE catagory='M' AND (ed_group='E' OR ed_group='N')";
                var dt = new DBClass().SqlGetData(sql);
                cbx.DataSource = dt;
                cbx.ValueMember = "prdTypeCode";
                cbx.DisplayMember = "prdTypeDesc";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxed_list_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var cbx = cbxed_list;
                var sql = "SELECT [id],[Des] FROM Med_inv_ed_List";
                var dt = new DBClass().SqlGetData(sql);
                cbx.DataSource = dt;
                cbx.ValueMember = "id";
                cbx.DisplayMember = "Des";
            }
            catch
            {
            }
        }

        private void bnavigator_code_Click(object sender, EventArgs e)
        {
            txtcode.Text = txtSearchcode.Text;
        }

        private void txtSearch_Ward_dept_TextChanged_1(object sender, EventArgs e)
        {
            if (dtWard_dept.Rows.Count > 0)
            {
                dtWard_dept.DefaultView.RowFilter = string.Format("ward_des LIKE '%{1}%'", filter_Ward_dept, txtSearch_Ward_dept.Text);
            }

            if(txtSearch_Ward_dept.TextLength > 0)
            {
                btnInsert4.Enabled = true;
            }
            else
            {
                btnInsert4.Enabled = false;

            }
        }

        private void txtSearchcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                showcode();
            }
        }

        private void dgvDform_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dgvDform;
            txtdform.Text = dgv.SelectedCells[0].Value.ToString();
            dgv.Visible = false;
        }

        private void bnavigator_code_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void bnavigator_code_Click_1(object sender, EventArgs e)
        {
            showcode();
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            showcode();
            showMed_inv_c();
            showWard_dept();
            showSpec();
        }
    }
}