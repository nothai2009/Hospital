using ReadWriteIniFileExample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using UDH;

namespace INVS
{
    public partial class fmMain : Form
    {
        private static string fileconfig = "config.ini";

        private Regex reg09 = new Regex("^[0-9]+$");
        private bool Edit;

        public fmMain()
        {
            InitializeComponent();

            //Updater up = new Updater();
            //var urlUpdate = "http://192.168.0.5/UPDATE_PROGRAM/INVS/UpdateInfo.dat";
            //up.CheckForUpdates(urlUpdate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DBClass().SqlPROCEDURE(txtMAX.Text, txtMIN.Text);
            var dgv = dataGridView1;
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "รหัสวิธีจัดซื้อ";
            dgv.Columns[1].HeaderText = "วิธีจัดซื้อ";
            dgv.Columns[2].HeaderText = "รหัสบริษัท";
            dgv.Columns[3].HeaderText = "บริษัท";
            dgv.Columns[4].HeaderText = "รหัสยา";
            dgv.Columns[5].HeaderText = "รายการ";
            dgv.Columns[6].HeaderText = "ขนาดบรรจุ";
            dgv.Columns[9].HeaderText = "คงเหลือ";
            dgv.Columns[10].HeaderText = "อัตราการใช้";
            dgv.Columns[11].HeaderText = "เหลือใช้";
            dgv.Columns[12].HeaderText = "ต้องซื้อ";
            dgv.Columns[13].HeaderText = "";
            dgv.Columns[14].HeaderText = "มูลค่า";
            dgv.Columns[18].HeaderText = "สัญญา";

            dgv.Columns[3].Width = 150;
            dgv.Columns[4].Width = 65;
            dgv.Columns[5].Width = 250;
            dgv.Columns[9].Width = 75;
            dgv.Columns[10].Width = 85;
            dgv.Columns[11].Width = 75;
            dgv.Columns[18].Width = 170;

            dgv.Columns[0].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[13].Visible = false;
            dgv.Columns[13].Visible = false;
            dgv.Columns[15].Visible = false;
            dgv.Columns[16].Visible = false;
            dgv.Columns[17].Visible = false;
            dgv.Columns[19].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulateRows();
            ExportToExcel();
        }

        private void PopulateRows()
        {
            //for (int i = 1; i <= 10; i++)
            //{
            DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
            //row.CreateCells(dataGridView1,string.Format("วิธีจัดซื้อ{0}", i),string.Format("บริษัท{0}", i), string.Format("รายการ{0}", i));
            //dataGridView1.Rows.Add(row);
            //}
        }

