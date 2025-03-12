namespace BookHaven.Forms.Authentication
{
    partial class Login
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
            lblLogin = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(12, 9);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(708, 34);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Login to BookHaven";
            lblLogin.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(198, 148);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(67, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Userame";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(198, 210);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(300, 145);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(197, 27);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(300, 207);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(197, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(403, 272);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 429);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}