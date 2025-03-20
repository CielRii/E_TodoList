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

namespace TodoList_App
{
    public class Controller
    {
        private Model _model;
        private string previousName;
        private string newName;

        public HomePage HomePage { get; set; }
        public UserCreationPage UserCreationPage { get; set; }
        public TasksTodoPage TasksTodoPage { get; set; }
        public AddTaskPage AddTaskPage { get; set; }
        public TasksDonePage TasksDonePage { get; set; }


        public Controller(Model model, HomePage home)
        {
            //Vérification de l'accès de l'utilisateur .... userNameInsert, passwordInsert
            //Ajout... lien avec le modèle et la DB
            //Modif'... enregistrement du nom actuel avant de valider. - On click sur n'importe quelle tâche
            //Delete... confirmation avec suppression

            _model = model;

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
    }
}
