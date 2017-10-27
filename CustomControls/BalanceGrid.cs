using DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GridAndChartStyleLibrary;

namespace CustomControls {

    enum GridMode {
        AddNew,
        EditExisting
    }

    public partial class BalanceGrid : UserControl {
        ContextMenuStrip contextMenuStripColunas;
        public List<BalanceItemOld> BalanceItems = null;
        public List<BalanceItemOld> DeletedItems = new List<BalanceItemOld>();
        private BindingSource source = null;
        private GridMode Mode;
        private int StartRow;  // para calculo de saldos
        private int PanelSize = 0;
        private Classificacao mClass = null;

        public event EventHandler OnBalanceGridAddedChanged;
        public event EventHandler OnBalanceGridRecordsChanged;
        public event EventHandler OnBalanceGridUpdatedChanged;
        public event EventHandler OnBalanceGridDeletedChanged;

        public BalanceGrid() {
            InitializeComponent();
        }

        private void BalanceGrid_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(balanceItemDataGridView);
            GridStyles.FormatColumn(dataDataGridViewTextBoxColumn, GridStyles.StyleDate, 90);
            GridStyles.FormatColumns(balanceItemDataGridView, new[] { 4, 6 }, GridStyles.StyleCurrency, 100);
            GridStyles.FormatColumn(afetaSaldoDataGridViewCheckBoxColumn, GridStyles.StyleBase, 20);
            GridStyles.FormatColumn(historicoDataGridViewTextBoxColumn, GridStyles.StyleBase, 300);
            grupoDataGridViewTextBoxColumn.Width = 60;

            if (this.ParentForm.Name == "frmViewer") {
                balanceItemDataGridView.Columns["bancoDataGridViewTextBoxColumn"].Visible = false;
                balanceItemDataGridView.Columns["saldoDataGridViewTextBoxColumn"].Visible = true;
                Mode = GridMode.EditExisting;
            }
            else {
                Mode = GridMode.AddNew;
                //balanceItemDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Cornsilk;
            }


            contextMenuStripColunas = new ContextMenuStrip();
            contextMenuStripColunas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripColunas_ItemClicked);

