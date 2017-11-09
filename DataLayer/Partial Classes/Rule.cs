using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public enum Comparacoes {
        Equals,
        Contains,
        Begins,
        Ends,
        Cents
    }
    public partial class Rule
    {
        public override string ToString() => $"{Banco} {ComparacaoAsEnum} {Historico}";
        
        public short Centavos => ComparacaoAsEnum == Comparacoes.Cents ? short.Parse(Historico) : (short)0;

        public Comparacoes ComparacaoAsEnum => (Comparacoes)Comparacao;
    }

    public class Comparacao {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public static List<Comparacao> Lista() {
            return (from Comparacoes c in Enum.GetValues(typeof(Comparacoes)) select new Comparacao() {Descricao = c.ToString(), Id = (int)c}).ToList();
        }
    }
}
