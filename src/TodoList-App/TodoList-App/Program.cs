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


            //Initialization of the MCD model 
            Model model = new Model();
            HomePage homePage = new HomePage();
            Controller controller = new Controller(model, homePage);

            UserCreationPage userCreation = new UserCreationPage();
            TasksTodoPage tasksTodo = new TasksTodoPage();
            AddTaskPage addTask = new AddTaskPage();
            TasksDonePage tasksDone = new TasksDonePage();
            HomePage home = new HomePage(userCreation, tasksTodo, addTask, tasksDone);
            home.UserCreationPage = userCreation;
            home.TasksTodoPage = tasksTodo;
            userCreation.TasksTodoPage = tasksTodo;
            tasksTodo.TasksDonePage = tasksDone;
            tasksTodo.AddTaskPage = addTask;
            addTask.TasksTodoPage = tasksTodo;
            tasksDone.TasksTodoPage = tasksTodo;

            Application.Run(home);
        }
    }
}
