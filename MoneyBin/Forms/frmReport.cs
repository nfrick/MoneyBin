using DataLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmReport : Form {

        private static string _rptPath;
        private readonly MoneyBinEntities _ctx;

        private readonly DateTimePicker _inicio = new DateTimePicker();
        private readonly DateTimePicker _termino = new DateTimePicker();

        public frmReport() {
            InitializeComponent();
            _ctx = new MoneyBinEntities();
            toolStrip1.Items.Insert(7, CreateDatePicker(_inicio));
            toolStrip1.Items.Add(CreateDatePicker(_termino));

            toolStripComboBoxBanco.ComboBox.DataSource = _ctx.DataMaxsMins.OrderBy(b => b.Banco).ToList();
            toolStripComboBoxBanco.ComboBox.DisplayMember = "Banco";
            toolStripComboBoxBanco.ComboBox.ValueMember = "Banco";
        }

        private ToolStripControlHost CreateDatePicker(DateTimePicker dtp) {
            dtp.Format = DateTimePickerFormat.Short;
            var datePicker = new ToolStripControlHost(dtp) {
                Font = toolStrip1.Font,
                AutoSize = false,
                Width = 80
            };
            return datePicker;
        }

        private void Form_Load(object sender, EventArgs e) {
            var x = AppDomain.CurrentDomain.BaseDirectory;
            _rptPath = string.Join(@"\", x.Split('\\'), 0, x.Count(c => c == '\\') - 2) + @"\Reports\Report{0}.rdlc";
        }

        private void ToolStripButtonReport_Click(object sender, EventArgs e) {
            var reportEngine = rptViewer.LocalReport;
            reportEngine.DataSources.Clear();
            var rep = (string)((ToolStripButton)sender).Tag;
            reportEngine.ReportPath = string.Format(_rptPath, rep);

            var Banco = (DataMaxMin)toolStripComboBoxBanco.SelectedItem;

            if (rep == "PorGrupo") {
                reportEngine.DataSources.Add(new ReportDataSource($@"DataSet{rep}",
                    _ctx.Balance.Where(b => b.Data >= _inicio.Value && b.Data <= _termino.Value).ToList()));
            }
            else {
                reportEngine.DataSources.Add(new ReportDataSource($@"DataSet{rep}",
                    _ctx.Balance
                        .Where(b => b.Banco == Banco.Banco && b.Data >= _inicio.Value &&
                                    b.Data <= _termino.Value).ToList()));
            }
            rptViewer.RefreshReport();
        }

        private void toolStripComboBoxBanco_SelectedIndexChanged(object sender, EventArgs e) {
            var Dates = (DataMaxMin)toolStripComboBoxBanco.SelectedItem;
            if (Dates.DataMax.Year == 1900) {
                _inicio.Value = _termino.Value = DateTime.Today;
                _inicio.Enabled = _termino.Enabled = false;
            }
            else {
                var menosSeis = Dates.DataMax.AddMonths(-6);
                _inicio.MinDate = Dates.DataMin;
                _inicio.MaxDate = Dates.DataMax;
                _inicio.Value = (menosSeis.CompareTo(Dates.DataMin) < 0) ? Dates.DataMin : menosSeis;

                _termino.MinDate = Dates.DataMin;
                _termino.MaxDate = Dates.DataMax;
                _termino.Value = Dates.DataMax;
            }
        }
    }
}
