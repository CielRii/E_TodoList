///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : this page display all the tasks that were done by the user.

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
    public partial class TasksDonePage : Form
    {
        public Controller Controller { get; set; }

        private Label taskDoneLbl;
        private TextBox taskTodoTxt;

        private bool firstClick = false;
        private bool deleteStatus = false;

        const int LABEL_WIDTH = 200, LABEL_HEIGHT = 25, PANEL_SIZE = 40; //Label height and width
        private int indexTask = 1;
        private int x = 1;
        const int y = 1;
        const bool done = false;

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;
        public TasksDonePage()
        {
            InitializeComponent();
        }

        private void TasksDonePage_Load(object sender, EventArgs e)
        {
            List<string> tasksTodo = Controller.DisplayTasks(done);

            if (tasksTodo.Count > 0)
            {
                for (int j = 0; j < tasksTodo.Count; j++)
                {
                    taskDoneLbl = new Label();
                    taskDoneLbl.Click += new EventHandler(taskDoneLbl_Click); //Add of an event to handle further operations
                    taskDoneLbl.Height = LABEL_HEIGHT;
                    taskDoneLbl.Width = LABEL_WIDTH;
                    taskDoneLbl.Location = new Point(x, y);
                    taskDoneLbl.Name = "taskDoneLbl" + indexTask;
                    taskDoneLbl.Text = tasksTodo[j];
                    x += LABEL_HEIGHT + 10;
                    tasksDoneList.Controls.Add(taskDoneLbl);
                    indexTask++;
                }
            }
        }

        private void taskDoneLbl_Click(object sender, EventArgs e)
        {
            if (!firstClick)
            {
                // Create a new ContextMenuStrip control.
                contextMenuStrip = new ContextMenuStrip();

                // Attach an event handler for the 
                // ContextMenuStrip control's Opening event.

                ToolStrip ctrl = new ToolStrip();
                //ctrl.Dock = DockStyle.Right;
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

                // Assign the ContextMenuStrip to the form's 
                // ContextMenuStrip property.
                ContextMenuStrip = contextMenuStrip;

                // Add the ToolStrip control to the Controls collection.
                this.Controls.Add(ctrl);
                // Add the MenuStrip control last. This is important for correct placement in the z-order.
                this.Controls.Add(options);
                firstClick = true;
            }
        }


        private void deleteTask_Click(object sender, EventArgs e)
        {
            DialogResult confirmSuppression = MessageBox.Show("Êtes-vous de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    deleteStatus = true;
                    Controller.ManageTasks("Erase");
                    break;
                case DialogResult.No:
                    deleteStatus = false;
                    break;
            }

            if (deleteStatus)
                taskDoneLbl.Visible = false;
        }

        private void unmarkTaskAsDone_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = taskDoneLbl.Text; //
            lbl.Visible = true;
            Controller.DeplaceTask(lbl);
            taskDoneLbl.Visible = false;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            //ContextMenuStrip = null;
            //ContextMenuStrip.Close();

            //ContextMenuStrip.Hide();
            ContextMenuStrip.Visible = false;

            closeBtn.Visible = false;
        }

        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksTodoPage");
            Hide();
        }
    }
}
