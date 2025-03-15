namespace BookHaven.Forms.Customers
{
    partial class Customers
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
            lblPageInfo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gridCustomers = new DataGridView();
            btnNext = new Button();
            gbCustomerList = new GroupBox();
            btnPrevious = new Button();
            txtAddress = new TextBox();
            lblPhone = new Label();
            lblAddress = new Label();
            lblName = new Label();
            gbManageCustomer = new GroupBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtName = new TextBox();
            lblEmail = new Label();
            lblIdValue = new Label();
            lblId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)gridCustomers).BeginInit();
            gbCustomerList.SuspendLayout();
            gbManageCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(542, 30);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(79, 20);
            lblPageInfo.TabIndex = 10;
            lblPageInfo.Text = "Page - of -";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(270, 27);
            txtSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(282, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // gridCustomers
            // 
            gridCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCustomers.Dock = DockStyle.Bottom;
            gridCustomers.Location = new Point(3, 62);
            gridCustomers.MultiSelect = false;
            gridCustomers.Name = "gridCustomers";
            gridCustomers.RowHeadersWidth = 51;
            gridCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCustomers.Size = new Size(930, 235);
            gridCustomers.TabIndex = 5;
            gridCustomers.CellClick += gridCustomers_CellClick;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(795, 27);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // gbCustomerList
            // 
            gbCustomerList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbCustomerList.Controls.Add(lblPageInfo);
            gbCustomerList.Controls.Add(txtSearch);
            gbCustomerList.Controls.Add(btnSearch);
            gbCustomerList.Controls.Add(gridCustomers);
            gbCustomerList.Controls.Add(btnPrevious);
            gbCustomerList.Controls.Add(btnNext);
            gbCustomerList.Location = new Point(10, 8);
            gbCustomerList.Name = "gbCustomerList";
            gbCustomerList.Size = new Size(936, 300);
            gbCustomerList.TabIndex = 5;
            gbCustomerList.TabStop = false;
            gbCustomerList.Text = "Customer List";
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(654, 27);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(135, 29);
            btnPrevious.TabIndex = 7;
            btnPrevious.Text = "< Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(576, 125);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(180, 27);
            txtAddress.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(6, 128);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Phone";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(412, 128);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(6, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 9;
            lblName.Text = "Name";
            // 
            // gbManageCustomer
            // 
            gbManageCustomer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageCustomer.Controls.Add(txtPhone);
            gbManageCustomer.Controls.Add(txtAddress);
            gbManageCustomer.Controls.Add(txtEmail);
            gbManageCustomer.Controls.Add(txtName);
            gbManageCustomer.Controls.Add(lblPhone);
            gbManageCustomer.Controls.Add(lblAddress);
            gbManageCustomer.Controls.Add(lblEmail);
            gbManageCustomer.Controls.Add(lblName);
            gbManageCustomer.Controls.Add(lblIdValue);
            gbManageCustomer.Controls.Add(lblId);
            gbManageCustomer.Controls.Add(btnClear);
            gbManageCustomer.Controls.Add(btnDelete);
            gbManageCustomer.Controls.Add(btnSave);
            gbManageCustomer.Location = new Point(10, 314);
            gbManageCustomer.Name = "gbManageCustomer";
            gbManageCustomer.Size = new Size(936, 330);
            gbManageCustomer.TabIndex = 4;
            gbManageCustomer.TabStop = false;
            gbManageCustomer.Text = "Manage Customer";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(170, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 27);
            txtPhone.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(576, 82);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 27);
            txtEmail.TabIndex = 10;
            // 
            // txtName
            // 
            txtName.Location = new Point(170, 82);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 27);
            txtName.TabIndex = 10;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(412, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
            // 
            // lblIdValue
            // 
            lblIdValue.AutoSize = true;
            lblIdValue.Location = new Point(170, 46);
            lblIdValue.Name = "lblIdValue";
            lblIdValue.Size = new Size(15, 20);
            lblIdValue.TabIndex = 6;
            lblIdValue.Text = "-";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(6, 46);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 5;
            lblId.Text = "Id";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(288, 294);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(147, 294);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 294);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbCustomerList);
            Controls.Add(gbManageCustomer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Customers";
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)gridCustomers).EndInit();
            gbCustomerList.ResumeLayout(false);
            gbCustomerList.PerformLayout();
            gbManageCustomer.ResumeLayout(false);
            gbManageCustomer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblPageInfo;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridCustomers;
        private Button btnNext;
        private GroupBox gbCustomerList;
        private Button btnPrevious;
        private TextBox txtAddress;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblName;
        private GroupBox gbManageCustomer;
        private TextBox txtPhone;
        private TextBox txtName;
        private Label lblIdValue;
        private Label lblId;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private TextBox txtEmail;
        private Label lblEmail;
    }
}