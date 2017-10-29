using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmPagamentos : Form {
        public frmPagamentos() {
            InitializeComponent();
            toolStrip1.Visible = false;
        }

        private void frmPagamentos_Load(object sender, EventArgs e) {
            dgvPagamentos.Columns[0].Visible = false;
            dgvPagamentos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPagamentos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            for (var col = 3; col < dgvPagamentos.ColumnCount; col++) {
                dgvPagamentos.Columns[col].Width = 50;
            }
        }

        private void frmPagamentos_FormClosing(object sender, FormClosingEventArgs e) {
            dgvPagamentos.EndEdit();
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

        private void dgvPagamentos_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            RefreshSalvar();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvPagamentos.EndEdit();
            entityDataSource1.SaveChanges();
            RefreshSalvar();
        }

        private void toolStripButtonDesfazer_Click(object sender, EventArgs e) {
            entityDataSource1.CancelChanges();
        }

        private void RefreshSalvar() {
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            toolStrip1.Visible = tracker.HasChanges();

            var alts = tracker.Entries().Count(entry => entry.State == EntityState.Added ||
                                                        entry.State == EntityState.Deleted ||
                                                        entry.State == EntityState.Modified);

            toolStripButtonSalvar.Text = $" Salvar {alts} alteraç" + (alts == 1 ? "ão" : "ões");
        }
    }
}
