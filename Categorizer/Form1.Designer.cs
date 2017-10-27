namespace Categorizer {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.txtSubCategoria = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxNovoGrupo = new System.Windows.Forms.ComboBox();
            this.txtNovaCategoria = new System.Windows.Forms.TextBox();
            this.txtNovaSubCategoria = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCategoriaToList = new System.Windows.Forms.Button();
            this.btnSubCategoriaToList = new System.Windows.Forms.Button();
            this.btnDescricaoToList = new System.Windows.Forms.Button();
            this.btnDescricaoClear = new System.Windows.Forms.Button();
            this.btnDesricaoToSubCategoria = new System.Windows.Forms.Button();
            this.entityBindingNavigator1 = new EFWinforms.EntityBindingNavigator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.entityBindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCategoria
            // 
            this.txtCategoria.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Categoria", true));
            this.txtCategoria.Location = new System.Drawing.Point(24, 196);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(277, 38);
            this.txtCategoria.TabIndex = 5;
            this.txtCategoria.Text = "Categoria";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(Categorizer.MoneyBinEntities);
            // 
            // txtSubCategoria
            // 
            this.txtSubCategoria.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.SubCategoria", true));
            this.txtSubCategoria.Location = new System.Drawing.Point(24, 241);
            this.txtSubCategoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSubCategoria.Name = "txtSubCategoria";
            this.txtSubCategoria.ReadOnly = true;
            this.txtSubCategoria.Size = new System.Drawing.Size(277, 38);
            this.txtSubCategoria.TabIndex = 6;
            this.txtSubCategoria.Text = "SubCategoria";
            // 
            // txtDescricao
            // 
            this.txtDescricao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Descricao", true));
            this.txtDescricao.Location = new System.Drawing.Point(372, 328);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(277, 38);
            this.txtDescricao.TabIndex = 10;
            this.txtDescricao.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Banco", true));
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Data", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd/MM/yyyy dddd"));
            this.label2.Location = new System.Drawing.Point(125, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Historico", true));
            this.label3.Location = new System.Drawing.Point(18, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Historico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Valor", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.label4.Location = new System.Drawing.Point(18, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.Grupo", true));
            this.label5.Location = new System.Drawing.Point(18, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grupo";
            // 
            // cbxNovoGrupo
            // 
            this.cbxNovoGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxNovoGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNovoGrupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.NovoGrupo", true));
            this.cbxNovoGrupo.FormattingEnabled = true;
            this.cbxNovoGrupo.Location = new System.Drawing.Point(372, 195);
            this.cbxNovoGrupo.Name = "cbxNovoGrupo";
            this.cbxNovoGrupo.Size = new System.Drawing.Size(277, 39);
            this.cbxNovoGrupo.TabIndex = 11;
            this.cbxNovoGrupo.Text = "NovoGrupo";
            // 
            // txtNovaCategoria
            // 
            this.txtNovaCategoria.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.NovaCategoria", true));
            this.txtNovaCategoria.Location = new System.Drawing.Point(372, 240);
            this.txtNovaCategoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovaCategoria.Name = "txtNovaCategoria";
            this.txtNovaCategoria.Size = new System.Drawing.Size(277, 38);
            this.txtNovaCategoria.TabIndex = 15;
            this.txtNovaCategoria.Text = "NovaCategoria";
            // 
            // txtNovaSubCategoria
            // 
            this.txtNovaSubCategoria.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Balance.NovaSubCategoria", true));
            this.txtNovaSubCategoria.Location = new System.Drawing.Point(372, 284);
            this.txtNovaSubCategoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovaSubCategoria.Name = "txtNovaSubCategoria";
            this.txtNovaSubCategoria.Size = new System.Drawing.Size(277, 38);
            this.txtNovaSubCategoria.TabIndex = 16;
            this.txtNovaSubCategoria.Text = "NovaSubCategoria";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(716, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(355, 283);
            this.listBox1.TabIndex = 17;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // btnCategoriaToList
            // 
            this.btnCategoriaToList.Location = new System.Drawing.Point(658, 241);
            this.btnCategoriaToList.Name = "btnCategoriaToList";
            this.btnCategoriaToList.Size = new System.Drawing.Size(37, 34);
            this.btnCategoriaToList.TabIndex = 19;
            this.btnCategoriaToList.UseVisualStyleBackColor = true;
            this.btnCategoriaToList.Click += new System.EventHandler(this.btnCategoriasToList_Click);
            // 
            // btnSubCategoriaToList
            // 
            this.btnSubCategoriaToList.Location = new System.Drawing.Point(658, 285);
            this.btnSubCategoriaToList.Name = "btnSubCategoriaToList";
            this.btnSubCategoriaToList.Size = new System.Drawing.Size(37, 34);
            this.btnSubCategoriaToList.TabIndex = 20;
            this.btnSubCategoriaToList.UseVisualStyleBackColor = true;
            this.btnSubCategoriaToList.Click += new System.EventHandler(this.btnSubCategoriasToList_Click);
            // 
            // btnDescricaoToList
            // 
            this.btnDescricaoToList.Location = new System.Drawing.Point(658, 329);
            this.btnDescricaoToList.Name = "btnDescricaoToList";
            this.btnDescricaoToList.Size = new System.Drawing.Size(37, 34);
            this.btnDescricaoToList.TabIndex = 21;
            this.btnDescricaoToList.UseVisualStyleBackColor = true;
            this.btnDescricaoToList.Click += new System.EventHandler(this.btnDescricoesToList_Click);
            // 
            // btnDescricaoClear
            // 
            this.btnDescricaoClear.Location = new System.Drawing.Point(325, 328);
            this.btnDescricaoClear.Name = "btnDescricaoClear";
            this.btnDescricaoClear.Size = new System.Drawing.Size(40, 37);
            this.btnDescricaoClear.TabIndex = 22;
            this.btnDescricaoClear.UseVisualStyleBackColor = true;
            this.btnDescricaoClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDesricaoToSubCategoria
            // 
            this.btnDesricaoToSubCategoria.Location = new System.Drawing.Point(325, 285);
            this.btnDesricaoToSubCategoria.Name = "btnDesricaoToSubCategoria";
            this.btnDesricaoToSubCategoria.Size = new System.Drawing.Size(40, 37);
            this.btnDesricaoToSubCategoria.TabIndex = 23;
            this.btnDesricaoToSubCategoria.UseVisualStyleBackColor = true;
            this.btnDesricaoToSubCategoria.Click += new System.EventHandler(this.button5_Click);
            // 
            // entityBindingNavigator1
            // 
            this.entityBindingNavigator1.DataMember = "Balance";
            this.entityBindingNavigator1.DataSource = this.entityDataSource1;
            this.entityBindingNavigator1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.entityBindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton6});
            this.entityBindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.entityBindingNavigator1.Name = "entityBindingNavigator1";
            this.entityBindingNavigator1.Size = new System.Drawing.Size(1108, 37);
            this.entityBindingNavigator1.TabIndex = 0;
            this.entityBindingNavigator1.Text = "entityBindingNavigator1";
            this.entityBindingNavigator1.PositionChanged += new System.EventHandler(this.entityBindingNavigator1_PositionChanged);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(57, 34);
            this.toolStripButton5.Text = "-1000";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 34);
            this.toolStripButton1.Text = "-100";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(39, 34);
            this.toolStripButton3.Text = "-50";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(44, 34);
            this.toolStripButton4.Text = "+50";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(53, 34);
            this.toolStripButton2.Text = "+100";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(62, 34);
            this.toolStripButton6.Text = "+1000";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 383);
            this.Controls.Add(this.btnDesricaoToSubCategoria);
            this.Controls.Add(this.btnDescricaoClear);
            this.Controls.Add(this.btnDescricaoToList);
            this.Controls.Add(this.btnSubCategoriaToList);
            this.Controls.Add(this.btnCategoriaToList);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtNovaSubCategoria);
            this.Controls.Add(this.txtNovaCategoria);
            this.Controls.Add(this.cbxNovoGrupo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtSubCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.entityBindingNavigator1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.entityBindingNavigator1.ResumeLayout(false);
            this.entityBindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EFWinforms.EntityDataSource entityDataSource1;
        private EFWinforms.EntityBindingNavigator entityBindingNavigator1;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtSubCategoria;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxNovoGrupo;
        private System.Windows.Forms.TextBox txtNovaCategoria;
        private System.Windows.Forms.TextBox txtNovaSubCategoria;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCategoriaToList;
        private System.Windows.Forms.Button btnSubCategoriaToList;
        private System.Windows.Forms.Button btnDescricaoToList;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button btnDescricaoClear;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Button btnDesricaoToSubCategoria;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
    }
}

