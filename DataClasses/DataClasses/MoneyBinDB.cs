using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DataClasses {
    public class MoneyBinDB {
        private static void ShowError(string function, Exception ex) {
            MessageBox.Show($"Erro em {function}:\n\nTipo: {ex.GetType()}\n\nMensagem: {ex.Message}.",
                "Erro ao acessar banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Adjusts and returns connection string according to computer
        /// </summary>
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TygerDell"].ToString();

        /// <summary>
        /// Returns an opened connection object to Access DB
        /// </summary>
        /// <returns>OleDbConnection conn</returns>
        public static SqlConnection GetConnection() {
            try {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetConnection()\nString: " + ConnectionString, ex);
                return null;
            }
        }


        /// <summary>
        /// Returns a list of Grupo-Categoria tuples for all Banks
        /// </summary>
        /// <returns></returns>
        public static List<Tuple2Levels> GetGruposCategorias() {
            return GetGruposCategorias(null, null, null);
        }

        /// <summary>
        /// Returns a list of Grupo-Categoria tuples for a given Banc between 2 dates
        /// </summary>
        /// <param name="banco"></param>
        /// <param name="inicio"></param>
        /// <param name="termino"></param>
        /// <returns></returns>
        public static List<Tuple2Levels> GetGruposCategorias(string banco, DateTime? inicio, DateTime? termino) {
            try {
                var items = new List<Tuple2Levels>();
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_GruposCategorias", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                    cmd.Parameters.Add(new SqlParameter("@Inicio", inicio));
                    cmd.Parameters.Add(new SqlParameter("@Termino", termino));
                    var r = cmd.ExecuteReader();
                    while (r.Read()) {
                        items.Add(new Tuple2Levels(r, "Grupo", "Categoria"));
                    }
                    r.Close();
                    return items;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetGruposCategorias(Banco, Inicio, Termino)", ex);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all existing Classificacao (Grupo-Categoria-SubCategoria-Descrição)
        /// </summary>
        /// <returns></returns>
        public static List<ClassificacaoItem> GetClassificacao() {
            try {
                var items = new List<ClassificacaoItem>();
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_Classificacao", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        items.Add(new ClassificacaoItem(reader));
                    }
                    reader.Close();
                    return items;
                }
            }
            catch (Exception ex) {
                ShowError("@MoneyBin.GetClassificacao()\nString: " + ConnectionString + "\n", ex);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all Ano-Mes tuples for a given Bank
        /// </summary>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static List<Tuple2Levels> GetAnosMeses(string banco) {
            try {
                var meses = new List<Tuple2Levels>();
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_AnosMeses", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        meses.Add(new Tuple2Levels(reader, "Ano", "Mes"));
                    }
                    reader.Close();
                    return meses;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetAnosMeses()", ex);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of BalanceItems for a given Bank, between two dates and optional GrupoCategoria
        /// </summary>
        /// <param name="banco"></param>
        /// <param name="inicio"></param>
        /// <param name="termino"></param>
        /// <param name="grupoCategoria"></param>
        /// <returns></returns>
        public static List<BalanceItem> GetBalanceItems(string banco, DateTime inicio, DateTime termino, string grupoCategoria) {
            try {
                var items = new List<BalanceItem>();

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand { Connection = conn };
                    var cmdSaldo = new SqlCommand { Connection = conn };
                    if (grupoCategoria.Equals("")) {
                        cmdSaldo.CommandText = "sp_GetSaldo";
                        cmdSaldo.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdSaldo.Parameters.Add(new SqlParameter("@Banco", banco));
                        cmdSaldo.Parameters.Add(new SqlParameter("@Data", termino));

                        cmd.CommandText = "sp_BalanceItems";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                        cmd.Parameters.Add(new SqlParameter("@Inicio", inicio));
                        cmd.Parameters.Add(new SqlParameter("@Termino", termino));
                    }
                    else {
                        cmdSaldo.CommandText =
                            $@"SELECT COALESCE(SUM(Valor),0) AS Total FROM tblBalance WHERE Banco = '{banco}' AND Data <= '{termino:yyyy-MM-dd}' AND AfetaSaldo = 1 AND ({grupoCategoria})";
                        cmdSaldo.CommandType = System.Data.CommandType.Text;

                        cmd.CommandText =
                            $@"SELECT tblBalance.*, tblGroups.Descricao AS GrupoNome FROM tblBalance 
                            INNER JOIN tblGroups ON tblBalance.Grupo = tblGroups.GrupoID 
                            WHERE (Banco = '{banco}') AND 
                                (Data BETWEEN '{inicio:yyyy-MM-dd}' AND
                                '{termino:yyyy-MM-dd}') AND ({grupoCategoria}) 
                            ORDER BY Data DESC, Valor ASC";
                        cmd.CommandType = System.Data.CommandType.Text;
                    }
                    BalanceItem.SaldoFinal = (decimal)cmdSaldo.ExecuteScalar();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        items.Add(new BalanceItemComGrupo(reader));
                    }
                    reader.Close();
                    return items;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetBalanceItems()", ex);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all BalanceItems
        /// </summary>
        /// <returns></returns>
        public static List<BalanceItem> GetBalanceItems() {
            try {
                var items = new List<BalanceItem>();

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand {
                        Connection = conn,
                        CommandText = "sp_BalanceItems",
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        items.Add(new BalanceItem(reader));
                    }
                    reader.Close();
                    return items;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetBalanceItems()", ex);
                return null;
            }
        }

        /// <summary>
        /// Insert or Update edited BalanceItems
        /// </summary>
        /// <param name="items">List of BalanceItems</param>
        /// <returns>true if sucessful</returns>
        public static bool UpdateBalanceItems(List<BalanceItem> items) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("to be defined", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var item in items) {
                        if (item.IsNew) {
                            cmd.CommandText = "sp_BalanceItemInsert";
                            cmd.Parameters.Add(new SqlParameter("@Banco", item.Banco));
                            cmd.Parameters.Add(new SqlParameter("@Data", item.Data));
                            cmd.Parameters.Add(new SqlParameter("@Historico", item.Historico));
                            cmd.Parameters.Add(new SqlParameter("@Documento", item.Documento));
                            cmd.Parameters.Add(new SqlParameter("@Valor", item.Valor));
                        }
                        else {
                            cmd.CommandText = "sp_BalanceItemUpdate";
                            cmd.Parameters.Add(new SqlParameter("@ID", item.ID));
                        }
                        cmd.Parameters.Add(new SqlParameter("@AfetaSaldo", item.AfetaSaldo));
                        cmd.Parameters.Add(new SqlParameter("@Grupo", item.Grupo));
                        cmd.Parameters.Add(new SqlParameter("@Categoria", item.Categoria));
                        cmd.Parameters.Add(new SqlParameter("@SubCategoria", item.SubCategoria));
                        cmd.Parameters.Add(new SqlParameter("@Descricao", item.Descricao));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        item.Updated = false;
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.InsertBalanceItems()", ex);
                return false;
            }
        }

        /// <summary>
        /// Delete list of BalanceItems from table
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool DeleteBalanceItems(List<BalanceItem> items) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_BalanceItemDelete", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var item in items) {
                        cmd.Parameters.Add(new SqlParameter("@ID", item.ID));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.DeleteBalanceItems()", ex);
                return false;
            }
        }

        /// <summary>
        /// Return the most recent BalanceItem's date for a given Bank 
        /// </summary>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static DateTime GetDataMax(string banco) {
            return GetDataMaxMin(banco).Max;
        }

        /// <summary>
        /// Return the oldest BalanceItem's date for a given Bank 
        /// </summary>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static DateTime GetDataMin(string banco) {
            return GetDataMaxMin(banco).Min;
        }

        public static (DateTime Min, DateTime Max) GetDataMaxMin(string banco) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_GetDataMinMax", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                    cmd.Parameters.Add(DateParameter("@Min"));
                    cmd.Parameters.Add(DateParameter("@Max"));
                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    cmd.ExecuteNonQuery();
                    return ((DateTime) cmd.Parameters["@Min"].Value, (DateTime) cmd.Parameters["@Max"].Value);
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetDataMinMax()", ex);
                return (new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));
            }

            SqlParameter DateParameter(string pName) {
                return new SqlParameter(pName, SqlDbType.Date) {
                    Direction = ParameterDirection.Output,
                    IsNullable = false
                };
            }
        }

        public static List<AnalysisItem> GetAnalysisItems(string anoMes, string grupoCategoria) {
            try {
                var items = new List<AnalysisItem>();

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand {
                        Connection = conn,
                        CommandText = $"SELECT * FROM vw_AnaliseBaseView {WhereClause(anoMes, grupoCategoria)}",
                        CommandType = System.Data.CommandType.Text
                    };
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        items.Add(new AnalysisItem(reader));
                    }
                    reader.Close();
                    return items;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetAnalysisItems()", ex);
                return null;
            }
        }

        private static string WhereClause(string anoMes, string grupoCategoria) {
            var sb = new StringBuilder();
            if (anoMes.Equals("") && grupoCategoria.Equals(""))
                return "";
            sb.Append("WHERE ");
            if (!anoMes.Equals(""))
                sb.AppendFormat("({0})", anoMes);
            if (!anoMes.Equals("") && !grupoCategoria.Equals(""))
                sb.Append(" AND ");
            if (!grupoCategoria.Equals(""))
                sb.AppendFormat("({0})", grupoCategoria);
            return sb.ToString();
        }

        public static SortableBindingList<Rule> GetRules() {
            return GetRules(null);
        }

        public static SortableBindingList<Rule> GetRules(string banco) {
            try {
                var rules = new SortableBindingList<Rule>();
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_Rules", conn) { CommandType = System.Data.CommandType.StoredProcedure };
                    cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        rules.Add(new Rule(reader));
                    }
                    reader.Close();
                    return rules;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetRules(Banco)", ex);
                return null;
            }
        }


        public static bool UpdateRules(List<Rule> rules) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var rule in rules) {
                        if (rule.IsNew)
                            cmd.CommandText = "sp_RuleInsert";
                        else {
                            cmd.CommandText = "sp_RuleUpdate";
                            cmd.Parameters.Add(new SqlParameter("@ID", rule.ID));
                        }
                        cmd.Parameters.Add(new SqlParameter("@Banco", rule.Banco));
                        cmd.Parameters.Add(new SqlParameter("@Historico", rule.Historico));
                        cmd.Parameters.Add(new SqlParameter("@Comparacao", rule.ComparacaoInt()));
                        cmd.Parameters.Add(new SqlParameter("@AfetaSaldo", rule.AfetaSaldo));
                        cmd.Parameters.Add(new SqlParameter("@Grupo", rule.Grupo));
                        cmd.Parameters.Add(new SqlParameter("@Categoria", rule.Categoria));
                        cmd.Parameters.Add(new SqlParameter("@SubCategoria", rule.SubCategoria));
                        cmd.Parameters.Add(new SqlParameter("@Descricao", rule.Descricao));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        rule.Updated = false;
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.UpdateRules()", ex);
                return false;
            }
        }

        public static bool IncrementRules(List<BalanceItem> balanceItems) {
            try {
                var updatedRules =
                    from bi in balanceItems
                    where (bi.Updated || bi.Grupo == "S") && bi.Rule != 0
                    group bi by bi.Rule into cond
                    select new { ID = cond.Key, Count = cond.Count() };

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_RuleIncrement", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var rule in updatedRules) {
                        cmd.Parameters.Add(new SqlParameter("@ID", rule.ID));
                        cmd.Parameters.Add(new SqlParameter("@Ocorrencias", rule.Count));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.IncrementRules()", ex);
                return false;
            }
        }

        /// <summary>
        /// Delete list of Rules from table
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static bool DeleteRules(List<Rule> rules) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_RuleDelete", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var r in rules) {
                        cmd.Parameters.Add(new SqlParameter("@ID", r.ID));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.DeleteRules()", ex);
                return false;
            }
        }


        public static SortableBindingList<Payment> GetPayments() {
            try {
                var payments = new SortableBindingList<Payment>();

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand(@"sp_Payments", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        payments.Add(new Payment(reader));
                    }
                    reader.Close();
                    return payments;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetPayments()", ex);
                return null;
            }
        }


        public static bool UpdatePayments(List<Payment> payments) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var payment in payments) {
                        if (payment.IsNew)
                            cmd.CommandText = @"sp_PaymentInsert";
                        else {
                            cmd.CommandText = @"sp_PaymentUpdate";
                            cmd.Parameters.Add(new SqlParameter("@ID", payment.ID));
                        }
                        cmd.Parameters.Add(new SqlParameter("@Group", payment.Group));
                        cmd.Parameters.Add(new SqlParameter("@Description", payment.Description));
                        cmd.Parameters.Add(new SqlParameter("@Day", payment.Day));
                        cmd.Parameters.Add(new SqlParameter("@Enabled", payment.Enabled));
                        cmd.Parameters.Add(new SqlParameter("@Months", payment.Months));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        payment.Updated = false;
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.UpdatePayments()", ex);
                return false;
            }
        }

        /// <summary>
        /// Delete list of Payments from table
        /// </summary>
        /// <param name="payments"></param>
        /// <returns></returns>
        public static bool DeletePayments(List<Payment> payments) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand(@"sp_PaymentDelete", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    foreach (var payment in payments) {
                        cmd.Parameters.Add(new SqlParameter("@ID", payment.ID));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.DeletePayments()", ex);
                return false;
            }
        }

        public static SortableBindingList<Calendar> GetCalendar(DateTime m) {
            try {
                var cal = new SortableBindingList<Calendar>();

                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_Calendar", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Year", (short)m.Year));
                    cmd.Parameters.Add(new SqlParameter("@Month", (short)(1 << (m.Month - 1))));
                    if (cmd.ExecuteScalar() == null) {
                        if (MessageBox.Show($"Calendar for month {m.Month}-{m.Year} does not exist. Create?",
                             "Get Calendar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return cal;
                        cmd.CommandText = @"sp_CalendarInsert";
                        cmd.ExecuteNonQuery();
                    }
                    else {
                        cmd.CommandText = @"sp_CalendarInsert";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"sp_CalendarClean";
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = @"sp_Calendar";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        cal.Add(new Calendar(reader));
                    }
                    reader.Close();
                    return cal;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetCalendar()", ex);
                return null;
            }
        }

        public static bool UpdateCalendar(List<Calendar> calendarItems, DateTime mes) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = @"sp_CalendarUpdate"
                    };
                    foreach (var cal in calendarItems) {
                        cmd.Parameters.Add(new SqlParameter("@Year", (short)mes.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", (short)(1 << (mes.Month - 1))));
                        cmd.Parameters.Add(new SqlParameter("@ID", cal.PaymentID));
                        cmd.Parameters.Add(new SqlParameter("@Paid", cal.Paid));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cal.Updated = false;
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.UpdateCalendar()", ex);
                return false;
            }
        }

        public static SortableBindingList<NextPayment> GetNextPayments(int days) {
            try {
                var payments = new SortableBindingList<NextPayment>();

                using (var conn = GetConnection()) {
                    if (conn == null)
                        return null;
                    var cmd = new SqlCommand(@"sp_CalendarDays", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Days", days));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        payments.Add(new NextPayment(reader));
                    reader.Close();
                    return payments;
                }
            }
            catch (Exception ex) {
                ShowError(@"MoneyBin.GetNextPayments()", ex);
                return null;
            }
        }
    }
}
