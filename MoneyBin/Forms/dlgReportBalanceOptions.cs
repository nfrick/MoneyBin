using System;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class dlgReportBalanceOptions : Form {
        public dlgReportBalanceOptions() {
            InitializeComponent();
        }

        public string Banco {get; set; }

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
            var dateRange = DataClasses.MoneyBinDB.GetDataMaxMin(Banco);
            if (dateRange.Max.Year == 1900) {
                dateTimePickerInicio.Value = DateTime.Today;
                dateTimePickerInicio.Enabled = false;
                dateTimePickerTermino.Value = DateTime.Today;
                dateTimePickerTermino.Enabled = false;
            }
            else {
                var menosSeis = DateTime.Today.AddMonths(-6);
                dateTimePickerInicio.MinDate = dateRange.Min;
                dateTimePickerInicio.MaxDate = dateRange.Max;
                dateTimePickerInicio.Value = (menosSeis.CompareTo(dateRange.Min) < 0) ? dateRange.Min : menosSeis;

                dateTimePickerTermino.MinDate = dateRange.Min;
                dateTimePickerTermino.MaxDate = dateRange.Max;
                dateTimePickerTermino.Value = dateRange.Max;
            }
        }

        private void buttons_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
