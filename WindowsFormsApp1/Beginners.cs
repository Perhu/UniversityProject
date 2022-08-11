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
    public partial class Beginners : Form
    {
        List<string> TheQuerryData=new List<string>();
        int TheIndex = 0;
        public Beginners()
        {
            InitializeComponent();

            LoadDataBase();
            this.Text = "Querry";
            this.label2.Text = "Course Name";
            this.textBox2.Text = TheQuerryData[0];
            this.textBox2.Enabled = false;
            this.label3.Text = "Course Price";
            this.textBox3.Text = TheQuerryData[1];
            this.textBox3.Enabled = false;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
            this.textBox3.Text = string.Format("{0:#,##0.00}", double.Parse(textBox3.Text));

            this.button2.Text = "Previous Record";
            this.button1.Text = "Next Record";
        }

        private void LoadDataBase()
        {
            DataBaseConnect Conn = new DataBaseConnect();
            List<string> Colums = new List<string>();
            Colums.Add("Course");
            Colums.Add("CoursePrice");
            string Querry =
                "SELECT Co.Course, Co.CoursePrice"+
                " FROM courseandlectors Co" +
                " WHERE course LIKE '%beginners%';";
            TheQuerryData = Conn.Select(Querry, Colums);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (TheIndex + 2 < TheQuerryData.Count)
            {
                this.textBox2.Text = TheQuerryData[TheIndex + 2];
                this.textBox3.Text = TheQuerryData[TheIndex + 1];
                TheIndex += 2;
            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex-2>=0)
            {
                this.textBox2.Text = TheQuerryData[TheIndex - 2];
                this.textBox3.Text = TheQuerryData[TheIndex - 1];
                TheIndex -= 2;
            }else MessageBox.Show("There is no previous record!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = string.Format("{0:#,##0.00}", double.Parse(textBox3.Text));
        }
    }
}
