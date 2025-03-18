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
        public UserCreationPage UserCreationPage;
        public TasksTodoPage TasksTodoPage;
        public HomePage(UserCreationPage creation, TasksTodoPage tasksTodo, AddTaskPage addTask, TasksDonePage tasksDone)
        {
            InitializeComponent();

            creation.Text = this.Text;
            tasksTodo.Text = this.Text;
            addTask.Text = this.Text;
            tasksDone.Text = this.Text;

            creation.Icon = this.Icon;
            tasksTodo.Icon = this.Icon;
            addTask.Icon = this.Icon;
            tasksDone.Icon = this.Icon;

        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserCreationPage.Show();
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TasksTodoPage.Show();
        }

    }
}
