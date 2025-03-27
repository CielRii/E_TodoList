namespace TodoList_App
{
    partial class TasksTodoPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksTodoPage));
            this.tasksDoneBtn = new System.Windows.Forms.Button();
            this.tasksTodoTitle = new System.Windows.Forms.Label();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.tasksTodoList = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksDoneBtn
            // 
            this.tasksDoneBtn.Location = new System.Drawing.Point(630, 405);
            this.tasksDoneBtn.Name = "tasksDoneBtn";
            this.tasksDoneBtn.Size = new System.Drawing.Size(134, 33);
            this.tasksDoneBtn.TabIndex = 0;
            this.tasksDoneBtn.Text = "Voir les tâches faites ->";
            this.tasksDoneBtn.UseVisualStyleBackColor = true;
            this.tasksDoneBtn.Click += new System.EventHandler(this.tasksDoneBtn_Click);
            // 
            // tasksTodoTitle
            // 
            this.tasksTodoTitle.AutoSize = true;
            this.tasksTodoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksTodoTitle.Location = new System.Drawing.Point(229, 57);
            this.tasksTodoTitle.Name = "tasksTodoTitle";
            this.tasksTodoTitle.Size = new System.Drawing.Size(358, 29);
            this.tasksTodoTitle.TabIndex = 1;
            this.tasksTodoTitle.Text = "Votre liste des tâches à faire :";
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(45, 354);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(149, 57);
            this.addTaskBtn.TabIndex = 2;
            this.addTaskBtn.Text = "Ajouter une nouvelle tâche";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // tasksTodoList
            // 
            this.tasksTodoList.Location = new System.Drawing.Point(216, 119);
            this.tasksTodoList.Name = "tasksTodoList";
            this.tasksTodoList.Size = new System.Drawing.Size(414, 214);
            this.tasksTodoList.TabIndex = 3;
            // 
            // closeBtn
            // 
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(612, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(18, 10);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 4;
            this.closeBtn.TabStop = false;
            this.closeBtn.Visible = false;
            // 
            // TasksTodoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.tasksTodoList);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.tasksTodoTitle);
            this.Controls.Add(this.tasksDoneBtn);
            this.Name = "TasksTodoPage";
            this.Text = "TasksTodoPage";
            this.Load += new System.EventHandler(this.TasksTodoPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tasksDoneBtn;
        private System.Windows.Forms.Label tasksTodoTitle;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.Panel tasksTodoList;
        private System.Windows.Forms.PictureBox closeBtn;
    }
}