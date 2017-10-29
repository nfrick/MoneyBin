namespace MoneyBin {
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
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.RuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNewDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comparacaoDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.centavosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afetaSaldoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NovoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NovaCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NovaSubCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocorrenciasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RuleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvRules);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1404, 711);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.Size = new System.Drawing.Size(1404, 711);
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToOrderColumns = true;
            this.dgvRules.AutoGenerateColumns = false;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.isNewDataGridViewCheckBoxColumn,
            this.bancoDataGridViewTextBoxColumn,
            this.historicoDataGridViewTextBoxColumn,
            this.comparacaoDataGridViewComboBoxColumn,
            this.centavosDataGridViewTextBoxColumn,
            this.afetaSaldoDataGridViewCheckBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.subCategoriaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.NovoGrupo,
            this.NovaCategoria,
            this.NovaSubCategoria,
            this.ocorrenciasDataGridViewTextBoxColumn,
            this.updatedDataGridViewCheckBoxColumn});
            this.dgvRules.DataSource = this.RuleBindingSource;
            this.dgvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRules.Location = new System.Drawing.Point(0, 0);
            this.dgvRules.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowTemplate.Height = 26;
            this.dgvRules.Size = new System.Drawing.Size(1404, 711);
            this.dgvRules.TabIndex = 2;
            this.dgvRules.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.RulesdataGridView_CellFormatting);
            this.dgvRules.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRules_CellValueChanged);
            this.dgvRules.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.RulesdataGridView_DataError);
            this.dgvRules.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewRules_EditingControlShowing);
            this.dgvRules.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewRules_UserAddedRow);
            this.dgvRules.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewRules_UserDeletedRow);
            this.dgvRules.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewRules_UserDeletingRow);
            // 
            // RuleBindingSource
            // 
            this.RuleBindingSource.DataSource = typeof(DataClasses.Rule);
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
            // bancoDataGridViewTextBoxColumn
            // 
            this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            // 
            // historicoDataGridViewTextBoxColumn
            // 
            this.historicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.comparacaoDataGridViewComboBoxColumn.Width = 60;
            // 
            // centavosDataGridViewTextBoxColumn
            // 
            this.centavosDataGridViewTextBoxColumn.DataPropertyName = "Centavos";
            this.centavosDataGridViewTextBoxColumn.HeaderText = "Centavos";
            this.centavosDataGridViewTextBoxColumn.Name = "centavosDataGridViewTextBoxColumn";
            this.centavosDataGridViewTextBoxColumn.Visible = false;
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
            // NovoGrupo
            // 
            this.NovoGrupo.DataPropertyName = "NovoGrupo";
            this.NovoGrupo.HeaderText = "NovoGrupo";
            this.NovoGrupo.Name = "NovoGrupo";
            // 
            // NovaCategoria
            // 
            this.NovaCategoria.DataPropertyName = "NovaCategoria";
            this.NovaCategoria.HeaderText = "NovaCategoria";
            this.NovaCategoria.Name = "NovaCategoria";
            // 
            // NovaSubCategoria
            // 
            this.NovaSubCategoria.DataPropertyName = "NovaSubCategoria";
            this.NovaSubCategoria.HeaderText = "NovaSubCategoria";
            this.NovaSubCategoria.Name = "NovaSubCategoria";
            // 
            // ocorrenciasDataGridViewTextBoxColumn
            // 
            this.ocorrenciasDataGridViewTextBoxColumn.DataPropertyName = "Ocorrencias";
            this.ocorrenciasDataGridViewTextBoxColumn.HeaderText = "Ocorrências";
            this.ocorrenciasDataGridViewTextBoxColumn.Name = "ocorrenciasDataGridViewTextBoxColumn";
            this.ocorrenciasDataGridViewTextBoxColumn.Width = 70;
            // 
            // updatedDataGridViewCheckBoxColumn
            // 
            this.updatedDataGridViewCheckBoxColumn.DataPropertyName = "AddToDatabase";
            this.updatedDataGridViewCheckBoxColumn.HeaderText = "AddToDatabase";
            this.updatedDataGridViewCheckBoxColumn.Name = "updatedDataGridViewCheckBoxColumn";
            this.updatedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // frmRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 711);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmRules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRules_FormClosing);
            this.Load += new System.EventHandler(this.frmRules_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RuleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.BindingSource RuleBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNewDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn comparacaoDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centavosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afetaSaldoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NovoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NovaCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NovaSubCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocorrenciasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn updatedDataGridViewCheckBoxColumn;
    }
}