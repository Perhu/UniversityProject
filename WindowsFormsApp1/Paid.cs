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
    public partial class Paid : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -6;
        public Paid()
        {
            InitializeComponent();
            LoadDB();
            this.label1.Text = "Course";
            this.textBox1.Enabled = false;

            this.label2.Text = "ParticipantName";
            this.textBox2.Enabled = false;

            this.label3.Text = "ParticipantSurname";
            this.textBox3.Enabled = false;

            this.label4.Text = "ParticipantTown";
            this.textBox4.Enabled = false;

            this.label5.Text = "CoursePrice";
            this.textBox5.Enabled = false;

            this.label6.Text = "Sum";
            this.textBox6.Enabled = false;

            this.Text = "Querry";

            this.button1.Text = "Next";
            this.button2.Text = "Previous";

            button1_Click(new object(), new EventArgs());
        }

        private void LoadDB()
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string QuerryString = "select courseandlectors.Course, particiepant.ParticipantName," +
                "particiepant.ParticipantSurname,particiepant.ParticipantTown,courseandlectors.CoursePrice," +
                " Sum(CoursePrice) as Sum " +
                " from payment" +
                " join courseandlectors on payment.CourseID = courseandlectors.CourseID" +
                " join particiepant on payment.ParticipantID = particiepant.ParticipantID" +
                " group by particiepant.ParticipantName";


            List<string> Colums = new List<string>();
            Colums.Add("Course");
            Colums.Add("ParticipantName");
            Colums.Add("ParticipantSurname");
            Colums.Add("ParticipantTown");
            Colums.Add("CoursePrice");
            Colums.Add("Sum");
            TheQuerryData =dataBaseConnect.Select(QuerryString, Colums);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TheIndex + 6 < TheQuerryData.Count)
            {

                TheIndex += 6;
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex + 1];
                this.textBox3.Text = TheQuerryData[TheIndex + 2];
                this.textBox4.Text = TheQuerryData[TheIndex + 3];
                this.textBox5.Text = TheQuerryData[TheIndex + 4];
                this.textBox6.Text = TheQuerryData[TheIndex + 5];

            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex - 6 >= 0)
            {
                TheIndex -= 6;
                DataBaseConnect Conn = new DataBaseConnect();
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex + 1];
                this.textBox3.Text = TheQuerryData[TheIndex + 2];
                this.textBox4.Text = TheQuerryData[TheIndex + 3];
                this.textBox5.Text = TheQuerryData[TheIndex + 4];
                this.textBox6.Text = TheQuerryData[TheIndex + 5];

            }
            else MessageBox.Show("There are no previous records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
