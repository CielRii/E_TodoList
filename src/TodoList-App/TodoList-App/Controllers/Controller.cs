///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 02.04.25
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TodoList_App
{
    public class Controller
    {
        //
        private Model _model;
        private HomePage _home;

        // To save new user username after checking avaibility
        private string username;
        private const int numberOfItterations = 20000;
        private List<string> tasks;
        private const bool done = false;
        private byte[] salt;

        // Reference to all the app page excluding 
        public UserCreationPage UserCreationPage { get; set; }
        public TasksTodoPage TasksTodoPage { get; set; }
        public AddTaskPage AddTaskPage { get; set; }
        public TasksDonePage TasksDonePage { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="home"></param>
        public Controller(Model model, HomePage home)
        {
            _model = model;
            _home = home;

            _model.Controller = this;
            _home.Controller = this;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShareAppID()
        {
            UserCreationPage.Text = _home.Text;
            TasksTodoPage.Text = _home.Text;
            AddTaskPage.Text = _home.Text;
            TasksDonePage.Text = _home.Text;

            UserCreationPage.Icon = _home.Icon;
            TasksTodoPage.Icon = _home.Icon;
            AddTaskPage.Icon = _home.Icon;
            TasksDonePage.Icon = _home.Icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formName"></param>
        public void Redirection(string formName)
        {
            switch (formName)
            {
                case "UserCreationPage":
                    UserCreationPage.Show();
                    break;
                case "TasksTodoPage":
                    ShowTasksToDisplay(false);
                    TasksTodoPage.Show();
                    break;
                case "AddTaskPage":
                    AddTaskPage.Show();
                    break;
                case "TasksDonePage":
                    ShowTasksToDisplay(true);
                    TasksDonePage.Show();
                    break;
            }
        }
        
        public void ShowTasksToDisplay(bool done)
        {
            tasks = DisplayTasks(done);
            if (!done)
                TasksTodoPage.DisplayTasks(tasks);
            else
                TasksDonePage.DisplayTasks(tasks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CheckLogin (string username, string password)
        {
            if (username != string.Empty && password != string.Empty)
            {
                if (_model.CheckLogin (username, HashPassword(username, password, false)))
                {
                    Redirection("TasksTodoPage");
                }
                else
                {
                    MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
                }
            }
            else
            {
                MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckUserAvaible (string username)
        {
            if (_model.CheckUserAvaible(username)) //
            { this.username = username; return true; }
            else
            { return false; }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        public void CheckPassword (string password, string confirmPassword)
        {
            Regex upperCase = new Regex("([A-Z])");
            Regex lowerCase = new Regex("([a-z])");
            Regex digit = new Regex("([0-9])");
            Regex specials = new Regex("([-/#~%*])");

            if (password.Length >= 8 && upperCase.Matches(password).Count >= 1 && lowerCase.Matches(password).Count >= 1 &&
                digit.Matches(password).Count >= 1 && specials.Matches(password).Count >= 1) // Controls the password is enough secure
            {
                if (password == confirmPassword)
                { _model.CreateUser(username, HashPassword(username, password, true), salt.ToString()); Redirection("TasksTodoPage"); } //
                else
                { MessageBox.Show("Vos deux entrées de mots de passe ne se correpondent pas."); }
            }
            else
            {
                MessageBox.Show($"Upper: {upperCase.Matches(password).Count}, Lower: {lowerCase.Matches(password).Count}, Digit: {digit.Matches(password).Count}, Special: {specials.Matches(password).Count}");

                MessageBox.Show("Votre mot de passe n'est pas conforme. Il doit contenir au moins 8 caractères, un chiffre, " +
                "un lettre majuscule, une lettre miniscule et un caractère spécial.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public string HashPasswordMySqlCompatible(string username,string password, bool create)
        {
            if (!create)
            { 
                salt = Encoding.UTF8.GetBytes(_model.GetSalt(username)); 
            }    
            else
            { 
                Random rnd = new Random();
                int length = rnd.Next(12, 20);
                int rndValue;
                string rndSalt = "";
                char letter;
                for (int i = 0; i < length; i++)
                {
                    // Generating a random number
                    rndValue = rnd.Next(0, 26);

                    // Generating random character by converting 
                    // the random number into character
                    letter = Convert.ToChar(rndValue + 65);

                    // Appending the letter to string
                    rndSalt = rndSalt + letter;
                }
                salt = Encoding.UTF8.GetBytes(rndSalt); 
            }

            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="create"></param>
    /// <returns></returns>
    public string HashPassword(string username, string password, bool create)
    {
        salt = Encoding.UTF8.GetBytes(_model.GetSalt(username)); //
        using (var sha256 = SHA256.Create())
        {
            // Concaténer les deux chaînes en tant que texte
            string combined = password + salt;

            // Encoder la chaîne combinée en UTF-8
            byte[] inputBytes = Encoding.UTF8.GetBytes(combined);

            // Calculer le hash
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Convertir en chaîne hexadécimale (comme MySQL le fait)
            StringBuilder sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("x2")); // format hexadécimal minuscule
            return sb.ToString();
        }
    }


    //public 

    //private void HashPassword(string password)
    //{

    //    Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(password, 8, numberOfItterations);    //Hash the password with a 8 byte salt
    //    byte[] password = PBKDF2.GetBytes(20);    //Returns a 20 byte hash
    //    byte[] salt = PBKDF2.Salt;
    //    writeHashToFile(password, salt, numberOfItterations); //Store the hashed password with the salt and number of itterations to check against future password entries
    //}

    //private bool checkPassword(string userName, string userPassword, int numberOfItterations)
    //{
    //    byte[] usersHash = getUserHashFromFile(userName);
    //    byte[] userSalt = getUserSaltFromFile(userName);
    //    Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(userPassword, userSalt, numberOfItterations);    //Hash the password with the users salt
    //    byte[] hashedPassword = PBKDF2.GetBytes(20);    //Returns a 20 byte hash            
    //    bool passwordsMach = comparePasswords(usersHash, hashedPassword);    //Compares byte arrays
    //    return passwordsMach;
    //}

    //private bool comparePasswords(byte[] usersHash, byte[] hashedPassword)
    //{
    //    throw new NotImplementedException();
    //}



    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
        public void CheckTaskData (string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string[] tab = data.Split(' ');

                if (tab.Length >= 2) // Check the number of word in the variable before adding it
                {
                    if (_model.AddTask(data))
                        DisplayTasks(false);
                }
                else
                {
                   MessageBox.Show("Votre tâche n'est pas suffisamment fournie pour que nous la considérions.");
                }
            }
            else
            {
                MessageBox.Show("Votre tâche n'est pas suffisamment fournie pour que nous la considérions.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insert"></param>
        public void EmptyUserInsert (dynamic insert = null)
        {
            insert.Text = null;
            //otherInsert = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="previousName"></param>
        public void EditTask (string newName, string previousName)
        {
            if (newName != previousName)
                _model.EditTask (newName, previousName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void EraseTask(string name)
        {
            _model.EraseTask(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="done"></param>
        /// <returns></returns>
        public List<string> DisplayTasks(bool done)
        {
            return _model.DisplayTasks(_model.RetrieveUserID(), done);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="done"></param>
        public void DeplaceTask(Label task, bool done)
        {
            if (done)
                _model.DeplaceTask(task.Text, done);
            else
                _model.DeplaceTask(task.Text, done);
        }
    }
}