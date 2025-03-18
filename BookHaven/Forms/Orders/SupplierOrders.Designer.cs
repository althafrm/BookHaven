namespace BookHaven.Forms.Orders
{
    partial class SupplierOrders
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
            gbManageSupplierOrder = new GroupBox();
            gridSupplierOrderDetails = new DataGridView();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbOrderStatus = new ComboBox();
            cmbSupplier = new ComboBox();
            cmbBook = new ComboBox();
            lblOrderStatus = new Label();
            lblSupplier = new Label();
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
            btnDelete = new Button();
            btnSave = new Button();
            lblPageInfo = new Label();
            gridSupplierOrders = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            gbSupplierOrdersList = new GroupBox();
            gbManageSupplierOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSupplierOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSupplierOrders).BeginInit();
            gbSupplierOrdersList.SuspendLayout();
            SuspendLayout();
            // 
            // gbManageSupplierOrder
            // 
            gbManageSupplierOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageSupplierOrder.Controls.Add(gridSupplierOrderDetails);
            gbManageSupplierOrder.Controls.Add(numQuantity);
            gbManageSupplierOrder.Controls.Add(lblQuantity);
            gbManageSupplierOrder.Controls.Add(cmbOrderStatus);
            gbManageSupplierOrder.Controls.Add(cmbSupplier);
            gbManageSupplierOrder.Controls.Add(cmbBook);
            gbManageSupplierOrder.Controls.Add(lblOrderStatus);
            gbManageSupplierOrder.Controls.Add(lblSupplier);
            gbManageSupplierOrder.Controls.Add(lblBook);
            gbManageSupplierOrder.Controls.Add(lblOrderIdValue);
            gbManageSupplierOrder.Controls.Add(lblOrderDateValue);
            gbManageSupplierOrder.Controls.Add(lblPriceValue);
            gbManageSupplierOrder.Controls.Add(lblTotalAmountValue);
            gbManageSupplierOrder.Controls.Add(lblUserIdValue);
            gbManageSupplierOrder.Controls.Add(lblOrderId);
            gbManageSupplierOrder.Controls.Add(lblOrderDate);
            gbManageSupplierOrder.Controls.Add(lblPrice);
            gbManageSupplierOrder.Controls.Add(lblTotalAmount);
            gbManageSupplierOrder.Controls.Add(lblUserId);
            gbManageSupplierOrder.Controls.Add(btnClear);
            gbManageSupplierOrder.Controls.Add(btnDelete);
            gbManageSupplierOrder.Controls.Add(btnSave);
            gbManageSupplierOrder.Location = new Point(10, 314);
            gbManageSupplierOrder.Name = "gbManageSupplierOrder";
            gbManageSupplierOrder.Size = new Size(936, 330);
            gbManageSupplierOrder.TabIndex = 8;
            gbManageSupplierOrder.TabStop = false;
            gbManageSupplierOrder.Text = "Manage Supplier Order";
            // 
            // gridSupplierOrderDetails
            // 
            gridSupplierOrderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridSupplierOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSupplierOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSupplierOrderDetails.Location = new Point(472, 33);
            gridSupplierOrderDetails.MultiSelect = false;
            gridSupplierOrderDetails.Name = "gridSupplierOrderDetails";
            gridSupplierOrderDetails.RowHeadersWidth = 51;
            gridSupplierOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSupplierOrderDetails.Size = new Size(458, 141);
            gridSupplierOrderDetails.TabIndex = 11;
            gridSupplierOrderDetails.CellClick += gridSupplierOrderDetails_CellClick;
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
            // cmbOrderStatus
            // 
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Location = new Point(574, 217);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(180, 28);
            cmbOrderStatus.TabIndex = 8;
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(171, 57);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(180, 28);
            cmbSupplier.TabIndex = 8;
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
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Location = new Point(410, 220);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(91, 20);
            lblOrderStatus.TabIndex = 7;
            lblOrderStatus.Text = "Order Status";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(7, 60);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(64, 20);
            lblSupplier.TabIndex = 7;
            lblSupplier.Text = "Supplier";
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
            // gridSupplierOrders
            // 
            gridSupplierOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSupplierOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSupplierOrders.Dock = DockStyle.Bottom;
            gridSupplierOrders.Location = new Point(3, 62);
            gridSupplierOrders.MultiSelect = false;
            gridSupplierOrders.Name = "gridSupplierOrders";
            gridSupplierOrders.RowHeadersWidth = 51;
            gridSupplierOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSupplierOrders.Size = new Size(930, 235);
            gridSupplierOrders.TabIndex = 5;
            gridSupplierOrders.CellClick += gridSupplierOrders_CellClick;
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
            // gbSupplierOrdersList
            // 
            gbSupplierOrdersList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSupplierOrdersList.Controls.Add(lblPageInfo);
            gbSupplierOrdersList.Controls.Add(gridSupplierOrders);
            gbSupplierOrdersList.Controls.Add(btnPrevious);
            gbSupplierOrdersList.Controls.Add(btnNext);
            gbSupplierOrdersList.Location = new Point(10, 8);
            gbSupplierOrdersList.Name = "gbSupplierOrdersList";
            gbSupplierOrdersList.Size = new Size(936, 300);
            gbSupplierOrdersList.TabIndex = 9;
            gbSupplierOrdersList.TabStop = false;
            gbSupplierOrdersList.Text = "Supplier Orders List";
            // 
            // SupplierOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbManageSupplierOrder);
            Controls.Add(gbSupplierOrdersList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SupplierOrders";
            Text = "SupplierOrders";
            gbManageSupplierOrder.ResumeLayout(false);
            gbManageSupplierOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSupplierOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSupplierOrders).EndInit();
            gbSupplierOrdersList.ResumeLayout(false);
            gbSupplierOrdersList.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDeliveryAddress;
        private GroupBox gbManageSupplierOrder;
        private DataGridView gridSupplierOrderDetails;
        private NumericUpDown numQuantity;
        private Label lblQuantity;
        private ComboBox cmbOrderStatus;
        private ComboBox cmbCustomer;
        private ComboBox cmbBook;
        private Label lblDeliveryAddress;
        private Label lblOrderStatus;
        private Label lblSupplier;
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
        private Button btnDelete;
        private Button btnSave;
        private Label lblPageInfo;
        private DataGridView gridSupplierOrders;
        private Button btnPrevious;
        private Button btnNext;
        private GroupBox gbSupplierOrdersList;
        private ComboBox cmbSupplier;
    }
}