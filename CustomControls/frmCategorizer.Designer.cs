namespace CustomControls {
    partial class frmCategorizer {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxGrupo = new System.Windows.Forms.CheckBox();
            this.textBoxGrupo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxSubCategoria = new System.Windows.Forms.CheckBox();
            this.textBoxSubCategoria = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxCategoria = new System.Windows.Forms.CheckBox();
            this.textBoxCategoria = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxDescricao = new System.Windows.Forms.CheckBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonPreencher = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.16667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.16667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(485, 117);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxGrupo);
            this.panel1.Controls.Add(this.textBoxGrupo);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 51);
            this.panel1.TabIndex = 8;
            // 
            // checkBoxGrupo
            // 
            this.checkBoxGrupo.AutoSize = true;
            this.checkBoxGrupo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxGrupo.Location = new System.Drawing.Point(3, 3);
            this.checkBoxGrupo.Name = "checkBoxGrupo";
            this.checkBoxGrupo.Size = new System.Drawing.Size(59, 19);
            this.checkBoxGrupo.TabIndex = 8;
            this.checkBoxGrupo.Text = "Grupo";
            this.checkBoxGrupo.UseVisualStyleBackColor = true;
            this.checkBoxGrupo.CheckedChanged += new System.EventHandler(this.checkBoxGrupo_CheckedChanged);
            // 
            // textBoxGrupo
            // 
            this.textBoxGrupo.Enabled = false;
            this.textBoxGrupo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxGrupo.Location = new System.Drawing.Point(3, 25);
            this.textBoxGrupo.Name = "textBoxGrupo";
            this.textBoxGrupo.Size = new System.Drawing.Size(109, 23);
            this.textBoxGrupo.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxSubCategoria);
            this.panel3.Controls.Add(this.textBoxSubCategoria);
            this.panel3.Location = new System.Drawing.Point(245, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 51);
            this.panel3.TabIndex = 11;
            // 
            // checkBoxSubCategoria
            // 
            this.checkBoxSubCategoria.AutoSize = true;
            this.checkBoxSubCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSubCategoria.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSubCategoria.Name = "checkBoxSubCategoria";
            this.checkBoxSubCategoria.Size = new System.Drawing.Size(97, 19);
            this.checkBoxSubCategoria.TabIndex = 10;
            this.checkBoxSubCategoria.Text = "SubCategoria";
            this.checkBoxSubCategoria.UseVisualStyleBackColor = true;
            this.checkBoxSubCategoria.CheckedChanged += new System.EventHandler(this.checkBoxSubCategoria_CheckedChanged);
            // 
            // textBoxSubCategoria
            // 
            this.textBoxSubCategoria.Enabled = false;
            this.textBoxSubCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSubCategoria.Location = new System.Drawing.Point(3, 25);
            this.textBoxSubCategoria.Name = "textBoxSubCategoria";
            this.textBoxSubCategoria.Size = new System.Drawing.Size(109, 23);
            this.textBoxSubCategoria.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxCategoria);
            this.panel2.Controls.Add(this.textBoxCategoria);
            this.panel2.Location = new System.Drawing.Point(124, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(115, 51);
            this.panel2.TabIndex = 9;
            // 
            // checkBoxCategoria
            // 
            this.checkBoxCategoria.AutoSize = true;
            this.checkBoxCategoria.Location = new System.Drawing.Point(3, 5);
            this.checkBoxCategoria.Name = "checkBoxCategoria";
            this.checkBoxCategoria.Size = new System.Drawing.Size(71, 17);
            this.checkBoxCategoria.TabIndex = 9;
            this.checkBoxCategoria.Text = "Categoria";
            this.checkBoxCategoria.UseVisualStyleBackColor = true;
            this.checkBoxCategoria.CheckedChanged += new System.EventHandler(this.checkBoxCategoria_CheckedChanged);
            // 
            // textBoxCategoria
            // 
            this.textBoxCategoria.Enabled = false;
            this.textBoxCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxCategoria.Location = new System.Drawing.Point(3, 25);
            this.textBoxCategoria.Name = "textBoxCategoria";
            this.textBoxCategoria.Size = new System.Drawing.Size(109, 23);
            this.textBoxCategoria.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBoxDescricao);
            this.panel5.Controls.Add(this.textBoxDescricao);
            this.panel5.Location = new System.Drawing.Point(366, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(116, 51);
            this.panel5.TabIndex = 10;
            // 
            // checkBoxDescricao
            // 
            this.checkBoxDescricao.AutoSize = true;
            this.checkBoxDescricao.Location = new System.Drawing.Point(3, 5);
            this.checkBoxDescricao.Name = "checkBoxDescricao";
            this.checkBoxDescricao.Size = new System.Drawing.Size(74, 17);
            this.checkBoxDescricao.TabIndex = 9;
            this.checkBoxDescricao.Text = "Descrição";
            this.checkBoxDescricao.UseVisualStyleBackColor = true;
            this.checkBoxDescricao.CheckedChanged += new System.EventHandler(this.checkBoxDescricao_CheckedChanged);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Enabled = false;
            this.textBoxDescricao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDescricao.Location = new System.Drawing.Point(3, 25);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(109, 23);
            this.textBoxDescricao.TabIndex = 12;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.buttonPreencher);
            this.panel4.Location = new System.Drawing.Point(124, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 26);
            this.panel4.TabIndex = 12;
            // 
            // buttonPreencher
            // 
            this.buttonPreencher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPreencher.Location = new System.Drawing.Point(80, 2);
            this.buttonPreencher.Name = "buttonPreencher";
            this.buttonPreencher.Size = new System.Drawing.Size(75, 23);
            this.buttonPreencher.TabIndex = 17;
            this.buttonPreencher.Text = "Preencher";
            this.buttonPreencher.UseVisualStyleBackColor = true;
            this.buttonPreencher.Click += new System.EventHandler(this.buttonPreencher_Click);
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 4);
            this.panel6.Controls.Add(this.progressBar1);
            this.panel6.Location = new System.Drawing.Point(3, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(479, 22);
            this.panel6.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 22);
            this.progressBar1.TabIndex = 0;
            // 
            // frmCategorizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 117);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategorizer";
            this.Text = "Categorizer";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxCategoria;
        private System.Windows.Forms.TextBox textBoxCategoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxGrupo;
        private System.Windows.Forms.TextBox textBoxGrupo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxSubCategoria;
        private System.Windows.Forms.TextBox textBoxSubCategoria;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonPreencher;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBoxDescricao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}