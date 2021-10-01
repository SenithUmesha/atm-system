namespace ATM
{
    partial class water
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(water));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblcpin = new System.Windows.Forms.Label();
            this.txtcpin = new System.Windows.Forms.TextBox();
            this.lblamount = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.lblbillno = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.btnproceed = new System.Windows.Forms.Button();
            this.pbwater = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwater)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(509, 97);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(216, 150);
            this.dgv.TabIndex = 153;
            // 
            // lblcpin
            // 
            this.lblcpin.AutoSize = true;
            this.lblcpin.BackColor = System.Drawing.Color.White;
            this.lblcpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcpin.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcpin.ForeColor = System.Drawing.Color.DimGray;
            this.lblcpin.Location = new System.Drawing.Point(74, 473);
            this.lblcpin.Name = "lblcpin";
            this.lblcpin.Size = new System.Drawing.Size(229, 46);
            this.lblcpin.TabIndex = 152;
            this.lblcpin.Text = "Confirm PIN :";
            // 
            // txtcpin
            // 
            this.txtcpin.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpin.ForeColor = System.Drawing.Color.Gray;
            this.txtcpin.Location = new System.Drawing.Point(325, 479);
            this.txtcpin.Name = "txtcpin";
            this.txtcpin.Size = new System.Drawing.Size(322, 40);
            this.txtcpin.TabIndex = 151;
            this.txtcpin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcpin_KeyPress);
            // 
            // lblamount
            // 
            this.lblamount.AutoSize = true;
            this.lblamount.BackColor = System.Drawing.Color.White;
            this.lblamount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblamount.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamount.ForeColor = System.Drawing.Color.DimGray;
            this.lblamount.Location = new System.Drawing.Point(137, 413);
            this.lblamount.Name = "lblamount";
            this.lblamount.Size = new System.Drawing.Size(166, 46);
            this.lblamount.TabIndex = 150;
            this.lblamount.Text = "Amount :";
            // 
            // txtamount
            // 
            this.txtamount.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamount.ForeColor = System.Drawing.Color.Gray;
            this.txtamount.Location = new System.Drawing.Point(325, 419);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(322, 40);
            this.txtamount.TabIndex = 149;
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamount_KeyPress);
            // 
            // lblbillno
            // 
            this.lblbillno.AutoSize = true;
            this.lblbillno.BackColor = System.Drawing.Color.White;
            this.lblbillno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblbillno.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbillno.ForeColor = System.Drawing.Color.DimGray;
            this.lblbillno.Location = new System.Drawing.Point(167, 353);
            this.lblbillno.Name = "lblbillno";
            this.lblbillno.Size = new System.Drawing.Size(136, 46);
            this.lblbillno.TabIndex = 148;
            this.lblbillno.Text = "Bill no :";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.DimGray;
            this.btnreset.FlatAppearance.BorderSize = 0;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreset.Location = new System.Drawing.Point(175, 578);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(191, 55);
            this.btnreset.TabIndex = 147;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // txtbillno
            // 
            this.txtbillno.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbillno.ForeColor = System.Drawing.Color.Gray;
            this.txtbillno.Location = new System.Drawing.Point(325, 359);
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.Size = new System.Drawing.Size(322, 40);
            this.txtbillno.TabIndex = 146;
            this.txtbillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbillno_KeyPress);
            // 
            // btnproceed
            // 
            this.btnproceed.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnproceed.FlatAppearance.BorderSize = 0;
            this.btnproceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproceed.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproceed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnproceed.Location = new System.Drawing.Point(398, 578);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(191, 55);
            this.btnproceed.TabIndex = 145;
            this.btnproceed.Text = "Proceed";
            this.btnproceed.UseVisualStyleBackColor = false;
            this.btnproceed.Click += new System.EventHandler(this.btnproceed_Click);
            // 
            // pbwater
            // 
            this.pbwater.Image = ((System.Drawing.Image)(resources.GetObject("pbwater.Image")));
            this.pbwater.Location = new System.Drawing.Point(253, 38);
            this.pbwater.Name = "pbwater";
            this.pbwater.Size = new System.Drawing.Size(250, 250);
            this.pbwater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbwater.TabIndex = 144;
            this.pbwater.TabStop = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.DimGray;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnback.Location = new System.Drawing.Point(296, 654);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(191, 55);
            this.btnback.TabIndex = 143;
            this.btnback.Text = "Go Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // water
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblcpin);
            this.Controls.Add(this.txtcpin);
            this.Controls.Add(this.lblamount);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.lblbillno);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.txtbillno);
            this.Controls.Add(this.btnproceed);
            this.Controls.Add(this.pbwater);
            this.Controls.Add(this.btnback);
            this.Name = "water";
            this.Size = new System.Drawing.Size(740, 750);
            this.Load += new System.EventHandler(this.water_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwater)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblcpin;
        private System.Windows.Forms.TextBox txtcpin;
        private System.Windows.Forms.Label lblamount;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label lblbillno;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.Button btnproceed;
        private System.Windows.Forms.PictureBox pbwater;
        private System.Windows.Forms.Button btnback;
    }
}
