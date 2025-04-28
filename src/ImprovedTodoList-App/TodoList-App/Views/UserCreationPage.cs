///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 02.04.25
///Description : this page allows the user to create an account for using the app.

using System;
using System.Windows.Forms;

namespace TodoList_App
{
    public partial class UserCreationPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserCreationPage()
        {
            InitializeComponent();
        }

        private void UserCreationPage_Load(object sender, EventArgs e)
        {
            newUserPasswordInsert.UseSystemPasswordChar = true;
            newUserConfirmPasswordInsert.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            if (Controller.CheckUserAvaible(newUserNameInsert.Text))
                Controller.CheckPassword(newUserPasswordInsert.Text, newUserConfirmPasswordInsert.Text);
            else
                MessageBox.Show("Ce nom d'utilisateur n'est pas disponible, veuillez choisir un autre.");

            Hide();
        }
    }
}