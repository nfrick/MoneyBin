using System;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            MdiClient ctlMDI;
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls) {
                try {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc) {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void toolStripButtonNewViewer_Click(object sender, EventArgs e) {
            var frm = new frmViewer { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonNewReader_Click(object sender, EventArgs e) {
            var frm = new frmReader { MdiParent = this };
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
            var frm = new frmPayments { MdiParent = this };
            frm.Show();
        }

        private void toolStripButtonCalendar_Click(object sender, EventArgs e) {
            var frm = new frmCalendar { MdiParent = this };
            frm.Show();
        }
    }
}
