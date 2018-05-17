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
    public partial class staffInfo : Form
    {
        public staffInfo(String s, People people)
        {
            InitializeComponent();
            richTextBox1.Text += people.staff.Find(x => x.name.Equals(s)).name;
            richTextBox1.Text += people.staff.Find(x => x.name.Equals(s)).email;
            richTextBox1.Text += people.staff.Find(x => x.name.Equals(s)).interestArea;
            richTextBox1.Text += people.staff.Find(x => x.name.Equals(s)).phone;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
