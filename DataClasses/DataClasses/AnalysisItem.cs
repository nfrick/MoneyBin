using System;
using System.Data.SqlClient;

namespace DataClasses {

    public class AnalysisItem {
        public string Ano { get; set; }
        public string Mes { get; set; }
        public string Grupo { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }

        public AnalysisItem(SqlDataReader r) {
            Ano = r["Ano"].ToString();
            Mes = r["Mes"].ToString();
            Grupo = r["Grupo"].ToString();
            Categoria = r["Categoria"].ToString();
            IsNegative = (Convert.ToSByte((decimal)r["Sinal"]) < 0);
            Valor = (decimal)r["Valor"];
        }

        public bool IsPositive => !IsNegative;

        public bool IsNegative { get; }
    }
}
