namespace Project3_School
{
    partial class Fact
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rtb_fact = new System.Windows.Forms.RichTextBox();
            this.ptb_fact = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_fact)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rtb_fact
            // 
            this.rtb_fact.BackColor = System.Drawing.Color.DarkSalmon;
            this.rtb_fact.Location = new System.Drawing.Point(55, 41);
            this.rtb_fact.Name = "rtb_fact";
            this.rtb_fact.Size = new System.Drawing.Size(689, 383);
            this.rtb_fact.TabIndex = 0;
            this.rtb_fact.Text = "";
            this.rtb_fact.TextChanged += new System.EventHandler(this.rtb_fact_TextChanged);
            // 
            // ptb_fact
            // 
            this.ptb_fact.Location = new System.Drawing.Point(584, 269);
            this.ptb_fact.Name = "ptb_fact";
            this.ptb_fact.Size = new System.Drawing.Size(126, 133);
            this.ptb_fact.TabIndex = 1;
            this.ptb_fact.TabStop = false;
            // 
            // Fact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ptb_fact);
            this.Controls.Add(this.rtb_fact);
            this.Name = "Fact";
            this.Text = "Fact";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_fact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox rtb_fact;
        private System.Windows.Forms.PictureBox ptb_fact;
    }
}