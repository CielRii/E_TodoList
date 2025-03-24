///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList_App
{
    internal static class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UserCreationPage userCreation = new UserCreationPage();
            TasksTodoPage tasksTodo = new TasksTodoPage();
            AddTaskPage addTask = new AddTaskPage();
            TasksDonePage tasksDone = new TasksDonePage();
            HomePage home = new HomePage(userCreation, tasksTodo, addTask, tasksDone);

            //Initialization of the MCD model 
            Model model = new Model();
            Controller controller = new Controller(model, home);

            //Initialization of Controller in all page depending on it
            //userCreation.Controller = controller;
            //tasksTodo.Controller = controller;
            //tasksTodo.Controller = controller;
            //addTask.Controller = controller;
            //tasksDone.Controller = controller;
            //home.Controller = controller;

            //Initialization of classes in Controller.cs 
            controller.UserCreationPage = userCreation;
            controller.TasksTodoPage = tasksTodo;
            controller.TasksDonePage = tasksDone;

            Application.Run(home);
        }
    }
}
