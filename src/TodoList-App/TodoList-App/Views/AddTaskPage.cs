///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : this page allows the user to add further tasks.

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
    public partial class AddTaskPage : Form
    {
        public Controller Controller { get; set; }
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksTodoPage");
            Hide();
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckTaskData(addTaskInsert.Text);
        }
    }
}
