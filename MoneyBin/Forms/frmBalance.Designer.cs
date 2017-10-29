namespace MoneyBin.Forms
{
    partial class frmBalance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalance));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvBalance = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afetaSaldoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.novoGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.novaCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.novaSubCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxBanco = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxGrupo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparatorSalvar = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProcurar = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxProcurar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelProcurar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonDesfazer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvBalance);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1219, 477);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1219, 505);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dgvBalance
            // 
            this.dgvBalance.AllowUserToAddRows = false;
            this.dgvBalance.AutoGenerateColumns = false;
            this.dgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.bancoDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.historicoDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.afetaSaldoDataGridViewCheckBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.saldoDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.subCategoriaDataGridViewTextBoxColumn,
            this.novoGrupoDataGridViewTextBoxColumn,
            this.novaCategoriaDataGridViewTextBoxColumn,
            this.novaSubCategoriaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn});
            this.dgvBalance.DataSource = this.BalanceBindingSource;
            this.dgvBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalance.Location = new System.Drawing.Point(0, 0);
            this.dgvBalance.Name = "dgvBalance";
            this.dgvBalance.RowTemplate.Height = 24;
            this.dgvBalance.Size = new System.Drawing.Size(1219, 477);
            this.dgvBalance.TabIndex = 0;
            this.dgvBalance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBalance_CellEndEdit);
            this.dgvBalance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBalance_CellFormatting);
            this.dgvBalance.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBalance_CellValueChanged);
            this.dgvBalance.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBalance_EditingControlShowing);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bancoDataGridViewTextBoxColumn
            // 
            this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            this.bancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.bancoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // historicoDataGridViewTextBoxColumn
            // 
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
            // 
            // afetaSaldoDataGridViewCheckBoxColumn
            // 
            this.afetaSaldoDataGridViewCheckBoxColumn.DataPropertyName = "AfetaSaldo";
            this.afetaSaldoDataGridViewCheckBoxColumn.HeaderText = "Afeta Saldo?";
            this.afetaSaldoDataGridViewCheckBoxColumn.Name = "afetaSaldoDataGridViewCheckBoxColumn";
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoDataGridViewTextBoxColumn
            // 
            this.saldoDataGridViewTextBoxColumn.DataPropertyName = "Saldo";
            this.saldoDataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.saldoDataGridViewTextBoxColumn.Name = "saldoDataGridViewTextBoxColumn";
            this.saldoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            this.categoriaDataGridViewTextBoxColumn.Visible = false;
            // 
            // subCategoriaDataGridViewTextBoxColumn
            // 
            this.subCategoriaDataGridViewTextBoxColumn.DataPropertyName = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.HeaderText = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.Name = "subCategoriaDataGridViewTextBoxColumn";
            this.subCategoriaDataGridViewTextBoxColumn.Visible = false;
            // 
            // novoGrupoDataGridViewTextBoxColumn
            // 
            this.novoGrupoDataGridViewTextBoxColumn.DataPropertyName = "NovoGrupo";
            this.novoGrupoDataGridViewTextBoxColumn.HeaderText = "Novo Grupo";
            this.novoGrupoDataGridViewTextBoxColumn.Name = "novoGrupoDataGridViewTextBoxColumn";
            // 
            // novaCategoriaDataGridViewTextBoxColumn
            // 
            this.novaCategoriaDataGridViewTextBoxColumn.DataPropertyName = "NovaCategoria";
            this.novaCategoriaDataGridViewTextBoxColumn.HeaderText = "Nova Categoria";
            this.novaCategoriaDataGridViewTextBoxColumn.Name = "novaCategoriaDataGridViewTextBoxColumn";
            // 
            // novaSubCategoriaDataGridViewTextBoxColumn
            // 
            this.novaSubCategoriaDataGridViewTextBoxColumn.DataPropertyName = "NovaSubCategoria";
            this.novaSubCategoriaDataGridViewTextBoxColumn.HeaderText = "Nova SubCategoria";
            this.novaSubCategoriaDataGridViewTextBoxColumn.Name = "novaSubCategoriaDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // BalanceBindingSource
            // 
            this.BalanceBindingSource.AllowNew = false;
            this.BalanceBindingSource.DataSource = typeof(DataLayer.BalanceItemComSaldo);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxBanco,
            this.toolStripLabel2,
            this.toolStripComboBoxGrupo,
            this.toolStripSeparatorSalvar,
            this.toolStripButtonSalvar,
            this.toolStripButtonProcurar,
            this.toolStripTextBoxProcurar,
            this.toolStripLabelProcurar,
            this.toolStripButtonDesfazer,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(527, 28);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 25);
            this.toolStripLabel1.Text = "Banco:";
            // 
            // toolStripComboBoxBanco
            // 
            this.toolStripComboBoxBanco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripComboBoxBanco.Name = "toolStripComboBoxBanco";
            this.toolStripComboBoxBanco.Size = new System.Drawing.Size(75, 28);
            this.toolStripComboBoxBanco.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxBanco_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 25);
            this.toolStripLabel2.Text = "Grupo:";
            // 
            // toolStripComboBoxGrupo
            // 
            this.toolStripComboBoxGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripComboBoxGrupo.Name = "toolStripComboBoxGrupo";
            this.toolStripComboBoxGrupo.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBoxGrupo.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxGrupo_SelectedIndexChanged);
            // 
            // toolStripSeparatorSalvar
            // 
            this.toolStripSeparatorSalvar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripSeparatorSalvar.Name = "toolStripSeparatorSalvar";
            this.toolStripSeparatorSalvar.Size = new System.Drawing.Size(6, 28);
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
            this.toolStripButtonSalvar.Visible = false;
            this.toolStripButtonSalvar.Click += new System.EventHandler(this.toolStripButtonSalvar_Click);
            // 
            // toolStripButtonProcurar
            // 
            this.toolStripButtonProcurar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonProcurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripButtonProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonProcurar.Font = new System.Drawing.Font("Webdings", 9F);
            this.toolStripButtonProcurar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButtonProcurar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonProcurar.Image")));
            this.toolStripButtonProcurar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProcurar.Name = "toolStripButtonProcurar";
            this.toolStripButtonProcurar.Size = new System.Drawing.Size(28, 25);
            this.toolStripButtonProcurar.Text = "L";
            this.toolStripButtonProcurar.Click += new System.EventHandler(this.toolStripButtonProcurar_Click);
            // 
            // toolStripTextBoxProcurar
            // 
            this.toolStripTextBoxProcurar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBoxProcurar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripTextBoxProcurar.Name = "toolStripTextBoxProcurar";
            this.toolStripTextBoxProcurar.Size = new System.Drawing.Size(100, 28);
            // 
            // toolStripLabelProcurar
            // 
            this.toolStripLabelProcurar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelProcurar.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabelProcurar.Name = "toolStripLabelProcurar";
            this.toolStripLabelProcurar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripLabelProcurar.Size = new System.Drawing.Size(67, 25);
            this.toolStripLabelProcurar.Text = "Procurar:";
            // 
            // toolStripButtonDesfazer
            // 
            this.toolStripButtonDesfazer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripButtonDesfazer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDesfazer.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonDesfazer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDesfazer.Image")));
            this.toolStripButtonDesfazer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDesfazer.Name = "toolStripButtonDesfazer";
            this.toolStripButtonDesfazer.Size = new System.Drawing.Size(71, 25);
            this.toolStripButtonDesfazer.Text = "Desfazer";
            this.toolStripButtonDesfazer.Visible = false;
            this.toolStripButtonDesfazer.Click += new System.EventHandler(this.toolStripButtonDesfazer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // frmBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 505);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBalance";
            this.Text = "Balance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBalance_FormClosing);
            this.Load += new System.EventHandler(this.frmBalance_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxBanco;
        private System.Windows.Forms.BindingSource BalanceBindingSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.DataGridView dgvBalance;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxGrupo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSalvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afetaSaldoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novoGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novaCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novaSubCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButtonProcurar;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxProcurar;
        private System.Windows.Forms.ToolStripLabel toolStripLabelProcurar;
        private System.Windows.Forms.ToolStripButton toolStripButtonDesfazer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}