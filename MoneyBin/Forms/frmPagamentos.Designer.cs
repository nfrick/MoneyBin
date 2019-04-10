namespace MoneyBin.Forms {
    partial class frmPagamentos {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentos));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDesfazer = new System.Windows.Forms.ToolStripButton();
            this.decDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.novDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.octDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sepDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.augDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.julDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.junDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mayDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aprDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.marDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.febDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.janDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yearDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvPagamentos);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1242, 485);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1242, 510);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.MoneyBinEntities);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSalvar,
            this.toolStripButtonDesfazer});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(109, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonSalvar
            // 
            this.toolStripButtonSalvar.BackColor = System.Drawing.Color.Green;
            this.toolStripButtonSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSalvar.ForeColor = System.Drawing.Color.White;
            this.toolStripButtonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSalvar.Image")));
            this.toolStripButtonSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSalvar.Name = "toolStripButtonSalvar";
            this.toolStripButtonSalvar.Size = new System.Drawing.Size(42, 22);
            this.toolStripButtonSalvar.Text = "Salvar";
            this.toolStripButtonSalvar.Click += new System.EventHandler(this.toolStripButtonSalvar_Click);
            // 
            // toolStripButtonDesfazer
            // 
            this.toolStripButtonDesfazer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButtonDesfazer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDesfazer.ForeColor = System.Drawing.Color.White;
            this.toolStripButtonDesfazer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDesfazer.Image")));
            this.toolStripButtonDesfazer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDesfazer.Name = "toolStripButtonDesfazer";
            this.toolStripButtonDesfazer.Size = new System.Drawing.Size(55, 22);
            this.toolStripButtonDesfazer.Text = "Desfazer";
            this.toolStripButtonDesfazer.Click += new System.EventHandler(this.toolStripButtonDesfazer_Click);
            // 
            // decDataGridViewCheckBoxColumn
            // 
            this.decDataGridViewCheckBoxColumn.DataPropertyName = "Dec";
            this.decDataGridViewCheckBoxColumn.HeaderText = "Dez";
            this.decDataGridViewCheckBoxColumn.Name = "decDataGridViewCheckBoxColumn";
            // 
            // novDataGridViewCheckBoxColumn
            // 
            this.novDataGridViewCheckBoxColumn.DataPropertyName = "Nov";
            this.novDataGridViewCheckBoxColumn.HeaderText = "Nov";
            this.novDataGridViewCheckBoxColumn.Name = "novDataGridViewCheckBoxColumn";
            // 
            // octDataGridViewCheckBoxColumn
            // 
            this.octDataGridViewCheckBoxColumn.DataPropertyName = "Oct";
            this.octDataGridViewCheckBoxColumn.HeaderText = "Out";
            this.octDataGridViewCheckBoxColumn.Name = "octDataGridViewCheckBoxColumn";
            // 
            // sepDataGridViewCheckBoxColumn
            // 
            this.sepDataGridViewCheckBoxColumn.DataPropertyName = "Sep";
            this.sepDataGridViewCheckBoxColumn.HeaderText = "Set";
            this.sepDataGridViewCheckBoxColumn.Name = "sepDataGridViewCheckBoxColumn";
            // 
            // augDataGridViewCheckBoxColumn
            // 
            this.augDataGridViewCheckBoxColumn.DataPropertyName = "Aug";
            this.augDataGridViewCheckBoxColumn.HeaderText = "Ago";
            this.augDataGridViewCheckBoxColumn.Name = "augDataGridViewCheckBoxColumn";
            // 
            // julDataGridViewCheckBoxColumn
            // 
            this.julDataGridViewCheckBoxColumn.DataPropertyName = "Jul";
            this.julDataGridViewCheckBoxColumn.HeaderText = "Jul";
            this.julDataGridViewCheckBoxColumn.Name = "julDataGridViewCheckBoxColumn";
            // 
            // junDataGridViewCheckBoxColumn
            // 
            this.junDataGridViewCheckBoxColumn.DataPropertyName = "Jun";
            this.junDataGridViewCheckBoxColumn.HeaderText = "Jun";
            this.junDataGridViewCheckBoxColumn.Name = "junDataGridViewCheckBoxColumn";
            // 
            // mayDataGridViewCheckBoxColumn
            // 
            this.mayDataGridViewCheckBoxColumn.DataPropertyName = "May";
            this.mayDataGridViewCheckBoxColumn.HeaderText = "Mai";
            this.mayDataGridViewCheckBoxColumn.Name = "mayDataGridViewCheckBoxColumn";
            // 
            // aprDataGridViewCheckBoxColumn
            // 
            this.aprDataGridViewCheckBoxColumn.DataPropertyName = "Apr";
            this.aprDataGridViewCheckBoxColumn.HeaderText = "Abr";
            this.aprDataGridViewCheckBoxColumn.Name = "aprDataGridViewCheckBoxColumn";
            // 
            // marDataGridViewCheckBoxColumn
            // 
            this.marDataGridViewCheckBoxColumn.DataPropertyName = "Mar";
            this.marDataGridViewCheckBoxColumn.HeaderText = "Mar";
            this.marDataGridViewCheckBoxColumn.Name = "marDataGridViewCheckBoxColumn";
            // 
            // febDataGridViewCheckBoxColumn
            // 
            this.febDataGridViewCheckBoxColumn.DataPropertyName = "Feb";
            this.febDataGridViewCheckBoxColumn.HeaderText = "Fev";
            this.febDataGridViewCheckBoxColumn.Name = "febDataGridViewCheckBoxColumn";
            // 
            // janDataGridViewCheckBoxColumn
            // 
            this.janDataGridViewCheckBoxColumn.DataPropertyName = "Jan";
            this.janDataGridViewCheckBoxColumn.HeaderText = "Jan";
            this.janDataGridViewCheckBoxColumn.Name = "janDataGridViewCheckBoxColumn";
            // 
            // yearDataGridViewCheckBoxColumn
            // 
            this.yearDataGridViewCheckBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewCheckBoxColumn.HeaderText = "Ano";
            this.yearDataGridViewCheckBoxColumn.Name = "yearDataGridViewCheckBoxColumn";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Historico
            // 
            this.Historico.DataPropertyName = "Historico";
            this.Historico.HeaderText = "Historico";
            this.Historico.Name = "Historico";
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewTextBoxColumn.HeaderText = "Dia";
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            // 
            // EnabledDataGridViewCheckBoxColumn
            // 
            this.EnabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.EnabledDataGridViewCheckBoxColumn.HeaderText = "Ativo";
            this.EnabledDataGridViewCheckBoxColumn.Name = "EnabledDataGridViewCheckBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // dgvPagamentos
            // 
            this.dgvPagamentos.AutoGenerateColumns = false;
            this.entityDataSource1.SetAutoLookup(this.dgvPagamentos, true);
            this.dgvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.EnabledDataGridViewCheckBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dayDataGridViewTextBoxColumn,
            this.Historico,
            this.Valor,
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
            this.decDataGridViewCheckBoxColumn});
            this.dgvPagamentos.DataMember = "Payments";
            this.dgvPagamentos.DataSource = this.entityDataSource1;
            this.dgvPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagamentos.Location = new System.Drawing.Point(0, 0);
            this.dgvPagamentos.Name = "dgvPagamentos";
            this.dgvPagamentos.RowHeadersWidth = 25;
            this.dgvPagamentos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPagamentos.RowTemplate.Height = 24;
            this.dgvPagamentos.Size = new System.Drawing.Size(1242, 485);
            this.dgvPagamentos.TabIndex = 0;
            this.dgvPagamentos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagamentos_CellEndEdit);
            this.dgvPagamentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPagamentos_CellFormatting);
            // 
            // frmPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 510);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPagamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPagamentos_FormClosing);
            this.Load += new System.EventHandler(this.frmPagamentos_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EFWinforms.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.ToolStripButton toolStripButtonDesfazer;
        private System.Windows.Forms.DataGridView dgvPagamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
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
    }
}