using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestUtility;
using System.Diagnostics;

namespace Project3_School
{

    
    public partial class Form1 : Form
    {
        //global objects
        Employment employment;
        About about;
        People people;
        Resources resources;
        GraduateDegree graduat;
        Undergrad undgraduat;
        ugminors ugmin;
        cours courses;
        Research research;
        fsocial fsoc;

        //stopwatch for testing
        Stopwatch sw = new Stopwatch();


        //get our restful resources..
        REST rj = new REST("http://ist.rit.edu/api");

        //another onr we won't use
        REST rx = new REST("htpps://google.com/api");

        private string jsonAbout;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //go get the /about/info..
            string jsonAbout = rj.getRestJSON("/about/");
           about = JToken.Parse(jsonAbout).ToObject<About>();
            rtb_about_desc.Text += about.title;
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += about.description;
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += about.quote;
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += "\n";
            rtb_about_desc.Text += about.quoteAuthor;


            //go get the resources
            string jsonResources = rj.getRestJSON("/resources/");
             resources = JToken.Parse(jsonResources).ToObject<Resources>();

            linkLabel1.Text = "Click me for the pdf";        
            linkLabel1.Tag = resources.coopEnrollment.RITJobZoneGuidelink;

            linkLabel2.Text = "Click me for the application";
            linkLabel2.Tag = resources.studentAmbassadors.applicationFormLink;

            string jsonDegree = getRestData("/degrees/graduate/");

            //have to return a string jsonAbout into an object
            //ABout Object....
             graduat = JToken.Parse(jsonDegree).ToObject<GraduateDegree>();


            string jsonUDegree = getRestData("/degrees/undergraduate/");

            //have to return a string jsonAbout into an object
            //Undergrad....
            undgraduat = JToken.Parse(jsonUDegree).ToObject<Undergrad>();


            string jsonUmin = getRestData("/minors/UgMinors");

            //have to return a string jsonAbout into an object
            //Undergrad....
            ugmin = JToken.Parse(jsonUmin).ToObject<ugminors>();

            string jsonCourse = getRestData("/course/");

            //have to return a string jsonAbout into an object
            //Undergrad....
           // courses = JToken.Parse(jsonCourse).ToObject<cours>();



            string jsonEmp = getRestData("/employment/");

            //have to return a string jsonAbout into an object
            //Employee....
            employment = JToken.Parse(jsonEmp).ToObject<Employment>();



            string jsonPeople = rj.getRestJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();


            // Let's assume that we are going to get a list of acceptable tabs to show the user from a call.

            //retrived from the server

            string jsonfooter = rj.getRestJSON("/footer/");
             fsoc = JToken.Parse(jsonfooter).ToObject<fsocial>();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Which one am i
            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            //navigate to the url
            //tag is an object hence, encapsulated to ToString
            System.Diagnostics.Process.Start(me.Tag.ToString());
        }

        private void rtb_about_desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the people
           

            //play with the data
            foreach (Faculty thisFac in people.faculty)
            {
                Console.WriteLine(thisFac.name);
              
            }

