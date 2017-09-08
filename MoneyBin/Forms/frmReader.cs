using DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmReader : CustomControls.frmBase {
        private readonly List<BalanceItem> _newBalanceItems;
        public bool HasData;

        public frmReader() {
            InitializeComponent();
            _newBalanceItems = BalanceFileReader.Read();
            if (_newBalanceItems == null) {
                Load += (s, e) => Close();
                return;
            }
            HasData = true;
        }

        private void frmReader_Load(object sender, EventArgs e) {
            toolStripButtonLoad.Visible = false;
            toolStripButtonAnalyze.Visible = false;
            toolStripStatusLabelUpdated.Visible = false;
            toolStripStatusLabelDeleted.Visible = false;
            balanceGrid.OnBalanceGridAddedChanged += OnAddedChanged;
            balanceGrid.OnBalanceGridUpdatedChanged += OnUpdatedChanged;
            balanceGrid.Setup(45);

            var bancos = _newBalanceItems.GroupBy(bi => bi.Banco)
                .Select(banco => new {
                    Banco = banco.Key,
                    MaxData = banco.Max(p => p.Data),
                    MinData = banco.Min(p => p.Data)
                });

            foreach (var banco in bancos) {
                var rules = MoneyBinDB.GetRules(banco.Banco);
                foreach (var bi in _newBalanceItems) {
                    foreach (var rule in rules.Where(r => r.Grupo == "S")) {
                        if (bi.Matches(rule))
                            break;
                    }
                    if (bi.Rule != 0) continue;
                    foreach (var rule in rules.Where(r => r.Grupo != "S")) {
                        if (bi.Matches(rule))
                            break;
                    }
                }

                var existing = MoneyBinDB.GetBalanceItems(banco.Banco, banco.MinData, banco.MaxData);   //, "");
                //var repetidos = _newBalanceItems.Where(r => r.Grupo != "S" && existing.Any(d => d.Equals(r)));
                var repetidos = _newBalanceItems.Where(r => r.Grupo != "S" && existing.Any(d => d.Similar(r)));
                foreach (var rep in repetidos)
                    rep.Updated = false;

                var grupos = new[] { "N", "O", "E", "B" };
                var aCompensar = MoneyBinDB.GetBalanceItems(banco.Banco, banco.MinData.AddDays(-45), banco.MaxData) //  , "")
                    .Where(bi => grupos.Contains(bi.Grupo)).ToList();
                var compensacoes = _newBalanceItems.Where(bi => bi.Historico.StartsWith("Transferência on line") &&
                bi.Historico.EndsWith("AYRTON FRICK") && bi.Valor > 0 && bi.Updated);
                foreach (var comp in compensacoes) {
                    var despesa = aCompensar.FirstOrDefault(ex => Math.Abs(ex.Valor) == comp.Valor);
                    if (despesa == null) continue;
                    comp.Grupo = despesa.Grupo == "B" ? "B" : "H";
                    comp.Categoria = despesa.Categoria;
                    comp.SubCategoria = despesa.SubCategoria;
                    comp.Descricao = despesa.Descricao;
                }
            }

            balanceGrid.SetSource(_newBalanceItems, true);
            OnRecordsChanged(_newBalanceItems.Count, null);
            OnAddedChanged(_newBalanceItems.Count(p => p.Updated), null);
        }

        public override void toolStripButtonSave_Click(object sender, EventArgs e) {
            MoneyBinDB.IncrementRules(balanceGrid.BalanceItems);
            balanceGrid.SaveChanges(false);
            this.Close();
        }

        public override void toolStripButtonCategorize_Click(object sender, EventArgs e) {
            balanceGrid.Categorize();
        }

        private void frmReader_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !balanceGrid.SaveChanges(true);
        }
    }
}
