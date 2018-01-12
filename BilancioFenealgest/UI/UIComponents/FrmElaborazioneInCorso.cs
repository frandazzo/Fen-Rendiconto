using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmElaborazioneInCorso : XtraForm
    {
        public bool Annulla = false;

        public FrmElaborazioneInCorso()
        {
            InitializeComponent();
        }

        public void SetPercentageValue(int Perc)
        {
            if (Perc > 100)
                Perc = 100;

            this.ProgressBar1.Value = Perc;
            Application.DoEvents();
        }



        public void SetActivity(string text)
        {
            lblAttivita.Text = text;
        }


        public void EnableCancel(bool enable)
        {
            cmdAnnulla.Enabled = enable;
        }

        private void FrmElaborazioneInCorso_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private void FrmElaborazioneInCorso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Annulla = true;
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            Annulla = true;
            this.ControlBox = true;
        }
    }
}
