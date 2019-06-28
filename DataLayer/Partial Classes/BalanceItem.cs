using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataLayer {
    public partial class BalanceItem : IEquatable<BalanceItem> {
        private static readonly CultureInfo CultureUS = CultureInfo.CreateSpecificCulture("en-US");
        private static readonly CultureInfo CultureBR = CultureInfo.CreateSpecificCulture("pt-BR");
        private const DateTimeStyles Styles = DateTimeStyles.None;

        public decimal ValorParaSaldo => AfetaSaldo ? Valor : 0.0m;
        public bool AddToDatabase { get; set; }
        public int Centavos => (int)(Valor % 1 * 100);
        //public int Rule { get; set; }

        public string Conta => $"{Account.Apelido} ag. {Account.Agencia} cc {Account.ContaCorrente}";
        public string ContaAbrev => Account.Apelido;
        public string Banco => Account.Bank.Banco;

        public override string ToString() {
            return $"{Data:d}  {Historico}  {Valor:C2}";
        }

        public string Classificacao() {
            var classificacao = new List<string> { Grupo, Categoria };
            if (SubCategoria != null) classificacao.Add(SubCategoria);
            if (Descricao != null) classificacao.Add(Descricao);
            return string.Join("-", classificacao);
        }

        public string Identificacao => $"{ID} {Classificacao()} {Data.ToShortDateString()}";

        #region IEquitable_implementation
        /// <summary>
        /// Compares two BalanceItems
        /// </summary>
        /// <param name="bi"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (!(obj is BalanceItem)) throw new ArgumentException("Object is not a BalanceItem");
            var other = (BalanceItem)obj;
            return this.Equals(other);
        }

        public bool Equals(BalanceItem other) {
            if (other == null)
                return false;
            return this.Data.Equals(other.Data) &&
                   this.Valor.Equals(other.Valor) &&
                   this.Historico.Equals(other.Historico) &&
                   this.AccountID.Equals(other.AccountID) &&
                   (other.Documento == null ? (this.Documento == null || this.Documento.Equals("")) : this.Documento.Equals(other.Documento));
        }

        public bool Similar(BalanceItem other) {
            if (other == null)
                return false;
            return this.AccountID.Equals(other.AccountID) &&
                   this.Data.Equals(other.Data) &&
                   this.Valor.Equals(other.Valor) &&
                   (other.Documento == null ?
                       string.IsNullOrEmpty(this.Documento) :
                       this.Documento.Equals(other.Documento));
        }

        public override int GetHashCode() {
            return this.Historico.GetHashCode();
        }

        public static bool operator ==(BalanceItem bi1, BalanceItem bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return true;
            if (object.ReferenceEquals(bi1, null)) return false;
            return !object.ReferenceEquals(bi2, null) && bi1.Equals(bi2);
        }


        public static bool operator !=(BalanceItem bi1, BalanceItem bi2) {
            if (object.ReferenceEquals(bi1, bi2)) return false;
            if (object.ReferenceEquals(bi1, null)) return true;
            if (object.ReferenceEquals(bi2, null)) return true;
            return !bi1.Equals(bi2);
        }

        public bool FindMatchingRule(List<Rule> rules) {
            return RuleId != 0 || rules.Any(Matches);
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
            Descricao = rule.Descricao;
            if (rule.AfetaSaldo)
                AfetaSaldo = !Historico.StartsWith(@"Depósito bloq", StringComparison.CurrentCultureIgnoreCase);
            else
                AfetaSaldo = rule.AfetaSaldo;
            AddToDatabase = rule.AddToDatabase;  // (Grupo != "Saldo");
            RuleId = rule.ID;
            return true;
        }

        public bool IsSaldo(IEnumerable<Rule> rules) {
            var ruleSaldo = Account.Bank.Rules.FirstOrDefault(r => r.Grupo == "S");
            return (ruleSaldo != null) && Matches(ruleSaldo);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Não é chamado por código mas precisa existir
        /// </summary>
        public BalanceItem() {
            AddToDatabase = true;
        }


        /// <summary>
        /// Creates a BalanceItem from a XML node
        /// </summary>
        /// <param name="xTRNode">XML node</param>
        /// <param name="banco">Bank code</param>
        public BalanceItem(XmlNode xTDNode, int conta) {
            AccountID = conta;
            AfetaSaldo = true;
            Grupo = "";
            Categoria = "";
            SubCategoria = "";
            Descricao = "";
            AddToDatabase = true;
            RuleId = 0;
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
        #endregion

        #region Exporters
        public static string CSVHeader =>
                "\"ID\",\"Conta\",,\"ContaID\"\"Data\",\"Historico\",\"Documento\",\"Valor\",\"AfetaSaldo\",\"Grupo\",\"Categoria\",\"SubCategoria\",\"Descricao\"";

        public string ToCSV =>
                $"\"{ID}\",,\"{Account.Apelido}\"\"{AccountID}\",\"{Data:MM/dd/yyyy}\",\"{Historico}\",\"{Documento}\",\"{Valor.ToString("0.00", CultureUS)}\",\"{AfetaSaldo}\",\"{Grupo}\",\"{Categoria}\",\"{SubCategoria}\",\"{Descricao}\"";
       
        public XElement toXML() {
            return new XElement("BalanceItem",
                new XAttribute("ID", ID),
                new XElement("Conta", Account.Apelido),
                new XElement("ContaID", AccountID),
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
        #endregion
    }

    public static class Extensions {
        public static void CalcularSaldos(this List<BalanceItem> lista, int start) {
            var saldo = start == lista.Count - 1 ? 0.0m : lista[start + 1].Saldo;
            for (var i = start; i >= 0; i--) {
                var bi = lista.ElementAt(i);
                saldo += bi.ValorParaSaldo;
                bi.Saldo = saldo;
            }
        }
    }
}
