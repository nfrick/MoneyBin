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
            toolStripComboBoxBanco.ComboBox.Items.AddRange(_ctx.Balance.Select(b => b.Banco).Distinct().OrderBy(b => b).ToArray());
            toolStripComboBoxBanco.ComboBox.SelectedIndex = 0;
            dgvBalance.DataSource = BalanceBindingSource;

            toolStripComboBoxBanco.ComboBox.SelectedIndex = 0;
        }

        private void frmBalance_FormClosing(object sender, FormClosingEventArgs e) {
            dgvBalance.EndEdit();
            if (!_ctx.ChangeTracker.HasChanges()) return;
            switch (FormUtils.PerguntaSeSalva(_ctx.ChangeTracker, Text)) {
                case DialogResult.Yes:
                    _ctx.SaveChanges();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        #endregion FORM

        #region TOOLBAR
        private void toolStripComboBoxBanco_SelectedIndexChanged(object sender, EventArgs e) {
            BalanceBindingSource.DataSource = _ctx.Balance
                .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem)
                .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();

            toolStripComboBoxGrupo.ComboBox.Items.Clear();
            toolStripComboBoxGrupo.ComboBox.Items.Add("Todos");
            toolStripComboBoxGrupo.ComboBox.Items
                .AddRange(_ctx.Balance.Select(b => b.NovoGrupo).Distinct().OrderBy(b => b).ToArray());
            toolStripComboBoxGrupo.ComboBox.SelectedIndex = 0;
        }

        private void toolStripComboBoxGrupo_SelectedIndexChanged(object sender, EventArgs e) {
            if (toolStripComboBoxGrupo.SelectedIndex == 0)
                BalanceBindingSource.DataSource = _ctx.Balance.Local
                    .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
            else
                BalanceBindingSource.DataSource = _ctx.Balance.Local
                    .Where(b => b.Banco == (string)toolStripComboBoxBanco.SelectedItem
                                && b.NovoGrupo == (string)toolStripComboBoxGrupo.SelectedItem)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvBalance.EndEdit();
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void toolStripTextBoxProcurar_KeyPress(object sender, KeyPressEventArgs e) {

        }
        private void toolStripTextBoxProcurar_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(toolStripTextBoxProcurar.Text))
                Procurar();
        }

        private void toolStripButtonProcurar_Click(object sender, EventArgs e) {
            Procurar();
        }

        private void Procurar() {
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
            toolStripButtonSalvar.Text = FormUtils.TextoSalvar(_ctx.ChangeTracker);
            toolStripButtonSalvar.Visible = _ctx.ChangeTracker.HasChanges();
        }

        private void dgvBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if ((e.ColumnIndex != 6 && e.ColumnIndex != 7) || (decimal)e.Value > 0) return;
            e.CellStyle.ForeColor = (decimal)e.Value == 0 ? Color.Gray : Color.DarkOrange;
        }

        private void dgvBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvBalance.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") return;

            ((List<BalanceItem>)BalanceBindingSource.DataSource).CalcularSaldos(e.RowIndex);
            dgvBalance.Refresh();
        }

        private void dgvBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            FormUtils.EditingControlShowing(sender, e);
        }

        #endregion DATAGRIDVIEW

    }
}
