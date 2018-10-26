namespace UDH
{
    partial class fmAdminApproveUsePart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.t1 = new System.Windows.Forms.TabPage();
            this.gbStock = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nud1 = new System.Windows.Forms.NumericUpDown();
            this.labelUNIT = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxPART_NAME = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.tabControl2.SuspendLayout();
            this.t1.SuspendLayout();
            this.gbStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.t1);
            this.tabControl2.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabControl2.Location = new System.Drawing.Point(7, 7);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1343, 671);
            this.tabControl2.TabIndex = 27;
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            // 
            // t1
            // 
            this.t1.Controls.Add(this.gbStock);
            this.t1.Controls.Add(this.button1);
            this.t1.Controls.Add(this.btnSave);
            this.t1.Controls.Add(this.dgvMain);
            this.t1.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t1.Location = new System.Drawing.Point(4, 29);
            this.t1.Name = "t1";
            this.t1.Padding = new System.Windows.Forms.Padding(3);
            this.t1.Size = new System.Drawing.Size(1335, 638);
            this.t1.TabIndex = 1;
            this.t1.Text = "อนุมัติใช้อะไหล่ในสต๊อก";
            this.t1.UseVisualStyleBackColor = true;
            // 
            // gbStock
            // 
            this.gbStock.Controls.Add(this.btnEdit);
            this.gbStock.Controls.Add(this.btnDeleteAll);
            this.gbStock.Controls.Add(this.btnDelete);
            this.gbStock.Controls.Add(this.dgvStock);
            this.gbStock.Controls.Add(this.btnAdd);
            this.gbStock.Controls.Add(this.nud1);
            this.gbStock.Controls.Add(this.labelUNIT);
            this.gbStock.Controls.Add(this.label18);
            this.gbStock.Controls.Add(this.label19);
            this.gbStock.Controls.Add(this.cbxPART_NAME);
            this.gbStock.Location = new System.Drawing.Point(5, 398);
            this.gbStock.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gbStock.Name = "gbStock";
            this.gbStock.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gbStock.Size = new System.Drawing.Size(830, 214);
            this.gbStock.TabIndex = 47;
            this.gbStock.TabStop = false;
            this.gbStock.Text = "รายการอะไหล่ที่ใช้ซ่อม(ใน Stock)";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(732, 78);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 43);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(732, 168);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(87, 39);
            this.btnDeleteAll.TabIndex = 15;
            this.btnDeleteAll.Text = "ลบทั้งหมด";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(732, 125);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 39);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Thai Sans Lite", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvStock.BackgroundColor = System.Drawing.Color.Ivory;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStock.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvStock.Location = new System.Drawing.Point(10, 56);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStock.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Thai Sans Lite", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvStock.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(714, 151);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            this.dgvStock.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStock_CellMouseUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(732, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 43);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nud1
            // 
            this.nud1.Location = new System.Drawing.Point(338, 23);
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
            this.labelUNIT.Location = new System.Drawing.Point(389, 28);
            this.labelUNIT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUNIT.Name = "labelUNIT";
            this.labelUNIT.Size = new System.Drawing.Size(37, 20);
            this.labelUNIT.TabIndex = 3;
            this.labelUNIT.Text = "หน่วย";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(289, 27);
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
            this.cbxPART_NAME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxPART_NAME.DropDownHeight = 170;
            this.cbxPART_NAME.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPART_NAME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbxPART_NAME.IntegralHeight = false;
            this.cbxPART_NAME.ItemHeight = 20;
            this.cbxPART_NAME.Location = new System.Drawing.Point(100, 25);
            this.cbxPART_NAME.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbxPART_NAME.MaxDropDownItems = 15;
            this.cbxPART_NAME.Name = "cbxPART_NAME";
            this.cbxPART_NAME.Size = new System.Drawing.Size(184, 28);
            this.cbxPART_NAME.TabIndex = 0;
            this.cbxPART_NAME.Click += new System.EventHandler(this.cbxPART_NAME_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(860, 408);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 51);
            this.button1.TabIndex = 46;
            this.button1.Text = "อนุมัติ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.Location = new System.Drawing.Point(5, 574);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 37);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "อนุมัติ";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMain.BackgroundColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Location = new System.Drawing.Point(5, 4);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1323, 386);
            this.dgvMain.TabIndex = 23;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvMain_ColumnAdded);
            this.dgvMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMain_DataBindingComplete);
            // 
            // fmAdminApproveUsePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1354, 726);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl2);
            this.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmAdminApproveUsePart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "อนุมัติใช้อะไหล่ในสต๊อก";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmAdminApproveUsePart_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAdminApproveUsePart_KeyDown);
            this.tabControl2.ResumeLayout(false);
            this.t1.ResumeLayout(false);
            this.gbStock.ResumeLayout(false);
            this.gbStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage t1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.GroupBox gbStock;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nud1;
        private System.Windows.Forms.Label labelUNIT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxPART_NAME;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEdit;
    }
}