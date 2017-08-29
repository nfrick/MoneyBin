namespace CustomControls {
    partial class BalanceGrid {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.balanceItemDataGridView = new System.Windows.Forms.DataGridView();
            this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afetaSaldoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.balanceItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.balanceItemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(357, 250);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(167, 0);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // balanceItemDataGridView
            // 
            this.balanceItemDataGridView.AllowUserToAddRows = false;
            this.balanceItemDataGridView.AllowUserToOrderColumns = true;
            this.balanceItemDataGridView.AutoGenerateColumns = false;
            this.balanceItemDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.balanceItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bancoDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.historicoDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.afetaSaldoDataGridViewCheckBoxColumn,
            this.saldoDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.subCategoriaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.updatedDataGridViewCheckBoxColumn});
            this.balanceItemDataGridView.DataSource = this.balanceItemBindingSource;
            this.balanceItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceItemDataGridView.Location = new System.Drawing.Point(0, 0);
            this.balanceItemDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.balanceItemDataGridView.Name = "balanceItemDataGridView";
            this.balanceItemDataGridView.RowHeadersWidth = 25;
            this.balanceItemDataGridView.RowTemplate.Height = 25;
            this.balanceItemDataGridView.Size = new System.Drawing.Size(528, 254);
            this.balanceItemDataGridView.TabIndex = 15;
            this.balanceItemDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.balanceItemDataGridView_CellFormatting);
            this.balanceItemDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.balanceItemDataGridView_CellValueChanged);
            this.balanceItemDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.balanceItemDataGridView_ColumnHeaderMouseClick);
            this.balanceItemDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.balanceItemDataGridView_EditingControlShowing);
            this.balanceItemDataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.balanceItemDataGridView_UserDeletedRow);
            this.balanceItemDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.balanceItemDataGridView_UserDeletingRow);
            // 
            // bancoDataGridViewTextBoxColumn
            // 
            this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            this.bancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.bancoDataGridViewTextBoxColumn.Width = 20;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataDataGridViewTextBoxColumn.Width = 20;
            // 
            // historicoDataGridViewTextBoxColumn
            // 
            this.historicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historicoDataGridViewTextBoxColumn.DataPropertyName = "Historico";
            this.historicoDataGridViewTextBoxColumn.HeaderText = "Histórico";
            this.historicoDataGridViewTextBoxColumn.Name = "historicoDataGridViewTextBoxColumn";
            this.historicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "Documento";
            this.documentoDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentoDataGridViewTextBoxColumn.Visible = false;
            this.documentoDataGridViewTextBoxColumn.Width = 20;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorDataGridViewTextBoxColumn.Width = 20;
            // 
            // afetaSaldoDataGridViewCheckBoxColumn
            // 
            this.afetaSaldoDataGridViewCheckBoxColumn.DataPropertyName = "AfetaSaldo";
            this.afetaSaldoDataGridViewCheckBoxColumn.HeaderText = "";
            this.afetaSaldoDataGridViewCheckBoxColumn.Name = "afetaSaldoDataGridViewCheckBoxColumn";
            this.afetaSaldoDataGridViewCheckBoxColumn.ToolTipText = "Afeta Saldo";
            this.afetaSaldoDataGridViewCheckBoxColumn.Width = 20;
            // 
            // saldoDataGridViewTextBoxColumn
            // 
            this.saldoDataGridViewTextBoxColumn.DataPropertyName = "Saldo";
            this.saldoDataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.saldoDataGridViewTextBoxColumn.Name = "saldoDataGridViewTextBoxColumn";
            this.saldoDataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoDataGridViewTextBoxColumn.Width = 20;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grupoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.Width = 20;
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            this.categoriaDataGridViewTextBoxColumn.Width = 20;
            // 
            // subCategoriaDataGridViewTextBoxColumn
            // 
            this.subCategoriaDataGridViewTextBoxColumn.DataPropertyName = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.HeaderText = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.Name = "subCategoriaDataGridViewTextBoxColumn";
            this.subCategoriaDataGridViewTextBoxColumn.Width = 20;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // updatedDataGridViewCheckBoxColumn
            // 
            this.updatedDataGridViewCheckBoxColumn.DataPropertyName = "Updated";
            this.updatedDataGridViewCheckBoxColumn.HeaderText = "Updated";
            this.updatedDataGridViewCheckBoxColumn.Name = "updatedDataGridViewCheckBoxColumn";
            this.updatedDataGridViewCheckBoxColumn.Visible = false;
            this.updatedDataGridViewCheckBoxColumn.Width = 20;
            // 
            // balanceItemBindingSource
            // 
            this.balanceItemBindingSource.DataSource = typeof(DataClasses.BalanceItem);
            // 
            // BalanceGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.balanceItemDataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BalanceGrid";
            this.Size = new System.Drawing.Size(528, 254);
            this.Load += new System.EventHandler(this.BalanceGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.balanceItemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource balanceItemBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView balanceItemDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afetaSaldoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn updatedDataGridViewCheckBoxColumn;
    }
}
