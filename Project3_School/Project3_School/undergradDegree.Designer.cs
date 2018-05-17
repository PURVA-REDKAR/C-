namespace Project3_School
{
    partial class undergradDegree
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
            this.rtb_undgrd_t = new System.Windows.Forms.RichTextBox();
            this.dgv_und = new System.Windows.Forms.DataGridView();
            this.Concentration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_und)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_undgrd_t
            // 
            this.rtb_undgrd_t.BackColor = System.Drawing.Color.DarkSalmon;
            this.rtb_undgrd_t.Location = new System.Drawing.Point(12, 12);
            this.rtb_undgrd_t.Name = "rtb_undgrd_t";
            this.rtb_undgrd_t.Size = new System.Drawing.Size(776, 174);
            this.rtb_undgrd_t.TabIndex = 0;
            this.rtb_undgrd_t.Text = "";
            // 
            // dgv_und
            // 
            this.dgv_und.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.dgv_und.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_und.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concentration});
            this.dgv_und.Location = new System.Drawing.Point(266, 192);
            this.dgv_und.Name = "dgv_und";
            this.dgv_und.RowTemplate.Height = 24;
            this.dgv_und.Size = new System.Drawing.Size(246, 257);
            this.dgv_und.TabIndex = 1;
            // 
            // Concentration
            // 
            this.Concentration.HeaderText = "Concentration";
            this.Concentration.Name = "Concentration";
            // 
            // undergradDegree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_und);
            this.Controls.Add(this.rtb_undgrd_t);
            this.Name = "undergradDegree";
            this.Text = "undergradDegree";
            this.Load += new System.EventHandler(this.undergradDegree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_und)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_undgrd_t;
        private System.Windows.Forms.DataGridView dgv_und;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concentration;
    }
}