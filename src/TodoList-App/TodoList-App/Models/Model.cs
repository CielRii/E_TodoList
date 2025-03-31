///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 31.03.25
///Description : this page helps for the management of the data include in the app.
///              It also helps for the connexion between the app and the database.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TodoList_App
{
    public class Model
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static Model _instance = null;

        private MySqlCommand cmd;
        private MySqlDataReader dataReader;
        public int userID;

        public static Model Instance()
        {
            if (_instance == null)
                _instance = new Model();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                string connstring = "server='localhost'; port='6033'; database='setup_database'; UID='root'; password='root'";

                try
                {
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }

            }
            // if (String.IsNullOrEmpty(databaseName))
            // return false;
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }

        public bool CheckLogin(string username, string password)
        {
            if (!IsConnect()) return false;

            string query = "SELECT * FROM t_user WHERE `username` = @username;"; //Secure request
            cmd = new MySqlCommand(query, Connection); //Send the request to the database
            cmd.Parameters.AddWithValue("@username", username); //Bind the parameters
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                //Retrieve actual user id
                userID = dataReader.GetInt32(0);

                if (dataReader.GetString(1) == username)
                {
                    if (dataReader.GetString(2) == password)
                    {
                        dataReader.Close();
                        return true;
                    }
                }
            }

            dataReader.Close();
            return false;
        }

        public int RetrieveUserID()
        {
            return userID;
        }

        public bool CheckUserAvaible (string username)
        {
            if (!IsConnect()) return false;

            int i = 0;
            string query = "SELECT username FROM t_user;";
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetString(i) == username)
                {
                    dataReader.Close();
                    return false;
                }
                i++;
            }

            dataReader.Close();
            return true;
        }

        public bool CreateUser(string username, string password)
        {
            if (!IsConnect()) return false;

            string query = "INSERT INTO `t_user`(user_id, username, password) VALUES(NULL, @username, @password);";

            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        public List<string> DisplayTasks(int userID, bool done)
        {
            List<string> tasks = new List<string>();
            int i = 0;
            if (!IsConnect()) return null;

            string query = "SELECT name FROM `t_task` t INNER JOIN `t_user` u ON t.user_id = u.user_id " +
               "WHERE u.user_id = @userID && t.done = @done ;";

            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@done", done);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                tasks.Add(dataReader.GetString(i));
                i++;
            }
            dataReader.Close();
            return tasks;
        }

        public bool AddTask(string name)
        {
            if (!IsConnect()) return false;

            string query = "INSERT INTO `t_task`(task_id, name, user_id, user_id_1, user_id_2, user_id_3, user_id_4)" +
                "VALUES (NULL, @name, @userID, @userID, @userID, @userID, @userID);";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool EditTask(string newName, string previousName)
        {
            if (!IsConnect()) return false;

            string query = "UPDATE `t_task` SET `name` = @newName WHERE `name` = @previousName;";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@previousName", previousName);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool EraseTask(string name)
        {
            if (!IsConnect()) return false;

            string query = "DELETE FROM `t_task` WHERE `name` = @name;";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
