namespace AMSPROJECT
{
    partial class UserControlpayroll
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
            this.paygrid = new System.Windows.Forms.DataGridView();
            this.payfilter = new System.Windows.Forms.Button();
            this.payexport = new System.Windows.Forms.Button();
            this.paysearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paygrid)).BeginInit();
            this.SuspendLayout();
            // 
            // paygrid
            // 
            this.paygrid.AllowUserToAddRows = false;
            this.paygrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paygrid.Location = new System.Drawing.Point(23, 109);
            this.paygrid.Name = "paygrid";
            this.paygrid.Size = new System.Drawing.Size(708, 324);
            this.paygrid.TabIndex = 0;
            // 
            // payfilter
            // 
            this.payfilter.BackColor = System.Drawing.Color.Navy;
            this.payfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payfilter.ForeColor = System.Drawing.Color.White;
            this.payfilter.Location = new System.Drawing.Point(584, 69);
            this.payfilter.Name = "payfilter";
            this.payfilter.Size = new System.Drawing.Size(75, 38);
            this.payfilter.TabIndex = 1;
            this.payfilter.Text = "FILTER";
            this.payfilter.UseVisualStyleBackColor = false;
            this.payfilter.Click += new System.EventHandler(this.payfilter_Click);
            // 
            // payexport
            // 
            this.payexport.BackColor = System.Drawing.Color.Green;
            this.payexport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payexport.ForeColor = System.Drawing.Color.White;
            this.payexport.Location = new System.Drawing.Point(656, 69);
            this.payexport.Name = "payexport";
            this.payexport.Size = new System.Drawing.Size(75, 38);
            this.payexport.TabIndex = 3;
            this.payexport.Text = "EXPORT";
            this.payexport.UseVisualStyleBackColor = false;
            this.payexport.Click += new System.EventHandler(this.payexport_Click);
            // 
            // paysearch
            // 
            this.paysearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paysearch.Location = new System.Drawing.Point(436, 69);
            this.paysearch.Multiline = true;
            this.paysearch.Name = "paysearch";
            this.paysearch.Size = new System.Drawing.Size(147, 34);
            this.paysearch.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(-4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "PAYROLL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search";
            // 
            // UserControlpayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paysearch);
            this.Controls.Add(this.payexport);
            this.Controls.Add(this.payfilter);
            this.Controls.Add(this.paygrid);
            this.Name = "UserControlpayroll";
            this.Size = new System.Drawing.Size(748, 456);
            ((System.ComponentModel.ISupportInitialize)(this.paygrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView paygrid;
        private System.Windows.Forms.Button payfilter;
        private System.Windows.Forms.Button payexport;
        private System.Windows.Forms.TextBox paysearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
