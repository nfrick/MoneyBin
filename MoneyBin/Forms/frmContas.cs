using GridAndChartStyleLibrary;
using System;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;

namespace MoneyBin.Forms {
    public partial class frmContas : Form {
        public frmContas() {
            InitializeComponent();
            GridStyles.FormatGrid(dgvContas);
            GridStyles.FormatColumn(dgvContas.Columns[0], GridStyles.StyleInteger, 40);
            dgvContas.Columns[2].Width = 120;
            dgvContas.Columns[3].Width = 80;
            dgvContas.Columns[4].Width = 100;
            dgvContas.Columns[5].Width = 80;
            dgvContas.Columns[6].Width = 250;
            dgvContas.Columns[7].Width = 130;
            dgvContas.Columns[8].Width = 130;
            dgvContas.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var font = new Font("Segoe UI", 12);
            for (var i = 0; i < dgvContas.ColumnCount; i++) {
                dgvContas.Columns[i].DefaultCellStyle.Font = font;
            }
            dgvContas.RowTemplate.Height = 28;
            dgvContas.ColumnHeadersHeight = 28;


            using (var ctx = new MoneyBinEntities()) {
                var contas = ctx.Accounts.ToList();
            }
        }

        private void frmRules_FormClosing(object sender, FormClosingEventArgs e) {
            dgvContas.EndEdit();
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

        private void dgvContas_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            RefreshSalvar();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvContas.EndEdit();
            try {
                entityDataSource1.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                var sb = new StringBuilder(ex.Message);
                foreach (var evError in ex.EntityValidationErrors) {
                    sb.Append($"\n\nID = {((Bank)evError.Entry.Entity).Banco} - {evError.ValidationErrors.Count} errors found:");
                    foreach (var error in evError.ValidationErrors) {
                        sb.Append($"\n\t{error.ErrorMessage}");
                    }
                }
                MessageBox.Show(sb.ToString(), "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
    }
}
