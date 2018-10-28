using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UDH
{
    public class User
    {
        public static string _U_ID { get; set; }
        public static string _U_NAME { get; set; }
        public static string _U_LOGIN { get; set; }
        public static string _U_PASSWORD { get; set; }
        public static string _U_POSITION { get; set; }
        public static List<string> _PART_ID { get; set; }
        public static string _JOB_Now { get; set; }
        public static string _CARUCODE { get; set; }
        public static string _CARUNO { get; set; }
        public static string _U_DEPT { get; set; }
        public static string _sqlReport { get; set; }

        public static string _pathConfig { get; set; }

        public static string GETymd_time()
        {
            var dt = new DBClass().SqlGetData("SELECT dbo.GETymd_time()");

            return dt.Rows[0][0].ToString(); ;
        }

        public void formatGridView(DataGridView e)
        {
            e.EnableHeadersVisualStyles = false;
            e.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);                //สี header
            e.ColumnHeadersDefaultCellStyle.Font = new Font("Thai Sans Lite", 12);                    //ตัวอักษร ขนาดตัวอักษร

            //e.SortMode = DataGridViewColumnSortMode.NotSortable;                         //ไม่เรียงข้อมูล
            e.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ตำแหน่งตรงกลาง
            //e.Column.HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 128);                //สี header
            //e.Column.HeaderCell.Style.Font = new Font("Thai Sans Lite", 12);                    //ตัวอักษร ขนาดตัวอักษร
        }

        public class FIXED_TYPE
        {
            public string _ซ่อมเองโดยไม่ใช้วัสดุ = "1";
            public string _ซ่อมเองโดยขออนุมัติซื้อพัสดุ = "3";
            public string _ส่งซ่อมเอกชนนอกประกัน = "4";
            public string _ขออนุมัติซื้อทดแทน = "5";
            public string _ส่งซ่อมเอกชนในประกัน = "6";
        }

        public class STATUS_FIXED
        {
            public string _รอหัวหน้าช่างมอบหมายงาน = "1";
            public string _รอช่างรับงาน = "2";
            public string _กำลังดำเนินการซ่อม = "3";
            public string _รอหัวหน้าช่างอนุมัติสั่งซื้อพัสดุ = "4";
            public string _กำลังซ่อม = "5";
            public string _รอหน่วยงานรับเครื่องกลับ = "6";
            public string _เสร็จสิ้น = "7";
            public string _รอหัวหน้าช่างอนุมัติส่งซ่อมเอกชนในประกัน = "8";
            public string _ส่งซ่อมเอกชนนอกประกัน = "9";
            public string _รอหัวหน้าหน่วยงานอนุมัติสั่งซื้อพัสดุ = "10";
            public string _ส่งซ่อมเอกชนในประกัน = "11";
            public string _รอหัวหน้าช่างอนุมัติส่งซ่อมเอกชนนอกประกัน = "12";
            public string _สั่งซื้อพัสดุ = "13";
            public string _รอหัวหน้าหน่วยงานอนุมัติส่งซ่อมเอกชนในประกัน = "14";
            public string _รอหัวหน้าหน่วยงานอนุมัติส่งซ่อมเอกชนนอกประกัน = "15";
            public string _รอหัวหน้าหน่วยงานอนุมัติสั่งซื้อทดแทน = "23";
            public string _ขออนุมัติซื้อทดแทน = "24";
            public string _รับพัสดุที่สั่งซื้อครบ = "16";
            public string _รับพัสดุที่ส่งซ่อมเอกชนนอกประกัน = "17";
            public string _รับพัสดุที่ส่งซ่อมเอกชนในประกัน = "18";
            public string _รับพัสดุที่สั่งซื้อยังไม่ครบ = "19";
            public string _ขออนุมัติพัสดุสั่งซื้อ = "20";
            public string _ซ่อมเสร็จ = "21";
            public string _รอพัสดุรับรายการสั่งซื้อ = "25";
        }

        public class DOC_TYPE
        {
            public string _ใบเสนอราคา = "1";
            public string _ใบสเปค = "2";
            public string _ใบแจ้งซ่อม = "3";
        }
    }
}