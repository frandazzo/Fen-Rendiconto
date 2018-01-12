using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.Middleware;
using System.Diagnostics;
using System.Reflection;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class Form1 : XtraForm, IStartupFormView 
    {

        StartupFormPresenter _presenter;


        public Form1()
        {
            InitializeComponent();
            _presenter = new StartupFormPresenter(this);
            _presenter.InitializeForm();

            string header = "";

            if (Properties.Settings.Default.IsFeneal)
                header = "FENEAL";
            else if (Properties.Settings.Default.IsRlst)
                header = "RLST";

            simpleButton1.Text = string.Format("Apri rendiconto {0} esistente", header);
            simpleButton2.Text = string.Format("Crea nuovo rendiconto {0}", header); 
            
        }
  

       


        public void SetHeader()
        {
            
        }

   

        public BilancioFenealgest.Middleware.IMessageBox GetSimpleMessageNotificator()
        {
            return new DesktopMessageBox();
        }



        public BilancioFenealgest.Middleware.IOpenFileClass GetOpenFileDialog()
        {
            return new DesktopOpenFileDialog(openFileDialog1);
        }

    


    
      

       

     


        public IRendicontoHeaderView RendicontoHeaderView
        {
            get { return new FrmRendicontoHeader(); }
        }

        

        public IBilancioFormView BilancioView(string idBilancio)
        {
            return  new FrmBilancio(idBilancio );
           
        }

      


        public IOpenFileClass GetFolderBrowserDialog()
        {
            return new DesktopFolderBrowserNavigator(folderBrowserDialog1);
        }

       


        public bool IsFreeTemplate
        {
            get { return Properties.Settings.Default.CreateFromTemplate; }
        }

       

      



        #region IStartupFormView Membri di


        public string FileFreeTemplate
        {
            get {  return Properties.Settings.Default.FileFreeTemplate; }
        }

        #endregion

    

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _presenter.CreateNewBilancio();
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.OpenExistingBilancio();
      
        }
    }
}
