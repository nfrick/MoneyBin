namespace MoneyBin {
    partial class frmAnalysis {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanelExternal = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTables = new System.Windows.Forms.TableLayoutPanel();
            this.AnoGrupoDataGridView = new System.Windows.Forms.DataGridView();
            this.AnoMesGrupoDataGridView = new System.Windows.Forms.DataGridView();
            this.AnoMesCategoriaDataGridView = new System.Windows.Forms.DataGridView();
            this.AnoMesGrupoCategoriaDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPageCharts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartAnoMesNegative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoMesPositive = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoPositive = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoNegative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.treeSelGroupsCats = new CustomControls.TreeSelector();
            this.treeSelMonths = new CustomControls.TreeSelector();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanelExternal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tableLayoutPanelTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnoGrupoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesGrupoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesCategoriaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesGrupoCategoriaDataGridView)).BeginInit();
            this.tabPageCharts.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesNegative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoNegative)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanelExternal);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1805, 885);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.Size = new System.Drawing.Size(1805, 885);
            // 
            // tableLayoutPanelExternal
            // 
            this.tableLayoutPanelExternal.ColumnCount = 2;
            this.tableLayoutPanelExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanelExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 996F));
            this.tableLayoutPanelExternal.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanelExternal.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanelExternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExternal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelExternal.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanelExternal.Name = "tableLayoutPanelExternal";
            this.tableLayoutPanelExternal.RowCount = 1;
            this.tableLayoutPanelExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelExternal.Size = new System.Drawing.Size(1805, 885);
            this.tableLayoutPanelExternal.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTables);
            this.tabControl1.Controls.Add(this.tabPageCharts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(241, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1560, 877);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.tableLayoutPanelTables);
            this.tabPageTables.Location = new System.Drawing.Point(4, 30);
            this.tabPageTables.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTables.Size = new System.Drawing.Size(1552, 843);
            this.tabPageTables.TabIndex = 0;
            this.tabPageTables.Text = "Tables";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTables
            // 
            this.tableLayoutPanelTables.ColumnCount = 2;
            this.tableLayoutPanelTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTables.Controls.Add(this.AnoGrupoDataGridView, 1, 0);
            this.tableLayoutPanelTables.Controls.Add(this.AnoMesGrupoDataGridView, 0, 1);
            this.tableLayoutPanelTables.Controls.Add(this.AnoMesCategoriaDataGridView, 0, 1);
            this.tableLayoutPanelTables.Controls.Add(this.AnoMesGrupoCategoriaDataGridView, 0, 0);
            this.tableLayoutPanelTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTables.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelTables.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelTables.Name = "tableLayoutPanelTables";
            this.tableLayoutPanelTables.RowCount = 2;
            this.tableLayoutPanelTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelTables.Size = new System.Drawing.Size(1544, 835);
            this.tableLayoutPanelTables.TabIndex = 0;
            // 
            // AnoGrupoDataGridView
            // 
            this.AnoGrupoDataGridView.AllowUserToAddRows = false;
            this.AnoGrupoDataGridView.AllowUserToDeleteRows = false;
            this.AnoGrupoDataGridView.AllowUserToOrderColumns = true;
            this.AnoGrupoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnoGrupoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnoGrupoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnoGrupoDataGridView.Location = new System.Drawing.Point(776, 4);
            this.AnoGrupoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AnoGrupoDataGridView.Name = "AnoGrupoDataGridView";
            this.AnoGrupoDataGridView.ReadOnly = true;
            this.AnoGrupoDataGridView.RowTemplate.Height = 32;
            this.AnoGrupoDataGridView.Size = new System.Drawing.Size(764, 409);
            this.AnoGrupoDataGridView.TabIndex = 10;
            // 
            // AnoMesGrupoDataGridView
            // 
            this.AnoMesGrupoDataGridView.AllowUserToAddRows = false;
            this.AnoMesGrupoDataGridView.AllowUserToDeleteRows = false;
            this.AnoMesGrupoDataGridView.AllowUserToOrderColumns = true;
            this.AnoMesGrupoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnoMesGrupoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnoMesGrupoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnoMesGrupoDataGridView.Location = new System.Drawing.Point(4, 421);
            this.AnoMesGrupoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AnoMesGrupoDataGridView.Name = "AnoMesGrupoDataGridView";
            this.AnoMesGrupoDataGridView.ReadOnly = true;
            this.AnoMesGrupoDataGridView.RowTemplate.Height = 32;
            this.AnoMesGrupoDataGridView.Size = new System.Drawing.Size(764, 410);
            this.AnoMesGrupoDataGridView.TabIndex = 9;
            // 
            // AnoMesCategoriaDataGridView
            // 
            this.AnoMesCategoriaDataGridView.AllowUserToAddRows = false;
            this.AnoMesCategoriaDataGridView.AllowUserToDeleteRows = false;
            this.AnoMesCategoriaDataGridView.AllowUserToOrderColumns = true;
            this.AnoMesCategoriaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnoMesCategoriaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnoMesCategoriaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnoMesCategoriaDataGridView.Location = new System.Drawing.Point(776, 421);
            this.AnoMesCategoriaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AnoMesCategoriaDataGridView.Name = "AnoMesCategoriaDataGridView";
            this.AnoMesCategoriaDataGridView.ReadOnly = true;
            this.AnoMesCategoriaDataGridView.RowTemplate.Height = 32;
            this.AnoMesCategoriaDataGridView.Size = new System.Drawing.Size(764, 410);
            this.AnoMesCategoriaDataGridView.TabIndex = 8;
            // 
            // AnoMesGrupoCategoriaDataGridView
            // 
            this.AnoMesGrupoCategoriaDataGridView.AllowUserToAddRows = false;
            this.AnoMesGrupoCategoriaDataGridView.AllowUserToDeleteRows = false;
            this.AnoMesGrupoCategoriaDataGridView.AllowUserToOrderColumns = true;
            this.AnoMesGrupoCategoriaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnoMesGrupoCategoriaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnoMesGrupoCategoriaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnoMesGrupoCategoriaDataGridView.Location = new System.Drawing.Point(4, 4);
            this.AnoMesGrupoCategoriaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AnoMesGrupoCategoriaDataGridView.Name = "AnoMesGrupoCategoriaDataGridView";
            this.AnoMesGrupoCategoriaDataGridView.ReadOnly = true;
            this.AnoMesGrupoCategoriaDataGridView.RowHeadersVisible = false;
            this.AnoMesGrupoCategoriaDataGridView.RowTemplate.Height = 32;
            this.AnoMesGrupoCategoriaDataGridView.Size = new System.Drawing.Size(764, 409);
            this.AnoMesGrupoCategoriaDataGridView.TabIndex = 7;
            // 
            // tabPageCharts
            // 
            this.tabPageCharts.Controls.Add(this.tableLayoutPanelCharts);
            this.tabPageCharts.Location = new System.Drawing.Point(4, 30);
            this.tabPageCharts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageCharts.Name = "tabPageCharts";
            this.tabPageCharts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageCharts.Size = new System.Drawing.Size(980, 0);
            this.tabPageCharts.TabIndex = 1;
            this.tabPageCharts.Text = "Charts";
            this.tabPageCharts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoMesNegative, 0, 1);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoMesPositive, 0, 1);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoPositive, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoNegative, 1, 0);
            this.tableLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelCharts.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 2;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(972, 0);
            this.tableLayoutPanelCharts.TabIndex = 0;
            // 
            // chartAnoMesNegative
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAnoMesNegative.ChartAreas.Add(chartArea1);
            this.chartAnoMesNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartAnoMesNegative.Legends.Add(legend1);
            this.chartAnoMesNegative.Location = new System.Drawing.Point(4, 4);
            this.chartAnoMesNegative.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoMesNegative.Name = "chartAnoMesNegative";
            this.chartAnoMesNegative.Size = new System.Drawing.Size(478, 1);
            this.chartAnoMesNegative.TabIndex = 11;
            // 
            // chartAnoMesPositive
            // 
            this.chartAnoMesPositive.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chartAnoMesPositive.ChartAreas.Add(chartArea2);
            this.chartAnoMesPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartAnoMesPositive.Legends.Add(legend2);
            this.chartAnoMesPositive.Location = new System.Drawing.Point(490, 4);
            this.chartAnoMesPositive.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoMesPositive.Name = "chartAnoMesPositive";
            this.chartAnoMesPositive.Size = new System.Drawing.Size(478, 1);
            this.chartAnoMesPositive.TabIndex = 9;
            // 
            // chartAnoPositive
            // 
            this.chartAnoPositive.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.Name = "ChartArea1";
            this.chartAnoPositive.ChartAreas.Add(chartArea3);
            this.chartAnoPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartAnoPositive.Legends.Add(legend3);
            this.chartAnoPositive.Location = new System.Drawing.Point(4, 4);
            this.chartAnoPositive.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoPositive.Name = "chartAnoPositive";
            this.chartAnoPositive.Size = new System.Drawing.Size(478, 1);
            this.chartAnoPositive.TabIndex = 8;
            // 
            // chartAnoNegative
            // 
            chartArea4.Name = "ChartArea1";
            this.chartAnoNegative.ChartAreas.Add(chartArea4);
            this.chartAnoNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartAnoNegative.Legends.Add(legend4);
            this.chartAnoNegative.Location = new System.Drawing.Point(490, 4);
            this.chartAnoNegative.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoNegative.Name = "chartAnoNegative";
            this.chartAnoNegative.Size = new System.Drawing.Size(478, 1);
            this.chartAnoNegative.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.treeSelGroupsCats, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.treeSelMonths, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(229, 877);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // treeSelGroupsCats
            // 
            this.treeSelGroupsCats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSelGroupsCats.ItemName = null;
            this.treeSelGroupsCats.Location = new System.Drawing.Point(5, 443);
            this.treeSelGroupsCats.Margin = new System.Windows.Forms.Padding(5);
            this.treeSelGroupsCats.Name = "treeSelGroupsCats";
            this.treeSelGroupsCats.Size = new System.Drawing.Size(219, 429);
            this.treeSelGroupsCats.SubItemName = null;
            this.treeSelGroupsCats.TabIndex = 5;
            // 
            // treeSelMonths
            // 
            this.treeSelMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSelMonths.ItemName = null;
            this.treeSelMonths.Location = new System.Drawing.Point(5, 5);
            this.treeSelMonths.Margin = new System.Windows.Forms.Padding(5);
            this.treeSelMonths.Name = "treeSelMonths";
            this.treeSelMonths.Size = new System.Drawing.Size(219, 428);
            this.treeSelMonths.SubItemName = null;
            this.treeSelMonths.TabIndex = 4;
            // 
            // frmAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1805, 885);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analysis";
            this.Load += new System.EventHandler(this.frmAnalysis_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanelExternal.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tableLayoutPanelTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnoGrupoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesGrupoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesCategoriaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnoMesGrupoCategoriaDataGridView)).EndInit();
            this.tabPageCharts.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesNegative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoNegative)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExternal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTables;
        private System.Windows.Forms.DataGridView AnoGrupoDataGridView;
        private System.Windows.Forms.DataGridView AnoMesGrupoDataGridView;
        private System.Windows.Forms.DataGridView AnoMesCategoriaDataGridView;
        private System.Windows.Forms.DataGridView AnoMesGrupoCategoriaDataGridView;
        private System.Windows.Forms.TabPage tabPageCharts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoMesNegative;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoMesPositive;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoPositive;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoNegative;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CustomControls.TreeSelector treeSelGroupsCats;
        private CustomControls.TreeSelector treeSelMonths;
    }
}
