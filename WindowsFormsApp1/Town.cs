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
    public partial class Town : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -4;
        public Town()
        {
            InitializeComponent();
            LoadDB();
            this.label1.Text = "Participant Name";
            this.textBox1.Enabled = false;
            

            this.label2.Text = "Participant Town";
            this.textBox2.Enabled = false;

            this.Text = "Querry";
            this.button1.Text = "Next";
            this.button2.Text = "Previous";

            button1_Click(new object(), new EventArgs());
        }

        private void LoadDB()
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string QuerryString = "select ParticipantName, ParticipantSurname, ParticipantTown, ParticipantID " +
                " from particiepant" +
                " order by ParticipantTown";

            List<string> Colums = new List<string>();
            Colums.Add("ParticipantName");
            Colums.Add("ParticipantSurname");
            Colums.Add("ParticipantTown");
            Colums.Add("ParticipantID");
            TheQuerryData =dataBaseConnect.Select(QuerryString, Colums);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TheIndex + 4 < TheQuerryData.Count)
            {

                TheIndex += 4;
                DataBaseConnect Conn = new DataBaseConnect();
                this.textBox1.Text = Conn.ReturnGenderOfID(Int32.Parse(TheQuerryData[TheIndex + 3])) + " " +
                TheQuerryData[TheIndex] + " " + TheQuerryData[TheIndex + 1];
                this.textBox2.Text = TheQuerryData[TheIndex+2];
            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex - 4 >= 0)
            {
                TheIndex -= 4;
                DataBaseConnect Conn = new DataBaseConnect();
                this.textBox1.Text = Conn.ReturnGenderOfID(Int32.Parse(TheQuerryData[TheIndex + 3])) + " "+
                TheQuerryData[TheIndex]+" " + TheQuerryData[TheIndex + 1];
                this.textBox2.Text = TheQuerryData[TheIndex + 2];

            }
            else MessageBox.Show("There are no previous records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
