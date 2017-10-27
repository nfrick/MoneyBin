using CustomControls;
using DataClasses;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GridAndChartStyleLibrary;

namespace MoneyBin {
    public partial class frmCalendar : CustomControls.frmBase {
        public SortableBindingList<CalendarOld> CalendarItems;
        private BindingSource _source = null;

        public event EventHandler OnCalendarGridRecordsChanged;
        public event EventHandler OnCalendarGridUpdatedChanged;

        public frmCalendar() {
            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e) {
            OnCalendarGridRecordsChanged += OnRecordsChanged;
            OnCalendarGridUpdatedChanged += OnUpdatedChanged;

            toolStripButtonAnalyze.Visible = false;
            toolStripButtonCategorize.Visible = false;
            toolStripStatusLabelAdded.Visible = false;
            toolStripStatusLabelDeleted.Visible = false;
            SetSource();

            GridStyles.FormatGrid(dgvCalendar);
            dayDataGridViewTextBoxColumn.DefaultCellStyle = 
                new DataGridViewCellStyle() {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N0"
                };
            dayDataGridViewTextBoxColumn.Width = 50;
            this.Height = 170 + CalendarItems.Count * dgvCalendar.RowTemplate.Height;
        }

        public override void toolStripButtonLoad_Click(object sender, EventArgs e) {
            SetSource();
        }

        private void dateTimePickerMonth_ValueChanged(object sender, EventArgs e) {
            SetSource();
        }

        private void SetSource() {
            if (SaveChanges(true)) {
                CalendarItems = MoneyBinDB.GetCalendar(dateTimePickerMonth.Value);
                Height += dgvCalendar.RowTemplate.Height * 
                    (CalendarItems.Count() - dgvCalendar.Rows.Count);
                _source = new BindingSource {DataSource = CalendarItems};
                dgvCalendar.DataSource = _source;
                RaiseRecords();
            }
        }

        public bool SaveChanges(bool promptBeforeSaving) {
            if (CalendarItems == null)
                return true;

            var updatedItems = CalendarItems.Count(p => p.Updated);
            if (updatedItems == 0)
                return true;

            if (promptBeforeSaving) {
                var resp = MessageBox.Show($@"There are {updatedItems} updated items. Save changes?", 
                    @"Pending Updates", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (resp) {
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            MoneyBinDB.UpdateCalendar(CalendarItems.Where(p => p.Updated).ToList(), dateTimePickerMonth.Value);
            _source.ResetBindings(false);
            RaiseUpdated();
            return true;
        }

        private void frmCalendar_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !SaveChanges(true);
        }

        public override void toolStripButtonSave_Click(object sender, EventArgs e) {
            SaveChanges(false);
        }

        private void dataGridViewCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!CalendarItems.Any() || CalendarItems.Count <= e.RowIndex)
                return;
            if (CalendarItems[e.RowIndex].Paid) {
                e.CellStyle.ForeColor = Color.Gray;
            }
            else if (CalendarItems[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void dataGridViewCalendar_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) return;
            CalendarItems[e.RowIndex].Updated = true;
            _source.ResetBindings(false);
            RaiseUpdated();
        }

        private void RaiseUpdated() {
            OnCalendarGridUpdatedChanged?.Invoke(CalendarItems.Count(n => n.Updated), null);
        }

        private void RaiseRecords() {
            OnCalendarGridRecordsChanged?.Invoke(CalendarItems.Count, null);
        }
    }
}
