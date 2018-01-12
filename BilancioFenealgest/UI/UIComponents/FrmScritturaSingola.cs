using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BilancioFenealgest.UI.PresentationLogicComponents;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmScritturaSingola : XtraForm, IScritturaSingloaView
    {
        ScritturaSingolaPresenter _presenter;
        private DevDesktopComboConto combo;
        private string selectedConto = SELECT_CONTO;

        private static readonly string SELECT_CONTO= "(Seleziona una contropartita)";

        string _banca1;
        string _banca2;
        string _banca3;

        string _banca4;
        string _banca5;
        string _banca6;


        public FrmScritturaSingola(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            InitializeComponent();

            _banca1 = banca1;
            _banca2 = banca2;
            _banca3 = banca3;

            _banca4 = banca4;
            _banca5 = banca5;
            _banca6 = banca6;
        }

        #region IScritturaSingloaView Membri di

        public string Banca1
        {
            get
            {
                return _banca1;
            }
        }

        public string Banca2
        {
            get
            {
                return _banca2;
            }
        }

        public string Banca3
        {
            get
            {
                return _banca3;
            }
        }


        public string Banca4
        {
            get
            {
                return _banca4;
            }
        }

        public string Banca5
        {
            get
            {
                return _banca5;
            }
        }

        public string Banca6
        {
            get
            {
                return _banca6;
            }
        }
       



        public string SelectedCausale
        {
            get
            {
                return txtCausale.Text;
            }
            set
            {
                txtCausale .Text = value;
            }
        }

        public string SelectedNumeroPezza
        {
            get
            {
                return txtPezza.Text ;
            }
            set
            {
                txtPezza.Text = value ;
            }
        }

        public decimal SelecteImporto
        {
            get
            {
                return numImp.Value ;
            }
            set
            {
                numImp .Value = value;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return dtpDate.DateTime;
            }
            set
            {
                dtpDate.EditValue = value;
            }
        }

       

        public void SetPresenter(ScritturaSingolaPresenter presenter)
        {
            _presenter = presenter;
        }

        public BilancioFenealgest.Middleware.ILookupList ComboTipoOperazione
        {
            get
            {
                if (combo == null)
                    combo = new DevDesktopComboConto(cboTipo, Banca1, _banca2, _banca3, _banca4, _banca5, _banca6);
                return combo;
            }
        }


        public bool ShowAndContinue()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }

        #endregion

       

        #region IBasePresentation Membri di

        public BilancioFenealgest.Middleware.IMessageBox GetSimpleMessageNotificator()
        {
            return new DesktopMessageBox ();
        }

        public BilancioFenealgest.Middleware.IOpenFileClass GetOpenFileDialog()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IScritturaSingloaView Membri di


        public bool IsContainerEnabled
        {
            set { groupBox1.Enabled = value ; }
        }

        #endregion

        #region IScritturaSingloaView Membri di


        public bool IsOkButtonEnabled
        {
            set { cmdOk.Enabled = value; }
        }

        #endregion

     

        #region IScritturaSingloaView Membri di


        public bool IsRecreateNewButtonEnabled
        {
            set { button1.Enabled = value; }
        }

        #endregion

        #region IScritturaSingloaView Membri di


        public void SetInitialFocus()
        {
            dtpDate.Focus();
        }

        #endregion

        #region IBasePresentation Membri di


        public BilancioFenealgest.Middleware.IOpenFileClass GetFolderBrowserDialog()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void numImp_Enter(object sender, EventArgs e)
        {
            numImp.Select(0, numImp.Text.Length);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.AddAndRecreeteNew();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (!CheckOperazioneDiCassa())
                _presenter.CreateOrUpdateScrittura();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmScritturaSingola_Load(object sender, EventArgs e)
        {
           // dtpDate.EditValue = DateTime.Now;
        }

        private void numImp_Leave(object sender, EventArgs e)
        {
            //CheckOperazioneDiCassa();
        }

        //private bool CheckOperazioneDiCassa()
        //{
        //    if (numImp.Value >= 1000)
        //        if (lblContropartita.Text == "Cassa")
        //        {
        //            XtraMessageBox.Show("Attenzione! Le scritture di cassa non possono superare i 1.000 Euro!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return false;
        //        }


        //    return true;
        //}

        private void cboTipo_EditValueChanged(object sender, EventArgs e)
        {
            //if (lblContropartita.Text == "Cassa")
            //     if (numImp.Value >= 1000)
            //         XtraMessageBox.Show("Attenzione! Le scritture di cassa non possono superare i 1.000 Euro!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        public WIN.BILANCIO.PresentationLogicComponents.IFrmContropartita GetFrmContropartita
        {
            get { return new FrmContropartita(_banca1, _banca2, _banca3, _banca4, _banca5, _banca6); }
        }

        private void cboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            
               
           
        }


        public void ShowContropartitaDetails(string nomeConto)
        {
            layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblContropartita.Text = nomeConto;
            lblContropartita.Tag = "";
        }

        public void HideContropartitadetails()
        {
            layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }


        public void ShowPropertyInLayout(string property)
        {
            if (property == "Deleghe")
            {
                layoutSettore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutEnte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutPersonale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (property == "Personale")
            {
                layoutSettore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutEnte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutPersonale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutSettore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutEnte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutPersonale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            
        }


        public Middleware.ILookupList ComboEnte
        {
            get { return new DevDesktopCombo(cboEnte); }
        }

        public Middleware.ILookupList ComboPersonale
        {
            get { return new DevDesktopCombo(cboPersonale); }
        }

        public Middleware.ILookupList ComboSettore
        {
            get { return new DevDesktopCombo(cboSettore); }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.PrepareChooseContropartita();
        }

        private void cboTipo_QueryCloseUp(object sender, CancelEventArgs e)
        {
             PopupListBox list = (sender as IPopupControl).PopupWindow.Controls[0] as PopupListBox;
             bool isEqualSelected  = list.SelectedItem .Equals( selectedConto) &&  !list.SelectedItem.Equals(SELECT_CONTO);
             selectedConto = list.SelectedItem.ToString();
            if (isEqualSelected)
                _presenter.PrepareChooseContropartita();
            e.Cancel = false;
   
        }
    }
}
