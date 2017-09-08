using DataClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using OfficeOpenXml;

namespace MoneyBin {
    public partial class frmExport : Form {
        private delegate void Exporter();

        public List<BalanceItem> Items { get; set; }
        private Exporter _exporter;

        public frmExport() {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e) {
            Items = Items ?? MoneyBinDB.GetBalanceItems();
            textBoxSaveAs.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\\Money Bin Export.csv";
            radioButtonCSV.Checked = true;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e) {
            var chk = sender as RadioButton;
            if (!chk.Checked) return;
            if (radioButtonCSV.Checked) {
                SetSaveDialog("csv", @"CSV Files|*.csv");
                _exporter = ExportToCSV;
            }

            else if (radioButtonXML.Checked) {
                SetSaveDialog("xml", @"XML Files|*.xml");
                _exporter = ExportToXML;
            }

            else if (radioButtonExcel.Checked) {
                SetSaveDialog("xlsx", @"Excel Files|*.xlsx");
                _exporter = ExportToExcel;
            }

            else {
                SetSaveDialog("xlsx", @"Excel Files|*.xlsx");
                _exporter = ExportToAcertos;
            }

        }

        private void SetSaveDialog(string extension, string filter) {
            saveFileDialog1.DefaultExt = extension;
            saveFileDialog1.Filter = filter;
            if (textBoxSaveAs.Text != string.Empty)
                textBoxSaveAs.Text = Path.ChangeExtension(textBoxSaveAs.Text, extension);
        }

        private void buttonPickFile_Click(object sender, EventArgs e) {
            var fInfo = new FileInfo(textBoxSaveAs.Text);
            saveFileDialog1.InitialDirectory = fInfo.DirectoryName;
            saveFileDialog1.FileName = fInfo.Name;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                textBoxSaveAs.Text = saveFileDialog1.FileName;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            _exporter();
            progressBar1.Visible = false;
            labelMid.Visible = false;
            labelMax.Visible = false;
        }

        private void SetProgressBar(int count) {
            progressBar1.Maximum = count;
            progressBar1.Visible = true;
            labelMid.Text = (count / 2).ToString();
            labelMid.Visible = true;
            labelMax.Text = count.ToString();
            labelMax.Visible = true;
        }

        private void ExportToCSV() {
            SetProgressBar(Items.Count);
            var backgroundThread = new Thread(
                () => {
                    var sw = new StreamWriter(textBoxSaveAs.Text, false, Encoding.Default);
                    sw.WriteLine(BalanceItem.CSVHeader());
                    foreach (var item in Items) {
                        sw.WriteLine(item.ToCSV());
                        progressBar1.BeginInvoke(
                            new Action(() => {
                                progressBar1.Increment(1);
                            }
                            ));
                    }
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.BeginInvoke(
                        new Action(() => {
                            progressBar1.Value = 0;
                        }
                        ));
                });
            backgroundThread.Start();
        }

        private void ExportToXML() {
            try {
                var xEle = new XElement("Balance", Items.Select(b => b.toXML()));
                xEle.Save(textBoxSaveAs.Text);
                MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExportToExcel() {
            ToExcel(Items);
        }

        private void ToExcel(IEnumerable<BalanceItem> mItems) {
            SetProgressBar(Items.Count);
            var pck = new ExcelPackage(new FileInfo(textBoxSaveAs.Text));
            var ws = pck.Workbook.Worksheets.Add("Balance");
            ws.View.ShowGridLines = false;
            ws.Cells["A1"].Value = "Banco";
            ws.Cells["B1"].Value = "Data";
            ws.Cells["C1"].Value = "Historico";
            ws.Cells["D1"].Value = "Documento";
            ws.Cells["E1"].Value = "Valor";
            ws.Cells["F1"].Value = "AfetaSaldo";
            ws.Cells["G1"].Value = "Saldo";
            ws.Cells["H1"].Value = "Grupo";
            ws.Cells["I1"].Value = "Categoria";
            ws.Cells["J1"].Value = "SubCategoria";
            ws.Cells["K1"].Value = "Descricao";

            var row = 2;
            foreach (var item in mItems) {
                var col = 1;
                progressBar1.Value = row - 1;
                ws.Cells[row, col++].Value = item.Banco;
                ws.Cells[row, col++].Value = item.Data;
                ws.Cells[row, col++].Value = item.Historico;
                ws.Cells[row, col++].Value = item.Documento;
                ws.Cells[row, col++].Value = item.Valor;
                ws.Cells[row, col++].Value = item.AfetaSaldo;
                ws.Cells[row, col++].Value = item.Saldo;
                ws.Cells[row, col++].Value = item.Grupo;
                ws.Cells[row, col++].Value = item.Categoria;
                ws.Cells[row, col++].Value = item.SubCategoria;
                ws.Cells[row++, col++].Value = item.Descricao;
            }
            ws.Cells.AutoFitColumns(0);
            pck.Save();
            MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToAcertos() {
            ToExcel(MoneyBinDB.GetAcertoItems());
        }
    }
}
