namespace BookHaven.Forms.Orders
{
    partial class Orders
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
            gridOrderDetails = new DataGridView();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbBook = new ComboBox();
            lblBook = new Label();
            lblOrderIdValue = new Label();
            lblOrderDateValue = new Label();
            lblPriceValue = new Label();
            lblTotalAmountValue = new Label();
            lblUserIdValue = new Label();
            lblOrderId = new Label();
            lblOrderDate = new Label();
            lblPrice = new Label();
            lblTotalAmount = new Label();
            lblUserId = new Label();
            btnClear = new Button();
            btnSave = new Button();
            lblPageInfo = new Label();
            gridOrders = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            gbOrdersList = new GroupBox();
            gbManageOrder = new GroupBox();
            txtDeliveryAddress = new TextBox();
            cmbOrderStatus = new ComboBox();
            cmbCustomer = new ComboBox();
            lblDeliveryAddress = new Label();
            lblOrderStatus = new Label();
            lblCustomer = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)gridOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridOrders).BeginInit();
            gbOrdersList.SuspendLayout();
            gbManageOrder.SuspendLayout();
            SuspendLayout();
            // 
            // gridOrderDetails
            // 
            gridOrderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrderDetails.Location = new Point(475, 33);
            gridOrderDetails.MultiSelect = false;
            gridOrderDetails.Name = "gridOrderDetails";
            gridOrderDetails.RowHeadersWidth = 51;
            gridOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrderDetails.Size = new Size(458, 141);
            gridOrderDetails.TabIndex = 11;
            gridOrderDetails.CellClick += gridOrderDetails_CellClick;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(171, 246);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(180, 27);
            numQuantity.TabIndex = 12;
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(7, 248);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(65, 20);
            lblQuantity.TabIndex = 11;
            lblQuantity.Text = "Quantity";
            // 
            // cmbBook
            // 
            cmbBook.FormattingEnabled = true;
            cmbBook.Location = new Point(171, 188);
            cmbBook.Name = "cmbBook";
            cmbBook.Size = new Size(180, 28);
            cmbBook.TabIndex = 8;
            cmbBook.SelectedIndexChanged += cmbBook_SelectedIndexChanged;
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(7, 191);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(43, 20);
            lblBook.TabIndex = 7;
            lblBook.Text = "Book";
            // 
            // lblOrderIdValue
            // 
            lblOrderIdValue.AutoSize = true;
            lblOrderIdValue.Location = new Point(171, 86);
            lblOrderIdValue.Name = "lblOrderIdValue";
            lblOrderIdValue.Size = new Size(15, 20);
            lblOrderIdValue.TabIndex = 6;
            lblOrderIdValue.Text = "-";
            // 
            // lblOrderDateValue
            // 
            lblOrderDateValue.AutoSize = true;
            lblOrderDateValue.Location = new Point(171, 113);
            lblOrderDateValue.Name = "lblOrderDateValue";
            lblOrderDateValue.Size = new Size(15, 20);
            lblOrderDateValue.TabIndex = 6;
            lblOrderDateValue.Text = "-";
            // 
            // lblPriceValue
            // 
            lblPriceValue.AutoSize = true;
            lblPriceValue.Location = new Point(171, 220);
            lblPriceValue.Name = "lblPriceValue";
            lblPriceValue.Size = new Size(36, 20);
            lblPriceValue.TabIndex = 6;
            lblPriceValue.Text = "0.00";
            // 
            // lblTotalAmountValue
            // 
            lblTotalAmountValue.AutoSize = true;
            lblTotalAmountValue.Location = new Point(171, 140);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(36, 20);
            lblTotalAmountValue.TabIndex = 6;
            lblTotalAmountValue.Text = "0.00";
            // 
            // lblUserIdValue
            // 
            lblUserIdValue.AutoSize = true;
            lblUserIdValue.Location = new Point(171, 33);
            lblUserIdValue.Name = "lblUserIdValue";
            lblUserIdValue.Size = new Size(15, 20);
            lblUserIdValue.TabIndex = 6;
            lblUserIdValue.Text = "-";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(7, 86);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(64, 20);
            lblOrderId.TabIndex = 5;
            lblOrderId.Text = "Order Id";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(7, 113);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(83, 20);
            lblOrderDate.TabIndex = 5;
            lblOrderDate.Text = "Order Date";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(7, 220);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(7, 140);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(99, 20);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "Total Amount";
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(7, 33);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(55, 20);
            lblUserId.TabIndex = 5;
            lblUserId.Text = "User Id";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(289, 295);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(7, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Order";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
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
            // gridOrders
            // 
            gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrders.Dock = DockStyle.Bottom;
            gridOrders.Location = new Point(3, 62);
            gridOrders.MultiSelect = false;
            gridOrders.Name = "gridOrders";
            gridOrders.RowHeadersWidth = 51;
            gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrders.Size = new Size(930, 235);
            gridOrders.TabIndex = 5;
            gridOrders.CellClick += gridOrders_CellClick;
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
            // gbOrdersList
            // 
            gbOrdersList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbOrdersList.Controls.Add(lblPageInfo);
            gbOrdersList.Controls.Add(gridOrders);
            gbOrdersList.Controls.Add(btnPrevious);
            gbOrdersList.Controls.Add(btnNext);
            gbOrdersList.Location = new Point(10, 8);
            gbOrdersList.Name = "gbOrdersList";
            gbOrdersList.Size = new Size(936, 300);
            gbOrdersList.TabIndex = 7;
            gbOrdersList.TabStop = false;
            gbOrdersList.Text = "Orders List";
            // 
            // gbManageOrder
            // 
            gbManageOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageOrder.Controls.Add(txtDeliveryAddress);
            gbManageOrder.Controls.Add(gridOrderDetails);
            gbManageOrder.Controls.Add(numQuantity);
            gbManageOrder.Controls.Add(lblQuantity);
            gbManageOrder.Controls.Add(cmbOrderStatus);
            gbManageOrder.Controls.Add(cmbCustomer);
            gbManageOrder.Controls.Add(cmbBook);
            gbManageOrder.Controls.Add(lblDeliveryAddress);
            gbManageOrder.Controls.Add(lblOrderStatus);
            gbManageOrder.Controls.Add(lblCustomer);
            gbManageOrder.Controls.Add(lblBook);
            gbManageOrder.Controls.Add(lblOrderIdValue);
            gbManageOrder.Controls.Add(lblOrderDateValue);
            gbManageOrder.Controls.Add(lblPriceValue);
            gbManageOrder.Controls.Add(lblTotalAmountValue);
            gbManageOrder.Controls.Add(lblUserIdValue);
            gbManageOrder.Controls.Add(lblOrderId);
            gbManageOrder.Controls.Add(lblOrderDate);
            gbManageOrder.Controls.Add(lblPrice);
            gbManageOrder.Controls.Add(lblTotalAmount);
            gbManageOrder.Controls.Add(lblUserId);
            gbManageOrder.Controls.Add(btnClear);
            gbManageOrder.Controls.Add(btnDelete);
            gbManageOrder.Controls.Add(btnSave);
            gbManageOrder.Location = new Point(10, 314);
            gbManageOrder.Name = "gbManageOrder";
            gbManageOrder.Size = new Size(936, 330);
            gbManageOrder.TabIndex = 6;
            gbManageOrder.TabStop = false;
            gbManageOrder.Text = "Manage Order";
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.Location = new Point(574, 251);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new Size(240, 27);
            txtDeliveryAddress.TabIndex = 13;
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Location = new Point(574, 217);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(180, 28);
            cmbOrderStatus.TabIndex = 8;
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(171, 57);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(180, 28);
            cmbCustomer.TabIndex = 8;
            // 
            // lblDeliveryAddress
            // 
            lblDeliveryAddress.AutoSize = true;
            lblDeliveryAddress.Location = new Point(410, 253);
            lblDeliveryAddress.Name = "lblDeliveryAddress";
            lblDeliveryAddress.Size = new Size(120, 20);
            lblDeliveryAddress.TabIndex = 7;
            lblDeliveryAddress.Text = "Delivery Address";
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Location = new Point(410, 220);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(91, 20);
            lblOrderStatus.TabIndex = 7;
            lblOrderStatus.Text = "Order Status";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(7, 60);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(72, 20);
            lblCustomer.TabIndex = 7;
            lblCustomer.Text = "Customer";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(148, 295);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete Order";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbOrdersList);
            Controls.Add(gbManageOrder);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Orders";
            Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)gridOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridOrders).EndInit();
            gbOrdersList.ResumeLayout(false);
            gbOrdersList.PerformLayout();
            gbManageOrder.ResumeLayout(false);
            gbManageOrder.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridOrderDetails;
        private NumericUpDown numQuantity;
        private Label lblQuantity;
        private ComboBox cmbBook;
        private Label lblBook;
        private Label lblOrderIdValue;
        private Label lblOrderDateValue;
        private Label lblPriceValue;
        private Label lblTotalAmountValue;
        private Label lblUserIdValue;
        private Label lblOrderId;
        private Label lblOrderDate;
        private Label lblPrice;
        private Label lblTotalAmount;
        private Label lblUserId;
        private Button btnClear;
        private Button btnSave;
        private Label lblPageInfo;
        private DataGridView gridOrders;
        private Button btnPrevious;
        private Button btnNext;
        private GroupBox gbOrdersList;
        private GroupBox gbManageOrder;
        private Button btnDelete;
        private ComboBox cmbOrderStatus;
        private Label lblOrderStatus;
        private TextBox txtDeliveryAddress;
        private Label lblDeliveryAddress;
        private ComboBox cmbCustomer;
        private Label lblCustomer;
    }
}