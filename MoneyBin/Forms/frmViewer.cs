using System;
using System.Windows.Forms;
using DataClasses;

namespace MoneyBin {
    public partial class frmViewer : CustomControls.frmBase {
        private string _banco = "BB";
        private bool _loading = true;

        public frmViewer() {
            InitializeComponent();
            treeSelector1.ItemName = "Grupo";
            treeSelector1.SubItemName = "Categoria";
        }

        private void frmViewer_Load(object sender, EventArgs e) {
            balanceGrid1.OnBalanceGridAddedChanged += OnAddedChanged;
            balanceGrid1.OnBalanceGridRecordsChanged += OnRecordsChanged;
            balanceGrid1.OnBalanceGridUpdatedChanged += OnUpdatedChanged;
            balanceGrid1.OnBalanceGridDeletedChanged += OnDeletedChanged;
            balanceGrid1.Setup(370);
            SetDatesGroupsAndCategories();
            _loading = false;
            tableLayoutPanelControles.ColumnStyles[0].Width = 0;
            toolStripButtonAnalyze.Visible = false;
            toolStripStatusLabelAdded.Visible = false;
        }

        public override void toolStripButtonLoad_Click(object sender, EventArgs e) {
            var gc = treeSelector1.GetQuery();
            var bi = MoneyBinDB.GetBalanceItems(_banco, dateTimePickerInicio.Value, dateTimePickerTermino.Value, gc);
            balanceGrid1.SetSource(bi, gc.Length == 0);
            OnRecordsChanged(bi.Count, null);
            OnUpdatedChanged(0, null);
            OnDeletedChanged(0, null);
        }

        private void comboBoxBanco_SelectedValueChanged(object sender, EventArgs e) {
            _banco = comboBoxBanco.Text;
            SetDatesGroupsAndCategories();
        }

        private void SetDatesGroupsAndCategories() {
            SetDates();
            LoadTree();
        }

        private void labelInicio_Click(object sender, EventArgs e) {
            dateTimePickerInicio.Value = MoneyBinDB.GetDataMin(_banco);
        }

        private void labelTermino_Click(object sender, EventArgs e) {
            dateTimePickerTermino.Value = MoneyBinDB.GetDataMax(_banco);
        }

        private void SetDates() {
            var dateRange = MoneyBinDB.GetDataMaxMin(_banco);
            if (dateRange.Max.Year == 1900) {
                dateTimePickerInicio.Value = DateTime.Today;
                dateTimePickerInicio.Enabled = false;
                dateTimePickerTermino.Value = DateTime.Today;
                dateTimePickerTermino.Enabled = false;
            }
            else {
                var seisMesesAtras = DateTime.Today.AddMonths(-6);
                dateTimePickerInicio.MinDate = dateRange.Min;
                dateTimePickerInicio.MaxDate = dateRange.Max;
                dateTimePickerInicio.Value = (seisMesesAtras.CompareTo(dateRange.Min) < 0) ? dateRange.Min : 
                    (seisMesesAtras.CompareTo(dateRange.Max) > 0 ? dateRange.Max.AddMonths(-6) : seisMesesAtras);

                dateTimePickerTermino.MinDate = dateRange.Min;
                dateTimePickerTermino.MaxDate = dateRange.Max;
                dateTimePickerTermino.Value = dateRange.Max;
            }
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e) {
            if (!_loading)
                LoadTree();
        }

        private void dateTimePickerTermino_ValueChanged(object sender, EventArgs e) {
            if (!_loading)
                LoadTree();
        }

        private void LoadTree() {
            var GCs = MoneyBinDB.GetGruposCategorias(_banco, dateTimePickerInicio.Value, dateTimePickerTermino.Value);
            treeSelector1.LoadData(GCs);
        }

        private void buttonCollapse_Click(object sender, EventArgs e) {
            tableLayoutPanelControles.ColumnStyles[0].Width = 24;
            tableLayoutPanelControles.ColumnStyles[1].Width = 0;
            tableLayoutPanelColunas.ColumnStyles[0].Width -= 175;
            this.Width -= 175;
        }

        private void buttonExpand_Click(object sender, EventArgs e) {
            tableLayoutPanelControles.ColumnStyles[0].Width = 0;
            tableLayoutPanelControles.ColumnStyles[1].Width = 160;
            tableLayoutPanelColunas.ColumnStyles[0].Width += 175;
            this.Width += 175;
        }

        public override void toolStripButtonSave_Click(object sender, EventArgs e) {
            balanceGrid1.SaveChanges(false);
            LoadTree();
        }

        public override void toolStripButtonCategorize_Click(object sender, EventArgs e) {
            balanceGrid1.Categorize();
        }

        private void frmViewer_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !balanceGrid1.SaveChanges(true);
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            //var frm = new frmExport() { Items = balanceGrid1.BalanceItems };
            //frm.ShowDialog();
        }
    }
}
