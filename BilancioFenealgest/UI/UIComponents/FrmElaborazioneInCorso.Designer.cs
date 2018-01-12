namespace BilancioFenealgest.UI.UIComponents
{
    partial class FrmElaborazioneInCorso
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
            this.lblAttivita = new System.Windows.Forms.Label();
            this.cmdAnnulla = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblAttivita
            // 
            this.lblAttivita.AutoSize = true;
            this.lblAttivita.Location = new System.Drawing.Point(16, 43);
            this.lblAttivita.Name = "lblAttivita";
            this.lblAttivita.Size = new System.Drawing.Size(108, 13);
            this.lblAttivita.TabIndex = 9;
            this.lblAttivita.Text = "Elaborazione in corso";
            // 
            // cmdAnnulla
            // 
            this.cmdAnnulla.Location = new System.Drawing.Point(327, 12);
            this.cmdAnnulla.Name = "cmdAnnulla";
            this.cmdAnnulla.Size = new System.Drawing.Size(100, 24);
            this.cmdAnnulla.TabIndex = 8;
            this.cmdAnnulla.Text = "Annulla";
            this.cmdAnnulla.UseVisualStyleBackColor = true;
            this.cmdAnnulla.Click += new System.EventHandler(this.cmdAnnulla_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(12, 12);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(309, 24);
            this.ProgressBar1.TabIndex = 7;
            // 
            // FrmElaborazioneInCorso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 64);
            this.Controls.Add(this.lblAttivita);
            this.Controls.Add(this.cmdAnnulla);
            this.Controls.Add(this.ProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmElaborazioneInCorso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elaborazione in corso";
            this.Load += new System.EventHandler(this.FrmElaborazioneInCorso_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmElaborazioneInCorso_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblAttivita;
        internal System.Windows.Forms.Button cmdAnnulla;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
    }
}