namespace COS
{
    partial class fmSettingConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSettingConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtUserName1 = new System.Windows.Forms.TextBox();
            this.txtServerName1 = new System.Windows.Forms.TextBox();
            this.cbxDatabaseName1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.txtUserName2 = new System.Windows.Forms.TextBox();
            this.txtServerName2 = new System.Windows.Forms.TextBox();
            this.cbxDatabaseName2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPassFTP = new System.Windows.Forms.TextBox();
            this.txtUserFTP = new System.Windows.Forms.TextBox();
            this.txtServerFTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPathFTP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword1);
            this.groupBox1.Controls.Add(this.txtUserName1);
            this.groupBox1.Controls.Add(this.txtServerName1);
            this.groupBox1.Controls.Add(this.cbxDatabaseName1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(282, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server data";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(102, 94);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(162, 29);
            this.txtPassword1.TabIndex = 2;
            // 
            // txtUserName1
            // 
            this.txtUserName1.Location = new System.Drawing.Point(102, 59);
            this.txtUserName1.Name = "txtUserName1";
            this.txtUserName1.Size = new System.Drawing.Size(162, 29);
            this.txtUserName1.TabIndex = 1;
            // 
            // txtServerName1
            // 
            this.txtServerName1.Location = new System.Drawing.Point(102, 24);
            this.txtServerName1.Name = "txtServerName1";
            this.txtServerName1.Size = new System.Drawing.Size(162, 29);
            this.txtServerName1.TabIndex = 0;
            // 
            // cbxDatabaseName1
            // 
            this.cbxDatabaseName1.DropDownHeight = 240;
            this.cbxDatabaseName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatabaseName1.FormattingEnabled = true;
            this.cbxDatabaseName1.IntegralHeight = false;
            this.cbxDatabaseName1.ItemHeight = 20;
            this.cbxDatabaseName1.Location = new System.Drawing.Point(102, 129);
            this.cbxDatabaseName1.MaxDropDownItems = 15;
            this.cbxDatabaseName1.Name = "cbxDatabaseName1";
            this.cbxDatabaseName1.Size = new System.Drawing.Size(162, 28);
            this.cbxDatabaseName1.TabIndex = 3;
            this.cbxDatabaseName1.DropDown += new System.EventHandler(this.cbxDatabaseName1_DropDown);
            this.cbxDatabaseName1.Click += new System.EventHandler(this.cbxDatabaseName1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "DatabaseName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerName";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPassword2);
            this.groupBox3.Controls.Add(this.txtUserName2);
            this.groupBox3.Controls.Add(this.txtServerName2);
            this.groupBox3.Controls.Add(this.cbxDatabaseName2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(300, 1);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Size = new System.Drawing.Size(280, 170);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Picture MongoDB";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(102, 94);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(162, 29);
            this.txtPassword2.TabIndex = 7;
            // 
            // txtUserName2
            // 
            this.txtUserName2.Location = new System.Drawing.Point(102, 59);
            this.txtUserName2.Name = "txtUserName2";
            this.txtUserName2.Size = new System.Drawing.Size(162, 29);
            this.txtUserName2.TabIndex = 6;
            // 
            // txtServerName2
            // 
            this.txtServerName2.Location = new System.Drawing.Point(102, 24);
            this.txtServerName2.Name = "txtServerName2";
            this.txtServerName2.Size = new System.Drawing.Size(162, 29);
            this.txtServerName2.TabIndex = 5;
            // 
            // cbxDatabaseName2
            // 
            this.cbxDatabaseName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatabaseName2.FormattingEnabled = true;
            this.cbxDatabaseName2.ItemHeight = 20;
            this.cbxDatabaseName2.Location = new System.Drawing.Point(102, 129);
            this.cbxDatabaseName2.MaxDropDownItems = 15;
            this.cbxDatabaseName2.Name = "cbxDatabaseName2";
            this.cbxDatabaseName2.Size = new System.Drawing.Size(162, 28);
            this.cbxDatabaseName2.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "DatabaseName";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "UserName";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "ServerName";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtURL);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 71);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "URL Update Program";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(10, 28);
            this.txtURL.Name = "txtURL";
            this.txtURL.PasswordChar = '*';
            this.txtURL.Size = new System.Drawing.Size(546, 29);
            this.txtURL.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(490, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPathFTP);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtPassFTP);
            this.groupBox4.Controls.Add(this.txtUserFTP);
            this.groupBox4.Controls.Add(this.txtServerFTP);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(586, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Size = new System.Drawing.Size(280, 170);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Server Picture FTP";
            // 
            // txtPassFTP
            // 
            this.txtPassFTP.Location = new System.Drawing.Point(102, 94);
            this.txtPassFTP.Name = "txtPassFTP";
            this.txtPassFTP.PasswordChar = '*';
            this.txtPassFTP.Size = new System.Drawing.Size(162, 29);
            this.txtPassFTP.TabIndex = 7;
            // 
            // txtUserFTP
            // 
            this.txtUserFTP.Location = new System.Drawing.Point(102, 59);
            this.txtUserFTP.Name = "txtUserFTP";
            this.txtUserFTP.PasswordChar = '*';
            this.txtUserFTP.Size = new System.Drawing.Size(162, 29);
            this.txtUserFTP.TabIndex = 6;
            // 
            // txtServerFTP
            // 
            this.txtServerFTP.Location = new System.Drawing.Point(102, 24);
            this.txtServerFTP.Name = "txtServerFTP";
            this.txtServerFTP.Size = new System.Drawing.Size(162, 29);
            this.txtServerFTP.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "UserName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "ServerName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "PathFTP";
            // 
            // txtPathFTP
            // 
            this.txtPathFTP.Location = new System.Drawing.Point(102, 128);
            this.txtPathFTP.Name = "txtPathFTP";
            this.txtPathFTP.Size = new System.Drawing.Size(162, 29);
            this.txtPathFTP.TabIndex = 9;
            // 
            // fmSettingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 298);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Thai Sans Lite", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "fmSettingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Config Connection DataBase";
            this.Load += new System.EventHandler(this.fmSettingConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDatabaseName1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtUserName1;
        private System.Windows.Forms.TextBox txtServerName1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.TextBox txtUserName2;
        private System.Windows.Forms.TextBox txtServerName2;
        private System.Windows.Forms.ComboBox cbxDatabaseName2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPassFTP;
        private System.Windows.Forms.TextBox txtUserFTP;
        private System.Windows.Forms.TextBox txtServerFTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPathFTP;
        private System.Windows.Forms.Label label5;
    }
}