namespace ATM
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnback = new System.Windows.Forms.Button();
            this.btncpin = new System.Windows.Forms.Button();
            this.btnnatms = new System.Windows.Forms.Button();
            this.lblreg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.btnereceipts = new System.Windows.Forms.Button();
            this.nearbyATM1 = new ATM.NearbyATM();
            this.changePIN1 = new ATM.ChangePIN();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.DimGray;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnback.Location = new System.Drawing.Point(245, 559);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(271, 98);
            this.btnback.TabIndex = 141;
            this.btnback.Text = "Go Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btncpin
            // 
            this.btncpin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncpin.FlatAppearance.BorderSize = 0;
            this.btncpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncpin.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncpin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncpin.Location = new System.Drawing.Point(245, 425);
            this.btncpin.Name = "btncpin";
            this.btncpin.Size = new System.Drawing.Size(271, 98);
            this.btncpin.TabIndex = 140;
            this.btncpin.Text = "Change PIN";
            this.btncpin.UseVisualStyleBackColor = false;
            this.btncpin.Click += new System.EventHandler(this.btncpin_Click);
            // 
            // btnnatms
            // 
            this.btnnatms.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnnatms.FlatAppearance.BorderSize = 0;
            this.btnnatms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnatms.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnatms.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnnatms.Location = new System.Drawing.Point(245, 157);
            this.btnnatms.Name = "btnnatms";
            this.btnnatms.Size = new System.Drawing.Size(271, 98);
            this.btnnatms.TabIndex = 139;
            this.btnnatms.Text = "Print Nearby ATMs";
            this.btnnatms.UseVisualStyleBackColor = false;
            this.btnnatms.Click += new System.EventHandler(this.btnnatms_Click);
            // 
            // lblreg
            // 
            this.lblreg.AutoSize = true;
            this.lblreg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblreg.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreg.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblreg.Location = new System.Drawing.Point(61, 50);
            this.lblreg.Name = "lblreg";
            this.lblreg.Size = new System.Drawing.Size(412, 49);
            this.lblreg.TabIndex = 138;
            this.lblreg.Text = "Available Transactions : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 750);
            this.panel2.TabIndex = 137;
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.Location = new System.Drawing.Point(710, 12);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(28, 29);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbclose.TabIndex = 136;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            // 
            // btnereceipts
            // 
            this.btnereceipts.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnereceipts.FlatAppearance.BorderSize = 0;
            this.btnereceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnereceipts.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnereceipts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnereceipts.Location = new System.Drawing.Point(245, 291);
            this.btnereceipts.Name = "btnereceipts";
            this.btnereceipts.Size = new System.Drawing.Size(271, 98);
            this.btnereceipts.TabIndex = 144;
            this.btnereceipts.Text = "E-Receipts";
            this.btnereceipts.UseVisualStyleBackColor = false;
            this.btnereceipts.Click += new System.EventHandler(this.btnereceipts_Click);
            // 
            // nearbyATM1
            // 
            this.nearbyATM1.AutoSize = true;
            this.nearbyATM1.BackColor = System.Drawing.Color.White;
            this.nearbyATM1.Location = new System.Drawing.Point(12, 0);
            this.nearbyATM1.Name = "nearbyATM1";
            this.nearbyATM1.Size = new System.Drawing.Size(740, 750);
            this.nearbyATM1.TabIndex = 143;
            // 
            // changePIN1
            // 
            this.changePIN1.AutoSize = true;
            this.changePIN1.BackColor = System.Drawing.Color.White;
            this.changePIN1.Location = new System.Drawing.Point(12, 0);
            this.changePIN1.Name = "changePIN1";
            this.changePIN1.Size = new System.Drawing.Size(740, 750);
            this.changePIN1.TabIndex = 142;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 750);
            this.Controls.Add(this.nearbyATM1);
            this.Controls.Add(this.changePIN1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btncpin);
            this.Controls.Add(this.btnnatms);
            this.Controls.Add(this.lblreg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.btnereceipts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZEMO Bank";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btncpin;
        private System.Windows.Forms.Button btnnatms;
        private System.Windows.Forms.Label lblreg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbclose;
        private ChangePIN changePIN1;
        private NearbyATM nearbyATM1;
        private System.Windows.Forms.Button btnereceipts;
    }
}