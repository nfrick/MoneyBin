﻿namespace MoneyBin {
    partial class frmMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripButtonContas = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonViewer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReader = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReembolsos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRules = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPayments = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCalendar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBackground = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonContas,
            this.toolStripButtonViewer,
            this.toolStripButtonReader,
            this.toolStripButtonReembolsos,
            this.toolStripButtonAnalysis,
            this.toolStripButtonReport,
            this.toolStripButtonExport,
            this.toolStripButtonRules,
            this.toolStripButtonPayments,
            this.toolStripButtonCalendar,
            this.toolStripButtonBackground});
            this.toolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(1684, 54);
            this.toolStripMainMenu.TabIndex = 1;
            this.toolStripMainMenu.Text = "toolStrip1";
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripButtonContas
            // 
            this.toolStripButtonContas.Image = global::MoneyBin.Properties.Resources.money_wallet_icon;
            this.toolStripButtonContas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonContas.Name = "toolStripButtonContas";
            this.toolStripButtonContas.Size = new System.Drawing.Size(48, 51);
            this.toolStripButtonContas.Text = "Contas";
            this.toolStripButtonContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonContas.Click += new System.EventHandler(this.toolStripButtonContas_Click);
            // 
            // toolStripButtonViewer
            // 
            this.toolStripButtonViewer.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonViewer.Image = global::MoneyBin.Properties.Resources.table_edit_icon;
            this.toolStripButtonViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewer.Name = "toolStripButtonViewer";
            this.toolStripButtonViewer.Size = new System.Drawing.Size(47, 51);
            this.toolStripButtonViewer.Text = "Extrato";
            this.toolStripButtonViewer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonViewer.Click += new System.EventHandler(this.toolStripButtonNewViewer_Click);
            // 
            // toolStripButtonReader
            // 
            this.toolStripButtonReader.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonReader.Image = global::MoneyBin.Properties.Resources.glasses_icon;
            this.toolStripButtonReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReader.Name = "toolStripButtonReader";
            this.toolStripButtonReader.Size = new System.Drawing.Size(41, 51);
            this.toolStripButtonReader.Text = "Leitor";
            this.toolStripButtonReader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonReader.Click += new System.EventHandler(this.toolStripButtonNewReader_Click);
            // 
            // toolStripButtonReembolsos
            // 
            this.toolStripButtonReembolsos.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonReembolsos.Image = global::MoneyBin.Properties.Resources.rightleft2red;
            this.toolStripButtonReembolsos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReembolsos.Name = "toolStripButtonReembolsos";
            this.toolStripButtonReembolsos.Size = new System.Drawing.Size(75, 51);
            this.toolStripButtonReembolsos.Text = "Reembolsos";
            this.toolStripButtonReembolsos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonReembolsos.Click += new System.EventHandler(this.toolStripButtonReembolsos_Click);
            // 
            // toolStripButtonAnalysis
            // 
            this.toolStripButtonAnalysis.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonAnalysis.Image = global::MoneyBin.Properties.Resources.Document_Chart_icon;
            this.toolStripButtonAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnalysis.Name = "toolStripButtonAnalysis";
            this.toolStripButtonAnalysis.Size = new System.Drawing.Size(49, 51);
            this.toolStripButtonAnalysis.Text = "Análise";
            this.toolStripButtonAnalysis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAnalysis.Click += new System.EventHandler(this.toolStripButtonAnalysis_Click);
            // 
            // toolStripButtonReport
            // 
            this.toolStripButtonReport.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonReport.Image = global::MoneyBin.Properties.Resources.document_yellow_icon;
            this.toolStripButtonReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReport.Name = "toolStripButtonReport";
            this.toolStripButtonReport.Size = new System.Drawing.Size(63, 51);
            this.toolStripButtonReport.Text = "Relatórios";
            this.toolStripButtonReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonReport.Click += new System.EventHandler(this.toolStripButtonReport_Click);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonExport.Image = global::MoneyBin.Properties.Resources.export_icon;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(54, 51);
            this.toolStripButtonExport.Text = "Exportar";
            this.toolStripButtonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // toolStripButtonRules
            // 
            this.toolStripButtonRules.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonRules.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRules.Image")));
            this.toolStripButtonRules.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRules.Name = "toolStripButtonRules";
            this.toolStripButtonRules.Size = new System.Drawing.Size(46, 51);
            this.toolStripButtonRules.Text = "Regras";
            this.toolStripButtonRules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRules.Click += new System.EventHandler(this.toolStripButtonRules_Click);
            // 
            // toolStripButtonPayments
            // 
            this.toolStripButtonPayments.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonPayments.Image = global::MoneyBin.Properties.Resources.money_icon;
            this.toolStripButtonPayments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPayments.Name = "toolStripButtonPayments";
            this.toolStripButtonPayments.Size = new System.Drawing.Size(77, 51);
            this.toolStripButtonPayments.Text = "Pagamentos";
            this.toolStripButtonPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPayments.Click += new System.EventHandler(this.toolStripButtonPayments_Click);
            // 
            // toolStripButtonCalendar
            // 
            this.toolStripButtonCalendar.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonCalendar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCalendar.Image")));
            this.toolStripButtonCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCalendar.Name = "toolStripButtonCalendar";
            this.toolStripButtonCalendar.Size = new System.Drawing.Size(68, 51);
            this.toolStripButtonCalendar.Text = "Calendário";
            this.toolStripButtonCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCalendar.Click += new System.EventHandler(this.toolStripButtonCalendar_Click);
            // 
            // toolStripButtonBackground
            // 
            this.toolStripButtonBackground.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonBackground.Image = global::MoneyBin.Properties.Resources.Uncle_Scrooge_McDuck;
            this.toolStripButtonBackground.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBackground.Name = "toolStripButtonBackground";
            this.toolStripButtonBackground.Size = new System.Drawing.Size(75, 51);
            this.toolStripButtonBackground.Text = "Background";
            this.toolStripButtonBackground.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBackground.Click += new System.EventHandler(this.toolStripButtonBackground_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1684, 1031);
            this.Controls.Add(this.toolStripMainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Green;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Money Bin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewer;
        private System.Windows.Forms.ToolStripButton toolStripButtonReader;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnalysis;
        private System.Windows.Forms.ToolStripButton toolStripButtonReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonRules;
        private System.Windows.Forms.ToolStripButton toolStripButtonPayments;
        private System.Windows.Forms.ToolStripButton toolStripButtonCalendar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBackground;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonReembolsos;
        private System.Windows.Forms.ToolStripButton toolStripButtonContas;
    }
}