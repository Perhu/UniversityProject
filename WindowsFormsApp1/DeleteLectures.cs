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
    public partial class DeleteLectures : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -4;
        public DeleteLectures()
        {
            InitializeComponent();
            DBLoad();
            this.Text = "Querry";
            this.Name = "Lectures";
            this.label1.Text = "Course";
            this.label2.Text = "LectorID";
            this.label3.Text = "CoursePrice";
            this.textBox1.Enabled=false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;

            button2_Click(new object(), new EventArgs());

            this.button3.Text = "Previous";
            this.button2.Text = "Next";
            this.button1.Text = "Delete";
        }

        private void DBLoad()
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string QuerryString = "select * from courseandlectors";
            List<string> Colums = new List<string>();
            Colums.Add("CourseID");
            Colums.Add("Course");
            Colums.Add("LectorID");
            Colums.Add("CoursePrice");
            TheQuerryData = dataBaseConnect.Select(QuerryString, Colums);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseConnect dataBaseConnect = new DataBaseConnect();
                string DeleteString = "DELETE FROM courseandlectors WHERE CourseID=" + TheQuerryData[TheIndex];
                dataBaseConnect.Delete(DeleteString);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("There is no Lector with that name!\n"+ex.Message, "Sorry!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex + 4 < TheQuerryData.Count())
            {
                TheIndex += 4;
                textBox1.Text = TheQuerryData[TheIndex + 1];
                textBox2.Text = TheQuerryData[TheIndex + 2];
                textBox3.Text = TheQuerryData[TheIndex + 3];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TheIndex - 4 >= 0)
            {
                TheIndex -= 4;
                textBox1.Text = TheQuerryData[TheIndex + 1];
                textBox2.Text = TheQuerryData[TheIndex + 2];
                textBox3.Text = TheQuerryData[TheIndex + 3];
            }
        }
    }
}
