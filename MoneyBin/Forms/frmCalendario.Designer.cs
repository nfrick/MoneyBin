namespace MoneyBin.Forms {
    partial class frmCalendario {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendario));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvCalendario = new System.Windows.Forms.DataGridView();
            this.CalendarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPrevMonth = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxMes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonNextMonth = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripEncontrarPagamentos = new System.Windows.Forms.ToolStripButton();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scheduled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ScheduleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvCalendario);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(772, 336);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(772, 364);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dgvCalendario
            // 
            this.dgvCalendario.AllowUserToAddRows = false;
            this.dgvCalendario.AllowUserToDeleteRows = false;
            this.dgvCalendario.AutoGenerateColumns = false;
            this.dgvCalendario.ColumnHeadersHeight = 28;
            this.dgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCalendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.paymentDataGridViewTextBoxColumn,
            this.Scheduled,
            this.ScheduleDate,
            this.Amount,
            this.paidDataGridViewCheckBoxColumn,
            this.PaymentDate});
            this.dgvCalendario.DataSource = this.CalendarBindingSource;
            this.dgvCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendario.Location = new System.Drawing.Point(0, 0);
            this.dgvCalendario.Name = "dgvCalendario";
            this.dgvCalendario.RowHeadersWidth = 25;
            this.dgvCalendario.RowTemplate.Height = 24;
            this.dgvCalendario.Size = new System.Drawing.Size(772, 336);
            this.dgvCalendario.TabIndex = 0;
            this.dgvCalendario.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendario_CellEndEdit);
            this.dgvCalendario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCalendario_CellFormatting);
            this.dgvCalendario.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendario_CellValueChanged);
            this.dgvCalendario.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCalendario_CurrentCellDirtyStateChanged);
            // 
            // CalendarBindingSource
            // 
            this.CalendarBindingSource.AllowNew = false;
            this.CalendarBindingSource.DataSource = typeof(DataLayer.CalendarItem);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPrevMonth,
            this.toolStripComboBoxMes,
            this.toolStripButtonNextMonth,
            this.toolStripButtonSalvar,
            this.toolStripEncontrarPagamentos});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(366, 28);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonPrevMonth
            // 
            this.toolStripButtonPrevMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPrevMonth.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.toolStripButtonPrevMonth.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevMonth.Image")));
            this.toolStripButtonPrevMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevMonth.Name = "toolStripButtonPrevMonth";
            this.toolStripButtonPrevMonth.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonPrevMonth.Text = "3";
            this.toolStripButtonPrevMonth.ToolTipText = "Mês anterior";
            this.toolStripButtonPrevMonth.Click += new System.EventHandler(this.toolStripButtonMonth_Click);
            // 
            // toolStripComboBoxMes
            // 
            this.toolStripComboBoxMes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripComboBoxMes.Name = "toolStripComboBoxMes";
            this.toolStripComboBoxMes.Size = new System.Drawing.Size(80, 28);
            this.toolStripComboBoxMes.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxMes_SelectedIndexChanged);
            // 
            // toolStripButtonNextMonth
            // 
            this.toolStripButtonNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNextMonth.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.toolStripButtonNextMonth.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextMonth.Image")));
            this.toolStripButtonNextMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextMonth.Name = "toolStripButtonNextMonth";
            this.toolStripButtonNextMonth.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonNextMonth.Text = "4";
            this.toolStripButtonNextMonth.ToolTipText = "Próximo mês";
            this.toolStripButtonNextMonth.Click += new System.EventHandler(this.toolStripButtonMonth_Click);
            // 
            // toolStripButtonSalvar
            // 
            this.toolStripButtonSalvar.BackColor = System.Drawing.Color.Green;
            this.toolStripButtonSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSalvar.ForeColor = System.Drawing.Color.White;
            this.toolStripButtonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSalvar.Image")));
            this.toolStripButtonSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSalvar.Name = "toolStripButtonSalvar";
            this.toolStripButtonSalvar.Size = new System.Drawing.Size(53, 25);
            this.toolStripButtonSalvar.Text = "Salvar";
            this.toolStripButtonSalvar.Click += new System.EventHandler(this.toolStripButtonSalvar_Click);
            // 
            // toolStripEncontrarPagamentos
            // 
            this.toolStripEncontrarPagamentos.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.toolStripEncontrarPagamentos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEncontrarPagamentos.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEncontrarPagamentos.Image")));
            this.toolStripEncontrarPagamentos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEncontrarPagamentos.Name = "toolStripEncontrarPagamentos";
            this.toolStripEncontrarPagamentos.Size = new System.Drawing.Size(161, 25);
            this.toolStripEncontrarPagamentos.Text = "Encontrar Pagamentos";
            this.toolStripEncontrarPagamentos.ToolTipText = "Encontrar pagamentos no extrato";
            this.toolStripEncontrarPagamentos.Click += new System.EventHandler(this.toolStripButtonEncontrarPagamentos_Click);
            // 
            // Day
            // 
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "Dia";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // paymentDataGridViewTextBoxColumn
            // 
            this.paymentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paymentDataGridViewTextBoxColumn.DataPropertyName = "Payment";
            this.paymentDataGridViewTextBoxColumn.HeaderText = "Pagamento";
            this.paymentDataGridViewTextBoxColumn.Name = "paymentDataGridViewTextBoxColumn";
            this.paymentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Scheduled
            // 
            this.Scheduled.DataPropertyName = "Scheduled";
            this.Scheduled.HeaderText = "Agendado?";
            this.Scheduled.Name = "Scheduled";
            // 
            // ScheduleDate
            // 
            this.ScheduleDate.DataPropertyName = "ScheduleDate";
            this.ScheduleDate.HeaderText = "Data";
            this.ScheduleDate.Name = "ScheduleDate";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Valor";
            this.Amount.Name = "Amount";
            // 
            // paidDataGridViewCheckBoxColumn
            // 
            this.paidDataGridViewCheckBoxColumn.DataPropertyName = "Paid";
            this.paidDataGridViewCheckBoxColumn.HeaderText = "Pago?";
            this.paidDataGridViewCheckBoxColumn.Name = "paidDataGridViewCheckBoxColumn";
            this.paidDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.paidDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.paidDataGridViewCheckBoxColumn.Width = 60;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            this.PaymentDate.HeaderText = "Data";
            this.PaymentDate.Name = "PaymentDate";
            // 
            // frmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 364);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCalendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCalendario_FormClosing);
            this.Load += new System.EventHandler(this.frmCalendario_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgvCalendario;
        private System.Windows.Forms.BindingSource CalendarBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMes;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevMonth;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextMonth;
        private System.Windows.Forms.ToolStripButton toolStripEncontrarPagamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Scheduled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn paidDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
    }
}