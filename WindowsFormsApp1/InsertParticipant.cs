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
    public partial class InsertParticipant : Form
    {
        public InsertParticipant()
        {
            InitializeComponent();
            this.label1.Text = "Participant Name";
            this.textBox1.Text = "Jhonny";
            this.label2.Text = "Participant Last Name";
            this.textBox2.Text = "Dope";
            this.label3.Text = "Participant Town";
            this.textBox3.Text = "Varna";
            this.label4.Text = "Participant Gender";
            this.comboBox1.Items.Add("Male");
            this.comboBox1.Items.Add("Female");
            this.comboBox1.SelectedIndex = 0;
            this.Text = "Querry";
            this.button1.Text = "Insert";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            string InesrtString = "INSERT INTO particiepant(ParticipantName,ParticipantSurname,ParticipantTown,Gender)"
                + " VALUES('"     +textBox1.Text+
                              "','"+textBox2.Text+"'"+
                               ",'"+textBox3.Text+"'"+
                               ","+ comboBox1.SelectedIndex+")";
            dataBaseConnect.Insert(InesrtString);
        }
    }
}
