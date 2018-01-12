namespace BilancioFenealgest.UI.UIComponents
{
    partial class FrmScritturaSingola
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
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboPersonale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboEnte = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboSettore = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblContropartita = new DevExpress.XtraEditors.LabelControl();
            this.txtCausale = new DevExpress.XtraEditors.MemoEdit();
            this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
            this.numImp = new DevExpress.XtraEditors.SpinEdit();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtPezza = new DevExpress.XtraEditors.TextEdit();
            this.cboTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSettore = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutEnte = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutPersonale = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEnte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSettore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCausale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPezza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSettore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEnte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPersonale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 22);
            this.button1.StyleController = this.layoutControl1;
            this.button1.TabIndex = 4;
            this.button1.Text = "&Aggiungi e crea nuova";
            this.button1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboPersonale);
            this.layoutControl1.Controls.Add(this.cboEnte);
            this.layoutControl1.Controls.Add(this.cboSettore);
            this.layoutControl1.Controls.Add(this.lblContropartita);
            this.layoutControl1.Controls.Add(this.txtCausale);
            this.layoutControl1.Controls.Add(this.cmdClose);
            this.layoutControl1.Controls.Add(this.numImp);
            this.layoutControl1.Controls.Add(this.cmdOk);
            this.layoutControl1.Controls.Add(this.txtPezza);
            this.layoutControl1.Controls.Add(this.button1);
            this.layoutControl1.Controls.Add(this.cboTipo);
            this.layoutControl1.Controls.Add(this.dtpDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 22);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(609, 49, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(287, 319);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboPersonale
            // 
            this.cboPersonale.Location = new System.Drawing.Point(65, 179);
            this.cboPersonale.Name = "cboPersonale";
            this.cboPersonale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersonale.Size = new System.Drawing.Size(210, 20);
            this.cboPersonale.StyleController = this.layoutControl1;
            this.cboPersonale.TabIndex = 12;
            // 
            // cboEnte
            // 
            this.cboEnte.Location = new System.Drawing.Point(65, 155);
            this.cboEnte.Name = "cboEnte";
            this.cboEnte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEnte.Size = new System.Drawing.Size(210, 20);
            this.cboEnte.StyleController = this.layoutControl1;
            this.cboEnte.TabIndex = 11;
            // 
            // cboSettore
            // 
            this.cboSettore.Location = new System.Drawing.Point(65, 131);
            this.cboSettore.Name = "cboSettore";
            this.cboSettore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSettore.Size = new System.Drawing.Size(210, 20);
            this.cboSettore.StyleController = this.layoutControl1;
            this.cboSettore.TabIndex = 10;
            // 
            // lblContropartita
            // 
            this.lblContropartita.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContropartita.Location = new System.Drawing.Point(12, 60);
            this.lblContropartita.Name = "lblContropartita";
            this.lblContropartita.Size = new System.Drawing.Size(263, 13);
            this.lblContropartita.StyleController = this.layoutControl1;
            this.lblContropartita.TabIndex = 9;
            // 
            // txtCausale
            // 
            this.txtCausale.Location = new System.Drawing.Point(65, 203);
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.Size = new System.Drawing.Size(210, 76);
            this.txtCausale.StyleController = this.layoutControl1;
            this.txtCausale.TabIndex = 8;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(209, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(66, 22);
            this.cmdClose.StyleController = this.layoutControl1;
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "&Chiudi";
            this.cmdClose.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // numImp
            // 
            this.numImp.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numImp.Location = new System.Drawing.Point(65, 101);
            this.numImp.Name = "numImp";
            this.numImp.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.numImp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numImp.Properties.Appearance.Options.UseFont = true;
            this.numImp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numImp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numImp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numImp.Properties.MaxValue = new decimal(new int[] {
            99000000,
            0,
            0,
            0});
            this.numImp.Properties.MinValue = new decimal(new int[] {
            99000000,
            0,
            0,
            -2147483648});
            this.numImp.Size = new System.Drawing.Size(210, 26);
            this.numImp.StyleController = this.layoutControl1;
            this.numImp.TabIndex = 7;
            this.numImp.Leave += new System.EventHandler(this.numImp_Leave);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(142, 285);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(63, 22);
            this.cmdOk.StyleController = this.layoutControl1;
            this.cmdOk.TabIndex = 5;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtPezza
            // 
            this.txtPezza.Location = new System.Drawing.Point(65, 77);
            this.txtPezza.Name = "txtPezza";
            this.txtPezza.Size = new System.Drawing.Size(210, 20);
            this.txtPezza.StyleController = this.layoutControl1;
            this.txtPezza.TabIndex = 6;
            // 
            // cboTipo
            // 
            this.cboTipo.EditValue = "";
            this.cboTipo.Location = new System.Drawing.Point(65, 36);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipo.Size = new System.Drawing.Size(210, 20);
            this.cboTipo.StyleController = this.layoutControl1;
            this.cboTipo.TabIndex = 5;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            this.cboTipo.SelectedValueChanged += new System.EventHandler(this.cboTipo_SelectedValueChanged);
            this.cboTipo.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.cboTipo_QueryCloseUp);
            this.cboTipo.EditValueChanged += new System.EventHandler(this.cboTipo_EditValueChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = null;
            this.dtpDate.Location = new System.Drawing.Point(65, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDate.Size = new System.Drawing.Size(210, 20);
            this.dtpDate.StyleController = this.layoutControl1;
            this.dtpDate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.simpleSeparator1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutSettore,
            this.layoutEnte,
            this.layoutPersonale});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(287, 319);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtpDate;
            this.layoutControlItem1.CustomizationFormText = "Data";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(267, 24);
            this.layoutControlItem1.Text = "Data";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboTipo;
            this.layoutControlItem2.CustomizationFormText = "Tipo op.";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(267, 24);
            this.layoutControlItem2.Text = "Controp.";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPezza;
            this.layoutControlItem3.CustomizationFormText = "Num. doc.";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 65);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(267, 24);
            this.layoutControlItem3.Text = "Num. doc.";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.numImp;
            this.layoutControlItem4.CustomizationFormText = "Importo";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 89);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(267, 30);
            this.layoutControlItem4.Text = "Importo";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtCausale;
            this.layoutControlItem5.CustomizationFormText = "Causale";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 191);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(267, 80);
            this.layoutControlItem5.Text = "Causale";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(49, 13);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 271);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(267, 2);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.button1;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 273);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmdOk;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(130, 273);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(67, 26);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.cmdClose;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(197, 273);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(70, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lblContropartita;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem9.CustomizationFormText = "_";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(267, 17);
            this.layoutControlItem9.Text = "_";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutSettore
            // 
            this.layoutSettore.Control = this.cboSettore;
            this.layoutSettore.CustomizationFormText = "Settore";
            this.layoutSettore.Location = new System.Drawing.Point(0, 119);
            this.layoutSettore.Name = "layoutSettore";
            this.layoutSettore.Size = new System.Drawing.Size(267, 24);
            this.layoutSettore.Text = "Settore";
            this.layoutSettore.TextSize = new System.Drawing.Size(49, 13);
            this.layoutSettore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutEnte
            // 
            this.layoutEnte.Control = this.cboEnte;
            this.layoutEnte.CustomizationFormText = "Ente";
            this.layoutEnte.Location = new System.Drawing.Point(0, 143);
            this.layoutEnte.Name = "layoutEnte";
            this.layoutEnte.Size = new System.Drawing.Size(267, 24);
            this.layoutEnte.Text = "Ente";
            this.layoutEnte.TextSize = new System.Drawing.Size(49, 13);
            this.layoutEnte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutPersonale
            // 
            this.layoutPersonale.Control = this.cboPersonale;
            this.layoutPersonale.CustomizationFormText = "Personale";
            this.layoutPersonale.Location = new System.Drawing.Point(0, 167);
            this.layoutPersonale.Name = "layoutPersonale";
            this.layoutPersonale.Size = new System.Drawing.Size(267, 24);
            this.layoutPersonale.Text = "Personale";
            this.layoutPersonale.TextSize = new System.Drawing.Size(49, 13);
            this.layoutPersonale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 343);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.Text = "Scrittura";
            // 
            // FrmScritturaSingola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 367);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmScritturaSingola";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creazione / aggiornamento scrittura";
            this.Load += new System.EventHandler(this.FrmScritturaSingola_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEnte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSettore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCausale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPezza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSettore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEnte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPersonale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.SimpleButton cmdClose;
        private DevExpress.XtraEditors.GroupControl groupBox1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit txtCausale;
        private DevExpress.XtraEditors.SpinEdit numImp;
        private DevExpress.XtraEditors.TextEdit txtPezza;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.LabelControl lblContropartita;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.ComboBoxEdit cboPersonale;
        private DevExpress.XtraEditors.ComboBoxEdit cboEnte;
        private DevExpress.XtraEditors.ComboBoxEdit cboSettore;
        private DevExpress.XtraLayout.LayoutControlItem layoutSettore;
        private DevExpress.XtraLayout.LayoutControlItem layoutEnte;
        private DevExpress.XtraLayout.LayoutControlItem layoutPersonale;
    }
}