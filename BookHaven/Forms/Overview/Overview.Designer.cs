namespace BookHaven.Forms.Overview
{
    partial class Overview
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
            lblOverview = new Label();
            SuspendLayout();
            // 
            // lblOverview
            // 
            lblOverview.AutoSize = true;
            lblOverview.Location = new Point(0, 0);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(70, 20);
            lblOverview.TabIndex = 0;
            lblOverview.Text = "Overview";
            // 
            // Overview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 653);
            Controls.Add(lblOverview);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Overview";
            Text = "Overview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOverview;
    }
}