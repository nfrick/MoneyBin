namespace MoneyBin.Forms {
    partial class frmAssociador {
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
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();
            this.bindingSourcePagamentos = new System.Windows.Forms.BindingSource(this.components);
            this.dgvReembolsos = new System.Windows.Forms.DataGridView();
            this.bindingSourceReembolsos = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPagamentos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxGrupo = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.radioButtonPagtosAssociados = new System.Windows.Forms.RadioButton();
            this.radioButtonPagtosPendentes = new System.Windows.Forms.RadioButton();
            this.radioButtonPagtosTodos = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonReembTodos = new System.Windows.Forms.RadioButton();
            this.radioButtonReembValorIgual = new System.Windows.Forms.RadioButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAssociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReembolsos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReembolsos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPagamentos
            // 
            this.dgvPagamentos.AllowUserToAddRows = false;
            this.dgvPagamentos.AllowUserToDeleteRows = false;
            this.dgvPagamentos.AutoGenerateColumns = false;
            this.dgvPagamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.bancoDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.subCategoriaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.IDAssociado});
            this.dgvPagamentos.DataSource = this.bindingSourcePagamentos;
            this.dgvPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagamentos.Location = new System.Drawing.Point(3, 101);
            this.dgvPagamentos.Name = "dgvPagamentos";
            this.dgvPagamentos.RowTemplate.Height = 24;
            this.dgvPagamentos.Size = new System.Drawing.Size(741, 596);
            this.dgvPagamentos.TabIndex = 0;
            this.dgvPagamentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGastos_CellDoubleClick);
            this.dgvPagamentos.SelectionChanged += new System.EventHandler(this.dgvBalance_SelectionChanged);
            // 
            // bindingSourcePagamentos
            // 
            this.bindingSourcePagamentos.AllowNew = false;
            this.bindingSourcePagamentos.DataSource = typeof(DataLayer.BalanceItem);
            // 
            // dgvReembolsos
            // 
            this.dgvReembolsos.AllowUserToAddRows = false;
            this.dgvReembolsos.AllowUserToDeleteRows = false;
            this.dgvReembolsos.AutoGenerateColumns = false;
            this.dgvReembolsos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReembolsos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReembolsos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvReembolsos.DataSource = this.bindingSourceReembolsos;
            this.dgvReembolsos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReembolsos.Location = new System.Drawing.Point(750, 101);
            this.dgvReembolsos.Name = "dgvReembolsos";
            this.dgvReembolsos.ReadOnly = true;
            this.dgvReembolsos.RowTemplate.Height = 24;
            this.dgvReembolsos.Size = new System.Drawing.Size(741, 596);
            this.dgvReembolsos.TabIndex = 1;
            this.dgvReembolsos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReembolsos_CellDoubleClick);
            // 
            // bindingSourceReembolsos
            // 
            this.bindingSourceReembolsos.AllowNew = false;
            this.bindingSourceReembolsos.DataSource = typeof(DataLayer.BalanceItem);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPagamentos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvReembolsos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPagamentos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1494, 700);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelPagamentos
            // 
            this.labelPagamentos.AutoSize = true;
            this.labelPagamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPagamentos.Font = new System.Drawing.Font("Stencil", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagamentos.Location = new System.Drawing.Point(3, 0);
            this.labelPagamentos.Name = "labelPagamentos";
            this.labelPagamentos.Size = new System.Drawing.Size(741, 52);
            this.labelPagamentos.TabIndex = 2;
            this.labelPagamentos.Text = "PAGAMENTOS";
            this.labelPagamentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Stencil", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(750, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(741, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "REEMBOLSOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBoxGrupo);
            this.panel1.Controls.Add(this.dateTimePickerInicio);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.radioButtonPagtosAssociados);
            this.panel1.Controls.Add(this.radioButtonPagtosPendentes);
            this.panel1.Controls.Add(this.radioButtonPagtosTodos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 40);
            this.panel1.TabIndex = 4;
            // 
            // comboBoxGrupo
            // 
            this.comboBoxGrupo.FormattingEnabled = true;
            this.comboBoxGrupo.Location = new System.Drawing.Point(417, 6);
            this.comboBoxGrupo.Name = "comboBoxGrupo";
            this.comboBoxGrupo.Size = new System.Drawing.Size(103, 31);
            this.comboBoxGrupo.TabIndex = 5;
            this.comboBoxGrupo.SelectedIndexChanged += new System.EventHandler(this.Grupo_Inicio_ValueChanged);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(535, 6);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(102, 30);
            this.dateTimePickerInicio.TabIndex = 4;
            this.dateTimePickerInicio.Value = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            this.dateTimePickerInicio.ValueChanged += new System.EventHandler(this.Grupo_Inicio_ValueChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.ForeColor = System.Drawing.Color.Black;
            this.buttonRefresh.Location = new System.Drawing.Point(654, 6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 31);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // radioButtonPagtosAssociados
            // 
            this.radioButtonPagtosAssociados.AutoSize = true;
            this.radioButtonPagtosAssociados.ForeColor = System.Drawing.Color.Black;
            this.radioButtonPagtosAssociados.Location = new System.Drawing.Point(257, 8);
            this.radioButtonPagtosAssociados.Name = "radioButtonPagtosAssociados";
            this.radioButtonPagtosAssociados.Size = new System.Drawing.Size(114, 27);
            this.radioButtonPagtosAssociados.TabIndex = 2;
            this.radioButtonPagtosAssociados.Text = "Associados";
            this.radioButtonPagtosAssociados.UseVisualStyleBackColor = true;
            this.radioButtonPagtosAssociados.CheckedChanged += new System.EventHandler(this.radioButtonPagtos_CheckedChanged);
            // 
            // radioButtonPagtosPendentes
            // 
            this.radioButtonPagtosPendentes.AutoSize = true;
            this.radioButtonPagtosPendentes.ForeColor = System.Drawing.Color.Black;
            this.radioButtonPagtosPendentes.Location = new System.Drawing.Point(123, 8);
            this.radioButtonPagtosPendentes.Name = "radioButtonPagtosPendentes";
            this.radioButtonPagtosPendentes.Size = new System.Drawing.Size(110, 27);
            this.radioButtonPagtosPendentes.TabIndex = 1;
            this.radioButtonPagtosPendentes.Text = "Pendentes";
            this.radioButtonPagtosPendentes.UseVisualStyleBackColor = true;
            this.radioButtonPagtosPendentes.CheckedChanged += new System.EventHandler(this.radioButtonPagtos_CheckedChanged);
            // 
            // radioButtonPagtosTodos
            // 
            this.radioButtonPagtosTodos.AutoSize = true;
            this.radioButtonPagtosTodos.Checked = true;
            this.radioButtonPagtosTodos.ForeColor = System.Drawing.Color.Black;
            this.radioButtonPagtosTodos.Location = new System.Drawing.Point(18, 8);
            this.radioButtonPagtosTodos.Name = "radioButtonPagtosTodos";
            this.radioButtonPagtosTodos.Size = new System.Drawing.Size(75, 27);
            this.radioButtonPagtosTodos.TabIndex = 0;
            this.radioButtonPagtosTodos.TabStop = true;
            this.radioButtonPagtosTodos.Text = "Todos";
            this.radioButtonPagtosTodos.UseVisualStyleBackColor = true;
            this.radioButtonPagtosTodos.CheckedChanged += new System.EventHandler(this.radioButtonPagtos_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.radioButtonReembTodos);
            this.panel2.Controls.Add(this.radioButtonReembValorIgual);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(750, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 40);
            this.panel2.TabIndex = 5;
            // 
            // radioButtonReembTodos
            // 
            this.radioButtonReembTodos.AutoSize = true;
            this.radioButtonReembTodos.ForeColor = System.Drawing.Color.Black;
            this.radioButtonReembTodos.Location = new System.Drawing.Point(171, 8);
            this.radioButtonReembTodos.Name = "radioButtonReembTodos";
            this.radioButtonReembTodos.Size = new System.Drawing.Size(75, 27);
            this.radioButtonReembTodos.TabIndex = 3;
            this.radioButtonReembTodos.Text = "Todos";
            this.radioButtonReembTodos.UseVisualStyleBackColor = true;
            this.radioButtonReembTodos.CheckedChanged += new System.EventHandler(this.radioButtonReemb_CheckedChanged);
            // 
            // radioButtonReembValorIgual
            // 
            this.radioButtonReembValorIgual.AutoSize = true;
            this.radioButtonReembValorIgual.Checked = true;
            this.radioButtonReembValorIgual.ForeColor = System.Drawing.Color.Black;
            this.radioButtonReembValorIgual.Location = new System.Drawing.Point(22, 8);
            this.radioButtonReembValorIgual.Name = "radioButtonReembValorIgual";
            this.radioButtonReembValorIgual.Size = new System.Drawing.Size(112, 27);
            this.radioButtonReembValorIgual.TabIndex = 2;
            this.radioButtonReembValorIgual.TabStop = true;
            this.radioButtonReembValorIgual.Text = "Valor igual";
            this.radioButtonReembValorIgual.UseVisualStyleBackColor = true;
            this.radioButtonReembValorIgual.CheckedChanged += new System.EventHandler(this.radioButtonReemb_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Banco";
            this.dataGridViewTextBoxColumn2.HeaderText = "Banco";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Data";
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Valor";
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Grupo";
            this.dataGridViewTextBoxColumn5.HeaderText = "Grupo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Categoria";
            this.dataGridViewTextBoxColumn6.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SubCategoria";
            this.dataGridViewTextBoxColumn7.HeaderText = "SubCategoria";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn8.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // bancoDataGridViewTextBoxColumn
            // 
            this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            this.bancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            this.categoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subCategoriaDataGridViewTextBoxColumn
            // 
            this.subCategoriaDataGridViewTextBoxColumn.DataPropertyName = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.HeaderText = "SubCategoria";
            this.subCategoriaDataGridViewTextBoxColumn.Name = "subCategoriaDataGridViewTextBoxColumn";
            this.subCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IDAssociado
            // 
            this.IDAssociado.DataPropertyName = "IDAssociado";
            this.IDAssociado.HeaderText = "Reemb";
            this.IDAssociado.Name = "IDAssociado";
            // 
            // frmAssociador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAssociador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamentos e Reembolsos";
            this.Load += new System.EventHandler(this.frmAssociador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReembolsos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReembolsos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourcePagamentos;
        private System.Windows.Forms.DataGridView dgvPagamentos;
        private System.Windows.Forms.DataGridView dgvReembolsos;
        private System.Windows.Forms.BindingSource bindingSourceReembolsos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelPagamentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.RadioButton radioButtonPagtosAssociados;
        private System.Windows.Forms.RadioButton radioButtonPagtosPendentes;
        private System.Windows.Forms.RadioButton radioButtonPagtosTodos;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.ComboBox comboBoxGrupo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonReembTodos;
        private System.Windows.Forms.RadioButton radioButtonReembValorIgual;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAssociado;
    }
}