namespace AMSPROJECT
{
    partial class UserControl1attendance
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
            this.atbtnfilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.atdatagrid = new System.Windows.Forms.DataGridView();
            this.atfromdate = new System.Windows.Forms.DateTimePicker();
            this.atttodate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.atdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // atbtnfilter
            // 
            this.atbtnfilter.BackColor = System.Drawing.Color.Navy;
            this.atbtnfilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atbtnfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atbtnfilter.ForeColor = System.Drawing.Color.White;
            this.atbtnfilter.Location = new System.Drawing.Point(654, 85);
            this.atbtnfilter.Name = "atbtnfilter";
            this.atbtnfilter.Size = new System.Drawing.Size(78, 33);
            this.atbtnfilter.TabIndex = 4;
            this.atbtnfilter.Text = "FILTER";
            this.atbtnfilter.UseVisualStyleBackColor = false;
            this.atbtnfilter.Click += new System.EventHandler(this.atbtnfilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "TO";
            // 
            // atdatagrid
            // 
            this.atdatagrid.AllowUserToAddRows = false;
            this.atdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.atdatagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.atdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.atdatagrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.atdatagrid.Location = new System.Drawing.Point(12, 139);
            this.atdatagrid.Name = "atdatagrid";
            this.atdatagrid.Size = new System.Drawing.Size(720, 300);
            this.atdatagrid.TabIndex = 15;
            // 
            // atfromdate
            // 
            this.atfromdate.Location = new System.Drawing.Point(198, 93);
            this.atfromdate.Name = "atfromdate";
            this.atfromdate.Size = new System.Drawing.Size(203, 20);
            this.atfromdate.TabIndex = 16;
            // 
            // atttodate
            // 
            this.atttodate.Location = new System.Drawing.Point(445, 93);
            this.atttodate.Name = "atttodate";
            this.atttodate.Size = new System.Drawing.Size(203, 20);
            this.atttodate.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(-2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "ATTENDANACE REPORT";
            // 
            // UserControl1attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.atttodate);
            this.Controls.Add(this.atfromdate);
            this.Controls.Add(this.atdatagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atbtnfilter);
            this.Name = "UserControl1attendance";
            this.Size = new System.Drawing.Size(748, 456);
            this.Load += new System.EventHandler(this.UserControl1attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.atdatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button atbtnfilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView atdatagrid;
        private System.Windows.Forms.DateTimePicker atfromdate;
        private System.Windows.Forms.DateTimePicker atttodate;
        private System.Windows.Forms.Label label3;
    }
}
