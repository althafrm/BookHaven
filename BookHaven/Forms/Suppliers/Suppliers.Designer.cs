namespace BookHaven.Forms.Suppliers
{
    partial class Suppliers
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
            gbSupplierList = new GroupBox();
            lblPageInfo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gridSuppliers = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            txtEmail = new TextBox();
            txtName = new TextBox();
            lblEmail = new Label();
            lblName = new Label();
            lblIdValue = new Label();
            lblId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            gbManageSupplier = new GroupBox();
            txtPhone = new TextBox();
            txtContact = new TextBox();
            txtAddress = new TextBox();
            lblPhone = new Label();
            lblContact = new Label();
            lblAddress = new Label();
            gbSupplierList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).BeginInit();
            gbManageSupplier.SuspendLayout();
            SuspendLayout();
            // 
            // gbSupplierList
            // 
            gbSupplierList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSupplierList.Controls.Add(lblPageInfo);
            gbSupplierList.Controls.Add(txtSearch);
            gbSupplierList.Controls.Add(btnSearch);
            gbSupplierList.Controls.Add(gridSuppliers);
            gbSupplierList.Controls.Add(btnPrevious);
            gbSupplierList.Controls.Add(btnNext);
            gbSupplierList.Location = new Point(10, 12);
            gbSupplierList.Name = "gbSupplierList";
            gbSupplierList.Size = new Size(936, 300);
            gbSupplierList.TabIndex = 5;
            gbSupplierList.TabStop = false;
            gbSupplierList.Text = "Supplier List";
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
            // gridSuppliers
            // 
            gridSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSuppliers.Dock = DockStyle.Bottom;
            gridSuppliers.Location = new Point(3, 62);
            gridSuppliers.MultiSelect = false;
            gridSuppliers.Name = "gridSuppliers";
            gridSuppliers.RowHeadersWidth = 51;
            gridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSuppliers.Size = new Size(930, 235);
            gridSuppliers.TabIndex = 5;
            gridSuppliers.CellClick += gridSuppliers_CellClick;
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
            // txtEmail
            // 
            txtEmail.Location = new Point(170, 125);
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
            lblEmail.Location = new Point(6, 128);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
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
            // gbManageSupplier
            // 
            gbManageSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageSupplier.Controls.Add(txtPhone);
            gbManageSupplier.Controls.Add(txtContact);
            gbManageSupplier.Controls.Add(txtAddress);
            gbManageSupplier.Controls.Add(txtEmail);
            gbManageSupplier.Controls.Add(txtName);
            gbManageSupplier.Controls.Add(lblPhone);
            gbManageSupplier.Controls.Add(lblContact);
            gbManageSupplier.Controls.Add(lblAddress);
            gbManageSupplier.Controls.Add(lblEmail);
            gbManageSupplier.Controls.Add(lblName);
            gbManageSupplier.Controls.Add(lblIdValue);
            gbManageSupplier.Controls.Add(lblId);
            gbManageSupplier.Controls.Add(btnClear);
            gbManageSupplier.Controls.Add(btnDelete);
            gbManageSupplier.Controls.Add(btnSave);
            gbManageSupplier.Location = new Point(10, 314);
            gbManageSupplier.Name = "gbManageSupplier";
            gbManageSupplier.Size = new Size(936, 330);
            gbManageSupplier.TabIndex = 4;
            gbManageSupplier.TabStop = false;
            gbManageSupplier.Text = "Manage Supplier";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(576, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 27);
            txtPhone.TabIndex = 10;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(576, 82);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(180, 27);
            txtContact.TabIndex = 10;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(170, 171);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(180, 27);
            txtAddress.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(412, 128);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Phone";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(412, 85);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(107, 20);
            lblContact.TabIndex = 9;
            lblContact.Text = "Contact Person";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(6, 174);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address";
            // 
            // Suppliers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbSupplierList);
            Controls.Add(gbManageSupplier);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Suppliers";
            Text = "Suppliers";
            gbSupplierList.ResumeLayout(false);
            gbSupplierList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).EndInit();
            gbManageSupplier.ResumeLayout(false);
            gbManageSupplier.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbSupplierList;
        private Label lblPageInfo;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridSuppliers;
        private Button btnPrevious;
        private Button btnNext;
        private TextBox txtEmail;
        private TextBox txtName;
        private Label lblEmail;
        private Label lblName;
        private Label lblIdValue;
        private Label lblId;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private GroupBox gbManageSupplier;
        private TextBox txtPhone;
        private TextBox txtContact;
        private Label lblPhone;
        private Label lblContact;
        private TextBox txtAddress;
        private Label lblAddress;
    }
}