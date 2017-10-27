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
using Form = System.Windows.Forms.Form;

namespace MoneyBin {
    public partial class frmExport : Form {
        private delegate bool Exporter();

        public List<BalanceItemOld> Items { get; set; }
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

            else if (radioButtonAcertos.Checked) {
                SetSaveDialog("xlsx", @"Excel Files|*.xlsx");
                _exporter = ExportToAcertos;
            }

            else if (radioButtonExtrato.Checked) {
                SetSaveDialog("accdb", @"Access Files|*.accdb");
                _exporter = ExportToExtrato;
            }
        }

        private void SetSaveDialog(string extension, string filter) {
            saveFileDialog1.DefaultExt = extension;
            saveFileDialog1.Filter = filter;
            if (extension == "accdb") {
                var oneDrivePath = Environment.GetEnvironmentVariable("ONEDRIVE");
                var filepath = oneDrivePath + @"\Documents\Financeiro\Extratos\ExtratosData.accdb";
                while (!File.Exists(filepath)) {
                    filepath = PickFile(oneDrivePath, "ExtratosData.accdb");
                }
                textBoxSaveAs.Text = filepath;
            }
            else if (textBoxSaveAs.Text != string.Empty)
                textBoxSaveAs.Text = Path.ChangeExtension(textBoxSaveAs.Text, extension);
        }

        private void buttonPickFile_Click(object sender, EventArgs e) {
            var fInfo = new FileInfo(textBoxSaveAs.Text);
            saveFileDialog1.InitialDirectory = fInfo.DirectoryName;
            saveFileDialog1.FileName = fInfo.Name;
            textBoxSaveAs.Text = PickFile(fInfo.DirectoryName, fInfo.Name);
        }

        private string PickFile(string path, string file) {
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.FileName = file;
            saveFileDialog1.CheckFileExists = saveFileDialog1.DefaultExt == "accdb";
            saveFileDialog1.OverwritePrompt = saveFileDialog1.DefaultExt != "accdb";
            return saveFileDialog1.ShowDialog() == DialogResult.OK ? saveFileDialog1.FileName : file;
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            if (_exporter())
                MessageBox.Show(@"Data exported.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }

        private bool ExportToCSV() {
            var progressDialog = new frmProgressBar();
            var backgroundThread = new Thread(
                () => {
                    progressDialog.Maximum = Items.Count;
                    progressDialog.UpdateProgress("Exporting \u2026");
                    var sw = new StreamWriter(textBoxSaveAs.Text, false, Encoding.Default);
                    sw.WriteLine(BalanceItemOld.CSVHeader());

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
            return true;
        }

        private bool ExportToXML() {
            try {
                var xEle = new XElement("Balance", Items.Select(b => b.toXML()));
                xEle.Save(textBoxSaveAs.Text);
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool ExportToExcel() {
            return ToExcel(Items);
        }

        private bool ExportToAcertos() {
            return ToExcel(MoneyBinDB.GetAcertoItems());
        }

        private bool ToExcel(ICollection<BalanceItemOld> mItems) {
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
            return true;
        }

        private bool ExportToExtrato() {
            MoneyBinDB.ExportToExtrato(textBoxSaveAs.Text);

            var accessDB = textBoxSaveAs.Text;
            var tempFile = Path.Combine(Path.GetDirectoryName(accessDB),
                Path.GetRandomFileName() + Path.GetExtension(accessDB));

            var app = new Microsoft.Office.Interop.Access.Application {Visible = false};
            app.CompactRepair(accessDB, tempFile, false);
            app.Quit();

            var temp = new FileInfo(tempFile);
            temp.CopyTo(accessDB, true);
            temp.Delete();
            return true;
        }
    }
}
