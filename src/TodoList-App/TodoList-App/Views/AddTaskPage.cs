///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this page allows the user to add further tasks.

using System;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class AddTaskPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AddTaskPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksTodoPage");
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckTaskData(addTaskInsert.Text);
            Controller.EmptyUserInsert(addTaskInsert);
            //
        }
    }
}