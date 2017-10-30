namespace MoneyBin {
    partial class dlgReportBalanceOptions {
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
            this.dateTimePickerTermino = new System.Windows.Forms.DateTimePicker();
            this.labelTermino = new System.Windows.Forms.Label();
            this.labelInicio = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBanco = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePickerTermino
            // 
            this.dateTimePickerTermino.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTermino.Location = new System.Drawing.Point(210, 137);
            this.dateTimePickerTermino.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dateTimePickerTermino.Name = "dateTimePickerTermino";
            this.dateTimePickerTermino.Size = new System.Drawing.Size(131, 30);
            this.dateTimePickerTermino.TabIndex = 16;
            // 
            // labelTermino
            // 
            this.labelTermino.AutoSize = true;
            this.labelTermino.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermino.Location = new System.Drawing.Point(206, 105);
            this.labelTermino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTermino.Name = "labelTermino";
            this.labelTermino.Size = new System.Drawing.Size(63, 20);
            this.labelTermino.TabIndex = 18;
            this.labelTermino.Text = "Término";
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicio.Location = new System.Drawing.Point(206, 25);
            this.labelInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(45, 20);
            this.labelInicio.TabIndex = 17;
            this.labelInicio.Text = "Início";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(210, 59);
            this.dateTimePickerInicio.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(131, 30);
            this.dateTimePickerInicio.TabIndex = 15;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(53, 191);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 40);
            this.buttonOK.TabIndex = 21;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttons_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(189, 191);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 40);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttons_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Banco";
            // 
            // comboBoxBanco
            // 
            this.comboBoxBanco.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBanco.FormattingEnabled = true;
            this.comboBoxBanco.Items.AddRange(new object[] {
            "BB",
            "CEF",
            "STD"});
            this.comboBoxBanco.Location = new System.Drawing.Point(29, 57);
            this.comboBoxBanco.Name = "comboBoxBanco";
            this.comboBoxBanco.Size = new System.Drawing.Size(114, 31);
            this.comboBoxBanco.TabIndex = 25;
            this.comboBoxBanco.Text = "BB";
            this.comboBoxBanco.SelectedValueChanged += new System.EventHandler(this.comboBoxBanco_SelectedValueChanged);
            // 
            // dlgReportBalanceOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(370, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBanco);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dateTimePickerTermino);
            this.Controls.Add(this.labelTermino);
            this.Controls.Add(this.labelInicio);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "dlgReportBalanceOptions";
            this.Text = "Opções";
            this.Load += new System.EventHandler(this.dlgReportBalanceOptions_Load);
            this.Click += new System.EventHandler(this.buttons_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerTermino;
        private System.Windows.Forms.Label labelTermino;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBanco;
    }
}