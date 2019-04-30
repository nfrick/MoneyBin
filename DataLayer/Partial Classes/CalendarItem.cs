using System;

namespace DataLayer {
    public partial class CalendarItem {
        public override string ToString() => Payment?.Description ?? "Não definido";

        public int Day => Payment?.Day ?? 1;

        public int Month12 => 1 + (int)Math.Log(Month, 2);

        public DateTime Date => new DateTime(Year, Month12, Day);
    }
}
