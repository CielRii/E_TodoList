namespace TodoList_App
{
    partial class AddTaskPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.requestMessageAddTask = new System.Windows.Forms.Label();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.addTaskInsert = new System.Windows.Forms.TextBox();
            this.tasksTodoBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestMessageAddTask
            // 
            this.requestMessageAddTask.AutoSize = true;
            this.requestMessageAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestMessageAddTask.Location = new System.Drawing.Point(228, 58);
            this.requestMessageAddTask.Name = "requestMessageAddTask";
            this.requestMessageAddTask.Size = new System.Drawing.Size(383, 29);
            this.requestMessageAddTask.TabIndex = 0;
            this.requestMessageAddTask.Text = "Veuillez saisir la tâche à ajouter";
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(451, 181);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(124, 23);
            this.addTaskBtn.TabIndex = 1;
            this.addTaskBtn.Text = "Ajouter la tâche";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // addTaskInsert
            // 
            this.addTaskInsert.Location = new System.Drawing.Point(299, 181);
            this.addTaskInsert.Name = "addTaskInsert";
            this.addTaskInsert.Size = new System.Drawing.Size(100, 20);
            this.addTaskInsert.TabIndex = 2;
            this.addTaskInsert.WordWrap = false;
            // 
            // tasksTodoBtn
            // 
            this.tasksTodoBtn.Location = new System.Drawing.Point(626, 405);
            this.tasksTodoBtn.Name = "tasksTodoBtn";
            this.tasksTodoBtn.Size = new System.Drawing.Size(134, 33);
            this.tasksTodoBtn.TabIndex = 3;
            this.tasksTodoBtn.Text = "<- Voir les tâches à faire";
            this.tasksTodoBtn.UseVisualStyleBackColor = true;
            this.tasksTodoBtn.Click += new System.EventHandler(this.tasksTodoBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // AddTaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tasksTodoBtn);
            this.Controls.Add(this.addTaskInsert);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.requestMessageAddTask);
            this.Name = "AddTaskPage";
            this.Text = "AddTaskPage";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label requestMessageAddTask;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.TextBox addTaskInsert;
        private System.Windows.Forms.Button tasksTodoBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}