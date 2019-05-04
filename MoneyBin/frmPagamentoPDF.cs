using DataLayer;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmPagamentoPDF : Form {

        public ComprovantePDF Comprovante { get; private set; }
        private readonly string _folder;

        public frmPagamentoPDF(string header, string folder, IReadOnlyCollection<string> files) {
            InitializeComponent();
            labelHeader.Text = header;
            _folder = folder;
            foreach (var file in files) {
                listBoxFiles.Items.Add(file.Replace(_folder, ""));
            }

            if (files.Count == 1) {
                listBoxFiles.SelectedIndex = 0;
            }
            else {
                listBoxFiles.SelectedItem = listBoxFiles.Items.Cast<string>().First(f => f.Contains("pagto"));
            }
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, System.EventArgs e) {
            var file = _folder + (string)listBoxFiles.SelectedItem;
            Comprovante = new ComprovantePDF(file);
            labelAgendamentoData.Text = Comprovante.AgendamentoDisplay;
            labelPagamentoData.Text = Comprovante.PagamentoDisplay;
            labelValorNumero.Text = Comprovante.ValorDisplay;
            textBoxPDF.Text = Comprovante.TextoToDisplay;
            textBoxPDF.Select(0, 0);
            buttonOK.Enabled = Comprovante.DadosOK;
        }

        private void button_Click(object sender, System.EventArgs e) {
            this.Close();
        }

        private void label_TextChanged(object sender, System.EventArgs e) {
            var label = (Label)sender;
            label.ForeColor = label.Text == @"NÃO ENCONTRADO" ? Color.Yellow : Color.White;
        }
    }
}