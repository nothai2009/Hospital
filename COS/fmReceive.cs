using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmReceive : Form
    {
        private DBClass dc = new DBClass();

        public fmReceive()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tP2)
            {
                ShowReceive();
            }
            else if (tabControl1.SelectedTab == tpRECEIVED)
            {
                ShowSuccess();
            }
            else if (tabControl1.SelectedTab == tpWait)
            {
                ShowWait();
            }
        }

        private void ShowWait()
        {
            var sql = "select distinct PO.JOB_ID,SPL.SPL_NAME, ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART, PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE" +
                " ,dbo.dmy_hm(NJ.REQ_DATE)as REQ_DATE, dbo.dmy_hm(NJ.SUB_BOSS_DATE)as SUB_BOSS_DATE" +
                 " from COS_PART_LIST P " +
                 " LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID " +
                 " LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT " +
                 " LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C " +
                 " LEFT JOIN COS_JOB NJ WITH(NOLOCK) ON NJ.JOBID = PO.JOB_ID " +
                 " LEFT JOIN COS_STATUS_PART_LIST SPL (NOLOCK) ON SPL.SPL_ID = PO.SPL_ID" +
                 " WHERE PO.SPL_ID BETWEEN 3 AND 4";

            var dt = new DBClass().SqlGetData(sql);
            var dgv = dgvWait;
            dgv.DataSource = dt;
            //dgv.Columns[0].Visible = true;
            //dgv.Columns[1].Visible = false;
            //dgv.Columns[2].Visible = false;
            //dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "พัสดุ";
            dgv.Columns[5].HeaderText = "จำนวน";
            dgv.Columns[6].HeaderText = "หน่วย";
            //dgv.Columns[7].HeaderText = "ราคาต่อชิ้น";
            //dgv.Columns[8].HeaderText = "ราคารวม";
            dgv.Columns[4].Width = 351;
            dgv.Columns[5].Width = 75;
            dgv.Columns[6].Width = 95;
            //dgv.Columns[7].Width = 95;
            //dgv.Columns[8].Width = 95;
        }

        private void ShowSuccess()
        {
            var sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C, ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART, PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE " +
                 "from COS_PART_LIST P " +
                 "LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID " +
                 "LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT " +
                 "LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C " +
                 "LEFT JOIN COS_JOB NJ WITH(NOLOCK) ON NJ.JOBID = PO.JOB_ID " +
                 "WHERE NJ.STATUS_FIX_ID = '20' AND SPL_ID='4' AND PO.PO_QTY_REQUIRED = PO.PO_QTY_RECEIVED";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);
            var dgv = dgvSuccess;
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = true;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "พัสดุ";
            dgv.Columns[5].HeaderText = "จำนวน";
            dgv.Columns[6].HeaderText = "หน่วย";
            dgv.Columns[7].HeaderText = "ราคาต่อชิ้น";
            dgv.Columns[8].HeaderText = "ราคารวม";
            dgv.Columns[4].Width = 351;
            dgv.Columns[5].Width = 75;
            dgv.Columns[6].Width = 95;
            dgv.Columns[7].Width = 95;
            dgv.Columns[8].Width = 95;
        }

        private void ShowReceive()
        {
            var sql_PART_ORDER = "select distinct PO.JOB_ID,PO.PO_ID,P.PL_ID,PL.PL_ID_C, ISNULL(PL_NAME, '') + ' ' + ISNULL(PL_BRAND, '') + ' ' + ISNULL(PL_GEN, '') + ' ' + ISNULL(PL_DESC_C, '') AS PART, PO.PO_QTY_REQUIRED,U.ST_NAME,PL.PL_PRICE,PO.PO_QTY_REQUIRED* PL.PL_PRICE AS TOTALPRICE " +
                 "from COS_PART_LIST P " +
                 "LEFT JOIN COS_PART_LIST_C PL ON P.PL_ID = PL.PL_ID " +
                 "LEFT JOIN COS_UNIT U ON U.ST_UNIT = P.PL_UNIT " +
                 "LEFT JOIN COS_PART_ORDER PO ON PO.PL_ID = P.PL_ID AND PO.PL_ID_C = PL.PL_ID_C " +
                 "LEFT JOIN COS_JOB NJ WITH(NOLOCK) ON NJ.JOBID = PO.JOB_ID " +
                 "WHERE NJ.STATUS_FIX_ID = '20' AND SPL_ID='4' AND PO.PO_QTY_REQUIRED != PO.PO_QTY_RECEIVED";

            var dt = new DBClass().SqlGetData(sql_PART_ORDER);
            var dgv = dgvReceivePart;
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = true;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "พัสดุ";
            dgv.Columns[5].HeaderText = "จำนวน";
            dgv.Columns[6].HeaderText = "หน่วย";
            dgv.Columns[7].HeaderText = "ราคาต่อชิ้น";
            dgv.Columns[8].HeaderText = "ราคารวม";
            dgv.Columns[4].Width = 351;
            dgv.Columns[5].Width = 75;
            dgv.Columns[6].Width = 95;
            dgv.Columns[7].Width = 95;
            dgv.Columns[8].Width = 95;
        }

        private void dgvReceivePart_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReceivePart.ClearSelection();
        }

        private void fmReceive_Load(object sender, EventArgs e)
        {
            ShowReceive();
        }

        private void nudReceive_ValueChanged(object sender, EventArgs e)
        {
            if (nudReceive.Value > 0)
            {
                rdo1.Checked = false;
            }
            else
            {
                rdo1.Checked = true;
            }
        }

        private void dgvReceivePart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtQTY.Text = dgvReceivePart.SelectedCells[5].Value.ToString();
            var QTY = dgvReceivePart.SelectedCells[5].Value.ToString();
            nudReceive.Maximum = Convert.ToInt32(QTY);
        }

        private void btnSaveReceivePart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการบันทึกใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvReceivePart.SelectedRows.Count > 0)
                {
                    string QTY = "";
                    if (rdo1.Checked == true)
                    {
                        QTY = dgvReceivePart.SelectedCells[5].Value.ToString();
                    }
                    else
                    {
                        QTY = nudReceive.Value.ToString();
                    }
                    var JOB_ID = dgvReceivePart.SelectedCells[0].Value.ToString();
                    var sqlupdate = "update COS_PART_ORDER set PO_QTY_RECEIVED=@PO_QTY_RECEIVED, INVOICE_NO=@INVOICE_NO,RECEIVED_DATE=@RECEIVED_DATE where JOB_ID = '" + JOB_ID + "'";
                    SqlParameterCollection param2 = new SqlCommand().Parameters;
                    param2.AddWithValue("@PO_QTY_RECEIVED", SqlDbType.Int).Value = Convert.ToInt32(QTY);
                    param2.AddWithValue("@INVOICE_NO", SqlDbType.NVarChar).Value = txtINVOICE_NO.Text;
                    param2.AddWithValue("@RECEIVED_DATE", SqlDbType.VarChar).Value = dc.GetDate();
                    int i2 = new DBClass().SqlExecute(sqlupdate, param2);

                    ShowReceive();

                    txtINVOICE_NO.Text = "";
                    nudReceive.Value = 0;
                }
            }
        }

        private void dgvSuccess_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSuccess.ClearSelection();
        }
    }
}