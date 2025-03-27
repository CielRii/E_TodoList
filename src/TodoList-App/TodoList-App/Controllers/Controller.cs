///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 31.03.25
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList_App
{
    public class Controller
    {
        private Model _model;
        private HomePage _home;

        private string previousName;
        private string newName;

        public HomePage HomePage { get; set; }
        public UserCreationPage UserCreationPage { get; set; }
        public TasksTodoPage TasksTodoPage { get; set; }
        public AddTaskPage AddTaskPage { get; set; }
        public TasksDonePage TasksDonePage { get; set; }


        public Controller(Model model, HomePage home)
        {
            _model = model;
            _home = home;

            _model.Controller = this;
            _home.Controller = this;

        }

        public void ShareAppID()
        {
            UserCreationPage.Text = HomePage.Text;
            TasksTodoPage.Text = HomePage.Text;
            AddTaskPage.Text = HomePage.Text;
            TasksDonePage.Text = HomePage.Text;

            UserCreationPage.Icon = HomePage.Icon;
            TasksTodoPage.Icon = HomePage.Icon;
            AddTaskPage.Icon = HomePage.Icon;
            TasksDonePage.Icon = HomePage.Icon;
        }

        public void Redirection(string formName)
        {
            switch (formName)
            {
                case "HomePage":
                    HomePage.Show();
                    break;
                case "UserCreationPage":
                    UserCreationPage.Show();
                    break;
                case "TasksTodoPage":
                    TasksTodoPage.Show();
                    break;
                case "AddTaskPage":
                    AddTaskPage.Show();
                    break;
                case "TasksDonePage":
                    TasksDonePage.Show();
                    break;
            }
        }

        public void CheckLogin (string username, string password)
        {
            if (username != string.Empty && password != string.Empty)
            {
                if (_model.CheckLogin (username, password))
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

        public bool CheckUserAvaible (string username)
        {
            if (_model.CheckUserAvaible(username))
                return true;
            else
                return false;
        }


        public void CheckPassword (string password, string confirmPassword)
        {

            Regex upperCase = new Regex("([A-Z])");
            Regex lowerCase = new Regex("([a-z])");
            Regex digit = new Regex("([0-9])");
            Regex specials = new Regex("([#~%*])");

            if (password.Length == 8 && upperCase.Matches(password).Count >= 1 && lowerCase.Matches(password).Count >= 1 &&
                digit.Matches(password).Count >= 1 && specials.Matches(password).Count >= 1) // Controls the password is enough secure
            {
                if (password == confirmPassword)
                    Redirection("TasksTodoPage");
                else
                    MessageBox.Show("Vos deux entrées de mots de passe ne se correpondent pas.");
            }
            else
            {
                MessageBox.Show("Votre mot de passe n'est pas conforme. Il doit contenir au moins 8 caractères, un chiffre, " +
                    "un lettre majuscule, une lettre miniscule et un caractère spécial.");
            }
        }

        public void CheckTaskData (string data)
        {
            if (!string.IsNullOrEmpty(data)) 
            {
                string[] tab = data.Split(' ');

                if (tab.Length > 2) // Check the number of word in the variable before adding it
                {
                    _model.AddTask(data);
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

        public void ManageTasks (string name)
        {
            switch (name)
            {
                case "Add":
                    _model.AddTask (name);
                    break;
                case "Edit":
                    previousName = name;
                    EditTask(previousName);
                    break;
                case "Erase":
                    _model.EraseTask(name);
                    break;
            }
        }

        public void EditTask (string previousName)
        {
            _model.EditTask (newName, previousName);
        }

        public List<string> DisplayTasks()
        {
            return _model.DisplayTasks(_model.RetrieveUserID());
        }

        public void DeplaceTask(Label task)
        {
            TasksDonePage.Controls.Add(task);
        }
    }
}
