namespace BookHaven.Forms.Dashboard
{
    partial class Dashboard
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
            lblBookHaven = new Label();
            panelSidebar = new Panel();
            btnOrders = new Button();
            btnSales = new Button();
            btnSuppliers = new Button();
            btnCustomers = new Button();
            btnGenres = new Button();
            btnLogout = new Button();
            btnManageBooks = new Button();
            btnHome = new Button();
            lblGreeting = new Label();
            panelContainer = new Panel();
            btnUsers = new Button();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // lblBookHaven
            // 
            lblBookHaven.AutoSize = true;
            lblBookHaven.Location = new Point(12, 9);
            lblBookHaven.Name = "lblBookHaven";
            lblBookHaven.Size = new Size(85, 20);
            lblBookHaven.TabIndex = 0;
            lblBookHaven.Text = "BookHaven";
            // 
            // panelSidebar
            // 
            panelSidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelSidebar.Controls.Add(btnUsers);
            panelSidebar.Controls.Add(btnOrders);
            panelSidebar.Controls.Add(btnSales);
            panelSidebar.Controls.Add(btnSuppliers);
            panelSidebar.Controls.Add(btnCustomers);
            panelSidebar.Controls.Add(btnGenres);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnManageBooks);
            panelSidebar.Controls.Add(btnHome);
            panelSidebar.Controls.Add(lblGreeting);
            panelSidebar.Controls.Add(lblBookHaven);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 700);
            panelSidebar.TabIndex = 1;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(12, 394);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(235, 40);
            btnOrders.TabIndex = 7;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnSales
            // 
            btnSales.Location = new Point(12, 348);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(235, 40);
            btnSales.TabIndex = 6;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(12, 302);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(235, 40);
            btnSuppliers.TabIndex = 5;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(12, 256);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(235, 40);
            btnCustomers.TabIndex = 4;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnGenres
            // 
            btnGenres.Location = new Point(12, 210);
            btnGenres.Name = "btnGenres";
            btnGenres.Size = new Size(235, 40);
            btnGenres.TabIndex = 2;
            btnGenres.Text = "Book Genres";
            btnGenres.UseVisualStyleBackColor = true;
            btnGenres.Click += btnGenres_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogout.Location = new Point(12, 662);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(235, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageBooks
            // 
            btnManageBooks.Location = new Point(12, 164);
            btnManageBooks.Name = "btnManageBooks";
            btnManageBooks.Size = new Size(235, 40);
            btnManageBooks.TabIndex = 2;
            btnManageBooks.Text = "Books";
            btnManageBooks.UseVisualStyleBackColor = true;
            btnManageBooks.Click += btnManageBooks_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(12, 118);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(235, 40);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Location = new Point(12, 49);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(57, 20);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "Hi User";
            // 
            // panelContainer
            // 
            panelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContainer.Location = new Point(256, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(975, 700);
            panelContainer.TabIndex = 1;
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(12, 440);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(235, 40);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 703);
            Controls.Add(panelContainer);
            Controls.Add(panelSidebar);
            Name = "Dashboard";
            Text = "Dashboard";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBookHaven;
        private Panel panelSidebar;
        private Panel panelContainer;
        private Label lblGreeting;
        private Button btnManageBooks;
        private Button btnHome;
        private Button btnLogout;
        private Button btnGenres;
        private Button btnCustomers;
        private Button btnSuppliers;
        private Button btnSales;
        private Button btnOrders;
        private Button btnUsers;
    }
}