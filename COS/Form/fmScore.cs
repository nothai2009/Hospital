using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UDH
{
    public partial class fmScore : Form
    {
        private List<string> JOB_ID_List = new List<string>();

        public fmScore()
        {
            InitializeComponent();
        }

        private void Score_Load(object sender, EventArgs e)
        {
            ShowdgvScore();
        }

        private void ShowdgvScore()
        {
            try
            {
                string sql = "SELECT COS_JOB.JOBID, COS_JOB.CARUCODE, COS_JOB.CARUNO, CARU2_COS_NEW_CARU_TYPE.CT_NAME, RTRIM(COS_NEW_DEPT.deptname) AS DEPTNAME,"
                         + " COS_CAUSE_TYPE.CAUSE_NAME, COS_JOB.DESC_, dbo.dmy_hm(COS_JOB.REQ_DATE) AS REQ_DATE, dbo.dmy(COS_JOB.EXPECT_DATE)"
                         + " AS EXPECT_DATE, dbo.dmy_hm(COS_JOB.FINISH_DATE) AS FINISH_DATE, dbo.dmy_hm(COS_JOB.SEND_DATE) AS SEND_DATE, COS_USER.U_NAME,"
                         + " COS_JOB.FIXED_DETAIL, COS_FIXED_TYPE.FT_NAME"
                         + " FROM COS_JOB INNER JOIN"
                         + " COS_CAUSE_TYPE ON COS_JOB.CAUSE_ID = COS_CAUSE_TYPE.CAUSE_ID INNER JOIN"
                         + " COS_NEW_DEPT ON COS_JOB.DEPT_ID = CARU2_COS_NEW_DEPT.DEPT INNER JOIN"
                         + " COS_NEW_CARU_TYPE ON COS_JOB.CARU_ID = CARU2_COS_NEW_CARU_TYPE.CT_ID INNER JOIN"
                         + " COS_LEVEL_TYPE ON COS_JOB.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID INNER JOIN"
                         + " COS_PART_ORDER ON COS_JOB.JOBID = COS_PART_ORDER.JOB_ID INNER JOIN"
                         + " COS_USER ON COS_JOB.USER_ID = COS_USER.U_ID INNER JOIN"
                         + " COS_FIXED_TYPE ON COS_JOB.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
                         + " WHERE(COS_JOB.STATUS_FIX_ID = 7) AND (COS_JOB.SCORE IS NULL)"
                         + " ORDER BY COS_JOB.JOBID";
            DataTable dt = new DBClass().SqlGetData(sql);
            dgvScore.DataSource = dt;
            dgvScore.Columns[0].HeaderText = "JOB_ID"; dgvScore.Columns[0].Width = 128;
            dgvScore.Columns[1].HeaderText = "เลขครุภัณฑ์"; dgvScore.Columns[1].Width = 85;
            dgvScore.Columns[2].HeaderText = "ตัวย่อ"; dgvScore.Columns[2].Width = 44;
            dgvScore.Columns[3].HeaderText = "ประเภท"; dgvScore.Columns[3].Width = 118;
            dgvScore.Columns[4].HeaderText = "หน่วยงาน"; dgvScore.Columns[4].Width = 100;
            dgvScore.Columns[5].HeaderText = "อาการเสีย"; dgvScore.Columns[5].Width = 120;
            dgvScore.Columns[6].HeaderText = "คำอธิบาย"; dgvScore.Columns[6].Width = 85;
            dgvScore.Columns[7].HeaderText = "วันแจ้ง"; dgvScore.Columns[7].Width = 65;
            dgvScore.Columns[8].HeaderText = "กำหนดเสร็จ"; dgvScore.Columns[8].Width = 95;
            dgvScore.Columns[9].HeaderText = "วันเสร็จ"; dgvScore.Columns[9].Width = 95;
            dgvScore.Columns[10].HeaderText = "วันส่งมอบ"; dgvScore.Columns[10].Width = 95;
            dgvScore.Columns[11].HeaderText = "ช่างผู้รับผิดชอบ"; dgvScore.Columns[11].Width = 120;
            dgvScore.Columns[12].HeaderText = "รายละเอียดการซ่อม"; dgvScore.Columns[12].Width = 160;
            dgvScore.Columns[13].HeaderText = "วิธีการซ่อม"; dgvScore.Columns[13].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }
        }

        private void dgvScore_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvScore_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvScore.ClearSelection();

            for (int i = 0; i < dgvScore.RowCount; i++)
            {
                var EXPECT_DATE = Convert.ToDateTime(dgvScore.Rows[i].Cells[8].Value);
                var COMPLETE_DATE = Convert.ToDateTime(dgvScore.Rows[i].Cells[9].Value);
                var SEND_DATE = Convert.ToDateTime(dgvScore.Rows[i].Cells[10].Value);
                if (COMPLETE_DATE > EXPECT_DATE)
                {
                    dgvScore.Rows[i].Cells[8].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvScore.Rows[i].Cells[8].Style.BackColor = Color.Green;
                }
                if (SEND_DATE > EXPECT_DATE)
                {
                    dgvScore.Rows[i].Cells[9].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvScore.Rows[i].Cells[9].Style.BackColor = Color.Green;
                }
            }
        }

        private void dgvScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)         //ถ้าไม่มีแถวจะไม่เกิดอะไรขึ้น
            {
                return;
            }
            //JOB_ID_List = new Setting().ShowColorClick(dgvScore, JOB_ID_List);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (JOB_ID_List.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกงาน !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbxSCORE.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกคะแนน !", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSCORE.DroppedDown = true;
                return;
            }

            if (MessageBox.Show("คุณต้องการบันทึกวิธีการส่งซ่อมใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i;
                for (i = 0; i < JOB_ID_List.Count; i++)
                {
                    if (JOB_ID_List[i] != "")
                    {
                        try
                        {
                            var sql_update = "update COS_JOB SET SCORE=@SCORE,SCORE_DETAIL=@SCORE_DETAIL where JOBID='" + JOB_ID_List[i] + "'";
                            SqlParameterCollection param = new SqlCommand().Parameters;
                            param.AddWithValue("@SCORE", SqlDbType.Int).Value = cbxSCORE.Text;
                            param.AddWithValue("@SCORE_DETAIL", SqlDbType.VarChar).Value = txtSCORE_DETAIL.Text;
                            int i2 = new DBClass().SqlExecute(sql_update, param);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("รับงานไม่ได้เนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //DBClass.tr.Rollback();
                        }
                    }
                    if (JOB_ID_List.Count == i)
                    {
                        MessageBox.Show("บันทึกวิธีส่งซ่อมเสร็จเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ClearData();
                ShowdgvScore();
                JOB_ID_List.Clear();
            }
        }

        private void ClearData()
        {
            cbxSCORE.SelectedIndex = -1;
            txtSCORE_DETAIL.Text = "";
        }
    }
}