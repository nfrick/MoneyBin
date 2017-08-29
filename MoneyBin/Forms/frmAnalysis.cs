using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CustomControls;
using DataClasses;
using GridAndChartStyleLibrary;

namespace MoneyBin {
    public partial class frmAnalysis : frmBase {

        private BindingSource _sourceAnoGrupo;
        private BindingSource _sourceAnoMesGrupo;
        private BindingSource _sourceAnoMesCategoria;
        private BindingSource _sourceAnoMesGrupoCategoria;

        private bool _isSingleGroup;
        private bool _isSingleCategory;
        private bool _isSingleYear;
        private bool _isSingleMonth;

        private bool _MustInitializeDGV = true;

        public frmAnalysis() {
            InitializeComponent();
            statusStrip1.Visible = false;
        }

        private void frmAnalysis_Load(object sender, EventArgs e) {

            //foreach (Control ctrl in tableLayoutPanelTables.Controls)
            //    if (ctrl.GetType().Name.Equals("DataGridView"))
            //        SetupDGV((DataGridView)ctrl);

            SetupChart(chartAnoPositive, "Ano x Grupo", "Positivo");
            SetupChart(chartAnoMesPositive, "Ano-Mês x Grupo", "Positivo");
            SetupChart(chartAnoNegative, "Ano x Grupo", "Negativo");
            SetupChart(chartAnoMesNegative, "Ano-Mês x Grupo", "Negativo");

            var meses = MoneyBinDB.GetAnosMeses("BB");
            treeSelMonths.LoadData(meses);
            treeSelMonths.ItemName = "Ano";
            treeSelMonths.SubItemName = "Mes";

            var grpCats = MoneyBinDB.GetGruposCategorias();
            treeSelGroupsCats.LoadData(grpCats);
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
                        col.DisplayIndex = 0;
                        break;
                    case "Mes":
                        GridStyles.FormatColumn(col, GridStyles.StyleInteger, 50);
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
                        break;
                    case "Negativo":
                        GridStyles.FormatColumn(col, GridStyles.StyleCurrency, remainderWidth / 2);
                        break;
                    case "Total":
                        GridStyles.FormatColumn(col, GridStyles.StyleCurrency, remainderWidth);
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

            var baseData = MoneyBinDB.GetAnalysisItems(treeSelMonths.GetQuery(), treeSelGroupsCats.GetQuery());

            var anoMesGrupoCategoria =
                (from p in baseData
                 group p by p.Ano + p.Mes + p.Grupo + p.Categoria into g
                 select new {
                     Ano = g.Key.Substring(0, 4),
                     Mes = g.Key.Substring(4, 2),
                     Grupo = g.Key.Substring(6, 1),
                     Categoria = g.Key.Substring(7),
                     Positivo = g.Sum(p => p.IsPositive ? p.Valor : 0),
                     Negativo = g.Sum(p => p.IsNegative ? p.Valor : 0),
                     Total = g.Sum(p => p.Valor)
                 }).OrderBy(c => c.Ano).ThenBy(c => c.Mes).ThenBy(c => c.Grupo).ThenBy(c => c.Categoria);

            var anoGrupo =
                (from p in anoMesGrupoCategoria
                 group p by p.Ano + p.Grupo into g
                 select new {
                     Ano = g.Key.Substring(0, 4),
                     Grupo = g.Key.Substring(4),
                     Positivo = g.Sum(p => p.Positivo),
                     Negativo = g.Sum(p => p.Negativo),
                     Total = g.Sum(p => p.Total)
                 }).OrderBy(c => c.Ano).ThenBy(c => c.Grupo);

            var anoMesGrupo =
                (from p in anoMesGrupoCategoria
                 group p by p.Ano + p.Mes + p.Grupo into g
                 select new {
                     Ano = g.Key.Substring(0, 4),
                     Mes = g.Key.Substring(4, 2),
                     Grupo = g.Key.Substring(6),
                     Positivo = g.Sum(p => p.Positivo),
                     Negativo = g.Sum(p => p.Negativo),
                     Total = g.Sum(p => p.Total)
                 }).OrderBy(c => c.Ano).ThenBy(c => c.Mes).ThenBy(c => c.Grupo);

            var anoMesCategoria =
                (from p in anoMesGrupoCategoria
                 group p by p.Ano + p.Mes + p.Categoria into g
                 select new {
                     Ano = g.Key.Substring(0, 4),
                     Mes = g.Key.Substring(4, 2),
                     Categoria = g.Key.Substring(6),
                     Positivo = g.Sum(p => p.Positivo),
                     Negativo = g.Sum(p => p.Negativo),
                     Total = g.Sum(p => p.Total)
                 }).OrderBy(c => c.Ano).ThenBy(c => c.Mes).ThenBy(c => c.Categoria);

            // ANO-MES-GRUPO-CATEGORIA (1-1)
            if (_isSingleCategory || _isSingleMonth)  // Redundante com Ano-Grupo-Categoria ou Ano-Mes-Grupo
                AnoMesGrupoCategoriaDataGridView.Visible = false;
            else {
                AnoMesGrupoCategoriaDataGridView.Visible = true;
                _sourceAnoMesGrupoCategoria = new BindingSource { DataSource = anoMesGrupoCategoria };
                AnoMesGrupoCategoriaDataGridView.DataSource = _sourceAnoMesGrupoCategoria;
            }

            // ANO-GRUPO
            if (_isSingleMonth) // Redundante com Ano-Mes-Grupo
                AnoGrupoDataGridView.Visible = false;
            else {
                AnoGrupoDataGridView.Visible = true;
                _sourceAnoGrupo = new BindingSource { DataSource = anoGrupo };
                AnoGrupoDataGridView.DataSource = _sourceAnoGrupo;
            }

            // ANO-MES-GRUPO
            _sourceAnoMesGrupo = new BindingSource { DataSource = anoMesGrupo };
            AnoMesGrupoDataGridView.DataSource = _sourceAnoMesGrupo;

            // ANO-MES-CATEGORIA
            if (_isSingleCategory) // Redundante com Ano-Mes-Grupo
                AnoMesCategoriaDataGridView.Visible = false;
            else {
                AnoMesCategoriaDataGridView.Visible = true;
                _sourceAnoMesCategoria = new BindingSource { DataSource = anoMesCategoria };
                AnoMesCategoriaDataGridView.DataSource = _sourceAnoMesCategoria;
            }

            tableLayoutPanelExternal.ColumnStyles[1].Width = _isSingleCategory ? 0 : 400;

            if (_MustInitializeDGV) {
                _MustInitializeDGV = false;
                foreach (Control ctrl in tableLayoutPanelTables.Controls)
                    if (ctrl.GetType().Name.Equals("DataGridView"))
                        SetupDGV((DataGridView)ctrl);
            }

            // SET CHARTS
            chartAnoPositive.Series.Clear();
            chartAnoMesPositive.Series.Clear();
            chartAnoNegative.Series.Clear();
            chartAnoMesNegative.Series.Clear();

            if (_isSingleGroup) {
                if (_isSingleYear || _isSingleMonth) {
                    // Pie chart at category level
                    var categories =
                        (from p in anoMesGrupoCategoria
                         group p by p.Categoria into g
                         select new {
                             Categoria = g.Key,
                             TotalPos = g.Sum(p => p.Positivo),
                             TotalNeg = g.Sum(p => p.Negativo)
                         }).OrderBy(c => c.Categoria);

                    var seriesP = chartAnoPositive.Series.Add(anoGrupo.ElementAt(0).Ano);
                    seriesP.ChartType = SeriesChartType.Pie;
                    var seriesN = chartAnoNegative.Series.Add(anoGrupo.ElementAt(0).Ano);
                    seriesN.ChartType = SeriesChartType.Pie;
                    foreach (var cat in categories) {
                        seriesP.Points.AddXY(cat.Categoria, cat.TotalPos == 0 ? 0 : cat.TotalPos);
                        seriesN.Points.AddXY(cat.Categoria, cat.TotalNeg == 0 ? 0 : -1 * cat.TotalNeg);
                    }
                }
                else {
                    // Stacked bar at Category level
                    var anoCategoria =
                        (from p in anoMesCategoria
                         group p by p.Ano + p.Categoria into g
                         select new {
                             Ano = g.Key.Substring(0, 4),
                             Categoria = g.Key.Substring(4),
                             TotalPos = g.Sum(p => p.Positivo),
                             TotalNeg = g.Sum(p => p.Negativo)
                         }).OrderBy(c => c.Categoria).ThenBy(c => c.Ano);

                    foreach (var cat in anoCategoria) {
                        var seriesP = chartAnoPositive.Series.FindByName(cat.Categoria);
                        if (seriesP == null) {
                            seriesP = chartAnoPositive.Series.Add(cat.Categoria);
                            seriesP.ChartType = SeriesChartType.StackedColumn;
                        }

                        var seriesN = chartAnoNegative.Series.FindByName(cat.Categoria);
                        if (seriesN == null) {
                            seriesN = chartAnoNegative.Series.Add(cat.Categoria);
                            seriesN.ChartType = SeriesChartType.StackedColumn;
                        }

                        seriesP.Points.AddXY(cat.Ano, cat.TotalPos == 0 ? 0 : cat.TotalPos);
                        seriesN.Points.AddXY(cat.Ano, cat.TotalNeg == 0 ? 0 : -1 * cat.TotalNeg);
                    }
                }
            }

            else if (_isSingleYear) {
                // Pie chart at group level
                var seriesP = chartAnoPositive.Series.Add(anoGrupo.ElementAt(0).Ano);
                seriesP.ChartType = SeriesChartType.Pie;
                var seriesN = chartAnoNegative.Series.Add(anoGrupo.ElementAt(0).Ano);
                seriesN.ChartType = SeriesChartType.Pie;

                foreach (var g in anoGrupo) {
                    seriesP.Points.AddXY(g.Grupo, g.Positivo == 0 ? 0 : g.Positivo);
                    seriesN.Points.AddXY(g.Grupo, g.Negativo == 0 ? 0 : -1 * g.Negativo);
                }
            }

            else {
                var grupos = anoGrupo.Select(a => a.Grupo).Distinct().OrderBy(g => g);

                foreach (var grupo in grupos) {
                    var seriesP = chartAnoPositive.Series.Add(grupo);
                    seriesP.ChartType = SeriesChartType.StackedColumn;
                    var seriesN = chartAnoNegative.Series.Add(grupo);
                    seriesN.ChartType = SeriesChartType.StackedColumn;

                    var itemsAno = anoGrupo.Where(i => i.Grupo == grupo).OrderBy(i => i.Ano);

                    foreach (var ai in itemsAno) {
                        seriesP.Points.AddXY(ai.Ano, ai.Positivo == 0 ? 0 : ai.Positivo);
                        seriesN.Points.AddXY(ai.Ano, ai.Negativo == 0 ? 0 : -1 * ai.Negativo);
                    }
                }
            }

            // ANO-MES-GRUPO
            if (_isSingleGroup) {
                if (_isSingleYear && _isSingleMonth) {
                    // Pie chart at category level
                    var categories =
                        (from p in anoMesGrupoCategoria
                         group p by p.Categoria into g
                         select new {
                             Categoria = g.Key,
                             TotalPos = g.Sum(p => p.Positivo),
                             TotalNeg = g.Sum(p => p.Negativo)
                         }).OrderBy(c => c.Categoria);

                    var seriesP = chartAnoMesPositive.Series.Add(anoGrupo.ElementAt(0).Ano);
                    seriesP.ChartType = SeriesChartType.Pie;
                    var seriesN = chartAnoMesNegative.Series.Add(anoGrupo.ElementAt(0).Ano);
                    seriesN.ChartType = SeriesChartType.Pie;
                    foreach (var cat in categories) {
                        seriesP.Points.AddXY(cat.Categoria, cat.TotalPos == 0 ? 0 : cat.TotalPos);
                        seriesN.Points.AddXY(cat.Categoria, cat.TotalNeg == 0 ? 0 : -1 * cat.TotalNeg);
                    }
                }
                else {
                    // Stacked bar at Category level
                    var categorias = (
                        from g in anoMesCategoria
                        orderby g.Categoria
                        select g.Categoria)
                        .Distinct();

                    var anosMeses = (
                        from g in anoMesCategoria
                        orderby g.Ano, g.Mes
                        select new {
                            g.Ano,
                            g.Mes,
                            AnoMes = $@"{g.Ano}\n{g.Mes}"
                        })
                        .Distinct();

                    foreach (var cat in categorias) {
                        var seriesP = chartAnoMesPositive.Series.Add(cat);
                        seriesP.ChartType = SeriesChartType.StackedColumn;
                        var seriesN = chartAnoMesNegative.Series.Add(cat);
                        seriesN.ChartType = SeriesChartType.StackedColumn;

                        foreach (var am in anosMeses) {
                            var anoMesData = (
                                from p in anoMesCategoria
                                where p.Ano == am.Ano && p.Mes == am.Mes && p.Categoria == cat
                                select new {
                                    AnoMes = $@"{p.Ano}\n{p.Mes}",
                                    TotalPos = p.Positivo,
                                    TotalNeg = p.Negativo
                                }).OrderBy(c => c.AnoMes);

                            if (!anoMesData.Any()) {
                                seriesP.Points.AddXY(am.AnoMes, 0);
                                seriesN.Points.AddXY(am.AnoMes, 0);
                            }
                            else {
                                foreach (var item in anoMesData) {
                                    seriesP.Points.AddXY(item.AnoMes, item.TotalPos == 0 ? 0 : item.TotalPos);
                                    seriesN.Points.AddXY(item.AnoMes, item.TotalNeg == 0 ? 0 : -1 * item.TotalNeg);
                                }
                            }
                        }
                    }
                }
            }

            else if (_isSingleMonth) {
                // Pie chart at group level
                var firstItem = anoMesGrupo.ElementAt(0);
                var aNomes = $@"{firstItem.Ano}\n{firstItem.Mes}";
                var seriesP = chartAnoMesPositive.Series.Add(aNomes);
                seriesP.ChartType = SeriesChartType.Pie;
                var seriesN = chartAnoMesNegative.Series.Add(aNomes);
                seriesN.ChartType = SeriesChartType.Pie;

                foreach (var g in anoMesGrupo) {
                    seriesP.Points.AddXY(g.Grupo, g.Positivo == 0 ? 0 : g.Positivo);
                    seriesN.Points.AddXY(g.Grupo, g.Negativo == 0 ? 0 : -1 * g.Negativo);
                }
            }
            else {
                var grupos = anoGrupo.Select(g => g.Grupo).Distinct().OrderBy(g => g);
                foreach (var grupo in grupos) {
                    var seriesP = chartAnoMesPositive.Series.Add(grupo);
                    seriesP.ChartType = SeriesChartType.StackedColumn;
                    var seriesN = chartAnoMesNegative.Series.Add(grupo);
                    seriesN.ChartType = SeriesChartType.StackedColumn;

                    var itemsAnoMes = anoMesGrupo.Where(i => i.Grupo == grupo)
                        .OrderBy(i => i.Ano).ThenBy(i => i.Mes);

                    foreach (var item in itemsAnoMes) {
                        var anomes = $@"{item.Ano}\n{item.Mes}";
                        seriesP.Points.AddXY(anomes, item.Positivo == 0 ? 0 : item.Positivo);
                        seriesN.Points.AddXY(anomes, item.Negativo == 0 ? 0 : -1 * item.Negativo);
                    }
                }
            }
        }
    }
}