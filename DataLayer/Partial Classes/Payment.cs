using System;
using System.Linq;

namespace DataLayer {
    [Flags]
    public enum MonthsOfYear {
        None = 0, Jan = 1, Feb = 2, Mar = 4, Apr = 8, May = 16, Jun = 32, Jul = 64, Aug = 128, Sep = 256, Oct = 512, Nov = 1024, Dec = 2048
    }
    public partial class Payment {
        public override string ToString() => $@"{Group}\{Description}";
        public bool Year {
            get => Enum.GetValues(typeof(MonthsOfYear)).Cast<MonthsOfYear>().All(IsMonth);
            set {
                foreach (MonthsOfYear m in Enum.GetValues(typeof(MonthsOfYear)))
                    SetMonth(m, value);
            }
        }
        public bool Jan {
            get => IsMonth(MonthsOfYear.Jan);
            set => SetMonth(MonthsOfYear.Jan, value);
        }
        public bool Feb {
            get => IsMonth(MonthsOfYear.Feb);
            set => SetMonth(MonthsOfYear.Feb, value);
        }
        public bool Mar {
            get => IsMonth(MonthsOfYear.Mar);
            set => SetMonth(MonthsOfYear.Mar, value);
        }
        public bool Apr {
            get => IsMonth(MonthsOfYear.Apr);
            set => SetMonth(MonthsOfYear.Apr, value);
        }
        public bool May {
            get => IsMonth(MonthsOfYear.May);
            set => SetMonth(MonthsOfYear.May, value);
        }
        public bool Jun {
            get => IsMonth(MonthsOfYear.Jun);
            set => SetMonth(MonthsOfYear.Jun, value);
        }
        public bool Jul {
            get => IsMonth(MonthsOfYear.Jul);
            set => SetMonth(MonthsOfYear.Jul, value);
        }
        public bool Aug {
            get => IsMonth(MonthsOfYear.Aug);
            set => SetMonth(MonthsOfYear.Aug, value);
        }
        public bool Sep {
            get => IsMonth(MonthsOfYear.Sep);
            set => SetMonth(MonthsOfYear.Sep, value);
        }
        public bool Oct {
            get => IsMonth(MonthsOfYear.Oct);
            set => SetMonth(MonthsOfYear.Oct, value);
        }
        public bool Nov {
            get => IsMonth(MonthsOfYear.Nov);
            set => SetMonth(MonthsOfYear.Nov, value);
        }
        public bool Dec {
            get => IsMonth(MonthsOfYear.Dec);
            set => SetMonth(MonthsOfYear.Dec, value);
        }
        public bool Updated { get; set; }

        private bool IsMonth(MonthsOfYear m) {
            return (Months & (int)m) == (int)m;
        }

        private void SetMonth(MonthsOfYear m, bool b) {
            if (b)
                Months |= (int)m;
            else
                Months &= ~(int)m;
        }
    }
}
