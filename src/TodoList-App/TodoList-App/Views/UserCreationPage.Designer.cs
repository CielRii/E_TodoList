namespace TodoList_App
{
    partial class UserCreationPage
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
            this.requestMessageCreateAccount = new System.Windows.Forms.Label();
            this.newUserConfirmPasswordInsert = new System.Windows.Forms.TextBox();
            this.createAccountBtn = new System.Windows.Forms.Button();
            this.newUserNameLbl = new System.Windows.Forms.Label();
            this.newUserPasswordLbl = new System.Windows.Forms.Label();
            this.newUserConfirmPasswordLbl = new System.Windows.Forms.Label();
            this.newUserNameInsert = new System.Windows.Forms.TextBox();
            this.newUserPasswordInsert = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // requestMessageCreateAccount
            // 
            this.requestMessageCreateAccount.AutoSize = true;
            this.requestMessageCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestMessageCreateAccount.Location = new System.Drawing.Point(12, 50);
            this.requestMessageCreateAccount.Name = "requestMessageCreateAccount";
            this.requestMessageCreateAccount.Size = new System.Drawing.Size(788, 29);
            this.requestMessageCreateAccount.TabIndex = 0;
            this.requestMessageCreateAccount.Text = "Veuillez saisir les informations ci-dessous pour créer votre compte";
            // 
            // newUserConfirmPasswordInsert
            // 
            this.newUserConfirmPasswordInsert.Location = new System.Drawing.Point(424, 241);
            this.newUserConfirmPasswordInsert.Name = "newUserConfirmPasswordInsert";
            this.newUserConfirmPasswordInsert.Size = new System.Drawing.Size(128, 20);
            this.newUserConfirmPasswordInsert.TabIndex = 1;
            // 
            // createAccountBtn
            // 
            this.createAccountBtn.Location = new System.Drawing.Point(334, 324);
            this.createAccountBtn.Name = "createAccountBtn";
            this.createAccountBtn.Size = new System.Drawing.Size(111, 42);
            this.createAccountBtn.TabIndex = 2;
            this.createAccountBtn.Text = "Créer le compte";
            this.createAccountBtn.UseVisualStyleBackColor = true;
            this.createAccountBtn.Click += new System.EventHandler(this.createAccountBtn_Click);
            // 
            // newUserNameLbl
            // 
            this.newUserNameLbl.AutoSize = true;
            this.newUserNameLbl.Location = new System.Drawing.Point(224, 135);
            this.newUserNameLbl.Name = "newUserNameLbl";
            this.newUserNameLbl.Size = new System.Drawing.Size(90, 13);
            this.newUserNameLbl.TabIndex = 3;
            this.newUserNameLbl.Text = "Nom d\'utilisateur :";
            // 
            // newUserPasswordLbl
            // 
            this.newUserPasswordLbl.AutoSize = true;
            this.newUserPasswordLbl.Location = new System.Drawing.Point(224, 192);
            this.newUserPasswordLbl.Name = "newUserPasswordLbl";
            this.newUserPasswordLbl.Size = new System.Drawing.Size(77, 13);
            this.newUserPasswordLbl.TabIndex = 4;
            this.newUserPasswordLbl.Text = "Mot de passe :";
            // 
            // newUserConfirmPasswordLbl
            // 
            this.newUserConfirmPasswordLbl.AutoSize = true;
            this.newUserConfirmPasswordLbl.Location = new System.Drawing.Point(224, 241);
            this.newUserConfirmPasswordLbl.Name = "newUserConfirmPasswordLbl";
            this.newUserConfirmPasswordLbl.Size = new System.Drawing.Size(152, 13);
            this.newUserConfirmPasswordLbl.TabIndex = 5;
            this.newUserConfirmPasswordLbl.Text = "Confirmation du mot de passe :";
            // 
            // newUserNameInsert
            // 
            this.newUserNameInsert.Location = new System.Drawing.Point(424, 135);
            this.newUserNameInsert.Name = "newUserNameInsert";
            this.newUserNameInsert.Size = new System.Drawing.Size(128, 20);
            this.newUserNameInsert.TabIndex = 6;
            // 
            // newUserPasswordInsert
            // 
            this.newUserPasswordInsert.Location = new System.Drawing.Point(424, 192);
            this.newUserPasswordInsert.Name = "newUserPasswordInsert";
            this.newUserPasswordInsert.Size = new System.Drawing.Size(128, 20);
            this.newUserPasswordInsert.TabIndex = 7;
            // 
            // UserCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newUserPasswordInsert);
            this.Controls.Add(this.newUserNameInsert);
            this.Controls.Add(this.newUserConfirmPasswordLbl);
            this.Controls.Add(this.newUserPasswordLbl);
            this.Controls.Add(this.newUserNameLbl);
            this.Controls.Add(this.createAccountBtn);
            this.Controls.Add(this.newUserConfirmPasswordInsert);
            this.Controls.Add(this.requestMessageCreateAccount);
            this.Name = "UserCreationPage";
            this.Text = "UserCreationPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label requestMessageCreateAccount;
        private System.Windows.Forms.TextBox newUserConfirmPasswordInsert;
        private System.Windows.Forms.Button createAccountBtn;
        private System.Windows.Forms.Label newUserNameLbl;
        private System.Windows.Forms.Label newUserPasswordLbl;
        private System.Windows.Forms.Label newUserConfirmPasswordLbl;
        private System.Windows.Forms.TextBox newUserNameInsert;
        private System.Windows.Forms.TextBox newUserPasswordInsert;
    }
}