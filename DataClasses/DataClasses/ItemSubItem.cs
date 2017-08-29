using System.Data.SqlClient;

namespace DataClasses {
    public class Tuple2Levels {
        public string Item { get; set; }
        public string SubItem { get; set; }

        public string Key() => Item + '-' + SubItem;

        public Tuple2Levels(SqlDataReader r, string itemField, string subItemField) {
            Item = r[itemField].ToString();
            SubItem = r[subItemField].ToString();
        }
    }
}
