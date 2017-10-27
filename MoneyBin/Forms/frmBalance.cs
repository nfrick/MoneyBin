using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MoneyBin.Forms {
    public partial class frmBalance : Form {
        private MoneyBinEntities _ctx;

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

        private void dgvBalance_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            var tracker = _ctx.ChangeTracker;
            toolStripButtonSalvar.Visible = toolStripSeparatorSalvar.Visible =
                toolStripButtonDesfazer.Visible = tracker.HasChanges();
            toolStripButtonSalvar.Text = Alteracoes();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void frmBalance_FormClosing(object sender, FormClosingEventArgs e) {
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
            toolStripButtonSalvar.Visible = toolStripSeparatorSalvar.Visible =
                toolStripButtonDesfazer.Visible = false;
            dgvBalance.Refresh();
        }

        private void dgvBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if ((e.ColumnIndex != 6 && e.ColumnIndex != 7) || (decimal)e.Value > 0) return;
            e.CellStyle.ForeColor = Color.DarkOrange;
        }
    }
}
