namespace Project3_School
{
    partial class factRea
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
            this.rtb_factr = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_factr
            // 
            this.rtb_factr.BackColor = System.Drawing.Color.DarkSalmon;
            this.rtb_factr.Location = new System.Drawing.Point(73, 55);
            this.rtb_factr.Name = "rtb_factr";
            this.rtb_factr.Size = new System.Drawing.Size(625, 310);
            this.rtb_factr.TabIndex = 0;
            this.rtb_factr.Text = "";
            this.rtb_factr.TextChanged += new System.EventHandler(this.rtb_factr_TextChanged);
            // 
            // factRea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_factr);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "factRea";
            this.Text = "factRea";
            this.Load += new System.EventHandler(this.factRea_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_factr;
    }
}