            foreach (DataGridViewColumn col in balanceItemDataGridView.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStripColunas.Items.Add(col.HeaderText);
                item.Name = col.Name;
                item.CheckOnClick = true;
                if (col.Visible)
                    item.CheckState = CheckState.Checked;
            }
        }

        public void Setup(int size) {
            mClass = new Classificacao();
            PanelSize = size;
        }

        public void SetSource(List<BalanceItemOld> items, bool exibeSaldo) {
            if (SaveChanges(true)) {
                BalanceItems = items;
                ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStripColunas.Items["saldoDataGridViewTextBoxColumn"];
                item.Checked = exibeSaldo;
                balanceItemDataGridView.Columns["saldoDataGridViewTextBoxColumn"].Visible = exibeSaldo;
                source = new BindingSource();
                source.DataSource = BalanceItems;
                balanceItemDataGridView.DataSource = source;
                if (Mode == GridMode.AddNew)
                    CalculaSaldos(BalanceItems.Count - 1);
                DeletedItems.Clear();
                SetFormWidth();
            }
        }

        public bool SaveChanges(bool promptBeforeSaving) {
            if (BalanceItems == null)
                return true;

            int NewItems = BalanceItems.Count(p => p.Updated && p.IsNew);
            int UpdatedItems = BalanceItems.Count(p => p.Updated && !p.IsNew);

            if (NewItems + UpdatedItems + DeletedItems.Count == 0)
                return true;

            if (promptBeforeSaving) {
                DialogResult resp = MessageBox.Show(frmBase.CreateSavePrompt(NewItems, UpdatedItems, DeletedItems.Count),
                    "Pending Updates", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return true;
                else if (resp == DialogResult.Cancel)
                    return false;
            }

            MoneyBinDB.UpdateBalanceItems(BalanceItems.Where(p => p.Updated).ToList());
            if (DeletedItems.Any()) {
                MoneyBinDB.DeleteBalanceItems(DeletedItems);
                DeletedItems.Clear();
            }
            source.ResetBindings(false);
            RaiseUpdated();
            RaiseDeleted();
            return true;
        }

        private void balanceItemDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!BalanceItems.Any() || BalanceItems.Count < e.RowIndex)
                return;
            var colName = this.balanceItemDataGridView.Columns[e.ColumnIndex].HeaderText;
            var item = BalanceItems[e.RowIndex];
            if (Mode == GridMode.EditExisting) {
                if (!item.AfetaSaldo)
                    e.CellStyle.ForeColor = Color.DarkGray;
                if (item.Updated)
                    e.CellStyle.ForeColor = Color.Yellow;
                if ((colName == "Valor" && item.Valor < 0) || (colName == "Saldo" && item.Saldo < 0))
                    e.CellStyle.ForeColor = Color.LightCoral;
            }
            else {
                if (!item.Updated)
                    e.CellStyle.ForeColor = Color.DarkGray;
                else if ((colName == "Valor" && item.Valor < 0) || (colName == "Saldo" && item.Saldo < 0)) {
                    e.CellStyle.ForeColor = Color.LightCoral;
                }
            }
        }

        private void balanceItemDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            BalanceItemOld bi = BalanceItems[e.RowIndex];
            if (Mode == GridMode.EditExisting)
                bi.Updated = true;
            string x = balanceItemDataGridView.Columns[e.ColumnIndex].Name;
            if (balanceItemDataGridView.Columns[e.ColumnIndex].Name == "afetaSaldoDataGridViewCheckBoxColumn") {
                bi.Saldo += (bi.AfetaSaldo ? 1 : -1) * bi.Valor;
                CalculaSaldos(e.RowIndex);
            }
            source.ResetBindings(false);
            RaiseUpdated();
        }

        private void CalculaSaldos(int startRow) {
            for (int i = startRow - 1; i > -1; i--)
                BalanceItems[i].Saldo = BalanceItems[i + 1].Saldo + (BalanceItems[i].AfetaSaldo ? BalanceItems[i].Valor : 0);
        }

        private void contextMenuStripColunas_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            balanceItemDataGridView.Columns[item.Name].Visible = !item.Checked;
            SetFormWidth();
        }

        void SetFormWidth() {
            int width = balanceItemDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            this.ParentForm.ClientSize = new Size(PanelSize + width, this.ParentForm.ClientSize.Height);
        }

        public void Categorize() {
            DataGridViewSelectedRowCollection SelectedRows = balanceItemDataGridView.SelectedRows;
            if (SelectedRows.Count == 0) {
                MessageBox.Show("No records selected.", "Categorizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmCategorizer frm = new frmCategorizer();
            frm.SelectedItems = new List<BalanceItemOld>();
            foreach (DataGridViewRow r in SelectedRows)
                frm.SelectedItems.Add(BalanceItems[r.Index]);
            frm.ShowDialog();
            source.ResetBindings(false);
            RaiseUpdated();
        }

        private void RaiseUpdated() {
            if (OnBalanceGridUpdatedChanged != null) {
                if (Mode == GridMode.AddNew)
                    OnBalanceGridAddedChanged(BalanceItems.Count(n => n.Updated), null);
                else
                    OnBalanceGridUpdatedChanged(BalanceItems.Count(n => n.Updated), null);
            }
        }

        private void RaiseRecords() {
            if (OnBalanceGridRecordsChanged != null)
                OnBalanceGridRecordsChanged(BalanceItems.Count(), null);
        }

        private void RaiseDeleted() {
            RaiseRecords();
            if (Mode == GridMode.EditExisting) {
                OnBalanceGridDeletedChanged?.Invoke(DeletedItems.Count(), null);
            }
            RaiseUpdated();
        }

        private void balanceItemDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            int row = e.Row.Index;
            DeletedItems.Add(BalanceItems[row]);
            StartRow = -1;
            if (!BalanceItems[row].AfetaSaldo)
                return;
            if (row > 0) {
                BalanceItems[row - 1].Saldo -= BalanceItems[row].Valor;
                StartRow = row - 1;
            }
        }

        private void balanceItemDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            if (StartRow > 0)
                CalculaSaldos(StartRow);
            source.ResetBindings(false);
            RaiseDeleted();
        }

        private void balanceItemDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                contextMenuStripColunas.Show(Cursor.Position);
            }
        }

        private void balanceItemDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            int col = balanceItemDataGridView.CurrentCell.ColumnIndex;
            int row = balanceItemDataGridView.CurrentCell.RowIndex;
            BalanceItemOld bi = BalanceItems[row];
            TextBox txt = e.Control as TextBox;
            if (balanceItemDataGridView.Columns[col].HeaderText == "Categoria") {
                txt.AutoCompleteCustomSource = mClass.Categorias(bi);
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (balanceItemDataGridView.Columns[col].HeaderText == "SubCategoria") {
                txt.AutoCompleteCustomSource = mClass.SubCategorias(bi);
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (balanceItemDataGridView.Columns[col].HeaderText == "Descricao") {
                txt.AutoCompleteCustomSource = mClass.Descricoes(bi);
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
        }
    }
}
