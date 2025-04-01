///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : application's entry point

using System;
using System.Windows.Forms;

namespace TodoList_App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialization of the MCD model 
            Model model = new Model();
            HomePage home = new HomePage();
            Controller controller = new Controller(model, home);

            //Initialization of all the page
            UserCreationPage userCreation = new UserCreationPage();
            TasksTodoPage tasksTodo = new TasksTodoPage();
            AddTaskPage addTask = new AddTaskPage();
            TasksDonePage tasksDone = new TasksDonePage();

            //Controller's initialization of all page depending on it
            userCreation.Controller = controller;
            tasksTodo.Controller = controller;
            addTask.Controller = controller;
            tasksDone.Controller = controller;
            home.Controller = controller;

            //Initialization of classes in Controller.cs 
            controller.UserCreationPage = userCreation;
            controller.TasksTodoPage = tasksTodo;
            controller.AddTaskPage = addTask;
            controller.TasksDonePage = tasksDone;

            Application.Run(home);
        }
    }
}