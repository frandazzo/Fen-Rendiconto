using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.BILANCIO.PresentationLogicComponents;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmContropartita : DevExpress.XtraEditors.XtraForm, IFrmContropartita
    {
        private FrmContropartitaPresenter _presenter;

        string _banca1;
        string _banca2;
        string _banca3;
        string _banca4;
        string _banca5;
        string _banca6;

        public FrmContropartita(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            InitializeComponent();
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
            _banca1 = banca1;
            _banca2 = banca2;
            _banca3 = banca3;

            _banca4 = banca4;
            _banca5 = banca5;
            _banca6 = banca6;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            _presenter.SelectConto();
            
        }
        public void SetDialogoResultToOK()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public Middleware.IIerarchicalContainer IerarchicalContainer
        {
            get { return new DesktopTreelist(treeListView1, _banca1, _banca2, _banca3, _banca4, _banca5, _banca6); }
        }

        public bool ShowAndContinue()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }

    

        public void SetPresenter(FrmContropartitaPresenter frmContropartitaPresenter)
        {
            _presenter = frmContropartitaPresenter;
        }

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

        private void FrmContropartita_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }
    }
}