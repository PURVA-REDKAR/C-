using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_School
{
    public partial class UnderGradMin : Form
    {
        ugminors ugmin;
        cours cou;
        String name;
        public UnderGradMin(ugminors ugmin1, String name)
        {
            
            InitializeComponent();
            ugmin = ugmin1;
            rtb_title.Text = ugmin1.UgMinors.Find(x => x.name.Equals(name)).title;
            rtb_title.Text = ugmin1.UgMinors.Find(x => x.name.Equals(name)).description;

            
            for (int i = 0; i < ugmin1.UgMinors.Find(x => x.name.Equals(name)).courses.Count; i++)
            {
                dgv_courses.Rows.Add();
                dgv_courses.Rows[i].Cells[0].Value = ugmin1.UgMinors.Find(x => x.name.Equals(name)).courses[i];
               
            }

        }

        private void UnderGradMin_Load(object sender, EventArgs e)
        {

        }

        private void rtb_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_courses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex; // not going to use
            int selectedrowindex = dgv_courses.SelectedCells[0].RowIndex;
            rtb_course.Clear();
            
           rtb_course.Text+= dgv_courses.Rows[selectedrowindex].Cells[0].Value;
          //  MessageBox.Show(cou.title + "");

          






        }
    }
}
