namespace BilancioFenealgest.UI.UIComponents
{
    partial class FrmScrittureContoRLST
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtPezza = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpA = new System.Windows.Forms.DateTimePicker();
            this.dtpDa = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.cmdCancelFilter = new System.Windows.Forms.Button();
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Conto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Causale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pezza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTask = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkAuto);
            this.panel1.Controls.Add(this.txtPezza);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCausale);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpA);
            this.panel1.Controls.Add(this.dtpDa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.cmdFilter);
            this.panel1.Controls.Add(this.cmdCancelFilter);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 115);
            this.panel1.TabIndex = 6;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(321, 72);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(178, 17);
            this.chkAuto.TabIndex = 9;
            this.chkAuto.Text = "Visualizza scritture autogenerate";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtPezza
            // 
            this.txtPezza.Location = new System.Drawing.Point(140, 68);
            this.txtPezza.Name = "txtPezza";
            this.txtPezza.Size = new System.Drawing.Size(139, 20);
            this.txtPezza.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cerca num. pezza";
            // 
            // txtCausale
            // 
            this.txtCausale.Location = new System.Drawing.Point(140, 42);
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.Size = new System.Drawing.Size(360, 20);
            this.txtCausale.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cerca nella causale";
            // 
            // dtpA
            // 
            this.dtpA.Enabled = false;
            this.dtpA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpA.Location = new System.Drawing.Point(386, 14);
            this.dtpA.Name = "dtpA";
            this.dtpA.Size = new System.Drawing.Size(114, 20);
            this.dtpA.TabIndex = 4;
            // 
            // dtpDa
            // 
            this.dtpDa.Enabled = false;
            this.dtpDa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDa.Location = new System.Drawing.Point(224, 13);
            this.dtpDa.Name = "dtpDa";
            this.dtpDa.Size = new System.Drawing.Size(114, 20);
            this.dtpDa.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "da";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(42, 16);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(130, 17);
            this.chkDate.TabIndex = 0;
            this.chkDate.Text = "Filtra per data scrittura";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFilter.Location = new System.Drawing.Point(654, 28);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 69);
            this.cmdFilter.TabIndex = 10;
            this.cmdFilter.Text = "&Filtra";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click_1);
            // 
            // cmdCancelFilter
            // 
            this.cmdCancelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelFilter.Location = new System.Drawing.Point(735, 28);
            this.cmdCancelFilter.Name = "cmdCancelFilter";
            this.cmdCancelFilter.Size = new System.Drawing.Size(75, 69);
            this.cmdCancelFilter.TabIndex = 11;
            this.cmdCancelFilter.Text = "Ri&muovi filtro";
            this.cmdCancelFilter.UseVisualStyleBackColor = true;
            this.cmdCancelFilter.Click += new System.EventHandler(this.cmdCancelFilter_Click_1);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(287, 545);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(110, 20);
            this.lblMessaggio.TabIndex = 10;
            this.lblMessaggio.Text = "Saldo conto:";
            // 
            // lblNumero
            // 
            this.lblNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(291, 525);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(118, 13);
            this.lblNumero.TabIndex = 9;
            this.lblNumero.Text = "Numero elementi trovati";
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.BackColor = System.Drawing.Color.White;
            this.lblEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.Location = new System.Drawing.Point(294, 170);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(255, 25);
            this.lblEmpty.TabIndex = 8;
            this.lblEmpty.Text = "Nessuna scrittura trovata";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conto,
            this.Data,
            this.Causale,
            this.Pezza,
            this.TipoOperazione,
            this.Importo});
            this.dataGridView1.Location = new System.Drawing.Point(3, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 397);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // Conto
            // 
            this.Conto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Conto.DataPropertyName = "ParentName";
            this.Conto.HeaderText = "Conto";
            this.Conto.Name = "Conto";
            this.Conto.ReadOnly = true;
            this.Conto.Width = 60;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Data.DataPropertyName = "Date";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 55;
            // 
            // Causale
            // 
            this.Causale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Causale.DataPropertyName = "Causale";
            this.Causale.HeaderText = "Causale";
            this.Causale.Name = "Causale";
            this.Causale.ReadOnly = true;
            // 
            // Pezza
            // 
            this.Pezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pezza.DataPropertyName = "NumeroPezza";
            this.Pezza.HeaderText = "Pezza contabile";
            this.Pezza.Name = "Pezza";
            this.Pezza.ReadOnly = true;
            this.Pezza.Width = 98;
            // 
            // TipoOperazione
            // 
            this.TipoOperazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TipoOperazione.DataPropertyName = "TipoOperazione";
            this.TipoOperazione.HeaderText = "Tipo operazione";
            this.TipoOperazione.Name = "TipoOperazione";
            this.TipoOperazione.ReadOnly = true;
            this.TipoOperazione.Width = 99;
            // 
            // Importo
            // 
            this.Importo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Importo.DataPropertyName = "Importo";
            this.Importo.HeaderText = "Importo";
            this.Importo.Name = "Importo";
            this.Importo.ReadOnly = true;
            this.Importo.Width = 67;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.cmdAdd);
            this.flowLayoutPanel1.Controls.Add(this.cmdRemove);
            this.flowLayoutPanel1.Controls.Add(this.cmdClose);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 520);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 50);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(3, 3);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(58, 35);
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "&Aggiungi";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(67, 3);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(58, 35);
            this.cmdRemove.TabIndex = 1;
            this.cmdRemove.Text = "&Rimuovi";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(131, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(58, 35);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "&Chiudi";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTask);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(254, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 125);
            this.panel2.TabIndex = 12;
            this.panel2.Visible = false;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTask.Location = new System.Drawing.Point(49, 91);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(20, 16);
            this.lblTask.TabIndex = 2;
            this.lblTask.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Esportazione in corso...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BilancioFenealgest.Properties.Resources.spinner2_white40;
            this.pictureBox1.Location = new System.Drawing.Point(74, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(195, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "E&sporta su excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmScrittureContoRLST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmScrittureContoRLST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmScrittureContoRLST";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtPezza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCausale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpA;
        private System.Windows.Forms.DateTimePicker dtpDa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Button cmdCancelFilter;
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Causale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pezza;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}