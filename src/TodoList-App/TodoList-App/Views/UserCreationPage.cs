///ETML
///Author: Sarah Dongmo
///Creation date: 17.03.25
///Last modification: 31.03.25
///Description : this page allows the user to create an account for using the app.

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
    public partial class UserCreationPage : Form
    {
        public Controller Controller { get; set; }
        public UserCreationPage()
        {
            InitializeComponent();
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckPassword(newUserPasswordInsert.Text, newUserConfirmPasswordInsert.Text);

            Hide();
        }
    }
}
