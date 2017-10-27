using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace DataClasses {
 
    public sealed class ExtratoCEFMap : ClassMap<BalanceItemOld> {
        //"Conta";"Data_Mov";"Nr_Doc";"Historico";"Valor";"Deb_Cred"
        public ExtratoCEFMap() {
            Map(m => m.Banco).Constant("CEF");
            Map(m => m.Data).Index(1).ConvertUsing(row => DateTime.ParseExact(row.GetField<string>(1),
                "yyyyMMdd", CultureInfo.InvariantCulture));
            Map(m => m.Documento).Index(2);
            Map(m => m.Historico).Index(3);
            Map(m => m.Valor).Index(4).ConvertUsing(row =>
                (row.GetField<string>(5) == "D" ? -1 : 1) *
                decimal.Parse(row.GetField<string>(4), new CultureInfo("en-US")));
        }
    }

    public sealed class ExtratoBBMap : ClassMap<BalanceItemOld> {
        //"Data","Dependencia Origem","Histórico","Data do Balancete","Número do documento","Valor",
        public ExtratoBBMap() {
            Map(m => m.Banco).Constant("BB");
            Map(m => m.Data).Index(0).ConvertUsing(row => DateTime.ParseExact(row.GetField<string>(0),
                "MM/dd/yyyy",
                CultureInfo.CurrentUICulture));
            Map(m => m.Historico).Index(2);
            Map(m => m.Documento).Index(4);
            Map(m => m.Valor).Index(5).ConvertUsing(row =>
                decimal.Parse(row.GetField<string>(5), new CultureInfo("en-US")));
        }
    }
}