        private void ExportToExcel()
        {
            // Creating a Excel object.
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //try
            //{
            string sql = "SELECT  [BUYMET_CODE],[BUYMET_DES]FROM [BUYMETHOD]WHERE HIDE='N'ORDER BY BUYMET_DES";
            var dt = new DBClass().SqlGetData3(sql);
            var cbx = comboBox1;
            cbx.DataSource = dt;
            cbx.DisplayMember = "BUYMET_DES";
            cbx.ValueMember = "BUYMET_CODE";
            cbx.SelectedIndex = -1;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            var tap = tabControl1;
            var tt = tap.SelectedTab.Name;
            if (tabControl1.SelectedIndex == 2)
            {
                //DataTable dt1 = new DBClass().SqlSORTROW();

                //DataTable dt = new DBClass().SqlCountActiveValueCost();
                //var dgv = dataGridView2;
                //dgv.DataSource = dt;
                //dgv.Columns[0].Width = 40;
                //dgv.Columns[1].Width = 80;
                //dgv.Columns[2].Width = 80;
                //dgv.Columns[3].Width = 40;
                //dgv.Columns[4].Width = 60;
                //dgv.Columns[5].Width = 60;
                //dgv.Columns[6].Width = 60;
                //dgv.Columns[7].Width = 60;
                //dgv.Columns[8].Width = 60;
                //dgv.Columns[9].Width = 60;
                //dgv.Columns[10].Width = 60;
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                var sql = "SELECT dbo.ce2dmy1(GETDATE())AS TIME";
                var dt = new DBClass().SqlGetData3(sql);
                var time = dt.Rows[0][0].ToString();
                dtpdatesFax.Value = (DateTime.Parse(time)).AddMonths(0);
                dtpdateeFax.Value = DateTime.Parse(time);
                dtpFAX.Value = DateTime.Parse(time);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                ShowCOMPANY();
                //for (int i = 0; i < dgv.ColumnCount; i++)
                //{
                //    dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                //}
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                var sql = "SELECT dbo.ce2dmy1(GETDATE())AS TIME";
                var dt = new DBClass().SqlGetData3(sql);
                var time = dt.Rows[0][0].ToString();
                dtpRECEIVE_DATE.Text = time;
            }
            else if (tabControl1.SelectedTab.Name == "tpinvs_homc")
            {
                var DEPT_ID = IniFileHelper.ReadValue("INVS_UPDATE", "DEPT_ID", Path.GetFullPath(fileconfig));
                var DEPT_NAME = IniFileHelper.ReadValue("INVS_UPDATE", "DEPT_NAME", Path.GetFullPath(fileconfig));

                cbxDEPT_ID.DisplayMember = "Text";
                cbxDEPT_ID.ValueMember = "Value";

                cbxDEPT_ID.Items.Add(new { Text = "report A", Value = "reportA" });



                //ComboboxItem item = new ComboboxItem();
                //cbxDEPT_ID.DataSource = null;
                //cbxDEPT_ID.Items.Clear();

                //item.Text = DEPT_NAME;
                //item.Value = DEPT_ID;

                //cbxDEPT_ID.Items.Add(item);
                //cbxDEPT_ID.SelectedIndex = 0;

                _Show_Medcode_not_match();
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void _Show_Medcode_not_match()
        {
            var cbx = cbxDEPT_ID;
            var ttt = cbx.SelectedItem.ToString();
            var sql = "SELECT DISTINCT [CODE_HOS],[MED_HOS] ROM [DISPENSED_TEMP] WHERE [WORKING_CODE] IS NULL AND DISP_DEPT='"+ cbx.SelectedItem.ToString()+"'";
            var dt = new DBClass().SqlGetData(sql);
            var dgv = dgvMedcode_not_match;
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "รหัสยา homc";
            dgv.Columns[1].HeaderText = "ชื่อยา";

            dgv.Columns[0].Width = 80;
            dgv.Columns[1].Width = 340;
        }

        private void ShowCOMPANY()
        {
            string hide = "";
            if (chkCOMPANY_HIDE.Checked == false)
            {
                //แสดงผลเฉพาะรายการที่ไม่ซ่อน
                hide = " WHERE (C.[HIDE] IS NOT NULL OR C.[HIDE] IS NULL)";
            }
            else
            {
                hide = " WHERE C.[HIDE] = 'Y'";
            }
            var company_name = txtSCompany.Text;
            if (txtSCompany.Text.Length > 0)
            {
                var value = company_name.Substring(0, 1);
                if (reg09.IsMatch(value))
                {
                    //ค้นหาด้วยโค้ด
                    hide = hide + " AND C.COMPANY_CODE LIKE '%" + txtSCompany.Text + "%'";
                }
                else
                {
                    //ค้นหาด้วยชื่อบริษัท
                    hide = hide + " AND C.COMPANY_NAME LIKE '%" + txtSCompany.Text + "%'";
                }
            }

            var sql = "SELECT C.[COMPANY_CODE],RTRIM([KEY_WORD])AS KEY_WORD,BT.[BUSINESS_NAME],[COMPANY_NAME],RTRIM([ADDRESS])AS ADDRESS,RTRIM([TEL])AS TEL,RTRIM([FAX])AS FAX,[TAX_ID],CC.[BANK_NAME],[PHONE_DETAIL]"
                    + " ,[BANK],[CODE_BANK],[BRANCH],[CODE1],[CODE2],[BANK_NO],[F16],[F17],[F18],[F19],[NAME_PO],C.HIDE,X"
                    + " FROM[COMPANY]C"
                    + " LEFT JOIN COMPANY_C CC WITH(NOLOCK) ON C.COMPANY_CODE = CC.COMPANY_CODE"
                    + " LEFT JOIN BUSINESS_TYPE BT WITH(NOLOCK) ON BT.[BUSINESS_TYPE]=C.BUSINESS_TYPE" + hide
                    + " ORDER BY COMPANY_NAME ";
            DataTable dt = new DBClass().SqlGetData3(sql);
            var dgv = dgvCOMPANY;
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 95;
            dgv.Columns[1].Width = 100;
            dgv.Columns[9].Width = 150;
            dgv.Columns[0].HeaderText = "รหัสหน่วยงาน";
            dgv.Columns[1].HeaderText = "คำค้น";
            dgv.Columns[2].HeaderText = "ประเภท";
            dgv.Columns[3].HeaderText = "ชื่อบริษัท";
            dgv.Columns[4].HeaderText = "ที่อยู่";
            dgv.Columns[5].HeaderText = "เบอร์โทร";
            dgv.Columns[6].HeaderText = "FAX";
            dgv.Columns[7].HeaderText = "เลชที่ผู้เสียภาษี";
            dgv.Columns[8].HeaderText = "ชื่อบัญชี";
            dgv.Columns[9].HeaderText = "เบอร์ติดต่อ(รายละเอียด)";
            dgv.Columns[10].HeaderText = "ธนาคาร";
            dgv.Columns[11].HeaderText = "โค้ด";
            dgv.Columns[12].HeaderText = "สาขา";
            dgv.Columns[13].HeaderText = "รหัส 1";
            dgv.Columns[14].HeaderText = "รหัส 2";
            dgv.Columns[15].HeaderText = "เลขที่บัญชี";
            dgv.Columns[16].HeaderText = "F16";
            dgv.Columns[17].HeaderText = "F17";
            dgv.Columns[18].HeaderText = "F18";
            dgv.Columns[19].HeaderText = "F19";
            dgv.Columns[20].HeaderText = "ผู้รับใบสั่งซื้อ";
            dgv.Columns[21].HeaderText = "ซ่อน";
            dgv.Columns[22].HeaderText = "X";
        }

        private double R4, R5, R6, S4, S5, S6 = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //tabControl1.SelectedTab = tabPage4;
                //textBox21.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                //textBox22.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            string StrQuery;
            //try
            //{
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.0.3;User ID=homc;Password=homc;Initial Catalog=INVS;Connection Timeout=10000000"))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    conn.Open();
                    var dgv = dgvCARD;

                    //DELETE TEMP
                    StrQuery = @"DELETE FROM " + txtTEMP.Text + "";
                    comm.CommandText = StrQuery;
                    comm.ExecuteNonQuery();

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        // INSERT TEMP
                        StrQuery = @"INSERT INTO " + txtTEMP.Text + "([Row],[WORKING_CODE],[R_S_STATUS],[ACTIVE_QTY],[VALUE],[COST],[R_ACTIVE_QTY],[R_VALUE],[R_COST]) VALUES ("
                                + dgv.Rows[i].Cells[0].Value + ", "
                                + dgv.Rows[i].Cells[1].Value + ", '"
                                + dgv.Rows[i].Cells[4].Value + "', "
                                + dgv.Rows[i].Cells[5].Value + ", "
                                + dgv.Rows[i].Cells[8].Value + ", "
                                + dgv.Rows[i].Cells[9].Value + ", "
                                + dgv.Rows[i].Cells[11].Value + ", "
                                + dgv.Rows[i].Cells[12].Value + ", "
                                + dgv.Rows[i].Cells[13].Value + ");";
                        comm.CommandText = StrQuery;
                        comm.ExecuteNonQuery();
                    }

                    //UPDATE ปรับคงคลังล่าสุด ตาราง CARD แก้ไขแล้ว
                    StrQuery = @"UPDATE C"
                                + " SET"
                                + " C.REMAIN_QTY	    =T.[R_ACTIVE_QTY],"
                                + " C.REMAIN_COST	=T.[R_VALUE], "
                                + " C.REMAIN_VALUE	=T.[R_COST]"
                                + " FROM [INVS].[dbo].[CARD]C INNER JOIN " + txtTEMP.Text + " T ON T.WORKING_CODE=C.WORKING_CODE AND C.Row=T.Row AND C.R_S_STATUS=T.R_S_STATUS"
                                + " WHERE C.STOCK_ID='" + txtSTOCK_ID.Text + "' AND C.WORKING_CODE='" + WORKING_CODE + "'";
                    comm.CommandText = StrQuery;
                    comm.ExecuteNonQuery();

                    //ปรับคงคลังล่าสุด ตาราง INV_MD แก้ไขแล้ว
                    //StrQuery = @"UPDATE M "
                    //        + " SET"
                    //        + " QTY_ON_HAND	=(SELECT TOP 1 [REMAIN_QTY]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC),"
                    //        + " TOTAL_COST	=(SELECT TOP 1 [REMAIN_VALUE]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC),"
                    //        + " TOTAL_VALUE	=(SELECT TOP 1 [REMAIN_COST]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC),"
                    //        + " FIRST_PACK_RATIO=(SELECT TOP 1 [ACTIVE_PACK]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC),"
                    //        + " LAST_PACK_RATIO =(SELECT TOP 1 [ACTIVE_PACK]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC),"
                    //        + " STD_PRICE       =(SELECT TOP 1 ([COST]/[ACTIVE_QTY])*[ACTIVE_PACK] FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE =M.WORKING_CODE AND STOCK_ID=M.DEPT_ID ORDER BY OPERATE_DATE DESC)"
                    //        + " FROM [INVS].[dbo].[INV_MD]M"
                    //        + " WHERE DEPT_ID='" + txtSTOCK_ID.Text + "' AND M.WORKING_CODE='" + WORKING_CODE + "'";
                    //comm.CommandText = StrQuery;
                    //comm.ExecuteNonQuery();

                    //ปรับคงคลังล่าสุด ตาราง INV_MD_C แก้ไขแล้ว
                    //if (txtREMAIN_STOCK.Text == "0")
                    //{
                    //    StrQuery = @"DELETE INV_MD_C WHERE WORKING_CODE='" + WORKING_CODE + "' AND DEPT_ID='" + txtSTOCK_ID.Text + "' AND (SELECT TOP 1 [REMAIN_QTY]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE ='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' ORDER BY OPERATE_DATE DESC)=0";
                    //    comm.CommandText = StrQuery;
                    //    comm.ExecuteNonQuery();
                    //}
                    //else if (dgvMD_C.Rows.Count > 1)
                    //{
                    //    StrQuery = @"UPDATE MC"
                    //            + " SET MC.LOT_NO=D.LOT_NO,MC.QTY_ON_HAND=D.QTY_ON_HAND,MC.PACK_RATIO=D.PACK_RATIO, MC.PACK_COST=D.PACK_COST,MC.EXPIRED_DATE=D.EXPIRED_DATE ,MC.LOT_COST=D.LOT_COST, MC.LOT_VALUE=D.LOT_VALUE"
                    //            + " FROM"
                    //            + " ("
                    //                + " SELECT A.LOT_NO ,SUM(A.ACTIVE_QTY)-CASE WHEN SUM(B.ACTIVE_QTY)IS NULL THEN '0' ELSE SUM(B.ACTIVE_QTY)END AS QTY_ON_HAND,A.ACTIVE_PACK AS PACK_RATIO, ( SELECT SUM(COST)/ACTIVE_QTY AS COST_PACK FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS='R' AND LOT_NO=A.LOT_NO GROUP BY ACTIVE_QTY)AS PACK_COST, A.EXPIRED_DATE, A.COST-ISNULL((	SELECT SUM(COST)FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS<>'R' AND LOT_NO=A.LOT_NO GROUP BY LOT_NO),0) AS LOT_COST, A.VALUE-ISNULL((	SELECT SUM(VALUE)FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS<>'R' AND LOT_NO=A.LOT_NO GROUP BY LOT_NO),0) AS LOT_VALUE"
                    //            + " FROM"
                    //                + " ("
                    //            + " SELECT (LOT_NO),SUM(ACTIVE_QTY)AS ACTIVE_QTY,OPERATE_DATE,COST,VALUE,WORKING_CODE,STOCK_ID,ACTIVE_PACK,EXPIRED_DATE"
                    //            + " FROM [CARD]"
                    //            + " WHERE WORKING_CODE='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' AND R_S_STATUS='R'"
                    //            + " GROUP BY LOT_NO,OPERATE_DATE,COST,VALUE,WORKING_CODE,STOCK_ID,ACTIVE_PACK,ACTIVE_PACK,EXPIRED_DATE"
                    //                + " )AS A"
                    //            + " LEFT JOIN "
                    //                + " ("
                    //                    + " SELECT (LOT_NO),SUM(ACTIVE_QTY)AS ACTIVE_QTY"
                    //            + " FROM [CARD]"
                    //            + " WHERE WORKING_CODE='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' AND R_S_STATUS<>'R'"
                    //            + " GROUP BY LOT_NO"
                    //                + " )AS B"
                    //            + " ON A.LOT_NO = B.LOT_NO"
                    //            + " GROUP BY A.LOT_NO,B.LOT_NO,A.OPERATE_DATE,B.ACTIVE_QTY, A.COST, A.VALUE,A.WORKING_CODE,A.STOCK_ID,A.ACTIVE_PACK,A.EXPIRED_DATE"
                    //            + " HAVING SUM(A.ACTIVE_QTY)>SUM(B.ACTIVE_QTY) OR SUM(A.ACTIVE_QTY)<SUM(B.ACTIVE_QTY) OR ISNULL(B.ACTIVE_QTY,0) =0"
                    //            + " )AS D"
                    //            + " INNER JOIN INV_MD_C MC ON MC.LOT_NO=D.LOT_NO AND MC.PACK_RATIO=D.PACK_RATIO AND MC.EXPIRED_DATE=D.EXPIRED_DATE ";
                    //    comm.CommandText = StrQuery;
                    //    comm.ExecuteNonQuery();
                    //}
                    //else if (dgvMD_C.Rows.Count == 1)
                    //{
                    //    StrQuery = @"UPDATE MC"
                    //             + " SET MC.LOT_NO=D.LOT_NO,MC.QTY_ON_HAND=D.QTY_ON_HAND,MC.PACK_RATIO=D.PACK_RATIO, MC.PACK_COST=D.PACK_COST,MC.EXPIRED_DATE=D.EXPIRED_DATE ,MC.LOT_COST=D.LOT_COST, MC.LOT_VALUE=D.LOT_VALUE"
                    //             + " FROM"
                    //             + " ("
                    //                 + " SELECT A.LOT_NO ,SUM(A.ACTIVE_QTY)-CASE WHEN SUM(B.ACTIVE_QTY)IS NULL THEN '0' ELSE SUM(B.ACTIVE_QTY)END AS QTY_ON_HAND,A.ACTIVE_PACK AS PACK_RATIO, ( SELECT SUM(COST)/ACTIVE_QTY AS COST_PACK FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS='R' AND LOT_NO=A.LOT_NO GROUP BY ACTIVE_QTY)AS PACK_COST, A.EXPIRED_DATE, A.COST-ISNULL((	SELECT SUM(COST)FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS<>'R' AND LOT_NO=A.LOT_NO GROUP BY LOT_NO),0) AS LOT_COST, A.VALUE-ISNULL((	SELECT SUM(VALUE)FROM [CARD]WHERE WORKING_CODE=A.WORKING_CODE AND STOCK_ID=A.STOCK_ID AND R_S_STATUS<>'R' AND LOT_NO=A.LOT_NO GROUP BY LOT_NO),0) AS LOT_VALUE"
                    //             + " FROM"
                    //                 + " ("
                    //             + " SELECT (LOT_NO),SUM(ACTIVE_QTY)AS ACTIVE_QTY,OPERATE_DATE,COST,VALUE,WORKING_CODE,STOCK_ID,ACTIVE_PACK,EXPIRED_DATE"
                    //             + " FROM [CARD]"
                    //             + " WHERE WORKING_CODE='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' AND R_S_STATUS='R'"
                    //             + " GROUP BY LOT_NO,OPERATE_DATE,COST,VALUE,WORKING_CODE,STOCK_ID,ACTIVE_PACK,ACTIVE_PACK,EXPIRED_DATE"
                    //                 + " )AS A"
                    //             + " LEFT JOIN "
                    //                 + " ("
                    //                     + " SELECT (LOT_NO),SUM(ACTIVE_QTY)AS ACTIVE_QTY"
                    //             + " FROM [CARD]"
                    //             + " WHERE WORKING_CODE='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' AND R_S_STATUS<>'R'"
                    //             + " GROUP BY LOT_NO"
                    //                 + " )AS B"
                    //             + " ON A.LOT_NO = B.LOT_NO"
                    //             + " GROUP BY A.LOT_NO,B.LOT_NO,A.OPERATE_DATE,B.ACTIVE_QTY, A.COST, A.VALUE,A.WORKING_CODE,A.STOCK_ID,A.ACTIVE_PACK,A.EXPIRED_DATE"
                    //             + " HAVING SUM(A.ACTIVE_QTY)>SUM(B.ACTIVE_QTY) OR SUM(A.ACTIVE_QTY)<SUM(B.ACTIVE_QTY) OR ISNULL(B.ACTIVE_QTY,0) =0"
                    //             + " )AS D"
                    //             + " INNER JOIN INV_MD_C MC ON MC.LOT_NO=D.LOT_NO AND MC.PACK_RATIO=D.PACK_RATIO AND MC.EXPIRED_DATE=D.EXPIRED_DATE ";
                    //    comm.CommandText = StrQuery;
                    //    comm.ExecuteNonQuery();

                    //    StrQuery = @"DELETE INV_MD_C WHERE WORKING_CODE='" + WORKING_CODE + "' AND DEPT_ID='" + txtSTOCK_ID.Text + "' AND (SELECT TOP 1 [REMAIN_QTY]FROM [INVS].[dbo].[CARD]WHERE WORKING_CODE ='" + WORKING_CODE + "' AND STOCK_ID='" + txtSTOCK_ID.Text + "' ORDER BY OPERATE_DATE DESC)=0";
                    //    comm.CommandText = StrQuery;
                    //    comm.ExecuteNonQuery();
                    //}
                    //else if (dgvMD_C.Rows.Count == 0)
                    //{
                    //    var sql = new DBClass().SqlExecute3(WORKING_CODE, txtSTOCK_ID.Text);
                    //}
                }

