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

        public static (DateTime Min, DateTime Max) GetDataMaxMin(string banco) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_GetDataMinMax", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new SqlParameter("@Banco", banco));
                    cmd.Parameters.Add(DateParameter("@Min"));
                    cmd.Parameters.Add(DateParameter("@Max"));
                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    cmd.ExecuteNonQuery();
                    return ((DateTime)cmd.Parameters["@Min"].Value, (DateTime)cmd.Parameters["@Max"].Value);
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

        public static void ExportToExtrato(string accessDB) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_ExportToExtrato", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AccessDB", accessDB));
                    var x = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                ShowError("@MoneyBin.ExportToExtrato()\nString: " + ConnectionString + "\n", ex);
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
