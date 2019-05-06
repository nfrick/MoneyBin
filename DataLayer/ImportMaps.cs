using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataLayer {
    public sealed class ExtratoBBMap : ClassMap<BalanceItem> {
        private static string DataFormato { get; set; } = "dd/MM/yyyy";
        //"Data","Dependencia Origem","Histórico","Data do Balancete","Número do documento","Valor",
        public ExtratoBBMap() {
            Map(m => m.Banco).Index(1).Constant(@"BB");
            Map(m => m.Data).Name("Data").Index(0)
                .ConvertUsing(row => DateTime.ParseExact(row.GetField<string>(0),
                DataFormato, CultureInfo.CurrentUICulture));
            Map(m => m.Historico).Name("Histórico").Index(2);
            Map(m => m.Documento).Name("Número do documento").Index(4);
            Map(m => m.Valor).Name("Valor").Index(5).ConvertUsing(row =>
                decimal.Parse(row.GetField<string>(5), new CultureInfo("en-US")));
            Map(m => m.AfetaSaldo).Index(3).Constant(true);
        }

        public static void DefineFormatoData(string path) {
            // https://stackoverflow.com/questions/32387274/retrieve-list-of-possible-datetime-formats-from-string-value
            var linhas = File.ReadLines(path);
            var data = linhas.ElementAt(1).Split(new[] { ',' })[0].Replace("\"", "");
            // Procura separadores
            var sep = data.FirstOrDefault(c => !char.IsDigit(c));
            var sep1 = sep == '\0' ? string.Empty : "" + sep;
            var formatos = new[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd" };
            for(var i = 0; i < formatos.Length; i++)
                formatos[i] = formatos[i].Replace("/", sep1);
            DataFormato = formatos
                .FirstOrDefault(format => DateTime.TryParseExact(data, format, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var ignored));
        }
    }

    public sealed class ExtratoCEFMap : ClassMap<BalanceItem> {
        private static string DataFormato { get; set; } = "dd/MM/yyyy";

        //"Conta";"Data_Mov";"Nr_Doc";"Historico";"Valor";"Deb_Cred"
        public ExtratoCEFMap() {
            Map(m => m.Banco).Index(0).Constant("CEF");
            Map(m => m.Data).Index(1).ConvertUsing(row => DateTime.ParseExact(row.GetField<string>(1),
                "yyyyMMdd", CultureInfo.InvariantCulture));
            Map(m => m.Documento).Index(2);
            Map(m => m.Historico).Index(3);
            Map(m => m.Valor).Index(4).ConvertUsing(row =>
                (row.GetField<string>(5) == "D" ? -1 : 1) *
                decimal.Parse(row.GetField<string>(4), new CultureInfo("en-US")));
        }

        public static void DefineFormatoData(string path) {
            // https://stackoverflow.com/questions/32387274/retrieve-list-of-possible-datetime-formats-from-string-value
            var linhas = File.ReadLines(path);
            var data = linhas.ElementAt(1).Split(new[] { ';' })[1].Replace("\"", "");
            // Procura separadores
            var sep = data.FirstOrDefault(c => !char.IsDigit(c));
            var sep1 = sep == '\0' ? string.Empty : "" + sep;
            var formatos = new[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd" };
            for (var i = 0; i < formatos.Length; i++)
                formatos[i] = formatos[i].Replace("/", sep1);
            DataFormato = formatos
                .FirstOrDefault(format => DateTime.TryParseExact(data, format, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var ignored));
        }
    }
}
