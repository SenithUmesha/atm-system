namespace ATM
{
    partial class FundTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FundTransfer));
            this.lblraccno = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.txtraccno = new System.Windows.Forms.TextBox();
            this.btnproceed = new System.Windows.Forms.Button();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblamount = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.lblcpin = new System.Windows.Forms.Label();
            this.txtcpin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblraccno
            // 
            this.lblraccno.AutoSize = true;
            this.lblraccno.BackColor = System.Drawing.Color.White;
            this.lblraccno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblraccno.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblraccno.ForeColor = System.Drawing.Color.DimGray;
            this.lblraccno.Location = new System.Drawing.Point(39, 385);
            this.lblraccno.Name = "lblraccno";
            this.lblraccno.Size = new System.Drawing.Size(376, 46);
            this.lblraccno.TabIndex = 125;
            this.lblraccno.Text = "Receiver\'s account no :";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.DimGray;
            this.btnreset.FlatAppearance.BorderSize = 0;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreset.Location = new System.Drawing.Point(191, 577);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(191, 55);
            this.btnreset.TabIndex = 124;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.DimGray;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnback.Location = new System.Drawing.Point(292, 649);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(191, 55);
            this.btnback.TabIndex = 123;
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
            this.lblinfo.Location = new System.Drawing.Point(260, 312);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(264, 49);
            this.lblinfo.TabIndex = 122;
            this.lblinfo.Text = "Fund Transfer :";
            // 
            // txtraccno
            // 
            this.txtraccno.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtraccno.ForeColor = System.Drawing.Color.Gray;
            this.txtraccno.Location = new System.Drawing.Point(439, 391);
            this.txtraccno.Name = "txtraccno";
            this.txtraccno.Size = new System.Drawing.Size(268, 40);
            this.txtraccno.TabIndex = 121;
            this.txtraccno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtraccno_KeyPress);
            // 
            // btnproceed
            // 
            this.btnproceed.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnproceed.FlatAppearance.BorderSize = 0;
            this.btnproceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproceed.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproceed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnproceed.Location = new System.Drawing.Point(398, 577);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(191, 55);
            this.btnproceed.TabIndex = 120;
            this.btnproceed.Text = "Proceed";
            this.btnproceed.UseVisualStyleBackColor = false;
            this.btnproceed.Click += new System.EventHandler(this.btnproceed_Click);
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.Location = new System.Drawing.Point(710, 12);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(28, 29);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbclose.TabIndex = 119;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(263, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 750);
            this.panel2.TabIndex = 126;
            // 
            // lblamount
            // 
            this.lblamount.AutoSize = true;
            this.lblamount.BackColor = System.Drawing.Color.White;
            this.lblamount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblamount.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamount.ForeColor = System.Drawing.Color.DimGray;
            this.lblamount.Location = new System.Drawing.Point(249, 440);
            this.lblamount.Name = "lblamount";
            this.lblamount.Size = new System.Drawing.Size(166, 46);
            this.lblamount.TabIndex = 128;
            this.lblamount.Text = "Amount :";
            // 
            // txtamount
            // 
            this.txtamount.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamount.ForeColor = System.Drawing.Color.Gray;
            this.txtamount.Location = new System.Drawing.Point(439, 446);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(268, 40);
            this.txtamount.TabIndex = 127;
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamount_KeyPress);
            // 
            // lblcpin
            // 
            this.lblcpin.AutoSize = true;
            this.lblcpin.BackColor = System.Drawing.Color.White;
            this.lblcpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcpin.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcpin.ForeColor = System.Drawing.Color.DimGray;
            this.lblcpin.Location = new System.Drawing.Point(186, 495);
            this.lblcpin.Name = "lblcpin";
            this.lblcpin.Size = new System.Drawing.Size(229, 46);
            this.lblcpin.TabIndex = 143;
            this.lblcpin.Text = "Confirm PIN :";
            // 
            // txtcpin
            // 
            this.txtcpin.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpin.ForeColor = System.Drawing.Color.Gray;
            this.txtcpin.Location = new System.Drawing.Point(439, 501);
            this.txtcpin.Name = "txtcpin";
            this.txtcpin.Size = new System.Drawing.Size(268, 40);
            this.txtcpin.TabIndex = 142;
            this.txtcpin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcpin_KeyPress);
            // 
            // FundTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 750);
            this.Controls.Add(this.lblcpin);
            this.Controls.Add(this.txtcpin);
            this.Controls.Add(this.lblamount);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblraccno);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.txtraccno);
            this.Controls.Add(this.btnproceed);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FundTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZEMO Bank";
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblraccno;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox txtraccno;
        private System.Windows.Forms.Button btnproceed;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblamount;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label lblcpin;
        private System.Windows.Forms.TextBox txtcpin;
    }
}