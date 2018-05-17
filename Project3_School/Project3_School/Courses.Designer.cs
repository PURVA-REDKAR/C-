namespace Project3_School
{
    partial class Courses
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
            this.rtb_course = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_course
            // 
            this.rtb_course.Location = new System.Drawing.Point(76, 42);
            this.rtb_course.Name = "rtb_course";
            this.rtb_course.Size = new System.Drawing.Size(625, 366);
            this.rtb_course.TabIndex = 0;
            this.rtb_course.Text = "";
            this.rtb_course.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_course);
            this.Name = "Courses";
            this.Text = "Courses";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_course;
    }
}