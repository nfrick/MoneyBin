using System;
using System.Data.SqlClient;

namespace DataClasses {
    public class CalendarBase {
        public DateTime Date { get; set; }
        public int Day => Date.Day;
        public string Group { get; set; }
        public string Description { get; set; }

        public CalendarBase(SqlDataReader r) {
            Date = (DateTime)r["Date"]; ;
            Group = r["Group"].ToString();
            Description = r["Description"].ToString();
        }
    }

    public class CalendarOld : CalendarBase {
        public int PaymentID { get; set; }
        public bool Paid { get; set; }
        public bool Updated { get; set; }

        public CalendarOld(SqlDataReader r) : base(r) {
            PaymentID = (int)r["PaymentID"];
            Paid = (bool)r["Paid"]; ;
            Updated = false;
        }
    }

    public class NextPayment : CalendarBase {
        public int DaysLate { get; set; }
        public NextPayment(SqlDataReader r) : base(r) {
            DaysLate = (int)r["DaysLate"]; ;
        }
    }
}
