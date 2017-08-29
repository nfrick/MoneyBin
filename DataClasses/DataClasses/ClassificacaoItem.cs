using System.Data.SqlClient;

namespace DataClasses {
    public class ClassificacaoItem {
        public string Grupo { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Descricao { get; set; }

        public ClassificacaoItem(SqlDataReader r) {
            Grupo = r["Grupo"].ToString();
            Categoria = r["Categoria"].ToString();
            SubCategoria = r["SubCategoria"].ToString();
            Descricao = r["Descricao"].ToString();
        }
    }
}
