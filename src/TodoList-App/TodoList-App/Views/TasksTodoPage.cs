///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this page displays all the tasks an user has to do.

using System;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class TasksTodoPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        private const bool done = false;


        /// <summary>
        /// 
        /// </summary>
        public TasksTodoPage()
        {
            InitializeComponent();
        }

        private void TasksTodoPage_Load(object sender, EventArgs e)
        {
           
        }

        private void TasksTodoPage_Activated(object sender, EventArgs e)
        {
            Controller.CurrentPageRecap(tasksTodoPnl, done);
            //Controller.AssignEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void taskTodoLbl_Click(object sender, EventArgs e)
        {
            //Controller.AssignEvents();
            Controller.CloseContextMenuStrip();
            if (sender is Label lbl)
            {
                string currentTask = lbl.Name;
                Controller.DisplayContextMenuStrip(closeBtn, currentTask);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void markTaskAsDone_Click(object sender, EventArgs e)
        {
            Controller.DeplaceTask(true);
            Controller.CloseContextMenuStrip();
            Controller.DisplayTasks();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void editTask_Click(object sender, EventArgs e)
        {
            Controller.EditTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void taskTodoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            Controller.ControlUserInput(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void deleteTask_Click(object sender, EventArgs e)
        {
            Controller.DeleteTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void closeBtn_Click(object sender, EventArgs e)
        {
            Controller.CloseContextMenuStrip();
            //Controller.AssignEvents();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            Controller.CloseContextMenuStrip();
            Controller.Redirection("AddTaskPage");
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tasksDoneBtn_Click(object sender, EventArgs e)
        {
            Controller.CloseContextMenuStrip(); //
            Controller.Redirection("TasksDonePage");
            Hide();
        }
    }
}