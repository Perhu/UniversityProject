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
    public partial class DeletePayment : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -3;
        public DeletePayment()
        {
            InitializeComponent();
            DBLoad();
            this.Text = "Querry";
            this.Name = "Lector";
            this.label1.Text = "CourseID";
            this.label2.Text = "ParticipantID";
            button2_Click(new object(), new EventArgs());

            this.button3.Text = "Previous";
            this.button2.Text = "Next";
            this.button1.Text = "Delete";
        }

        private void DBLoad()
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string QuerryString = "select * from payment";
            List<string> Colums = new List<string>();
            Colums.Add("PaymentID");
            Colums.Add("CourseID");
            Colums.Add("ParticipantID");
            TheQuerryData = dataBaseConnect.Select(QuerryString, Colums);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseConnect dataBaseConnect = new DataBaseConnect();
                string DeleteString = "DELETE FROM payment WHERE PaymentID=" + TheQuerryData[TheIndex];
                dataBaseConnect.Delete(DeleteString);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("There is no Lector with that name!\n"+ex.Message, "Sorry!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex + 3 < TheQuerryData.Count())
            {
                TheIndex += 3;
                textBox1.Text = TheQuerryData[TheIndex + 1];
                textBox2.Text = TheQuerryData[TheIndex + 2];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TheIndex - 3 >= 0)
            {
                TheIndex -= 3;
                textBox1.Text = TheQuerryData[TheIndex + 1];
                textBox2.Text = TheQuerryData[TheIndex + 2];
            }
        }
    }
}
