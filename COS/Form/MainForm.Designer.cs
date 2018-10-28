namespace CSWinFormSingleInstanceApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelWelcomeMsg = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuAssignmentsWork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAssignmentsWork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemBoss = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemAdminApproveBuyPart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemReceive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemDatamanagement = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuItemDataOnWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลในโปรแกรมToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemScore = new System.Windows.Forms.ToolStripMenuItem();
            this.ตดตามงานซอมToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGetWork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProcurementManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReport1 = new System.Windows.Forms.ToolStripMenuItem();
            this.รายงานคางซอมToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.อตราการสงมอบตามนดToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.สรปภาระงานToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExitProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPositions = new System.Windows.Forms.Label();
            this.lableName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcomeMsg
            // 
            this.labelWelcomeMsg.AutoSize = true;
            this.labelWelcomeMsg.Location = new System.Drawing.Point(12, 9);
            this.labelWelcomeMsg.Name = "labelWelcomeMsg";
            this.labelWelcomeMsg.Size = new System.Drawing.Size(0, 13);
            this.labelWelcomeMsg.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.closeToolStripMenuItem.Text = "ปิดโปรแกรม";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Orange;
            this.menuStrip1.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAssignmentsWork,
            this.toolStripMenuItem3,
            this.MenuGetWork,
            this.toolStripMenuItem4,
            this.MenuProcurementManager,
            this.toolStripMenuItem5,
            this.MenuReport1,
            this.toolStripMenuItem9,
            this.MenuLogout,
            this.dToolStripMenuItem,
            this.MenuExitProgram,
            this.MenuAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1334, 76);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuAssignmentsWork
            // 
            this.MenuAssignmentsWork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAssignmentsWork,
            this.toolStripMenuItem12,
            this.MenuItemBoss,
            this.toolStripMenuItem2,
            this.MenuItemAdminApproveBuyPart,
            this.toolStripMenuItem6,
            this.MenuItemReceive,
            this.toolStripMenuItem7,
            this.MenuItemDatamanagement,
            this.toolStripMenuItem11,
            this.MenuUser,
            this.toolStripMenuItem1,
            this.MenuItemScore,
            this.ตดตามงานซอมToolStripMenuItem});
            this.MenuAssignmentsWork.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuAssignmentsWork.Image = global::COS.Properties.Resources.UserBoss;
            this.MenuAssignmentsWork.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAssignmentsWork.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.MenuAssignmentsWork.Name = "MenuAssignmentsWork";
            this.MenuAssignmentsWork.Size = new System.Drawing.Size(75, 72);
            this.MenuAssignmentsWork.Text = "ผู้ดูแลระบบ";
            this.MenuAssignmentsWork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuAssignmentsWork.Click += new System.EventHandler(this.MenuAssignmentsWork_Click);
            // 
            // MenuItemAssignmentsWork
            // 
            this.MenuItemAssignmentsWork.Name = "MenuItemAssignmentsWork";
            this.MenuItemAssignmentsWork.Size = new System.Drawing.Size(211, 24);
            this.MenuItemAssignmentsWork.Text = "หัวหน้าช่างมอบหมายงาน";
            this.MenuItemAssignmentsWork.Click += new System.EventHandler(this.มอบหมายงานToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuItemBoss
            // 
            this.MenuItemBoss.Name = "MenuItemBoss";
            this.MenuItemBoss.Size = new System.Drawing.Size(211, 24);
            this.MenuItemBoss.Text = "หัวหน้าหน่วยงานอนุมัติซ่อม";
            this.MenuItemBoss.Click += new System.EventHandler(this.MenuItemBoss_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuItemAdminApproveBuyPart
            // 
            this.MenuItemAdminApproveBuyPart.Name = "MenuItemAdminApproveBuyPart";
            this.MenuItemAdminApproveBuyPart.Size = new System.Drawing.Size(211, 24);
            this.MenuItemAdminApproveBuyPart.Text = "หัวหน้าช่างอนุมัติซ่อม";
            this.MenuItemAdminApproveBuyPart.Click += new System.EventHandler(this.อนมสToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuItemReceive
            // 
            this.MenuItemReceive.Name = "MenuItemReceive";
            this.MenuItemReceive.Size = new System.Drawing.Size(211, 24);
            this.MenuItemReceive.Text = "รับพัสดุที่สั่งซื้อ";
            this.MenuItemReceive.Click += new System.EventHandler(this.MenuItemReceive_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuItemDatamanagement
            // 
            this.MenuItemDatamanagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuItemDataOnWeb,
            this.ขอมลในโปรแกรมToolStripMenuItem});
            this.MenuItemDatamanagement.Name = "MenuItemDatamanagement";
            this.MenuItemDatamanagement.Size = new System.Drawing.Size(211, 24);
            this.MenuItemDatamanagement.Text = "จัดการข้อมูล";
            this.MenuItemDatamanagement.Click += new System.EventHandler(this.MenuItem6_Click);
            // 
            // TSMenuItemDataOnWeb
            // 
            this.TSMenuItemDataOnWeb.Name = "TSMenuItemDataOnWeb";
            this.TSMenuItemDataOnWeb.Size = new System.Drawing.Size(157, 24);
            this.TSMenuItemDataOnWeb.Text = "ข้อมูลบนเว็บ";
            this.TSMenuItemDataOnWeb.Click += new System.EventHandler(this.ขอมลบนเวบToolStripMenuItem_Click);
            // 
            // ขอมลในโปรแกรมToolStripMenuItem
            // 
            this.ขอมลในโปรแกรมToolStripMenuItem.Name = "ขอมลในโปรแกรมToolStripMenuItem";
            this.ขอมลในโปรแกรมToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.ขอมลในโปรแกรมToolStripMenuItem.Text = "ข้อมูลในโปรแกรม";
            this.ขอมลในโปรแกรมToolStripMenuItem.Click += new System.EventHandler(this.ขอมลในโปรแกรมToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuUser
            // 
            this.MenuUser.Name = "MenuUser";
            this.MenuUser.Size = new System.Drawing.Size(211, 24);
            this.MenuUser.Text = "ผู้ใช้งาน";
            this.MenuUser.Click += new System.EventHandler(this.ผใชงานToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuItemScore
            // 
            this.MenuItemScore.Name = "MenuItemScore";
            this.MenuItemScore.Size = new System.Drawing.Size(211, 24);
            this.MenuItemScore.Text = "ให้คะแนนการทำงาน";
            this.MenuItemScore.Visible = false;
            this.MenuItemScore.Click += new System.EventHandler(this.ใหคะแนนToolStripMenuItem_Click);
            // 
            // ตดตามงานซอมToolStripMenuItem
            // 
            this.ตดตามงานซอมToolStripMenuItem.Name = "ตดตามงานซอมToolStripMenuItem";
            this.ตดตามงานซอมToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.ตดตามงานซอมToolStripMenuItem.Text = "ติดตามงานซ่อม";
            this.ตดตามงานซอมToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::COS.Properties.Resources.line;
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(15, 72);
            // 
            // MenuGetWork
            // 
            this.MenuGetWork.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuGetWork.Image = global::COS.Properties.Resources.user22;
            this.MenuGetWork.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuGetWork.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.MenuGetWork.Name = "MenuGetWork";
            this.MenuGetWork.Size = new System.Drawing.Size(81, 72);
            this.MenuGetWork.Text = "ส่วนของช่าง";
            this.MenuGetWork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuGetWork.Click += new System.EventHandler(this.MenuGetWork_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::COS.Properties.Resources.line;
            this.toolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(15, 72);
            // 
            // MenuProcurementManager
            // 
            this.MenuProcurementManager.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProcurementManager.Image = global::COS.Properties.Resources.user2;
            this.MenuProcurementManager.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuProcurementManager.Name = "MenuProcurementManager";
            this.MenuProcurementManager.Size = new System.Drawing.Size(66, 72);
            this.MenuProcurementManager.Text = "ฝ่ายพัสดุ";
            this.MenuProcurementManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuProcurementManager.Click += new System.EventHandler(this.MenuProcurementManager_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::COS.Properties.Resources.line;
            this.toolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(15, 72);
            // 
            // MenuReport1
            // 
            this.MenuReport1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.รายงานคางซอมToolStripMenuItem,
            this.อตราการสงมอบตามนดToolStripMenuItem,
            this.สรปภาระงานToolStripMenuItem});
            this.MenuReport1.Image = global::COS.Properties.Resources.Document48;
            this.MenuReport1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuReport1.Name = "MenuReport1";
            this.MenuReport1.Size = new System.Drawing.Size(60, 72);
            this.MenuReport1.Text = "รายงาน";
            this.MenuReport1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuReport1.Click += new System.EventHandler(this.MenuReport_Click);
            // 
            // รายงานคางซอมToolStripMenuItem
            // 
            this.รายงานคางซอมToolStripMenuItem.Name = "รายงานคางซอมToolStripMenuItem";
            this.รายงานคางซอมToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.รายงานคางซอมToolStripMenuItem.Text = "รายงานค้างซ่อม";
            this.รายงานคางซอมToolStripMenuItem.Click += new System.EventHandler(this.รายงานคางซอมToolStripMenuItem_Click);
            // 
            // อตราการสงมอบตามนดToolStripMenuItem
            // 
            this.อตราการสงมอบตามนดToolStripMenuItem.Name = "อตราการสงมอบตามนดToolStripMenuItem";
            this.อตราการสงมอบตามนดToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.อตราการสงมอบตามนดToolStripMenuItem.Text = "อัตราการส่งมอบตามนัด";
            this.อตราการสงมอบตามนดToolStripMenuItem.Click += new System.EventHandler(this.อตราการสงมอบตามนดToolStripMenuItem_Click);
            // 
            // สรปภาระงานToolStripMenuItem
            // 
            this.สรปภาระงานToolStripMenuItem.Name = "สรปภาระงานToolStripMenuItem";
            this.สรปภาระงานToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.สรปภาระงานToolStripMenuItem.Text = "สรุปภาระงาน";
            this.สรปภาระงานToolStripMenuItem.Click += new System.EventHandler(this.สรปภาระงานToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::COS.Properties.Resources.line;
            this.toolStripMenuItem9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(15, 72);
            // 
            // MenuLogout
            // 
            this.MenuLogout.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLogout.Image = global::COS.Properties.Resources.userlo;
            this.MenuLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuLogout.Name = "MenuLogout";
            this.MenuLogout.Size = new System.Drawing.Size(90, 72);
            this.MenuLogout.Text = "เปลี่ยนผู้ใช้งาน";
            this.MenuLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuLogout.Click += new System.EventHandler(this.MenuLogout_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Image = global::COS.Properties.Resources.line;
            this.dToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(15, 72);
            // 
            // MenuExitProgram
            // 
            this.MenuExitProgram.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuExitProgram.Image = global::COS.Properties.Resources.Log_Out_48x48;
            this.MenuExitProgram.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuExitProgram.Name = "MenuExitProgram";
            this.MenuExitProgram.Size = new System.Drawing.Size(105, 72);
            this.MenuExitProgram.Text = "ออกจากโปรแกรม";
            this.MenuExitProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuExitProgram.Click += new System.EventHandler(this.MenuExitProgram_Click);
            // 
            // MenuAdmin
            // 
            this.MenuAdmin.Image = global::COS.Properties.Resources.UserBoss;
            this.MenuAdmin.Name = "MenuAdmin";
            this.MenuAdmin.Size = new System.Drawing.Size(55, 72);
            this.MenuAdmin.Text = "Admin";
            this.MenuAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuAdmin.Click += new System.EventHandler(this.MenuAdmin_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelPositions);
            this.panel1.Controls.Add(this.lableName);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.panel1.Location = new System.Drawing.Point(0, 563);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 32);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.label3.Location = new System.Drawing.Point(221, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "กลุ่มผู้ใช้งาน";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.labelIP.Location = new System.Drawing.Point(729, 4);
            this.labelIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 23);
            this.labelIP.TabIndex = 21;
            this.labelIP.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.label2.Location = new System.Drawing.Point(576, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "หมายเลขเครื่องของคุณคือ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::COS.Properties.Resources.User28x28;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.labelVersion.Location = new System.Drawing.Point(493, 4);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(52, 23);
            this.labelVersion.TabIndex = 19;
            this.labelVersion.Text = "เวอร์ชัน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.label1.Location = new System.Drawing.Point(439, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "เวอร์ชัน";
            // 
            // labelPositions
            // 
            this.labelPositions.AutoSize = true;
            this.labelPositions.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.labelPositions.Location = new System.Drawing.Point(291, 4);
            this.labelPositions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPositions.Name = "labelPositions";
            this.labelPositions.Size = new System.Drawing.Size(149, 23);
            this.labelPositions.TabIndex = 9;
            this.labelPositions.Text = "ฝ่ายช่างศูนย์คอมพิวเตอร์";
            // 
            // lableName
            // 
            this.lableName.AutoSize = true;
            this.lableName.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.lableName.Location = new System.Drawing.Point(40, 4);
            this.lableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableName.Name = "lableName";
            this.lableName.Size = new System.Drawing.Size(143, 23);
            this.lableName.TabIndex = 8;
            this.lableName.Text = "นายคณพศ พลชัยสวัสดิ์";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 70000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1334, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelWelcomeMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "UDH Computer online service ระบบแจ้งซ่อมคอมพิวเตอร์ออนไลน์";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWelcomeMsg;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAssignmentsWork;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAssignmentsWork;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAdminApproveBuyPart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDatamanagement;
        private System.Windows.Forms.ToolStripMenuItem MenuGetWork;
        private System.Windows.Forms.ToolStripMenuItem MenuProcurementManager;
        private System.Windows.Forms.ToolStripMenuItem MenuLogout;
        private System.Windows.Forms.ToolStripMenuItem MenuExitProgram;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelPositions;
        public System.Windows.Forms.Label lableName;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItemDataOnWeb;
        private System.Windows.Forms.ToolStripMenuItem ขอมลในโปรแกรมToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.ToolStripMenuItem MenuReport1;
        private System.Windows.Forms.ToolStripMenuItem รายงานคางซอมToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem อตราการสงมอบตามนดToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem MenuUser;
        private System.Windows.Forms.ToolStripMenuItem สรปภาระงานToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBoss;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem ตดตามงานซอมToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReceive;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    }
}

