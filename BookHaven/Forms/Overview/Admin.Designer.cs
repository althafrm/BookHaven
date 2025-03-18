namespace BookHaven.Forms.Overview
{
    partial class Admin
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
            gbLabel = new GroupBox();
            lblLowStockBooks = new Label();
            lblActiveCustomers = new Label();
            lblTotalCustomers = new Label();
            lblTotalOrders = new Label();
            lblTotalSales = new Label();
            gbGrid = new GroupBox();
            gridStaffPerformance = new DataGridView();
            gbLabel.SuspendLayout();
            gbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStaffPerformance).BeginInit();
            SuspendLayout();
            // 
            // gbLabel
            // 
            gbLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbLabel.Controls.Add(lblLowStockBooks);
            gbLabel.Controls.Add(lblActiveCustomers);
            gbLabel.Controls.Add(lblTotalCustomers);
            gbLabel.Controls.Add(lblTotalOrders);
            gbLabel.Controls.Add(lblTotalSales);
            gbLabel.Location = new Point(0, 0);
            gbLabel.Name = "gbLabel";
            gbLabel.Size = new Size(957, 240);
            gbLabel.TabIndex = 0;
            gbLabel.TabStop = false;
            gbLabel.Text = "Overview";
            // 
            // lblLowStockBooks
            // 
            lblLowStockBooks.AutoSize = true;
            lblLowStockBooks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLowStockBooks.Location = new Point(12, 196);
            lblLowStockBooks.Name = "lblLowStockBooks";
            lblLowStockBooks.Size = new Size(182, 28);
            lblLowStockBooks.TabIndex = 1;
            lblLowStockBooks.Text = "Low Stock Books: ";
            // 
            // lblActiveCustomers
            // 
            lblActiveCustomers.AutoSize = true;
            lblActiveCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblActiveCustomers.Location = new Point(443, 112);
            lblActiveCustomers.Name = "lblActiveCustomers";
            lblActiveCustomers.Size = new Size(328, 28);
            lblActiveCustomers.TabIndex = 1;
            lblActiveCustomers.Text = "Active Customers (Last 30 Days): ";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalCustomers.Location = new Point(12, 112);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(175, 28);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "Total Customers: ";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalOrders.Location = new Point(443, 36);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(139, 28);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "Total Orders: ";
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalSales.Location = new Point(12, 36);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(264, 28);
            lblTotalSales.TabIndex = 1;
            lblTotalSales.Text = "Total Sales (Last 30 Days): ";
            // 
            // gbGrid
            // 
            gbGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbGrid.Controls.Add(gridStaffPerformance);
            gbGrid.Location = new Point(0, 246);
            gbGrid.Name = "gbGrid";
            gbGrid.Size = new Size(957, 405);
            gbGrid.TabIndex = 0;
            gbGrid.TabStop = false;
            gbGrid.Text = "Staff Performance";
            // 
            // gridStaffPerformance
            // 
            gridStaffPerformance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridStaffPerformance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridStaffPerformance.Dock = DockStyle.Bottom;
            gridStaffPerformance.Location = new Point(3, 26);
            gridStaffPerformance.MultiSelect = false;
            gridStaffPerformance.Name = "gridStaffPerformance";
            gridStaffPerformance.RowHeadersWidth = 51;
            gridStaffPerformance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridStaffPerformance.Size = new Size(951, 376);
            gridStaffPerformance.TabIndex = 1;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbGrid);
            Controls.Add(gbLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin";
            Text = "Admin";
            gbLabel.ResumeLayout(false);
            gbLabel.PerformLayout();
            gbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridStaffPerformance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbLabel;
        private GroupBox gbGrid;
        private Label lblLowStockBooks;
        private Label lblActiveCustomers;
        private Label lblTotalCustomers;
        private Label lblTotalOrders;
        private Label lblTotalSales;
        private DataGridView gridStaffPerformance;
    }
}