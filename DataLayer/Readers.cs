using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DataLayer {
    public static class BalanceFileReader {
        private const string DialogTitle = @"Leitor de Extratos";
        public static List<BalanceItem> Read() {
            var NewItems = new List<BalanceItem>();
            var dlg = new OpenFileDialog {
                Filter = @"Balance Files|*.csv;*.txt;*.xls|All Files|*.*",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = @"Selecione arquivo(s) de extrato:"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return null;

            var includeAll = MessageBox.Show(@"Incluir todos os itens?", DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            foreach (var file in dlg.FileNames) {
                var extrato = new Extrato(file, includeAll);
                if (extrato.HasEntries)
                    NewItems.AddRange(extrato.Entries);
            }

            if (NewItems.Any())
                return NewItems.OrderByDescending(x => x.Data).ToList();
            MessageBox.Show(@"Não há itens para serem importados.", DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }
    }

    public class Extrato {
        private static readonly MoneyBinEntities _ctx = new MoneyBinEntities();
        private readonly Bank _banco;
        private readonly bool _getAll;
        private List<BalanceItem> _entries;

        public List<BalanceItem> Entries => _getAll ? _entries : _entries.Where(i => i.Data.CompareTo(_banco.DataMaxMins.DataMax) >= 0).ToList();
        public bool HasEntries => _entries != null && _entries.Any();

        /// <summary>
        /// Populates BalanceItem list with entries from a file
        /// </summary>
        /// <param name="filepath">Path of the import file</param>
        public Extrato(string filepath, bool getAll) {
            var extension = Path.GetExtension(filepath).ToLower();
            _banco = _ctx.Banks.FirstOrDefault(b => extension.EndsWith(b.Extensao));
            if (_banco == null)
                return;
            _getAll = _banco.DataMaxMins.DataMax == null || getAll;

            if (extension.Equals(".xls")) {
                ExtratoFromXML(filepath);
            }
            else {
                ExtratoFromCSV(filepath);
            }

            ClassificaItens();
            _entries.Reverse();
        }

        private void ClassificaItens() {
            var allRules = _ctx.Rules.ToList();
            var rules = _banco.Rules.OrderByDescending(r => r.Ocorrencias).ToList();
            var rulesSaldo = rules.Where(r => r.Grupo == "S").ToList();
            _entries[0].Saldo = _entries[0].ValorParaSaldo;
            var saldo = _entries[0].FindMatchingRule(rulesSaldo) ? _entries[0].Saldo : 0.0m;

            var start = _entries[0].Rule == 0 ? 0 : 1;
            for (var i = start; i < _entries.Count; i++) {
                _entries[i].FindMatchingRule(rules);
                saldo += _entries[i].ValorParaSaldo;
                _entries[i].Saldo = saldo;
            }

            var MinData = _entries.Min(p => p.Data);
            var MinData2 = _entries.Min(p => p.Data).AddDays(-45);
            var MaxData = _entries.Max(p => p.Data);

            var existing = _banco.Balance
                .Where(bi => bi.Data >= MinData && bi.Data <= MaxData)
                .ToList();

            foreach (var entry in _entries) {
                entry.AddToDatabase = entry.Grupo != "S" && !existing.Any(d => d.Similar(entry));
            }

            var grupos = new[] { "Rio", "Araras" };
            var aCompensar = _banco.Balance.Where(bi => grupos.Contains(bi.Grupo) &&
                                                             bi.Data <= MinData2 &&
                                                             bi.Data >= MaxData).ToList();

            var compensacoes =
                _entries.Where(bi => bi.AddToDatabase &&
                                     bi.Historico.StartsWith("Transferência on line") &&
                                     bi.Historico.EndsWith("AYRTON FRICK") && bi.Valor > 0);

            foreach (var comp in compensacoes) {
                var despesa = aCompensar.FirstOrDefault(ex => Math.Abs(ex.Valor) == comp.Valor);
                if (despesa == null) continue;
                comp.Grupo = "Pessoal";
                comp.Categoria = "Papai";
                comp.SubCategoria = despesa.SubCategoria;
                comp.Descricao = despesa.Descricao;
            }
        }

        private void ExtratoFromCSV(string filepath) {
            using (TextReader reader = new StreamReader(filepath, Encoding.Default)) {
                var csv = new CsvReader(reader);
                csv.Configuration.HasHeaderRecord = true;
                if (_banco.Banco == "BB") {
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.RegisterClassMap<ExtratoBBMap>();
                    csv.Configuration.HeaderValidated = null;
                }
                else {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.RegisterClassMap<ExtratoCEFMap>();
                    csv.Configuration.HeaderValidated = null;
                }

                _entries = csv.GetRecords<BalanceItem>().ToList();
            }
        }

        private void ExtratoFromXML(string filepath) {
            _entries = new List<BalanceItem>();

            var htmlContent = File.ReadAllText(filepath).Replace("Saldo<td>", "Saldo</td>");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root />");

            var rootEle = xmlDoc.DocumentElement;
            rootEle.InnerXml = htmlContent;

            //Get the table node
            var xTableNode = rootEle.SelectSingleNode("html")
                .SelectSingleNode("body").SelectSingleNode("table");

            //Get each row node
            var rows = xTableNode.SelectNodes("tr");
            for (var i = 1; i < rows.Count; i++) {
                var xTDNode = rows[i].SelectNodes("td")[0];
                _entries.Add(new BalanceItem(xTDNode, _banco.Banco));
            }
        }
    }
}
