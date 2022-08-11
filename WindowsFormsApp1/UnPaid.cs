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
    public partial class UnPaid : Form
    {
        List<string> TheQuerryData=new List<string>();
        int TheIndex = -1;

        public UnPaid()
        {
            InitializeComponent();
            this.Text = "Querry";
            DataBaseConnect Conn = new DataBaseConnect();
            List<string> Colums = new List<string>();
            Colums.Add("Unpaid");
            string Querry =
                " select c.Course as Unpaid" +
                " from courseandlectors c" +
                " LEFT OUTER JOIN payment p on p.CourseID = c.CourseID" +
                " WHERE p.PaymentID IS NULL";
            TheQuerryData = Conn.Select(Querry, Colums);


            this.label1.Text = "Course without payment";
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox1.Enabled = false;

            button1_Click(new object(), new EventArgs());

            this.button1.Text = "Next";
            this.button2.Text = "Previous";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheIndex + 1 < TheQuerryData.Count)
            {
                TheIndex += 1;
                this.textBox1.Text = TheQuerryData[TheIndex];
            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex - 1 >= 0)
            {
                TheIndex -= 1;
                this.textBox1.Text = TheQuerryData[TheIndex];
                
            }
            else MessageBox.Show("There are no previous records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
