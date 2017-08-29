using CustomControls;
using DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GridAndChartStyleLibrary;

namespace MoneyBin {
    public partial class frmPayments : CustomControls.frmBase {
        public SortableBindingList<Payment> Payments { get; set; }
        public List<Payment> DeletedItems = new List<Payment>();
        private BindingSource _source;

        public event EventHandler OnPaymentsGridAddedChanged;
        public event EventHandler OnPaymentsGridRecordsChanged;
        public event EventHandler OnPaymentsGridUpdatedChanged;
        public event EventHandler OnPaymentsGridDeletedChanged;

        public frmPayments() {
            InitializeComponent();
        }

        private void frmPayments_Load(object sender, EventArgs e) {
            OnPaymentsGridAddedChanged += OnAddedChanged;
            OnPaymentsGridRecordsChanged += OnRecordsChanged;
            OnPaymentsGridUpdatedChanged += OnUpdatedChanged;
            OnPaymentsGridDeletedChanged += OnDeletedChanged;
            toolStripButtonAnalyze.Visible = false;
            toolStripButtonCategorize.Visible = false;
            SetSource();

            GridStyles.FormatGrid(dataGridViewPayments);
            dayDataGridViewTextBoxColumn.DefaultCellStyle =
                new DataGridViewCellStyle() {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N0"
                };
            dayDataGridViewTextBoxColumn.Width = 50;
            this.Height = 160 + Payments.Count * dataGridViewPayments.RowTemplate.Height;
        }

        private void SetSource() {
            if (SaveChanges(true)) {
                Payments = MoneyBinDB.GetPayments();
                _source = new BindingSource {DataSource = Payments};
                dataGridViewPayments.DataSource = _source;
                RaiseRecords();
            }
        }

        public bool SaveChanges(bool promptBeforeSaving) {
            if (Payments == null)
                return true;

            var newPayments = Payments.Count(p => p.IsNew);
            var updatedPayments = Payments.Count(p => p.Updated && !p.IsNew);

            if (newPayments + updatedPayments == 0 && !DeletedItems.Any())
                return true;

            if (promptBeforeSaving) {
                var resp = MessageBox.Show(CreateSavePrompt(newPayments, updatedPayments, DeletedItems.Count), "Pending Updates", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (resp) {
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }

            if (newPayments + updatedPayments > 0)
                MoneyBinDB.UpdatePayments(Payments.Where(p => p.Updated).ToList());
            if (DeletedItems.Count > 0) {
                MoneyBinDB.DeletePayments(DeletedItems);
                DeletedItems.Clear();
            }
            _source.ResetBindings(false);
            RaiseUpdated();
            RaiseDeleted();
            return true;
        }

        private void frmPayments_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !SaveChanges(true);
        }

        public override void toolStripButtonLoad_Click(object sender, EventArgs e) {
            SetSource();
        }

        public override void toolStripButtonSave_Click(object sender, EventArgs e) {
            SaveChanges(false);
        }

        private void PaymentsdataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!Payments.Any() || Payments.Count <= e.RowIndex)
                return;
            var item = Payments[e.RowIndex];
            if (item.Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void dataGridViewPayments_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            Payments[e.RowIndex].Updated = true;
            _source.ResetBindings(false);
            RaiseUpdated();
        }

        private void dataGridViewPayments_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
            RaiseAdded();
        }

        private void dataGridViewPayments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            int row = e.Row.Index;
            if (!Payments[row].IsNew)
                DeletedItems.Add(Payments[row]);
        }

        private void dataGridViewPayments_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            _source.ResetBindings(false);
            RaiseDeleted();
        }

        private void PaymentsdataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show($@"Data error in row {e.RowIndex} column {e.ColumnIndex}");
        }

        private void RaiseAdded() {
            RaiseRecords();
            OnPaymentsGridAddedChanged?.Invoke(Payments.Count(n => n.IsNew), null);
        }

        private void RaiseUpdated() {
            OnPaymentsGridUpdatedChanged?.Invoke(Payments.Count(n => n.Updated && !n.IsNew), null);
        }

        private void RaiseRecords() {
            OnPaymentsGridRecordsChanged?.Invoke(Payments.Count(), null);
        }

        private void RaiseDeleted() {
            RaiseAdded();
            RaiseUpdated();
            OnPaymentsGridDeletedChanged?.Invoke(DeletedItems.Count(), null);
        }
    }
}
