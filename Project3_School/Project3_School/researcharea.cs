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
    public partial class researcharea : Form
    {
        public researcharea(Research research,String s)
        {
            InitializeComponent();
            for (int i = 0; i < research.byInterestArea.Find(x => x.areaName.Equals(s)).citations.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = research.byInterestArea.Find(x => x.areaName.Equals(s)).citations[i];
            }


            }

        private void researcharea_Load(object sender, EventArgs e)
        {

        }
    }
}
