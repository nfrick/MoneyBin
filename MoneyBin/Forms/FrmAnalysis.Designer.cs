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
            this.dgvAnoGrupo = new System.Windows.Forms.DataGridView();
            this.dgvAnoMesGrupo = new System.Windows.Forms.DataGridView();
            this.dgvGrupoMesAno = new System.Windows.Forms.DataGridView();
            this.dgvAnoMesGrupoCategoria = new System.Windows.Forms.DataGridView();
            this.tabPageCharts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartAnoNegative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoPositive = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoMesPositive = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnoMesNegative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.treeSelGroupsCats = new CustomControls.TreeSelector();
            this.treeSelMonths = new CustomControls.TreeSelector();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanelExternal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tableLayoutPanelTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoMesGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoMesAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoMesGrupoCategoria)).BeginInit();
            this.tabPageCharts.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoNegative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesNegative)).BeginInit();
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
            this.tableLayoutPanelTables.Controls.Add(this.dgvAnoGrupo, 1, 0);
            this.tableLayoutPanelTables.Controls.Add(this.dgvAnoMesGrupo, 0, 1);
            this.tableLayoutPanelTables.Controls.Add(this.dgvGrupoMesAno, 0, 1);
            this.tableLayoutPanelTables.Controls.Add(this.dgvAnoMesGrupoCategoria, 0, 0);
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
            // dgvAnoGrupo
            // 
            this.dgvAnoGrupo.AllowUserToAddRows = false;
            this.dgvAnoGrupo.AllowUserToDeleteRows = false;
            this.dgvAnoGrupo.AllowUserToOrderColumns = true;
            this.dgvAnoGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnoGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnoGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnoGrupo.Location = new System.Drawing.Point(776, 4);
            this.dgvAnoGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnoGrupo.Name = "dgvAnoGrupo";
            this.dgvAnoGrupo.ReadOnly = true;
            this.dgvAnoGrupo.RowTemplate.Height = 32;
            this.dgvAnoGrupo.Size = new System.Drawing.Size(764, 409);
            this.dgvAnoGrupo.TabIndex = 10;
            // 
            // dgvAnoMesGrupo
            // 
            this.dgvAnoMesGrupo.AllowUserToAddRows = false;
            this.dgvAnoMesGrupo.AllowUserToDeleteRows = false;
            this.dgvAnoMesGrupo.AllowUserToOrderColumns = true;
            this.dgvAnoMesGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnoMesGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnoMesGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnoMesGrupo.Location = new System.Drawing.Point(4, 421);
            this.dgvAnoMesGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnoMesGrupo.Name = "dgvAnoMesGrupo";
            this.dgvAnoMesGrupo.ReadOnly = true;
            this.dgvAnoMesGrupo.RowTemplate.Height = 32;
            this.dgvAnoMesGrupo.Size = new System.Drawing.Size(764, 410);
            this.dgvAnoMesGrupo.TabIndex = 9;
            // 
            // dgvGrupoMesAno
            // 
            this.dgvGrupoMesAno.AllowUserToAddRows = false;
            this.dgvGrupoMesAno.AllowUserToDeleteRows = false;
            this.dgvGrupoMesAno.AllowUserToOrderColumns = true;
            this.dgvGrupoMesAno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupoMesAno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupoMesAno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrupoMesAno.Location = new System.Drawing.Point(776, 421);
            this.dgvGrupoMesAno.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrupoMesAno.Name = "dgvGrupoMesAno";
            this.dgvGrupoMesAno.ReadOnly = true;
            this.dgvGrupoMesAno.RowTemplate.Height = 32;
            this.dgvGrupoMesAno.Size = new System.Drawing.Size(764, 410);
            this.dgvGrupoMesAno.TabIndex = 8;
            // 
            // dgvAnoMesGrupoCategoria
            // 
            this.dgvAnoMesGrupoCategoria.AllowUserToAddRows = false;
            this.dgvAnoMesGrupoCategoria.AllowUserToDeleteRows = false;
            this.dgvAnoMesGrupoCategoria.AllowUserToOrderColumns = true;
            this.dgvAnoMesGrupoCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnoMesGrupoCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnoMesGrupoCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnoMesGrupoCategoria.Location = new System.Drawing.Point(4, 4);
            this.dgvAnoMesGrupoCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnoMesGrupoCategoria.Name = "dgvAnoMesGrupoCategoria";
            this.dgvAnoMesGrupoCategoria.ReadOnly = true;
            this.dgvAnoMesGrupoCategoria.RowHeadersVisible = false;
            this.dgvAnoMesGrupoCategoria.RowTemplate.Height = 32;
            this.dgvAnoMesGrupoCategoria.Size = new System.Drawing.Size(764, 409);
            this.dgvAnoMesGrupoCategoria.TabIndex = 7;
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
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoNegative, 0, 1);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoPositive, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoMesPositive, 1, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartAnoMesNegative, 1, 1);
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
            // chartAnoNegative
            // 
            this.chartAnoNegative.BackColor = System.Drawing.Color.Gainsboro;
            this.chartAnoNegative.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartAnoNegative.BackSecondaryColor = System.Drawing.Color.DarkGray;
            chartArea1.Name = "ChartArea1";
            this.chartAnoNegative.ChartAreas.Add(chartArea1);
            this.chartAnoNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartAnoNegative.Legends.Add(legend1);
            this.chartAnoNegative.Location = new System.Drawing.Point(4, 4);
            this.chartAnoNegative.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoNegative.Name = "chartAnoNegative";
            this.chartAnoNegative.Size = new System.Drawing.Size(478, 1);
            this.chartAnoNegative.TabIndex = 14;
            // 
            // chartAnoPositive
            // 
            this.chartAnoPositive.BackColor = System.Drawing.Color.Gainsboro;
            this.chartAnoPositive.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartAnoPositive.BackSecondaryColor = System.Drawing.Color.DarkGray;
            this.chartAnoPositive.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chartAnoPositive.ChartAreas.Add(chartArea2);
            this.chartAnoPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartAnoPositive.Legends.Add(legend2);
            this.chartAnoPositive.Location = new System.Drawing.Point(4, 4);
            this.chartAnoPositive.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoPositive.Name = "chartAnoPositive";
            this.chartAnoPositive.Size = new System.Drawing.Size(478, 1);
            this.chartAnoPositive.TabIndex = 8;
            // 
            // chartAnoMesPositive
            // 
            this.chartAnoMesPositive.BackColor = System.Drawing.Color.Gainsboro;
            this.chartAnoMesPositive.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartAnoMesPositive.BackSecondaryColor = System.Drawing.Color.DarkGray;
            this.chartAnoMesPositive.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.Name = "ChartArea1";
            this.chartAnoMesPositive.ChartAreas.Add(chartArea3);
            this.chartAnoMesPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartAnoMesPositive.Legends.Add(legend3);
            this.chartAnoMesPositive.Location = new System.Drawing.Point(490, 4);
            this.chartAnoMesPositive.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoMesPositive.Name = "chartAnoMesPositive";
            this.chartAnoMesPositive.Size = new System.Drawing.Size(478, 1);
            this.chartAnoMesPositive.TabIndex = 9;
            // 
            // chartAnoMesNegative
            // 
            this.chartAnoMesNegative.BackColor = System.Drawing.Color.Gainsboro;
            this.chartAnoMesNegative.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartAnoMesNegative.BackSecondaryColor = System.Drawing.Color.DarkGray;
            chartArea4.Name = "ChartArea1";
            this.chartAnoMesNegative.ChartAreas.Add(chartArea4);
            this.chartAnoMesNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartAnoMesNegative.Legends.Add(legend4);
            this.chartAnoMesNegative.Location = new System.Drawing.Point(490, 4);
            this.chartAnoMesNegative.Margin = new System.Windows.Forms.Padding(4);
            this.chartAnoMesNegative.Name = "chartAnoMesNegative";
            this.chartAnoMesNegative.Size = new System.Drawing.Size(478, 1);
            this.chartAnoMesNegative.TabIndex = 13;
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
            this.Text = "Análise";
            this.Load += new System.EventHandler(this.frmAnalysis_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanelExternal.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tableLayoutPanelTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoMesGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoMesAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnoMesGrupoCategoria)).EndInit();
            this.tabPageCharts.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoNegative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnoMesNegative)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExternal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTables;
        private System.Windows.Forms.DataGridView dgvAnoGrupo;
        private System.Windows.Forms.DataGridView dgvAnoMesGrupo;
        private System.Windows.Forms.DataGridView dgvGrupoMesAno;
        private System.Windows.Forms.DataGridView dgvAnoMesGrupoCategoria;
        private System.Windows.Forms.TabPage tabPageCharts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoMesPositive;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoPositive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CustomControls.TreeSelector treeSelGroupsCats;
        private CustomControls.TreeSelector treeSelMonths;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoMesNegative;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnoNegative;
    }
}
