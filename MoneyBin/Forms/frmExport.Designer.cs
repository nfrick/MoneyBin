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
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonPickFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAcertos = new System.Windows.Forms.RadioButton();
            this.radioButtonExcel = new System.Windows.Forms.RadioButton();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.radioButtonExtrato = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSaveAs
            // 
            this.textBoxSaveAs.Enabled = false;
            this.textBoxSaveAs.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaveAs.Location = new System.Drawing.Point(19, 130);
            this.textBoxSaveAs.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBoxSaveAs.Name = "textBoxSaveAs";
            this.textBoxSaveAs.Size = new System.Drawing.Size(676, 30);
            this.textBoxSaveAs.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonExport.Location = new System.Drawing.Point(626, 14);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(113, 54);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonPickFile
            // 
            this.buttonPickFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPickFile.Location = new System.Drawing.Point(703, 130);
            this.buttonPickFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonPickFile.Name = "buttonPickFile";
            this.buttonPickFile.Size = new System.Drawing.Size(36, 30);
            this.buttonPickFile.TabIndex = 9;
            this.buttonPickFile.Text = "...";
            this.buttonPickFile.UseVisualStyleBackColor = true;
            this.buttonPickFile.Click += new System.EventHandler(this.buttonPickFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonExtrato);
            this.groupBox1.Controls.Add(this.radioButtonAcertos);
            this.groupBox1.Controls.Add(this.radioButtonExcel);
            this.groupBox1.Controls.Add(this.radioButtonXML);
            this.groupBox1.Controls.Add(this.radioButtonCSV);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(542, 101);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format";
            // 
            // radioButtonAcertos
            // 
            this.radioButtonAcertos.AutoSize = true;
            this.radioButtonAcertos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAcertos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonAcertos.Location = new System.Drawing.Point(167, 58);
            this.radioButtonAcertos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonAcertos.Name = "radioButtonAcertos";
            this.radioButtonAcertos.Size = new System.Drawing.Size(172, 27);
            this.radioButtonAcertos.TabIndex = 17;
            this.radioButtonAcertos.TabStop = true;
            this.radioButtonAcertos.Text = "Acertos Pendentes";
            this.radioButtonAcertos.UseVisualStyleBackColor = true;
            this.radioButtonAcertos.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonExcel
            // 
            this.radioButtonExcel.AutoSize = true;
            this.radioButtonExcel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonExcel.Location = new System.Drawing.Point(167, 27);
            this.radioButtonExcel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonExcel.Name = "radioButtonExcel";
            this.radioButtonExcel.Size = new System.Drawing.Size(69, 27);
            this.radioButtonExcel.TabIndex = 16;
            this.radioButtonExcel.TabStop = true;
            this.radioButtonExcel.Text = "Excel";
            this.radioButtonExcel.UseVisualStyleBackColor = true;
            this.radioButtonExcel.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.AutoSize = true;
            this.radioButtonXML.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonXML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonXML.Location = new System.Drawing.Point(24, 58);
            this.radioButtonXML.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(64, 27);
            this.radioButtonXML.TabIndex = 15;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = "XML";
            this.radioButtonXML.UseVisualStyleBackColor = true;
            this.radioButtonXML.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCSV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonCSV.Location = new System.Drawing.Point(24, 27);
            this.radioButtonCSV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(62, 27);
            this.radioButtonCSV.TabIndex = 14;
            this.radioButtonCSV.TabStop = true;
            this.radioButtonCSV.Text = "CSV";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            this.radioButtonCSV.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonExtrato
            // 
            this.radioButtonExtrato.AutoSize = true;
            this.radioButtonExtrato.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExtrato.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonExtrato.Location = new System.Drawing.Point(376, 27);
            this.radioButtonExtrato.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonExtrato.Name = "radioButtonExtrato";
            this.radioButtonExtrato.Size = new System.Drawing.Size(150, 27);
            this.radioButtonExtrato.TabIndex = 18;
            this.radioButtonExtrato.TabStop = true;
            this.radioButtonExtrato.Text = "Extrato (Access)";
            this.radioButtonExtrato.UseVisualStyleBackColor = true;
            this.radioButtonExtrato.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(757, 174);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPickFile);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.textBoxSaveAs);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSaveAs;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonPickFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAcertos;
        private System.Windows.Forms.RadioButton radioButtonExcel;
        private System.Windows.Forms.RadioButton radioButtonXML;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.RadioButton radioButtonExtrato;
    }
}