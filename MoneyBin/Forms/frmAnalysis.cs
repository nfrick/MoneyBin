using CustomControls;
using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyBin {
    internal enum ChartPeriod {
        Ano,
        AnoMes
    }

    public partial class frmAnalysis : frmBase {
        private MoneyBinEntities _ctx;

        private BindingSource _sourceAnoGrupo;
        private BindingSource _sourceAnoMesGrupo;
        private BindingSource _sourceGrupoMesAno;
        private BindingSource _sourceAnoMesGrupoCategoria;

        private bool _isSingleGroup;
        private bool _isSingleCategory;
        private bool _isSingleYear;
        private bool _isSingleMonth;

        private bool _MustInitializeDGV = true;

        public frmAnalysis() {
            InitializeComponent();
            statusStrip1.Visible = false;
            _ctx = new MoneyBinEntities();
        }

        private void frmAnalysis_Load(object sender, EventArgs e) {
            SetupChart(chartAnoPositive, "Ano x Grupo", "Positivo");
            SetupChart(chartAnoMesPositive, "Ano-Mês x Grupo", "Positivo");
            SetupChart(chartAnoNegative, "Ano x Grupo", "Negativo");
            SetupChart(chartAnoMesNegative, "Ano-Mês x Grupo", "Negativo");

            var meses = _ctx.Balance
                .Select(b => new { Ano = b.Data.Year, Mes = b.Data.Month }).Distinct()
                .OrderByDescending(t => t.Ano).ThenByDescending(t => t.Mes).ToList();
            treeSelMonths.LoadData(meses.Select(t => new Tuple<string, string>($"{t.Ano}", $"{t.Mes:D2}")).ToList());
            treeSelMonths.ItemName = "Ano";
            treeSelMonths.SubItemName = "Mes";

            var grpCats = _ctx.Balance
                .Select(b => new { b.NovoGrupo, b.NovaCategoria }).Distinct()
                .OrderBy(t => t.NovoGrupo).ThenBy(t => t.NovaCategoria).ToList();
            treeSelGroupsCats.LoadData(grpCats
                .Select(b => new Tuple<string, string>(b.NovoGrupo, b.NovaCategoria)).ToList());
            treeSelGroupsCats.ItemName = "Grupo";
            treeSelGroupsCats.SubItemName = "Categoria";

            this.Width = this.Parent.Width - 10;
            this.Height = this.Parent.Height - 10;

            toolStripButtonLoad.Visible = false;
            toolStripButtonCategorize.Visible = false;
            toolStripButtonSave.Visible = false;
        }

        private void SetupChart(Chart chrt, string title, string subTitle) {
            var font = new Font("Segoe UI", 8);
            var fontTitle = new Font("Segoe UI", 12);
            chrt.Palette = ChartColorPalette.Bright;
            var t = chrt.Titles.Add(title);
            t.Font = fontTitle;
            chrt.Titles.Add(subTitle);
            chrt.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chrt.ChartAreas[0].AxisX.LabelStyle.Font = font;
            chrt.ChartAreas[0].AxisY.LabelStyle.Font = font;
        }

        private void SetupDGV(DataGridView dgv) {
            GridStyles.FormatGrid(dgv);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;

            var remainderWidth = dgv.Width;
            foreach (DataGridViewColumn col in dgv.Columns) {
                col.HeaderCell.Value = col.HeaderText.Trim();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                switch (col.HeaderText) {
                    case "Ano":
                        GridStyles.FormatColumn(col, GridStyles.StyleInteger, 50);
                        break;
                    case "Mes":
                        GridStyles.FormatColumn(col, GridStyles.StyleInteger, 50);
                        col.DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                        break;
                    case "Grupo":
                        GridStyles.FormatColumn(col, GridStyles.StyleBase, 70);
                        col.Visible = true;
                        break;
                    case "Categoria":
                        GridStyles.FormatColumn(col, GridStyles.StyleBase, 100);
                        col.Visible = true;
                        break;
                    case "Positivo":
                        GridStyles.FormatColumn(col, GridStyles.StyleCurrency, remainderWidth / 3);
                        col.DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                        break;
                    case "Negativo":
                        GridStyles.FormatColumn(col, GridStyles.StyleCurrency, remainderWidth / 2);
                        col.DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                        break;
                    case "Total":
                        GridStyles.FormatColumn(col, GridStyles.StyleCurrency, remainderWidth);
                        col.DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    default:
                        break;
                }
                remainderWidth -= col.Width;
            }
        }

        public override void toolStripButtonAnalyze_Click(object sender, EventArgs e) {
            _isSingleYear = treeSelMonths.IsSingleLevel(1);
            _isSingleMonth = treeSelMonths.IsSingleLevel(2);
            _isSingleGroup = treeSelGroupsCats.IsSingleLevel(1);
            _isSingleCategory = treeSelGroupsCats.IsSingleLevel(2);

            var baseData = _ctx.Database
                .SqlQuery<AnaliseItem>(
                    $"SELECT * FROM vw_Analise {WhereClause()}")
                .OrderByDescending(c => c.Ano).ThenByDescending(c => c.Mes)
                .ThenBy(c => c.Grupo).ThenBy(c => c.Categoria)
                .ToList();

            var anoMesGrupoCategoria =
            (from p in baseData
             group p by new { p.Ano, p.Mes, p.Grupo, p.Categoria } into g
             select new {
                 Ano = g.Key.Ano,
                 Mes = g.Key.Mes,
                 Grupo = g.Key.Grupo,
                 Categoria = g.Key.Categoria,
                 Positivo = g.Sum(p => p.IsPositive ? p.Valor : 0),
                 Negativo = -1 * g.Sum(p => p.IsNegative ? p.Valor : 0),
                 Total = g.Sum(p => p.Valor)
             });

            var anoGrupo =
                (from p in anoMesGrupoCategoria
                 group p by new { p.Ano, p.Grupo } into g
                 select new {
                     Ano = g.Key.Ano,
                     Grupo = g.Key.Grupo,
                     Positivo = g.Sum(p => p.Positivo),
                     Negativo = g.Sum(p => p.Negativo),
                     Total = g.Sum(p => p.Total)
                 });

            var anoMesGrupo =
            (from p in anoMesGrupoCategoria
             group p by new { p.Ano, p.Mes, p.Grupo }
                into g
             select new {
                 Ano = g.Key.Ano,
                 Mes = g.Key.Mes,
                 AnoMes = $@"{g.Key.Ano}\n{g.Key.Mes}",
                 Grupo = g.Key.Grupo,
                 Positivo = g.Sum(p => p.Positivo),
                 Negativo = g.Sum(p => p.Negativo),
                 Total = g.Sum(p => p.Total)
             });

            var grupoMesAno = anoMesGrupo
                .Select(p => new { p.Grupo, p.Mes, p.Ano, p.AnoMes, p.Positivo, p.Negativo, p.Total })
                    .OrderBy(c => c.Grupo).ThenByDescending(c => c.Mes).ThenByDescending(c => c.Ano);

            // ANO-MES-GRUPO-CATEGORIA (1-1)
            if (_isSingleCategory || _isSingleMonth)  // Redundante com Ano-Grupo-Categoria ou Ano-Mes-Grupo
                dgvAnoMesGrupoCategoria.Visible = false;
            else {
                dgvAnoMesGrupoCategoria.Visible = true;
                _sourceAnoMesGrupoCategoria = new BindingSource {
                    DataSource = anoMesGrupoCategoria
                };
                dgvAnoMesGrupoCategoria.DataSource = _sourceAnoMesGrupoCategoria;
            }

            // ANO-GRUPO
            dgvAnoGrupo.Visible = !_isSingleMonth;
            if (!_isSingleMonth) { // Redundante com Ano-Mes-Grupo
                dgvAnoGrupo.Visible = true;
                _sourceAnoGrupo = new BindingSource { DataSource = anoGrupo };
                dgvAnoGrupo.DataSource = _sourceAnoGrupo;
            }

            // ANO-MES-GRUPO
            _sourceAnoMesGrupo = new BindingSource { DataSource = anoMesGrupo };
            dgvAnoMesGrupo.DataSource = _sourceAnoMesGrupo;

            // GRUPO-MES-ANO
            dgvGrupoMesAno.Visible = !_isSingleCategory;
            if (!_isSingleCategory) {  // Redundante com Ano-Mes-Grupo
                dgvGrupoMesAno.Visible = true;
                _sourceGrupoMesAno = new BindingSource { DataSource = grupoMesAno };
                dgvGrupoMesAno.DataSource = _sourceGrupoMesAno;
            }

            tableLayoutPanelExternal.ColumnStyles[1].Width = _isSingleCategory ? 0 : 400;

            if (_MustInitializeDGV) {
                _MustInitializeDGV = false;
                foreach (Control ctrl in tableLayoutPanelTables.Controls)
                    if (ctrl.GetType().Name.Equals("DataGridView"))
                        SetupDGV((DataGridView)ctrl);
            }

            // SET CHARTS
            foreach (Control ctrl in tableLayoutPanelCharts.Controls)
                if (ctrl.GetType().Name.Equals("Chart")) {
                    ctrl.Visible = true;
                    ((Chart)ctrl).Series.Clear();
                    ((Chart)ctrl).Legends.Clear();
                    var legenda = new Legend { LegendItemOrder = LegendItemOrder.SameAsSeriesOrder };
                    ((Chart)ctrl).Legends.Add(legenda);
                    ((Chart) ctrl).ChartAreas[0].AxisY.MajorGrid.LineColor =
                        ((Chart)ctrl).ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DarkGray;
                    ((Chart) ctrl).ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                }

            #region ANO-GRUPO
            if (_isSingleGroup) {
                if (_isSingleYear || _isSingleMonth) {
                    // Pie chart at category level
                    var items =
                        (from p in anoMesGrupoCategoria
                         group p by p.Categoria into g
                         select new PieItem() {
                             Legenda = g.Key,
                             Positivo = g.Sum(p => p.Positivo),
                             Negativo = g.Sum(p => p.Negativo)
                         });
                    DrawPieChart(items, ChartPeriod.Ano);
                }

                // Single Group, more than one years or months
                else {
                    // Stacked bar at Category level
                    var items =
                        from p in anoMesGrupoCategoria
                        group p by new { p.Ano, p.Categoria }
                            into g
                        select new StackedItem {
                            Legenda = g.Key.Categoria,
                            EixoX = g.Key.Ano,
                            Positivo = g.Sum(p => p.Positivo),
                            Negativo = g.Sum(p => p.Negativo)
                        };
                    DrawStackedChart(items, ChartPeriod.Ano);
                }
            }

            // More than one Group, Single Year
            else if (_isSingleYear) {
                // Pie chart at group level
                var items = anoGrupo.Select(
                    a => new PieItem { Legenda = a.Grupo, Positivo = a.Positivo, Negativo = a.Negativo });
                DrawPieChart(items, ChartPeriod.Ano);
            }

            // More than one Group, More than one Year
            else {
                var items = anoGrupo.Select(
                    a => new StackedItem { Legenda = a.Grupo, EixoX = a.Ano, Positivo = a.Positivo, Negativo = a.Negativo });
                DrawStackedChart(items, ChartPeriod.Ano);
            }
            #endregion ANO-GRUPO

            #region ANO-MES-GRUPO
            if (_isSingleGroup) {
                if (_isSingleYear && _isSingleMonth) {
                    // Pie chart at category level
                    var items =
                        from p in anoMesGrupoCategoria
                        group p by p.Categoria into g
                        select new PieItem {
                            Legenda = g.Key,
                            Positivo = g.Sum(p => p.Positivo),
                            Negativo = g.Sum(p => p.Negativo)
                        };
                    DrawPieChart(items, ChartPeriod.AnoMes);
                }

                // Single Group, more than one year or month
                else {
                    var items =
                    from p in anoMesGrupoCategoria
                    group p by new { p.Categoria, p.Ano, p.Mes }
                        into g
                    select new StackedItem {
                        Legenda = g.Key.Categoria,
                        EixoX = $@"{g.Key.Ano}\n{g.Key.Mes}",
                        Positivo = g.Sum(p => p.Positivo),
                        Negativo = g.Sum(p => p.Negativo)
                    };
                    DrawStackedChart(items, ChartPeriod.AnoMes);
                }
            }

            // More than one Group, single Month - redundant: same as ANO-GRUPO
            else if (_isSingleMonth) {
                // do nothing
            }

            // More than one Group, more than one Month
            else {
                var items = grupoMesAno.Select(
                    i => new StackedItem() { Legenda = i.Grupo, EixoX = i.AnoMes, Positivo = i.Positivo, Negativo = i.Negativo });
                DrawStackedChart(items, ChartPeriod.AnoMes);
            }
            #endregion ANO-MES-GRUPO

            foreach (Control ctrl in tableLayoutPanelCharts.Controls)
                if (ctrl.GetType().Name.Equals("Chart")) {
                    var chart = (Chart)ctrl;
                    chart.Visible = chart.Series.Any(s => s.Points.Any(p => p.YValues.Any(y => y > 0.0)));
                }
        }

        private Series GetSeries(Chart chart, string serieName, SeriesChartType type) {
            var serie = chart.Series.FindByName(serieName);
            if (serie != null) return serie;
            serie = chart.Series.Add(serieName);
            serie.ChartType = type;
            return serie;
        }

        private string WhereClause() {
            var condicoes = new List<string> { treeSelMonths.Query, treeSelGroupsCats.Query };
            return condicoes.All(string.IsNullOrEmpty) ?
                "" : "WHERE " + string.Join(" AND ", condicoes.Where(c => !string.IsNullOrEmpty(c)));
        }

        private void DrawPieChart(IEnumerable<PieItem> items, ChartPeriod period) {
            GetCharts(period, out Chart chartPos, out Chart chartNeg);
            foreach (var item in items.OrderByDescending(c => c.Legenda)) {
                if (item.Positivo != 0)
                    PieChartAdd(chartPos, item.Legenda, item.Positivo);

                if (item.Negativo == 0) continue;
                PieChartAdd(chartNeg, item.Legenda, item.Negativo);
            }
        }

        private void PieChartAdd(Chart chart, string legenda, decimal valor) {
            var series = GetSeries(chart, "pie", SeriesChartType.Pie);
            var dp = series.Points.Add((double)valor);
            dp.LegendText = legenda;
            dp.AxisLabel = $"{valor:N0}";
            chart.ApplyPaletteColors();
            dp.LabelForeColor = ColorFunctions.ContrastColor(dp.Color);
        }

        private void DrawStackedChart(IEnumerable<StackedItem> items, ChartPeriod period) {
            GetCharts(period, out Chart chartPos, out Chart chartNeg);
            foreach (var item in items.OrderByDescending(i => i.Legenda).ThenBy(i => i.EixoX)) {
                var seriesP = GetSeries(chartPos, item.Legenda, SeriesChartType.StackedColumn);
                seriesP.Points.AddXY(item.EixoX, item.Positivo);
                var seriesN = GetSeries(chartNeg, item.Legenda, SeriesChartType.StackedColumn);
                seriesN.Points.AddXY(item.EixoX, item.Negativo);
            }
        }

        private void GetCharts(ChartPeriod period, out Chart chartPos, out Chart chartNeg) {
            chartPos = period == ChartPeriod.Ano ? chartAnoPositive : chartAnoMesPositive;
            chartNeg = period == ChartPeriod.Ano ? chartAnoNegative : chartAnoMesNegative;
        }

    }

    internal class PieItem {
        public string Legenda { get; set; }
        public decimal Positivo { get; set; }
        public decimal Negativo { get; set; }
    }

    internal class StackedItem {
        public string Legenda { get; set; }
        public string EixoX { get; set; }
        public decimal Positivo { get; set; }
        public decimal Negativo { get; set; }
    }
}