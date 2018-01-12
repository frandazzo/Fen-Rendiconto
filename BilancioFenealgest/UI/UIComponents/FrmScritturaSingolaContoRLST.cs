using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.BILANCIO.PresentationLogicComponents;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmScritturaSingolaContoRLST : Form, IScritturaSingolaContoRLSTFormView
    {
        ScritturaSingolaContoRLSTPresenter _presenter;


        public FrmScritturaSingolaContoRLST()
        {
            InitializeComponent();
        }

        #region IScritturaSingloaView Membri di

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
                return dtpDate.Value.Date;
            }
            set
            {
                dtpDate.Value = value;
            }
        }

       

        public void SetPresenter(ScritturaSingolaContoRLSTPresenter presenter)
        {
            _presenter = presenter;
        }

        public BilancioFenealgest.Middleware.ILookupList ComboTipoOperazione
        {
            get { return new DesktopCombo(cboTipo); }
        }


        public bool ShowAndContinue()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }

        #endregion

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _presenter.CreateOrUpdateScrittura();


           // this.DialogResult = DialogResult.OK;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.AddAndRecreeteNew();

        }

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

     

        private void numImp_Enter_1(object sender, EventArgs e)
        {
  numImp.Select(0, numImp.Text.Length);
        }
    }
}