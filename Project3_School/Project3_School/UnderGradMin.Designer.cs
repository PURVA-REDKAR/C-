namespace Project3_School
{
    partial class UnderGradMin
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
            this.rtb_title = new System.Windows.Forms.RichTextBox();
            this.dgv_courses = new System.Windows.Forms.DataGridView();
            this.Courses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_course = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_courses)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_title
            // 
            this.rtb_title.BackColor = System.Drawing.Color.DarkSalmon;
            this.rtb_title.Location = new System.Drawing.Point(67, 25);
            this.rtb_title.Name = "rtb_title";
            this.rtb_title.Size = new System.Drawing.Size(682, 193);
            this.rtb_title.TabIndex = 0;
            this.rtb_title.Text = "";
            this.rtb_title.TextChanged += new System.EventHandler(this.rtb_title_TextChanged);
            // 
            // dgv_courses
            // 
            this.dgv_courses.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.dgv_courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_courses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Courses});
            this.dgv_courses.Location = new System.Drawing.Point(57, 224);
            this.dgv_courses.Name = "dgv_courses";
            this.dgv_courses.RowTemplate.Height = 24;
            this.dgv_courses.Size = new System.Drawing.Size(248, 214);
            this.dgv_courses.TabIndex = 1;
            this.dgv_courses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_courses_CellContentClick);
            // 
            // Courses
            // 
            this.Courses.HeaderText = "Courses";
            this.Courses.Name = "Courses";
            // 
            // rtb_course
            // 
            this.rtb_course.Location = new System.Drawing.Point(409, 225);
            this.rtb_course.Name = "rtb_course";
            this.rtb_course.Size = new System.Drawing.Size(214, 190);
            this.rtb_course.TabIndex = 2;
            this.rtb_course.Text = "";
            // 
            // UnderGradMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_course);
            this.Controls.Add(this.dgv_courses);
            this.Controls.Add(this.rtb_title);
            this.Name = "UnderGradMin";
            this.Text = "UnderGradMin";
            this.Load += new System.EventHandler(this.UnderGradMin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_courses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_title;
        private System.Windows.Forms.DataGridView dgv_courses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Courses;
        private System.Windows.Forms.RichTextBox rtb_course;
    }
}