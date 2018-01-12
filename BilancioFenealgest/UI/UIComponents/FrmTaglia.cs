using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.BILANCIO.PresentationLogicComponents;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmTaglia : XtraForm, IFrmTaglia
    {
        private FrmTagliaPresenter _presenter;

        string _banca1;
        string _banca2;
        string _banca3;

        string _banca4;
        string _banca5;
        string _banca6;

        public FrmTaglia(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            InitializeComponent();
            _banca1 = banca1;
            _banca2 = banca2;
            _banca3 = banca3;


            _banca4 = banca4;
            _banca5 = banca5;
            _banca6 = banca6;
        }

        public void SetPresenter(FrmTagliaPresenter presenter)
        {
            _presenter = presenter;
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        #region IFrmTaglia Membri di

        public BilancioFenealgest.Middleware.IIerarchicalContainer IerarchicalContainer
        {
            get { return new DesktopTreelist(treeListView1, _banca1, _banca2, _banca3, _banca4, _banca5, _banca6); }
        }

      

       
        public bool ShowAndContinue()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }
        

        public BilancioFenealgest.Middleware.IMessageBox GetSimpleMessageNotificator()
        {
            return new DesktopMessageBox();
        }

        public BilancioFenealgest.Middleware.IOpenFileClass GetOpenFileDialog()
        {
            throw new NotImplementedException();
        }

        public BilancioFenealgest.Middleware.IOpenFileClass GetFolderBrowserDialog()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.PasteData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkAcc.Checked)
        //    {
        //        chkCass.Checked = false;
        //        panel1.Enabled = false;
        //    }
        //    else
        //    {
        //        panel1.Enabled = true;
        //    }
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkCass.Checked)
        //    {
        //        chkAcc.Checked = false;
        //        panel1.Enabled = false;
        //    }
        //    else
        //    {
        //        panel1.Enabled = true;
        //    }
        //}

 }
}
