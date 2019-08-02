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
            _ctx = new MoneyBinEntities();
            if (!_ctx.Balance.Any()) {
                MessageBox.Show(@"Não há registros a serem mostrados.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            GridStyles.FormatGrid(dgvBalance);
            GridStyles.FormatColumns(dgvBalance, GridStyles.StyleDate, 90, 1);
            GridStyles.FormatColumns(dgvBalance, 5, 6, GridStyles.StyleCurrency, 80);
            //dgvBalance.Columns[2].Width = 400;
            dgvBalance.Columns[4].Width = 50;
            dgvBalance.Columns[8].Width = 120;
            dgvBalance.Columns[9].Width = 180;
            dgvBalance.Columns[10].Width = 180;
            dgvBalance.Columns[11].Width = 50;

            this.Width = 150 + dgvBalance.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            toolStripComboBoxBanco.ComboBox.Items.AddRange(_ctx.Accounts.Select(a => a.Apelido).OrderBy(a=>a).ToArray());
            dgvBalance.DataSource = BalanceBindingSource;

            this.toolStripComboBoxBanco.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxConta_SelectedIndexChanged);
            toolStripComboBoxBanco.ComboBox.SelectedIndex = 0;
        }

        private void frmBalance_FormClosing(object sender, FormClosingEventArgs e) {
            dgvBalance.EndEdit();
            if (!_ctx.ChangeTracker.HasChanges()) {
                return;
            }

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
        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = (string)toolStripComboBoxBanco.SelectedItem;
            var dados = _ctx.Balance.Where(b => b.Account.Apelido == conta);
            BalanceBindingSource.DataSource = dados.OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();

            toolStripComboBoxGrupo.ComboBox.Items.Clear();
            toolStripComboBoxGrupo.ComboBox.Items.Add("Todos");

            var grupos = dados.Select(b => b.Grupo).Where(g => g != null).Distinct();
            if (grupos.Any()) {
                toolStripComboBoxGrupo.ComboBox.Items
                    .AddRange(grupos.OrderBy(b => b).ToArray());
            }

            toolStripComboBoxGrupo.ComboBox.SelectedIndex = 0;
            SelectFirstRow();
        }

        private void toolStripComboBoxGrupo_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = (string)toolStripComboBoxBanco.SelectedItem;
            if (toolStripComboBoxGrupo.SelectedIndex == 0) {
                BalanceBindingSource.DataSource = _ctx.Balance
                    .Where(b => b.Account.Apelido == conta)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
            }
            else {
                BalanceBindingSource.DataSource = _ctx.Balance
                    .Where(b => b.Account.Apelido == conta
                                && b.Grupo == (string)toolStripComboBoxGrupo.SelectedItem)
                    .OrderByDescending(b => b.Data).ThenByDescending(b => b.ID).ToList();
            }
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvBalance.EndEdit();
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void toolStripTextBoxProcurar_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(toolStripTextBoxProcurar.Text)) return;
            SelectFirstRow();
            Procurar();
        }

        private void toolStripTextBoxProcurar_Validated(object sender, EventArgs e) {
            SelectFirstRow();
        }

        private void SelectFirstRow() {
            dgvBalance.ClearSelection();
            dgvBalance.CurrentCell = dgvBalance.Rows[0].Cells[0];
            dgvBalance.Rows[0].Selected = true;
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
                    if (!found) {
                        continue;
                    }

                    dgvBalance.CurrentCell = Row.Cells[col];
                    break;
                }
                if (found) {
                    return;
                }
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
            if ((e.ColumnIndex != 5 && e.ColumnIndex != 6) || (decimal)e.Value > 0) {
                return;
            }

            e.CellStyle.ForeColor = (decimal)e.Value == 0 ? Color.Gray : Color.DarkOrange;
        }

        private void dgvBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvBalance.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") {
                return;
            } ((List<BalanceItem>)BalanceBindingSource.DataSource).CalcularSaldos(e.RowIndex);
            dgvBalance.Refresh();
        }

        private void dgvBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            FormUtils.EditingControlShowing(sender, e);
        }

        private void dgvBalance_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            ((List<BalanceItem>)BalanceBindingSource.DataSource).CalcularSaldos(e.Row.Index);
            dgvBalance.Refresh();
        }

        private void dgvBalance_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            var bi = (BalanceItem)dgvBalance.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Deletar item:\n{bi}?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                e.Cancel = true;
                return;
            }
            _ctx.sp_BalanceItemDelete(bi.ID);
        }

        #endregion DATAGRIDVIEW
    }
}
