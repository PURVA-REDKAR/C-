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
    public partial class Fact : Form
    {
        public Fact(String s, People people)
        {
            InitializeComponent();
            rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).name;
            rtb_fact.Text += "\n";
            rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).email;
            rtb_fact.Text += "\n";
            rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).interestArea;
            rtb_fact.Text += "\n";
            rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).phone;
            rtb_fact.Text += "\n";
            if (checknull(people.faculty.Find(x => x.name.Equals(s)).facebook)) {
                rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).facebook;
                rtb_fact.Text += "\n";
            }
            if (checknull(people.faculty.Find(x => x.name.Equals(s)).twitter))
            {
                rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).twitter;
                rtb_fact.Text += "\n";
            }
            if (checknull(people.faculty.Find(x => x.name.Equals(s)).website))
            {
                rtb_fact.Text += people.faculty.Find(x => x.name.Equals(s)).website;
                rtb_fact.Text += "\n";
            }
            ptb_fact.ImageLocation = people.faculty.Find(x => x.name.Equals(s)).imagePath;
        }

        public Boolean checknull(String s) {

            if (s.Equals(null) || s.Equals("")) {
                return false;
            }

            return true;
        }
        private void rtb_fact_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
