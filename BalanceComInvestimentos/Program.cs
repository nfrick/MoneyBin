using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceComInvestimentos {
    class Program {
        static void Main(string[] args) {
            using (var ctx1 = new Investimentos2Entities()) {
                using (var ctx2 = new MoneyBinEntities()) {
                    var balanceItems = ctx2.Balance.Where(b => b.Grupo == "I" &&
                                                       (b.Categoria == "Compra" || b.Categoria == "Venda") && b.SubCategoria == "Ações").ToList();
                    foreach (var bi in balanceItems) {
                        var inicio = bi.Data.AddDays(-7);
                        var termino = bi.Data.AddDays(-2);
                        var ops = ctx1.Operacoes.Where(o => o.Data >= inicio && o.Data <= termino &&
                                                            o.QtdReal / Math.Abs(o.QtdReal) == o.tbOperacoesTipos.Sinal).OrderByDescending(o => o.Data).ToList();
                        Console.WriteLine($"\n{bi.Data:d}  {bi.Historico}  {bi.Valor:N2}\t\t{ops.Sum(o => o.ValorReal * o.QtdReal):N2}\t{bi.Categoria}\t{bi.SubCategoria}\t{bi.Descricao}");
                        foreach (var op in ops) {
                            Console.WriteLine($"\t{op.Data:d}\t{op.Codigo}\t{op.QtdReal}\t{op.ValorReal}\t{op.ValorReal * op.QtdReal:N2}");
                        }
                        var sum = Math.Abs(bi.Valor);
                        var SubCat = new List<string>();
                        var Desc = new List<string>();
                        foreach (var op in ops) {
                            if(!SubCat.Contains(op.Codigo)) SubCat.Add(op.Codigo);
                            Desc.Add($"{op.QtdReal} {op.Codigo} a {op.ValorReal:N2}");
                            sum -= Math.Abs(op.ValorReal * op.QtdReal);
                            if (sum == 0) break;
                        }
                        const string del = ", ";
                        var s = string.Join(del, SubCat);
                        var d = string.Join(del, Desc);
                        Console.WriteLine($"{s} {d}");
                        //bi.SubCategoria = s;
                        //bi.Descricao = d;
                    }
                    //ctx2.SaveChanges();
                }
            }
            Console.ReadLine();
        }
    }
}
