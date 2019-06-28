using System;
using System.Linq;

namespace DataLayer {
    public partial class Account {
        public DateTime DataMin => Balance.Min(b => b.Data);
        public DateTime DataMax => Balance.Max(b => b.Data);
        public bool HasData => Balance.Any();
    }
}