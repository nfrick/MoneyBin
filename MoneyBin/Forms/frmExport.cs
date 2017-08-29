using DataClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MoneyBin {
    public partial class frmExport : Form {

        List<BalanceItem> _items;

        public frmExport() {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e) {
            textBoxSaveAs.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\\Money Bin Export.csv";
            radioButtonCSV.Checked = true;
            _items = MoneyBinDB.GetBalanceItems();
            progressBar1.Maximum = _items.Count();
            labelMid.Text = (_items.Count / 2).ToString();
            labelMax.Text = _items.Count.ToString();
        }

        private void buttonSaveAs_Click(object sender, EventArgs e) {
            if (radioButtonCSV.Checked) {
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = @"CSV Files|*.csv";
            }
            else {
                saveFileDialog1.DefaultExt = "xml";
                saveFileDialog1.Filter = @"XML Files|*.xml";
            }
            var fInfo = new FileInfo(textBoxSaveAs.Text);
            saveFileDialog1.InitialDirectory = fInfo.DirectoryName;
            saveFileDialog1.FileName = fInfo.Name;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                textBoxSaveAs.Text = saveFileDialog1.FileName;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            //var fInfo = new FileInfo(textBoxSaveAs.Text);
            textBoxSaveAs.Text = Path.ChangeExtension(textBoxSaveAs.Text, radioButtonCSV.Checked ? "csv" : "xml");
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            if (radioButtonCSV.Checked)
                SaveAsCSV();
            else
                SaveAsXML();
        }

        private void SaveAsCSV() {
            var backgroundThread = new Thread(
                () => {
                    var sw = new StreamWriter(textBoxSaveAs.Text, false, Encoding.Default);
                    sw.WriteLine(BalanceItem.CSVHeader());
                    foreach (var b in _items) {
                        sw.WriteLine(b.ToCSV());
                        progressBar1.BeginInvoke(
                            new Action(() => {
                                    progressBar1.Increment(1);
                                }
                            ));
                    }
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.BeginInvoke(
                        new Action(() => {
                                progressBar1.Value = 0;
                            }
                        ));
                });
            backgroundThread.Start();
        }

        private void SaveAsXML() {
            try {
                var xEle = new XElement("Balance", _items.Select(b => b.toXML()));
                xEle.Save(textBoxSaveAs.Text);
                MessageBox.Show(@"Data exported.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, @"Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
