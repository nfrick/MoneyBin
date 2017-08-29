using System;
using System.Data.SqlClient;
using System.Linq;

namespace DataClasses {

    [Flags]
    public enum Month {
        None = 0, Jan = 1, Feb = 2, Mar = 4, Apr = 8, May = 16, Jun = 32, Jul = 64, Aug = 128, Sep = 256, Oct = 512, Nov = 1024, Dec = 2048 }
    public class Payment {
        public int ID { get; }
        public bool IsNew => ID == 0;
        public string Group { get; set; }
        public string Description { get; set; }
        public byte Day { get; set; }
        public bool Enabled { get; set; }
        public Month Months { get; set; }
        public bool Year { 
            get => Enum.GetValues(typeof(Month)).Cast<Month>().All(IsMonth);
            set {
                foreach (Month m in Enum.GetValues(typeof(Month)))
                    SetMonth(m, value);
            }
        }
        public bool Jan { get => IsMonth(Month.Jan);
            set => SetMonth(Month.Jan, value);
        }
        public bool Feb { get => IsMonth(Month.Feb);
            set => SetMonth(Month.Feb, value);
        }
        public bool Mar { get => IsMonth(Month.Mar);
            set => SetMonth(Month.Mar, value);
        }
        public bool Apr { get => IsMonth(Month.Apr);
            set => SetMonth(Month.Apr, value);
        }
        public bool May { get => IsMonth(Month.May);
            set => SetMonth(Month.May, value);
        }
        public bool Jun { get => IsMonth(Month.Jun);
            set => SetMonth(Month.Jun, value);
        }
        public bool Jul { get => IsMonth(Month.Jul);
            set => SetMonth(Month.Jul, value);
        }
        public bool Aug { get => IsMonth(Month.Aug);
            set => SetMonth(Month.Aug, value);
        }
        public bool Sep { get => IsMonth(Month.Sep);
            set => SetMonth(Month.Sep, value);
        }
        public bool Oct { get => IsMonth(Month.Oct);
            set => SetMonth(Month.Oct, value);
        }
        public bool Nov { get => IsMonth(Month.Nov);
            set => SetMonth(Month.Nov, value);
        }
        public bool Dec { get => IsMonth(Month.Dec);
            set => SetMonth(Month.Dec, value);
        }
        public bool Updated { get; set; }

        private bool IsMonth(Month m) {
            return (Months & m) == m;
        }

        private void SetMonth(Month m, bool b) {
            if (b)
                Months |= m;
            else
                Months &= ~m;
        }

        public Payment() {
            ID = 0;
            Group = string.Empty;
            Description = string.Empty;
            Day = 0;
            Enabled = true;
            foreach (Month m in Enum.GetValues(typeof(Month)))
                Months &= m; 
            Updated = false;
        }

        public Payment(SqlDataReader r) {
            ID = (int)r["ID"];
            Group = r["Group"].ToString();
            Description = r["Description"].ToString();
            Day = (byte)r["Day"];
            Months = (Month)(short)r["Months"];
            Enabled = (bool)r["Enabled"];
            Updated = false;
        }
    }
}
