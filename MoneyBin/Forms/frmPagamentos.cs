﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridAndChartStyleLibrary;

namespace MoneyBin.Forms {
    public partial class frmPagamentos : Form {
        public frmPagamentos() {
            InitializeComponent();
            toolStrip1.Visible = false;
        }

        private void frmPagamentos_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvPagamentos);
            dgvPagamentos.Columns[0].Visible = false;
            dgvPagamentos.Columns[1].Width = 50;
            dgvPagamentos.Columns[3].Width = 150;
            GridStyles.FormatColumn(dgvPagamentos.Columns[4], GridStyles.StyleInteger, 50);
            dgvPagamentos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridStyles.FormatColumn(dgvPagamentos.Columns[6], GridStyles.StyleCurrency, 70);
            for (var col = 7; col < dgvPagamentos.ColumnCount; col++) {
                dgvPagamentos.Columns[col].Width = 50;
            }          
        }

        private void frmPagamentos_FormClosing(object sender, FormClosingEventArgs e) {
            dgvPagamentos.EndEdit();
            if (!toolStripButtonSalvar.Visible) return;
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
            if((toolStrip1.Visible = tracker.HasChanges()))
            toolStripButtonSalvar.Text = FormUtils.TextoSalvar(entityDataSource1.DbContext.ChangeTracker);
        }

        private void dgvPagamentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView) sender;
            if (dgv.RowCount == 0) {
                return;
            }

            var ativo = dgv.Rows[e.RowIndex].Cells[1].Value ?? false;
            if ((bool)ativo) {
                return;
            }

            e.CellStyle.ForeColor = Color.DarkGray;
        }
    }
}
