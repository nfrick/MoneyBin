using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CsvHelper;

namespace DataClasses {
    public static class BalanceFileReader {
        public static List<BalanceItemOld> Read() {
            var NewItems = new List<BalanceItemOld>();
            var dlg = new OpenFileDialog {
                Filter = @"Balance Files|*.csv;*.txt;*.xls|All Files|*.*",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = @"Select Balance file(s):"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return null;

            var includeAll = MessageBox.Show(@"Incluir todos os itens?", @"New Reader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            foreach (var f in dlg.FileNames) {
                var extrato = new Extrato(f);
                NewItems.AddRange(extrato.GetEntries(includeAll));
            }
            if (NewItems.Any())
                return NewItems.OrderByDescending(x => x.Data).ToList();
            MessageBox.Show(@"Não há itens para serem importados.", @"Reader", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }
    }

    public class Extrato {
        private List<BalanceItemOld> _extratoItems; // = new List<BalanceItemOld>();

        public string Banco { get; }

        /// <summary>
        /// Populates the BalanceItemOld list with entries from a file
        /// </summary>
        /// <param name="filepath">Path of the import file</param>
        public Extrato(string filepath) {
            var extension = Path.GetExtension(filepath).ToLower();
            if (extension.Equals(".xls")) {
                Banco = "STD";
                ExtratoFromXML(filepath);
            }
            else {
                Banco = extension.Equals(".csv") ? "BB" : "CEF";
                ExtratoFromCSV(filepath);
            }

            var firstBI = _extratoItems.ElementAt(0);
            if (firstBI.Historico.ToUpper() == "SALDO ANTERIOR")
                firstBI.Saldo = firstBI.Valor;
            _extratoItems.Reverse();
        }

        private void ExtratoFromCSV(string filepath) {
            using (TextReader reader = new StreamReader(filepath, Encoding.Default)) {
                var csv = new CsvReader(reader);
                csv.Configuration.HasHeaderRecord = true;
                if (Banco == "BB") {
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.RegisterClassMap<ExtratoBBMap>();
                }
                else {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.RegisterClassMap<ExtratoCEFMap>();
                }

                _extratoItems = csv.GetRecords<BalanceItemOld>().ToList();
            }
        }

        private void ExtratoFromXML(string filepath) {
            _extratoItems = new List<BalanceItemOld>();

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
                _extratoItems.Add(new BalanceItemOld(xTDNode, Banco));
            }
        }

        /// <summary>
        /// Returns list of entries in Extrato
        /// </summary>
        /// <returns>List<BalanceItemOld></returns>
        public List<BalanceItemOld> GetEntries(bool getAll) {
            return getAll ? 
                _extratoItems : 
                _extratoItems.Where(n => n.Data.CompareTo(MoneyBinDB.GetDataMax(Banco)) >= 0).ToList();
        }
    }
}

