namespace COS
{
    partial class ManagerPartCom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxPL_NAME = new System.Windows.Forms.ComboBox();
            this.ctmHide = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPL_BRAND = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPL_PRICE = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.nudST_IN = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudST_IN)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxPL_NAME
            // 
            this.cbxPL_NAME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxPL_NAME.DropDownHeight = 320;
            this.cbxPL_NAME.FormattingEnabled = true;
            this.cbxPL_NAME.IntegralHeight = false;
            this.cbxPL_NAME.ItemHeight = 22;
            this.cbxPL_NAME.Location = new System.Drawing.Point(83, 18);
            this.cbxPL_NAME.Name = "cbxPL_NAME";
            this.cbxPL_NAME.Size = new System.Drawing.Size(286, 30);
            this.cbxPL_NAME.TabIndex = 98;
            // 
            // ctmHide
            // 
            this.ctmHide.Name = "ctmHide";
            this.ctmHide.Size = new System.Drawing.Size(98, 22);
            this.ctmHide.Text = "ซ่อน";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmHide,
            this.ctmShow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // ctmShow
            // 
            this.ctmShow.Name = "ctmShow";
            this.ctmShow.Size = new System.Drawing.Size(98, 22);
            this.ctmShow.Text = "แสดง";
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(375, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 97;
            this.button1.Text = "เพิ่ม";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtPL_BRAND
            // 
            this.txtPL_BRAND.Location = new System.Drawing.Point(84, 58);
            this.txtPL_BRAND.Name = "txtPL_BRAND";
            this.txtPL_BRAND.Size = new System.Drawing.Size(179, 30);
            this.txtPL_BRAND.TabIndex = 83;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(29, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 22);
            this.label15.TabIndex = 96;
            this.label15.Text = "หน่วย";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(21, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 22);
            this.label14.TabIndex = 95;
            this.label14.Text = "จำนวน";
            // 
            // txtPL_PRICE
            // 
            this.txtPL_PRICE.Location = new System.Drawing.Point(84, 143);
            this.txtPL_PRICE.Name = "txtPL_PRICE";
            this.txtPL_PRICE.Size = new System.Drawing.Size(100, 30);
            this.txtPL_PRICE.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(33, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 22);
            this.label8.TabIndex = 88;
            this.label8.Text = "ราคา";
            // 
            // btnCancel2
            // 
            this.btnCancel2.Enabled = false;
            this.btnCancel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel2.Location = new System.Drawing.Point(375, 227);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(91, 43);
            this.btnCancel2.TabIndex = 93;
            this.btnCancel2.Text = "ยกเลิก";
            this.btnCancel2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 89;
            this.label2.Text = "ชื่อพัสดุ";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Enabled = false;
            this.btnDelete2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete2.Location = new System.Drawing.Point(278, 227);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(91, 43);
            this.btnDelete2.TabIndex = 92;
            this.btnDelete2.Text = "ลบ";
            this.btnDelete2.UseVisualStyleBackColor = true;
            // 
            // btnEdit2
            // 
            this.btnEdit2.Enabled = false;
            this.btnEdit2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit2.Location = new System.Drawing.Point(181, 227);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(91, 43);
            this.btnEdit2.TabIndex = 91;
            this.btnEdit2.Text = "แก้ไข";
            this.btnEdit2.UseVisualStyleBackColor = true;
            // 
            // btnSave2
            // 
            this.btnSave2.Enabled = false;
            this.btnSave2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave2.Location = new System.Drawing.Point(84, 227);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(91, 43);
            this.btnSave2.TabIndex = 87;
            this.btnSave2.Text = "บันทึก";
            this.btnSave2.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv1.BackgroundColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Thai Sans Lite", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeight = 30;
            this.dgv1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Thai Sans Lite", 12.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(471, 12);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.dgv1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(789, 257);
            this.dgv1.TabIndex = 90;
            // 
            // nudST_IN
            // 
            this.nudST_IN.Location = new System.Drawing.Point(84, 103);
            this.nudST_IN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudST_IN.Name = "nudST_IN";
            this.nudST_IN.Size = new System.Drawing.Size(71, 30);
            this.nudST_IN.TabIndex = 99;
            this.nudST_IN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudST_IN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ManagerPartCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 281);
            this.Controls.Add(this.nudST_IN);
            this.Controls.Add(this.cbxPL_NAME);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPL_BRAND);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPL_PRICE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnEdit2);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.dgv1);
            this.Font = new System.Drawing.Font("Thai Sans Lite", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ManagerPartCom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการข้อมูลพัสดุในสต๊อก";
            this.Load += new System.EventHandler(this.ManagerPartCom_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudST_IN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPL_NAME;
        private System.Windows.Forms.ToolStripMenuItem ctmHide;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctmShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPL_BRAND;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtPL_PRICE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnEdit2;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.NumericUpDown nudST_IN;
    }
}