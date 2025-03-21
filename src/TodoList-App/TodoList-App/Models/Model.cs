﻿///ETML
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
                //if (String.IsNullOrEmpty(databaseName))
                // return false;
                string connstring = string.Format("Server='localhost'; database='setup_database'; UID='root'; password='root'", Server, DatabaseName, UserName, Password);

                try
                {
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                catch (Exception e)
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

        public bool CheckLogin(string username, string password)
        {
            string query = "SELECT * FROM t_user WHERE `username` =" + username;
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
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

        public bool AddTask(string name)
        {
            string query = "INSERT INTO `t_task` WHERE `name` =" + name;
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (name == dataReader.GetString(1))
                {
                    dataReader.Close();
                    return true;
                }
            }
            dataReader.Close();
            return false;
        }

        public bool EditTask(string newName, string previousName)
        {
            string query = "UPDATE `t_task` SET `name` =" + newName + "WHERE `name` =" + previousName;
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (newName == dataReader.GetString(1))
                {
                    dataReader.Close();
                    return true;
                }
            }
            dataReader.Close();
            return false;
        }

        public bool EraseTask(string name)
        {
            string query = "DELETE FROM `t_task` WHERE `name` =" + name;
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (name == dataReader.GetString(1))
                {
                    dataReader.Close();
                    return true;
                }
            }
            dataReader.Close();
            return false;
        }
    }
}
