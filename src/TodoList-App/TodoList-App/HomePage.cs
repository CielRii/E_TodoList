///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : first page that the user see when entrering in the app.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class HomePage : Form
    {
        public HomePage(ConnexionPage connexion, UserCreationPage creation, TasksTodoPage tasksTodo, AddTaskPage addTask, TasksDonePage tasksDone)
        {
            InitializeComponent();

            connexion.Text = this.Text;
            creation.Text = this.Text;
            tasksTodo.Text = this.Text;
            addTask.Text = this.Text;
            tasksDone.Text = this.Text;

        }
    }
}
