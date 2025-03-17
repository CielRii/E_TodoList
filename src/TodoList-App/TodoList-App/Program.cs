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
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomePage(ConnexionPage connexion, UserCreationPage creation, TasksTodoPage tasksTodo, AddTaskPage addTask, TasksDonePage tasksDone));
        }
    }
}
