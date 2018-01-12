namespace BilancioFenealgest.UI.UIComponents
{
    partial class FrmRendicontoHeader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProprietario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.txtProprietario = new DevExpress.XtraEditors.TextEdit();
            this.grpNomeFile = new DevExpress.XtraEditors.GroupControl();
            this.grpTipo = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.groupBox2 = new DevExpress.XtraEditors.GroupControl();
            this.cboProvincia = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboRegione = new DevExpress.XtraEditors.ComboBoxEdit();
            this.numericUpDown1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProprietario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNomeFile)).BeginInit();
            this.grpNomeFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTipo)).BeginInit();
            this.grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRegione.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProprietario
            // 
            this.lblProprietario.AutoSize = true;
            this.lblProprietario.Location = new System.Drawing.Point(10, 41);
            this.lblProprietario.Name = "lblProprietario";
            this.lblProprietario.Size = new System.Drawing.Size(50, 13);
            this.lblProprietario.TabIndex = 0;
            this.lblProprietario.Text = "Feneal di";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Esercizio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Provincia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Regione";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Inserire il nome del file che si desidera creare.";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(188, 330);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(272, 330);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Annulla";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 20);
            this.textBox1.TabIndex = 1;
            // 
            // txtProprietario
            // 
            this.txtProprietario.Location = new System.Drawing.Point(74, 33);
            this.txtProprietario.Name = "txtProprietario";
            this.txtProprietario.Size = new System.Drawing.Size(242, 20);
            this.txtProprietario.TabIndex = 8;
            this.txtProprietario.EditValueChanged += new System.EventHandler(this.txtProprietario_TextChanged);
            // 
            // grpNomeFile
            // 
            this.grpNomeFile.Controls.Add(this.textBox1);
            this.grpNomeFile.Controls.Add(this.label4);
            this.grpNomeFile.Location = new System.Drawing.Point(13, 241);
            this.grpNomeFile.Name = "grpNomeFile";
            this.grpNomeFile.Size = new System.Drawing.Size(336, 76);
            this.grpNomeFile.TabIndex = 7;
            this.grpNomeFile.Text = "Nome file";
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.radioGroup1);
            this.grpTipo.Location = new System.Drawing.Point(13, 9);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(336, 59);
            this.grpTipo.TabIndex = 8;
            this.grpTipo.Text = "TipoRendiconto";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.EditValue = true;
            this.radioGroup1.Location = new System.Drawing.Point(2, 22);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Provinciale"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Regionale")});
            this.radioGroup1.Size = new System.Drawing.Size(332, 35);
            this.radioGroup1.TabIndex = 2;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboProvincia);
            this.groupBox2.Controls.Add(this.cboRegione);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.txtProprietario);
            this.groupBox2.Controls.Add(this.lblProprietario);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 158);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.Text = "Dati rendiconto";
            // 
            // cboProvincia
            // 
            this.cboProvincia.Location = new System.Drawing.Point(74, 125);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProvincia.Size = new System.Drawing.Size(242, 20);
            this.cboProvincia.TabIndex = 11;
            // 
            // cboRegione
            // 
            this.cboRegione.Location = new System.Drawing.Point(74, 96);
            this.cboRegione.Name = "cboRegione";
            this.cboRegione.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRegione.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRegione.Size = new System.Drawing.Size(242, 20);
            this.cboRegione.TabIndex = 10;
            this.cboRegione.SelectedIndexChanged += new System.EventHandler(this.cboRegione_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.EditValue = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(74, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.numericUpDown1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numericUpDown1.Properties.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numericUpDown1.Properties.MinValue = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // FrmRendicontoHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.grpNomeFile);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRendicontoHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendiconto Feneal";
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProprietario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNomeFile)).EndInit();
            this.grpNomeFile.ResumeLayout(false);
            this.grpNomeFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTipo)).EndInit();
            this.grpTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRegione.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblProprietario;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.SimpleButton cmdClose;
        private DevExpress.XtraEditors.TextEdit txtProprietario;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraEditors.GroupControl grpNomeFile;
        private DevExpress.XtraEditors.GroupControl grpTipo;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.GroupControl groupBox2;
        private DevExpress.XtraEditors.ComboBoxEdit cboProvincia;
        private DevExpress.XtraEditors.ComboBoxEdit cboRegione;
        private DevExpress.XtraEditors.SpinEdit numericUpDown1;
    }
}