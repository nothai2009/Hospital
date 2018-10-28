using CrystalDecisions.CrystalReports.Engine;
using System;
using System.IO;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class fmSents : Form
    {
        
        public fmSents(string sql)
        {
            InitializeComponent();
            try
            {
                var path = @"C:\COS\ReportFix.rpt";
                var File = new FileInfo(path);
                var text = "ติดต่อโปรแกรมเมอร์ 1126";

                if (!File.Exists)
                {
                    MessageBox.Show("ไม่มีไฟล์ใบสั่งซ่อม " + text, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (File.Length == 0)
                {
                    MessageBox.Show("ไฟล์ใบส่งซ่อมไม่สมบูรณ์ " + text, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = new DBClass().SqlGetData(sql);
                ReportDocument rpt = new ReportDocument();
                rpt.Load(path);

                rpt.SetDataSource(dt);
                rpt.SetDatabaseLogon("homc", "homc", "192.168.0.5", "UHDATA");
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fmSents_Load(object sender, EventArgs e)
        {

        }
    }
}
