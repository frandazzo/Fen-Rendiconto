namespace BilancioFenealgest.UI.UIComponents
{
    partial class FrmContropartita
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
            this.label1 = new System.Windows.Forms.Label();
            this.treeListView1 = new WinControls.ListView.TreeListView();
            this.containerColumnHeader1 = new WinControls.ListView.ContainerColumnHeader();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmdAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selezionare un conto di contropartita";
            // 
            // treeListView1
            // 
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.BorderStyle = WinControls.ListView.Enums.BorderStyleType.None;
            this.treeListView1.Columns.AddRange(new WinControls.ListView.ContainerColumnHeader[] {
            this.containerColumnHeader1});
            this.treeListView1.DefaultImageIndex = 2;
            this.treeListView1.DefaultSelectedImageIndex = 3;
            this.treeListView1.Location = new System.Drawing.Point(16, 31);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.PathSeparator = ".";
            this.treeListView1.Size = new System.Drawing.Size(432, 309);
            this.treeListView1.TabIndex = 4;
            this.treeListView1.VisualStyles = false;
            // 
            // containerColumnHeader1
            // 
            this.containerColumnHeader1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containerColumnHeader1.Text = "Conto";
            this.containerColumnHeader1.Width = 372;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(261, 351);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(92, 25);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdAnnulla
            // 
            this.cmdAnnulla.Location = new System.Drawing.Point(359, 351);
            this.cmdAnnulla.Name = "cmdAnnulla";
            this.cmdAnnulla.Size = new System.Drawing.Size(89, 25);
            this.cmdAnnulla.TabIndex = 6;
            this.cmdAnnulla.Text = "Annulla";
            this.cmdAnnulla.Click += new System.EventHandler(this.cmdAnnulla_Click);
            // 
            // FrmContropartita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 388);
            this.Controls.Add(this.cmdAnnulla);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmContropartita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleziona contropartita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContropartita_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private WinControls.ListView.TreeListView treeListView1;
        private WinControls.ListView.ContainerColumnHeader containerColumnHeader1;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.SimpleButton cmdAnnulla;
    }
}