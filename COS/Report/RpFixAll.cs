using ReadWriteIniFileExample;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS.Report
{
    public partial class RpFixAll : Form
    {
        private printReport pr = new printReport();

        public string Report1 { get; private set; }
        public string CARUCODE { get; private set; }
        public string CARUNO { get; private set; }

        private DBClass dc = new DBClass();

        public RpFixAll()
        {
            InitializeComponent();
            ReadIni();

            var sql = "SELECT * "
                + " FROM COS_JOB NJ"
                + " LEFT JOIN MUHDEP M ON M.DEPCODE = NJ.DEPT_ID"
                //+ " WHERE REQ_DATE BETWEEN '25591201' AND '25610510'"
                //+ " AND SEND_DATE IS NULL"
                //+ " AND CANCEL IS NULL"
                + " ORDER BY CARUCODE,CARUNO";
            DataTable dt = new DBClass().SqlGetData(sql);
            dataGridView1.DataSource = dt;
        }

        private void ReadIni()
        {
            string value = IniFileHelper.ReadValue("Printer", "Printer", Path.GetFullPath(dc.pathIni));

            var cbx = comboBox1;
            cbx.Items.Add(value);
            cbx.SelectedIndex = 0;
        }

        private void RpFixAll_Load(object sender, System.EventArgs e)
        {
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                PrintPreview();
            }
        }

        private void comboBox1_DropDown(object sender, System.EventArgs e)
        {
            var cbx = comboBox1;
            cbx.DataSource = null;
            cbx.Items.Clear();
        }

        private void comboBox1_DropDownClosed(object sender, System.EventArgs e)
        {
            var cbx = comboBox1;
            bool result = IniFileHelper.WriteValue("Printer", "Printer", cbx.SelectedItem.ToString(), Path.GetFullPath(dc.pathIni));
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var cbx = comboBox1;
            cbx.Items.Clear();
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbx.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cbx.SelectedIndex = cbx.Items.IndexOf(strPrinter);
                }
            }
        }

        private void PrintPreview()
        {
            DataGridView dgv = dataGridView1;
            var JOB_ID = dgv.SelectedCells[0].Value.ToString();

            //ปริ้นใบแจ้งซ่อม
            Report1 = "SELECT DISTINCT NJ.JOBID,"
                + " (select U_NAME from COS_USER WHERE U_ID = PO.U_ID)AS NAME, RTRIM(D.DEPNAME)AS DEPTNAME, "
                + " NJ.TEL, NJ.OWNER, dbo.dmyCOS_hm(NJ.REQ_DATE) AS REQ_DATE, c2c.NAME AS CT_NAME, CT.CAUSE_NAME, NJ.CARUCODE, "
                + " NJ.CARUNO, dbo.dmyCOS(NJ.EXPECT_DATE) AS EXPECT_DATE, PLC.PL_ID, PLC.PL_ID_C, (ISNULL(PL_NAME, '')) + '' + ISNULL(PL_BRAND, '') + '' + ISNULL(PL_GEN, '') + '' + ISNULL(PL_DESC_C, '') AS PO_NAME, PO.PO_QTY_REQUIRED, UN.ST_NAME AS ST_NAME, U.U_NAME, FT.FT_NAME, "
                + " C.[Boss_Technician], C.[Boss_Stock], C.[DeputyDirector], C.[Director], dbo.dmyCOS(SUBSTRING(FIXED_DATE, 1, 8))AS FIXED_DATE, "
                + " dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE, 1, 8))AS PO_ASSIGN_DATE, dbo.dmyCOS(SUBSTRING(PO_ASSIGN_DATE_SOTCK, 1, 8))AS PO_ASSIGN_DATE_SOTCK,NJ.MOTIVE,NJ.FIXED_DETAIL,FIXED_DETAIL,(SELECT dbo.dmyCOS(GETDATE()))AS DATE"
                + " FROM COS_JOB NJ"
                + " LEFT JOIN COS_CAUSE_TYPE CT ON NJ.CAUSE_ID = CT.CAUSE_ID"
                + " LEFT JOIN MUHDEP D ON NJ.DEPT_ID = D.DEPCODE"
                + " LEFT JOIN [CARU2CODE]c2c ON NJ.CARUCODE = c2c.CARUCODE"
                + " LEFT JOIN COS_LEVEL_TYPE ON NJ.JOB_WANT_ID = COS_LEVEL_TYPE.LEVEL_ID"
                + " LEFT JOIN COS_FIXED_TYPE ON NJ.FIX_TYPE_ID = COS_FIXED_TYPE.FT_ID"
                + " LEFT JOIN COS_USER U ON NJ.USER_ID = U.U_ID"
                + " LEFT JOIN COS_PART_ORDER PO ON PO.JOB_ID = NJ.JOBID"
                + " LEFT JOIN COS_FIXED_TYPE FT ON FT.FT_ID = NJ.FIX_TYPE_ID"
                + " LEFT JOIN COS_PART_LIST_C PLC ON PLC.PL_ID = PO.PL_ID AND PLC.PL_ID_C = PO.PL_ID_C"
                + " LEFT JOIN COS_PART_LIST PL ON PL.PL_ID = PO.PL_ID "
                + " LEFT JOIN COS_UNIT UN ON UN.ST_UNIT = PL.PL_UNIT"
                + " CROSS JOIN COS_COS C"
                + " where NJ.JOBID =  '" + JOB_ID + "'";
            CARUCODE = dgv.SelectedCells[3].Value.ToString();
            CARUNO = dgv.SelectedCells[4].Value.ToString();

            fmReport1 f = new fmReport1(Report1, CARUCODE, CARUNO);
            f.Dock = DockStyle.Fill;
            f.ShowDialog();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dgv = dataGridView1;
            var JOB_ID = dgv.SelectedCells[0].Value.ToString();
            fmReport2 f2 = new fmReport2(JOB_ID);
            f2.Dock = DockStyle.Fill;
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dgv = dataGridView1; 
            var JOB_ID = dgv.SelectedCells[0].Value.ToString();
            var Carucode = dgv.SelectedCells[3].Value.ToString();
            var   Caruno= dgv.SelectedCells[4].Value.ToString();
            var Pritername = comboBox1.SelectedItem.ToString();
            ;

            pr.noPreview(JOB_ID, Carucode, Caruno, Pritername);
        }
    }
}