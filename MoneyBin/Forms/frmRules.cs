using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Data.Entity;
using System.Linq;
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
            dgvRules.Columns[0].Visible = false;
            dgvRules.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridStyles.FormatColumn(dgvRules.Columns[12], GridStyles.StyleInteger, 80);

            this.Width = 150 + dgvRules.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            RefreshSalvar();
        }

        private void dgvRules_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            RefreshSalvar();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            entityDataSource1.SaveChanges();
            RefreshSalvar();
        }

        private void RefreshSalvar() {
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            toolStripButtonSalvar.Visible = tracker.HasChanges();

            var alts = tracker.Entries().Count(entry => entry.State == EntityState.Added ||
                                                        entry.State == EntityState.Deleted ||
                                                        entry.State == EntityState.Modified);

            toolStripButtonSalvar.Text = $" Salvar {alts} alteraç" + (alts == 1 ? "ão" : "ões");
        }

        private void frmRules_FormClosing(object sender, FormClosingEventArgs e) {
            if (!toolStripButtonSalvar.Visible) return;
            switch (MessageBox.Show(@"Salvar alterações pendentes?", Text, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)) {
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
    }
}
