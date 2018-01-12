using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BilancioFenealgest.UI.PresentationLogicComponents;
using DevExpress.XtraEditors;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmSituazioneFianziaria : XtraForm, ISituazioneFianziariaformView
    {

        SituazioneFinanziariaPresenter _presenter;

        public FrmSituazioneFianziaria()
        {
            InitializeComponent();

            //label1.Text = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            //label3.Text = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            //label4.Text = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;

        }

        #region ISituazioneFianziariaformView Membri di

        public bool ShowAndContinue()
        {
            if (this.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        public void SetPresenter(SituazioneFinanziariaPresenter presenter)
        {
            _presenter = presenter;
        }

        public decimal SelectedBanca
        {
            get
            {
                return numBanca.Value;
            }
            set
            {
                numBanca.Value = value;
            }
        }

        public decimal SelectedAccantonamenti
        {
            get
            {
                return numAcc.Value;
            }
            set
            {
                numAcc.Value = value;
            }
        }

        public decimal SelectedCassa
        {
            get
            {
                return numCassa.Value;
            }
            set
            {
                numCassa.Value = value;
            }
        }

        public bool IsLabelCassaVisible
        {
            set { lblCassa.Visible = value; }
        }

        public bool IsNumUpDownCassaVisible
        {
            set { numCassa.Visible = value; ; }
        }

        public string ViewCaption
        {
            set { this.Text = value ; }
        }

        #endregion




        #region ISituazioneFianziariaformView Membri di


        public bool IsLabelAccantonamentoVisible
        {
            set { label2.Visible = value; }
        }

        public bool IsNumUpDownAccantonamentoVisible
        {
            set { numAcc.Visible = value; }
        }

        #endregion

        #region ISituazioneFianziariaformView Membri di


        public decimal SelectedBanca2
        {
            get
            {
                return numBanca2.Value;
            }
            set
            {
                numBanca2.Value = value;
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.UpdateFinanza();
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        public decimal SelectedBanca3
        {
            get
            {
                return numBanca3.Value;
            }
            set
            {
                numBanca3.Value = value;
            }
        }
    }
}
