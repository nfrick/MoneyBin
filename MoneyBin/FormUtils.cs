using DataLayer;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin {
    public static class FormUtils {
        public static int ContaAlteracoes(DbChangeTracker tracker) {
            return tracker.Entries()
                .Count(entry => entry.State == EntityState.Added ||
                                entry.State == EntityState.Deleted ||
                                entry.State == EntityState.Modified);
        }

        public static string TextoSalvar(DbChangeTracker tracker) {
            return TextoSalvar(ContaAlteracoes(tracker));
        }

        public static string TextoSalvar(int alteracoes) {
            return $" Salvar {alteracoes} alteraç" + (alteracoes == 1 ? "ão" : "ões");
        }

        public static DialogResult PerguntaSeSalva(DbChangeTracker tracker, string caption) {
            return PerguntaSeSalva(ContaAlteracoes(tracker), caption);
        }

        public static DialogResult PerguntaSeSalva(int alteracoes, string caption) {
            return MessageBox.Show(TextoSalvar(alteracoes) + @"?", caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static void CalculaSaldos(List<BalanceItem> lista, int start) {
            var saldo = start == lista.Count - 1 ? 0.0m : lista[start + 1].Saldo;
            for (var i = start; i >= 0; i--) {
                var bi = lista.ElementAt(i);
                saldo += bi.ValorParaSaldo;
                bi.Saldo = saldo;
            }
        }

        public static void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            var dgv = (DataGridView)sender;
            var row = dgv.CurrentCell.RowIndex;
            var col = dgv.CurrentCell.ColumnIndex;
            var bi = (BalanceItem)dgv.Rows[row].DataBoundItem;
            var txt = e.Control as TextBox;
            using (var ctx = new MoneyBinEntities()) {
                switch (dgv.Columns[col].HeaderText) {
                    case "Novo Grupo":
                        txt.AutoCompleteCustomSource = 
                            CreateCollection(ctx.Balance.Select(b => b.NovoGrupo).Distinct().ToArray());
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Nova Categoria":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.Balance.Where(b => b.NovoGrupo == bi.NovoGrupo).Select(b => b.NovaCategoria));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Nova SubCategoria":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.Balance.Where(b => b.NovaCategoria == bi.NovaCategoria).Select(b => b.NovaSubCategoria));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    case "Descrição":
                        txt.AutoCompleteCustomSource =
                            CreateCollection(ctx.Balance.Where(b => b.NovaSubCategoria == bi.NovaSubCategoria).Select(b => b.Descricao));
                        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        break;
                    default:
                        txt.AutoCompleteMode = AutoCompleteMode.None;
                        break;
                }
            }
        }

        private static AutoCompleteStringCollection CreateCollection(IEnumerable<string> lista) {
            var source = new AutoCompleteStringCollection();
            source.AddRange(lista.Distinct().Where(a => !string.IsNullOrEmpty(a)).ToArray());
            return source;
        }

    }
}
