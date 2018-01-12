using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.BILANCIO.PresentationLogicComponents;
using System.Xml;
using BilancioFenealgest.Middleware;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmExportBilancio : XtraForm, IFrmExportBilancio, IBasePresentation
    {
        ExportBilancioPresenter _presenter;

        public FrmExportBilancio()
        {
            InitializeComponent();
        }

    

        #region IFrmExportBilancio Membri di

        public string UserName
        {
            get { return txtUser.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        #endregion

        #region IBasePresentation Membri di

        public IMessageBox GetSimpleMessageNotificator()
        {
            return new DesktopMessageBox();
        }

        public IOpenFileClass GetOpenFileDialog()
        {
            throw new NotImplementedException();
        }

        public IOpenFileClass GetFolderBrowserDialog()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IFrmExportBilancio Membri di


        public void SetPresenter(ExportBilancioPresenter presenter)
        {
            _presenter = presenter;
        }

        #endregion

        #region IFrmExportBilancio Membri di


        public void ShowDialogMode()
        {
            this.ShowDialog();
        }

        #endregion

        private void cmdSend_Click(object sender, EventArgs e)
        {
           
            
        }

        private void FrmExportBilancio_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        #region IFrmExportBilancio Membri di


        public bool IsRlst
        {
            get { return Properties.Settings.Default.IsRlst; }
        }

        public bool IsFeneal
        {
            get { return Properties.Settings.Default.IsFeneal; }
        }

        #endregion

        private void cmdSend1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdSend.Enabled = false;
                cmdClose.Enabled = false;
                lblAttesa.Text = "Attendere...";
                System.Windows.Forms.Application.DoEvents();
                _presenter.SendBilancio();

            }
            finally
            {
                cmdSend.Enabled = true;
                cmdClose.Enabled = true;
                lblAttesa.Text = "";
            }
        }

        private void cmdClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
