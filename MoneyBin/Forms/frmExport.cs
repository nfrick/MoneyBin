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
        public List<BalanceItem> Items { get; set; }
        public List<BalanceItem> SelectedItems { get; set; }
        public List<DataMaxMin> Banks { get; set; }
        public List<DataMaxMin> SelectedBanks { get; set; }

        private List<string> _gruposChecked;
        private Func<bool> _exporter;
        private string _saveAs;
        private readonly string _myDocsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string _oneDriveFolder = Environment.GetEnvironmentVariable("ONEDRIVE");
        private readonly DateTime _lastExportDate = Properties.Settings.Default.LastExport;
        public frmExport() {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                Items = ctx.Balance.ToList();
                Banks = ctx.DataMaxsMins.OrderBy(b => b.Banco).ToList();
                dtpAcertoInicio.Value = ctx.UltimoAcerto().FirstOrDefault() ?? DateTime.Now;
            }
            foreach (var b in Banks) {
                var i = checkedListBoxBancos.Items.Add(b.Banco);
                checkedListBoxBancos.SetItemChecked(i, true);
            }

            _saveAs = $@"{_myDocsFolder}\Money Bin Export.csv";
            radioButtonCSV.Checked = true;
        }

        private void checkedListBoxBancos_ItemCheck(object sender, ItemCheckEventArgs e) {
            var bancosChecked = checkedListBoxBancos.CheckedItems.Cast<string>().ToList();
            var curItem = checkedListBoxBancos.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked) {
                bancosChecked.Add(curItem);
            }
            else {
                bancosChecked.Remove(curItem);
            }

            SelectedBanks = Banks.Where(b => bancosChecked.Contains(b.Banco)).ToList();
            buttonExport.Enabled = SelectedBanks.Any();
            dtpInicio.Enabled = dtpTermino.Enabled =
                checkedListBoxGrupos.Enabled = buttonExport.Enabled;
            if (!buttonExport.Enabled) {
                SelecionaParaExportar();
                return;
            }
            dtpInicio.MinDate = dtpTermino.MinDate = SelectedBanks.Min(b => b.DataMin);
            dtpInicio.MaxDate = dtpTermino.MaxDate = SelectedBanks.Max(b => b.DataMax);
            dtpInicio.Value = dtpInicio.MinDate;
            dtpTermino.Value = dtpTermino.MaxDate;
            SelecionaParaExportar();
        }

        private void AtualizaGrupos() {
            var bancos = SelectedBanks.Select(b => b.Banco).ToArray();
            checkedListBoxGrupos.Items.Clear();
            checkedListBoxGrupos.Items.AddRange(Items
                .Where(b => bancos.Contains(b.Banco) &&
                            b.Data >= dtpInicio.Value && b.Data <= dtpTermino.Value)
                .GroupBy(b => b.Grupo)
                .Select(g => $"{g.Key} ({g.Count()})")
                .OrderBy(b => b).ToArray());

            for (var i = 0; i < checkedListBoxGrupos.Items.Count; i++) {
                checkedListBoxGrupos.SetItemChecked(i, true);
            }
        }

        private void dtpickers_ValueChanged(object sender, EventArgs e) {
            AtualizaGrupos();
            SelecionaParaExportar();
        }

        private void SelecionaParaExportar() {
            var bancos = SelectedBanks.Select(b => b.Banco).ToArray();
            SelectedItems = Items
                .Where(b => bancos.Contains(b.Banco) &&
                b.Data >= dtpInicio.Value && b.Data <= dtpTermino.Value &&
                _gruposChecked.Contains(b.Grupo)).ToList();
            labelCount.Text = $"Registros a serem exportados: {SelectedItems.Count}";
            buttonExport.Enabled = SelectedItems.Any();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e) {
            var chk = sender as RadioButton;
            if (!chk.Checked) {
                return;
            }

            dtpAcertoInicio.Enabled = radioButtonAcertos.Checked;
            groupBoxCriteria.Enabled = !radioButtonAcertos.Checked;
            if (radioButtonCSV.Checked) {
                SetSaveDialog("Money Bin Export", "csv", @"CSV Files|*.csv");
                _exporter = ExportToCSV;
            }

            else if (radioButtonXML.Checked) {
                SetSaveDialog("Money Bin Export", "xml", @"XML Files|*.xml");
                _exporter = ExportToXML;
            }

            else if (radioButtonExcel.Checked) {
                SetSaveDialog("Money Bin Export", "xlsx", @"Excel Files|*.xlsx");
                _exporter = ExportToExcel;
            }

            else if (radioButtonAcertos.Checked) {
                SetSaveDialog("Acertos Pendentes", "xlsx", @"Excel Files|*.xlsx");
                _exporter = ExportToAcertos;
            }

            else if (radioButtonExtrato.Checked) {
                SetSaveDialog("Extratos", "accdb", @"Access Files|*.accdb");
                _exporter = ExportToExtrato;
            }
        }

        private void SetSaveDialog(string filename, string extension, string filter) {
            SFD.DefaultExt = extension;
            SFD.Filter = filter;
            _saveAs = extension == "accdb" ?
                $@"{_oneDriveFolder}\Documents\Financeiro\Extratos\{filename}.{extension}" :
                $@"{_myDocsFolder}\{filename}.{extension}";
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            var fInfo = new FileInfo(_saveAs);
            SFD.InitialDirectory = fInfo.DirectoryName;
            SFD.FileName = fInfo.Name;
            SFD.CheckFileExists = SFD.DefaultExt == "accdb";
            SFD.OverwritePrompt = SFD.DefaultExt != "accdb";

            if (fInfo.Extension == "accdb") {
                do {
                    if (SFD.ShowDialog() != DialogResult.OK) {
                        return;
                    }

                    _saveAs = SFD.FileName;
                } while (!File.Exists(_saveAs));
            }
            else {
                if (SFD.ShowDialog() != DialogResult.OK) {
                    return;
                }
            }

            _saveAs = SFD.FileName;
            Cursor.Current = Cursors.WaitCursor;
            if (_exporter()) {
                MessageBox.Show($@"{SelectedItems.Count} registros exportados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }

        private bool ExportToCSV() {
            var progressDialog = new frmProgressBar();
            var backgroundThread = new Thread(
                () => {
                    progressDialog.Maximum = SelectedItems.Count;
                    progressDialog.UpdateProgress("Exportando \u2026");
                    var sw = new StreamWriter(_saveAs, false, Encoding.Default);
                    sw.WriteLine(BalanceItem.CSVHeader());

                    foreach (var item in SelectedItems) {
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
                var xEle = new XElement("Balance", SelectedItems.Select(b => b.toXML()));
                xEle.Save(_saveAs);
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool ExportToExcel() {
            return ToExcel(SelectedItems);
        }

        private bool ExportToAcertos() {
            using (var ctx = new MoneyBinEntities()) {
                return ToExcel(ctx.AcertosPendentes(dtpAcertoInicio.Value).ToList());
            }
        }

        private bool ToExcel(IEnumerable<BalanceItem> mItems) {
            if (!mItems.Any()) {
                MessageBox.Show(@"Não há registros para serem exportados.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var pck = new ExcelPackage(new FileInfo(_saveAs));
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
                ws.Cells[row, col++].Value = item.Grupo;
                ws.Cells[row, col++].Value = item.Categoria;
                ws.Cells[row, col++].Value = item.SubCategoria;
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
            var retorno = true;
            //using (var ctx = new MoneyBinEntities()) {
            //    ctx.sp_ExportToExtrato(_saveAs);
            //}

            MoneyBinDB.ExportToExtrato(_saveAs);

            var tempFile = Path.Combine(Path.GetDirectoryName(_saveAs),
                Path.GetRandomFileName() + Path.GetExtension(_saveAs));
            var app = new Microsoft.Office.Interop.Access.Application { Visible = false };
            try {
                app.CompactRepair(_saveAs, tempFile, false);
                var temp = new FileInfo(tempFile);
                temp.CopyTo(_saveAs, true);
                temp.Delete();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
                //throw;
            }
            finally {
                app.Quit();
            }
            return retorno;
        }

        private void buttonSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void checkedListBoxGrupos_ItemCheck(object sender, ItemCheckEventArgs e) {
            _gruposChecked = checkedListBoxGrupos.CheckedItems.Cast<string>()
                .Select(g => g.Substring(0, g.IndexOf(" ("))).ToList();

            var curItem = checkedListBoxGrupos.Items[e.Index].ToString();
            curItem = curItem.Substring(0, curItem.IndexOf(" ("));
            if (e.NewValue == CheckState.Checked) {
                _gruposChecked.Add(curItem);
            }
            else {
                _gruposChecked.Remove(curItem);
            }

            SelecionaParaExportar();
        }

        private void label1_Click(object sender, EventArgs e) {
            if (_lastExportDate.Year == 1) return;
            dtpInicio.Value = (dtpInicio.Value == dtpInicio.MinDate) ?
                _lastExportDate : dtpInicio.MinDate;
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.LastExport = dtpTermino.Value;
            Properties.Settings.Default.Save();
        }
    }
}