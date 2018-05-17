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
    public partial class Peep : Form
    {
        public Peep(Faculty fac)
        {
            InitializeComponent();
        }

        public Peep(Staff staff)
        {
            InitializeComponent();
        }
    }
}
