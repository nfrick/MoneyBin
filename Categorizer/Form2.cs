using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Categorizer {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            entityDataSource1.SaveChanges();
            entityDataSource1.Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var id = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            var x = entityDataSource1.DbContext.Set<BalanceItem>().Where(i => i.GrupoId == id&& i.NovaSubCategoria != null).Select(i => i.NovaSubCategoria).Distinct().ToList();
            listBox1.Items.Clear();
            foreach (var y in x) {
                listBox1.Items.Add(y);
            }
        }
    }
}
