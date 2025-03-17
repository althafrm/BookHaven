namespace BookHaven.Forms.Users
{
    partial class Users
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
            gbUserList = new GroupBox();
            lblPageInfo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gridUsers = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            cmbRole = new ComboBox();
            lblRole = new Label();
            lblIdValue = new Label();
            lblId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            gbManageUser = new GroupBox();
            txtUsername = new TextBox();
            lblUsername = new Label();
            gbUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            gbManageUser.SuspendLayout();
            SuspendLayout();
            // 
            // gbUserList
            // 
            gbUserList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbUserList.Controls.Add(lblPageInfo);
            gbUserList.Controls.Add(txtSearch);
            gbUserList.Controls.Add(btnSearch);
            gbUserList.Controls.Add(gridUsers);
            gbUserList.Controls.Add(btnPrevious);
            gbUserList.Controls.Add(btnNext);
            gbUserList.Location = new Point(10, 8);
            gbUserList.Name = "gbUserList";
            gbUserList.Size = new Size(936, 300);
            gbUserList.TabIndex = 5;
            gbUserList.TabStop = false;
            gbUserList.Text = "User List";
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
            // gridUsers
            // 
            gridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Bottom;
            gridUsers.Location = new Point(3, 62);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(930, 235);
            gridUsers.TabIndex = 5;
            gridUsers.CellClick += gridUsers_CellClick;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(654, 26);
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
            btnNext.Location = new Point(795, 26);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(170, 125);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(180, 27);
            txtPassword.TabIndex = 10;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(576, 125);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(180, 27);
            txtConfirmPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 128);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(412, 128);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(127, 20);
            lblConfirmPassword.TabIndex = 9;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(576, 82);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(180, 28);
            cmbRole.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(412, 85);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(39, 20);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role";
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
            // gbManageUser
            // 
            gbManageUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageUser.Controls.Add(txtUsername);
            gbManageUser.Controls.Add(txtPassword);
            gbManageUser.Controls.Add(txtConfirmPassword);
            gbManageUser.Controls.Add(lblUsername);
            gbManageUser.Controls.Add(lblPassword);
            gbManageUser.Controls.Add(lblConfirmPassword);
            gbManageUser.Controls.Add(cmbRole);
            gbManageUser.Controls.Add(lblRole);
            gbManageUser.Controls.Add(lblIdValue);
            gbManageUser.Controls.Add(lblId);
            gbManageUser.Controls.Add(btnClear);
            gbManageUser.Controls.Add(btnDelete);
            gbManageUser.Controls.Add(btnSave);
            gbManageUser.Location = new Point(10, 314);
            gbManageUser.Name = "gbManageUser";
            gbManageUser.Size = new Size(936, 330);
            gbManageUser.TabIndex = 4;
            gbManageUser.TabStop = false;
            gbManageUser.Text = "Manage User";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(170, 82);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 27);
            txtUsername.TabIndex = 10;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 85);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username";
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbUserList);
            Controls.Add(gbManageUser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Users";
            Text = "Users";
            gbUserList.ResumeLayout(false);
            gbUserList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            gbManageUser.ResumeLayout(false);
            gbManageUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUserList;
        private Label lblPageInfo;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridUsers;
        private Button btnPrevious;
        private Button btnNext;
        private NumericUpDown numStock;
        private NumericUpDown numPrice;
        private Label lblStock;
        private Label lblPrice;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtTitle;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblTitle;
        private ComboBox cmbRole;
        private Label lblRole;
        private Label lblIdValue;
        private Label lblId;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private GroupBox gbManageUser;
        private TextBox txtUsername;
        private Label lblUsername;
    }
}