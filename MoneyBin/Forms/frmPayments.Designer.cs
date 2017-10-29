namespace MoneyBin {
    partial class frmPayments {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayments));
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNewDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.monthsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.janDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.febDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.marDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aprDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mayDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.junDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.julDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.augDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sepDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.octDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.novDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.decDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridViewPayments);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1457, 716);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.toolStripContainer1.Size = new System.Drawing.Size(1457, 716);
            // 
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataSource = typeof(DataClasses.Payment);
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AutoGenerateColumns = false;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.isNewDataGridViewCheckBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dayDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.monthsDataGridViewTextBoxColumn,
            this.yearDataGridViewCheckBoxColumn,
            this.janDataGridViewCheckBoxColumn,
            this.febDataGridViewCheckBoxColumn,
            this.marDataGridViewCheckBoxColumn,
            this.aprDataGridViewCheckBoxColumn,
            this.mayDataGridViewCheckBoxColumn,
            this.junDataGridViewCheckBoxColumn,
            this.julDataGridViewCheckBoxColumn,
            this.augDataGridViewCheckBoxColumn,
            this.sepDataGridViewCheckBoxColumn,
            this.octDataGridViewCheckBoxColumn,
            this.novDataGridViewCheckBoxColumn,
            this.decDataGridViewCheckBoxColumn,
            this.updatedDataGridViewCheckBoxColumn});
            this.dataGridViewPayments.DataSource = this.paymentBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPayments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPayments.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPayments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.RowTemplate.Height = 26;
            this.dataGridViewPayments.Size = new System.Drawing.Size(1457, 716);
            this.dataGridViewPayments.TabIndex = 1;
            this.dataGridViewPayments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PaymentsdataGridView_CellFormatting);
            this.dataGridViewPayments.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPayments_CellValueChanged);
            this.dataGridViewPayments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.PaymentsdataGridView_DataError);
            this.dataGridViewPayments.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewPayments_UserAddedRow);
            this.dataGridViewPayments.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewPayments_UserDeletedRow);
            this.dataGridViewPayments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewPayments_UserDeletingRow);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // isNewDataGridViewCheckBoxColumn
            // 
            this.isNewDataGridViewCheckBoxColumn.DataPropertyName = "IsNew";
            this.isNewDataGridViewCheckBoxColumn.HeaderText = "IsNew";
            this.isNewDataGridViewCheckBoxColumn.Name = "isNewDataGridViewCheckBoxColumn";
            this.isNewDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isNewDataGridViewCheckBoxColumn.Visible = false;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Group";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewTextBoxColumn.HeaderText = "Day";
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            this.dayDataGridViewTextBoxColumn.Width = 50;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Width = 50;
            // 
            // monthsDataGridViewTextBoxColumn
            // 
            this.monthsDataGridViewTextBoxColumn.DataPropertyName = "Months";
            this.monthsDataGridViewTextBoxColumn.HeaderText = "Months";
            this.monthsDataGridViewTextBoxColumn.Name = "monthsDataGridViewTextBoxColumn";
            this.monthsDataGridViewTextBoxColumn.Visible = false;
            // 
            // yearDataGridViewCheckBoxColumn
            // 
            this.yearDataGridViewCheckBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewCheckBoxColumn.HeaderText = "Year";
            this.yearDataGridViewCheckBoxColumn.Name = "yearDataGridViewCheckBoxColumn";
            this.yearDataGridViewCheckBoxColumn.Width = 50;
            // 
            // janDataGridViewCheckBoxColumn
            // 
            this.janDataGridViewCheckBoxColumn.DataPropertyName = "Jan";
            this.janDataGridViewCheckBoxColumn.HeaderText = "Jan";
            this.janDataGridViewCheckBoxColumn.Name = "janDataGridViewCheckBoxColumn";
            this.janDataGridViewCheckBoxColumn.Width = 50;
            // 
            // febDataGridViewCheckBoxColumn
            // 
            this.febDataGridViewCheckBoxColumn.DataPropertyName = "Feb";
            this.febDataGridViewCheckBoxColumn.HeaderText = "Feb";
            this.febDataGridViewCheckBoxColumn.Name = "febDataGridViewCheckBoxColumn";
            this.febDataGridViewCheckBoxColumn.Width = 50;
            // 
            // marDataGridViewCheckBoxColumn
            // 
            this.marDataGridViewCheckBoxColumn.DataPropertyName = "Mar";
            this.marDataGridViewCheckBoxColumn.HeaderText = "Mar";
            this.marDataGridViewCheckBoxColumn.Name = "marDataGridViewCheckBoxColumn";
            this.marDataGridViewCheckBoxColumn.Width = 50;
            // 
            // aprDataGridViewCheckBoxColumn
            // 
            this.aprDataGridViewCheckBoxColumn.DataPropertyName = "Apr";
            this.aprDataGridViewCheckBoxColumn.HeaderText = "Apr";
            this.aprDataGridViewCheckBoxColumn.Name = "aprDataGridViewCheckBoxColumn";
            this.aprDataGridViewCheckBoxColumn.Width = 50;
            // 
            // mayDataGridViewCheckBoxColumn
            // 
            this.mayDataGridViewCheckBoxColumn.DataPropertyName = "May";
            this.mayDataGridViewCheckBoxColumn.HeaderText = "May";
            this.mayDataGridViewCheckBoxColumn.Name = "mayDataGridViewCheckBoxColumn";
            this.mayDataGridViewCheckBoxColumn.Width = 50;
            // 
            // junDataGridViewCheckBoxColumn
            // 
            this.junDataGridViewCheckBoxColumn.DataPropertyName = "Jun";
            this.junDataGridViewCheckBoxColumn.HeaderText = "Jun";
            this.junDataGridViewCheckBoxColumn.Name = "junDataGridViewCheckBoxColumn";
            this.junDataGridViewCheckBoxColumn.Width = 50;
            // 
            // julDataGridViewCheckBoxColumn
            // 
            this.julDataGridViewCheckBoxColumn.DataPropertyName = "Jul";
            this.julDataGridViewCheckBoxColumn.HeaderText = "Jul";
            this.julDataGridViewCheckBoxColumn.Name = "julDataGridViewCheckBoxColumn";
            this.julDataGridViewCheckBoxColumn.Width = 50;
            // 
            // augDataGridViewCheckBoxColumn
            // 
            this.augDataGridViewCheckBoxColumn.DataPropertyName = "Aug";
            this.augDataGridViewCheckBoxColumn.HeaderText = "Aug";
            this.augDataGridViewCheckBoxColumn.Name = "augDataGridViewCheckBoxColumn";
            this.augDataGridViewCheckBoxColumn.Width = 50;
            // 
            // sepDataGridViewCheckBoxColumn
            // 
            this.sepDataGridViewCheckBoxColumn.DataPropertyName = "Sep";
            this.sepDataGridViewCheckBoxColumn.HeaderText = "Sep";
            this.sepDataGridViewCheckBoxColumn.Name = "sepDataGridViewCheckBoxColumn";
            this.sepDataGridViewCheckBoxColumn.Width = 50;
            // 
            // octDataGridViewCheckBoxColumn
            // 
            this.octDataGridViewCheckBoxColumn.DataPropertyName = "Oct";
            this.octDataGridViewCheckBoxColumn.HeaderText = "Oct";
            this.octDataGridViewCheckBoxColumn.Name = "octDataGridViewCheckBoxColumn";
            this.octDataGridViewCheckBoxColumn.Width = 50;
            // 
            // novDataGridViewCheckBoxColumn
            // 
            this.novDataGridViewCheckBoxColumn.DataPropertyName = "Nov";
            this.novDataGridViewCheckBoxColumn.HeaderText = "Nov";
            this.novDataGridViewCheckBoxColumn.Name = "novDataGridViewCheckBoxColumn";
            this.novDataGridViewCheckBoxColumn.Width = 50;
            // 
            // decDataGridViewCheckBoxColumn
            // 
            this.decDataGridViewCheckBoxColumn.DataPropertyName = "Dec";
            this.decDataGridViewCheckBoxColumn.HeaderText = "Dec";
            this.decDataGridViewCheckBoxColumn.Name = "decDataGridViewCheckBoxColumn";
            this.decDataGridViewCheckBoxColumn.Width = 50;
            // 
            // updatedDataGridViewCheckBoxColumn
            // 
            this.updatedDataGridViewCheckBoxColumn.DataPropertyName = "AddToDatabase";
            this.updatedDataGridViewCheckBoxColumn.HeaderText = "AddToDatabase";
            this.updatedDataGridViewCheckBoxColumn.Name = "updatedDataGridViewCheckBoxColumn";
            this.updatedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 716);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPayments_FormClosing);
            this.Load += new System.EventHandler(this.frmPayments_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource paymentBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNewDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yearDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn janDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn febDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn marDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aprDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mayDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn junDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn julDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn augDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sepDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn octDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn novDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn decDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn updatedDataGridViewCheckBoxColumn;
    }
}