using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Categorizer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                var grupos = ctx.Balance.Select(i => new { i.NovoGrupo }).Distinct()
                    .Where(g => !string.IsNullOrEmpty(g.NovoGrupo)).OrderBy(i => i.NovoGrupo).ToList();
                cbxNovoGrupo.DataSource = grupos;
                cbxNovoGrupo.DisplayMember = "NovoGrupo";
                cbxNovoGrupo.ValueMember = "NovoGrupo";
            }

            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            try {
                var pos = config.AppSettings.Settings["Position"].Value;
                entityBindingNavigator1.Position = int.Parse(pos);
            }
            catch {

            }
        }

        private void WhiteBackColor() {
            foreach (var ctl in Controls) {
                if (ctl is TextBox)
                    ((TextBox)ctl).BackColor = Color.White;
            }
        }

        private void btnCategoriasToList_Click(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                var categorias = ctx.Balance
                    .Where(i => i.NovoGrupo == (string)cbxNovoGrupo.SelectedValue && !string.IsNullOrEmpty(i.NovaCategoria))
                    .Select(i => new { opcao = i.NovaCategoria }).Distinct()
                    .OrderBy(o => o.opcao).ToList();
                listBox1.DataSource = categorias;
                listBox1.DisplayMember = "opcao";
                listBox1.ValueMember = "opcao";
                listBox1.Tag = txtNovaCategoria;
                WhiteBackColor();
                txtNovaCategoria.BackColor = Color.Khaki;
            }
        }

        private void btnSubCategoriasToList_Click(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                var subCategorias = ctx.Balance
                    .Where(i => i.NovoGrupo == (string)cbxNovoGrupo.SelectedValue && i.NovaCategoria == txtNovaCategoria.Text
                                && !string.IsNullOrEmpty(i.NovaSubCategoria))
                    .Select(i => new { opcao = i.NovaSubCategoria }).Distinct()
                    .OrderBy(o => o.opcao).ToList();
                listBox1.DataSource = subCategorias;
                listBox1.DisplayMember = "opcao";
                listBox1.ValueMember = "opcao";
                listBox1.Tag = txtNovaSubCategoria;
                WhiteBackColor();
                txtNovaSubCategoria.BackColor = Color.Khaki;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e) {
            ((TextBox)listBox1.Tag).Text = (string)listBox1.SelectedValue;
        }

        private void btnDescricoesToList_Click(object sender, EventArgs e) {
            using (var ctx = new MoneyBinEntities()) {
                var descricoes = ctx.Balance
                    .Where(i => i.NovoGrupo == (string)cbxNovoGrupo.SelectedValue && i.NovaCategoria == txtNovaCategoria.Text
                                 && !string.IsNullOrEmpty(i.Descricao))
                    .Select(i => new { opcao = i.Descricao }).Distinct()
                    .OrderBy(o => o.opcao).ToList();
                listBox1.DataSource = descricoes;
                listBox1.DisplayMember = "opcao";
                listBox1.ValueMember = "opcao";
                listBox1.Tag = txtNovaSubCategoria;
                WhiteBackColor();
                txtNovaSubCategoria.BackColor = Color.Khaki;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position -= 100;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position += 100;
        }

        private void button4_Click(object sender, EventArgs e) {
            txtDescricao.Text = string.Empty;
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position -= 50;
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position += 50;
        }

        private void button5_Click(object sender, EventArgs e) {
            txtNovaSubCategoria.Text = txtDescricao.Text;
            txtDescricao.Text = string.Empty;
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position -= 1000;
        }

        private void toolStripButton6_Click(object sender, EventArgs e) {
            entityBindingNavigator1.Position += 1000;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("Position");
            config.AppSettings.Settings.Add("Position", entityBindingNavigator1.Position.ToString());
            config.Save(ConfigurationSaveMode.Modified);
        }

        private int countChanges = 0;
        private void entityBindingNavigator1_PositionChanged(object sender, EventArgs e) {
            countChanges++;
            if (countChanges != 5) return;
            countChanges = 0;
            entityDataSource1.SaveChanges();
        }
    }
}
