using CustomControls;


namespace MoneyBin {
    partial class frmViewer {
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
            this.buttonExpand = new System.Windows.Forms.Button();
            this.balanceGrid1 = new CustomControls.BalanceGrid();
            this.tableLayoutPanelColunas = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelControles = new System.Windows.Forms.TableLayoutPanel();
            this.treeSelector1 = new CustomControls.TreeSelector();
            this.panelCollapse = new System.Windows.Forms.Panel();
            this.buttonCollapse = new System.Windows.Forms.Button();
            this.panelBanco = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBanco = new System.Windows.Forms.ComboBox();
            this.panelDatas = new System.Windows.Forms.Panel();
            this.dateTimePickerTermino = new System.Windows.Forms.DateTimePicker();
            this.labelTermino = new System.Windows.Forms.Label();
            this.labelInicio = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanelColunas.SuspendLayout();
            this.tableLayoutPanelControles.SuspendLayout();
            this.panelCollapse.SuspendLayout();
            this.panelBanco.SuspendLayout();
            this.panelDatas.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanelColunas);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1341, 562);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.Size = new System.Drawing.Size(1341, 562);
            // 
            // buttonExpand
            // 
            this.buttonExpand.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonExpand.Location = new System.Drawing.Point(4, 4);
            this.buttonExpand.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(16, 30);
            this.buttonExpand.TabIndex = 29;
            this.buttonExpand.Text = "4";
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // balanceGrid1
            // 
            this.balanceGrid1.AutoSize = true;
            this.balanceGrid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.balanceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceGrid1.Location = new System.Drawing.Point(204, 5);
            this.balanceGrid1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.balanceGrid1.Name = "balanceGrid1";
            this.balanceGrid1.Size = new System.Drawing.Size(1133, 552);
            this.balanceGrid1.TabIndex = 31;
            // 
            // tableLayoutPanelColunas
            // 
            this.tableLayoutPanelColunas.ColumnCount = 2;
            this.tableLayoutPanelColunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelColunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColunas.Controls.Add(this.tableLayoutPanelControles, 0, 0);
            this.tableLayoutPanelColunas.Controls.Add(this.balanceGrid1, 1, 0);
            this.tableLayoutPanelColunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColunas.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelColunas.Name = "tableLayoutPanelColunas";
            this.tableLayoutPanelColunas.RowCount = 1;
            this.tableLayoutPanelColunas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelColunas.Size = new System.Drawing.Size(1341, 562);
            this.tableLayoutPanelColunas.TabIndex = 2;
            // 
            // tableLayoutPanelControles
            // 
            this.tableLayoutPanelControles.ColumnCount = 2;
            this.tableLayoutPanelControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanelControles.Controls.Add(this.treeSelector1, 1, 3);
            this.tableLayoutPanelControles.Controls.Add(this.panelCollapse, 1, 0);
            this.tableLayoutPanelControles.Controls.Add(this.buttonExpand, 0, 0);
            this.tableLayoutPanelControles.Controls.Add(this.panelBanco, 1, 1);
            this.tableLayoutPanelControles.Controls.Add(this.panelDatas, 1, 2);
            this.tableLayoutPanelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControles.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanelControles.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanelControles.Name = "tableLayoutPanelControles";
            this.tableLayoutPanelControles.RowCount = 4;
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControles.Size = new System.Drawing.Size(200, 556);
            this.tableLayoutPanelControles.TabIndex = 0;
            // 
            // treeSelector1
            // 
            this.treeSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSelector1.ItemName = null;
            this.treeSelector1.Location = new System.Drawing.Point(28, 269);
            this.treeSelector1.Margin = new System.Windows.Forms.Padding(4, 27, 4, 27);
            this.treeSelector1.Name = "treeSelector1";
            this.treeSelector1.Size = new System.Drawing.Size(172, 260);
            this.treeSelector1.SubItemName = null;
            this.treeSelector1.TabIndex = 38;
            // 
            // panelCollapse
            // 
            this.panelCollapse.BackColor = System.Drawing.Color.Transparent;
            this.panelCollapse.Controls.Add(this.buttonCollapse);
            this.panelCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCollapse.Location = new System.Drawing.Point(28, 4);
            this.panelCollapse.Margin = new System.Windows.Forms.Padding(4);
            this.panelCollapse.Name = "panelCollapse";
            this.panelCollapse.Size = new System.Drawing.Size(172, 30);
            this.panelCollapse.TabIndex = 31;
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCollapse.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonCollapse.Location = new System.Drawing.Point(154, 0);
            this.buttonCollapse.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCollapse.Name = "buttonCollapse";
            this.buttonCollapse.Size = new System.Drawing.Size(18, 30);
            this.buttonCollapse.TabIndex = 25;
            this.buttonCollapse.Text = "3";
            this.buttonCollapse.UseVisualStyleBackColor = true;
            this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
            // 
            // panelBanco
            // 
            this.panelBanco.Controls.Add(this.buttonExport);
            this.panelBanco.Controls.Add(this.label1);
            this.panelBanco.Controls.Add(this.comboBoxBanco);
            this.panelBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBanco.Location = new System.Drawing.Point(28, 42);
            this.panelBanco.Margin = new System.Windows.Forms.Padding(4);
            this.panelBanco.Name = "panelBanco";
            this.panelBanco.Size = new System.Drawing.Size(172, 64);
            this.panelBanco.TabIndex = 32;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(123, 31);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(31, 29);
            this.buttonExport.TabIndex = 13;
            this.buttonExport.Text = "E";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Banco";
            // 
            // comboBoxBanco
            // 
            this.comboBoxBanco.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxBanco.FormattingEnabled = true;
            this.comboBoxBanco.Items.AddRange(new object[] {
            "BB",
            "CEF",
            "STD"});
            this.comboBoxBanco.Location = new System.Drawing.Point(8, 30);
            this.comboBoxBanco.Name = "comboBoxBanco";
            this.comboBoxBanco.Size = new System.Drawing.Size(102, 31);
            this.comboBoxBanco.TabIndex = 0;
            this.comboBoxBanco.Text = "BB";
            this.comboBoxBanco.SelectedValueChanged += new System.EventHandler(this.comboBoxBanco_SelectedValueChanged);
            // 
            // panelDatas
            // 
            this.panelDatas.Controls.Add(this.dateTimePickerTermino);
            this.panelDatas.Controls.Add(this.labelTermino);
            this.panelDatas.Controls.Add(this.labelInicio);
            this.panelDatas.Controls.Add(this.dateTimePickerInicio);
            this.panelDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatas.Location = new System.Drawing.Point(28, 114);
            this.panelDatas.Margin = new System.Windows.Forms.Padding(4);
            this.panelDatas.Name = "panelDatas";
            this.panelDatas.Size = new System.Drawing.Size(172, 124);
            this.panelDatas.TabIndex = 33;
            // 
            // dateTimePickerTermino
            // 
            this.dateTimePickerTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTermino.Location = new System.Drawing.Point(7, 86);
            this.dateTimePickerTermino.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTermino.Name = "dateTimePickerTermino";
            this.dateTimePickerTermino.Size = new System.Drawing.Size(103, 30);
            this.dateTimePickerTermino.TabIndex = 10;
            this.dateTimePickerTermino.ValueChanged += new System.EventHandler(this.dateTimePickerTermino_ValueChanged);
            // 
            // labelTermino
            // 
            this.labelTermino.AutoSize = true;
            this.labelTermino.ForeColor = System.Drawing.Color.Black;
            this.labelTermino.Location = new System.Drawing.Point(4, 63);
            this.labelTermino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTermino.Name = "labelTermino";
            this.labelTermino.Size = new System.Drawing.Size(71, 23);
            this.labelTermino.TabIndex = 12;
            this.labelTermino.Text = "Término";
            this.labelTermino.Click += new System.EventHandler(this.labelTermino_Click);
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.ForeColor = System.Drawing.Color.Black;
            this.labelInicio.Location = new System.Drawing.Point(4, 5);
            this.labelInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(51, 23);
            this.labelInicio.TabIndex = 11;
            this.labelInicio.Text = "Início";
            this.labelInicio.Click += new System.EventHandler(this.labelInicio_Click);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(7, 29);
            this.dateTimePickerInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(103, 30);
            this.dateTimePickerInicio.TabIndex = 9;
            this.dateTimePickerInicio.ValueChanged += new System.EventHandler(this.dateTimePickerInicio_ValueChanged);
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1341, 562);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewer_FormClosing);
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanelColunas.ResumeLayout(false);
            this.tableLayoutPanelColunas.PerformLayout();
            this.tableLayoutPanelControles.ResumeLayout(false);
            this.panelCollapse.ResumeLayout(false);
            this.panelBanco.ResumeLayout(false);
            this.panelBanco.PerformLayout();
            this.panelDatas.ResumeLayout(false);
            this.panelDatas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonExpand;
        private BalanceGrid balanceGrid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColunas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControles;
        private TreeSelector treeSelector1;
        private System.Windows.Forms.Panel panelCollapse;
        private System.Windows.Forms.Button buttonCollapse;
        private System.Windows.Forms.Panel panelBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBanco;
        private System.Windows.Forms.Panel panelDatas;
        private System.Windows.Forms.DateTimePicker dateTimePickerTermino;
        private System.Windows.Forms.Label labelTermino;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Button buttonExport;
    }
}
