using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using GridAndChartStyleLibrary;

namespace MoneyBin.Forms {
    public partial class frmCalendario : Form {
        private MoneyBinEntities _ctx;
        private int previousIndex = -1;
        public frmCalendario() {
            InitializeComponent();
            _ctx = new MoneyBinEntities();
        }

        private void frmCalendario_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvCalendario);
            var temp = _ctx.Calendar.Select(c => new { c.Month, c.Year }).Distinct().OrderByDescending(m => m.Year).ThenByDescending(m => m.Month).ToList();
            var Meses = temp.Select(t => new MesPicklist { Month = t.Month, Year = t.Year }).ToList();
            Meses.Insert(0, Meses[0].ProximoMes());
            toolStripComboBoxMes.ComboBox.DataSource = Meses;
            toolStripComboBoxMes.ComboBox.ValueMember = "Mes";
            toolStripComboBoxMes.ComboBox.DisplayMember = "Mes";
            previousIndex = 1;
            toolStripComboBoxMes.SelectedIndex = 1;

        }

        private void LoadData(bool Reload = false) {
            if (Reload)
                toolStripComboBoxMes.SelectedIndex = previousIndex;
            var mes = (MesPicklist)toolStripComboBoxMes.SelectedItem;
            CalendarBindingSource.DataSource = _ctx.Calendar.Where(c => c.Month == mes.Month && c.Year == mes.Year).ToList();
            Height = toolStrip1.Height + dgvCalendario.ColumnHeadersHeight +
            dgvCalendario.RowCount * (5 + dgvCalendario.RowTemplate.Height);
            previousIndex = toolStripComboBoxMes.SelectedIndex;
        }

        private void dgvCalendario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var cal = (CalendarItem)dgvCalendario.Rows[e.RowIndex].DataBoundItem;
            if (cal.Paid) e.CellStyle.ForeColor = Color.Gray;
        }

        private void dgvCalendario_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvCalendario.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") return;
        }

        private void toolStripComboBoxMes_SelectedIndexChanged(object sender, EventArgs e) {
            var reload = false;
            if (previousIndex == -1) return;
            if (toolStripComboBoxMes.SelectedIndex == 0) {
                var novoMes = (MesPicklist)toolStripComboBoxMes.Items[0];
                if (MessageBox.Show($"Mês {novoMes.Mes} não existe. Cria?", Text, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) {
                    reload = true;
                }
                else {
                    var payments = _ctx.Payments.Where(p => (p.Months & novoMes.Month) == novoMes.Month).ToList()
                        .Select(p => new CalendarItem() {
                            Month = (short)novoMes.Month,
                            Year = (short)novoMes.Year,
                            PaymentID = p.ID,
                            Paid = false
                        }).ToList();
                    _ctx.Calendar.AddRange(payments);
                }
            }
            LoadData(reload);
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvCalendario.EndEdit();
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void dgvCalendario_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            toolStripButtonSalvar.Text = FormUtils.TextoSalvar(_ctx.ChangeTracker);
            toolStripButtonSalvar.Visible = _ctx.ChangeTracker.HasChanges();
        }
    }

    internal class MesPicklist {
        public string Mes => $"{1 + Math.Log(Month, 2):00}-{Year}";
        public int Month { get; set; }
        public int Year { get; set; }

        public MesPicklist ProximoMes() {
            var ultimoMes = 1 + (int)Math.Log(Month, 2);
            return ultimoMes == 12 ? new MesPicklist() { Month = 0, Year = Year + 1 } :
                new MesPicklist() { Month = Month * 2, Year = Year };
        }
    }
}
