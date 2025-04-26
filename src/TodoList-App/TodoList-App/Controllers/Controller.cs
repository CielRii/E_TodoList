///ETML
///Author: Sarah Dongmo
///Creation date: 20.03.25
///Last modification: 02.04.25
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TodoList_App
{
    public class Controller
    {
        //
        private Model _model;
        private HomePage _home;

        // To save new user username after checking avaibility
        private string username;
        private const int numberOfItterations = 20000;
        private List<string> tasks;
        private List<Label> tasksList;
        private bool done;
        private byte[] salt;

        const int LABEL_WIDTH = 200, LABEL_HEIGHT = 25; //Label height and width
        private int indexTask;
        private const int x = 1;
        private int y = 1;

        private Label taskLbl;
        private TextBox taskTodoTxt;
        private Panel tasksPnl;
        private string previousName;
        private string newName;

        private string currentTask;
        private string previousTask;
        private int currentIndex;


        private bool closeProcess = false;
        private bool firstClick = false;
        private bool open = false;

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;
        private PictureBox closeBtn;
        private MenuStrip options;


        // Reference to all the app page excluding 
        public UserCreationPage UserCreationPage { get; set; }
        public TasksTodoPage TasksTodoPage { get; set; }
        public AddTaskPage AddTaskPage { get; set; }
        public TasksDonePage TasksDonePage { get; set; }
        private EventHandler taskLbl_Click { get; set; }
        private EventHandler markTaskAsDone_Click { get; set; }
        private EventHandler editTask_Click { get; set; }
        private EventHandler deleteTask_Click { get; set; }
        private KeyEventHandler taskTodoTxt_KeyDown { get; set; }
        private EventHandler closeBtn_Click { get; set; }
        private EventHandler unmarkTaskAsDone_Click { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="home"></param>
        public Controller(Model model, HomePage home)
        {
            _model = model;
            _home = home;

            _model.Controller = this;
            _home.Controller = this;
        }

        public void AssignEvents()
        {
            if (! done)
            {
                taskLbl_Click = TasksTodoPage.taskTodoLbl_Click;
                markTaskAsDone_Click = TasksTodoPage.markTaskAsDone_Click;
                editTask_Click = TasksTodoPage.editTask_Click;
                taskTodoTxt_KeyDown = TasksTodoPage.taskTodoTxt_KeyDown;
                deleteTask_Click = TasksTodoPage.deleteTask_Click;
                closeBtn_Click = TasksTodoPage.closeBtn_Click;
            }
            else
            {
                taskLbl_Click = TasksDonePage.taskDoneLbl_Click;
                deleteTask_Click = TasksDonePage.deleteTask_Click;
                unmarkTaskAsDone_Click = TasksDonePage.unmarkTaskAsDone_Click;
                closeBtn_Click = TasksDonePage.closeBtn_Click;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShareAppID()
        {
            UserCreationPage.Text = _home.Text;
            TasksTodoPage.Text = _home.Text;
            AddTaskPage.Text = _home.Text;
            TasksDonePage.Text = _home.Text;

            UserCreationPage.Icon = _home.Icon;
            TasksTodoPage.Icon = _home.Icon;
            AddTaskPage.Icon = _home.Icon;
            TasksDonePage.Icon = _home.Icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formName"></param>
        public void Redirection(string formName)
        {
            switch (formName)
            {
                case "UserCreationPage":
                    UserCreationPage.Show();
                    break;
                case "TasksTodoPage":
                    TasksTodoPage.Show();
                    AssignEvents();
                    DisplayTasks();
                    break;
                case "AddTaskPage":
                    AddTaskPage.Show();
                    break;
                case "TasksDonePage":
                    TasksDonePage.Show();
                    AssignEvents();
                    DisplayTasks();
                    break;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tasksPnl"></param>
        /// <param name="done"></param>
        public void CurrentPageRecap(Panel tasksPnl, bool done)
        {
            this.tasksPnl = tasksPnl;
            this.done = done;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayTasks()
        {
            tasksPnl.Controls.Clear();
            y = 1;
            indexTask = 0;
            tasks = SpecificTasksToDisplay();
            tasksList = new List<Label>();

            if (tasks.Count > 0)
            {
                for (int j = 0; j < tasks.Count; j++)
                {
                    taskLbl = new Label();
                    taskLbl.Click += new EventHandler(taskLbl_Click); //Add of an event to handle further operations
                    taskLbl.Height = LABEL_HEIGHT;
                    taskLbl.Width = LABEL_WIDTH;
                    taskLbl.Location = new Point(x, y);
                    taskLbl.Name = "taskLbl" + indexTask;
                    taskLbl.Text = tasks[j];
                    y += LABEL_HEIGHT + 10;
                    tasksList.Add(taskLbl); //
                    tasksPnl.Controls.Add(taskLbl);
                    indexTask++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> SpecificTasksToDisplay()
        {
            return _model.DisplayTasks(_model.RetrieveUserID(), done);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CheckLogin (string username, string password)
        {
            this.username = username;
            if (username != string.Empty && password != string.Empty)
            {
                if (_model.CheckLogin (username, HashPassword(password, true)))
                {
                    Redirection("TasksTodoPage");
                }
                else
                {
                    MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
                }
            }
            else
            {
                MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="created"></param>
        /// <returns></returns>
        public string HashPassword(string password, bool created)
        {
            // Control the need for the salt
            if (created)
                salt = _model.GetSalt(username); //Get salt in bytes
            else
                salt = GenerateSalt(); //Generate a salt


            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password); //Array with the password convert in bytes
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length]; //Definition of the length of the array that will contains the password and the salt

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length); //Add the password in bytes in the array for salted password
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length); //Add the salt in bytes in the array for salted password

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[salt.Length + hashedBytes.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckUserAvaible (string username)
        {
            if (_model.CheckUserAvaible(username)) //
            { this.username = username; return true; }
            else
            { return false; }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        public void CheckPassword (string password, string confirmPassword)
        {
            Regex upperCase = new Regex("([A-Z])");
            Regex lowerCase = new Regex("([a-z])");
            Regex digit = new Regex("([0-9])");
            Regex specials = new Regex("([-/#~%*])");

            if (password.Length >= 8 && upperCase.Matches(password).Count >= 1 && lowerCase.Matches(password).Count >= 1 &&
                digit.Matches(password).Count >= 1 && specials.Matches(password).Count >= 1) // Controls the password is enough secure
            {
                if (password == confirmPassword)
                { _model.CreateUser(username, HashPassword(password, false), salt); Redirection("TasksTodoPage"); } //
                else
                { MessageBox.Show("Vos deux entrées de mots de passe ne se correpondent pas."); }
            }
            else
            {
                MessageBox.Show($"Upper: {upperCase.Matches(password).Count}, Lower: {lowerCase.Matches(password).Count}, Digit: {digit.Matches(password).Count}, Special: {specials.Matches(password).Count}");

                MessageBox.Show("Votre mot de passe n'est pas conforme. Il doit contenir au moins 8 caractères, un chiffre, " +
                "un lettre majuscule, une lettre miniscule et un caractère spécial.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GenerateSalt(int size = 20)
        {
            using (var rng = new RNGCryptoServiceProvider()) //Secure random generator 
            {
                byte[] salt = new byte[size]; //Definition of the salt size
                rng.GetBytes(salt); //Random bytes
                return salt;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void CheckTaskData (string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string[] tab = data.Split(' ');

                if (tab.Length >= 2) // Check the number of word in the variable before adding it
                {
                    if (_model.AddTask(data))
                        DisplayTasks();
                }
                else
                {
                   MessageBox.Show("Votre tâche n'est pas suffisamment fournie pour que nous la considérions.");
                }
            }
            else
            {
                MessageBox.Show("Votre tâche n'est pas suffisamment fournie pour que nous la considérions.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insert"></param>
        public void EmptyUserInsert (dynamic insert = null)
        {
            insert.Text = null;
            //otherInsert = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void EraseTask(string name)
        {
            _model.EraseTask(name);
            CloseContextMenuStrip();
        }

        public void DisplayContextMenuStrip(PictureBox closeBtn, string currentTask)
        {
            this.currentTask = currentTask; 
            string[] index = Regex.Split(currentTask, @"\D+");
            foreach (string currentIndex in index)
            {
                int i;
                if (int.TryParse(currentIndex, out i))
                {
                    taskLbl = tasksList[i]; 
                }
            }

            if (!firstClick)
            {
                this.closeBtn = closeBtn;

                // Create a new ContextMenuStrip control.
                contextMenuStrip = new ContextMenuStrip();

                // Attach an event handler for the ContextMenuStrip control's Opening event.
                ToolStrip ctrl = new ToolStrip();
                string[] taskOptions;

                if (! done)
                {
                    taskOptions = new string[] { "1. Marquer la tâche comme complète", "2. Modifier la tâche", "3. Supprimer la tâche"};
                }
                else
                {
                    taskOptions = new string[] { "1. Supprimer définitivement la tâche", "2. Marquer la tâche comme non terminée" };
                }

                // Create a new MenuStrip control and add a ToolStripMenuItem.
                options = new MenuStrip();
                foreach (var option in taskOptions)
                {
                    ToolStripMenuItem crud = new ToolStripMenuItem(option);
                    if (option == "1. Marquer la tâche comme complète")
                        crud.Click += new EventHandler(markTaskAsDone_Click); //Add of an event to handle further operations
                    if (option == "2. Modifier la tâche")
                        crud.Click += new EventHandler(editTask_Click); //Add of an event to handle further operations
                    if (option == "3. Supprimer la tâche" || option == "1. Supprimer définitivement la tâche")
                        crud.Click += new EventHandler(deleteTask_Click); //Add of an event to handle further operations
                    if (option == "2. Marquer la tâche comme non terminée")
                        crud.Click += new EventHandler(unmarkTaskAsDone_Click);
                    options.Items.Add(crud);
                    options.Dock = DockStyle.Right;
                    crud.DropDown = contextMenuStrip;
                }

                //Link the close button to the menu
                closeBtn.ContextMenuStrip = contextMenuStrip;
                closeBtn.Visible = true;
                closeBtn.Click += new EventHandler(closeBtn_Click);

                if (!done)
                {
                    // Assign the ContextMenuStrip to the form's ContextMenuStrip property.
                    TasksTodoPage.ContextMenuStrip = contextMenuStrip;
                    // Add the ToolStrip control to the Controls collection.
                    TasksTodoPage.Controls.Add(ctrl);
                    // Add the MenuStrip control last. This is important for correct placement in the z-order.
                    TasksTodoPage.Controls.Add(options);
                }
                else
                {
                    // Assign the ContextMenuStrip to the form's ContextMenuStrip property.
                    TasksDonePage.ContextMenuStrip = contextMenuStrip;
                    // Add the ToolStrip control to the Controls collection.
                    TasksDonePage.Controls.Add(ctrl);
                    // Add the MenuStrip control last. This is important for correct placement in the z-order.
                    TasksDonePage.Controls.Add(options);
                }
                open = true;
                firstClick = true;
            }
        }

        public void EditTask()
        {
            previousName = taskLbl.Text;
            taskTodoTxt = new TextBox();
            taskTodoTxt.Text = taskLbl.Text;
            taskTodoTxt.Location = taskLbl.Location;
            taskTodoTxt.Visible = true;
            taskLbl.Visible = false;
            taskTodoTxt.KeyDown += taskTodoTxt_KeyDown;

            tasksPnl.Controls.Add(taskTodoTxt);
        }

        public void EditTask(string newName, string previousName)
        {
            if (newName != previousName)
                _model.EditTask(newName, previousName);
        }

        public void ControlUserInput(KeyEventArgs e = null)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlUserInput();
            }
        }

        public void ControlUserInput()
        {
            if (taskTodoTxt != null)
            {
                taskLbl.Text = taskTodoTxt.Text;
                newName = taskLbl.Text;
                taskLbl.Visible = true;
                taskTodoTxt.Visible = false;
                EditTask(newName, previousName);
            }
        }

        public void DeleteTask()
        {
            DialogResult confirmSuppression = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    EraseTask(taskLbl.Text);
                    DisplayTasks();
                    break;
                case DialogResult.No:

                    break;
            }
        }

        public void CloseContextMenuStrip()
        {
            if (open == true)
            {
                closeBtn.Visible = false;
                options.Hide();
                closeProcess = true;
                ControlUserInput();
                closeProcess = false;
                firstClick = false;
                open = false;
                taskTodoTxt = null;
                previousTask = taskLbl.Text;
            }
        }

        public void DeplaceTask(bool done)
        {
            _model.DeplaceTask(taskLbl.Text, done);
        }
    }
}