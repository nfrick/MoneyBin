using DataClasses;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmReport : Form {

        private static string _rptPath;

        public frmReport() {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e) {
            // _rptPath = ConfigurationManager.AppSettings["reportpath"] + @"{0}.rdlc";
            var x = AppDomain.CurrentDomain.BaseDirectory;
            _rptPath = string.Join(@"\", x.Split('\\'), 0, x.Count(c => c == '\\') - 2) + @"\Reports\Report{0}.rdlc";
        }

        private void ToolStripButtonReport_Click(object sender, EventArgs e) {
            var dlg = new dlgReportBalanceOptions();
            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            var reportEngine = reportViewer1.LocalReport;
            reportEngine.DataSources.Clear();
            var rep = ((ToolStripButton)sender).Tag;
            reportEngine.ReportPath = string.Format(_rptPath, rep);
            reportEngine.DataSources.Add(new ReportDataSource($@"DataSet{rep}", MoneyBinDB.GetBalanceItems(dlg.Banco, dlg.Inicio, dlg.Termino)));  //, "")));
            reportViewer1.RefreshReport();
        }
    }
}
