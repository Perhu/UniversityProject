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
    public partial class InsertLectors : Form
    {
        public InsertLectors()
        {
            InitializeComponent();
            this.Text = "Querry";
            this.Name = "Lector";
            this.label1.Text = "Lector First Name";
            this.textBox1.Text = "Jhon";
            this.label2.Text = "Lector Last name";
            this.textBox2.Text = "Smith";
            this.button1.Text = "Insert";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string InesrtString = "INSERT INTO lectors (LectorFirstName,LectorLastName)"
                + " VALUES('"     +textBox1.Text+
                              "','"+textBox2.Text+"')";
            dataBaseConnect.Insert(InesrtString);
        }
    }
}
