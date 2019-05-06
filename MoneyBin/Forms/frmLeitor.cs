using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmLeitor : Form {
        private List<BalanceItem> _BalanceItems;
        public bool HasData;

        #region FORM
        public frmLeitor() {
            InitializeComponent();

            _BalanceItems = BalanceFileReader.Read();
            HasData = _BalanceItems != null && _BalanceItems.Any();
            if (!HasData) {
                Load += (s, e) => Close();
            }
        }

        private void frmLeitor_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvBalance);
            GridStyles.FormatColumns(dgvBalance, GridStyles.StyleDate, 90, 2);
            GridStyles.FormatColumns(dgvBalance, 6, 7, GridStyles.StyleCurrency, 80);
            dgvBalance.Columns[3].Width = 400;
            dgvBalance.Columns[5].Width = 50;

            this.Width = 150 + dgvBalance.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }

        private void frmLeitor_FormClosing(object sender, FormClosingEventArgs e) {
            dgvBalance.EndEdit();
            if (!_BalanceItems.Any(bi => bi.AddToDatabase)) {
                return;
            }

            switch (FormUtils.PerguntaSeSalva(_BalanceItems.Count(bi => bi.AddToDatabase), Text)) {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    Salvar();
                    break;
                case DialogResult.No:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int Salvar() {
            dgvBalance.EndEdit();
            var count = 0;
            using (var ctx = new MoneyBinEntities()) {
                foreach (var item in _BalanceItems.Where(bi => bi.AddToDatabase).OrderBy(bi => bi.Data).ThenByDescending(bi => bi.Valor)) {
                    try {
                        ctx.Balance.Add(item);
                        count += ctx.SaveChanges();
                    }
                    catch (DbEntityValidationException ex) {
                        var sb = new StringBuilder(100);
                        foreach (var eve in ex.EntityValidationErrors) {
                            sb.AppendLine(
                                $"{eve.Entry.Entity.GetType().Name}\n{(BalanceItem)eve.Entry.Entity}\nAção '{eve.Entry.State}' apresenta erros de validação:");
                            foreach (var ve in eve.ValidationErrors) {
                                sb.AppendLine($"\t- {ve.PropertyName}, Erro: {ve.ErrorMessage}");
                            }
                        }
                        MessageBox.Show(sb.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //throw;
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //throw;
                    }
                }
            }
            BalanceFileReader.DeleteBalanceFiles();
            return count;
        }

        private void Limpar() {
            dgvBalance.DataSource = null;
            _BalanceItems.Clear();
            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }

        private void LerArquivo() {
            dgvBalance.DataSource = null;
            _BalanceItems = _BalanceItems.Concat(BalanceFileReader.Read())
                .Distinct().OrderByDescending(b => b.Data).ToList();
            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }
        #endregion

        #region GRID
        private void dgvBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvBalance.RowCount == 0) {
                return;
            }

            var lastCol = dgvBalance.ColumnCount - 1;
            if ((bool)dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value) {
                return;
            }

            e.CellStyle.ForeColor = Color.DarkGray;
        }

        private void dgvBalance_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            var lastCol = dgvBalance.ColumnCount - 1;
            if (_BalanceItems.ElementAt(e.RowIndex).Grupo == "Saldo") {
                return;
            }

            var novoValor = !(bool)dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value;
            dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value = novoValor;
            dgvBalance.Refresh();
            AtualizarBotoes();
        }

        private void dgvBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 ||
                !dgvBalance.Columns[e.ColumnIndex].Name.EndsWith("CheckBoxColumn")) {
                return;
            }

            _BalanceItems.CalcularSaldos(e.RowIndex);
            dgvBalance.Refresh();
            AtualizarBotoes();
        }

        private void dgvBalance_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show($"Row: {e.RowIndex}\nColumn: {e.ColumnIndex}\n\nError: {e.Exception}", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            FormUtils.EditingControlShowing(sender, e);
        }

        private void dgvBalance_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            _BalanceItems.CalcularSaldos(e.RowIndex);
            dgvBalance.Refresh();
        }

        private void dgvBalance_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            _BalanceItems.CalcularSaldos(e.Row.Index);
            dgvBalance.Refresh();
        }

        #endregion

        #region TOOLBAR
        private void AtualizarBotoes() {
            toolStripButtonSalvar.Visible = toolStripButtonLimpar.Visible =
                _BalanceItems.Any(bi => bi.AddToDatabase);
            if (!toolStripButtonSalvar.Visible) {
                return;
            }
            toolStripButtonSalvar.Text = $@"Salvar {_BalanceItems.Count(bi => bi.AddToDatabase)} novos itens";
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            var count = Salvar();
            Limpar();
            if (MessageBox.Show($"{count} registros salvos. Ler outro arquivo?", Text, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No) {
                this.Close();
            }
            else {
                LerArquivo();
            }
        }

        private void toolStripButtonLimpar_Click(object sender, EventArgs e) {
            Limpar();
        }

        private void toolStripButtonLerArquivo_Click(object sender, EventArgs e) {
            LerArquivo();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e) {
            var text = toolStripTextBoxTarget.TextBox.Text;
            if (string.IsNullOrEmpty(text)) {
                return;
            }

            dgvBalance.DataSource = null;
            var targets = text == "*" ? _BalanceItems : _BalanceItems.Where(b => b.Historico.StartsWith(text));
            var check = ((ToolStripButton)sender).Text == "Add";
            foreach (var bi in targets) {
                bi.AddToDatabase = check;
            }
            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }

        #endregion
    }
}
