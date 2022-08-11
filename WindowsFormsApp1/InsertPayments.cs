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
    public partial class InsertPayments : Form
    {
        public InsertPayments()
        {
            InitializeComponent();
            this.label1.Text = "CourseID";
            this.textBox1.Text = "1";
            this.label2.Text = "CourseName";
            
            textBox2.Enabled = false;
            this.label3.Text = "ParticipantID";
            this.textBox3.Text = "1";
            this.label4.Text = "ParticipantName";

            textBox4.Enabled = false;
            this.button1.Text = "Mark as Paid";
            this.update();
            this.Text = "Querry";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string InesrtString = "INSERT INTO payment(CourseID,ParticipantID)"
                + " VALUES("     +textBox1.Text+
                              ","+textBox3.Text+")";
            dataBaseConnect.Insert(InesrtString);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.update();
        }
        private void update()
        {
            try
            {
                DataBaseConnect Conn = new DataBaseConnect();

                string SelectQuerry = "select Course from courseandlectors where CourseID=" + textBox1.Text + ";";
                textBox2.Text = Conn.SelectSingleRow(SelectQuerry, "Course");
                
                SelectQuerry= "select ParticipantName from particiepant where ParticipantID=" + textBox3.Text + ";";
                textBox4.Text= Conn.ReturnGenderOfID(Int32.Parse(textBox3.Text))+" "+ Conn.SelectSingleRow(SelectQuerry, "ParticipantName");
                
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ex"+ex);
            }
            
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            this.update();
        }

        
    }
}
