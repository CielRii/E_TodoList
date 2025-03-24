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
        public TasksDonePage()
        {
            InitializeComponent();
        }

        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            Controller.Redirection("TasksTodoPage");
            Hide();
        }
    }
}
