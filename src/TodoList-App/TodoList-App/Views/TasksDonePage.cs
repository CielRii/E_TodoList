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
            tasksDoneList.Controls.Clear();
            y = 1;
            //tasksDone = Controller.DisplayTasks();

            if (tasksDone.Count > 0)
            {
                for (int j = 0; j < tasksDone.Count; j++)
                {
                    taskDoneLbl = new Label();
                    taskDoneLbl.Click += new EventHandler(taskDoneLbl_Click); //Add of an event to handle further operations
                    taskDoneLbl.Height = LABEL_HEIGHT;
                    taskDoneLbl.Width = LABEL_WIDTH;
                    taskDoneLbl.Location = new Point(x, y);
                    taskDoneLbl.Name = "taskDoneLbl" + indexTask;
                    taskDoneLbl.Text = tasksDone[j];
                    y += LABEL_HEIGHT + 10;
                    tasksDoneList.Controls.Add(taskDoneLbl);
                    indexTask++;
                }
            }
        }


        public void DisplayTasks()
        {
            tasksDoneList.Controls.Clear();
            y = 1;
           // tasksDone = Controller.DisplayTasks();

            if (tasksDone.Count > 0)
            {
                for (int j = 0; j < tasksDone.Count; j++)
                {
                    taskDoneLbl = new Label();
                    taskDoneLbl.Click += new EventHandler(taskDoneLbl_Click); //Add of an event to handle further operations
                    taskDoneLbl.Height = LABEL_HEIGHT;
                    taskDoneLbl.Width = LABEL_WIDTH;
                    taskDoneLbl.Location = new Point(x, y);
                    taskDoneLbl.Name = "taskDoneLbl" + indexTask;
                    taskDoneLbl.Text = tasksDone[j];
                    y += LABEL_HEIGHT + 10;
                    tasksDoneList.Controls.Add(taskDoneLbl);
                    indexTask++;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskDoneLbl_Click(object sender, EventArgs e)
        {
            if (!firstClick)
            {
                // Create a new ContextMenuStrip control.
                contextMenuStrip = new ContextMenuStrip();

                // Attach an event handler for the ContextMenuStrip control's Opening event.
                ToolStrip ctrl = new ToolStrip();
                
                string[] taskOptions = new string[] { "1.Supprimer définitivement la tâche", "2.Marquer la tâche comme non terminée" };


                // Create a new MenuStrip control and add a ToolStripMenuItem.
                MenuStrip options = new MenuStrip();
                foreach (var option in taskOptions)
                {
                    ToolStripMenuItem crud = new ToolStripMenuItem(option);
                    if (option == "1.Supprimer définitivement la tâche")
                        crud.Click += new EventHandler(deleteTask_Click); //Add of an event to handle further operations
                    if (option == "2.Marquer la tâche comme non terminée")
                        crud.Click += new EventHandler(unmarkTaskAsDone_Click); //Add of an event to handle further operations
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
        private void deleteTask_Click(object sender, EventArgs e)
        {
            DialogResult confirmSuppression = MessageBox.Show("Êtes-vous de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    deleteStatus = true;
                    Controller.EraseTask(taskDoneLbl.Text);
                    break;
                case DialogResult.No:
                    deleteStatus = false;
                    break;
            }

            if (deleteStatus)
                taskDoneLbl.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unmarkTaskAsDone_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = taskDoneLbl.Text;
            lbl.Visible = true;
            Controller.DeplaceTask(false);
            removeTask();
        }

        /// <summary>
        /// 
        /// </summary>
        private void removeTask()
        {
            string[] index = Regex.Split(taskDoneLbl.Name, @"\D+");
            foreach (string currentIndex in index)
            {
                int i;
                if (int.TryParse(currentIndex, out i))
                {
                    tasksDone.RemoveAt(i);
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
        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksTodoPage");
            Hide();
        }
    }
}
