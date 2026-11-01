namespace AMSPROJECT
{
    partial class UserControlhome
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
            this.hometimein = new System.Windows.Forms.Button();
            this.hometimeout = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hometimein
            // 
            this.hometimein.BackColor = System.Drawing.Color.Lime;
            this.hometimein.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hometimein.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hometimein.Location = new System.Drawing.Point(180, 170);
            this.hometimein.Name = "hometimein";
            this.hometimein.Size = new System.Drawing.Size(212, 83);
            this.hometimein.TabIndex = 1;
            this.hometimein.Text = "TIME-IN";
            this.hometimein.UseVisualStyleBackColor = false;
            this.hometimein.Click += new System.EventHandler(this.hometimein_Click);
            // 
            // hometimeout
            // 
            this.hometimeout.BackColor = System.Drawing.Color.Red;
            this.hometimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hometimeout.ForeColor = System.Drawing.Color.Black;
            this.hometimeout.Location = new System.Drawing.Point(393, 170);
            this.hometimeout.Name = "hometimeout";
            this.hometimeout.Size = new System.Drawing.Size(212, 83);
            this.hometimeout.TabIndex = 2;
            this.hometimeout.Text = "TIME-OUT";
            this.hometimeout.UseVisualStyleBackColor = false;
            this.hometimeout.Click += new System.EventHandler(this.hometimeout_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(292, 117);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(-2, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 29);
            this.label10.TabIndex = 53;
            this.label10.Text = "HOME";
            // 
            // UserControlhome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.hometimeout);
            this.Controls.Add(this.hometimein);
            this.Name = "UserControlhome";
            this.Size = new System.Drawing.Size(748, 456);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button hometimein;
        private System.Windows.Forms.Button hometimeout;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
    }
}
