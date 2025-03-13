using BookHaven.Repositories;
using BookHaven.Services;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;

        public Login(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _authService = serviceProvider.GetRequiredService<IAuthService>();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += Login_FormClosing;

            txtPassword.UseSystemPasswordChar = true;
            txtUsername.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_authService.Login(username, password))
            {
                this.Hide();
                var dashboard = new BookHaven.Forms.Dashboard.Dashboard(_serviceProvider);
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
