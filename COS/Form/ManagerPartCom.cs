using System;
using System.Windows.Forms;
using UDH;

namespace COS
{
    public partial class ManagerPartCom : Form
    {
        public ManagerPartCom()
        {
            InitializeComponent();
        }

        private void ManagerPartCom_Load(object sender, EventArgs e)
        {
            ClearText1();
            ShowData1();
        }

        private void ClearText1()
        {
            //txtST_NAME.Text = "";
            //cbxST_UNIT.SelectedIndex = -1;
            //nudST_IN.Value = 1;
            //txtST_PRICE.Text = "";
        }

        private void ShowData1()
        {
            var sql = "SELECT [ST_ID],S.[ST_NAME],U.ST_NAME,[ST_IN],[ST_PRICE],S.[HIDE]"
            + " FROM[COS_STOCK] S LEFT JOIN COS_UNIT U"
            + " ON S.ST_UNIT = U.ST_UNIT  ORDER BY S.ST_NAME ASC";
            var dt = new DBClass().SqlGetData(sql);
            dgv1.DataSource = dt;
            dgv1.Columns[0].HeaderText = "รหัส";
            dgv1.Columns[1].HeaderText = "ชื่ออะไหล่";
            dgv1.Columns[2].HeaderText = "หน่วย";
            dgv1.Columns[3].HeaderText = "จำนวนในสต๊อก";
            dgv1.Columns[4].HeaderText = "ราคา";
            dgv1.Columns[5].HeaderText = "สถานะ";

            dgv1.Columns[0].Width = 40;
            dgv1.Columns[1].Width = 150;
            dgv1.Columns[2].Width = 100;
            dgv1.Columns[3].Width = 100;
            dgv1.Columns[4].Width = 100;
            dgv1.Columns[5].Width = 100;
        }
    }
}