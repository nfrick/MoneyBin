namespace MoneyBin.Forms {
    partial class frmContas {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContas));
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDesfazer = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.agenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaCorrenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gerente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContas
            // 
            this.dgvContas.AllowUserToDeleteRows = false;
            this.dgvContas.AutoGenerateColumns = false;
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Apelido,
            this.BankID,
            this.agenciaDataGridViewTextBoxColumn,
            this.contaCorrenteDataGridViewTextBoxColumn,
            this.Operacao,
            this.Gerente,
            this.Telefone,
            this.Celular,
            this.EMail});
            this.dgvContas.DataMember = "Accounts";
            this.dgvContas.DataSource = this.entityDataSource1;
            this.dgvContas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContas.Location = new System.Drawing.Point(0, 0);
            this.dgvContas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.Size = new System.Drawing.Size(1136, 201);
            this.dgvContas.TabIndex = 0;
            this.dgvContas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContas_CellEndEdit);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.MoneyBinEntities);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvContas);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1136, 201);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1136, 226);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
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
            this.toolStrip1.TabIndex = 1;
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
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Apelido
            // 
            this.Apelido.DataPropertyName = "Apelido";
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.Name = "Apelido";
            // 
            // BankID
            // 
            this.BankID.DataPropertyName = "BankID";
            this.BankID.DataSource = this.entityDataSource1;
            this.BankID.DisplayMember = "Banks.Banco";
            this.BankID.HeaderText = "Banco";
            this.BankID.Name = "BankID";
            this.BankID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BankID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BankID.ValueMember = "Banks.ID";
            // 
            // agenciaDataGridViewTextBoxColumn
            // 
            this.agenciaDataGridViewTextBoxColumn.DataPropertyName = "Agencia";
            this.agenciaDataGridViewTextBoxColumn.HeaderText = "Agência";
            this.agenciaDataGridViewTextBoxColumn.Name = "agenciaDataGridViewTextBoxColumn";
            // 
            // contaCorrenteDataGridViewTextBoxColumn
            // 
            this.contaCorrenteDataGridViewTextBoxColumn.DataPropertyName = "ContaCorrente";
            this.contaCorrenteDataGridViewTextBoxColumn.HeaderText = "Conta Corrente";
            this.contaCorrenteDataGridViewTextBoxColumn.Name = "contaCorrenteDataGridViewTextBoxColumn";
            // 
            // Operacao
            // 
            this.Operacao.DataPropertyName = "Operacao";
            this.Operacao.HeaderText = "Operação";
            this.Operacao.Name = "Operacao";
            // 
            // Gerente
            // 
            this.Gerente.DataPropertyName = "Gerente";
            this.Gerente.HeaderText = "Gerente";
            this.Gerente.Name = "Gerente";
            this.Gerente.Width = 200;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "Celular";
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            // 
            // EMail
            // 
            this.EMail.DataPropertyName = "EMail";
            this.EMail.HeaderText = "E-Mail";
            this.EMail.Name = "EMail";
            this.EMail.Width = 300;
            // 
            // frmContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 226);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRules_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EFWinforms.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.ToolStripButton toolStripButtonDesfazer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewComboBoxColumn BankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn agenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaCorrenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gerente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMail;
    }
}