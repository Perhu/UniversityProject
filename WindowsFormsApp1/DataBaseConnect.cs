using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class DataBaseConnect
    {
        private string ServerName, DataBaseName, UserName, Password;
        private MySqlConnection connection;

        public DataBaseConnect()
        {
            ServerName = "localhost";
            DataBaseName = "task100";
            UserName = "root";
            Password = "150699";
            connection = this.ConnectionString();
        }

       
        public MySqlConnection ConnectionString()
        {
            string connectionString;
            connectionString = "SERVER=" + ServerName + ";" + "DATABASE=" +
            DataBaseName + ";" + "UID=" + UserName + ";" + "PASSWORD=" + Password + ";";
            return new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password!");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(string InsertQuerry)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(InsertQuerry, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("InsertSuccesful", "Good Job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CloseConnection();
            }
        }

        public string ReturnGenderOfID(int ID)
        {
            string sql = "select Gender from particiepant where ParticipantID =" + ID + ";";
            
            if((this.SelectSingleRow(sql, "Gender")=="1")){
                return "Miss";
            }else return "Mister";

        }

        public string SelectSingleRow(string Querry,string ResultColum)
        {

            string Result="";

            //Open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Querry, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Result = dataReader[ResultColum] +"";

                }
                dataReader.Close();
                this.CloseConnection();
                return Result;
            }
            else
            {
                return Result;
            }
        }

        public List<string> Select(string Querry,List<string> Colums)
        {
            List<string> Resultlist = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Querry, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    for(int i = 0; i < Colums.Count; i++)
                    {
                        Resultlist.Add(dataReader[Colums[i]].ToString());
                    }
                }
                dataReader.Close();
                this.CloseConnection();
                return Resultlist;
            }
            else
            {
                return Resultlist;
            }
        }

        public void Delete(string Querry)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Querry, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("DeleteSuccesful", "Good Job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CloseConnection();
            }
        }



    }
}
