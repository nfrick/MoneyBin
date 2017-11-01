using DataLayer;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MoneyBin {
    public partial class frmExport : Form {
        private delegate bool Exporter();

        public List<BalanceItemComSaldo> Items { get; set; }
        private Exporter _exporter;

        public frmExport() {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                Items = ctx.BalanceComSaldo.ToList();
            }
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
            SFD.DefaultExt = extension;
            SFD.Filter = filter;
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
            SFD.InitialDirectory = fInfo.DirectoryName;
            SFD.FileName = fInfo.Name;
            textBoxSaveAs.Text = PickFile(fInfo.DirectoryName, fInfo.Name);
        }

        private string PickFile(string path, string file) {
            SFD.InitialDirectory = path;
            SFD.FileName = file;
            SFD.CheckFileExists = SFD.DefaultExt == "accdb";
            SFD.OverwritePrompt = SFD.DefaultExt != "accdb";
            return SFD.ShowDialog() == DialogResult.OK ? SFD.FileName : file;
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
                    sw.WriteLine(BalanceItemComSaldo.CSVHeader());

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
            using (var ctx = new MoneyBinEntities()) {
                return ToExcel(ctx.AcertosPendentes().ToList());
            }
        }

        private bool ToExcel(IEnumerable<BalanceItemComSaldo> mItems) {
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
            ws.Cells[1, col++].Value = "Saldo";
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
                ws.Cells[row, col++].Value = item.Saldo;
                ws.Cells[row, col++].Value = item.NovoGrupo;
                ws.Cells[row, col++].Value = item.NovaCategoria;
                ws.Cells[row, col++].Value = item.NovaSubCategoria;
                ws.Cells[row++, col++].Value = item.Descricao;
            }

            row--;
            col--;
            ws.Cells[$"B2:B{row}"].Style.Numberformat.Format = "dd-MM-yyyy";
            ws.Cells[$"D2:D{row}"].Style.Numberformat.Format = "@";
            ws.Cells[$"E2:E{row}"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells[$"G2:G{row}"].Style.Numberformat.Format = "#,##0.00";
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
            // https://www.aspsnippets.com/Articles/The-OLE-DB-provider-Microsoft.Ace.OLEDB.12.0-for-linked-server-null.aspx
            MoneyBinDB.ExportToExtrato(textBoxSaveAs.Text);
            Thread.Sleep(3000);
            var accessDB = textBoxSaveAs.Text;
            var tempFile = Path.Combine(Path.GetDirectoryName(accessDB),
                Path.GetRandomFileName() + Path.GetExtension(accessDB));
            var app = new Microsoft.Office.Interop.Access.Application { Visible = false };
            try {
                app.CompactRepair(accessDB, tempFile, false);
                var temp = new FileInfo(tempFile);
                temp.CopyTo(accessDB, true);
                temp.Delete();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
            finally {
                app.Quit();
            }
            return true;
        }
    }
}