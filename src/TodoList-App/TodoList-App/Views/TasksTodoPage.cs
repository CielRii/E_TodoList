///ETML
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
        public Controller Controller { get; set; }
        private Label taskTodoLbl;
        private TextBox textBox1;
        private bool deleteStatus = false;
        const int LABEL_WIDTH = 200, LABEL_HEIGHT = 25, PANEL_SIZE = 40; //Label height and width
        private int indexTask = 1;
        private int x = 1;
        const int y = 1;

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;
        public TasksTodoPage()
        {
            InitializeComponent();
            //Controller.DisplayTasks();

            for (int j = 0; j < 10; j++)
            {
                taskTodoLbl = new Label();
                taskTodoLbl.Click += new System.EventHandler(taskTodoLbl_Click); //Add of an event to handler further operations
                taskTodoLbl.Height = LABEL_HEIGHT;
                taskTodoLbl.Width = LABEL_WIDTH;
                taskTodoLbl.Location = new System.Drawing.Point(x, y);
                taskTodoLbl.Name = "taskTodoLbl" + indexTask;
                x += LABEL_HEIGHT + 10;
                tasksTodoList.Controls.Add(taskTodoLbl);
                indexTask++;
            }

        }

        private void taskTodoLbl_Click(object sender, EventArgs e)
        {
            // Create a new ContextMenuStrip control.
            contextMenuStrip = new ContextMenuStrip();

            // Attach an event handler for the 
            // ContextMenuStrip control's Opening event.
            //contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);


            ToolStrip ctrl = new ToolStrip();
            ctrl.Dock = DockStyle.Right;
            string[] taskOptions = new string[] { "1.Marquer la tâche comme complète",
            "2.Modifier la tâche", "3.Supprimer la tâche"};

            // Create a new MenuStrip control and add a ToolStripMenuItem.
            MenuStrip options = new MenuStrip();
            foreach (var option in taskOptions)
            {
                ToolStripMenuItem crud = new ToolStripMenuItem(option);
                if (option == "1.Marquer la tâche comme complète")
                    crud.Click += new EventHandler(markTaskAsDone_Click); //Add of an event to handler further operations
                if (option == "2.Modifier la tâche")
                    crud.Click += new EventHandler(editTask_Click); //Add of an event to handler further operations
                if (option == "3.Supprimer la tâche")
                    crud.Click += new EventHandler(deleteTask_Click); //Add of an event to handler further operations
                options.Items.Add(crud);
                options.Dock = DockStyle.Right;
                crud.DropDown = contextMenuStrip;
            }

            // Assign the ContextMenuStrip to the form's 
            // ContextMenuStrip property.
            ContextMenuStrip = contextMenuStrip;

            // Add the ToolStrip control to the Controls collection.
            this.Controls.Add(ctrl);
            // Add the MenuStrip control last. This is important for correct placement in the z-order.
            this.Controls.Add(options);

        }

        private void markTaskAsDone_Click(object sender, EventArgs e)
        {
            Label taskTodoLbl1 = new Label();
            taskTodoLbl1 = taskTodoLbl;
            Controller.DeplaceTask();
            taskTodoLbl.Visible = false;
            Controller.Redirection("");
        }

        private void editTask_Click(object sender, EventArgs e)
        {
            textBox1 = new TextBox();
            textBox1.Text = taskTodoLbl.Text;
            textBox1.Location = taskTodoLbl.Location;
            textBox1.Visible = true;
            taskTodoLbl.Visible = false;
            textBox1.KeyDown += textBox1_KeyDown;

            Controls.Add(textBox1);
            if (!textBox1.Focus())
            {
                taskTodoLbl.Text = textBox1.Text;
                taskTodoLbl.Visible = true;
                textBox1.Visible = false;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                taskTodoLbl.Text = textBox1.Text;
                taskTodoLbl.Visible = true;
                textBox1.Visible = false;
            }
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            DialogResult confirmSuppression = MessageBox.Show("Êtes-vous de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    deleteStatus = true;
                    taskTodoLbl.Visible = false;
                    break;
                case DialogResult.No:
                    deleteStatus = false;
                    break;
            }
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("AddTaskPage");
            Hide();
        }

        private void tasksDoneBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksDonePage");
            Hide();
        }
    }
}
