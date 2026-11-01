namespace AMSPROJECT
{
    partial class UserControllEAVEAPPROVED
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
            this.btndeny = new System.Windows.Forms.Button();
            this.btnapproved = new System.Windows.Forms.Button();
            this.leavegrid = new System.Windows.Forms.DataGridView();
            this.leaveid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavefrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavestatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leavegrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btndeny
            // 
            this.btndeny.BackColor = System.Drawing.Color.LightCoral;
            this.btndeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeny.Location = new System.Drawing.Point(656, 69);
            this.btndeny.Name = "btndeny";
            this.btndeny.Size = new System.Drawing.Size(75, 23);
            this.btndeny.TabIndex = 32;
            this.btndeny.Text = "DENY";
            this.btndeny.UseVisualStyleBackColor = false;
            this.btndeny.Click += new System.EventHandler(this.btndeny_Click_1);
            // 
            // btnapproved
            // 
            this.btnapproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnapproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapproved.Location = new System.Drawing.Point(575, 69);
            this.btnapproved.Name = "btnapproved";
            this.btnapproved.Size = new System.Drawing.Size(75, 23);
            this.btnapproved.TabIndex = 31;
            this.btnapproved.Text = "APPROVE";
            this.btnapproved.UseVisualStyleBackColor = false;
            this.btnapproved.Click += new System.EventHandler(this.btnapproved_Click);
            // 
            // leavegrid
            // 
            this.leavegrid.AllowUserToAddRows = false;
            this.leavegrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leavegrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leaveid,
            this.name,
            this.leavetype,
            this.leavefrom,
            this.leaveto,
            this.leavestatus});
            this.leavegrid.Location = new System.Drawing.Point(17, 98);
            this.leavegrid.Name = "leavegrid";
            this.leavegrid.Size = new System.Drawing.Size(714, 342);
            this.leavegrid.TabIndex = 24;
            // 
            // leaveid
            // 
            this.leaveid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leaveid.HeaderText = "LEAVE_ID";
            this.leaveid.Name = "leaveid";
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "NAME";
            this.name.Name = "name";
            // 
            // leavetype
            // 
            this.leavetype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leavetype.HeaderText = "LEAVE_TYPE";
            this.leavetype.Name = "leavetype";
            // 
            // leavefrom
            // 
            this.leavefrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leavefrom.HeaderText = "LEAVE_FROM";
            this.leavefrom.Name = "leavefrom";
            // 
            // leaveto
            // 
            this.leaveto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leaveto.HeaderText = "LEAVE_TO";
            this.leaveto.Name = "leaveto";
            // 
            // leavestatus
            // 
            this.leavestatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leavestatus.HeaderText = "LEAVE_STATUS";
            this.leavestatus.Name = "leavestatus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(-5, -2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "LEAVE REPORT";
            // 
            // UserControllEAVEAPPROVED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btndeny);
            this.Controls.Add(this.btnapproved);
            this.Controls.Add(this.leavegrid);
            this.Name = "UserControllEAVEAPPROVED";
            this.Size = new System.Drawing.Size(748, 456);
            ((System.ComponentModel.ISupportInitialize)(this.leavegrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndeny;
        private System.Windows.Forms.Button btnapproved;
        private System.Windows.Forms.DataGridView leavegrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveid;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavefrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveto;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavestatus;
    }
}
