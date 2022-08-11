using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StartUp : Form
    {
        List<string> TheQuerryData = new List<string>();
        int TheIndex = -10;
        public StartUp()
        {
            InitializeComponent();

            this.Text = "Starting Screen";
            LoadWholeDataBase();
            label21.Text = "Records of all the Courses and the Students signed in them.";
            button1_Click(new object(), new EventArgs());
            this.button1.Text = "Next Record";
            this.button2.Text = "Previous Record";

        }

        private void LoadWholeDataBase()
        {
            DataBaseConnect Conn = new DataBaseConnect();
            List<string> Colums = new List<string>();
            Colums.Add("CourseID");
            Colums.Add("Course");
            Colums.Add("LectorID");
            Colums.Add("LectorFirstName");
            Colums.Add("LectorLastName");
            Colums.Add("CoursePrice");
            Colums.Add("PaymentID");
            Colums.Add("ParticipantID");
            Colums.Add("ParticipantName");
            Colums.Add("ParticipantSurname");
            string Querry =
                "SELECT Co.CourseID, Co.Course, Co.LectorID, Le.LectorFirstName,Le.LectorLastName," +
                " Co.CoursePrice,Pa.PaymentID, Pa.ParticipantID," +
                " Par.ParticipantName, Par.ParticipantSurname " +
                " FROM courseandlectors Co left" +
                " join lectors Le ON Co.LectorID = Le.LectorID left " +
                " join payment Pa on Co.CourseID = Pa.CourseID left " +
                " join particiepant Par on Pa.ParticipantID = Par.ParticipantID";
            TheQuerryData = Conn.Select(Querry, Colums);

            label11.Text = Colums[0];
            label12.Text = Colums[1];
            label13.Text = Colums[2];
            label14.Text = Colums[3];
            label15.Text = Colums[4];
            label16.Text = Colums[5];
            label17.Text = Colums[6];
            label18.Text = Colums[7];
            label19.Text = Colums[8];
            label20.Text = Colums[9];

        }

        private void begginersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var BegginersForm = new Beginners();
            BegginersForm.Show();
        }


        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var InsertForm = new InsertLectures();
            InsertForm.Show();
        }

        private void lectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var InsertForm = new InsertLectors();
            InsertForm.Show();
        }

        private void participantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var InsertForm = new InsertParticipant();
            InsertForm.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
            var InsertForm = new InsertPayments();
            InsertForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }
        private void cheaperThen500ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var QuerryForm = new LessThen500();
            QuerryForm.Show();
        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var DelLectures = new DeleteLectures();
                DelLectures.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void participantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var DelParti = new DeleteParticipant();
                DelParti.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var DelPay = new DeletePayment();
                DelPay.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void lectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var DelLector = new DeleteLectors();
                DelLector.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheIndex + 10 < TheQuerryData.Count())
            {
                TheIndex += 10;
                label1.Text = TheQuerryData[TheIndex];
                label2.Text = TheQuerryData[TheIndex + 1];
                label3.Text = TheQuerryData[TheIndex + 2];
                label4.Text = TheQuerryData[TheIndex + 3];
                label5.Text = TheQuerryData[TheIndex + 4];
                label6.Text = TheQuerryData[TheIndex + 5];
                label7.Text = TheQuerryData[TheIndex + 6];
                label8.Text = TheQuerryData[TheIndex + 7];
                DataBaseConnect Conn = new DataBaseConnect();
                if (TheQuerryData[TheIndex + 8].Length>2)
                    label9.Text =
                        Conn.ReturnGenderOfID(Int32.Parse(TheQuerryData[TheIndex + 7]))
                        + " " + TheQuerryData[TheIndex + 8];
                else label9.Text = TheQuerryData[TheIndex + 8];
                label10.Text = TheQuerryData[TheIndex + 9];
            }else MessageBox.Show("There are no more records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TheIndex - 10 >= 0)
            {
                TheIndex -= 10;
                label1.Text = TheQuerryData[TheIndex];
                label2.Text = TheQuerryData[TheIndex + 1];
                label3.Text = TheQuerryData[TheIndex + 2];
                label4.Text = TheQuerryData[TheIndex + 3];
                label5.Text = TheQuerryData[TheIndex + 4];
                label6.Text = TheQuerryData[TheIndex + 5];
                label7.Text = TheQuerryData[TheIndex + 6];
                label8.Text = TheQuerryData[TheIndex + 7];
                DataBaseConnect Conn = new DataBaseConnect();
                if (TheQuerryData[TheIndex + 8].Length > 2)
                    label9.Text =
                        Conn.ReturnGenderOfID(Int32.Parse(TheQuerryData[TheIndex + 7]))
                        + " " + TheQuerryData[TheIndex + 8];
                else label9.Text = TheQuerryData[TheIndex + 8];
                label10.Text = TheQuerryData[TheIndex + 9];
            }
            else MessageBox.Show("There are no previous records!", "Hold on!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sortedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Sort = new Sorted();
            Sort.Show();
        }

        private void payedForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var Paid = new PaidParam();
                Paid.Show();
            }catch (Exception ex)
            {
                MessageBox.Show("There are no Participants who have paid for this Course", ex.Message);
            }
        }

        private void taxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var tax = new Tax();
                tax.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void unpaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var unpaid = new UnPaid();
                unpaid.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void townToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var town = new Town();
                town.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }
        }

        private void paidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var paid = new Paid();
                paid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sorry!");
            }

        }

        private void fullExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = "FullExport.txt"; //WindowsFormsApp1\WindowsFormsApp1\bin\Debug
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Exporting the contents of the DataBase:");
                for (int i = 0;i< TheQuerryData.Count; i = i + 10)
                 {
                    
                    writer.WriteLine("CourseID:\t\t " + TheQuerryData[i]);
                    writer.WriteLine("Course:\t\t " + TheQuerryData[i+1]);
                    writer.WriteLine("LectorID:\t\t " + TheQuerryData[i+2]);
                    writer.WriteLine("LectorFirstName:\t " + TheQuerryData[i+3]);
                    writer.WriteLine("LectorLastName:\t " + TheQuerryData[i+4]);
                    writer.WriteLine("CoursePrice:\t " + TheQuerryData[i+5]);
                    writer.WriteLine("PaymentID:\t\t " + TheQuerryData[i+6]);
                    writer.WriteLine("ParticipantID:\t " + TheQuerryData[i+7]);
                    writer.WriteLine("ParticipantName:\t " + TheQuerryData[i+8]);
                    writer.WriteLine("ParticipantSurname:" + TheQuerryData[i+9]);
                    
                }
            }
            Process.Start(path);


        }
    }
}
