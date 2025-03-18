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
        public TasksTodoPage TasksTodoPage;
        public TasksDonePage()
        {
            InitializeComponent();
        }

        private void tasksTodoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TasksTodoPage.Show();
        }
    }
}
