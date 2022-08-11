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
    public partial class PaidParam : Form
    {
        List<string> TheQuerryData=new List<string>();
        int TheIndex = -4;
        public PaidParam()
        {
            InitializeComponent();

            string THEINPUT = ShowDialog("Choose a class for the Querry");

            LoadDataBase(Int32.Parse(THEINPUT) + 1);

            if (TheQuerryData.Count == 0)
            {
                this.Close();
            }

            this.Text = "Querry";
            this.label1.Text = "ParticipantID";
            this.textBox1.Enabled = false;

            this.label2.Text = "ParticipantName";
            this.textBox2.Enabled = false;

            this.label3.Text = "ParticipantSurname";
            this.textBox3.Enabled = false;

            this.label4.Text = "CoursePrice";
            this.textBox4.Enabled = false;

            this.button2.Text = "Previous Record";
            this.button1.Text = "Next Record";

            if (TheQuerryData.Count != 0)button1_Click(new object(), new EventArgs());
        }

        public static string ShowDialog(string text)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            ComboBox comboBox = new ComboBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Choose", Left = 350, Width = 100, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            
            DataBaseConnect Conn=new DataBaseConnect();
            
            List<string> list = new List<string>();
            List<string> colums = new List<string>();
            string Querry = "select courseID,Course from courseandlectors";
            colums.Add("courseID");
            colums.Add("Course");
            list = Conn.Select(Querry,colums);
            for(int i= 0; i < list.Count; i = i + 2)
            {
                comboBox.Items.Add(list[i+1]);
            }
            comboBox.SelectedIndex = 0;
            

            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? comboBox.SelectedIndex.ToString() : "";



        }

        private void LoadDataBase(int IDofSubject)
        {
            DataBaseConnect Conn = new DataBaseConnect();
            List<string> Colums = new List<string>();
            Colums.Add("ParticipantID");
            Colums.Add("ParticipantName");
            Colums.Add("ParticipantSurname");
            Colums.Add("CoursePrice");
            string Querry =
                "select p.ParticipantID, p.ParticipantName, p.ParticipantSurname, C.CoursePrice " +
                " from particiepant p " +
                " join payment pay on p.ParticipantID = pay.ParticipantID " +
                " join courseandlectors c on pay.CourseID = c.CourseID where pay.courseID = "+ IDofSubject+";";
            TheQuerryData = Conn.Select(Querry, Colums);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (TheIndex + 4 < TheQuerryData.Count)
            {
                TheIndex += 4;
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex+1];
                this.textBox3.Text = TheQuerryData[TheIndex + 2];
                this.textBox4.Text = TheQuerryData[TheIndex + 3];
            }
            else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex-4>=0)
            {
                TheIndex -= 4;
                this.textBox1.Text = TheQuerryData[TheIndex];
                this.textBox2.Text = TheQuerryData[TheIndex + 1];
                this.textBox3.Text = TheQuerryData[TheIndex + 2];
                this.textBox4.Text = TheQuerryData[TheIndex + 3];
            }else MessageBox.Show("There is no previous record!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox4.Text = string.Format("{0:#,##0.00}", double.Parse(textBox4.Text));
        }
    }
}
