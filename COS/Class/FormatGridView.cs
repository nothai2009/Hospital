using System.Windows.Forms;

namespace UDH
{
    public class FormatGridView
    {
        //Score
        public void FormatdgvScore(DataGridView dgvScore)
        {
            if (dgvScore.RowCount > 0)
            {
                dgvScore.Columns[0].HeaderText = "JOB_ID"; dgvScore.Columns[0].Width = 137;
                dgvScore.Columns[1].HeaderText = "เลขครุภัณฑ์"; dgvScore.Columns[1].Width = 93;
                dgvScore.Columns[2].HeaderText = "ตัวย่อ"; dgvScore.Columns[2].Width = 44;
                dgvScore.Columns[3].HeaderText = "ประเภท"; dgvScore.Columns[3].Width = 118;
                dgvScore.Columns[4].HeaderText = "หน่วยงาน"; dgvScore.Columns[4].Width = 100;
                dgvScore.Columns[5].HeaderText = "อาการเสีย"; dgvScore.Columns[5].Width = 120;
                dgvScore.Columns[6].HeaderText = "คำอธิบาย"; dgvScore.Columns[6].Width = 85;
                dgvScore.Columns[7].HeaderText = "วันแจ้ง"; dgvScore.Columns[7].Width = 65;
                dgvScore.Columns[8].HeaderText = "กำหนดเสร็จ"; dgvScore.Columns[8].Width = 65;
                dgvScore.Columns[9].HeaderText = "วันเสร็จ"; dgvScore.Columns[9].Width = 65;
                dgvScore.Columns[10].HeaderText = "วันส่งมอบ"; dgvScore.Columns[10].Width = 65;
                dgvScore.Columns[11].HeaderText = "ช่างผู้รับผิดชอบ"; dgvScore.Columns[11].Width = 120;
                dgvScore.Columns[12].HeaderText = "หมายเหตุ"; dgvScore.Columns[12].Width = 120;
                dgvScore.Columns[13].HeaderText = "รายละเอียดการซ่อม"; dgvScore.Columns[13].Width = 160;
                dgvScore.Columns[14].HeaderText = "วิธีการซ่อม"; dgvScore.Columns[14].Width = 120;
            }
        }

        public void FormatdgvGetWork(DataGridView dgvGetWork)
        {
            if (dgvGetWork.RowCount > 0)
            {
                dgvGetWork.Columns[0].HeaderText = "JOB_ID";
                dgvGetWork.Columns[1].HeaderText = "เลขครุภัณฑ์";
                dgvGetWork.Columns[2].HeaderText = "เลขท้าย";
                dgvGetWork.Columns[3].HeaderText = "ประเภท";
                dgvGetWork.Columns[4].HeaderText = "หน่วยงาน";
                dgvGetWork.Columns[5].HeaderText = "SPEC";
                dgvGetWork.Columns[6].HeaderText = "อาการเสีย";
                dgvGetWork.Columns[7].HeaderText = "คำอธิบาย";
                dgvGetWork.Columns[8].HeaderText = "ผู้แจ้ง";
                dgvGetWork.Columns[9].HeaderText = "เบอร์โทร";
                dgvGetWork.Columns[10].HeaderText = "วันแจ้ง";
                dgvGetWork.Columns[11].HeaderText = "กำหนดเสร็จ";
                dgvGetWork.Columns[12].HeaderText = "วิธีซ่อม";

                dgvGetWork.Columns[0].Width = 120;
                dgvGetWork.Columns[1].Width = 90;
                dgvGetWork.Columns[2].Width = 90;
                dgvGetWork.Columns[3].Width = 120;
                dgvGetWork.Columns[4].Width = 100;
                dgvGetWork.Columns[5].Width = 159;
                dgvGetWork.Columns[6].Width = 85;
                dgvGetWork.Columns[7].Width = 85;
                dgvGetWork.Columns[8].Width = 95;
                dgvGetWork.Columns[9].Width = 95;
                dgvGetWork.Columns[10].Width = 95;
                dgvGetWork.Columns[11].Width = 95;
                dgvGetWork.Columns[12].Width = 95;
            }
        }

