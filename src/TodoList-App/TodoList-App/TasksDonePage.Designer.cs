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
            this.tasksTodoBtn = new System.Windows.Forms.Button();
            this.tasksDoneList = new System.Windows.Forms.Label();
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
            // tasksDoneList
            // 
            this.tasksDoneList.AutoSize = true;
            this.tasksDoneList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksDoneList.Location = new System.Drawing.Point(265, 68);
            this.tasksDoneList.Name = "tasksDoneList";
            this.tasksDoneList.Size = new System.Drawing.Size(280, 29);
            this.tasksDoneList.TabIndex = 1;
            this.tasksDoneList.Text = "Historique des tâches :";
            // 
            // TasksDonePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tasksDoneList);
            this.Controls.Add(this.tasksTodoBtn);
            this.Name = "TasksDonePage";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tasksTodoBtn;
        private System.Windows.Forms.Label tasksDoneList;
    }
}