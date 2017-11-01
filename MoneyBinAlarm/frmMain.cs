using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace MoneyBinAlarm {
    public partial class frmMain : Form {
        //public List<NextPayment> CalendarItems;
        private int _numDays = 10;

        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if (!SetSource(0))
                Application.Exit();
        }

        private bool SetSource(int increment) {
            if (increment != 0)
                _numDays += increment;
            labelNumDays.Text = _numDays.ToString();
            using (var ctx = new MoneyBinEntities()) {
                var CalendarItems = ctx.CalendarNextPayments(_numDays).ToList();
                if (CalendarItems == null || !CalendarItems.Any())
                    return false;
                nextPaymentBindingSource.DataSource = CalendarItems;
            }
            return true;
        }

        private void dgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvPayments.RowCount == 0) return;

            var daysLate = (int)dgvPayments.Rows[e.RowIndex].Cells[0].Value;
            if (daysLate < 0) {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.Red;
            }
            else if (daysLate < 2)
                e.CellStyle.ForeColor = Color.Red;
            else if (daysLate < 4)
                e.CellStyle.ForeColor = Color.Yellow;
            else
                e.CellStyle.ForeColor = Color.White;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void labelNumDays_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                SetSource(1);
            else if (_numDays > 0)
                SetSource(-1);
        }
    }
}
