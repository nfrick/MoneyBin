using DataLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class dlgReportBalanceOptions : Form {
        public dlgReportBalanceOptions() {
            InitializeComponent();
        }

        public string Banco { get; set; }

        public DateTime Inicio => dateTimePickerInicio.Value;

        public DateTime Termino => dateTimePickerTermino.Value;

        private void dlgReportBalanceOptions_Load(object sender, EventArgs e) {
            Banco = "BB";
            SetDates();
        }

        private void comboBoxBanco_SelectedValueChanged(object sender, EventArgs e) {
            Banco = comboBoxBanco.Text;
            SetDates();
        }

        private void SetDates() {
            using (var ctx = new MoneyBinEntities()) {
                var dateRange = ctx.DataMaxsMins.FirstOrDefault(d => d.Banco == Banco);
                if (dateRange == null) return;
                if (dateRange.DataMax.Year == 1900) {
                    dateTimePickerInicio.Value = DateTime.Today;
                    dateTimePickerInicio.Enabled = false;
                    dateTimePickerTermino.Value = DateTime.Today;
                    dateTimePickerTermino.Enabled = false;
                }
                else {
                    var menosSeis = dateRange.DataMax.AddMonths(-6);
                    dateTimePickerInicio.MinDate = dateRange.DataMin;
                    dateTimePickerInicio.MaxDate = dateRange.DataMax;
                    dateTimePickerInicio.Value = (menosSeis.CompareTo(dateRange.DataMin) < 0) ? dateRange.DataMin : menosSeis;

                    dateTimePickerTermino.MinDate = dateRange.DataMin;
                    dateTimePickerTermino.MaxDate = dateRange.DataMax;
                    dateTimePickerTermino.Value = dateRange.DataMax;
                }
            }
        }

        private void buttons_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
