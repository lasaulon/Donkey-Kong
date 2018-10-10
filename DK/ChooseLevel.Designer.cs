namespace DK
{
    partial class ChooseLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLevel));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLvl1 = new System.Windows.Forms.Button();
            this.btnLvl2 = new System.Windows.Forms.Button();
            this.btnLvl3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Level";
            // 
            // btnLvl1
            // 
            this.btnLvl1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl1.Location = new System.Drawing.Point(91, 159);
            this.btnLvl1.Name = "btnLvl1";
            this.btnLvl1.Size = new System.Drawing.Size(131, 31);
            this.btnLvl1.TabIndex = 1;
            this.btnLvl1.Text = "Level 1";
            this.btnLvl1.UseVisualStyleBackColor = true;
            this.btnLvl1.Click += new System.EventHandler(this.btnLvl1_Click);
            // 
            // btnLvl2
            // 
            this.btnLvl2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl2.Location = new System.Drawing.Point(91, 209);
            this.btnLvl2.Name = "btnLvl2";
            this.btnLvl2.Size = new System.Drawing.Size(131, 31);
            this.btnLvl2.TabIndex = 2;
            this.btnLvl2.Text = "Level 2";
            this.btnLvl2.UseVisualStyleBackColor = true;
            this.btnLvl2.Click += new System.EventHandler(this.btnLvl2_Click);
            // 
            // btnLvl3
            // 
            this.btnLvl3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl3.Location = new System.Drawing.Point(91, 264);
            this.btnLvl3.Name = "btnLvl3";
            this.btnLvl3.Size = new System.Drawing.Size(131, 31);
            this.btnLvl3.TabIndex = 3;
            this.btnLvl3.Text = "Level 3";
            this.btnLvl3.UseVisualStyleBackColor = true;
            this.btnLvl3.Click += new System.EventHandler(this.btnLvl3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 199);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnMM
            // 
            this.btnMM.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMM.Location = new System.Drawing.Point(12, 339);
            this.btnMM.Name = "btnMM";
            this.btnMM.Size = new System.Drawing.Size(115, 23);
            this.btnMM.TabIndex = 5;
            this.btnMM.Text = "Main Menu";
            this.btnMM.UseVisualStyleBackColor = true;
            this.btnMM.Click += new System.EventHandler(this.btnMM_Click);
            // 
            // ChooseLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(543, 374);
            this.Controls.Add(this.btnMM);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLvl3);
            this.Controls.Add(this.btnLvl2);
            this.Controls.Add(this.btnLvl1);
            this.Controls.Add(this.label1);
            this.Name = "ChooseLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseLevel";
            this.Activated += new System.EventHandler(this.ChooseLevel_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLvl1;
        private System.Windows.Forms.Button btnLvl2;
        private System.Windows.Forms.Button btnLvl3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMM;
    }
}