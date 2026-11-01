namespace AMSPROJECT
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.userControllEAVEAPPROVED1 = new AMSPROJECT.UserControllEAVEAPPROVED();
            this.userControl1attendance1 = new AMSPROJECT.UserControl1attendance();
            this.userControlemplist1 = new AMSPROJECT.UserControlemplist();
            this.userControldeduct2 = new AMSPROJECT.UserControldeduct();
            this.userControldeduct1 = new AMSPROJECT.UserControldeduct();
            this.userControlpayroll1 = new AMSPROJECT.UserControlpayroll();
            this.userControlemployee2 = new AMSPROJECT.UserControlemployee();
            this.userControldashboard11 = new AMSPROJECT.UserControldashboard1();
            this.userControlemployee1 = new AMSPROJECT.UserControlemployee();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "DASHBOARD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "ATTENDANCE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 35);
            this.button3.TabIndex = 9;
            this.button3.Text = "ADD EMPLOYEE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 399);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(144, 35);
            this.button7.TabIndex = 12;
            this.button7.Text = "PAYROLL";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(0, 279);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(144, 35);
            this.button8.TabIndex = 13;
            this.button8.Text = "EMPLOYEE LIST";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 516);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 359);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 35);
            this.button4.TabIndex = 14;
            this.button4.Text = "LEAVE REPORT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(143, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 38);
            this.panel2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 465);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // userControllEAVEAPPROVED1
            // 
            this.userControllEAVEAPPROVED1.Location = new System.Drawing.Point(146, 43);
            this.userControllEAVEAPPROVED1.Name = "userControllEAVEAPPROVED1";
            this.userControllEAVEAPPROVED1.Size = new System.Drawing.Size(748, 472);
            this.userControllEAVEAPPROVED1.TabIndex = 14;
            // 
            // userControl1attendance1
            // 
            this.userControl1attendance1.Location = new System.Drawing.Point(144, 59);
            this.userControl1attendance1.Name = "userControl1attendance1";
            this.userControl1attendance1.Size = new System.Drawing.Size(748, 456);
            this.userControl1attendance1.TabIndex = 12;
            // 
            // userControlemplist1
            // 
            this.userControlemplist1.Location = new System.Drawing.Point(146, 60);
            this.userControlemplist1.Name = "userControlemplist1";
            this.userControlemplist1.Size = new System.Drawing.Size(748, 456);
            this.userControlemplist1.TabIndex = 11;
            // 
            // userControldeduct2
            // 
            this.userControldeduct2.Location = new System.Drawing.Point(146, 62);
            this.userControldeduct2.Name = "userControldeduct2";
            this.userControldeduct2.Size = new System.Drawing.Size(748, 456);
            this.userControldeduct2.TabIndex = 10;
            // 
            // userControldeduct1
            // 
            this.userControldeduct1.Location = new System.Drawing.Point(1316, -213);
            this.userControldeduct1.Name = "userControldeduct1";
            this.userControldeduct1.Size = new System.Drawing.Size(748, 456);
            this.userControldeduct1.TabIndex = 9;
            // 
            // userControlpayroll1
            // 
            this.userControlpayroll1.Location = new System.Drawing.Point(147, 61);
            this.userControlpayroll1.Name = "userControlpayroll1";
            this.userControlpayroll1.Size = new System.Drawing.Size(748, 456);
            this.userControlpayroll1.TabIndex = 8;
            // 
            // userControlemployee2
            // 
            this.userControlemployee2.Location = new System.Drawing.Point(147, 63);
            this.userControlemployee2.Name = "userControlemployee2";
            this.userControlemployee2.Size = new System.Drawing.Size(748, 456);
            this.userControlemployee2.TabIndex = 6;
            // 
            // userControldashboard11
            // 
            this.userControldashboard11.Location = new System.Drawing.Point(147, 64);
            this.userControldashboard11.Name = "userControldashboard11";
            this.userControldashboard11.Size = new System.Drawing.Size(748, 456);
            this.userControldashboard11.TabIndex = 5;
            // 
            // userControlemployee1
            // 
            this.userControlemployee1.Location = new System.Drawing.Point(146, 62);
            this.userControlemployee1.Name = "userControlemployee1";
            this.userControlemployee1.Size = new System.Drawing.Size(748, 456);
            this.userControlemployee1.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 515);
            this.ControlBox = false;
            this.Controls.Add(this.userControllEAVEAPPROVED1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userControl1attendance1);
            this.Controls.Add(this.userControlemplist1);
            this.Controls.Add(this.userControldeduct2);
            this.Controls.Add(this.userControldeduct1);
            this.Controls.Add(this.userControlpayroll1);
            this.Controls.Add(this.userControlemployee2);
            this.Controls.Add(this.userControldashboard11);
            this.Controls.Add(this.userControlemployee1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "ADMIN PAGE";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControlemployee userControlemployee1;
        private UserControldashboard1 userControldashboard11;
        private UserControlemployee userControlemployee2;

        private UserControlpayroll userControlpayroll1;
        private UserControldeduct userControldeduct1;
        private UserControldeduct userControldeduct2;
        private UserControlemplist userControlemplist1;
        private UserControl1attendance userControl1attendance1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private UserControllEAVEAPPROVED userControllEAVEAPPROVED1;
    }
}