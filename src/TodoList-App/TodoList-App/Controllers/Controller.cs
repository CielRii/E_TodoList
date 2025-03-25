///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 31.03.25
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Redirection(string formName)
        {

            //Vérification de l'accès de l'utilisateur .... userNameInsert, passwordInsert
            //Ajout... lien avec le modèle et la DB
            //Modif'... enregistrement du nom actuel avant de valider. - On click sur n'importe quelle tâche
            //Delete... confirmation avec suppression
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

        public void DisplayTasks()
        {
            _model.DisplayTasks(_model.RetrieveUserID());
        }

        public void DeplaceTask()
        {
            //Controls.Add(taskTodoLbl1);
        }
    }
}
