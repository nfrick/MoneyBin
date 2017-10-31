using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class AnaliseItem
    {
        public bool IsPositive => this.Sinal > 0;
        public bool IsNegative => this.Sinal < 0;
    }
}
