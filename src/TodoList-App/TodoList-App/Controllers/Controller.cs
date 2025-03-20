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
        public Controller(Model model, HomePage home)
        {

        }

        public void Redirection(string formName)
        {
            switch (formName)
            {
                case "AddTaskPage":
                    AddTaskPage.Show();
                    break;
                case "HomePage":
                    HomePage.Show();
                    break;
                case "TasksDonePage":
                    TasksDonePage.Show();
                    break;
                case "TasksTodoPage":
                    TasksTodoPage.Show();
                    break;
                case "UserCreationPage":
                    UserCreationPage.Show();
                    break;
            }
        }
    }
}
