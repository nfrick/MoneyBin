namespace MoneyBin {
    partial class frmReport {
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.AnalysisItemAnoMesGrupoCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonByMonth = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonByGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelBanco = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxBanco = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelInicio = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelTermino = new System.Windows.Forms.ToolStripLabel();
            this.BalanceItemComGrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisItemAnoMesGrupoCategoriaBindingSource)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceItemComGrupoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetBalance";
            reportDataSource1.Value = this.BalanceItemComGrupoBindingSource;
            this.rptViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewer.LocalReport.ReportEmbeddedResource = "MoneyBin.Reports.ReportBalance.rdlc";
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.rptViewer.Size = new System.Drawing.Size(1446, 555);
            this.rptViewer.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.rptViewer);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1446, 555);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1446, 583);
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
            this.toolStripButton1,
            this.toolStripButtonByMonth,
            this.toolStripButtonByGroup,
            this.toolStripSeparator1,
            this.toolStripLabelBanco,
            this.toolStripComboBoxBanco,
            this.toolStripLabelInicio,
            this.toolStripLabelTermino});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(462, 28);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 25);
            this.toolStripButton1.Tag = "Balance";
            this.toolStripButton1.Text = "Balance";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButtonReport_Click);
            // 
            // toolStripButtonByMonth
            // 
            this.toolStripButtonByMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStripButtonByMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonByMonth.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonByMonth.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonByMonth.Image")));
            this.toolStripButtonByMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonByMonth.Name = "toolStripButtonByMonth";
            this.toolStripButtonByMonth.Size = new System.Drawing.Size(76, 25);
            this.toolStripButtonByMonth.Tag = "ComDescricao";
            this.toolStripButtonByMonth.Text = "By Month";
            this.toolStripButtonByMonth.Click += new System.EventHandler(this.ToolStripButtonReport_Click);
            // 
            // toolStripButtonByGroup
            // 
            this.toolStripButtonByGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripButtonByGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonByGroup.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonByGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonByGroup.Image")));
            this.toolStripButtonByGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonByGroup.Name = "toolStripButtonByGroup";
            this.toolStripButtonByGroup.Size = new System.Drawing.Size(74, 25);
            this.toolStripButtonByGroup.Tag = "PorGrupo";
            this.toolStripButtonByGroup.Text = "By Group";
            this.toolStripButtonByGroup.Click += new System.EventHandler(this.ToolStripButtonReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabelBanco
            // 
            this.toolStripLabelBanco.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabelBanco.Name = "toolStripLabelBanco";
            this.toolStripLabelBanco.Size = new System.Drawing.Size(53, 25);
            this.toolStripLabelBanco.Text = "Banco:";
            // 
            // toolStripComboBoxBanco
            // 
            this.toolStripComboBoxBanco.AutoSize = false;
            this.toolStripComboBoxBanco.ForeColor = System.Drawing.Color.Black;
            this.toolStripComboBoxBanco.Name = "toolStripComboBoxBanco";
            this.toolStripComboBoxBanco.Size = new System.Drawing.Size(60, 28);
            this.toolStripComboBoxBanco.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxBanco_SelectedIndexChanged);
            // 
            // toolStripLabelInicio
            // 
            this.toolStripLabelInicio.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabelInicio.Name = "toolStripLabelInicio";
            this.toolStripLabelInicio.Size = new System.Drawing.Size(48, 25);
            this.toolStripLabelInicio.Text = "Início:";
            // 
            // toolStripLabelTermino
            // 
            this.toolStripLabelTermino.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabelTermino.Name = "toolStripLabelTermino";
            this.toolStripLabelTermino.Size = new System.Drawing.Size(66, 25);
            this.toolStripLabelTermino.Text = "Término:";
            // 
            // BalanceItemComGrupoBindingSource
            // 
            this.BalanceItemComGrupoBindingSource.DataMember = "BalanceItemComGrupo";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 583);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisItemAnoMesGrupoCategoriaBindingSource)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceItemComGrupoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.BindingSource AnalysisItemAnoMesGrupoCategoriaBindingSource;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButtonByMonth;
        private System.Windows.Forms.ToolStripButton toolStripButtonByGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxBanco;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBanco;
        private System.Windows.Forms.ToolStripLabel toolStripLabelInicio;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTermino;
        private System.Windows.Forms.BindingSource BalanceItemComGrupoBindingSource;
    }
}