        public void FormatdgvHowToRepair(DataGridView dgvMain)
        {
            //if (dgvMain.RowCount > 0)
            //{
            dgvMain.Columns[0].HeaderText = "JOB_ID";
            dgvMain.Columns[1].HeaderText = "หมายเลขครุภัณฑ์";
            dgvMain.Columns[2].HeaderText = "เลขท้าย";
            dgvMain.Columns[3].HeaderText = "ประเภท";
            dgvMain.Columns[4].HeaderText = "หน่วยงาน";
            dgvMain.Columns[5].HeaderText = "คุณสมบัติ";
            dgvMain.Columns[6].HeaderText = "อาการเสีย";
            dgvMain.Columns[7].HeaderText = "คำอธิบาย";
            dgvMain.Columns[8].HeaderText = "ผู้แจ้ง";
            dgvMain.Columns[9].HeaderText = "เบอร์โทร";
            dgvMain.Columns[10].HeaderText = "วันแจ้ง";
            dgvMain.Columns[11].HeaderText = "กำหนดเสร็จ";
            dgvMain.Columns[12].HeaderText = "ช่างผู้รับผิดชอบ";
            dgvMain.Columns[13].HeaderText = "หมายเหตุ";

            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 85;
            dgvMain.Columns[2].Width = 50;
            dgvMain.Columns[3].Width = 120;
            dgvMain.Columns[4].Width = 80;
            dgvMain.Columns[5].Width = 109;
            dgvMain.Columns[6].Width = 100;
            dgvMain.Columns[7].Width = 100;
            dgvMain.Columns[8].Width = 95;
            dgvMain.Columns[9].Width = 95;
            dgvMain.Columns[10].Width = 95;
            dgvMain.Columns[11].Width = 95;
            dgvMain.Columns[12].Width = 95;
            dgvMain.Columns[13].Width = 85;
            //}
        }

        public void FormatdgvStock(DataGridView dgvStock)
        {
            if (dgvStock.RowCount > 0)
            {
                dgvStock.Columns[0].HeaderText = "JOB_ID";
                dgvStock.Columns[1].HeaderText = "PART_ID";
                dgvStock.Columns[2].HeaderText = "ชื่ออะไหล่";
                dgvStock.Columns[3].HeaderText = "จำนวน";
                dgvStock.Columns[4].HeaderText = "หน่วย";
                dgvStock.Columns[5].HeaderText = "ราคาต่อชิ้น";
                dgvStock.Columns[6].HeaderText = "ราคารวม";

                dgvStock.Columns[0].Width = 120;
                dgvStock.Columns[1].Width = 90;
                dgvStock.Columns[2].Width = 150;
                dgvStock.Columns[3].Width = 80;
                dgvStock.Columns[4].Width = 80;
                dgvStock.Columns[5].Width = 75;
                dgvStock.Columns[6].Width = 95;
            }
        }

        public void FormatdgvPART_USER(DataGridView dgvStock)
        {
            //if (dgvStock.RowCount > 0)
            //{
            dgvStock.Columns[0].HeaderText = "JOB_ID";
            dgvStock.Columns[1].HeaderText = "PART_ID";
            dgvStock.Columns[2].HeaderText = "ชื่ออะไหล่";
            dgvStock.Columns[3].HeaderText = "จำนวน";
            dgvStock.Columns[4].HeaderText = "หน่วย";
            dgvStock.Columns[5].HeaderText = "ราคาต่อชิ้น";
            dgvStock.Columns[6].HeaderText = "ราคารวม";

            dgvStock.Columns[0].Width = 120;
            dgvStock.Columns[1].Width = 90;
            dgvStock.Columns[2].Width = 150;
            dgvStock.Columns[3].Width = 80;
            dgvStock.Columns[4].Width = 80;
            dgvStock.Columns[5].Width = 75;
            dgvStock.Columns[6].Width = 95;
            //}
        }

        public void FormatdgvRepairsCompleted(DataGridView dgvMain)
        {
            //if (dgvMain.RowCount > 0)
            //{
            dgvMain.Columns[0].HeaderText = "JOB_ID";
            dgvMain.Columns[1].HeaderText = "เลขครุภัณฑ์";
            dgvMain.Columns[2].HeaderText = "เลขท้าย";
            dgvMain.Columns[3].HeaderText = "ประเภท";
            dgvMain.Columns[4].HeaderText = "หน่วยงาน";
            dgvMain.Columns[5].HeaderText = "คุณสมบัติ";
            dgvMain.Columns[6].HeaderText = "คำอธิบาย";
            dgvMain.Columns[7].HeaderText = "อาการเสีย";
            dgvMain.Columns[8].HeaderText = "ผู้แจ้ง";
            dgvMain.Columns[9].HeaderText = "เบอร์โทร";
            dgvMain.Columns[10].HeaderText = "วันแจ้งซ่อม";
            dgvMain.Columns[11].HeaderText = "วันกำหนดเสร็จ";
            dgvMain.Columns[12].HeaderText = "ช่าง";
            dgvMain.Columns[13].HeaderText = "วิธีซ่อม";
            dgvMain.Columns[14].HeaderText = "หมายเหตุ";

            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 90;
            dgvMain.Columns[2].Width = 150;
            dgvMain.Columns[3].Width = 80;
            dgvMain.Columns[4].Width = 80;
            dgvMain.Columns[5].Width = 75;
            dgvMain.Columns[6].Width = 95;
            dgvMain.Columns[7].Width = 90;
            dgvMain.Columns[8].Width = 90;
            dgvMain.Columns[9].Width = 90;
            dgvMain.Columns[10].Width = 90;
            dgvMain.Columns[11].Width = 90;
            dgvMain.Columns[12].Width = 90;
            dgvMain.Columns[13].Width = 90;
            dgvMain.Columns[14].Width = 90;
            //}
        }

