using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses {

    public enum Comparacoes {
        Equals,
        Contains,
        Begins,
        Ends,
        Cents
    }

    public class Rule {
        private readonly string[] _comps = { "Equals", "Contains", "Begins", "Ends", "Cents" };

        private readonly int _ID;
        public int ID => _ID;
        public bool IsNew => (_ID == 0);
        public string Banco { get; set; }
        public string Historico { get; set; }
        public string Comparacao { get; set; }
        public short Centavos { get; set; }
        public bool AfetaSaldo { get; set; }
        public string Grupo { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Descricao { get; set; }
        public int Ocorrencias { get; set; }
        public bool Updated { get; set; }

        public Rule() {
            _ID = 0;
            Banco = string.Empty;
            Historico = string.Empty;
            Comparacao = "Equals";
            Centavos = 0;
            AfetaSaldo = true;
            Grupo = string.Empty;
            Categoria = string.Empty;
            SubCategoria = string.Empty;
            Descricao = string.Empty;
            Ocorrencias = 0;
            Updated = false;
        }

        public Rule(SqlDataReader r) {
            _ID = (int)r["ID"];
            Banco = r["Banco"].ToString();
            Historico = r["Historico"].ToString();
            Comparacao = _comps[(int)r["Comparacao"]];
            Centavos = Comparacao == "Cents" ? short.Parse(Historico) : (short)0;
            AfetaSaldo = (bool)r["AfetaSaldo"];
            Grupo = r["Grupo"].ToString();
            Categoria = r["Categoria"].ToString();
            SubCategoria = r["SubCategoria"].ToString();
            Descricao = r["Descricao"].ToString();
            Ocorrencias = (int)r["Ocorrencias"];
            Updated = false;
        }

        public Comparacoes ComparacaoInt() {
            return (Comparacoes)Array.IndexOf(_comps, Comparacao);
        }
    }
}
