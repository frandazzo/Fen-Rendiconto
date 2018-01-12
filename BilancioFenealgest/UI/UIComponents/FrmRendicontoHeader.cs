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
    public partial class FrmRendicontoHeader : XtraForm, IRendicontoHeaderView
    {

        RendicontoHeaderFormPresenter _presenter;

        public FrmRendicontoHeader()
        {
            InitializeComponent();
        }

       

        public bool ShowAndContinue()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }




        private void cmdOK_Click(object sender, EventArgs e)
        {
    
        }


        public bool IsRlst
        {
            get { return Properties.Settings.Default.IsRlst; }
        }

        public bool IsFeneal
        {
            get { return Properties.Settings.Default.IsFeneal; }
        }

        public void SetPresenter(RendicontoHeaderFormPresenter presenter)
        {
            _presenter = presenter;
        }


    

      


        public BilancioFenealgest.Middleware.ILookupList ComboRegioni
        {
            get { return new DevDesktopCombo(cboRegione); }
        }

        public BilancioFenealgest.Middleware.ILookupList ComboProvincie
        {
            get { return new DevDesktopCombo(cboProvincia); }
        }


        private void cboRegione_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.SetComboProvince();
        }

        private void optProv_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.ChangeBilancioType();
        }

        public bool IsComboProvincieEnabled
        {
            get
            {
                return cboProvincia.Enabled;
            }
            set
            {
                cboProvincia.Enabled = value;
            }
        }

        public bool IsFileInfoVisible
        {
            get
            {
                return grpNomeFile.Visible;
            }
            set
            {
                grpNomeFile.Visible = value;
            }
        }

        public bool IsBilancioOptionsEnabled
        {
            get
            {
                return grpTipo.Enabled;
            }
            set
            {
                grpTipo.Enabled = value;
            }
        }

        public void ClearComboProvincie()
        {
            cboProvincia.Properties.Items.Clear();
        }

        public bool IsRegionaleTypeChecked
        {
            get
            {
                return radioGroup1.SelectedIndex ==1;
            }
            set
            {
                if (value)
                    radioGroup1.SelectedIndex = 1;
                else
                    radioGroup1.SelectedIndex = 0;
            }
        }

        public string SelectedRegion
        {
            get
            {
                return cboRegione.Text;
            }
            set
            {
                cboRegione.Text = value;
            }
        }

        public string SelectedProvince
        {
            get
            {
                return cboProvincia.Text;
            }
            set
            {
                cboProvincia.Text = value;
            }
        }

        public int SelectedYear
        {
            get
            {
                return Convert.ToInt32(numericUpDown1.Value);
            }
            set
            {
                numericUpDown1.Value = (decimal)value;
            }
        }

        public string FileName
        {
            get { return textBox1.Text; }
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
            return new DesktopFolderBrowserNavigator(folderBrowserDialog1);
        }



        public string SelectedProprietario
        {
            get
            {
                return txtProprietario .Text;
            }
            set
            {
                txtProprietario .Text = value;
            }
        }

      


        public bool IsFreeTemplate
        {
            get { return Properties.Settings.Default.CreateFromTemplate; }
        }

  

        public bool IsBilancioOptionsVisible
        {
            set { grpTipo.Visible = value; }
        }

        public bool AreGeoComboVisible
        {
            set 
            {
                cboProvincia.Visible = value;
                cboRegione.Visible = value;
            }
        }



        public void SetTestoProprietario()
        {
            lblProprietario.Text = Properties.Settings.Default.TestoProprietario; 
        }

        private void txtProprietario_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Visible)
                textBox1.Text = txtProprietario.Text;
        }

        private void cmdClose1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            _presenter.CreateBilancioOrUpdateHeader();
            this.DialogResult = DialogResult.OK;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.ChangeBilancioType();
        }

    
    }
}
