using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmLeitor : Form {
        private List<BalanceItemComSaldo> _BalanceItems;
        public bool HasData;

        #region FORM
        public frmLeitor() {
            InitializeComponent();

            _BalanceItems = BalanceFileReader.Read();
            HasData = _BalanceItems.Any();
            if (!HasData)
                Load += (s, e) => Close();
        }

        private void frmLeitor_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvBalance);
            GridStyles.FormatColumn(dgvBalance.Columns[2], GridStyles.StyleDate, 90);
            GridStyles.FormatColumns(dgvBalance, new[] { 6, 7 }, GridStyles.StyleCurrency, 80);
            dgvBalance.Columns[3].Width = 400;
            dgvBalance.Columns[11].Width = 100;
            dgvBalance.Columns[12].Width = 110;
            dgvBalance.Columns[13].Width = 180;

            this.Width = 150 + dgvBalance.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }

        private void frmLeitor_FormClosing(object sender, FormClosingEventArgs e) {
            dgvBalance.EndEdit();
            if (!_BalanceItems.Any(bi => bi.AddToDatabase)) return;
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
            using (var ctx = new MoneyBinEntities()) {
                ctx.BalanceComSaldo.AddRange(_BalanceItems.Where(bi => bi.AddToDatabase).ToList());
                try {
                    return ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex) {
                    foreach (var eve in ex.EntityValidationErrors) {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors) {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        private void Limpar() {
            dgvBalance.DataSource = null;
            _BalanceItems.Clear();
            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }

        private void LerArquivo() {
            dgvBalance.DataSource = null;
            _BalanceItems = _BalanceItems.Concat(BalanceFileReader.Read()).Distinct().ToList();
            dgvBalance.DataSource = _BalanceItems;
            AtualizarBotoes();
        }
        #endregion

        #region GRID
        private void dgvBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvBalance.RowCount == 0) return;
            var lastCol = dgvBalance.ColumnCount - 1;
            if ((bool)dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value) return;
            e.CellStyle.ForeColor = Color.DarkGray;
        }

        private void dgvBalance_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            var lastCol = dgvBalance.ColumnCount - 1;
            if (_BalanceItems.ElementAt(e.RowIndex).Grupo == "Saldo") return;
            var novoValor = !(bool)dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value;
            dgvBalance.Rows[e.RowIndex].Cells[lastCol].Value = novoValor;
            dgvBalance.Refresh();
            AtualizarBotoes();
        }

        private void dgvBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvBalance.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") return;
            FormUtils.CalculaSaldos(_BalanceItems, e.RowIndex);
            dgvBalance.Refresh();
        }

        private void dgvBalance_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show($"Row: {e.RowIndex}\nColumn: {e.ColumnIndex}\n\nError: {e.Exception}", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            FormUtils.EditingControlShowing(sender, e);
        }

        #endregion

        #region TOOLBAR
        private void AtualizarBotoes() {
            toolStripButtonSalvar.Visible = toolStripButtonLimpar.Visible =
                _BalanceItems.Any(bi => bi.AddToDatabase);
            if (!toolStripButtonSalvar.Visible) return;
            toolStripButtonSalvar.Text = $@"Salvar {_BalanceItems.Count(bi => bi.AddToDatabase)} novos itens";
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            var count = Salvar();
            Limpar();
            if (MessageBox.Show($"{count} registros salvos. Ler outro arquivo?", Text, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                this.Close();
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
        #endregion
    }
}
