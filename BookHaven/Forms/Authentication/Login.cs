using BookHaven.Repositories;
using BookHaven.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms.Authentication
{
    public partial class Login : Form
    {
        private readonly IUserService _userService;

        public Login()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());

            txtPassword.UseSystemPasswordChar = true;
            txtUsername.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_userService.Login(username, password))
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new BookHaven.Forms.Dashboard.Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
