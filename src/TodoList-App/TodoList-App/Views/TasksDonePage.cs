///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this page display all the tasks that were done by the user.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class TasksDonePage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        private Label taskDoneLbl;

        private List<string> tasksDone; //
        private bool firstClick = false; //
        private bool deleteStatus = false; //

        private const int LABEL_WIDTH = 200, LABEL_HEIGHT = 25; //Label height and width
        private int indexTask = 1;
        private const int x = 1;
        private int y = 1;
        private const bool done = true;

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;

        /// <summary>
        /// 
        /// </summary>
        public TasksDonePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TasksDonePage_Load(object sender, EventArgs e)
        {
           
        }

        private void TasksDonePage_Activated(object sender, EventArgs e)
        {
            Controller.CurrentPageRecap(tasksDonePnl, done);
            //Controller.AssignEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void taskDoneLbl_Click(object sender, EventArgs e)
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
        public void deleteTask_Click(object sender, EventArgs e)
        {
            Controller.DeleteTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void unmarkTaskAsDone_Click(object sender, EventArgs e)
        {
            Controller.DeplaceTask(false);
            Controller.CloseContextMenuStrip();
            Controller.DisplayTasks();
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
    }
}
