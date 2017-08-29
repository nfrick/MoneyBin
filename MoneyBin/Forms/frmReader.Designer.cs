namespace MoneyBin {
    partial class frmReader {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.balanceGrid = new CustomControls.BalanceGrid();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.balanceGrid);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1403, 555);
            this.toolStripContainer1.Size = new System.Drawing.Size(1403, 555);
            // 
            // balanceGrid
            // 
            this.balanceGrid.AutoSize = true;
            this.balanceGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.balanceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceGrid.Location = new System.Drawing.Point(0, 0);
            this.balanceGrid.Margin = new System.Windows.Forms.Padding(5);
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.Size = new System.Drawing.Size(1403, 555);
            this.balanceGrid.TabIndex = 0;
            // 
            // frmReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1403, 555);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmReader";
            this.Text = "Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReader_FormClosing);
            this.Load += new System.EventHandler(this.frmReader_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.BalanceGrid balanceGrid;
    }
}
