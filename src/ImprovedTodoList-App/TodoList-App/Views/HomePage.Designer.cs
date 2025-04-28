namespace TodoList_App
{
    partial class HomePage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.connexionBtn = new System.Windows.Forms.Button();
            this.userNameInsert = new System.Windows.Forms.TextBox();
            this.introMessage = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.passwordInsert = new System.Windows.Forms.TextBox();
            this.createAccountBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connexionBtn
            // 
            this.connexionBtn.Location = new System.Drawing.Point(328, 320);
            this.connexionBtn.Name = "connexionBtn";
            this.connexionBtn.Size = new System.Drawing.Size(103, 38);
            this.connexionBtn.TabIndex = 0;
            this.connexionBtn.Text = "Connexion";
            this.connexionBtn.UseVisualStyleBackColor = true;
            this.connexionBtn.Click += new System.EventHandler(this.connexionBtn_Click);
            // 
            // userNameInsert
            // 
            this.userNameInsert.Location = new System.Drawing.Point(342, 147);
            this.userNameInsert.Name = "userNameInsert";
            this.userNameInsert.Size = new System.Drawing.Size(128, 20);
            this.userNameInsert.TabIndex = 1;
            // 
            // introMessage
            // 
            this.introMessage.AutoSize = true;
            this.introMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introMessage.Location = new System.Drawing.Point(38, 51);
            this.introMessage.Name = "introMessage";
            this.introMessage.Size = new System.Drawing.Size(741, 29);
            this.introMessage.TabIndex = 2;
            this.introMessage.Text = "Bonjour, merci de vous connecter pour utliser cette application";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(240, 204);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(77, 13);
            this.passwordLbl.TabIndex = 3;
            this.passwordLbl.Text = "Mot de passe :";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(240, 147);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(90, 13);
            this.userNameLbl.TabIndex = 4;
            this.userNameLbl.Text = "Nom d\'utilisateur :";
            // 
            // passwordInsert
            // 
            this.passwordInsert.Location = new System.Drawing.Point(342, 204);
            this.passwordInsert.Name = "passwordInsert";
            this.passwordInsert.Size = new System.Drawing.Size(128, 20);
            this.passwordInsert.TabIndex = 5;
            // 
            // createAccountBtn
            // 
            this.createAccountBtn.Location = new System.Drawing.Point(602, 320);
            this.createAccountBtn.Name = "createAccountBtn";
            this.createAccountBtn.Size = new System.Drawing.Size(88, 38);
            this.createAccountBtn.TabIndex = 6;
            this.createAccountBtn.Text = "Nouvel utilisateur ?";
            this.createAccountBtn.UseVisualStyleBackColor = true;
            this.createAccountBtn.Click += new System.EventHandler(this.createAccountBtn_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createAccountBtn);
            this.Controls.Add(this.passwordInsert);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.introMessage);
            this.Controls.Add(this.userNameInsert);
            this.Controls.Add(this.connexionBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.Text = "Todo App";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connexionBtn;
        private System.Windows.Forms.TextBox userNameInsert;
        private System.Windows.Forms.Label introMessage;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox passwordInsert;
        private System.Windows.Forms.Button createAccountBtn;
    }
}

