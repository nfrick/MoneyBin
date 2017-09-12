using CustomControls;
using DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GridAndChartStyleLibrary;

namespace MoneyBin {
    public partial class frmRules : CustomControls.frmBase {
        public SortableBindingList<Rule> Rules;
        public List<Rule> DeletedItems = new List<Rule>();
        private BindingSource _source;

        public event EventHandler OnRulesGridAddedChanged;
        public event EventHandler OnRulesGridRecordsChanged;
        public event EventHandler OnRulesGridUpdatedChanged;
        public event EventHandler OnRulesGridDeletedChanged;

        public frmRules() {
            InitializeComponent();
        }

        private void frmRules_Load(object sender, EventArgs e) {
            OnRulesGridAddedChanged += OnAddedChanged;
            OnRulesGridRecordsChanged += OnRecordsChanged;
            OnRulesGridUpdatedChanged += OnUpdatedChanged;
            OnRulesGridDeletedChanged += OnDeletedChanged;

            toolStripButtonAnalyze.Visible = false;
            toolStripButtonCategorize.Visible = false;
            SetSource();

            GridStyles.FormatGrid(dgvRules);
            ocorrenciasDataGridViewTextBoxColumn.DefaultCellStyle = GridStyles.StyleInteger;

            var newHeight = 160 + Rules.Count * dgvRules.RowTemplate.Height;
            this.Height = newHeight < this.Height ? newHeight : this.Height;
        }

        private void SetSource() {
            if (!SaveChanges(true)) return;
            Rules = MoneyBinDB.GetRules();
            _source = new BindingSource {DataSource = Rules};
            dgvRules.DataSource = _source;
            DeletedItems.Clear();
            RaiseRecords();
            RaiseAdded();
            RaiseUpdated();
            RaiseDeleted();
        }

        public bool SaveChanges(bool promptBeforeSaving) {
            if (Rules == null)
                return true;

            var newRules = Rules.Count(p => p.IsNew);
            var updatedRules = Rules.Count(p => p.Updated && !p.IsNew);

            if (newRules + updatedRules == 0 && !DeletedItems.Any())
                return true;

            if (promptBeforeSaving) {
                var resp = MessageBox.Show(CreateSavePrompt(newRules, updatedRules, DeletedItems.Count), "Pending Updates", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (resp) {
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }

            if (newRules + updatedRules > 0)
                MoneyBinDB.UpdateRules(Rules.Where(p => p.Updated).ToList());
            if (DeletedItems.Count > 0) {
                MoneyBinDB.DeleteRules(DeletedItems);
                DeletedItems.Clear();
            }
            _source.ResetBindings(false);
            RaiseUpdated();
            RaiseDeleted();
            return true;
        }

        private void frmRules_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !SaveChanges(true);
        }

        public override void toolStripButtonLoad_Click(object sender, EventArgs e) {
            SetSource();
        }

        public override void toolStripButtonSave_Click(object sender, EventArgs e) {
            SaveChanges(false);
        }

        private void RulesdataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!Rules.Any() || Rules.Count <= e.RowIndex)
                return;
            var item = Rules[e.RowIndex];
            if (item.Updated)
                e.CellStyle.ForeColor = Color.Yellow;
        }

        private void dataGridViewRules_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            Rules[e.RowIndex].Updated = true;
            _source.ResetBindings(false);
            RaiseUpdated();
        }

        private void dataGridViewRules_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
            RaiseAdded();
        }

        private void dataGridViewRules_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            var row = e.Row.Index;
            if (!Rules[row].IsNew)
                DeletedItems.Add(Rules[row]);
        }

        private void dataGridViewRules_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            _source.ResetBindings(false);
            RaiseDeleted();
        }

        private void RulesdataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show($@"Data error in row {e.RowIndex} column {e.ColumnIndex}");
        }

        private void RaiseAdded() {
            RaiseRecords();
            OnRulesGridAddedChanged?.Invoke(Rules.Count(n => n.IsNew), null);
        }

        private void RaiseUpdated() {
            OnRulesGridUpdatedChanged?.Invoke(Rules.Count(n => n.Updated && !n.IsNew), null);
        }

        private void RaiseRecords() {
            OnRulesGridRecordsChanged?.Invoke(Rules.Count(), null);
        }

        private void RaiseDeleted() {
            RaiseAdded();
            RaiseUpdated();
            OnRulesGridDeletedChanged?.Invoke(DeletedItems.Count(), null);
        }

        private void dataGridViewRules_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (e.Control == null) return;
            var col = dgvRules.CurrentCell.ColumnIndex;
            var source = new AutoCompleteStringCollection();
            var txt = e.Control as TextBox;
            switch (dgvRules.Columns[col].Name) {
                case "bancoDataGridViewTextBoxColumn":
                    source.AddRange(Rules.Select(c => c.Banco).Distinct().ToArray());
                    txt.AutoCompleteCustomSource = source;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    break;
                case "grupoDataGridViewTextBoxColumn":
                    source.AddRange(Rules.Select(c => c.Grupo).Distinct().ToArray());
                    txt.AutoCompleteCustomSource = source;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    break;
                case "categoriaDataGridViewTextBoxColumn":
                    source.AddRange(Rules.Select(c => c.Categoria).Distinct().ToArray());
                    txt.AutoCompleteCustomSource = source;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    break;
                case "subCategoriaDataGridViewTextBoxColumn":
                    source.AddRange(Rules.Select(c => c.SubCategoria).Distinct().ToArray());
                    txt.AutoCompleteCustomSource = source;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    break;
                case "descricaoDataGridViewTextBoxColumn":
                    source.AddRange(Rules.Select(c => c.Descricao).Distinct().ToArray());
                    txt.AutoCompleteCustomSource = source;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    break;
                case "comparacaoDataGridViewComboBoxColumn":
                    break;
                default:
                    if(txt != null)
                        txt.AutoCompleteMode = AutoCompleteMode.None;
                    break;
            }
        }
    }
}