            //the ability to get a single instance of faculty fro the username
            getSingleInstance("dsbics");

        }

        private void getSingleInstance(string id)
        { 
            //we are going to need a way to find a specific instance of a list of objects
            // to send the other form for dispaly

            //horrible, ugly don't do it this way
            foreach(Faculty thisFac in people.faculty)
            {
                if(thisFac.username == id)
                {
                    MessageBox.Show(thisFac.name);
                }
            }
            //better way
            Faculty result = people.faculty.Find(x=>x.username==id);
            MessageBox.Show(result.website);

            //another way
            List<Faculty> facList = people.faculty.FindAll(x=>x.title=="Associate Professor");
            Console.WriteLine(facList[2].name);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btn_datagridView_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("i");
            int col = e.ColumnIndex; // not going to use
            int row = e.RowIndex;

            string id = dataGridView1[0, row].Value.ToString();
            MessageBox.Show(id);

        }

        private void tb_datagrid_Enter(object sender, EventArgs e)
        {
          
        }



        private string getRestData(string url)
        {

            string baseUri = "http://ist.rit.edu/api";

            //connect to the api
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUri + url);

            try
            {
                WebResponse res = req.GetResponse();
                using (Stream resStream = res.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                // What to do when it all goes wrong
                WebResponse err = ex.Response;

                using (Stream resStream = err.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }

        private void tb_listview_Enter(object sender, EventArgs e)
        {
            //how long does his take?
           

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            string jsonAbout = rj.getRestJSON("/about/");
            About about = JToken.Parse(jsonAbout).ToObject<About>();
            rtb_about_desc.Text = about.description;
        }

        private void pb_fac_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void tb_deg_Enter(object sender, EventArgs e)
        {
            spinner.Visible = true;

            await Task.Run(() =>
            {
                rtb_degree1.Text = graduat.graduate.Find(x => x.degreeName.Equals("ist")).title;
                rtb_degree2.Text = graduat.graduate.Find(x => x.degreeName.Equals("hci")).title;
                rtb_degree3.Text = graduat.graduate.Find(x => x.degreeName.Equals("nsa")).title;
                rtb_degree4.Text = "graduate advanced certificates";
            });

            spinner.Visible = false;


           

        }

        private void rtb_degree1_Click(object sender, EventArgs e)
        {
            grad_click(rtb_desc, "ist");

        }

        private void rtb_degree2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_degree2_Click(object sender, EventArgs e)
        {

            grad_click(rtb_desc, "hci");

        }

        private void rtb_degree3_Click(object sender, EventArgs e)
        {
            grad_click(rtb_desc, "nsa");
        }


        public void grad_click(RichTextBox rtb, string s) {

            rtb.Visible = true;
            rtb.Clear();
            rtb.Text = graduat.graduate.Find(x => x.degreeName.Equals(s)).description;
            rtb_desc.Text += "\n";

            for (int i = 0; i < graduat.graduate.Find(x => x.degreeName.Equals(s)).concentrations.Count; i++)
            {

                rtb.Text += graduat.graduate.Find(x => x.degreeName.Equals(s)).concentrations[i];
                rtb.Text += "\n";
            }
        }

        private void rtb_degree1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void rtb_degree1_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_degree1);

        }

        private void rtb_degree1_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_degree1);

        }

        private void rtb_degree2_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_degree2);

        }

        private void rtb_degree2_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_degree2);
        }

        private void rtb_degree3_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_degree3);

        }

        private void rtb_degree3_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_degree3);

        }

        private void rtb_degree4_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_degree4_MouseClick(object sender, MouseEventArgs e)
        {
            rtb_desc.Visible = true;
            rtb_desc.Clear();
          
          

            for (int i = 0; i < graduat.graduate.Find(x => x.degreeName.Equals("graduate advanced certificates")).availableCertificates.Count; i++)
            {

                rtb_desc.Text += graduat.graduate.Find(x => x.degreeName.Equals("graduate advanced certificates")).availableCertificates[i];
                rtb_desc.Text += "\n";
            }

        }

        private void rtb_degree4_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_degree4);
        }

        private void rtb_degree4_MouseLeave(object sender, EventArgs e)
        {

            elementLeave(rtb_degree4);
        }

        private void tb_datagrid_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
       


        private void undergradClick(RichTextBox rtb, string s) {

            rtb.Clear();
            rtb.Visible = true;
            rtb.Text = undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).description;
            rtb.Text += "\n";

            for (int i = 0; i < undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).concentrations.Count; i++)
            {

                rtb.Text += undgraduat.undergraduate.Find(x => x.degreeName.Equals(s)).concentrations[i];
                rtb.Text += "\n";
            }

        }

        private void rtb_under_degree1_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under3);
        }

        private void rtb_under_degree1_MouseLeave(object sender, EventArgs e)
        {

            elementLeave(rtb_under3);

        }

        private void rtb_undergrad_degree2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_undergrad_degree2_MouseClick(object sender, MouseEventArgs e)
        {


           // undergradClick(rtb_undergrad_desc, "hcc");

        }

        private void rtb_undergrad_degree2_MouseHover(object sender, EventArgs e)
        {

          //  elementHover(rtb_undergrad_degree2);
        }

        private void rtb_undergrad_degree2_MouseLeave(object sender, EventArgs e)
        {
           // elementLeave(rtb_undergrad_degree2);

        }

        private void rtb_undergrad_degree3_MouseClick(object sender, MouseEventArgs e)
        {
         //   undergradClick(rtb_undergrad_desc, "cit");
            
        }

        private void rtb_undergrad_degree3_MouseHover(object sender, EventArgs e)
        {
          //  elementHover(rtb_undergrad_degree3);
        }

        private void rtb_undergrad_degree3_MouseLeave(object sender, EventArgs e)
        {
          //  elementLeave(rtb_undergrad_degree3);
        }

        private void elementHover(RichTextBox  rtb) {
            rtb.BackColor = Color.AliceBlue;
            rtb.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }

        private void elementLeave(RichTextBox rtb)
        {
            rtb.BackColor = Color.DarkSalmon;
            rtb.Font = new Font("Segoe UI", 8, FontStyle.Regular);
        }

        private void rtb_under1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            rtb_undg_min.Text = ugmin.UgMinors.Find(x => x.name.Equals("DBDDI-MN")).title;
            rtb_under_min2.Text = ugmin.UgMinors.Find(x => x.name.Equals("GIS-MN")).title;
           rtb_under_minor3.Text = ugmin.UgMinors.Find(x => x.name.Equals("MEDINFO-MN")).title;
          rtb_under_minor4.Text = ugmin.UgMinors.Find(x => x.name.Equals("MDDEV-MN")).title;
            rtb_undergrad_minor4.Text = ugmin.UgMinors.Find(x => x.name.Equals("MDEV-MN")).title;
            rtb_under_minor6.Text = ugmin.UgMinors.Find(x => x.name.Equals("NETSYS-MN")).title;
             rtb_under_minor7.Text = ugmin.UgMinors.Find(x => x.name.Equals("WEBDD-MN")).title;
             rtb_under_minor8.Text = ugmin.UgMinors.Find(x => x.name.Equals("WEBD-MN")).title;

        }

        private void richTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void rtb_under_degree1_MouseHover_1(object sender, EventArgs e)
        {

        }

        private void rtb_under1_Click_1(object sender, EventArgs e)
        {
            // undgraduat
            undergradDegree udg = new undergradDegree(undgraduat, "wmc");
            udg.ShowDialog();
        }

        private void tabPage2_Enter_1(object sender, EventArgs e)
        {
            rtb_under1.Text = undgraduat.undergraduate.Find(x => x.degreeName.Equals("wmc")).title;
            rtb_under2.Text = undgraduat.undergraduate.Find(x => x.degreeName.Equals("hcc")).title;
            rtb_under3.Text = undgraduat.undergraduate.Find(x => x.degreeName.Equals("cit")).title;
        }

        private void rtb_under2_Click(object sender, EventArgs e)
        {
            undergradDegree udg = new undergradDegree(undgraduat, "hcc");
            udg.ShowDialog();

        }

        private void rtb_under3_MouseClick(object sender, MouseEventArgs e)
        {
            undergradDegree udg = new undergradDegree(undgraduat, "cit");
            udg.ShowDialog();

        }

        private void rtb_under1_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under1);
        }

        private void rtb_under1_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under1);
        }

        private void rtb_under2_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under2);
        }

        private void rtb_under2_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under2);
        }

        private void rtb_under3_MouseEnter(object sender, EventArgs e)
        {
            elementHover(rtb_under3);
        }

        private void rtb_under3_MouseLeave(object sender, EventArgs e)
        {
           
            elementLeave(rtb_under3);
        }

        private void rtb_undg_min_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "DBDDI-MN");
            ug.ShowDialog();
        }

        private void rtb_undg_min_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_undg_min);
        }

        private void rtb_undg_min_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_undg_min);
        }

        private void rtb_under_min2_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_min2);
        }

        private void rtb_under_min2_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_min2);
        }

        private void rtb_under_minor3_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "MEDINFO-MN");
            ug.ShowDialog();
        }

        private void rtb_under_minor3_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_minor3);
        }

        private void rtb_under_minor3_MouseLeave(object sender, EventArgs e)
        {

            elementLeave(rtb_under_minor3);
        }

        private void rtb_under_minor4_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_minor4);
        }

        private void rtb_under_minor4_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_minor4);
        }

        private void rtb_under_minor4_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "MDEV-MN");
            ug.ShowDialog();

        }

        private void rtb_undergrad_minor4_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "NETSYS-MN");
            ug.ShowDialog();
        }

        private void rtb_undergrad_minor4_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_undergrad_minor4);
        }

        private void rtb_undergrad_minor4_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_minor4);
        }

        private void rtb_under_minor6_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_minor6);
        }

        private void rtb_under_minor6_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_minor6);
        }

        private void rtb_under_minor6_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "WEBDD-MN");
            ug.ShowDialog();
        }

        private void rtb_under_minor7_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_minor7);
        }

        private void rtb_under_minor7_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_minor7);
        }

        private void rtb_under_minor7_Click(object sender, EventArgs e)
        {

            UnderGradMin ug = new UnderGradMin(ugmin, "WEBDD-MN");
            ug.ShowDialog();
        }

        private void rtb_under_minor8_MouseClick(object sender, MouseEventArgs e)
        {

            UnderGradMin ug = new UnderGradMin(ugmin, "WEBDD-MN");
            ug.ShowDialog();
        }

        private void rtb_under_minor8_MouseHover(object sender, EventArgs e)
        {
            elementHover(rtb_under_minor8);
        }

        private void rtb_under_minor8_MouseLeave(object sender, EventArgs e)
        {
            elementLeave(rtb_under_minor8);
        }

        private void rtb_under_min2_Click(object sender, EventArgs e)
        {
            UnderGradMin ug = new UnderGradMin(ugmin, "GIS-MN");
            ug.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void rtb_emp_tit_TextChanged(object sender, EventArgs e)
        {

        }

        private  void tabPage4_Enter(object sender, EventArgs e)
        {
            spinner.Visible = true;

            

            rtb_emp_tit.Text = employment.introduction.title;
            for (int i = 0; i < employment.introduction.content.Count; i++) {

                rtb_emp_tit.Text += employment.introduction.content[i].title;
                rtb_emp_tit.Text += employment.introduction.content[i].description;
                rtb_emp_tit.Text += "\n";
            }
            rtb_1.Text = employment.degreeStatistics.statistics[0].value;
            rtb_1.Text += employment.degreeStatistics.statistics[0].description;


            rtb_2.Text = employment.degreeStatistics.statistics[1].value;
            rtb_2.Text += employment.degreeStatistics.statistics[1].description;

            rtb_3.Text = employment.degreeStatistics.statistics[2].value;
            rtb_3.Text += employment.degreeStatistics.statistics[2].description;

            rtb_4.Text = employment.degreeStatistics.statistics[3].value;
            rtb_4.Text += employment.degreeStatistics.statistics[3].description;

            rtb_emp.Text += "Employement";
            rtb_emp.Text += "\n";

            for (int i=0;i< employment.employers.employerNames.Count;i++) {

                rtb_emp.Text += employment.employers.employerNames[i];
                rtb_emp.Text += "\n";

            }
            rtb_carrer.Text += "Carrers";
            rtb_carrer.Text += "\n";

            for (int i = 0; i < employment.careers.careerNames.Count; i++)
            {

                rtb_carrer.Text += employment.careers.careerNames[i];
                rtb_carrer.Text += "\n";

            }
            

        }

        private async void bt_coop_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            dataGridView1.Visible = true;
            
                
                bt_coop.Enabled = false;
                if (listView1.Visible)
                {
                    listView1.Visible = false;
                }
                // MessageBox.Show("test");
                if (employment == null)
                {
                await Task.Run(() =>
                {
                    MessageBox.Show("employment");
                    //go get the /employment/info..
                    string jsonEmp = rj.getRestJSON("/employment/");
                    employment = JToken.Parse(jsonEmp).ToObject<Employment>();
                });
                }
                //have I build?
                if (dataGridView1.Rows.Count < 2)
                {
                    sw.Reset();
                    sw.Start();
                    //populate the dataFridView

                    for (int i = 0; i < employment.coopTable.coopInformation.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = employment.coopTable.coopInformation[i].employer;
                        dataGridView1.Rows[i].Cells[1].Value = employment.coopTable.coopInformation[i].degree;
                        dataGridView1.Rows[i].Cells[2].Value = employment.coopTable.coopInformation[i].city;
                        dataGridView1.Rows[i].Cells[3].Value = employment.coopTable.coopInformation[i].term;
                    }

                }
           
            spinner.Visible = false;
        }

        private void tb_listview_Click(object sender, EventArgs e)
        {

        }

        private void bt_emp_Click(object sender, EventArgs e)
        {
            bt_emp.Enabled = false;
            listView1.Visible = true;
            if (dataGridView1.Visible) {

                dataGridView1.Visible = false;

            }
            //dynamically create and 
            listView1.View = View.Details; // we want text
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Width = 710;

            //create the column headers...
            listView1.Columns.Add("Employers", 200);
            listView1.Columns.Add("Degree", 200);
            listView1.Columns.Add("City", 200);
            listView1.Columns.Add("Term", 100);

            //populate listview
            ListViewItem item;

            for (int j = 0; j < employment.coopTable.coopInformation.Count; j++)
            {
                item = new ListViewItem(new string[] {
                    employment.coopTable.coopInformation[j].employer,
                    employment.coopTable.coopInformation[j].degree,
                    employment.coopTable.coopInformation[j].city,
                    employment.coopTable.coopInformation[j].term
                });

                listView1.Items.Add(item);
            }

        }



        private void fact(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            Fact p = new Fact(s,people);
            p.ShowDialog();

          //  MessageBox.Show(s);



        }

        private void bt_fact_Click(object sender, EventArgs e)
        {

            tableLayoutPanel1.Controls.Clear();

            List<RichTextBox> textBoxes = new List<RichTextBox>();

           
            

            for (int i = 0; i < people.faculty.Count; i++)
            {
                if (i != 0)
                {
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                }
                int row = 0;
                
                    Button richTB = new Button();
                   // RichTextBox richTB = new RichTextBox();
                    richTB.Name = "textBox" + i+row;
                    richTB.Text = people.faculty[i].name;
                    richTB.Click += new EventHandler(this.fact);
              

                    tableLayoutPanel1.Controls.Add(richTB);
                    tableLayoutPanel1.SetColumn(richTB, i);
                    tableLayoutPanel1.SetRow(richTB, row);
                row++;


            }          
        }

        public void Staff(object sender, EventArgs e) {

            string s = (sender as Button).Text;
            staffInfo p = new staffInfo(s, people);
            p.ShowDialog();

        }

        private void bt_staff_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            List<RichTextBox> textBoxes = new List<RichTextBox>();

            for (int i = 0; i < people.staff.Count; i++)
            {

                if (i != 0)
                {
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                }
                int row = 0;
                Button richTB = new Button();
                    // RichTextBox richTB = new RichTextBox();
                    richTB.Name = "textBox" + i + row;
                    richTB.Text = people.staff[i].name;
                   richTB.Click += new EventHandler(this.Staff);

                    tableLayoutPanel1.Controls.Add(richTB);
                    tableLayoutPanel1.SetColumn(richTB, i);
                    tableLayoutPanel1.SetRow(richTB, row);

                row++; 

            }

        }


        public void byintrst(object sender, EventArgs e) {

            string s = (sender as Button).Text;
            researcharea resarea = new researcharea(research, s);
            resarea.ShowDialog();

        }

        private void tab_res_Enter(object sender, EventArgs e)
        {

            string jsonResearch = getRestData("/research/");

            research = JToken.Parse(jsonResearch).ToObject<Research>();

            tb_factReach.Controls.Clear();


            for (int i = 0; i < research.byInterestArea.Count; i++)
            {

                if (i != 0)
                {
                    tb_factReach.RowCount = tb_factReach.RowCount + 1;
                }
                int row = 0;
                Button richTB = new Button();
                // RichTextBox richTB = new RichTextBox();
                richTB.Name = "factBox" + i + row;
                richTB.Text = research.byInterestArea[i].areaName;
                 richTB.Click += new EventHandler(this.byintrst);

                tb_factReach.Controls.Add(richTB);
                tb_factReach.SetColumn(richTB, i);
                tb_factReach.SetRow(richTB, row);

                row++;

            }

        }

        private void tab_res_Click(object sender, EventArgs e)
        {

        }

        private void tb_factrese_Click(object sender, EventArgs e)
        {

        }

        public void byfactname(object sender, EventArgs e) {

            string s = (sender as PictureBox).Text;
            
            factRea p = new factRea(research,s);
            p.ShowDialog();

        }

        private void tb_factrese_Enter(object sender, EventArgs e)
        {
            string jsonResearch = getRestData("/research/");

            research = JToken.Parse(jsonResearch).ToObject<Research>();

            tbl_byfact.Controls.Clear();

            for (int i = 0; i < research.byFaculty.Count; i++)
            {

                if (i != 0)
                {
                    tbl_byfact.RowCount = tbl_byfact.RowCount + 1;
                }
                int row = 0;

               

                // RichTextBox richTB = new RichTextBox();

                  
                String s = research.byFaculty[i].facultyName;
                if (!s.Equals("Deborah Gears")) {
                    PictureBox richTB = new PictureBox();
                    richTB.Text = research.byFaculty[i].facultyName;
                    richTB.Name = "factBox1" + i + row;
                    richTB.Load(people.faculty.Find(x => x.name.Equals(s)).imagePath);
                    richTB.SizeMode = PictureBoxSizeMode.StretchImage;
                    richTB.Click += new EventHandler(this.byfactname);

                    tbl_byfact.Controls.Add(richTB);
                    tbl_byfact.SetColumn(richTB, i);
                    tbl_byfact.SetRow(richTB, row);
                    row++;
                }
                 

            }

        


    }

        private void rtb_cur1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void removeP() {


            foreach (Control item in rtb_de.Controls.OfType<Control>())
            {
                    rtb_de.Controls.Remove(item);
            }

        }

        private void rtb_cur1_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            removeP();
            
            for (int i = 0; i < resources.coopEnrollment.enrollmentInformationContent.Count; i++)
            {
                rtb_de.Text += resources.coopEnrollment.enrollmentInformationContent[i].description;
            }
        }

        public int count = 0;
        public void gradFrom(object sender, EventArgs e) {

            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            System.Diagnostics.Process.Start(me.Tag.ToString());
        }

        private void rtb_cur2_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            removeP();
            count = 0;
            for (int i = 0; i < resources.forms.graduateForms.Count; i++)
            {
                rtb_de.Text += resources.forms.graduateForms[i].formName;
                rtb_de.Text += "\n";
                count = i;
                LinkLabel richTB = new LinkLabel();
                richTB.Text += resources.forms.graduateForms[i].formName;
                richTB.Tag += "http://ist.rit.edu/" + resources.forms.graduateForms[i].href;
                richTB.Location = new Point(70+(i*40), 35+(i*10));
                richTB.Click += new EventHandler(this.gradFrom);
                rtb_de.Text += "\n";
                rtb_de.Controls.Add(richTB);



            }

        }

        public void tut(object sender, EventArgs e) {

            System.Diagnostics.Process.Start(resources.tutorsAndLabInformation.tutoringLabHoursLink);

        }

        private void rtb_cur3_Click(object sender, EventArgs e)
        {

            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            removeP();
            rtb_de.Text += resources.tutorsAndLabInformation.description;
            rtb_de.Text += "\n";
            Button richTB = new Button();
            richTB.Click += new EventHandler(this.tut);
            richTB.Location = new Point(100,100);
            richTB.Text = "click me";
            richTB.Name = "tut";
            rtb_de.Controls.Add(richTB);
           // rtb_de.Text += resources.tutorsAndLabInformation.tutoringLabHoursLink;

        }

        private void rtb_cur4_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            rtb_de.Text += "Each semester has an enrollment period in which students use the Student Information System (SIS) to choose classes to take the following semeste";
        }

        private void rtb_cur5_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            for (int i = 0; i < resources.studentServices.istMinorAdvising.minorAdvisorInformation.Count; i++) {

                rtb_de.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].title;
                rtb_de.Text += "\n";
                rtb_de.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].advisor;
                rtb_de.Text += "\n";
                rtb_de.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].email;
            }
        }

        private void rtb_cur6_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            
            rtb_de.Text += resources.studentServices.academicAdvisors.title;
            rtb_de.Text += "\n";
            rtb_de.Text += resources.studentServices.academicAdvisors.description;
            rtb_de.Text += "\n";
            rtb_de.Text += resources.studentServices.academicAdvisors.faq.title;
            rtb_de.Text += "\n";
            rtb_de.Tag += resources.studentServices.academicAdvisors.faq.contentHref;



        }

        private void rtb_cur7_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            rtb_de.Text += resources.studentAmbassadors.title;
            rtb_de.Text += resources.studentAmbassadors.applicationFormLink;
            rtb_de.Text += "\n";
            rtb_de.Text += resources.studentAmbassadors.note;
            rtb_de.Text += "\n";
            rtb_de.Text += resources.studentAmbassadors.subSectionContent;
            rtb_de.Text += "\n";



        }

        private void rtb_cur8_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            rtb_de.Text += resources.studyAbroad.title;
            rtb_de.Text += resources.studyAbroad.description;
            rtb_de.Text += resources.studyAbroad.places;
            

        }

        private void rtb_cur9_Click(object sender, EventArgs e)
        {
            rtb_de.Visible = true;
            removeP();
            rtb_de.Clear();
            rtb_de.Text += "The spring commencement ceremony typically happens during the third week of May. Every student that wants to graduate at that time must apply to graduate before April 15";

        }

        private void tb_current_Enter(object sender, EventArgs e)
        {
            rtb_cur1.Text = resources.coopEnrollment.title;
            rtb_cur2.Text = "Forms";
            rtb_cur3.Text = resources.tutorsAndLabInformation.title;
            rtb_cur4.Text = "Course Enrollment";
            rtb_cur5.Text = "Minors and Immersion";
            rtb_cur6.Text = "Student Advising service";
            rtb_cur7.Text = resources.studentAmbassadors.title;
            rtb_cur8.Text = resources.studyAbroad.title;
            rtb_cur9.Text = "Commencement";

        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            rtb_tw.Text = fsoc.social.title;
            rtb_tw.Text += "\n";
            rtb_tw.Text += fsoc.social.tweet;
            rtb_tw.Text += "\n";
            rtb_tw.Text += fsoc.social.twitter;
            rtb_tw.Text += "\n";
            rtb_tw.Text += fsoc.social.by;
            linkLabel3.Text = fsoc.quickLinks[0].title;
            linkLabel3.Tag = fsoc.quickLinks[0].href;

            linkLabel4.Text = fsoc.quickLinks[1].title;
            linkLabel4.Tag = fsoc.quickLinks[1].href;

            linkLabel5.Text = fsoc.quickLinks[2].title;
            linkLabel5.Tag = fsoc.quickLinks[2].href;
            linkLabel6.Text = "News";
            linkLabel6.Tag = fsoc.news;
            rtb_copy.Text = fsoc.copyright.title;
            rtb_copy.Text = "\n";

            rtb_copy.Text = fsoc.copyright.html;

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Which one am i
            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            //navigate to the url
            //tag is an object hence, encapsulated to ToString
            System.Diagnostics.Process.Start(me.Tag.ToString());
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Which one am i
            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            //navigate to the url
            //tag is an object hence, encapsulated to ToString
            System.Diagnostics.Process.Start(me.Tag.ToString());

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Which one am i
            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            //navigate to the url
            //tag is an object hence, encapsulated to ToString
            System.Diagnostics.Process.Start(me.Tag.ToString());
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Which one am i
            LinkLabel me = sender as LinkLabel;

            //me
            me.LinkVisited = true; //turns purple

            //navigate to the url
            //tag is an object hence, encapsulated to ToString
            System.Diagnostics.Process.Start(me.Tag.ToString());
        }

        private void rtb_sa_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_su_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_vis_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_tut_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_apply_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_sa_Click(object sender, EventArgs e)
        {
            rtb_desp.Visible = true;
            rtb_desp.Clear();
            rtb_desp.Text = resources.studyAbroad.title;
            rtb_desp.Text += "\n";
            rtb_desp.Text += resources.studyAbroad.description;
            rtb_desp.Text += resources.tutorsAndLabInformation.title;
        }

        private void rtb_su_Click(object sender, EventArgs e)
        {
            rtb_desp.Visible = true;
            rtb_desp.Clear();
            rtb_desp.Text += "How to Succeed in IST? ";
            rtb_desp.Text += "Like most other university departments, students need to meet certain basic requirements to do well in IST:";
            rtb_desp.Text += "The majority of IST students bring their own computer with them to RIT.";
        }

        private void rtb_vis_Click(object sender, EventArgs e)
        {
            rtb_desp.Visible = true;
            rtb_desp.Clear();
            rtb_desp.Text += "We are happy to accommodate you and your family, should you wish to visit our department. To make the most of your visit, we please ask that you first call ahead to the RIT Admissions Office  ";
            rtb_desp.Text += "This will allow us to coordinate with the admissions office and prepare for your arrival. You can find more info about visiting RIT online.";
        }

        private void richTextBox4_Click(object sender, EventArgs e)
        {
            rtb_desp.Text += "All course credit, whether it is from another college, AP, IB, or otherwise, must be submitted to the RIT Office of Admissions. More information about transferring credit can be found online.";
        }

        private void rtb_tut_Click(object sender, EventArgs e)
        {
            rtb_desp.Visible = true;
            rtb_desp.Clear();
            rtb_desp.Text = "\n";
            rtb_desp.Text = resources.tutorsAndLabInformation.description;
            rtb_desp.Text = "\n";
            rtb_desp.Text = resources.tutorsAndLabInformation.tutoringLabHoursLink;

        }

        private void rtb_apply_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            rtb_sa.Text = resources.studyAbroad.title;
           
            rtb_tut.Text = resources.tutorsAndLabInformation.title;
           
            rtb_vis.Text = "Visit us";
            rtb_su.Text = "Student Success";
            richTextBox4.Text = "Transfer Course Credit";
          

            
        }

        private void tb_deg_Click(object sender, EventArgs e)
        {

        }
    }
   
}

