
namespace SignalRServer.Tests
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.senMessageAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(12, 12);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(271, 23);
            this.usernameTB.TabIndex = 6;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(12, 41);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(271, 23);
            this.passwordTB.TabIndex = 7;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(11, 70);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(272, 23);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 99);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(272, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click_1);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(11, 160);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(271, 23);
            this.messageBox.TabIndex = 10;
            // 
            // senMessageAll
            // 
            this.senMessageAll.Location = new System.Drawing.Point(10, 189);
            this.senMessageAll.Name = "senMessageAll";
            this.senMessageAll.Size = new System.Drawing.Size(272, 23);
            this.senMessageAll.TabIndex = 11;
            this.senMessageAll.Text = "Send All";
            this.senMessageAll.UseVisualStyleBackColor = true;
            this.senMessageAll.Click += new System.EventHandler(this.senMessageAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 262);
            this.Controls.Add(this.senMessageAll);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button senMessageAll;
    }
}

