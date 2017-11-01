using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataLayer {
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

        public static int ExportToExtrato(string accessDB) {
            try {
                using (var conn = GetConnection()) {
                    var cmd = new SqlCommand("sp_ExportToExtrato", conn) {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AccessDB", accessDB));
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                ShowError("@MoneyBin.ExportToExtrato()\nString: " + ConnectionString + "\n", ex);
            }
            return 0;
        }

    }
}
