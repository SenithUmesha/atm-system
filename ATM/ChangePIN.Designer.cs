namespace ATM
{
    partial class ChangePIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePIN));
            this.lblcnewpin = new System.Windows.Forms.Label();
            this.txtcnewpin = new System.Windows.Forms.TextBox();
            this.lblnewpin = new System.Windows.Forms.Label();
            this.txtnewpin = new System.Windows.Forms.TextBox();
            this.lblcpin = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.txtcpin = new System.Windows.Forms.TextBox();
            this.btnproceed = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcnewpin
            // 
            this.lblcnewpin.AutoSize = true;
            this.lblcnewpin.BackColor = System.Drawing.Color.White;
            this.lblcnewpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcnewpin.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcnewpin.ForeColor = System.Drawing.Color.DimGray;
            this.lblcnewpin.Location = new System.Drawing.Point(66, 485);
            this.lblcnewpin.Name = "lblcnewpin";
            this.lblcnewpin.Size = new System.Drawing.Size(303, 46);
            this.lblcnewpin.TabIndex = 154;
            this.lblcnewpin.Text = "Confirm new PIN :";
            // 
            // txtcnewpin
            // 
            this.txtcnewpin.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcnewpin.ForeColor = System.Drawing.Color.Gray;
            this.txtcnewpin.Location = new System.Drawing.Point(399, 491);
            this.txtcnewpin.Name = "txtcnewpin";
            this.txtcnewpin.Size = new System.Drawing.Size(276, 40);
            this.txtcnewpin.TabIndex = 153;
            this.txtcnewpin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcnewpin_KeyPress);
            // 
            // lblnewpin
            // 
            this.lblnewpin.AutoSize = true;
            this.lblnewpin.BackColor = System.Drawing.Color.White;
            this.lblnewpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblnewpin.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnewpin.ForeColor = System.Drawing.Color.DimGray;
            this.lblnewpin.Location = new System.Drawing.Point(194, 417);
            this.lblnewpin.Name = "lblnewpin";
            this.lblnewpin.Size = new System.Drawing.Size(175, 46);
            this.lblnewpin.TabIndex = 152;
            this.lblnewpin.Text = "New PIN :";
            // 
            // txtnewpin
            // 
            this.txtnewpin.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewpin.ForeColor = System.Drawing.Color.Gray;
            this.txtnewpin.Location = new System.Drawing.Point(399, 423);
            this.txtnewpin.Name = "txtnewpin";
            this.txtnewpin.Size = new System.Drawing.Size(276, 40);
            this.txtnewpin.TabIndex = 151;
            this.txtnewpin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewpin_KeyPress);
            // 
            // lblcpin
            // 
            this.lblcpin.AutoSize = true;
            this.lblcpin.BackColor = System.Drawing.Color.White;
            this.lblcpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcpin.Font = new System.Drawing.Font("Corbel", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcpin.ForeColor = System.Drawing.Color.DimGray;
            this.lblcpin.Location = new System.Drawing.Point(146, 349);
            this.lblcpin.Name = "lblcpin";
            this.lblcpin.Size = new System.Drawing.Size(223, 46);
            this.lblcpin.TabIndex = 150;
            this.lblcpin.Text = "Current PIN :";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.DimGray;
            this.btnreset.FlatAppearance.BorderSize = 0;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreset.Location = new System.Drawing.Point(178, 581);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(191, 55);
            this.btnreset.TabIndex = 149;
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
            this.btnback.Location = new System.Drawing.Point(279, 653);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(191, 55);
            this.btnback.TabIndex = 148;
            this.btnback.Text = "Go Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // txtcpin
            // 
            this.txtcpin.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpin.ForeColor = System.Drawing.Color.Gray;
            this.txtcpin.Location = new System.Drawing.Point(399, 355);
            this.txtcpin.Name = "txtcpin";
            this.txtcpin.Size = new System.Drawing.Size(276, 40);
            this.txtcpin.TabIndex = 147;
            this.txtcpin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcpin_KeyPress);
            // 
            // btnproceed
            // 
            this.btnproceed.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnproceed.FlatAppearance.BorderSize = 0;
            this.btnproceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproceed.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproceed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnproceed.Location = new System.Drawing.Point(385, 581);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(191, 55);
            this.btnproceed.TabIndex = 146;
            this.btnproceed.Text = "Proceed";
            this.btnproceed.UseVisualStyleBackColor = false;
            this.btnproceed.Click += new System.EventHandler(this.btnproceed_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            // 
            // ChangePIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblcnewpin);
            this.Controls.Add(this.txtcnewpin);
            this.Controls.Add(this.lblnewpin);
            this.Controls.Add(this.txtnewpin);
            this.Controls.Add(this.lblcpin);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.txtcpin);
            this.Controls.Add(this.btnproceed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChangePIN";
            this.Size = new System.Drawing.Size(740, 750);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcnewpin;
        private System.Windows.Forms.TextBox txtcnewpin;
        private System.Windows.Forms.Label lblnewpin;
        private System.Windows.Forms.TextBox txtnewpin;
        private System.Windows.Forms.Label lblcpin;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.TextBox txtcpin;
        private System.Windows.Forms.Button btnproceed;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
