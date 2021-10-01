namespace ATM
{
    partial class BillPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillPayment));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.pbwater = new System.Windows.Forms.PictureBox();
            this.pbelectricity = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.electricity1 = new ATM.electricity();
            this.water1 = new ATM.water();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbelectricity)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(263, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.DimGray;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnback.Location = new System.Drawing.Point(301, 649);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(191, 55);
            this.btnback.TabIndex = 128;
            this.btnback.Text = "Go Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblinfo.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblinfo.Location = new System.Drawing.Point(233, 320);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(329, 49);
            this.lblinfo.TabIndex = 127;
            this.lblinfo.Text = "Available services :";
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.Location = new System.Drawing.Point(710, 12);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(28, 29);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbclose.TabIndex = 125;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            // 
            // pbwater
            // 
            this.pbwater.Image = ((System.Drawing.Image)(resources.GetObject("pbwater.Image")));
            this.pbwater.Location = new System.Drawing.Point(220, 429);
            this.pbwater.Name = "pbwater";
            this.pbwater.Size = new System.Drawing.Size(150, 150);
            this.pbwater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbwater.TabIndex = 129;
            this.pbwater.TabStop = false;
            this.pbwater.Click += new System.EventHandler(this.pbwater_Click);
            // 
            // pbelectricity
            // 
            this.pbelectricity.Image = ((System.Drawing.Image)(resources.GetObject("pbelectricity.Image")));
            this.pbelectricity.Location = new System.Drawing.Point(412, 429);
            this.pbelectricity.Name = "pbelectricity";
            this.pbelectricity.Size = new System.Drawing.Size(150, 150);
            this.pbelectricity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbelectricity.TabIndex = 130;
            this.pbelectricity.TabStop = false;
            this.pbelectricity.Click += new System.EventHandler(this.pbelectricity_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 750);
            this.panel2.TabIndex = 131;
            // 
            // electricity1
            // 
            this.electricity1.AutoSize = true;
            this.electricity1.BackColor = System.Drawing.Color.White;
            this.electricity1.Location = new System.Drawing.Point(12, 0);
            this.electricity1.Name = "electricity1";
            this.electricity1.Size = new System.Drawing.Size(740, 750);
            this.electricity1.TabIndex = 132;
            // 
            // water1
            // 
            this.water1.AutoSize = true;
            this.water1.BackColor = System.Drawing.Color.White;
            this.water1.Location = new System.Drawing.Point(12, 0);
            this.water1.Name = "water1";
            this.water1.Size = new System.Drawing.Size(740, 750);
            this.water1.TabIndex = 133;
            // 
            // BillPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 750);
            this.Controls.Add(this.water1);
            this.Controls.Add(this.electricity1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbelectricity);
            this.Controls.Add(this.pbwater);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZEMO Bank";
            this.Load += new System.EventHandler(this.BillPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbelectricity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.PictureBox pbwater;
        private System.Windows.Forms.PictureBox pbelectricity;
        private System.Windows.Forms.Panel panel2;
        private electricity electricity1;
        private water water1;
    }
}