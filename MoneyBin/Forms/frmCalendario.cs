using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmCalendario : Form {
        private readonly MoneyBinEntities _ctx;
        private int previousIndex = -1;
        public frmCalendario() {
            InitializeComponent();
            _ctx = new MoneyBinEntities();
        }

        private void frmCalendario_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvCalendario);
            GridStyles.FormatColumn(dgvCalendario.Columns[3], GridStyles.StyleInteger, 40);

            var meses = _ctx.Calendar.GroupBy(p => new { p.Year, p.Month })
                .Select(g => new MesPicklist { Month = g.FirstOrDefault().Month, Year = g.FirstOrDefault().Year })
                .OrderByDescending(m => m.Year).ThenByDescending(m => m.Month).ToList();

            if (meses.Count == 0) {
                previousIndex = 0;
                meses.Insert(0, new MesPicklist());
            }
            meses.Insert(0, meses[0].ProximoMes);

            toolStripComboBoxMes.ComboBox.ValueMember = "Mes";
            toolStripComboBoxMes.ComboBox.DisplayMember = "Mes";
            toolStripComboBoxMes.ComboBox.DataSource = meses;

            previousIndex = 1;
            toolStripComboBoxMes.SelectedIndex = 1;

            SetHeight();
            UpdateToolbarButtons();
        }

        private void frmCalendario_FormClosing(object sender, FormClosingEventArgs e) {
            dgvCalendario.EndEdit();
            if (!toolStripButtonSalvar.Visible) {
                return;
            }

            switch (FormUtils.PerguntaSeSalva(_ctx.ChangeTracker, Text)) {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    _ctx.SaveChanges();
                    break;
                case DialogResult.No:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void dgvCalendario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var cal = (CalendarItem)dgvCalendario.Rows[e.RowIndex].DataBoundItem;
            if (cal.Paid) {
                e.CellStyle.ForeColor = Color.Gray;
            }
        }

        private void dgvCalendario_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 || dgvCalendario.Columns[e.ColumnIndex].Name !=
                "afetaSaldoDataGridViewCheckBoxColumn") {
                return;
            }
        }

        private void toolStripComboBoxMes_SelectedIndexChanged(object sender, EventArgs e) {
            if (previousIndex == -1) {
                return;
            }

            var reload = false;
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
                    _ctx.SaveChanges();
                }
            }
            if (reload) {
                toolStripComboBoxMes.SelectedIndex = previousIndex;
            }

            var mes = (MesPicklist)toolStripComboBoxMes.SelectedItem;
            _ctx.sp_CalendarRefresh((short)mes.Year, (short)mes.Month);
            CalendarBindingSource.DataSource = _ctx.Calendar
                .Where(c => c.Month == mes.Month && c.Year == mes.Year)
                .ToList().OrderBy(c => c.Day).ThenBy(c => c.ToString()).ToList();
            SetHeight();
            previousIndex = toolStripComboBoxMes.SelectedIndex;
            EnableButtons();
            UpdateToolbarButtons();
        }

        private void SetHeight() {
            Height = 30 + toolStrip1.Height + dgvCalendario.ColumnHeadersHeight +
                     dgvCalendario.RowCount * (5 + dgvCalendario.RowTemplate.Height);
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            dgvCalendario.EndEdit();
            _ctx.SaveChanges();
            toolStripButtonSalvar.Visible = false;
        }

        private void dgvCalendario_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            UpdateToolbarButtons();
        }

        private void UpdateToolbarButtons() {
            toolStripButtonSalvar.Text = FormUtils.TextoSalvar(_ctx.ChangeTracker);
            toolStripButtonSalvar.Visible = _ctx.ChangeTracker.HasChanges();
            toolStripEncontrarPagamentos.Visible =
                dgvCalendario.Rows.OfType<DataGridViewRow>()
                    .Select(r => (CalendarItem)r.DataBoundItem)
                    .Any(r =>
                        (!r.Scheduled && r.Date < DateTime.Today) ||
                        (r.Scheduled && !r.Paid && (r.Payment.Historico != null || r.Payment.Valor != null))
                    );
        }

        private void dgvCalendario_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            dgvCalendario.EndEdit();
        }

        private void toolStripButtonMonth_Click(object sender, EventArgs e) {
            var btn = sender as ToolStripButton;
            if (btn.Name.Contains("Prev")) {
                toolStripComboBoxMes.ComboBox.SelectedIndex += 1;
            }
            else {
                toolStripComboBoxMes.ComboBox.SelectedIndex -= 1;
            }
            EnableButtons();
        }

        private void EnableButtons() {
            toolStripButtonNextMonth.Enabled = toolStripComboBoxMes.ComboBox.SelectedIndex < toolStripComboBoxMes.ComboBox.Items.Count - 1;
            toolStripButtonPrevMonth.Enabled = toolStripComboBoxMes.ComboBox.SelectedIndex > 0;
        }

        private void toolStripButtonEncontrarPagamentos_Click(object sender, EventArgs e) {
            ProcurarAgendamentos();
            ProcurarPagamentos();
            dgvCalendario.Refresh();
            UpdateToolbarButtons();
        }

        private void ProcurarAgendamentos() {
            var folder = Properties.Settings.Default.PaymentsFolder;
            const string header = "Conformar Agendamento";
            var mes = (MesPicklist)toolStripComboBoxMes.SelectedItem;
            foreach (var item in
                dgvCalendario.Rows.OfType<DataGridViewRow>()
                .Select(r => (CalendarItem)r.DataBoundItem)
                .Where(i => !i.Scheduled)
                .OrderBy(i => i.Date)) {
                var itemFolder = $@"{folder}{item.Payment}";
                if (Directory.Exists(itemFolder)) {
                    var files = Directory.GetFiles(itemFolder, $@"{mes.YearMonth}*.*");
                    if (files.Length == 0) {
                        if (item.Date <= DateTime.Today) {
                            MessageBox.Show(item.Description +
                                        ":\n\n\tAgendamento não encontrado.",
                                        header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else {
                        item.Scheduled = MessageBox.Show(item.Description + "\n\n" +
                                         string.Join("\t\n", files).Replace(folder, "    ") + "\n\nConfirma?", header,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) == DialogResult.Yes;
                    }
                }
                else {
                    if (MessageBox.Show($"Folder para '{item.Payment}' não existe. Cria?", header, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes) {
                        Directory.CreateDirectory(itemFolder);
                    }
                }
            }
        }

        private void ProcurarPagamentos() {
            var mes = (MesPicklist)toolStripComboBoxMes.SelectedItem;
            var pagamentos = _ctx.Balance.Where(b => b.Valor < 0
                                                     && b.Data.Year == mes.Year
                                                     && b.Data.Month == mes.Month12).ToList();
            var naoPagos = dgvCalendario.Rows.OfType<DataGridViewRow>()
                .Select(r => (CalendarItem)r.DataBoundItem).Where(r => r.Scheduled && !r.Paid &&
                (r.Payment.Historico != null || r.Payment.Valor != null));

            foreach (var item in naoPagos) {
                var ip = item.Payment;
                IEnumerable<BalanceItem> found;
                if (ip.Historico != null && ip.Valor != null) {
                    found = pagamentos.Where(p => p.Historico.Contains(ip.Historico) &&
                    p.Valor == -1 * ip.Valor);
                }
                else if (ip.Historico != null) {
                    found = pagamentos.Where(p => p.Historico.Contains(ip.Historico));
                }
                else {
                    found = pagamentos.Where(p => p.Valor == -1 * ip.Valor);
                }
                if (!found.Any()) {
                    MessageBox.Show(item.Description +
                                ":\n\n\tPagamento não encontrado.",
                                "Confirmar Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }

                var text = found.Select(f => f.ToString())
                    .Aggregate((i, j) => "\t" + i.ToString() + "\n" + j.ToString());
                item.Paid = MessageBox.Show(item.Description +
                                            ":\n\n" + text + "\n\nConfirma?",
                                "Confirmar Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes;
            }
        }
    }

    internal class MesPicklist {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Month12 => 1 + (int)Math.Log(Month, 2);
        public string Mes => $"{Month12:00}-{Year}";

        public MesPicklist() {
            Month = (int)Math.Pow(2, DateTime.Today.Month - 1);
            Year = DateTime.Today.Year;
        }

        public string YearMonth => $"{Year:0000}-{Month12:00}";

        public MesPicklist ProximoMes =>
            Month12 == 12 ? new MesPicklist() { Month = 1, Year = Year + 1 } :
                new MesPicklist() { Month = Month * 2, Year = Year };
    }
}
