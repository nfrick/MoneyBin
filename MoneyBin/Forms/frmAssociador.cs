using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmAssociador : Form {
        private MoneyBinEntities _ctx;
        private readonly string[] _grupos;
        public frmAssociador() {
            InitializeComponent();
            _ctx = new MoneyBinEntities();
            _grupos = _ctx.Reembolsaveis.Select(r => r.Grupo).Distinct().OrderBy(r => r).ToArray();
            comboBoxGrupo.Items.Add("Todos");
            comboBoxGrupo.Items.AddRange(_grupos);
        }

        private void frmAssociador_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvPagamentos);
            dgvPagamentos.Columns[1].Width = 30;
            GridStyles.FormatColumns(dgvPagamentos, GridStyles.StyleDate, 90, 2);
            GridStyles.FormatColumns(dgvPagamentos, GridStyles.StyleCurrency, 80, 3);
            dgvPagamentos.Columns[4].Width = 60;
            dgvPagamentos.Columns[5].Width = 80;
            dgvPagamentos.Columns[6].Width = 100;
            dgvPagamentos.Columns[7].Width = 200;
            dgvPagamentos.Columns[8].Width = 50;
            dgvPagamentos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CloneGrid(dgvPagamentos, dgvReembolsos);

            // Setting selected index forces loading dgvPagamentos
            dateTimePickerInicio.Value = DateTime.Today.AddDays(-60 - DateTime.Today.Day);
            comboBoxGrupo.SelectedIndex = 0;
        }

        private void LoadPagamentos() {
            var start = dateTimePickerInicio.Value;
            IOrderedQueryable<BalanceItem> sbase;
            if (comboBoxGrupo.Text == @"Todos")
                sbase = _ctx.Balance
                    .Where(b => b.Reembolsavel && b.Data >= start
                        && _grupos.Contains(b.Grupo))
                        .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID);
            else {
                sbase = _ctx.Balance
                    .Where(b => b.Reembolsavel && b.Data >= start
                        && b.Grupo == comboBoxGrupo.Text)
                        .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID);
            }

            if (radioButtonPagtosTodos.Checked)
                bindingSourcePagamentos.DataSource = sbase.ToList();
            else if (radioButtonPagtosPendentes.Checked)
                bindingSourcePagamentos.DataSource = sbase
                    .Where(b => b.IDAssociado == null).ToList();
            else
                bindingSourcePagamentos.DataSource = sbase
                    .Where(b => b.IDAssociado != null).ToList();
        }

        private void dgvBalance_SelectionChanged(object sender, EventArgs e) {
            LoadReembolsos();
        }

        private void LoadReembolsos() {
            if (dgvPagamentos.CurrentRow == null) return;
            if (_ctx.ChangeTracker.HasChanges())
                _ctx.SaveChanges();

            var associados = _ctx.Balance.Where(g => g.IDAssociado != null).Select(g => g.IDAssociado).ToArray();
            var pagamento = (BalanceItem)dgvPagamentos.CurrentRow.DataBoundItem;
            if (pagamento.IDAssociado == null) {
                var sbase = _ctx.Balance.Where(b => b.AfetaSaldo &&
                                !associados.Contains(b.ID) &&
                                b.Data >= dateTimePickerInicio.Value &&
                                (b.Grupo == "Rendas" || b.Grupo == "Pessoal") &&
                                (b.Categoria == "Papai" || b.Categoria == "Supermercado"))
                                .OrderByDescending(b => b.Data);
                bindingSourceReembolsos.DataSource = radioButtonReembValorIgual.Checked ?
                    sbase.Where(b => b.Valor == Math.Abs(pagamento.Valor)).ToList() :
                    sbase.Where(b => b.Valor > 0).ToList();
            }
            else {
                bindingSourceReembolsos.DataSource = _ctx.Balance
                    .Where(b => b.ID == pagamento.IDAssociado).ToList();
            }
        }

        public static void CloneGrid(DataGridView dgvMaster, DataGridView dgvClone) {
            GridStyles.FormatGrid(dgvClone);
            var colCount = Math.Min(dgvMaster.ColumnCount, dgvClone.ColumnCount);
            for (var col = 0; col < colCount; col++) {
                dgvClone.Columns[col].DefaultCellStyle = dgvMaster.Columns[col].DefaultCellStyle;
                dgvClone.Columns[col].Width = dgvMaster.Columns[col].Width;
                dgvClone.Columns[col].AutoSizeMode = dgvMaster.Columns[col].AutoSizeMode;
                dgvClone.Columns[col].Visible = dgvMaster.Columns[col].Visible;
            }
            dgvClone.BackgroundColor = dgvMaster.BackgroundColor;
            dgvClone.RowHeadersWidth = dgvMaster.RowHeadersWidth;
            dgvClone.GridColor = dgvMaster.GridColor;
        }

        private void dgvReembolsos_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var reembolso = (BalanceItem)dgvReembolsos.Rows[e.RowIndex].DataBoundItem;
            var descricao = new List<string>();
            foreach (DataGridViewRow row in dgvPagamentos.SelectedRows) {
                row.Cells[8].Value = reembolso.ID;
                var pagamento = (BalanceItem)row.DataBoundItem;
                descricao.Add(pagamento.Identificacao);
            }
            dgvReembolsos.CurrentRow.Cells[7].Value = string.Join(", ", descricao);
        }

        private void dgvGastos_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var pagamento = (BalanceItem)dgvPagamentos.Rows[e.RowIndex].DataBoundItem;
            pagamento.IDAssociado = null;
            var reembolso = (BalanceItem)dgvReembolsos.CurrentRow.DataBoundItem;
            reembolso.Descricao = null;
            LoadReembolsos();
        }

        private void radioButtonPagtos_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked) {
                LoadPagamentos();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            LoadPagamentos();
            // Usar código abaixo para redefinir as descições dos reembolsos
            //var descricao = new List<string>();
            //var associados = _ctx.Balance.Where(g => g.IDAssociado != null).Select(g => g.IDAssociado).Distinct().ToArray();
            //foreach (var ass in associados) {
            //    var pagamentos = _ctx.Balance.Where(b => b.IDAssociado == ass).ToList();
            //    descricao.Clear();
            //    foreach (var pagto in pagamentos) {
            //        descricao.Add(pagto.Identificacao);
            //    }
            //    var reembolso = _ctx.Balance.FirstOrDefault(b => b.ID == ass);
            //    reembolso.Descricao = string.Join(", ", descricao);
            //}
            //if (_ctx.ChangeTracker.HasChanges())
            //    _ctx.SaveChanges();
        }

        private void Grupo_Inicio_ValueChanged(object sender, EventArgs e) {
            LoadPagamentos();
        }

        private void radioButtonReemb_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked) {
                LoadReembolsos();
            }
        }
    }
}