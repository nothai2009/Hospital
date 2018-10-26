namespace COS
{
    partial class fmTest
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
            this.opfd1 = new System.Windows.Forms.OpenFileDialog();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnAddfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // opfd1
            // 
            this.opfd1.FileName = "openFileDialog1";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(93, 31);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "สแกน";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // btnAddfile
            // 
            this.btnAddfile.Location = new System.Drawing.Point(111, 12);
            this.btnAddfile.Name = "btnAddfile";
            this.btnAddfile.Size = new System.Drawing.Size(93, 31);
            this.btnAddfile.TabIndex = 1;
            this.btnAddfile.Text = "แนบไฟล์";
            this.btnAddfile.UseVisualStyleBackColor = true;
            // 
            // fmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddfile);
            this.Controls.Add(this.btnScan);
            this.Name = "fmTest";
            this.Text = "fmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opfd1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnAddfile;
    }
}