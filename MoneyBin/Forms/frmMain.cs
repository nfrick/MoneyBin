using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using MoneyBin.Forms;

namespace MoneyBin {
    public partial class frmMain : Form {
        private List<string> LastBackgrounds = new List<string>();
        public frmMain() {
            InitializeComponent();
            NewBackground();
            timer1.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e) {
            Controls.OfType<MdiClient>().First().BackColor = this.BackColor;
        }

        private void toolStripButtonNewViewer_Click(object sender, EventArgs e) {
            var frm = new frmBalance { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonNewReader_Click(object sender, EventArgs e) {
            var frm = new frmLeitor { MdiParent = this };
            if (!frm.HasData) return;
            frm.Show();
        }

        private void toolStripButtonAnalysis_Click(object sender, EventArgs e) {
            var frm = new frmAnalysis { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonReport_Click(object sender, EventArgs e) {
            var frm = new frmReport { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e) {
            var frm = new frmExport { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonRules_Click(object sender, EventArgs e) {
            var frm = new frmRules { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonPayments_Click(object sender, EventArgs e) {
            var frm = new frmPagamentos { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonCalendar_Click(object sender, EventArgs e) {
            var frm = new frmCalendario { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonBackground_Click(object sender, EventArgs e) {
            NewBackground();
        }

        private void NewBackground() {
            var _imgPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Backgrounds\\Reduzidas";
            var files = Directory.GetFiles(_imgPath, "*.jpg");
            if (LastBackgrounds.Count == files.Length)
                LastBackgrounds.RemoveAt(0);

            string file;
            var rnd = new Random();
            do {
                file = Path.GetFileName(files[rnd.Next(0, files.Length)]);
            } while (LastBackgrounds.Contains(file));
            BackgroundImage = Image.FromFile($"{_imgPath}\\{file}");
            LastBackgrounds.Add(Path.GetFileName(file));
        }

        private void timer1_Tick(object sender, EventArgs e) {
            NewBackground();
        }

        private void toolStripButtonReembolsos_Click(object sender, EventArgs e) {
            var frm = new frmAssociador { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonContas_Click(object sender, EventArgs e) {
            var frm = new frmContas() { MdiParent = this };
            frm.Show();
        }
    }
}
