using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Categorizer {
    public partial class Form3 : Form {
        private MoneyBinEntities _ctx;

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {
            _ctx = new MoneyBinEntities();
            dataGridView1.DataSource = _ctx.Balance.Where(b=>b.Banco=="CEF").ToList();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e) {

            var tracker = _ctx.ChangeTracker;
            if (!tracker.HasChanges()) return;

            var alts = tracker.Entries().Count(entry => entry.State == EntityState.Added ||
                                                        entry.State == EntityState.Deleted ||
                                                        entry.State == EntityState.Modified);

            MessageBox.Show($" Salvar {alts} alteraç" + (alts == 1 ? "ão" : "ões"));
            //ctx.SaveChanges();
        }
    }
}
