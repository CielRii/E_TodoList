///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this page displays all the tasks an user has to do.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class TasksTodoPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        private Label taskTodoLbl;
        private TextBox taskTodoTxt;

        private List<string> tasksTodo;
        private bool firstClick = false;
        private string previousName;
        private string newName;

        private int indexTask = 0;
        private const int x = 1;
        private int y = 1;
        private const bool done = false;
        private bool firstLoad = false;

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;

        /// <summary>
        /// 
        /// </summary>
        public TasksTodoPage()
        {
            InitializeComponent();
        }

        private void TasksTodoPage_Load(object sender, EventArgs e)
        {
            Controller.CurrentPageRecap(tasksTodoList, done);
            Controller.AssignEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void taskTodoLbl_Click(object sender, EventArgs e)
        {
            Controller.DisplayContextMenuStrip(closeBtn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void markTaskAsDone_Click(object sender, EventArgs e)
        {
            Controller.MarkTaskAsDone();
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
            Controller.DeplaceTask(true);
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
            Controller.AssignEvents();
            //Controller.taskLbl_Click = taskTodoLbl_Click;
            //Controller.markTaskAsDone_Click = markTaskAsDone_Click;
            //Controller.editTask_Click = editTask_Click;
            //Controller.taskTodoTxt_KeyDown = taskTodoTxt_KeyDown;
            //Controller.deleteTask_Click = deleteTask_Click;
            //Controller.closeBtn_Click = closeBtn_Click;
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
            Controller.CloseContextMenuStrip();
            Controller.Redirection("TasksDonePage");
            Hide();
        }
    }
}