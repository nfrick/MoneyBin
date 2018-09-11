using DataLayer;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBin.Forms {
    public partial class frmRuleFromHistorico : Form {
        private string banco;
        public frmRuleFromHistorico(string b) {
            banco = b;
            InitializeComponent();
            Text += $"    Banco: {banco}";
        }

        private void frmRuleFromHistorico_Load(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                foreach (var historico in ctx.sp_Historicos(banco)) {
                    var lv = lvHistoricos.Items.Add(historico.Texto);
                    lv.SubItems.Add(historico.Ocorrencias.ToString());
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lvHistoricos_ColumnClick(object sender, ColumnClickEventArgs e) {
            this.lvHistoricos.ListViewItemSorter = new ListViewItemComparer(e.Column);
            // Call the sort method to manually sort.
            lvHistoricos.Sort();
        }
    }
    // Implements the manual sorting of items by column.
    class ListViewItemComparer : IComparer {
        private int col;
        public ListViewItemComparer() {
            col = 0;
        }
        public ListViewItemComparer(int column) {
            col = column;
        }
        public int Compare(object x, object y) {
            var vx = ((ListViewItem)x).SubItems[col].Text;
            var vy = ((ListViewItem)y).SubItems[col].Text;

            return col == 0 ? string.Compare(vx, vy) : IntCompare(vx, vy);
        }

        public int IntCompare(string x, string y) {
            var vx = int.Parse(x);
            var vy = int.Parse(y);
            return -1 * Math.Sign(vx.CompareTo(vy));
        }
    }
}
