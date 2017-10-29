using System;
using System.Globalization;
using System.Text;
using System.Xml;

namespace DataLayer {
    public partial class BalanceItemComSaldo : IEquatable<BalanceItemComSaldo> {
        private static readonly CultureInfo CultureUS = CultureInfo.CreateSpecificCulture("en-US");
        private static readonly CultureInfo CultureBR = CultureInfo.CreateSpecificCulture("pt-BR");
        private const DateTimeStyles Styles = DateTimeStyles.None;

        public decimal ValorParaSaldo => AfetaSaldo ? Valor : 0.0m;
        public bool AddToDatabase { get; set; }
        public int Centavos => (int)(Valor % 1 * 100);
        public int Rule { get; set; }

        public BalanceItemComSaldo() {
            AddToDatabase = true;
        }

        #region IEquitable_implementation
        /// <summary>
        /// Compares two BalanceItems
        /// </summary>
        /// <param name="bi"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (!(obj is BalanceItemComSaldo)) throw new ArgumentException("Object is not a BalanceItemComSaldo");
            var other = (BalanceItemComSaldo)obj;
            return this.Equals(other);
        }

        public bool Equals(BalanceItemComSaldo other) {
            if (other == null)
                return false;
            return this.Data.Equals(other.Data) &&
                   this.Valor.Equals(other.Valor) &&
                   this.Historico.Equals(other.Historico) &&
                   this.Banco.Equals(other.Banco) &&
                   (other.Documento == null ? (this.Documento == null || this.Documento.Equals("")) : this.Documento.Equals(other.Documento));
        }

        public bool Similar(BalanceItemComSaldo other) {
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


        public static bool operator ==(BalanceItemComSaldo bi1, BalanceItemComSaldo bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return true;
            if (object.ReferenceEquals(bi1, null)) return false;
            return !object.ReferenceEquals(bi2, null) && bi1.Equals(bi2);
        }


        public static bool operator !=(BalanceItemComSaldo bi1, BalanceItemComSaldo bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return false;
            if (object.ReferenceEquals(bi1, null)) return true;
            if (object.ReferenceEquals(bi2, null)) return true;
            return !bi1.Equals(bi2);
        }

        public bool Matches(Rule rule) {
            switch (rule.ComparacaoAsEnum) {
                case Comparacoes.Equals: if (!Historico.Equals(rule.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Begins: if (!Historico.StartsWith(rule.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Ends: if (!Historico.EndsWith(rule.Historico, StringComparison.CurrentCultureIgnoreCase)) return false; break;
                case Comparacoes.Contains: if (!Historico.ToLower().Contains(rule.Historico.ToLower())) return false; break;
                case Comparacoes.Cents: if (Centavos != rule.Centavos) return false; break;
            }
            Grupo = rule.Grupo;
            Categoria = rule.Categoria;
            SubCategoria = rule.SubCategoria;
            NovoGrupo = rule.NovoGrupo;
            NovaCategoria = rule.Categoria;
            NovaSubCategoria = rule.SubCategoria;
            Descricao = rule.Descricao;
            if (rule.AfetaSaldo)
                AfetaSaldo = !Historico.StartsWith(@"Depósito bloq", StringComparison.CurrentCultureIgnoreCase);
            else
                AfetaSaldo = rule.AfetaSaldo;
            AddToDatabase = (Grupo != "S");
            Rule = rule.ID;
            return true;
        }

        #endregion

        /// <summary>
        /// Creates a BalanceItemOld from a XML node
        /// </summary>
        /// <param name="xTRNode">XML node</param>
        /// <param name="banco">Bank code</param>
        public BalanceItemComSaldo(XmlNode xTDNode, string banco) {
            Banco = banco;
            AfetaSaldo = true;
            Grupo = "";
            Categoria = "";
            SubCategoria = "";
            Descricao = "";
            AddToDatabase = true;
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
    }
}
