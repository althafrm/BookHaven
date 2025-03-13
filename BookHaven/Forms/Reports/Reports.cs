using BookHaven.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms.Reports
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();

            if (SessionManager.UserRole != "Admin")
            {
                MessageBox.Show("Access Denied. Only Admins can view reports.", "Unauthorized Access",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
