using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MoneyBin.Forms {
    public partial class frmBalance : Form {
        private MoneyBinEntities _ctx;
        private AutoCompleteStringCollection _grupoPicklist;

        #region FORM
        public frmBalance() {
            InitializeComponent();
        }

        private void frmBalance_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvBalance);
            GridStyles.FormatColumn(dgvBalance.Columns[2], GridStyles.StyleDate, 90);
            GridStyles.FormatColumns(dgvBalance, new[] { 6, 7 }, GridStyles.StyleCurrency, 80);
            dgvBalance.Columns[3].Width = 400;
            dgvBalance.Columns[11].Width = 100;
            dgvBalance.Columns[12].Width = 110;
            dgvBalance.Columns[13].Width = 180;

            this.Width = 150 + dgvBalance.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            _ctx = new MoneyBinEntities();
            toolStripComboBoxBanco.ComboBox.Items.AddRange(_ctx.BalanceComSaldo.Select(b => b.Banco).Distinct()
                .OrderBy(b => b).ToArray());
            toolStripComboBoxBanco.ComboBox.SelectedIndex = 0;
            dgvBalance.DataSource = BalanceBindingSource;

            toolStripComboBoxBanco.ComboBox.SelectedIndex = 0;
        }

        private void frmBalance_FormClosing(object sender, FormClosingEventArgs e) {
            dgvBalance.EndEdit();
            if (!_ctx.ChangeTracker.HasChanges()) return;
            switch (PerguntaSeSalva()) {
                case DialogResult.Yes:
                    _ctx.SaveChanges();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private DialogResult PerguntaSeSalva() {
            return MessageBox.Show(Alteracoes() + @"?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private string Alteracoes() {
            var alts = _ctx.ChangeTracker.Entries().Count(entry => entry.State == EntityState.Added ||
                                                                   entry.State == EntityState.Deleted ||
                                                                   entry.State == EntityState.Modified);
            return $" Salvar {alts} alteraç" + (alts == 1 ? "ão" : "ões");
        }
        #endregion FORM

        #region TOOLBAR
        private void toolStripComboBoxBanco_SelectedIndexChanged(object sender, EventArgs e) {
            BalanceBindingSource.DataSource = _ctx.BalanceComSaldo
                .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem)
                .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();

            toolStripComboBoxGrupo.ComboBox.Items.Clear();
            toolStripComboBoxGrupo.ComboBox.Items.Add("Todos");
            toolStripComboBoxGrupo.ComboBox.Items
                .AddRange(_ctx.BalanceComSaldo.Select(b => b.NovoGrupo).Distinct().OrderBy(b => b).ToArray());
            toolStripComboBoxGrupo.ComboBox.SelectedIndex = 0;
        }

        private void toolStripComboBoxGrupo_SelectedIndexChanged(object sender, EventArgs e) {
            if (toolStripComboBoxGrupo.SelectedIndex == 0)
                BalanceBindingSource.DataSource = _ctx.BalanceComSaldo.Local
                    .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
            else
                BalanceBindingSource.DataSource = _ctx.BalanceComSaldo.Local
                    .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem
                                && b.NovoGrupo == (string)toolStripComboBoxGrupo.SelectedItem)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvBalance.EndEdit();
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void toolStripButtonProcurar_Click(object sender, EventArgs e) {
            var columns = dgvBalance.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c => c.Index)
                .ToArray();
            var row = dgvBalance.CurrentRow.Index;
            var target = toolStripTextBoxProcurar.Text.ToLower();
            var found = false;
            do {
                var Row = dgvBalance.Rows[++row];
                foreach (var col in columns) {
                    found = Row.Cells[col].FormattedValue.ToString().ToLower().Contains(target);
                    if (!found) continue;
                    dgvBalance.CurrentCell = dgvBalance.Rows[row].Cells[3];
                    break;
                }
                if (found) return;
            } while (row < dgvBalance.RowCount - 1);
            MessageBox.Show($"'{target}' não encontrado", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonDesfazer_Click(object sender, EventArgs e) {
            foreach (var entry in _ctx.ChangeTracker.Entries()) {
                switch (entry.State) {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
            toolStripButtonSalvar.Visible = false;
            dgvBalance.Refresh();
        }

        private void toolStripButtonSalvar_VisibleChanged(object sender, EventArgs e) {
            toolStripButtonDesfazer.Visible =
                toolStripSeparatorSalvar.Visible = toolStripButtonSalvar.Visible;
        }
        #endregion TOOLBAR

        #region DATAGRIDVIEW
        private void dgvBalance_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            var tracker = _ctx.ChangeTracker;
            toolStripButtonSalvar.Text = Alteracoes();
            toolStripButtonSalvar.Visible = tracker.HasChanges();
        }

        private void dgvBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if ((e.ColumnIndex != 6 && e.ColumnIndex != 7) || (decimal)e.Value > 0) return;
            e.CellStyle.ForeColor = Color.DarkOrange;
        }

        private void CalculaSaldos(int start) {
            var _BalanceItems = (List<BalanceItemComSaldo>)BalanceBindingSource.DataSource;
            var saldo = start == _BalanceItems.Count - 1 ? 0.0m : _BalanceItems.ElementAt(start + 1).Saldo;
            for (var i = start; i >= 0; i--) {
                var bi = _BalanceItems.ElementAt(i);
                saldo += bi.ValorParaSaldo;
                bi.Saldo = saldo;
            }
            dgvBalance.Refresh();
        }

        private void dgvBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvBalance.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") return;
            CalculaSaldos(e.RowIndex);
        }
        private void dgvBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            var dgv = (DataGridView)sender;
            var row = dgv.CurrentCell.RowIndex;
            var col = dgv.CurrentCell.ColumnIndex;
            var bi = (BalanceItemComSaldo)dgv.Rows[row].DataBoundItem;
            var txt = e.Control as TextBox;
            using (var ctx = new MoneyBinEntities()) {
                switch (dgv.Columns[col].HeaderText) {
                    case "Novo Grupo":
                        if (_grupoPicklist == null)
                            _grupoPicklist = CreateCollection(ctx.BalanceComSaldo.Select(b => b.NovoGrupo).Distinct().ToArray());
                        txt.AutoCompleteCustomSource = _grupoPicklist;
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Nova Categoria":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.BalanceComSaldo.Where(b => b.NovoGrupo == bi.NovoGrupo).Select(b => b.NovaCategoria));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Nova SubCategoria":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.BalanceComSaldo.Where(b => b.NovaCategoria == bi.NovaCategoria).Select(b => b.NovaSubCategoria));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Descrição":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.BalanceComSaldo.Where(b => b.NovaSubCategoria == bi.NovaSubCategoria).Select(b => b.Descricao));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    default:
                        txt.AutoCompleteMode = AutoCompleteMode.None;
                        break;
                }
            }
        }

        private AutoCompleteStringCollection CreateCollection(IEnumerable<string> lista) {
            var source = new AutoCompleteStringCollection();
            source.AddRange(lista.Distinct().Where(a => !string.IsNullOrEmpty(a)).ToArray());
            return source;
        }

        #endregion DATAGRIDVIEW
    }
}
