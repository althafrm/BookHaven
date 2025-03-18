namespace BookHaven.Forms.Reports
{
    partial class Reports
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
            dtTo = new DateTimePicker();
            dtFrom = new DateTimePicker();
            cmbReport = new ComboBox();
            gridReport = new DataGridView();
            lblFrom = new Label();
            lblTo = new Label();
            lblReport = new Label();
            gbFilters = new GroupBox();
            gbTable = new GroupBox();
            btnNext = new Button();
            btnPrevious = new Button();
            lblPageInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)gridReport).BeginInit();
            gbTable.SuspendLayout();
            SuspendLayout();
            // 
            // dtTo
            // 
            dtTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtTo.Location = new Point(695, 23);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(250, 27);
            dtTo.TabIndex = 0;
            // 
            // dtFrom
            // 
            dtFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtFrom.Location = new Point(390, 23);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(250, 27);
            dtFrom.TabIndex = 0;
            // 
            // cmbReport
            // 
            cmbReport.FormattingEnabled = true;
            cmbReport.Location = new Point(72, 22);
            cmbReport.Name = "cmbReport";
            cmbReport.Size = new Size(180, 28);
            cmbReport.TabIndex = 1;
            cmbReport.SelectedIndexChanged += cmbReport_SelectedIndexChanged;
            // 
            // gridReport
            // 
            gridReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReport.Location = new Point(0, 49);
            gridReport.MultiSelect = false;
            gridReport.Name = "gridReport";
            gridReport.RowHeadersWidth = 51;
            gridReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridReport.Size = new Size(951, 525);
            gridReport.TabIndex = 2;
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(341, 25);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(43, 20);
            lblFrom.TabIndex = 3;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.Location = new Point(664, 25);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 20);
            lblTo.TabIndex = 3;
            lblTo.Text = "To";
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Location = new Point(12, 25);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(54, 20);
            lblReport.TabIndex = 4;
            lblReport.Text = "Report";
            // 
            // gbFilters
            // 
            gbFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFilters.Location = new Point(1, 1);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(957, 65);
            gbFilters.TabIndex = 5;
            gbFilters.TabStop = false;
            // 
            // gbTable
            // 
            gbTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbTable.Controls.Add(btnNext);
            gbTable.Controls.Add(btnPrevious);
            gbTable.Controls.Add(lblPageInfo);
            gbTable.Controls.Add(gridReport);
            gbTable.Location = new Point(1, 72);
            gbTable.Name = "gbTable";
            gbTable.Size = new Size(957, 580);
            gbTable.TabIndex = 6;
            gbTable.TabStop = false;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(809, 14);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 29);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(668, 14);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(135, 29);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "< Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(560, 18);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(79, 20);
            lblPageInfo.TabIndex = 3;
            lblPageInfo.Text = "Page - of -";
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(lblReport);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(cmbReport);
            Controls.Add(dtFrom);
            Controls.Add(dtTo);
            Controls.Add(gbFilters);
            Controls.Add(gbTable);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Reports";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)gridReport).EndInit();
            gbTable.ResumeLayout(false);
            gbTable.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtTo;
        private DateTimePicker dtFrom;
        private ComboBox cmbReport;
        private DataGridView gridReport;
        private Label lblFrom;
        private Label lblTo;
        private Label lblReport;
        private GroupBox gbFilters;
        private GroupBox gbTable;
        private Button btnNext;
        private Button btnPrevious;
        private Label lblPageInfo;
    }
}