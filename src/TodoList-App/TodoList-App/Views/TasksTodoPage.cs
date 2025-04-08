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

        const int LABEL_WIDTH = 200, LABEL_HEIGHT = 25; //Label height and width
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

        public void DisplayTasks(List<string> tasksTodo)
        {
            tasksTodoList.Controls.Clear();
            y = 0;
            if (tasksTodo.Count > 0)
            {
                for (int j = 0; j < tasksTodo.Count; j++)
                {
                    taskTodoLbl = new Label();
                    taskTodoLbl.Click += new EventHandler(taskTodoLbl_Click); //Add of an event to handle further operations
                    taskTodoLbl.Height = LABEL_HEIGHT;
                    taskTodoLbl.Width = LABEL_WIDTH;
                    taskTodoLbl.Location = new Point(x, y);
                    taskTodoLbl.Name = "taskTodoLbl" + indexTask;
                    taskTodoLbl.Text = tasksTodo[j];
                    y += LABEL_HEIGHT + 10;
                    tasksTodoList.Controls.Add(taskTodoLbl);
                    indexTask++;
                }
            }
            firstLoad = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskTodoLbl_Click(object sender, EventArgs e)
        {
            if (!firstClick)
            {
                // Create a new ContextMenuStrip control.
                contextMenuStrip = new ContextMenuStrip();

                // Attach an event handler for the ContextMenuStrip control's Opening event.
                ToolStrip ctrl = new ToolStrip();
                string[] taskOptions = new string[] { "1.Marquer la tâche comme complète",
                "2.Modifier la tâche", "3.Supprimer la tâche"};

                // Create a new MenuStrip control and add a ToolStripMenuItem.
                MenuStrip options = new MenuStrip();
                foreach (var option in taskOptions)
                {
                    ToolStripMenuItem crud = new ToolStripMenuItem(option);
                    if (option == "1.Marquer la tâche comme complète")
                        crud.Click += new EventHandler(markTaskAsDone_Click); //Add of an event to handle further operations
                    if (option == "2.Modifier la tâche")
                        crud.Click += new EventHandler(editTask_Click); //Add of an event to handle further operations
                    if (option == "3.Supprimer la tâche")
                        crud.Click += new EventHandler(deleteTask_Click); //Add of an event to handle further operations
                    options.Items.Add(crud);
                    options.Dock = DockStyle.Right;
                    crud.DropDown = contextMenuStrip;
                }
                //Link the close button to the menu
                closeBtn.ContextMenuStrip = contextMenuStrip;
                closeBtn.Visible = true;
                closeBtn.Click += new EventHandler(closeBtn_Click);

                // Assign the ContextMenuStrip to the form's ContextMenuStrip property.
                ContextMenuStrip = contextMenuStrip;

                // Add the ToolStrip control to the Controls collection.
                Controls.Add(ctrl);
                // Add the MenuStrip control last. This is important for correct placement in the z-order.
                Controls.Add(options);
                firstClick = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markTaskAsDone_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = taskTodoLbl.Text;
            lbl.Visible = true;
            Controller.DeplaceTask(lbl, true);
            Controller.EmptyUserInsert(insert:lbl);
            removeTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editTask_Click(object sender, EventArgs e)
        {
            previousName = taskTodoLbl.Text;
            taskTodoTxt = new TextBox();
            taskTodoTxt.Text = taskTodoLbl.Text;
            taskTodoTxt.Location = taskTodoLbl.Location;
            taskTodoTxt.Visible = true;
            taskTodoLbl.Visible = false;
            taskTodoTxt.KeyDown += taskTodoTxt_KeyDown;

            Controls.Add(taskTodoTxt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskTodoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                taskTodoLbl.Text = taskTodoTxt.Text;
                newName = taskTodoLbl.Text;
                taskTodoLbl.Visible = true;
                taskTodoTxt.Visible = false;
                Controller.EditTask(newName, previousName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTask_Click(object sender, EventArgs e)
        {
            DialogResult confirmSuppression = MessageBox.Show("Êtes-vous de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    removeTask();
                    break;
                case DialogResult.No:

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void removeTask()
        {
            string[] index = Regex.Split(taskTodoLbl.Name, @"\D+");
            foreach (string currentIndex in index)
            {
                int i;
                if (int.TryParse(currentIndex, out i))
                {
                    tasksTodo.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            ContextMenuStrip.Visible = false;
            closeBtn.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
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
            Controller.Redirection("TasksDonePage");
            Hide();
        }
    }
}