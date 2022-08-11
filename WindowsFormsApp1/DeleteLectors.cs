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
    public partial class DeleteLectors : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -3;
        public DeleteLectors()
        {
            InitializeComponent();
            DBLoad();
            this.Text = "Querry";
            this.Name = "Lector";
            this.label1.Text = "Lector First Name";
            this.label2.Text = "Lector Last name";
            button2_Click(new object(), new EventArgs());

            this.button3.Text = "Previous";
            this.button2.Text = "Next";
            this.button1.Text = "Delete";
        }

        private void DBLoad()
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string QuerryString = "select * from lectors";
            List<string> Colums = new List<string>();
            Colums.Add("LectorID");
            Colums.Add("LectorFirstName");
            Colums.Add("LectorLastName");
            TheQuerryData = dataBaseConnect.Select(QuerryString, Colums);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseConnect dataBaseConnect = new DataBaseConnect();
                string DeleteString = "DELETE FROM lectors WHERE LectorID=" + TheQuerryData[TheIndex];
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
