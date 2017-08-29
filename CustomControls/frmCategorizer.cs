using DataClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomControls {
    public partial class frmCategorizer : Form {
        public frmCategorizer() {
            InitializeComponent();
        }

        public List<BalanceItem> SelectedItems;

        private void buttonPreencher_Click(object sender, EventArgs e) {
            progressBar1.Maximum = SelectedItems.Count;
            progressBar1.Value = 0;
            foreach (BalanceItem bi in SelectedItems) {
                progressBar1.Value++;
                if (checkBoxGrupo.Checked)
                    bi.Grupo = textBoxGrupo.Text.Length == 0 ? null : textBoxGrupo.Text;
                if (checkBoxCategoria.Checked)
                    bi.Categoria = textBoxCategoria.Text.Length == 0 ? null : textBoxCategoria.Text;
                if (checkBoxSubCategoria.Checked)
                    bi.SubCategoria = textBoxSubCategoria.Text.Length == 0 ? null : textBoxSubCategoria.Text;
                if (checkBoxDescricao.Checked)
                    bi.Descricao = textBoxDescricao.Text.Length == 0 ? null : textBoxDescricao.Text;
                bi.Updated = true;
            }
            //progressBar1.Value = 0;
        }

        private void checkBoxGrupo_CheckedChanged(object sender, EventArgs e) {
            textBoxGrupo.Enabled = checkBoxGrupo.Checked;
            SetPreencher();
        }

        private void checkBoxCategoria_CheckedChanged(object sender, EventArgs e) {
            textBoxCategoria.Enabled = checkBoxCategoria.Checked;
            SetPreencher();
        }

        private void checkBoxSubCategoria_CheckedChanged(object sender, EventArgs e) {
            textBoxSubCategoria.Enabled = checkBoxSubCategoria.Checked;
            SetPreencher();
        }

        private void checkBoxDescricao_CheckedChanged(object sender, EventArgs e) {
            textBoxDescricao.Enabled = checkBoxDescricao.Checked;
            SetPreencher();
        }

        private void SetPreencher() {
            buttonPreencher.Enabled = checkBoxGrupo.Checked || checkBoxCategoria.Checked || checkBoxSubCategoria.Checked || checkBoxDescricao.Checked;
        }
    }
}
