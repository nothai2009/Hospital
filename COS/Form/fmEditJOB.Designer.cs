namespace COS
{
    partial class fmEditJOB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtJOBID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbCARUCODE = new System.Windows.Forms.Label();
            this.txtCARUCODE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSPEC = new System.Windows.Forms.TextBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCARUNO = new System.Windows.Forms.TextBox();
            this.gbStock = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.txtREF_PRICE = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nud1 = new System.Windows.Forms.NumericUpDown();
            this.labelUNIT = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxPART_NAME = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.gbStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtJOBID
            // 
            this.txtJOBID.Location = new System.Drawing.Point(103, 20);
            this.txtJOBID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtJOBID.Name = "txtJOBID";
            this.txtJOBID.ReadOnly = true;
            this.txtJOBID.Size = new System.Drawing.Size(184, 29);
            this.txtJOBID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "JOBID";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(579, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 46);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbCARUCODE
            // 
            this.lbCARUCODE.AutoSize = true;
            this.lbCARUCODE.Location = new System.Drawing.Point(30, 62);
            this.lbCARUCODE.Name = "lbCARUCODE";
            this.lbCARUCODE.Size = new System.Drawing.Size(50, 20);
            this.lbCARUCODE.TabIndex = 4;
            this.lbCARUCODE.Text = "ครุภัณฑ์";
            // 
            // txtCARUCODE
            // 
            this.txtCARUCODE.Location = new System.Drawing.Point(103, 59);
            this.txtCARUCODE.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCARUCODE.Name = "txtCARUCODE";
            this.txtCARUCODE.Size = new System.Drawing.Size(270, 29);
            this.txtCARUCODE.TabIndex = 0;
            this.txtCARUCODE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCARUCODE_MouseClick);
            this.txtCARUCODE.TextChanged += new System.EventHandler(this.txtCARUCODE_TextChanged);
            this.txtCARUCODE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCARUCODE_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ตัวย่อ";
            // 
            // txtSPEC
            // 
            this.txtSPEC.Location = new System.Drawing.Point(103, 98);
            this.txtSPEC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSPEC.Name = "txtSPEC";
            this.txtSPEC.ReadOnly = true;
            this.txtSPEC.Size = new System.Drawing.Size(440, 29);
            this.txtSPEC.TabIndex = 1;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(103, 88);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(440, 10);
            this.dgv1.TabIndex = 7;
            this.dgv1.Visible = false;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "สเปก";
            // 
            // txtCARUNO
            // 
            this.txtCARUNO.Location = new System.Drawing.Point(424, 59);
            this.txtCARUNO.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCARUNO.Name = "txtCARUNO";
            this.txtCARUNO.Size = new System.Drawing.Size(119, 29);
            this.txtCARUNO.TabIndex = 9;
            this.txtCARUNO.TextChanged += new System.EventHandler(this.txtCARUNO_TextChanged_1);
            // 
            // gbStock
            // 
            this.gbStock.Controls.Add(this.button2);
            this.gbStock.Controls.Add(this.btnDeleteAll);
            this.gbStock.Controls.Add(this.btnDelete);
            this.gbStock.Controls.Add(this.label15);
            this.gbStock.Controls.Add(this.txtTotal);
            this.gbStock.Controls.Add(this.dgvStock);
            this.gbStock.Controls.Add(this.txtREF_PRICE);
            this.gbStock.Controls.Add(this.label16);
            this.gbStock.Controls.Add(this.btnAdd);
            this.gbStock.Controls.Add(this.nud1);
            this.gbStock.Controls.Add(this.labelUNIT);
            this.gbStock.Controls.Add(this.label18);
            this.gbStock.Controls.Add(this.label19);
            this.gbStock.Controls.Add(this.cbxPART_NAME);
            this.gbStock.Enabled = false;
            this.gbStock.Location = new System.Drawing.Point(2, 312);
            this.gbStock.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gbStock.Name = "gbStock";
            this.gbStock.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gbStock.Size = new System.Drawing.Size(1111, 214);
            this.gbStock.TabIndex = 46;
            this.gbStock.TabStop = false;
            this.gbStock.Text = "รายการอะไหล่ที่ใช้ซ่อม(ใน Stock)";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Thai Sans Lite", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(531, 21);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 34);
            this.button2.TabIndex = 17;
            this.button2.Text = "จัดการพัสดุ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(1014, 169);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(87, 39);
            this.btnDeleteAll.TabIndex = 15;
            this.btnDeleteAll.Text = "ลบทั้งหมด";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1014, 116);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 39);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(857, 28);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 20);
            this.label15.TabIndex = 13;
            this.label15.Text = "ราคารวม";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(913, 22);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(93, 29);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Thai Sans Lite", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvStock.BackgroundColor = System.Drawing.Color.Ivory;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStock.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvStock.Location = new System.Drawing.Point(10, 56);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStock.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Thai Sans Lite", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvStock.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(996, 151);
            this.dgvStock.TabIndex = 0;
            // 
            // txtREF_PRICE
            // 
            this.txtREF_PRICE.Location = new System.Drawing.Point(772, 22);
            this.txtREF_PRICE.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtREF_PRICE.Name = "txtREF_PRICE";
            this.txtREF_PRICE.ReadOnly = true;
            this.txtREF_PRICE.Size = new System.Drawing.Size(79, 29);
            this.txtREF_PRICE.TabIndex = 10;
            this.txtREF_PRICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(738, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 20);
            this.label16.TabIndex = 7;
            this.label16.Text = "ราคา";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1014, 57);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 43);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // nud1
            // 
            this.nud1.Location = new System.Drawing.Point(642, 23);
            this.nud1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.nud1.Name = "nud1";
            this.nud1.Size = new System.Drawing.Size(45, 29);
            this.nud1.TabIndex = 4;
            this.nud1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelUNIT
            // 
            this.labelUNIT.AutoSize = true;
            this.labelUNIT.Location = new System.Drawing.Point(693, 28);
            this.labelUNIT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUNIT.Name = "labelUNIT";
            this.labelUNIT.Size = new System.Drawing.Size(37, 20);
            this.labelUNIT.TabIndex = 3;
            this.labelUNIT.Text = "หน่วย";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(593, 27);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "จำนวน :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 27);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "เพิ่มรายการอะไหล่";
            // 
            // cbxPART_NAME
            // 
            this.cbxPART_NAME.DropDownHeight = 170;
            this.cbxPART_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPART_NAME.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPART_NAME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbxPART_NAME.IntegralHeight = false;
            this.cbxPART_NAME.ItemHeight = 20;
            this.cbxPART_NAME.Location = new System.Drawing.Point(100, 25);
            this.cbxPART_NAME.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbxPART_NAME.MaxDropDownItems = 15;
            this.cbxPART_NAME.Name = "cbxPART_NAME";
            this.cbxPART_NAME.Size = new System.Drawing.Size(417, 28);
            this.cbxPART_NAME.TabIndex = 0;
            // 
            // fmEditJOB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 528);
            this.Controls.Add(this.gbStock);
            this.Controls.Add(this.txtCARUNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSPEC);
            this.Controls.Add(this.lbCARUCODE);
            this.Controls.Add(this.txtCARUCODE);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJOBID);
            this.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "fmEditJOB";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "แก้ไขงาน";
            this.Load += new System.EventHandler(this.fmEditJOB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.gbStock.ResumeLayout(false);
            this.gbStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJOBID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbCARUCODE;
        private System.Windows.Forms.TextBox txtCARUCODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSPEC;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCARUNO;
        private System.Windows.Forms.GroupBox gbStock;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.TextBox txtREF_PRICE;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nud1;
        private System.Windows.Forms.Label labelUNIT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxPART_NAME;
    }
}