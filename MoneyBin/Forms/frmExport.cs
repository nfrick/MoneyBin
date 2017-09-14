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
using OfficeOpenXml.Table;

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
            textBoxSaveAs.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Money Bin Export.csv";
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
        }

        private void ExportToCSV() {
            var progressDialog = new frmProgressBar();
            var backgroundThread = new Thread(
                () => {
                    progressDialog.Maximum = Items.Count();
                    progressDialog.UpdateProgress("Exporting \u2026");
                    var sw = new StreamWriter(textBoxSaveAs.Text, false, Encoding.Default);
                    sw.WriteLine(BalanceItem.CSVHeader());

                    foreach (var item in Items) {
                        progressDialog.UpdateProgress();
                        sw.WriteLine(item.ToCSV());
                    }
                    sw.Flush();
                    sw.Close();

                    progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                }
            );
            backgroundThread.Start();
            progressDialog.ShowDialog();
            MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ExportToAcertos() {
            ToExcel(MoneyBinDB.GetAcertoItems());
        }

        private void ToExcel(ICollection<BalanceItem> mItems) {
            var pck = new ExcelPackage(new FileInfo(textBoxSaveAs.Text));
            var ws = pck.Workbook.Worksheets.Add("Balance");
            ws.View.ShowGridLines = false;

            var col = 1;
            ws.Cells[1, col++].Value = "Banco";
            ws.Cells[1, col++].Value = "Data";
            ws.Cells[1, col++].Value = "Histórico";
            ws.Cells[1, col++].Value = "Documento";
            ws.Cells[1, col++].Value = "Valor";
            ws.Cells[1, col++].Value = "Afeta Saldo";
            // ws.Cells[1, col++].Value = "Saldo";
            ws.Cells[1, col++].Value = "Grupo";
            ws.Cells[1, col++].Value = "Categoria";
            ws.Cells[1, col++].Value = "SubCategoria";
            ws.Cells[1, col++].Value = "Descrição";

            var row = 2;
            foreach (var item in mItems) {
                col = 1;
                ws.Cells[row, col++].Value = item.Banco;
                ws.Cells[row, col++].Value = item.Data;
                ws.Cells[row, col++].Value = item.Historico;
                ws.Cells[row, col++].Value = item.Documento;
                ws.Cells[row, col++].Value = item.Valor;
                ws.Cells[row, col++].Value = item.AfetaSaldo;
                // ws.Cells[row, col++].Value = item.Saldo;
                ws.Cells[row, col++].Value = item.Grupo;
                ws.Cells[row, col++].Value = item.Categoria;
                ws.Cells[row, col++].Value = item.SubCategoria;
                ws.Cells[row++, col++].Value = item.Descricao;
            }

            row--;
            ws.Cells[$"B2:B{row}"].Style.Numberformat.Format = "dd-MM-yyyy";
            ws.Cells[$"D2:D{row}"].Style.Numberformat.Format = "@";
            ws.Cells[$"E2:E{row}"].Style.Numberformat.Format = "#,##0.00";
            // ws.Cells[$"G2:G{row}"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells.AutoFitColumns(0);

            var range = ws.Cells[1, 1, row, col];
            var table = ws.Tables.Add(range, "table1");
            table.ShowTotal = true;
            table.TableStyle = TableStyles.Light1;

            ws.View.FreezePanes(2, 1);

            pck.Save();
            MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
