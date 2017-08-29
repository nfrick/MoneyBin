using System;
using System.Text;
using System.Windows.Forms;

namespace CustomControls {
    public partial class frmBase : Form {
        public frmBase() {
            InitializeComponent();
        }

        private void frmBase_Load(object sender, EventArgs e) {
            this.Height = this.Parent.Height - this.Location.Y - 10;
        }

        protected void pbarSetMaximum(int max) {
            toolStripProgressBar1.Maximum = max;
        }

        protected void pbarIncrement() {
            toolStripProgressBar1.Increment(1);
        }

        protected void pbarIncrement(int value) {
            toolStripProgressBar1.Increment(value);
        }

        protected void OnAddedChanged(object sender, EventArgs e) {
            int additions = (int)sender;
            toolStripStatusLabelAdded.Text = String.Format("New: {0}", additions);
            toolStripButtonSave.Enabled |= (additions > 0);
        }

        protected void OnRecordsChanged(object sender, EventArgs e) {
            int records = (int)sender;
            toolStripStatusLabelRecords.Text = String.Format("Records: {0}", records);
            toolStripButtonSave.Enabled = false;
            toolStripButtonCategorize.Enabled = (records > 0);
        }

        protected void OnUpdatedChanged(object sender, EventArgs e) {
            int updates = (int)sender;
            toolStripStatusLabelUpdated.Text = String.Format("Updates: {0}", updates);
            toolStripButtonSave.Enabled |= (updates > 0);
        }

        protected void OnDeletedChanged(object sender, EventArgs e) {
            int deletes = (int)sender;
            toolStripStatusLabelDeleted.Text = String.Format("Deletes: {0}", deletes);
            toolStripButtonSave.Enabled |= (deletes > 0);
        }

        public static string CreateSavePrompt(int NewItems, int UpdatedItems, int DeletedItems) {
            var sb = new StringBuilder("There ").Append(NewItems + UpdatedItems + DeletedItems == 1 ? "is" : "are");
            if (NewItems > 0)
                sb.AppendFormat(" {0} new items", NewItems);
            if (UpdatedItems > 0) {
                if (NewItems > 0 && DeletedItems > 0)
                    sb.Append(",");
                else if (NewItems > 0)
                    sb.Append(" and");
                sb.AppendFormat(" {0} updated items", UpdatedItems);
            }
            if (DeletedItems > 0) {
                if (NewItems > 0 || UpdatedItems > 0)
                    sb.Append(" and");
                sb.AppendFormat(" {0} deleted items", DeletedItems);
            }
            return sb.Append(". Save changes?").ToString();
        }

        public virtual void toolStripButtonLoad_Click(object sender, EventArgs e) {

        }
        public virtual void toolStripButtonSave_Click(object sender, EventArgs e) {

        }
        public virtual void toolStripButtonAnalyze_Click(object sender, EventArgs e) {

        }
        public virtual void toolStripButtonCategorize_Click(object sender, EventArgs e) {

        }
    }
}
