using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BilancioFenealgest.UI.PresentationLogicComponents;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmImportoConto : XtraForm, IFrmContoView
    {

        ImportoContoPresenter _presenter;

        public FrmImportoConto()
        {
            InitializeComponent();
        }

        

        public decimal SelectedImporto
        {
            get
            {
                return num.Value;
            }
            set
            {
                num.Value = value;
            }
        }

       
        public void ShowDialogMode()
        {
            this.ShowDialog();
        }

      
        public void SetPresenter(ImportoContoPresenter importoContoPresenter)
        {
            _presenter = importoContoPresenter;
        }



        #region IFrmContoView Membri di


        public string CaptionText
        {
            set { this.Text = value; }
        }

        #endregion


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.SetNewImporto();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
