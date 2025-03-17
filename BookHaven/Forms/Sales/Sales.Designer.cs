namespace BookHaven.Forms.Sales
{
    partial class Sales
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
            gbSalesList = new GroupBox();
            lblPageInfo = new Label();
            gridSales = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbBook = new ComboBox();
            lblBook = new Label();
            lblUserIdValue = new Label();
            lblUserId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            gbManageSale = new GroupBox();
            gridSalesDetails = new DataGridView();
            numDiscount = new NumericUpDown();
            lblDiscount = new Label();
            lblSaleIdValue = new Label();
            lblSaleDateValue = new Label();
            lblPriceValue = new Label();
            lblTotalAmountValue = new Label();
            lblSaleId = new Label();
            lblSaleDate = new Label();
            lblPrice = new Label();
            lblTotalAmount = new Label();
            gbSalesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            gbManageSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSalesDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // gbSalesList
            // 
            gbSalesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSalesList.Controls.Add(lblPageInfo);
            gbSalesList.Controls.Add(gridSales);
            gbSalesList.Controls.Add(btnPrevious);
            gbSalesList.Controls.Add(btnNext);
            gbSalesList.Location = new Point(10, 8);
            gbSalesList.Name = "gbSalesList";
            gbSalesList.Size = new Size(936, 300);
            gbSalesList.TabIndex = 5;
            gbSalesList.TabStop = false;
            gbSalesList.Text = "Sales List";
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
            // gridSales
            // 
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSales.Dock = DockStyle.Bottom;
            gridSales.Location = new Point(3, 62);
            gridSales.MultiSelect = false;
            gridSales.Name = "gridSales";
            gridSales.RowHeadersWidth = 51;
            gridSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSales.Size = new Size(930, 235);
            gridSales.TabIndex = 5;
            gridSales.CellClick += gridSales_CellClick;
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
            // numQuantity
            // 
            numQuantity.Location = new Point(170, 255);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(180, 27);
            numQuantity.TabIndex = 12;
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(6, 257);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(65, 20);
            lblQuantity.TabIndex = 11;
            lblQuantity.Text = "Quantity";
            // 
            // cmbBook
            // 
            cmbBook.FormattingEnabled = true;
            cmbBook.Location = new Point(170, 195);
            cmbBook.Name = "cmbBook";
            cmbBook.Size = new Size(180, 28);
            cmbBook.TabIndex = 8;
            cmbBook.SelectedIndexChanged += cmbBook_SelectedIndexChanged;
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(6, 198);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(43, 20);
            lblBook.TabIndex = 7;
            lblBook.Text = "Book";
            // 
            // lblUserIdValue
            // 
            lblUserIdValue.AutoSize = true;
            lblUserIdValue.Location = new Point(170, 33);
            lblUserIdValue.Name = "lblUserIdValue";
            lblUserIdValue.Size = new Size(15, 20);
            lblUserIdValue.TabIndex = 6;
            lblUserIdValue.Text = "-";
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(6, 33);
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
            btnDelete.Text = "Delete Sale";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(7, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Sale";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // gbManageSale
            // 
            gbManageSale.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageSale.Controls.Add(gridSalesDetails);
            gbManageSale.Controls.Add(numQuantity);
            gbManageSale.Controls.Add(numDiscount);
            gbManageSale.Controls.Add(lblQuantity);
            gbManageSale.Controls.Add(lblDiscount);
            gbManageSale.Controls.Add(cmbBook);
            gbManageSale.Controls.Add(lblBook);
            gbManageSale.Controls.Add(lblSaleIdValue);
            gbManageSale.Controls.Add(lblSaleDateValue);
            gbManageSale.Controls.Add(lblPriceValue);
            gbManageSale.Controls.Add(lblTotalAmountValue);
            gbManageSale.Controls.Add(lblUserIdValue);
            gbManageSale.Controls.Add(lblSaleId);
            gbManageSale.Controls.Add(lblSaleDate);
            gbManageSale.Controls.Add(lblPrice);
            gbManageSale.Controls.Add(lblTotalAmount);
            gbManageSale.Controls.Add(lblUserId);
            gbManageSale.Controls.Add(btnClear);
            gbManageSale.Controls.Add(btnDelete);
            gbManageSale.Controls.Add(btnSave);
            gbManageSale.Location = new Point(10, 314);
            gbManageSale.Name = "gbManageSale";
            gbManageSale.Size = new Size(936, 330);
            gbManageSale.TabIndex = 4;
            gbManageSale.TabStop = false;
            gbManageSale.Text = "Manage Sale";
            // 
            // gridSalesDetails
            // 
            gridSalesDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridSalesDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSalesDetails.Location = new Point(475, 33);
            gridSalesDetails.MultiSelect = false;
            gridSalesDetails.Name = "gridSalesDetails";
            gridSalesDetails.RowHeadersWidth = 51;
            gridSalesDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSalesDetails.Size = new Size(458, 249);
            gridSalesDetails.TabIndex = 11;
            gridSalesDetails.CellClick += gridSalesDetails_CellClick;
            // 
            // numDiscount
            // 
            numDiscount.DecimalPlaces = 2;
            numDiscount.Location = new Point(171, 121);
            numDiscount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(180, 27);
            numDiscount.TabIndex = 12;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(7, 124);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(67, 20);
            lblDiscount.TabIndex = 11;
            lblDiscount.Text = "Discount";
            // 
            // lblSaleIdValue
            // 
            lblSaleIdValue.AutoSize = true;
            lblSaleIdValue.Location = new Point(171, 62);
            lblSaleIdValue.Name = "lblSaleIdValue";
            lblSaleIdValue.Size = new Size(15, 20);
            lblSaleIdValue.TabIndex = 6;
            lblSaleIdValue.Text = "-";
            // 
            // lblSaleDateValue
            // 
            lblSaleDateValue.AutoSize = true;
            lblSaleDateValue.Location = new Point(170, 93);
            lblSaleDateValue.Name = "lblSaleDateValue";
            lblSaleDateValue.Size = new Size(15, 20);
            lblSaleDateValue.TabIndex = 6;
            lblSaleDateValue.Text = "-";
            // 
            // lblPriceValue
            // 
            lblPriceValue.AutoSize = true;
            lblPriceValue.Location = new Point(170, 227);
            lblPriceValue.Name = "lblPriceValue";
            lblPriceValue.Size = new Size(36, 20);
            lblPriceValue.TabIndex = 6;
            lblPriceValue.Text = "0.00";
            // 
            // lblTotalAmountValue
            // 
            lblTotalAmountValue.AutoSize = true;
            lblTotalAmountValue.Location = new Point(171, 154);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(36, 20);
            lblTotalAmountValue.TabIndex = 6;
            lblTotalAmountValue.Text = "0.00";
            // 
            // lblSaleId
            // 
            lblSaleId.AutoSize = true;
            lblSaleId.Location = new Point(7, 62);
            lblSaleId.Name = "lblSaleId";
            lblSaleId.Size = new Size(54, 20);
            lblSaleId.TabIndex = 5;
            lblSaleId.Text = "Sale Id";
            // 
            // lblSaleDate
            // 
            lblSaleDate.AutoSize = true;
            lblSaleDate.Location = new Point(6, 93);
            lblSaleDate.Name = "lblSaleDate";
            lblSaleDate.Size = new Size(73, 20);
            lblSaleDate.TabIndex = 5;
            lblSaleDate.Text = "Sale Date";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(6, 227);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(7, 154);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(99, 20);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "Total Amount";
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(gbSalesList);
            Controls.Add(gbManageSale);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sales";
            Text = "Sales";
            gbSalesList.ResumeLayout(false);
            gbSalesList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            gbManageSale.ResumeLayout(false);
            gbManageSale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSalesDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbSalesList;
        private Label lblPageInfo;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridSales;
        private Button btnPrevious;
        private Button btnNext;
        private NumericUpDown numQuantity;
        private Label lblQuantity;
        private ComboBox cmbBook;
        private Label lblBook;
        private Label lblUserIdValue;
        private Label lblUserId;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private GroupBox gbManageSale;
        private DataGridView gridSalesDetails;
        private NumericUpDown numDiscount;
        private Label lblDiscount;
        private Label lblSaleIdValue;
        private Label lblSaleDateValue;
        private Label lblTotalAmountValue;
        private Label lblSaleId;
        private Label lblSaleDate;
        private Label lblTotalAmount;
        private Label lblPriceValue;
        private Label lblPrice;
    }
}