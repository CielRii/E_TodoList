///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this is the first page the user see when entering in the app.

using System;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class HomePage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomePage_Load(object sender, EventArgs e)
        {
            Controller.ShareAppID();
            passwordInsert.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("UserCreationPage");
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connexionBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckLogin(userNameInsert.Text, passwordInsert.Text);
            Hide();
        }
    }
}