                ShowDataC_MD_MD_C();
            }

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dgvMD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMD.ClearSelection();
        }

        private void dgvMD_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMD_C.ClearSelection();
        }

        private void dgvCARD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCARD.ClearSelection();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DBClass().SqlShowDATA(txtSTOCK_ID.Text, "TOTAL_REMAIN_NOT_TAOTAL_LOT");
            var dgv = dgvWORKING_CODE_C;
            dgv.DataSource = dt;
            Cursor.Current = Cursors.Default;
        }

        private void ShowDataC_MD_MD_C()
        {
            //INV_MD
            DataTable dt_INV_MD = new DBClass().SqlSHOWDATA_INV_MD(WORKING_CODE, txtSTOCK_ID.Text);

            using (dt_INV_MD)
            {
                DataGridView dgv2 = dgvMD;
                dgv2.DataSource = dt_INV_MD;
            }

            //INV_MD_C
            DataTable INV_MD_C = new DBClass().SqlSHOWDATA_INV_MD_C(WORKING_CODE, txtSTOCK_ID.Text);

            // TOTAL_QTY_ON_HAND,TOTAL_LOT_COST,TOTAL_LOT_VALUE 1,5,6
            // แสดงข้อมูล คงคลังรวมตาม LOT, ราคา, มูลค่า
            int TOTAL_QTY_ON_HAND = 0; double TOTAL_LOT_COST = 0, TOTAL_LOT_VALUE = 0;
            for (int i = 0; i < INV_MD_C.Rows.Count; i++)
            {
                TOTAL_QTY_ON_HAND += Convert.ToInt32(INV_MD_C.Rows[i][1]);
                TOTAL_LOT_COST += Convert.ToDouble(INV_MD_C.Rows[i][5]);
                TOTAL_LOT_VALUE += Convert.ToDouble(INV_MD_C.Rows[i][6]);
            }
            txtTOTAL_QTY_ON_HAND.Text = TOTAL_QTY_ON_HAND.ToString();
            txtTOTAL_LOT_COST.Text = TOTAL_LOT_COST.ToString();
            txtTOTAL_LOT_VALUE.Text = TOTAL_LOT_VALUE.ToString();

            //ถ้า จำนวนคงคลังตาม LOT ไม่เท่ากับคงคลังรวม ให้ตัวเลขแสดงสีแดง ถ้าเท่ากันให้แสดงสีเขียว
            if (Convert.ToInt32(txtTOTAL_QTY_ON_HAND.Text) == Convert.ToInt32(dt_INV_MD.Rows[0][0]))
            {
                txtTOTAL_QTY_ON_HAND.BackColor = Color.FromArgb(77, 255, 0);
            }
            else
            {
                txtTOTAL_QTY_ON_HAND.BackColor = Color.FromArgb(255, 68, 0);
            }

            if (Convert.ToDouble(txtTOTAL_LOT_COST.Text) == Convert.ToDouble(dt_INV_MD.Rows[0][2]))
            {
                txtTOTAL_LOT_COST.BackColor = Color.FromArgb(77, 255, 0);
            }
            else
            {
                txtTOTAL_LOT_COST.BackColor = Color.FromArgb(255, 68, 0);
            }

            if (Convert.ToDouble(txtTOTAL_LOT_VALUE.Text) == Convert.ToDouble(dt_INV_MD.Rows[0][3]))
            {
                txtTOTAL_LOT_VALUE.BackColor = Color.FromArgb(77, 255, 0);
            }
            else
            {
                txtTOTAL_LOT_VALUE.BackColor = Color.FromArgb(255, 68, 0);
            }

            using (INV_MD_C)
            {
                DataGridView dgv3 = dgvMD_C;
                dgv3.DataSource = INV_MD_C;
            }
        }

        private void dgvWORKING_CODE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWORKING_CODE.Text = "";
        }

        private void txtWORKING_CODE_TextChanged(object sender, EventArgs e)
        {
            if (txtWORKING_CODE.TextLength == 7)
            {
                dgvWORKING_CODE_C.DataSource = null;
                dgvWORKING_CODE_C.Refresh();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DBClass().SqlShowDATA(txtSTOCK_ID.Text, "INV_FREE");
            var dgv = dgvWORKING_CODE_C;
            dgv.DataSource = dt;
            Cursor.Current = Cursors.Default;
        }

        private void dgvCARD_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu m = new ContextMenu();
            //    m.MenuItems.Add(new MenuItem("Update"));

            //    //int currentMouseOverRow = dgvCARD.HitTest(e.X, e.Y).RowIndex;

            //    //if (currentMouseOverRow >= 0)
            //    //{
            //    //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
            //    //}

            //    m.Show(dgvCARD, new Point(e.X, e.Y));

            //}
        }

        private int rowIndex = 0;

        private void ctMu_Click(object sender, EventArgs e)
        {
            var dgv1 = dgvMD_C;
            if (dgv1.Rows[rowIndex].IsNewRow)
            {
            }
            else
            {
                var LOT_NO = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                var QTY_ON_HAND = Math.Round(Convert.ToDouble(dgv1.Rows[rowIndex].Cells[1].Value.ToString()), 2);
                var PACK_RATIO = Math.Round(Convert.ToDouble(dgv1.Rows[rowIndex].Cells[2].Value.ToString()), 2);
                var PACK_COST = Math.Round(Convert.ToDouble(dgv1.Rows[rowIndex].Cells[3].Value.ToString()), 2);
                var TOTAL_COST = (QTY_ON_HAND * PACK_COST) / PACK_RATIO;
                var TOTAL_VALUE = (QTY_ON_HAND * PACK_COST) / PACK_RATIO;

                if (ctmUpdate.Items[0].Selected == true)
                {
                    var delete = "delete INV_MD_C where DEPT_ID = '" + txtSTOCK_ID.Text + "' and WORKING_CODE = '" + WORKING_CODE + "' and LOT_NO = '" + LOT_NO + "'";
                    int i2 = new DBClass().SqlExecuteDB3(delete);
                }
                else if (ctmUpdate.Items[1].Selected == true)
                {
                    var update = "update INV_MD_C set QTY_ON_HAND ='" + QTY_ON_HAND + "',PACK_COST='" + PACK_COST + "',LOT_COST='" + TOTAL_COST + "',LOT_VALUE='" + TOTAL_VALUE + "' where DEPT_ID = '" + txtSTOCK_ID.Text + "' and WORKING_CODE = '" + WORKING_CODE + "' and LOT_NO = '" + LOT_NO + "'";
                    int i2 = new DBClass().SqlExecuteDB3(update);
                }
                else if (ctmUpdate.Items[2].Selected == true)
                {
                    var update = "update INV_MD set QTY_ON_HAND ='" + QTY_ON_HAND + "',TOTAL_COST='" + TOTAL_COST + "',TOTAL_VALUE='" + TOTAL_VALUE + "' where DEPT_ID = '" + txtSTOCK_ID.Text + "' and WORKING_CODE = '" + WORKING_CODE + "'";
                    int i2 = new DBClass().SqlExecuteDB3(update);
                }

                ShowDataC_MD_MD_C();
            }
        }

        private void dgvCARD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var dgv1 = dgvCARD;
                dgv1.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dgv1.CurrentCell = dgv1.Rows[e.RowIndex].Cells[1];
                ctmCard.Show(dgv1, e.Location);
                ctmCard.Show(Cursor.Position);
            }
        }

        private void dgvCARD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCARD.CurrentRow.Cells[0].Value;
            var working_code = dgvCARD.CurrentRow.Cells[1].Value;
            var operate_date = Convert.ToDateTime(dgvCARD.CurrentRow.Cells[2].Value);
            var active_qty = Convert.ToDouble(dgvCARD.CurrentRow.Cells[5].Value);
            var pack = Convert.ToDouble(dgvCARD.CurrentRow.Cells[6].Value);
            var pack_cost = Convert.ToDouble(dgvCARD.CurrentRow.Cells[7].Value);
            var cost = (dgvCARD.CurrentRow.Cells[8].Value) = (active_qty / pack) * pack_cost;
            var value = dgvCARD.CurrentRow.Cells[9].Value = (active_qty / pack) * pack_cost;

            if (e.ColumnIndex == 5)
            {
                var StrQuery = "UPDATE [CARD]SET ACTIVE_QTY='" + active_qty + "',COST='" + cost + "',VALUE='" + value + "' WHERE STOCK_ID = '" + txtSTOCK_ID.Text + "' AND WORKING_CODE = '" + working_code + "' AND Row = '" + row + "'";
                var i = new DBClass().SqlExecute3(StrQuery);
            }
            else if (e.ColumnIndex == 2)
            {
                var StrQuery = "UPDATE [CARD] SET OPERATE_DATE='" + operate_date + "' WHERE STOCK_ID = '" + txtSTOCK_ID.Text + "' AND WORKING_CODE = '" + working_code + "' AND Row = '" + row + "'";
                var i = new DBClass().SqlExecute3(StrQuery);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DBClass().SqlGetData3("SELECT DISTINCT[WORKING_CODE]FROM[INV_MD]ORDER BY WORKING_CODE");
            var dgv = dgvWORKING_CODE_C;
            dgv.DataSource = dt;
            Cursor.Current = Cursors.Default;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var dgv = dgvWORKING_CODE_C;

            //var dgv = dgvWORKING_CODE;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                int counter = dgvWORKING_CODE_C.CurrentRow.Index + 1;
                DataGridViewRow nextRow = default(DataGridViewRow);
                if (counter == dgvWORKING_CODE_C.RowCount)
                {
                    nextRow = dgvWORKING_CODE_C.Rows[0];
                }
                else
                {
                    nextRow = dgvWORKING_CODE_C.Rows[counter];
                }

                dgvWORKING_CODE_C.CurrentCell = nextRow.Cells[0];
                nextRow.Selected = true;

                Thread.Sleep(2000);
                //if (dgv.CurrentRow != null)
                //    dgv.CurrentCell =
                //        dgv
                //        .Rows[Math.Min(dgv.CurrentRow.Index + 1, dgv.Rows.Count - 1)]
                //        .Cells[dgv.CurrentCell.ColumnIndex];
                //    dgv.Rows[2].Selected = true;

                //    dgv.Rows[2].Selected = false;
            }
        }

        private void dgvWORKING_CODE_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvWORKING_CODE_C.ClearSelection();
        }

        private string name_pc = "";
        private DataTable dt = null;
        private SqlParameterCollection param = null;
        private DataGridView dgv = null;

        private void ShowFaxDate()
        {
            Cursor.Current = Cursors.WaitCursor;
            var dates = dtpdatesFax.Value.ToString("yyyyMMdd");
            var datee = dtpdateeFax.Value.ToString("yyyyMMdd");
            var dept_id = txtDEPT_ID.Text;

            if (txtPO_NO.Text != "")
            {
                name_pc = "SHOW_FAX_DATE2";
                param = new SqlCommand().Parameters;
                param.AddWithValue("@dept_id", SqlDbType.Char).Value = txtDEPT_ID.Text;
                param.AddWithValue("@PO_NO", SqlDbType.NVarChar).Value = txtPO_NO.Text;
                dt = new DBClass().GetDataDB3(param, name_pc);
                dgv = dgvPO;
                dgv.DataSource = dt;
            }
            else
            {
                name_pc = "SHOW_FAX_DATE";
                param = new SqlCommand().Parameters;
                param.AddWithValue("@dates", SqlDbType.Char).Value = dates;
                param.AddWithValue("@datee", SqlDbType.Char).Value = datee;
                param.AddWithValue("@dept_id", SqlDbType.NVarChar).Value = dept_id;
                dt = new DBClass().GetDataDB3(param, name_pc);
                dgv = dgvPO;
                dgv.DataSource = dt;
            }
            Cursor.Current = Cursors.Default;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ShowFaxDate();
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            var dgv = dgvPO;
            var value1 = dgv.SelectedCells[3].Value;
            var value2 = dgv.SelectedCells[3].Value;
            var fax_date = dtpFAX.Value.ToString("yyyyMMdd");
            var fax_date2 = dtpFAX.Value.ToString("dd/MM/yyyy");
            if (!dgv.Rows[rowIndex].IsNewRow)
            {
                if (ctmY.Visible == true)
                {
                    dgv[7, rowIndex].Value = "Y";
                    dgv.UpdateCellValue(7, rowIndex);
                    var update = "update MS_PO set FLAG='Y',FAX_DATE='" + fax_date + "' WHERE PO_NO='" + dgv.SelectedCells[0].Value + "'";
                    dgv[6, rowIndex].Value = fax_date2;
                    dgv.UpdateCellValue(6, rowIndex);

                    int i2 = new DBClass().SqlExecuteDB3(update);
                }
                else if (ctmY.Visible == false)
                {
                    dgv[7, rowIndex].Value = "";
                    dgv.UpdateCellValue(7, rowIndex);
                    var update = "update MS_PO set FLAG=NULL,FAX_DATE=NULL WHERE PO_NO='" + dgv.SelectedCells[0].Value + "'";
                    dgv[6, rowIndex].Value = "";
                    dgv.UpdateCellValue(6, rowIndex);
                    int i2 = new DBClass().SqlExecuteDB3(update);
                }

                //var update = "update MS_PO set FLAG='" + value1 + "' WHERE PO_NO='" + value2 + "'";
                //int i2 = new DBClass().SqlExecute(update);
                //dgv.Rows[rowIndex].Selected = true;
            }
        }

        private void dgvPO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPO.ClearSelection();
        }

        private void dgvPO_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                if (e.Button == MouseButtons.Right)
                {
                    var dgv = dgvPO;
                    dgv.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                    contextMenuStrip1.Show(dgv, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                    if (dgv.SelectedCells[7].Value.ToString() == "")
                    {
                        ctmY.Visible = true;
                        ctmN.Visible = false;
                    }
                    else
                    {
                        ctmY.Visible = false;
                        ctmN.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtpdatesFax_ValueChanged(object sender, EventArgs e)
        {
            txtPO_NO.Text = "";
        }

        private void dtpdateeFax_ValueChanged(object sender, EventArgs e)
        {
            txtPO_NO.Text = "";
        }

        private void txtPO_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowFaxDate();
            }
        }

        private void txtPO_NO_TextChanged(object sender, EventArgs e)
        {
            if (txtPO_NO.TextLength == 10)
            {
                txtPO_NO.BackColor = Color.FromArgb(77, 255, 0);
            }
            else
            {
                txtPO_NO.BackColor = SystemColors.Window;
            }
        }

        private void dgvMD_C_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var dgv = dgvMD_C;
                dgv.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                ctmUpdate.Show(dgv, e.Location);
                ctmUpdate.Show(Cursor.Position);
            }
        }

        private void ctmCard_Click(object sender, EventArgs e)
        {
            var dgv1 = dgvCARD;
            if (dgv1.Rows[rowIndex].IsNewRow)
            {
            }
            else
            {
                var Row = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                var OPERATE_DATE = dgv1.Rows[rowIndex].Cells[2].Value.ToString();
                var R_S_DATE = dgv1.Rows[rowIndex].Cells[3].Value.ToString();
                var R_S_STATUS = dgv1.Rows[rowIndex].Cells[4].Value.ToString();
                var ACTIVE_QTY = dgv1.Rows[rowIndex].Cells[5].Value.ToString();
                var ACTIVE_PACK = dgv1.Rows[rowIndex].Cells[6].Value.ToString();
                var PACK_COST = dgv1.Rows[rowIndex].Cells[7].Value.ToString();
                var COST = dgv1.Rows[rowIndex].Cells[8].Value.ToString();
                var VALUE = dgv1.Rows[rowIndex].Cells[9].Value.ToString();
                var LOT_NO = dgv1.Rows[rowIndex].Cells[10].Value.ToString();
                var REMAIN_QTY = dgv1.Rows[rowIndex].Cells[11].Value.ToString();
                var REMAIN_COST = dgv1.Rows[rowIndex].Cells[12].Value.ToString();
                var REMAIN_VALUE = dgv1.Rows[rowIndex].Cells[13].Value.ToString();

                if (ctmCard.Items[0].Selected == true)
                {
                    var delete = "delete CARD where STOCK_ID = '" + txtSTOCK_ID.Text + "' and WORKING_CODE = '" + WORKING_CODE + "' and Row = '" + Row + "'";
                    int i2 = new DBClass().SqlExecuteDB3(delete);
                }
                else if (ctmCard.Items[1].Selected == true)
                {
                    var update = "update CARD set ACTIVE_QTY ='" + ACTIVE_QTY + "',ACTIVE_PACK='" + ACTIVE_PACK + "',COST='" + COST + "',VALUE='" + VALUE + "',LOT_NO='" + LOT_NO + "' where STOCK_ID = '" + txtSTOCK_ID.Text + "' and WORKING_CODE = '" + WORKING_CODE + "' and Row = '" + Row + "'";
                    int i2 = new DBClass().SqlExecuteDB3(update);
                }

                ShowDataC_MD_MD_C();
            }
        }

        private void txtSUB_PO_NO1_TextChanged(object sender, EventArgs e)
        {
            var text = txtSUB_PO_NO1;
            if (text.TextLength == 10)
            {
                text.BackColor = Color.FromArgb(77, 255, 0);
                var sql = "SELECT DEPT_ID+' : '+DEPT_NAME AS DEPT_NAME FROM DEPT_ID WHERE DEPT_ID IN(SELECT DEPT_ID FROM SM_PO WHERE SUB_PO_NO = '" + txtSUB_PO_NO1.Text + "')";
                var dt = new DBClass().SqlGetData3(sql);
                txtDEPT_OLD.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                text.BackColor = SystemColors.Window;
            }
        }

        private void txtDEPT_TextChanged(object sender, EventArgs e)
        {
            //var text = txtDEPT_NEW.Text;
            var dgv = dgvDEPT;

            //if (text.Length < 1)
            //{
            //    dgv.Visible = false;
            //}
            //else
            //{
            //    dgv.Visible = true;
            //}
            cbxDEPT(dgv);
        }

        private void cbxDEPT(DataGridView dgv)
        {
            var sql = "SELECT RTRIM(DEPT_ID) +' : '++RTRIM([DEPT_NAME])AS DEPT_NAME"
                   + " FROM[DEPT_ID]"
                   + " WHERE HIDE = 'N' AND(DEPT_ID +' : '+DEPT_NAME LIKE '%" + txtDEPT_NEW.Text + "%')"
                   + " ORDER BY DEPT_NAME";
            var dt = new DBClass().SqlGetData3(sql);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 200;
            dgv.Columns[0].HeaderText = "หน่วยงาน";
        }

        private void txtSCompany_TextChanged(object sender, EventArgs e)
        {
            ShowCOMPANY();
        }

        private void dgvCOMPANY_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCOMPANY.ClearSelection();
        }

        private void dgvCOMPANY_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvCOMPANY;
            if (e.Button == MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(dgv, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                if (dgv.SelectedCells[19].Value.ToString() == "N")
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
                btnCancel1.Enabled = false;
            }
            else
            {
                txtCOMPANY_CODE.Text = dgv.SelectedCells[0].Value.ToString();
                txtKEY_WORD.Text = dgv.SelectedCells[1].Value.ToString();
                cbxBUSINESS_NAME.Text = dgv.SelectedCells[2].Value.ToString();
                txtCOMPANY_NAME.Text = dgv.SelectedCells[3].Value.ToString();
                txtADDRESS.Text = dgv.SelectedCells[4].Value.ToString();
                txtTEL.Text = dgv.SelectedCells[5].Value.ToString();
                txtFAX.Text = dgv.SelectedCells[6].Value.ToString();
                txtTAX_ID.Text = dgv.SelectedCells[7].Value.ToString();
                txtBANK_NAME.Text = dgv.SelectedCells[8].Value.ToString();
                txtPHONE_DETAIL.Text = dgv.SelectedCells[9].Value.ToString();
                txtBANK.Text = dgv.SelectedCells[10].Value.ToString();
                txtCODE_BANK.Text = dgv.SelectedCells[11].Value.ToString();
                txtBRANCH.Text = dgv.SelectedCells[12].Value.ToString();
                txtCODE1.Text = dgv.SelectedCells[13].Value.ToString();
                txtCODE2.Text = dgv.SelectedCells[14].Value.ToString();
                txtBANK_NO.Text = dgv.SelectedCells[15].Value.ToString();
                txtF16.Text = dgv.SelectedCells[16].Value.ToString();
                txtF17.Text = dgv.SelectedCells[17].Value.ToString();
                txtF18.Text = dgv.SelectedCells[18].Value.ToString();
                txtF19.Text = dgv.SelectedCells[19].Value.ToString();
                txtNAME_PO.Text = dgv.SelectedCells[20].Value.ToString();

                if (dgv.SelectedCells[22].Value.ToString() == "")
                {
                    ckbX.Checked = false;
                }
                else
                {
                    ckbX.Checked = true;
                }

                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;
                btnCancel1.Enabled = false;
            }
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave1.Enabled = true;
                btnEdit1.Enabled = false;
                btnCancel1.Enabled = true;
                btnSave1.Focus();
                Edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            var dgv = dgvCOMPANY;

            if (Edit == false)
            {
                try
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (dgv.Rows[i].Cells[1].Value.ToString() == txtCOMPANY_NAME.Text)
                        {
                            MessageBox.Show("ชื่อบรัษทซ้ำ", "คำเตือน");
                            return;
                        }
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่มข้อมูลบริษัท " + txtCOMPANY_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var id = "SELECT MAX([ST_ID]) FROM [CARU2_COS_NEW_STOCK]";
                        int ST_ID = new DBClass().AutoNunber(id);
                        //var save = "insert into [CARU2_COS_NEW_STOCK] ([ST_NAME],[ST_UNIT],[ST_IN],[ST_PRICE],[HIDE])VALUES ('" + txtST_NAME.Text + "','" + cbxST_UNIT.SelectedValue + "','" + nudST_IN.Value + "','" + txtST_PRICE.Text + "','Y')";
                        //int isave = new DBClass().SqlExecute3(save);
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
                    string X = "";
                    if (ckbX.Checked == true)
                    {
                        X = "'Y'";
                    }
                    else
                    {
                        X = "NULL";
                    }
                    if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลบริษัท " + txtCOMPANY_NAME.Text + " ใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var save = "UPDATE COMPANY SET FAX='" + txtFAX.Text + "',X=" + X + " WHERE COMPANY_CODE='" + dgv.SelectedCells[0].Value.ToString() + "'";
                        int isave = new DBClass().SqlExecute3(save);
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
            btnCancel1.Enabled = false;
            Edit = false;
            txtSCompany.Text = "";
            ShowCOMPANY();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnEdit1.Enabled = false;
            btnCancel1.Enabled = false;
            Edit = false;
            dgvCOMPANY.ClearSelection();
            txtSCompany.Focus();
            ShowCOMPANY();
        }

        private string Getdata(string sql, DataGridView dgv)
        {
            dgv.DataSource = new DBClass().SqlGetData3(sql);
            return dgv.Rows.Count.ToString();
        }

        private void Show_Working_code_Chang()
        {
            lbSM_PO_C.Text = "SM_PO_C";
            lbSM_PO_C.Text = lbSM_PO_C.Text + "(" + Getdata("SELECT DISTINCT WORKING_CODE FROM SM_PO_C  WHERE LEN(WORKING_CODE) < 7 ORDER BY WORKING_CODE", dgvSM_PO_C) + ")";

            lbPACK_RATIO.Text = "PACK_RATIO";
            lbPACK_RATIO.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM PACK_RATIO  WHERE LEN(WORKING_CODE) < 7 ORDER BY WORKING_CODE", dgvPACK_RATIO);

            lbMS_PO_C.Text = "MS_PO_C";
            lbMS_PO_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MS_PO_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMS_PO_C);

            lbMS_IVO_C.Text = "MS_IVO_C";
            lbMS_IVO_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MS_IVO_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMS_IVO_C);

            lbINV_MD_C.Text = "INV_MD_C";
            lbINV_MD_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM INV_MD_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvINV_MD_C);

            lbDRUG_VN.Text = "DRUG_VN";
            lbDRUG_VN.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM DRUG_VN  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvDRUG_VN);

            lbDRUG_GN.Text = "DRUG_GN";
            lbDRUG_GN.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM DRUG_GN  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvDRUG_GN);

            lbCNT_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM CNT_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvCNT_C);
            lbCARD.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM CARD  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvCARD);
            lbBUYPLAN_LOG.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM BUYPLAN_LOG  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvBUYPLAN_LOG);
            lbBILL.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM BILL  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvBILL);
            lbACCR_DISP.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM ACCR_DISP  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvACCR_DISP);
            lbFOCUS_LIST_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM FOCUS_LIST_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvFOCUS_LIST_C);
            lbINV_HAS_HIS.Text = Getdata("SELECT DISTINCT INV_CODE FROM INV_HAS_HIS  WHERE LEN(INV_CODE)< 7 ORDER BY INV_CODE", dgvINV_HAS_HIS);
            lbINV_RTN_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM INV_RTN_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvINV_RTN_C);
            lbINVITATION_DRUG.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM INVITATION_DRUG  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvINVITATION_DRUG);
            lbLOCATION.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM LOCATION  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvLOCATION);
            lbMBS_RE_M.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MBS_RE_M  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMBS_RE_M);
            lbMBS_RE_Y.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MBS_RE_Y  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMBS_RE_Y);
            lbMS_IVO_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MS_IVO_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMS_IVO_C);
            lbMS_PO_C.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM MS_PO_C  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvMS_PO_C);
            lbQUALI_GOAL.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM QUALI_GOAL  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvQUALI_GOAL);
            lbQUALI_RCV.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM QUALI_RCV  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvQUALI_RCV);
            lbSM_PO_E.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM SM_PO_E  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvSM_PO_E);
            lbTEMP.Text = Getdata("SELECT DISTINCT WORKING_CODE FROM TEMP  WHERE LEN(WORKING_CODE)< 7 ORDER BY WORKING_CODE", dgvTEMP);
        }

        private void btnSworking_code_Click(object sender, EventArgs e)
        {
            Show_Working_code_Chang();
        }

        private void dgvSM_PO_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSM_PO_C.ClearSelection();
        }

        private void dgvPACK_RATIO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPACK_RATIO.ClearSelection();
        }

        private void dgvMS_PO_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMS_PO_C.ClearSelection();
        }

        private void dgvMS_IVO_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMS_IVO_C.ClearSelection();
        }

        private void dgvINV_MD_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvINV_MD_C.ClearSelection();
        }

        private void dgvDRUG_VN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDRUG_VN.ClearSelection();
        }

        private void dgvDRUG_GN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDRUG_GN.ClearSelection();
        }

        private void dgvCNT_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCNT_C.ClearSelection();
        }

        private void dgvCARD2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCARD2.ClearSelection();
        }

        private void dgvBUYPLAN_LOG_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBUYPLAN_LOG.ClearSelection();
        }

        private void dgvBUYPLAN_C_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBUYPLAN_C.ClearSelection();
        }

        private void dgvACCR_DISP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvACCR_DISP.ClearSelection();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการเปลี่ยนรหัสยาใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var WORKING_CODE = dgvSM_PO_C.SelectedCells[0].Value.ToString();
                var WORKING_CODE_CHANG = txtWORKING_CODE_CHANG.Text;
                var update_SM_PO_C = "update SM_PO_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_SM_PO_C = new DBClass().SqlExecuteDB3(update_SM_PO_C);

                var update_PACK_RATIO = "update PACK_RATIO set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_PACK_RATIO = new DBClass().SqlExecuteDB3(update_PACK_RATIO);

                var update_MS_PO_C = "update MS_PO_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_MS_PO_C = new DBClass().SqlExecuteDB3(update_MS_PO_C);

                var update_MS_IVO_C = "update MS_IVO_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_MS_IVO_C = new DBClass().SqlExecuteDB3(update_MS_IVO_C);

                var update_INV_MD_C = "update INV_MD_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_INV_MD_C = new DBClass().SqlExecuteDB3(update_INV_MD_C);

                var update_DRUG_VN = "update DRUG_VN set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_DRUG_VN = new DBClass().SqlExecuteDB3(update_DRUG_VN);

                var update_DRUG_GN = "update DRUG_GN set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_DRUG_GN = new DBClass().SqlExecuteDB3(update_DRUG_GN);

                var update_CNT_C = "update CNT_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_CNT_C = new DBClass().SqlExecuteDB3(update_CNT_C);

                var update_CARD = "update CARD set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_CARD = new DBClass().SqlExecuteDB3(update_CARD);

                var update_BUYPLAN_LOG = "update BUYPLAN_LOG set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_BUYPLAN_LOG = new DBClass().SqlExecuteDB3(update_BUYPLAN_LOG);

                var update_BUYPLAN_C = "update BUYPLAN_C set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_BUYPLAN_C = new DBClass().SqlExecuteDB3(update_BUYPLAN_C);

                var update_ACCR_DISP = "update ACCR_DISP set WORKING_CODE ='" + WORKING_CODE_CHANG + "' WHERE WORKING_CODE='" + WORKING_CODE + "'";
                int i_update_ACCR_DISP = new DBClass().SqlExecuteDB3(update_ACCR_DISP);

                Show_Working_code_Chang();
                txtWORKING_CODE_CHANG.Text = "";
            }
        }

        private void txtWORKING_CODE_CHANG_TextChanged(object sender, EventArgs e)
        {
            if (txtWORKING_CODE_CHANG.TextLength == 7)
            {
                btnSave_Chang.Enabled = true;
            }
            else
            {
                btnSave_Chang.Enabled = false;
            }
        }

        private void dgvSM_PO_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvSM_PO_C;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvPACK_RATIO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvPACK_RATIO;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvMS_PO_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvMS_PO_C;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvMS_IVO_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvMS_IVO_C;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvINV_MD_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvINV_MD_C;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvDRUG_VN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvDRUG_VN;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvDRUG_GN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvDRUG_GN;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvCNT_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var dgv = dgvCNT_C;
            try
            {
                txtWORKING_OLD.Text = dgv.SelectedCells[0].Value.ToString();
                txtWORKING_CODE_CHANG.Text = "";
            }
            catch
            {
            }
        }

        private void dgvCARD2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtWORKING_OLD.Text = dgvCARD2.SelectedCells[0].Value.ToString();
            txtWORKING_CODE_CHANG.Text = "";
            dgvSM_PO_C.ClearSelection();
            dgvPACK_RATIO.ClearSelection();
            dgvMS_PO_C.ClearSelection();
            dgvMS_IVO_C.ClearSelection();
            dgvINV_MD_C.ClearSelection();
            dgvDRUG_VN.ClearSelection();
            dgvDRUG_GN.ClearSelection();
            dgvCNT_C.ClearSelection();
            //dgvCARD2.ClearSelection();
            dgvBUYPLAN_LOG.ClearSelection();
            dgvBUYPLAN_C.ClearSelection();
            dgvACCR_DISP.ClearSelection();
        }

        private void dgvBUYPLAN_LOG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtWORKING_OLD.Text = dgvBUYPLAN_LOG.SelectedCells[0].Value.ToString();
            txtWORKING_CODE_CHANG.Text = "";
            dgvSM_PO_C.ClearSelection();
            dgvPACK_RATIO.ClearSelection();
            dgvMS_PO_C.ClearSelection();
            dgvMS_IVO_C.ClearSelection();
            dgvINV_MD_C.ClearSelection();
            dgvDRUG_VN.ClearSelection();
            dgvDRUG_GN.ClearSelection();
            dgvCNT_C.ClearSelection();
            dgvCARD2.ClearSelection();
            //dgvBUYPLAN_LOG.ClearSelection();
            dgvBUYPLAN_C.ClearSelection();
            dgvACCR_DISP.ClearSelection();
        }

        private void dgvBUYPLAN_C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtWORKING_OLD.Text = dgvBUYPLAN_C.SelectedCells[0].Value.ToString();
            txtWORKING_CODE_CHANG.Text = "";
            dgvSM_PO_C.ClearSelection();
            dgvPACK_RATIO.ClearSelection();
            dgvMS_PO_C.ClearSelection();
            dgvMS_IVO_C.ClearSelection();
            dgvINV_MD_C.ClearSelection();
            dgvDRUG_VN.ClearSelection();
            dgvDRUG_GN.ClearSelection();
            dgvCNT_C.ClearSelection();
            dgvCARD2.ClearSelection();
            dgvBUYPLAN_LOG.ClearSelection();
            //dgvBUYPLAN_C.ClearSelection();
            dgvACCR_DISP.ClearSelection();
        }

        private void dgvACCR_DISP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtWORKING_OLD.Text = dgvACCR_DISP.SelectedCells[0].Value.ToString();
            txtWORKING_CODE_CHANG.Text = "";
            dgvSM_PO_C.ClearSelection();
            dgvPACK_RATIO.ClearSelection();
            dgvMS_PO_C.ClearSelection();
            dgvMS_IVO_C.ClearSelection();
            dgvINV_MD_C.ClearSelection();
            dgvDRUG_VN.ClearSelection();
            dgvDRUG_GN.ClearSelection();
            dgvCNT_C.ClearSelection();
            dgvCARD2.ClearSelection();
            dgvBUYPLAN_LOG.ClearSelection();
            dgvBUYPLAN_C.ClearSelection();
            //dgvACCR_DISP.ClearSelection();
        }

        private void dgvSM_PO_C_MouseClick(object sender, MouseEventArgs e)
        {
            txtWORKING_OLD.Text = dgvSM_PO_C.SelectedCells[0].Value.ToString();
            txtWORKING_CODE_CHANG.Text = "";
            //dgvSM_PO_C.ClearSelection();
            dgvPACK_RATIO.ClearSelection();
            dgvMS_PO_C.ClearSelection();
            dgvMS_IVO_C.ClearSelection();
            dgvINV_MD_C.ClearSelection();
            dgvDRUG_VN.ClearSelection();
            dgvDRUG_GN.ClearSelection();
            dgvCNT_C.ClearSelection();
            dgvCARD2.ClearSelection();
            dgvBUYPLAN_LOG.ClearSelection();
            dgvBUYPLAN_C.ClearSelection();
            dgvACCR_DISP.ClearSelection();
        }

        private void dgvDEPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDEPT_NEW.Text = dgvDEPT.SelectedCells[0].Value.ToString();
            dgvDEPT.Visible = false;
        }

        private void txtDEPT_NEW_MouseClick(object sender, MouseEventArgs e)
        {
            txtDEPT_NEW.Text = "";
            var dgv = dgvDEPT;
            dgv.Visible = true;
            cbxDEPT(dgv);
        }

        private void txtDEPT_NEW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDEPT_NEW.Text = dgvDEPT.SelectedCells[0].Value.ToString();
                dgvDEPT.Visible = false;
            }
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            var DEPT_NEW = txtDEPT_NEW.Text;
            var SUB_PO_NO = txtSUB_PO_NO1.Text;

            var sql = "SELECT SUBSTRING('" + DEPT_NEW + "',0,CHARINDEX(':','" + DEPT_NEW + "')-1)AS DEPT_ID";
            var dt = new DBClass().SqlGetData3(sql);
            var DEPT_ID = dt.Rows[0][0].ToString();

            var update_SM_PO = "UPDATE [SM_PO]SET DEPT_ID='" + DEPT_ID + "' WHERE(SUB_PO_NO = '" + SUB_PO_NO + "') AND(R_S_STATUS = 'T')";
            int i_SM_PO = new DBClass().SqlExecuteDB3(update_SM_PO);

            var update_CARD = "UPDATE [CARD] SET DEPT_ID='" + DEPT_ID + "' WHERE(R_S_NUMBER = '" + SUB_PO_NO + "') AND(R_S_STATUS = 'S') AND(STOCK_ID = '20')";
            int i_CARD = new DBClass().SqlExecuteDB3(update_CARD);

            MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSUB_PO_NO1.Text = "";
            txtDEPT_OLD.Text = "";
            txtDEPT_NEW.Text = "";
        }

        private void chkCOMPANY_HIDE_Click(object sender, EventArgs e)
        {
            ShowCOMPANY();
        }

        private void cbxBUSINESS_NAME_Click(object sender, EventArgs e)
        {
            try
            {
                var strcbxPART_NAME = "SELECT[BUSINESS_TYPE],[BUSINESS_NAME]FROM[BUSINESS_TYPE]ORDER BY [BUSINESS_NAME]";
                var dt1 = new DBClass().SqlGetData3(strcbxPART_NAME);
                cbxBUSINESS_NAME.DataSource = dt1;
                cbxBUSINESS_NAME.ValueMember = "BUSINESS_TYPE";
                cbxBUSINESS_NAME.DisplayMember = "BUSINESS_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาดเนื่องจาก" + ex.Message, "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการแก้ไขวันที่รับใช่หรือไม่", "ทำการยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var dtpdatetime = dtpRECEIVE_DATE.Value.ToString("yyyyMMdd");
                    var year = Int32.Parse(dtpdatetime.Substring(0, 4)) - 543;
                    var mount = dtpdatetime.Substring(4, 2);
                    var day = dtpdatetime.Substring(6, 2);
                    var date = year + mount + day;

                    var update_MS_IVO = "update MS_IVO set RECEIVE_DATE ='" + date + "' WHERE RECEIVE_NO='" + txtRECEIVE_NO.Text + "' and INVOICE_NO='" + txtINVOICE.Text + "'";
                    int i_MS_IVO = new DBClass().SqlExecuteDB3(update_MS_IVO);

                    var update_CARD = "update CARD set R_S_DATE ='" + date + "' WHERE R_S_NUMBER='" + txtRECEIVE_NO.Text + "'";
                    int i_CARD = new DBClass().SqlExecuteDB3(update_CARD);
                    MessageBox.Show("บันทึกสำเร็จ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ผิดพลาด " + ex.Message);
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void txtINVOICE_TextChanged(object sender, EventArgs e)
        {
            btnSaveRECEVIE();
        }

        private void txtRECEIVE_NO_TextChanged(object sender, EventArgs e)
        {
            btnSaveRECEVIE();
        }

        private void GetdataRECEVICE()
        {
            if (txtRECEIVE_NO.TextLength > 0)
            {
                try
                {
                    var sql = "SELECT INVOICE_NO,dbo.ce2dmy1(RECEIVE_DATE)AS RECEIVE_DATE FROM [MS_IVO]WHERE RECEIVE_NO='" + txtRECEIVE_NO.Text + "'";
                    var dt = new DBClass().SqlGetData(sql);
                    txtINVOICE.Text = dt.Rows[0][0].ToString();
                    //txtINVOICE_2.Text = dt.Rows[1][0].ToString();
                    dtpRECEIVE_DATE.Text = dt.Rows[0][1].ToString();
                }
                catch
                {
                }
            }
            else if (txtINVOICE.TextLength > 0)
            {
                try
                {
                    var sql = "SELECT RECEIVE_NO,dbo.ce2dmy1(RECEIVE_DATE)AS RECEIVE_DATE FROM [MS_IVO]WHERE INVOICE_NO='" + txtINVOICE.Text + "'";
                    var dt = new DBClass().SqlGetData3(sql);
                    txtRECEIVE_NO.Text = dt.Rows[0][0].ToString();
                    txtRECEIVE_NO_2.Text = dt.Rows[1][0].ToString();
                    dtpRECEIVE_DATE.Text = dt.Rows[0][1].ToString();
                }
                catch
                {
                }
            }
            else if (txtRECEIVE_NO.TextLength == 0)
            {
                txtINVOICE.Text = "";
            }
            else if (txtINVOICE.TextLength == 0)
            {
                txtRECEIVE_NO.Text = "";
            }
        }

        private void btnSaveRECEVIE()
        {
            if (txtINVOICE.TextLength > 0 && txtRECEIVE_NO.TextLength > 0)
            {
                btnSaveRECEIVE_DATE.Enabled = true;
            }
            else
            {
                btnSaveRECEIVE_DATE.Enabled = false;
            }
        }

        private void txtRECEIVE_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetdataRECEVICE();
            }
        }

        private void txtINVOICE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetdataRECEVICE();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            txtRECEIVE_NO.Text = "";
        }

        private void label16_Click(object sender, EventArgs e)
        {
            txtINVOICE.Text = "";
        }

        private void cbxDEPT_ID_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string sql = "SELECT DEPT_ID,DEPT_NAME FROM dbo.DEPT_ID WHERE HOSP_TYPE='1' AND INV_TYPE='3' AND DEPT_TYPE='3'";
                dt = new DBClass().SqlGetData(sql);
                var cbx = cbxDEPT_ID;
                cbx.DataSource = dt;
                cbx.DisplayMember = "DEPT_NAME";
                cbx.ValueMember = "DEPT_ID";

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void cbxDEPT_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cbx = cbxDEPT_ID;
            bool DEPT_ID = IniFileHelper.WriteValue("INVS_UPDATE", "DEPT_ID",cbx.SelectedValue.ToString() , Path.GetFullPath(fileconfig));
            bool DEPT_NAME = IniFileHelper.WriteValue("INVS_UPDATE", "DEPT_NAME",cbx.Text.ToString() , Path.GetFullPath(fileconfig));
        }

        private void dgvMedcode_not_match_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDEPT.ClearSelection();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private string WORKING_CODE = "";

        private void button3_Click(object sender, EventArgs e)
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            //if (tabControl1.SelectedIndex == 2)
            //{
            if (dgvWORKING_CODE_C.SelectedRows.Count == 1)
            {
                WORKING_CODE = dgvWORKING_CODE_C.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                WORKING_CODE = txtWORKING_CODE.Text;
            }

            DataTable dt1 = new DBClass().SqlSORTROW(WORKING_CODE, txtSTOCK_ID.Text);

            DataTable dt = new DBClass().SqlCountActiveValueCost2(WORKING_CODE, txtSTOCK_ID.Text);
            var dgv = dgvCARD;
            dgv.DataSource = dt;

            dgv.Columns[0].Width = 40;
            dgv.Columns[1].Width = 60;
            dgv.Columns[2].Width = 125;
            dgv.Columns[3].Width = 80;
            dgv.Columns[4].Width = 75;
            dgv.Columns[5].Width = 75;
            dgv.Columns[6].Width = 75;
            dgv.Columns[7].Width = 75;
            dgv.Columns[8].Width = 75;
            dgv.Columns[9].Width = 75;
            dgv.Columns[10].Width = 75;
            dgv.Columns[14].Width = 40;

            ShowData(dgv);

            ShowDataC_MD_MD_C();

            //var sql2 = "SELECT ISNULL(MIN(WORKING_CODE),'0')AS WORKING_CODE,ISNULL(MIN(REMAIN_QTY),'0')AS REMAIN_QTY,ISNULL(MIN(REMAIN),'0')AS REMAIN FROM"
            //+ "(SELECT DISTINCT C.WORKING_CODE,"
            //+ " CAST(("
            //        + " SELECT TOP 1 REMAIN_QTY"
            //        + " FROM CARD"
            //        + " WHERE USER_ID = 'สันติ ส' AND STOCK_ID = '" + txtSTOCK_ID.Text + "' AND OPERATE_DATE BETWEEN '2000-01-01' AND '2017-10-01' AND WORKING_CODE = C.WORKING_CODE"
            //        + " GROUP BY WORKING_CODE, REMAIN_QTY, OPERATE_DATE"
            //        + " ORDER BY OPERATE_DATE DESC, WORKING_CODE"
            //+ " )AS decimal(18, 2))AS REMAIN_QTY, CAST(S5.REMAIN AS decimal(18, 2))AS REMAIN"
            //+ " FROM CARD C"
            //+ " INNER JOIN[192.168.0.5].[UHDATA].[dbo].[STOCKSTOCK] S5 WITH (NOLOCK)ON S5.CODE = C.WORKING_CODE"
            //+ " WHERE[USER_ID] = 'สันติ ส' AND C.STOCK_ID = '" + txtSTOCK_ID.Text + "' AND C.OPERATE_DATE BETWEEN '2000-01-01' AND '2017-10-01' AND WORKING_CODE = '" + WORKING_CODE + "'"
            //+ " AND  CAST(REMAIN_QTY AS decimal(18, 2)) != CAST(REMAIN AS decimal(18, 2))"
            //+ " GROUP BY C.WORKING_CODE, C.OPERATE_DATE, S5.REMAIN)AS D";
            //var dt2 = new DBClass().SqlGetData3(sql2);
            ////คงเหลือโปรแกรมสต๊อกเดิม
            //txtREMAIN_INVS.Text = dt2.Rows[0][2].ToString();

            Cursor.Current = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DBClass().SqlSORTROW(WORKING_CODE, txtSTOCK_ID.Text);

            DataTable dt = new DBClass().SqlCountActiveValueCost();
            var dgv = dgvCARD;
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 40;
            dgv.Columns[1].Width = 80;
            dgv.Columns[2].Width = 80;
            dgv.Columns[3].Width = 40;
            dgv.Columns[4].Width = 60;
            dgv.Columns[5].Width = 60;
            dgv.Columns[6].Width = 60;
            dgv.Columns[7].Width = 60;
            dgv.Columns[8].Width = 60;
            dgv.Columns[9].Width = 60;
            dgv.Columns[10].Width = 60;
            ShowData(dgv);
        }

        private void ShowData(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                var R_S_STATUS = dgv.Rows[i].Cells[4].Value.ToString();
                var Row_END = dgvCARD.Rows[i].Cells[14].Value.ToString();
                var ACTIVE_QTY = Math.Round(Convert.ToDouble(dgv.Rows[i].Cells[5].Value), 2);
                var COST = Math.Round(Convert.ToDouble(dgv.Rows[i].Cells[8].Value), 2);
                var VALUE = Math.Round(Convert.ToDouble(dgv.Rows[i].Cells[9].Value), 2);

                if (R_S_STATUS == "R" && dgv.Rows[i].Index == 0)    //แถวแรก
                {
                    dgvCARD.Rows[i].Cells[11].Value = Math.Round(ACTIVE_QTY, 2);
                    dgvCARD.Rows[i].Cells[12].Value = Math.Round(COST, 2);
                    dgvCARD.Rows[i].Cells[13].Value = Math.Round(VALUE, 2);
                }
                else if (R_S_STATUS == "S" && dgv.Rows[i].Index == 0)//แถวแรก
                {
                    MessageBox.Show("ผิดพลาด จ่ายออกก่อนรับ ต้องปรับวันที่รับให้อยู่ลำดับก่อนจ่ายออก");
                    return;
                }
                else if (R_S_STATUS == "R" || R_S_STATUS == "G")
                {
                    R4 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[11].Value), 2) + Math.Round(ACTIVE_QTY, 2), 2);
                    R5 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[12].Value), 2) + Math.Round(COST, 2), 2);
                    R6 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[13].Value), 2) + Math.Round(VALUE, 2), 2);
                    dgvCARD.Rows[i].Cells[11].Value = Math.Round(R4, 2);
                    dgvCARD.Rows[i].Cells[12].Value = Math.Round(R5, 2);
                    dgvCARD.Rows[i].Cells[13].Value = Math.Round(R6, 2);
                }
                else
                {
                    if (i > 0)
                    {
                        S4 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[11].Value), 2) - Math.Round(ACTIVE_QTY, 2), 2);
                        S5 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[12].Value), 2) - Math.Round(COST, 2), 2);
                        S6 = Math.Round(Math.Round(Convert.ToDouble(dgv.Rows[i - 1].Cells[13].Value), 2) - Math.Round(VALUE, 2), 2);
                        dgvCARD.Rows[i].Cells[11].Value = Math.Round(S4, 2);
                        dgvCARD.Rows[i].Cells[12].Value = Math.Round(S5, 2);
                        dgvCARD.Rows[i].Cells[13].Value = Math.Round(S6, 2);
                    }
                }

                if (Row_END == "Y")
                {
                    txtREMAIN_STOCK.Text = dgvCARD.Rows[i].Cells[11].Value.ToString();

                    if (dgvCARD.Rows[i].Cells[11].Value.ToString() == txtREMAIN_STOCK.Text)
                    {
                        txtREMAIN_STOCK.BackColor = Color.FromArgb(77, 255, 0);
                    }
                    else
                    {
                        txtREMAIN_STOCK.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    dgvCARD.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(77, 255, 0);
                }
            }
        }
    }
}