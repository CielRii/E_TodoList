﻿///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : this page displays all the tasks an user has to do.

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
    public partial class TasksTodoPage : Form
    {
        public AddTaskPage AddTaskPage;
        public TasksDonePage TasksDonePage;
        public TasksTodoPage()
        {
            InitializeComponent();
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTaskPage.Show();
        }

        private void tasksDoneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TasksDonePage.Show();
        }
    }
}
