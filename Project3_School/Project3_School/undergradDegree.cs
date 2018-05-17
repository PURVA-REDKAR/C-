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
    public partial class undergradDegree : Form
    {
        public undergradDegree(Undergrad undgraduat,String s)
        {
            InitializeComponent();
            rtb_undgrd_t.Text += undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).title;
            rtb_undgrd_t.Text += "\n";
            rtb_undgrd_t.Text += undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).description;


            for (int i = 0; i < undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).concentrations.Count; i++)
            {
                dgv_und.Rows.Add();
                dgv_und.Rows[i].Cells[0].Value = undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).concentrations[i];

            }

        }

        private void undergradDegree_Load(object sender, EventArgs e)
        {

        }
    }
}
