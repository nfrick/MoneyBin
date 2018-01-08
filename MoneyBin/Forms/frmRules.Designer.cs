namespace MoneyBin.Forms {
    partial class frmRules {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRules));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDesfazer = new System.Windows.Forms.ToolStripButton();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.historicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comparacaoDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.afetaSaldoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocorrenciasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.MoneyBinEntities);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvRules);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1097, 536);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1097, 563);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dgvRules
            // 
            this.dgvRules.AutoGenerateColumns = false;
            this.entityDataSource1.SetAutoLookup(this.dgvRules, true);
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Bank,
            this.historicoDataGridViewTextBoxColumn,
            this.comparacaoDataGridViewComboBoxColumn,
            this.afetaSaldoDataGridViewCheckBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.subCategoriaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.ocorrenciasDataGridViewTextBoxColumn});
            this.dgvRules.DataMember = "Rules";
            this.dgvRules.DataSource = this.entityDataSource1;
            this.dgvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRules.Location = new System.Drawing.Point(0, 0);
            this.dgvRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowTemplate.Height = 24;
            this.dgvRules.Size = new System.Drawing.Size(1097, 536);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellEndEdit);
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
            this.toolStrip1.Size = new System.Drawing.Size(136, 27);
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
            this.toolStripButtonSalvar.Size = new System.Drawing.Size(53, 24);
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
            this.toolStripButtonDesfazer.Size = new System.Drawing.Size(71, 24);
            this.toolStripButtonDesfazer.Text = "Desfazer";
            this.toolStripButtonDesfazer.Click += new System.EventHandler(this.toolStripButtonDesfazer_Click);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Banco";
            this.Bank.DataSource = this.entityDataSource1;
            this.Bank.DisplayMember = "Banks.Banco";
            this.Bank.HeaderText = "Banco";
            this.Bank.Name = "Bank";
            this.Bank.ValueMember = "Banks.Banco";
            // 
            // historicoDataGridViewTextBoxColumn
            // 
            this.historicoDataGridViewTextBoxColumn.DataPropertyName = "Historico";
            this.historicoDataGridViewTextBoxColumn.HeaderText = "Histórico";
            this.historicoDataGridViewTextBoxColumn.Name = "historicoDataGridViewTextBoxColumn";
            // 
            // comparacaoDataGridViewComboBoxColumn
            // 
            this.comparacaoDataGridViewComboBoxColumn.DataPropertyName = "Comparacao";
            this.comparacaoDataGridViewComboBoxColumn.HeaderText = "Comparação";
            this.comparacaoDataGridViewComboBoxColumn.Items.AddRange(new object[] {
            "Equals",
            "Begins",
            "Contains",
            "Ends",
            "Cents"});
            this.comparacaoDataGridViewComboBoxColumn.Name = "comparacaoDataGridViewComboBoxColumn";
            this.comparacaoDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.comparacaoDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // afetaSaldoDataGridViewCheckBoxColumn
            // 
            this.afetaSaldoDataGridViewCheckBoxColumn.DataPropertyName = "AfetaSaldo";
            this.afetaSaldoDataGridViewCheckBoxColumn.HeaderText = "Afeta Saldo?";
            this.afetaSaldoDataGridViewCheckBoxColumn.Name = "afetaSaldoDataGridViewCheckBoxColumn";
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            // 
            // subCategoriaDataGridViewTextBoxColumn
            // 
            this.subCategoriaDataGridViewTextBoxColumn.DataPropertyName = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.HeaderText = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.Name = "subCategoriaDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // ocorrenciasDataGridViewTextBoxColumn
            // 
            this.ocorrenciasDataGridViewTextBoxColumn.DataPropertyName = "Ocorrencias";
            this.ocorrenciasDataGridViewTextBoxColumn.HeaderText = "Ocorrências";
            this.ocorrenciasDataGridViewTextBoxColumn.Name = "ocorrenciasDataGridViewTextBoxColumn";
            this.ocorrenciasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 563);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRules_FormClosing);
            this.Load += new System.EventHandler(this.frmRules_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgvRules;
        private EFWinforms.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.ToolStripButton toolStripButtonDesfazer;
        private System.Windows.Forms.DataGridViewTextBoxColumn novoGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novaCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novaSubCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn historicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn comparacaoDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afetaSaldoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocorrenciasDataGridViewTextBoxColumn;
    }
}