using DataClasses;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBinAlarm {
    public partial class frmMain : Form {
        public SortableBindingList<NextPayment> CalendarItems;
        private BindingSource _source;
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
            CalendarItems = MoneyBinDB.GetNextPayments(_numDays);
            if (CalendarItems == null || !CalendarItems.Any())
                return false;
            _source = new BindingSource {DataSource = CalendarItems};
            dgvPayments.DataSource = _source;
            return true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!CalendarItems.Any() || CalendarItems.Count <= e.RowIndex)
                return;
            if (CalendarItems[e.RowIndex].DaysLate < 0) {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.Red;
            }
            else if (CalendarItems[e.RowIndex].DaysLate < 2)
                e.CellStyle.ForeColor = Color.Red;
            else if (CalendarItems[e.RowIndex].DaysLate < 4)
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
