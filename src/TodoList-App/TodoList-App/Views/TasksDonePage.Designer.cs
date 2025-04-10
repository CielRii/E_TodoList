namespace TodoList_App
{
    partial class TasksDonePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksDonePage));
            this.tasksTodoBtn = new System.Windows.Forms.Button();
            this.tasksDoneTitle = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.tasksDoneList = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksTodoBtn
            // 
            this.tasksTodoBtn.Location = new System.Drawing.Point(626, 405);
            this.tasksTodoBtn.Name = "tasksTodoBtn";
            this.tasksTodoBtn.Size = new System.Drawing.Size(134, 33);
            this.tasksTodoBtn.TabIndex = 0;
            this.tasksTodoBtn.Text = "<- Voir les tâches à faire";
            this.tasksTodoBtn.UseVisualStyleBackColor = true;
            this.tasksTodoBtn.Click += new System.EventHandler(this.tasksTodoBtn_Click);
            // 
            // tasksDoneTitle
            // 
            this.tasksDoneTitle.AutoSize = true;
            this.tasksDoneTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksDoneTitle.Location = new System.Drawing.Point(265, 68);
            this.tasksDoneTitle.Name = "tasksDoneTitle";
            this.tasksDoneTitle.Size = new System.Drawing.Size(280, 29);
            this.tasksDoneTitle.TabIndex = 1;
            this.tasksDoneTitle.Text = "Historique des tâches :";
            // 
            // closeBtn
            // 
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(547, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(18, 10);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 5;
            this.closeBtn.TabStop = false;
            this.closeBtn.Visible = false;
            // 
            // tasksDoneList
            // 
            this.tasksDoneList.Location = new System.Drawing.Point(270, 116);
            this.tasksDoneList.Name = "tasksDoneList";
            this.tasksDoneList.Size = new System.Drawing.Size(266, 211);
            this.tasksDoneList.TabIndex = 6;
            // 
            // TasksDonePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tasksDoneList);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.tasksDoneTitle);
            this.Controls.Add(this.tasksTodoBtn);
            this.Name = "TasksDonePage";
            this.Text = "TasksDonePage";
            this.Activated += new System.EventHandler(this.TasksDonePage_Activated);
            this.Load += new System.EventHandler(this.TasksDonePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tasksTodoBtn;
        private System.Windows.Forms.Label tasksDoneTitle;
        private System.Windows.Forms.PictureBox closeBtn;
        public System.Windows.Forms.Panel tasksDoneList;
    }
}