        public void FormatdgvReceive(DataGridView dgvMain)
        {
            //if (dgvMain.RowCount > 0)
            //{
            dgvMain.Columns[0].HeaderText = "JOB_ID";
            dgvMain.Columns[1].HeaderText = "เลขครุภัณฑ์";
            dgvMain.Columns[2].HeaderText = "เลขท้าย";
            dgvMain.Columns[3].HeaderText = "ประเภท	";
            dgvMain.Columns[4].HeaderText = "หน่วยงาน";
            dgvMain.Columns[5].HeaderText = "คุณสมบัติ";
            dgvMain.Columns[6].HeaderText = "สาเหตุ";
            dgvMain.Columns[7].HeaderText = "อาการ";
            dgvMain.Columns[8].HeaderText = "ผู้แจ้ง";
            dgvMain.Columns[9].HeaderText = "ช่างผู้รับผิดชอบ";
            dgvMain.Columns[10].HeaderText = "เบอร์โทร";
            dgvMain.Columns[11].HeaderText = "รายละเอียดการซ่อม";
            dgvMain.Columns[12].HeaderText = "วิธีการซ่อม";

            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 90;
            dgvMain.Columns[2].Width = 55;
            dgvMain.Columns[3].Width = 118;
            dgvMain.Columns[4].Width = 80;
            dgvMain.Columns[5].Width = 190;
            dgvMain.Columns[6].Width = 95;
            dgvMain.Columns[7].Width = 90;
            dgvMain.Columns[8].Width = 90;
            dgvMain.Columns[9].Width = 90;
            dgvMain.Columns[10].Width = 78;
            dgvMain.Columns[11].Width = 90;
            dgvMain.Columns[12].Width = 138;
            //}
        }

        public void FormatdgvHisFix(DataGridView dgvHisFix)
        {
            //if (dgvHisFix.RowCount > 0)
            //{
            dgvHisFix.Columns[0].HeaderText = "JOB_ID"; dgvHisFix.Columns[0].Width = 137;
            dgvHisFix.Columns[1].HeaderText = "เลขครุภัณฑ์"; dgvHisFix.Columns[1].Width = 75;
            dgvHisFix.Columns[2].HeaderText = "ตัวย่อ"; dgvHisFix.Columns[2].Width = 44;
            dgvHisFix.Columns[3].HeaderText = "ประเภท"; dgvHisFix.Columns[3].Width = 110;
            dgvHisFix.Columns[4].HeaderText = "หน่วยงาน"; dgvHisFix.Columns[4].Width = 100;
            dgvHisFix.Columns[5].HeaderText = "อาการเสีย"; dgvHisFix.Columns[5].Width = 120;
            dgvHisFix.Columns[6].HeaderText = "ช่างผู้รับผิดชอบ"; dgvHisFix.Columns[6].Width = 120;
            dgvHisFix.Columns[7].HeaderText = "วิธีการซ่อม"; dgvHisFix.Columns[7].Width = 120;
            //}
        }

        public void FormatdgvAdminApproveBuyPart(DataGridView dgvAdminApproveBuyPart)
        {
            dgvAdminApproveBuyPart.Columns[0].HeaderText = "JOB_ID";
            dgvAdminApproveBuyPart.Columns[1].HeaderText = "PART_ID";
            dgvAdminApproveBuyPart.Columns[2].HeaderText = "รายการ";
            dgvAdminApproveBuyPart.Columns[3].HeaderText = "จำนวน";
            dgvAdminApproveBuyPart.Columns[4].HeaderText = "หน่วย";
            dgvAdminApproveBuyPart.Columns[5].HeaderText = "วันที่ขอซื้อ";
            dgvAdminApproveBuyPart.Columns[6].HeaderText = "ราคากลาง";
            dgvAdminApproveBuyPart.Columns[7].HeaderText = "รวมราคากลาง";

            dgvAdminApproveBuyPart.Columns[0].Width = 138;
            dgvAdminApproveBuyPart.Columns[1].Width = 90;
            dgvAdminApproveBuyPart.Columns[2].Width = 150;
            dgvAdminApproveBuyPart.Columns[3].Width = 119;
            dgvAdminApproveBuyPart.Columns[4].Width = 110;
            dgvAdminApproveBuyPart.Columns[5].Width = 180;
            dgvAdminApproveBuyPart.Columns[6].Width = 95;
            dgvAdminApproveBuyPart.Columns[7].Width = 90;
        }
    }
}