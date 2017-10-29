using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataClasses {
    public class BalanceItemOld : IEquatable<BalanceItemOld> {
        public int ID { get; }
        public bool IsNew => (ID == 0);
        public string Banco { get; set; }
        public DateTime Data { get; set; }
        public string Historico { get; set; }
        public string Documento { get; set; }
        public decimal Valor { get; set; }
        public int Centavos => (int)(Valor % 1 * 100);
        public bool AfetaSaldo { get; set; }
        public decimal Saldo { get; set; }
        public string Grupo { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Descricao { get; set; }
        public bool Updated { get; set; }
        public int Rule { get; set; }

        public static decimal SaldoFinal { get; set; }
        private static readonly CultureInfo CultureUS = CultureInfo.CreateSpecificCulture("en-US");
        private static readonly CultureInfo CultureBR = CultureInfo.CreateSpecificCulture("pt-BR");
        private const DateTimeStyles Styles = DateTimeStyles.None;

        public static string CSVHeader() {
            return
                "\"ID\",\"Banco\",\"Data\",\"Historico\",\"Documento\",\"Valor\",\"AfetaSaldo\",\"Grupo\",\"Categoria\",\"SubCategoria\",\"Descricao\"";
        }

        public string ToCSV() {
            return
                $"\"{ID}\",\"{Banco}\",\"{Data:MM/dd/yyyy}\",\"{Historico}\",\"{Documento}\",\"{Valor.ToString("0.00", CultureUS)}\",\"{AfetaSaldo}\",\"{Grupo}\",\"{Categoria}\",\"{SubCategoria}\",\"{Descricao}\"";
        }


        public XElement toXML() {
            return new XElement("BalanceItemOld",
                new XAttribute("ID", ID),
                new XElement("Banco", Banco),
                new XElement("Data", Data.ToString("MM/dd/yyyy")),
                new XElement("Historico", Historico),
                new XElement("Documento", Documento),
                new XElement("Valor", Valor.ToString("0.00", CultureUS)),
                new XElement("AfetaSaldo", AfetaSaldo),
                new XElement("Grupo", Grupo),
                new XElement("Categoria", Categoria),
                new XElement("SubCategoria", SubCategoria),
                new XElement("Descricao", Descricao)
            );
        }

        /// <summary>
        /// Creates a new BalanceItemOld
        /// </summary>
        public BalanceItemOld() {
            Updated = true;
        }

        /// <summary>
        /// Creates a BalanceItemOld from SQL Server database record
        /// </summary>
        /// <param name="r"></param>
        public BalanceItemOld(SqlDataReader r) {
            ID = (int)r["ID"];
            Banco = r["Banco"].ToString();
            Data = (DateTime)r["Data"];
            Historico = r["Historico"].ToString();
            Documento = r["Documento"].ToString();
            Valor = (decimal)r["Valor"];
            AfetaSaldo = (bool)r["AfetaSaldo"];
            Saldo = SaldoFinal;
            SaldoFinal -= AfetaSaldo ? Valor : 0;
            Grupo = r["Grupo"].ToString();
            Categoria = r["Categoria"].ToString();
            SubCategoria = r["SubCategoria"].ToString();
            Descricao = r["Descricao"].ToString();
            Updated = false;
            Rule = 0;
        }


        /// <summary>
        /// Creates a BalanceItemOld from a XML node
        /// </summary>
        /// <param name="xTRNode">XML node</param>
        /// <param name="banco">Bank code</param>
        public BalanceItemOld(XmlNode xTDNode, string banco) {
            Banco = banco;
            AfetaSaldo = true;
            Grupo = "";
            Categoria = "";
            SubCategoria = "";
            Descricao = "";
            Updated = true;
            Rule = 0;
            do {
                string s = xTDNode.InnerText;
                switch (xTDNode.Attributes[0].Value) {
                    case "data":
                        Data = ConvertDate(s, CultureBR);
                        break;
                    case "historico":
                        Historico = TrimAll(s);
                        break;
                    case "documento":
                        Documento = s;
                        break;
                    case "valor":
                        Valor = decimal.Parse(s.ToString(), CultureBR);
                        break;
                    default:
                        break;
                }
                xTDNode = xTDNode.NextSibling.NextSibling;
            } while (xTDNode != null);
        }


        /// <summary>
        /// Compares two BalanceItems
        /// </summary>
        /// <param name="bi"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (!(obj is BalanceItemOld)) throw new ArgumentException("Object is not a BalanceItemOld");
            var other = (BalanceItemOld)obj;
            return this.Equals(other);
        }

        public bool Equals(BalanceItemOld other) {
            if (other == null)
                return false;
            return this.Data.Equals(other.Data) &&
            this.Valor.Equals(other.Valor) &&
            this.Historico.Equals(other.Historico) &&
            this.Banco.Equals(other.Banco) &&
            (other.Documento == null ? (this.Documento == null || this.Documento.Equals("")) : this.Documento.Equals(other.Documento));
        }

        public bool Similar(BalanceItemOld other) {
            if (other == null)
                return false;
            return this.Data.Equals(other.Data) &&
            this.Valor.Equals(other.Valor) &&
            (other.Documento == null ?
            (this.Documento == null || this.Documento.Equals("")) :
            this.Documento.Equals(other.Documento));
        }

        public override int GetHashCode() {
            return this.Historico.GetHashCode();
        }


        public static bool operator ==(BalanceItemOld bi1, BalanceItemOld bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return true;
            if (object.ReferenceEquals(bi1, null)) return false;
            return !object.ReferenceEquals(bi2, null) && bi1.Equals(bi2);
        }


        public static bool operator !=(BalanceItemOld bi1, BalanceItemOld bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return false;
            if (object.ReferenceEquals(bi1, null)) return true;
            if (object.ReferenceEquals(bi2, null)) return true;
            return !bi1.Equals(bi2);
        }


        /// <summary>
        /// Converts string to DateTime
        /// </summary>
        /// <param name="dateString">String containing date</param>
        /// <param name="culture">Culture format used to determine date format</param>
        /// <returns>DateTime</returns>
        private static DateTime ConvertDate(string dateString, CultureInfo culture) {
            DateTime.TryParse(dateString, culture, Styles, out DateTime d);
            return d;
        }


        /// <summary>
        /// Removes all extra spaces from string
        /// </summary>
        /// <param name="sourceString">String with extra spaces</param>
        /// <returns>String</returns>
        private static string TrimAll(string sourceString) {
            char[] sep = { ' ' };
            var splittedString = sourceString.Trim().Split(sep, StringSplitOptions.None);
            var sb = new StringBuilder(sourceString.Trim().Length);
            foreach (var x in splittedString)
                if (x.Length > 0)
                    sb.Append(x).Append(" ");
            return sb.ToString().Trim();
        }

        public bool Matches(Rule r) {
            switch (r.ComparacaoInt()) {
                case Comparacoes.Equals: if (!Historico.Equals(r.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Begins: if (!Historico.StartsWith(r.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Ends: if (!Historico.EndsWith(r.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Contains: if (!Historico.ToLower().Contains(r.Historico.ToLower())) return false; break;
                case Comparacoes.Cents: if (Centavos != r.Centavos) return false; break;
            }
            Grupo = r.Grupo;
            Categoria = r.Categoria;
            SubCategoria = r.SubCategoria;
            Descricao = r.Descricao;
            if (r.AfetaSaldo)
                AfetaSaldo = !Historico.StartsWith(@"Depósito bloq", StringComparison.CurrentCultureIgnoreCase);
            else
                AfetaSaldo = r.AfetaSaldo;
            Updated = (Grupo != "S");
            Rule = r.ID;
            return true;
        }
    }

    public class BalanceItemOldComGrupo : BalanceItemOld {
        public string GrupoNome { get; set; }

        public BalanceItemOldComGrupo(SqlDataReader r) : base(r) {
            GrupoNome = r["GrupoNome"].ToString();
        }
    }
}
