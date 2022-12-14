using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LessThen500 : Form
    {
        List<string> TheQuerryData=new List<string>();
        int TheIndex = 0;

        public LessThen500()
        {
            InitializeComponent();
            this.Text = "Querry";
            DataBaseConnect Conn = new DataBaseConnect();
            List<string> Colums = new List<string>();
            Colums.Add("CourseID");
            Colums.Add("Course");
            Colums.Add("LectorFirstName");
            Colums.Add("LectorLastName");
            Colums.Add("CoursePrice");
            string Querry =
                "SELECT Co.CourseID, Co.Course, Le.LectorFirstName,Le.LectorLastName, Co.CoursePrice" +
                " FROM courseandlectors Co left join lectors Le ON Co.LectorID = Le.LectorID" +
                " WHERE Co.CoursePrice < 500;";
            TheQuerryData = Conn.Select(Querry, Colums);


            this.label1.Text = "Course id";
            this.textBox1.Text = TheQuerryData[0];
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox1.Enabled = false;

            this.label2.Text = "Course Name";
            this.textBox2.Text = TheQuerryData[1];
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            this.textBox2.Enabled = false;

            this.label3.Text = "Course Price";
            this.textBox3.Text = TheQuerryData[4];
            this.textBox3.TextAlign = HorizontalAlignment.Center;
            this.textBox3.Enabled = false;

            this.label4.Text = "Lector";
            this.textBox4.Text = TheQuerryData[2] + " "+ TheQuerryData[3];
            this.textBox4.TextAlign = HorizontalAlignment.Center;
            this.textBox4.Enabled = false;

            this.button2.Text = "Previous Record";
            this.button1.Text = "Next Record";


            //



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheIndex + 5 < TheQuerryData.Count)
            {
                TheIndex += 5;
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex+1];
                this.textBox4.Text = TheQuerryData[TheIndex+2] + " " + TheQuerryData[TheIndex+3];
                this.textBox3.Text = TheQuerryData[TheIndex+4];
                

            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex - 5 >= 0)
            {
                TheIndex -= 5;
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex+1];
                this.textBox4.Text = TheQuerryData[TheIndex + 2] + " " + TheQuerryData[TheIndex + 3];
                this.textBox3.Text = TheQuerryData[TheIndex + 4];
                
            }
            else MessageBox.Show("There are no previous records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = string.Format("{0:#,##0.00}", double.Parse(textBox3.Text));
        }
    }
}
