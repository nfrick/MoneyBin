using System;
using System.Windows.Forms;

namespace MoneyBin {
    public partial class frmProgressBar : Form {

        public frmProgressBar() {
            InitializeComponent();
        }

        public int Maximum {
            get => progressBar1.Maximum;
            set => progressBar1.Maximum = value;
        }

        public void UpdateProgress() {
            UpdateProgressBar();
        }

        public void UpdateProgress(int progress) {
            UpdateProgressBar(progress);
        }

        public void UpdateProgress(int progress, string label) {
            UpdateProgressBar(progress);
            UpdateLabel1(label);
        }

        public void UpdateProgress(string label) {
            UpdateProgressBar();
            UpdateLabel1(label);
        }

        private void UpdateProgressBar() {
            progressBar1.BeginInvoke(
            new Action(() => { progressBar1.Increment(1); }));
            labelProgresso.BeginInvoke(new Action(() => { labelProgresso.Text = $@"{progressBar1.Value} of {progressBar1.Maximum}"; }));
        }

        private void UpdateProgressBar(int progress) {
            progressBar1.BeginInvoke(
            new Action(() => { progressBar1.Value = progress; } ));
        }

        private void UpdateLabel1(string label) {
            labelMessage.BeginInvoke( new Action(() => { labelMessage.Text = label; } ));
        }
    }
}
