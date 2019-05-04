using System;
using System.Globalization;
using System.Linq;
using Toxy;
using Toxy.Parsers;

namespace DataLayer {
    public class ComprovantePDF {
        public string Texto { get; protected set; }

        public string TextoToDisplay => Texto.Replace("\n", Environment.NewLine);

        private readonly string[] _textAsArray;
        public DateTime Agendamento { get; protected set; }
        public DateTime Pagamento { get; protected set; }
        public decimal Valor { get; protected set; }

        public string AgendamentoDisplay => Agendamento.Year > 2000 ? Agendamento.ToString("dd/MM/yyyy hh:mm") : "NÃO ENCONTRADO";
        public string PagamentoDisplay => Pagamento.Year > 2000 ? Pagamento.ToString("dd/MM/yyyy hh:mm") : "NÃO ENCONTRADO";
        public string ValorDisplay => Valor > 0 ? Valor.ToString("N2") : "NÃO ENCONTRADO";

        public bool DadosOK => Agendamento.Year > 2000 && Pagamento.Year > 2000 && Valor > 0;

        protected static char[] _blank = new[] { ' ', ' ' }; // o 2º char não é espaço, é o sep no PDF da Caixa
        protected static char[] _newline = new[] { '\n' };
        protected static char[] _dash = new[] { '-' };

        public ComprovantePDF(string path) {
            var parser = new PDFTextParser(new ParserContext(path));
            Texto = parser.Parse();
            try {
                _textAsArray = Texto.Split(_newline).Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r))
                    .ToArray();
                if (_textAsArray.First() == "Comprovante") {
                    LerTransferencia();
                }
                else {
                    LerPagamento();
                }
            }
            catch {

            }
            finally {
                if (!DadosOK) {
                    var data = System.IO.Path.GetFileName(path).Substring(0, 10);
                    var DataArquivo = DateTime.ParseExact(data, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture);
                    Agendamento = Agendamento.Year > 2000 ? Agendamento : DataArquivo;
                    Pagamento = Pagamento.Year > 2000 ? Pagamento : DataArquivo;
                    Valor = Valor == 0 ? 1 : Valor;
                }
            }
        }

        private void LerPagamento() {
            string[] temp;
            DateTime d;
            // Pagamntos normais começam com SISBB, boletos começam com a data
            if (_textAsArray[0].EndsWith("caixa", StringComparison.CurrentCultureIgnoreCase)) {
                if (GetLine("Data/hora da operação", _blank, out temp)) {
                    if (DateTime.TryParse($"{temp.Take(temp.Length - 1).Last()} {temp.Last()}", out d)) {
                        Agendamento = d;
                    }
                }

                if (GetLine("Data de débito", _blank, out temp)) {
                    if (DateTime.TryParse(temp.Last(), out d)) {
                        Pagamento = d;
                    }
                }

            }
            else {
                temp = _textAsArray[0].StartsWith("SISBB")
                    ? _textAsArray[1].Split(_blank)
                    : _textAsArray[0].Split(_blank);
                if (DateTime.TryParse(temp.First() + " " + temp.Last().Replace(".", ":"), out d)) {
                    Agendamento = d;
                }

                if (GetLine("DATA DO PAGAMENTO", _blank, out temp)) {
                    if (DateTime.TryParse(temp.Last(), out d)) {
                        Pagamento = d;
                    }
                }
                else if (GetLine("DATA", _blank, out temp)) {  // Para transferências não agendadas
                    if (DateTime.TryParse(temp.Last(), out d)) {
                        Pagamento = d;
                    }
                }
            }
            if (GetLine("VALOR", _blank, out temp)) {
                if (decimal.TryParse(temp.Last(), out var v)) {
                    Valor = v;
                }
            }
        }

        private void LerTransferencia() {
            string[] temp;
            DateTime d;
            if (GetLine("SISBB", _dash, out temp)) {
                if (DateTime.TryParse(temp[2] + " " + temp[4], out d)) {
                    Agendamento = d;
                }
            }

            if (GetLine("Data", _blank, out temp)) {
                Pagamento = DateTime.TryParse(temp[1], out d) ? d : Agendamento;
                if (Pagamento == null) {
                    Pagamento = DateTime.TryParse(temp.Last(), out d) ? d : Agendamento;
                }
            }

            if (decimal.TryParse(temp.Last(), out var v)) {
                Valor = v;
            }
            else if (GetLine("Valor", _blank, out temp)) {
                if (decimal.TryParse(temp.Last(), out v)) {
                    Valor = v;
                }
            }
        }

        private bool GetLine(string text, char[] sep, out string[] retValue) {
            var row = _textAsArray.FirstOrDefault(r => r.StartsWith(text, StringComparison.InvariantCultureIgnoreCase));
            if (row == null) {
                retValue = null;
                return false;
            }
            retValue = row.Split(sep).Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r)).ToArray();
            return true;
        }
    }
}