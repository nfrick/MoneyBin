using System;

namespace DataLayer {
    public partial class CalendarItem {
        public override string ToString() => Payment.Group + "/" + Payment.Description;

        public int Day => Payment?.Day ?? 1;

        public int Month12 => 1 + (int)Math.Log(Month, 2);

        public DateTime Date => new DateTime(Year, Month12, Day);

        public string Description => ToString().ToUpper() + " - " + Date.ToString("dd/MM/yyyy");
    }
}
