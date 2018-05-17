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
    public partial class factRea : Form
    {
        public factRea(Research r, String s)
        {
            InitializeComponent();

            for (int i=0;i< r.byFaculty.Find(x => x.facultyName.Equals(s)).citations.Count;i++)
            {
                rtb_factr.Text  += r.byFaculty.Find(x => x.facultyName.Equals(s)).citations[i];
                rtb_factr.Text += "\n";
            }
        }

        private void factRea_Load(object sender, EventArgs e)
        {

        }

        private void rtb_factr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
