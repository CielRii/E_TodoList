///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : this is the first page the user see when entering in the app.

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
    public partial class HomePage : Form
    {
        public Controller Controller { get; set; }
       
        public HomePage() //UserCreationPage creation, TasksTodoPage tasksTodo, AddTaskPage addTask, TasksDonePage tasksDone
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Controller.ShareAppID(); //
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("UserCreationPage");
            Hide();
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckLogin(userNameInsert.Text, passwordInsert.Text);
            Hide();
        }
    }
}