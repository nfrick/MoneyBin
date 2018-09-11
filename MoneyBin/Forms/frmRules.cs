using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmRules : Form {
        public frmRules() {
            InitializeComponent();
            comparacaoDataGridViewComboBoxColumn.DataSource = Comparacao.Lista();
            comparacaoDataGridViewComboBoxColumn.DisplayMember = "Descricao";
            comparacaoDataGridViewComboBoxColumn.ValueMember = "Id";
        }

        private void frmRules_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvRules);
            //dgvRules.Columns[0].Visible = false;
            dgvRules.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridStyles.FormatColumn(dgvRules.Columns[10], GridStyles.StyleInteger, 80);

            this.Width = 150 + dgvRules.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            RefreshSalvar();
        }

        private void frmRules_FormClosing(object sender, FormClosingEventArgs e) {
            dgvRules.EndEdit();
            if (!toolStripButtonSalvar.Visible) {
                return;
            }

            switch (FormUtils.PerguntaSeSalva(entityDataSource1.DbContext.ChangeTracker, Text)) {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    entityDataSource1.SaveChanges();
                    break;
                case DialogResult.No:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void dgvRules_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            RefreshSalvar();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvRules.EndEdit();
            entityDataSource1.SaveChanges();
            RefreshSalvar();
        }

        private void toolStripButtonDesfazer_Click(object sender, EventArgs e) {
            entityDataSource1.CancelChanges();
        }

        private void RefreshSalvar() {
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            if ((toolStripButtonSalvar.Visible = tracker.HasChanges())) {
                toolStripButtonSalvar.Text = FormUtils.TextoSalvar(tracker);
            }
        }

        private void dgvRules_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var banco = (string)dgvRules.CurrentRow.Cells[1].Value;
            if (e.ColumnIndex != 2 || string.IsNullOrEmpty(banco)) {
                return;
            }

            var row = dgvRules.CurrentRow;
            var frm = new frmRuleFromHistorico(banco);
            if (frm.ShowDialog() != DialogResult.OK) {
                return;
            }
            row.Cells[2].Value = frm.lvHistoricos.SelectedItems[0].Text;
            dgvRules.Refresh();
        }
    }
}
