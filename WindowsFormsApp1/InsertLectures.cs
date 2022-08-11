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
    public partial class InsertLectures : Form
    {
        public InsertLectures()
        {
            InitializeComponent();
            this.label1.Text = "Course";
            this.textBox1.Text = "Matematika";
            this.label2.Text = "LectorID";
            this.textBox2.Text = "2";
            this.label3.Text = "CoursePrice";
            this.textBox3.Text = "375";
            this.button1.Text = "Insert";
            this.Text = "Querry";
            this.label4.Text = "Lector";
            this.textBox4.Enabled = false;
            checkBox1.Text = "For Beginners";
            checkBox1.Checked = false;
            SelfUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            if (checkBox1.Checked) textBox1.Text += " for beginners";
            string InesrtString = "INSERT INTO CourseAndLectors (Course,LectorID, CoursePrice)"
                + " VALUES('"     +textBox1.Text+
                              "',"+textBox2.Text+
                               ","+textBox3.Text+")";
            dataBaseConnect.Insert(InesrtString);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            SelfUpdate();
        }
        private void SelfUpdate()
        {
            textBox4.Text = "";
            DataBaseConnect Conn = new DataBaseConnect();
            string SelectQuerry = "select LectorFirstName from lectors where LectorID = " + textBox2.Text + ";";
            textBox4.Text = Conn.SelectSingleRow(SelectQuerry, "LectorFirstName");
            SelectQuerry = "select LectorLastName from lectors where LectorID = " + textBox2.Text + ";";
            textBox4.Text +=" "+ Conn.SelectSingleRow(SelectQuerry, "LectorLastName");
        }
    }
}
