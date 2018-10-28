namespace COS
{
    partial class fmUserAdd
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
            this.btnU_DEPT = new System.Windows.Forms.Button();
            this.cbxDEPT_NAME = new System.Windows.Forms.ComboBox();
            this.txtU_PASSWORD = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtU_NAME3 = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtU_NAME = new System.Windows.Forms.TextBox();
            this.btnCancel3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelete3 = new System.Windows.Forms.Button();
            this.btnEdit3 = new System.Windows.Forms.Button();
            this.btnSave3 = new System.Windows.Forms.Button();
            this.dgv3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnU_DEPT
            // 
            this.btnU_DEPT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnU_DEPT.Location = new System.Drawing.Point(321, 138);
            this.btnU_DEPT.Name = "btnU_DEPT";
            this.btnU_DEPT.Size = new System.Drawing.Size(120, 30);
            this.btnU_DEPT.TabIndex = 87;
            this.btnU_DEPT.Text = "กลุ่มงาน";
            this.btnU_DEPT.UseVisualStyleBackColor = true;
            // 
            // cbxDEPT_NAME
            // 
            this.cbxDEPT_NAME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxDEPT_NAME.FormattingEnabled = true;
            this.cbxDEPT_NAME.Location = new System.Drawing.Point(127, 138);
            this.cbxDEPT_NAME.Name = "cbxDEPT_NAME";
            this.cbxDEPT_NAME.Size = new System.Drawing.Size(187, 28);
            this.cbxDEPT_NAME.TabIndex = 86;
            // 
            // txtU_PASSWORD
            // 
            this.txtU_PASSWORD.Location = new System.Drawing.Point(127, 98);
            this.txtU_PASSWORD.Name = "txtU_PASSWORD";
            this.txtU_PASSWORD.PasswordChar = '*';
            this.txtU_PASSWORD.Size = new System.Drawing.Size(121, 29);
            this.txtU_PASSWORD.TabIndex = 85;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(57, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 84;
            this.label12.Text = "รหัสผ่าน";
            // 
            // txtU_NAME3
            // 
            this.txtU_NAME3.Location = new System.Drawing.Point(127, 58);
            this.txtU_NAME3.Name = "txtU_NAME3";
            this.txtU_NAME3.Size = new System.Drawing.Size(187, 29);
            this.txtU_NAME3.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(46, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 82;
            this.label11.Text = "ชื่อล็อกอิน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(58, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "กลุ่มงาน";
            // 
            // txtU_NAME
            // 
            this.txtU_NAME.Location = new System.Drawing.Point(127, 18);
            this.txtU_NAME.Name = "txtU_NAME";
            this.txtU_NAME.Size = new System.Drawing.Size(303, 29);
            this.txtU_NAME.TabIndex = 74;
            // 
            // btnCancel3
            // 
            this.btnCancel3.Enabled = false;
            this.btnCancel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel3.Location = new System.Drawing.Point(416, 218);
            this.btnCancel3.Name = "btnCancel3";
            this.btnCancel3.Size = new System.Drawing.Size(91, 43);
            this.btnCancel3.TabIndex = 80;
            this.btnCancel3.Text = "ยกเลิก";
            this.btnCancel3.UseVisualStyleBackColor = true;
            this.btnCancel3.Click += new System.EventHandler(this.btnCancel3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(4, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 76;
            this.label10.Text = "ชื่อผู้ใช้งานโปรแกรม";
            // 
            // btnDelete3
            // 
            this.btnDelete3.Enabled = false;
            this.btnDelete3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete3.Location = new System.Drawing.Point(319, 218);
            this.btnDelete3.Name = "btnDelete3";
            this.btnDelete3.Size = new System.Drawing.Size(91, 43);
            this.btnDelete3.TabIndex = 79;
            this.btnDelete3.Text = "ลบ";
            this.btnDelete3.UseVisualStyleBackColor = true;
            this.btnDelete3.Click += new System.EventHandler(this.btnDelete3_Click);
            // 
            // btnEdit3
            // 
            this.btnEdit3.Enabled = false;
            this.btnEdit3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit3.Location = new System.Drawing.Point(222, 218);
            this.btnEdit3.Name = "btnEdit3";
            this.btnEdit3.Size = new System.Drawing.Size(91, 43);
            this.btnEdit3.TabIndex = 78;
            this.btnEdit3.Text = "แก้ไข";
            this.btnEdit3.UseVisualStyleBackColor = true;
            this.btnEdit3.Click += new System.EventHandler(this.btnEdit3_Click);
            // 
            // btnSave3
            // 
            this.btnSave3.Enabled = false;
            this.btnSave3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave3.Location = new System.Drawing.Point(125, 218);
            this.btnSave3.Name = "btnSave3";
            this.btnSave3.Size = new System.Drawing.Size(91, 43);
            this.btnSave3.TabIndex = 77;
            this.btnSave3.Text = "บันทึก";
            this.btnSave3.UseVisualStyleBackColor = true;
            this.btnSave3.Click += new System.EventHandler(this.btnSave3_Click);
            // 
            // dgv3
            // 
            this.dgv3.AllowUserToAddRows = false;
            this.dgv3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.dgv3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv3.BackgroundColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv3.ColumnHeadersHeight = 30;
            this.dgv3.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv3.EnableHeadersVisualStyles = false;
            this.dgv3.Location = new System.Drawing.Point(8, 267);
            this.dgv3.Name = "dgv3";
            this.dgv3.ReadOnly = true;
            this.dgv3.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Thai Sans Lite", 13F);
            this.dgv3.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv3.Size = new System.Drawing.Size(499, 248);
            this.dgv3.TabIndex = 71;
            // 
            // fmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 527);
            this.Controls.Add(this.btnU_DEPT);
            this.Controls.Add(this.cbxDEPT_NAME);
            this.Controls.Add(this.txtU_PASSWORD);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtU_NAME3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtU_NAME);
            this.Controls.Add(this.btnCancel3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDelete3);
            this.Controls.Add(this.btnEdit3);
            this.Controls.Add(this.btnSave3);
            this.Controls.Add(this.dgv3);
            this.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "fmUserAdd";
            this.Text = "fmUserAdd";
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnU_DEPT;
        private System.Windows.Forms.ComboBox cbxDEPT_NAME;
        private System.Windows.Forms.MaskedTextBox txtU_PASSWORD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtU_NAME3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtU_NAME;
        private System.Windows.Forms.Button btnCancel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDelete3;
        private System.Windows.Forms.Button btnEdit3;
        private System.Windows.Forms.Button btnSave3;
        private System.Windows.Forms.DataGridView dgv3;
    }
}