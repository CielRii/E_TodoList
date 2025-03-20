///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 31.03.25
///Description : this page helps for the connexion between the app and the database.

using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace TodoList_App
{
    public class Database
    {
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static Database _instance = null;
        public static Database Instance()
        {
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                //if (String.IsNullOrEmpty(databaseName))
                   // return false;
                string connstring = string.Format("Server='localhost'; database='setup_database'; UID='root'; password='root'", Server, DatabaseName, UserName, Password);

                try
                {
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                } catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }

            }

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }

        public bool verifyAccount(string login, string password)
        {
            string query = "SELECT * FROM t_user WHERE `username` =" + login;

            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql = "Select * from Student";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            Console.WriteLine("Data from the Database..");
            while (dataReader.Read())
            {
                Console.WriteLine(dataReader.GetValue(0) + " || " + dataReader.GetValue(1));
            }
            dataReader.close();

            return true;
        }

        public bool addTask(string content)
        {
            return true;
        }

        public bool modifyTask(string content)
        {
            return true;
        }

        public bool deleteTask(string content)
        {
            return true;
        }
    }
}


