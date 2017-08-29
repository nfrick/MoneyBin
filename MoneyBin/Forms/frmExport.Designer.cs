namespace MoneyBin {
    partial class frmExport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBoxSaveAs = new System.Windows.Forms.TextBox();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMid = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // textBoxSaveAs
            // 
            this.textBoxSaveAs.Enabled = false;
            this.textBoxSaveAs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaveAs.Location = new System.Drawing.Point(95, 76);
            this.textBoxSaveAs.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSaveAs.Name = "textBoxSaveAs";
            this.textBoxSaveAs.Size = new System.Drawing.Size(479, 26);
            this.textBoxSaveAs.TabIndex = 0;
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCSV.Location = new System.Drawing.Point(16, 15);
            this.radioButtonCSV.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(55, 23);
            this.radioButtonCSV.TabIndex = 2;
            this.radioButtonCSV.TabStop = true;
            this.radioButtonCSV.Text = "CSV";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            this.radioButtonCSV.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 139);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(640, 28);
            this.progressBar1.TabIndex = 3;
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.AutoSize = true;
            this.radioButtonXML.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonXML.Location = new System.Drawing.Point(16, 43);
            this.radioButtonXML.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(58, 23);
            this.radioButtonXML.TabIndex = 4;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = "XML";
            this.radioButtonXML.UseVisualStyleBackColor = true;
            this.radioButtonXML.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(583, 15);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 64);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMin.Location = new System.Drawing.Point(16, 119);
            this.labelMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(17, 19);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "0";
            // 
            // labelMid
            // 
            this.labelMid.AutoSize = true;
            this.labelMid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMid.Location = new System.Drawing.Point(317, 119);
            this.labelMid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMid.Name = "labelMid";
            this.labelMid.Size = new System.Drawing.Size(61, 19);
            this.labelMid.TabIndex = 7;
            this.labelMid.Text = "labelMid";
            this.labelMid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax.Location = new System.Drawing.Point(619, 119);
            this.labelMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(63, 19);
            this.labelMax.TabIndex = 8;
            this.labelMax.Text = "labelMax";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveAs.Location = new System.Drawing.Point(16, 76);
            this.buttonSaveAs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(71, 27);
            this.buttonSaveAs.TabIndex = 9;
            this.buttonSaveAs.Text = "Save as";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(673, 175);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMid);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.radioButtonXML);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButtonCSV);
            this.Controls.Add(this.textBoxSaveAs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSaveAs;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButtonXML;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMid;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}