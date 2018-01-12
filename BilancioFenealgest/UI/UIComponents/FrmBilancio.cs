#define SENDABLE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer.ExcelExporter;
using System.Collections;
using DevExpress.XtraReports.UI;
using BilancioFenealgest.UI.PrintClasses;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Docking;
using System.Reflection;
using System.IO;
using BilancioFenealgest.ServiceLayer.DTO;
using WIN.BILANCIO.ServiceLayer.DTO;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmBilancio : XtraForm, IBilancioFormView
    {
        private BilancioFormPresenter _presenter;
        string fileLayout = "";

        internal BilancioFormPresenter Presenter
        {
            get
            {
                return _presenter;
            }
        }

        public FrmBilancio(string idBilancio)
        {
            InitializeComponent();
            barManager1.ForceInitialize();
            MyBarLocalizer.Active = new MyBarLocalizer();
            SkinHelper.InitSkinPopupMenu(m_style);





            xtraTabControl1.Dock = DockStyle.Fill;
            this.Text = "Gestionale amministrativo " + Properties.Settings.Default.Header;
           

            _presenter = new BilancioFormPresenter(idBilancio, this);
            _presenter.InitializeForm();


            string banca1 = "";
            string banca2 = "";
            string banca3 = "";


            string banca4 = "";
            string banca5 = "";
            string banca6 = "";

            _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
       


            navBarItem3.Caption = banca2; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            navBarItem2.Caption = banca1; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            navBarItem11.Caption = banca3; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;

            label34.Text = banca1; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale +":";
            label33.Text = banca2; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale + ":";

            label24.Text = banca1; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale +":";
            label6.Text = banca2; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale + ":";

            label2.Text = banca3; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale + ":";
            label18.Text = banca3; //TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale + ":";


            label8.Text = banca4;
            label36.Text = banca5;
            label39.Text = banca6;

            label30.Text = banca4;
            label37.Text = banca5;
            label41.Text = banca6;



        }


        private FrmBilancio()
        {
           
            InitializeComponent();
            this.Text = "Gestionale amministrativo " + Properties.Settings.Default.Header; 
        }

      

        public BilancioFenealgest.Middleware.IMessageBox GetSimpleMessageNotificator()
        {
            return new DesktopMessageBox();
        }

        public BilancioFenealgest.Middleware.IOpenFileClass GetOpenFileDialog()
        {
            throw new NotImplementedException();
        }


        public BilancioFenealgest.Middleware.IIerarchicalContainer IerarchicalContainer
        {
            get 
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";
                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
                return new DesktopTreelist(treeListView1, banca1, banca2, banca3, banca4,  banca5,  banca6); 
            }
        }

     


        public BilancioFenealgest.Middleware.IIerarchicalContainer IerarchicalContainer1
        {
            get 
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";
                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
                return new DesktopTreelist(treeListView2, banca1, banca2, banca3, banca4,  banca5,  banca6); 
            }
        }

        public BilancioFenealgest.Middleware.IIerarchicalContainer IerarchicalContainer2
        {
            get 
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";


                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);

                return new DesktopTreelist(treeListView3, banca1, banca2, banca3, banca4, banca5, banca6);
            }
        }

        public BilancioFenealgest.Middleware.IIerarchicalContainer IerarchicalContainer3
        {
            get 
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";


                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);

                return new DesktopTreelist(treeListView4, banca1, banca2, banca3, banca4, banca5, banca6);
            }
        }

       

       

        IRendicontoHeaderView IBilancioFormView.RendicontoHeaderView
        {
            get { return new FrmRendicontoHeader(); }
        }

       

    

     

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    _presenter.UpdateRendicontoHeader();
        //}

        #region IBilancioFormView Membri di


        public string Anno
        {
            set { lblAnno.Text = value; }
        }

        public string TipoBilancio
        {
            set { lblTipo.Text = value; }
        }

        public string Regione
        {
            set { lblRegione.Text = value; }
        }

        public string Provincia
        {
            set { lblProvincia.Text = value; }
        }

 

        public string Entrate
        {
            set { lblEntrate.Text = value; }
        }

        public string Sppese
        {
            set { lblSpese.Text = value; ; }
        }

        public string Avanzo
        {
            set { lblAvanzo.Text = value ; }
        }

        public string Fonti
        {
            set { lblFonti.Text = value; }
        }

        public string Impieghi
        {
            set { lblImpieghi.Text = value; }
        }

        public BilancioFenealgest.Middleware.ILabel QuadraturaLabel
        {
            get { return new DesktopLabel (lblQuadratura); }
        }

    

        public void ShowNoDialog()
        {
            this.Show();
        }

        #endregion

        //private void cmdSave_Click(object sender, EventArgs e)
        //{
        //    _presenter.Save();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    _presenter.OpenSituazioneIniziale();
        //}

        #region IBilancioFormView Membri di


        public ISituazioneFianziariaformView SituazioneFinanziariaView
        {
            get { return new FrmSituazioneFianziaria() ; }
        }

        #endregion

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    _presenter.ViewScrittureBanca();
        //}

        private void treeListView1_DoubleClick(object sender, EventArgs e)
        {
            _presenter.ShowNodeDetails();
        }



        #region IBilancioFormView Membri di


        public IScrittureFormView ScrittureFormView
        {
            get { return new FrmScritture (_presenter); }
        }

        #endregion

        private void treeListView2_DoubleClick(object sender, EventArgs e)
        {
            _presenter.ShowNodeDetails1();
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    _presenter.ShowScrittureBilancio();
        //}

        #region IBilancioFormView Membri di


        public void NotifyChangeOnPanel(Color panelColor)
        {
          //  panel1.BackColor = panelColor;
        }

        #endregion

        private void FrmBilancio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Close();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    _presenter.AggiornaFinanzaInizialePreventivo();
        //}

    


        public string EntratePreventivo
        {
            set { lblEntrate1.Text = value; }
        }

        public string SpesePreventivo
        {
            set { lblSpese1.Text = value; }
        }

        public string AvanzoPreventivo
        {
            set { lblAvanzo1.Text = value; }
        }

        public string FontiPreventivo
        {
            set { lblFonti1.Text = value; }
        }

        public string ImpieghiPreventivo
        {
            set { lblImpieghi1.Text = value; }
        }

        public BilancioFenealgest.Middleware.ILabel QuadraturaLabelPreventivo
        {
            get { return new DesktopLabel(lblQuadratura1); }
        }

     

        private void treeListView3_DoubleClick(object sender, EventArgs e)
        {
            _presenter.ShowPreventivoNodeDetails();
        }

        private void treeListView4_DoubleClick(object sender, EventArgs e)
        {
            _presenter.ShowPreventivoNodeDetails1();
        }

        #region IBilancioFormView Membri di


        public IFrmContoView ImportoFormView
        {
            get { return new FrmImportoConto(); }
        }

     


        public BilancioFenealgest.Middleware.IGridContainer<BilancioFenealgest.DomainLayer.Auto> GridAuto
        {
            get { return new DesktopGridContainer<Auto>(gridAuto, bindingSource1 ); }
        }

        public BilancioFenealgest.Middleware.IGridContainer<BilancioFenealgest.DomainLayer.Immobile> GridImmpobili
        {
            get { return new DesktopGridContainer<Immobile>(gridImmobili, bindingSource2); }
        }

        public BilancioFenealgest.Middleware.IGridContainer<BilancioFenealgest.DomainLayer.Deposito> GridDepositi
        {
            get { return new DesktopGridContainer<Deposito>(gridDepositi, bindingSource3); }
        }

        public BilancioFenealgest.Middleware.IGridContainer<BilancioFenealgest.DomainLayer.Polizza> GridPolizze
        {
            get { return new DesktopGridContainer<Polizza>(gridPolizze, bindingSource4); }
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            _presenter.AddAuto();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _presenter.RemoveAuto();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _presenter.AddPolizza();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _presenter.RemovePolizza();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _presenter.AddDeposito();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _presenter.RemoveDeposito();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _presenter.AddImmobile();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _presenter.RemoveImmobile();
        }

        private void gridImmobili_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            GetSimpleMessageNotificator().Show(e.Exception.Message, "Errore", BilancioFenealgest.Middleware.MessageType.Error);
            
        }

        

        private void gridImmobili_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

        private void gridDepositi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

        private void gridPolizze_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

        private void gridAuto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

      
       


        public BilancioFenealgest.Middleware.IOpenFileClass GetFolderBrowserDialog()
        {
            return new DesktopFolderBrowserNavigator (folderBrowserDialog1 );
        }

      

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    _presenter.Export();
        //}

        #region IBilancioFormView Membri di


        public bool IsWaitPanelVisible
        {
            set 
            {
                panel2.Visible = value;
                if (value)
                //panel2.BringToFront();
                {
                    this.Controls.SetChildIndex(this.panel2, 0);
                }
                Application.DoEvents();
                
            }
        }

     

        public void HidePanel()
        {
            panel2.Visible = false;
        }

      


        public string ModelloStampa(bool isRegionale)
        {

            if (isRegionale)
                return Properties.Settings.Default.ModelloRegionale;
            return Properties.Settings.Default.ModelloProvinciale;
        }

    

        public BilancioFenealgest.ServiceLayer.ExcelExporter.ExcelSearchCriteria CriteriaSettings
        {
            get 
            {
                return new ExcelSearchCriteria(
                    Properties.Settings.Default.SerachType,
                    Properties.Settings.Default.MaxRowPrimaColonna,
                    Properties.Settings.Default.MaxrowSecondaColonna,
                    Properties.Settings.Default.MaxColPrimaColonna,
                    Properties.Settings.Default.MaxColSecondaColonna);
             
            }
        }

     

        public bool IsFreeTemplate
        {
            get { return Properties.Settings.Default.CreateFromTemplate; }
        }

       

        public string ModelloStampa()
        {
            
            return Properties.Settings .Default.ModelloStampaTemplate;
        }

    

        public void NotifyTaskLabel(string text)
        {
            lblTask.Text = text;
        }

       

        public string FileNameToSave
        {
            get { return Properties.Settings .Default .NomeFileDaSalvare ; }
        }

     
        public bool IsTrannsferCommandVisible
        {
            set { cmdFeneal.Visible = value; }
        }

        #endregion

        //private void cmdFeneal_Click(object sender, EventArgs e)
        //{
        //    #if (SENDABLE)
        //    {
        //        _presenter.StartToSendBilancio();
        //    }
        //    #else
        //        MessageBox.Show("Funzione non abilitata!");
        //    #endif
        //}

        #region IBilancioFormView Membri di


        public string Proprietario
        {
            set { lblProprietario.Text = value; }
        }

        #endregion

        //private void cmdClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void label19_Click(object sender, EventArgs e)
        {

        }

     

        public void SetCassaIniziale(string value)
        {
            lblCassai.Text = value;
        }

        public void SetBancaIniziale(string value)
        {
            lblBancai.Text = value;
        }

        public void SetAccIniziale(string value)
        {
            //lblacci.Text = value;
        }

        public void SetCassaFinale(string value, Color color)
        {
            lblCassaf.Text = value;
            lblCassaf.ForeColor = color;
        }

        public void SetBancaFinale(string value)
        {
            lblBancaf.Text = value;
        }

        public void SetAccFinale(string value)
        {
           // lblaccf.Text = value;
        }



        #region IBilancioFormView Membri di


        public void SetTotaleFinanzaFinale(string p)
        {
            lblTotf.Text = p;
        }

        public void SetTotaleFinanzaIniziale(string p)
        {
            lblToti.Text = p;
        }

        #endregion

        //private void cmdScritturaCassa_Click(object sender, EventArgs e)
        //{
        //    _presenter.ViewScrittureCassa();
        //}

        #region IBilancioFormView Membri di


        public WIN.BILANCIO.PresentationLogicComponents.IFrmExportBilancio BilancioExportView
        {
            get { return new FrmExportBilancio(); }
        }

        #endregion

        //private void button15_Click(object sender, EventArgs e)
        //{
        //    _presenter.ViewScrittureAccantonamento();
        //}

        private void button16_Click(object sender, EventArgs e)
        {
            _presenter.ViewContoRLST();
        }

        #region IBilancioFormView Membri di


        public WIN.BILANCIO.PresentationLogicComponents.IScrittureContoRLSTFormView ScrittureContoRLSTFormView
        {
            get { return new FrmScrittureContoRLST(); }
        }

        #endregion

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //    {
        //        dtpa.Enabled = false;
        //        dtpDa.Enabled = false;
        //    }
        //    else
        //    {
        //        dtpa.Enabled = true;
        //        dtpDa.Enabled = true;
        //    }
        //}

        //private void cmdLibro_Click(object sender, EventArgs e)
        //{
        //    _presenter.StampaLibroGiornale();
        //}

        #region IBilancioFormView Membri di


        public DateTime InizioStampaGiornale
        {
            get 
            {

                if (checkBox11.Checked) //stampa intero periodo
                    return DateTime.Now.Date;


                if (checkEdit1.Checked) //stampa mese
                {
                    //ritorno l'inizio del mese
                    switch (comboBoxEdit1.Text)
                    {
                        case "Gennaio":
                            return new DateTime(DateTime.Now.Year, 1, 1);
                        case "Febbraio":
                            return new DateTime(DateTime.Now.Year, 2, 1);
                        case "Marzo":
                            return new DateTime(DateTime.Now.Year, 3, 1);
                        case "Aprile":
                            return new DateTime(DateTime.Now.Year, 4, 1);
                        case "Maggio":
                            return new DateTime(DateTime.Now.Year, 5, 1);
                        case "Giugno":
                            return new DateTime(DateTime.Now.Year, 6, 1);

                        case "Luglio":
                            return new DateTime(DateTime.Now.Year, 7, 1);
                        case "Agosto":
                            return new DateTime(DateTime.Now.Year, 8, 1);
                        case "Settambre":
                            return new DateTime(DateTime.Now.Year, 9, 1);

                        case "Ottobre":
                            return new DateTime(DateTime.Now.Year, 10, 1);
                        case "Novembre":
                            return new DateTime(DateTime.Now.Year, 11, 1);
                        case "Dicembre":
                            return new DateTime(DateTime.Now.Year, 12, 1);
                        default:
                            return dtpDa1.DateTime; 
                    }
                }
                else
                {
                    //ritorno la data del datepicker
                    return dtpDa1.DateTime; 
                }

                
            }
        }

        public DateTime FineStampaGiornale
        {
            get 
            {
                if (checkBox11.Checked) //stampa intero periodo
                    return DateTime.Now.Date;


                if (checkEdit1.Checked) //stampa mese
                {
                    //ritorno l'inizio del mese
                    switch (comboBoxEdit1.Text)
                    {
                        case "Gennaio":
                            return new DateTime(DateTime.Now.Year, 2, 1).AddDays(-1).Date;
                        case "Febbraio":
                            return new DateTime(DateTime.Now.Year, 3, 1).AddDays(-1).Date;
                        case "Marzo":
                            return new DateTime(DateTime.Now.Year, 4, 1).AddDays(-1).Date;
                        case "Aprile":
                            return new DateTime(DateTime.Now.Year, 5, 1).AddDays(-1).Date;
                        case "Maggio":
                            return new DateTime(DateTime.Now.Year, 6, 1).AddDays(-1).Date;
                        case "Giugno":
                            return new DateTime(DateTime.Now.Year, 7, 1).AddDays(-1).Date;

                        case "Luglio":
                            return new DateTime(DateTime.Now.Year, 8, 1).AddDays(-1).Date;
                        case "Agosto":
                            return new DateTime(DateTime.Now.Year, 9, 1).AddDays(-1).Date;
                        case "Settambre":
                            return new DateTime(DateTime.Now.Year, 10, 1).AddDays(-1).Date;

                        case "Ottobre":
                            return new DateTime(DateTime.Now.Year, 11, 1).AddDays(-1).Date;
                        case "Novembre":
                            return new DateTime(DateTime.Now.Year, 12, 1).AddDays(-1).Date;
                        case "Dicembre":
                            return new DateTime(DateTime.Now.Year + 1, 1, 1).AddDays(-1).Date;
                        default:
                            return dtpa1.DateTime;
                    }
                }
                else
                {
                    //ritorno la data del datepicker
                    return dtpa1.DateTime;
                }

            }
        }

        public bool StampaTuttoGiornale
        {
            get { return checkBox11.Checked; }
        }

        #endregion

        #region IBilancioFormView Membri di


        public bool GroupByConto
        {
            get { return chkRaggruppa1.Checked; }
        }

        #endregion

        private void label15_Click(object sender, EventArgs e)
        {

        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox2.Checked)
        //    {
        //        chkRaggruppa.Enabled = false;
        //    }
        //    else
        //    {
        //        chkRaggruppa.Enabled = true;
        //    }
        //}

        #region IBilancioFormView Membri di


        public bool StampaFormatoPrimaNota
        {
            get { return checkBox21.Checked; }
        }

        public void StampaPrimaNota(IList scritture , string filename)
        {
            XtraReport1 x = new XtraReport1();
            x.DataSource = scritture;

            string titleBanca1="";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale ;
            string titleBanca2 ="";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            string titleBanca3="";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;
            string titleBanca4 = "";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale ;
            string titleBanca5 = "";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            string titleBanca6 = "";// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;


            _presenter.FillNomiBanca(ref titleBanca1, ref titleBanca2, ref titleBanca3, ref titleBanca4, ref titleBanca5, ref titleBanca6);




            //riscrivo i nomi della banca
            foreach (ScritturaPrimaNotaDTO item in scritture)
            {
                if (item.Contropartita == "Banca1" && titleBanca1 != "Banca1")
                    item.ContoContropartita = titleBanca1 + "(Banca1)";
                else if (item.Contropartita == "Banca2" && titleBanca2 != "Banca2")
                    item.ContoContropartita = titleBanca2 + "(Banca2)";
                else if (item.Contropartita == "Banca3" && titleBanca3 != "Banca3")
                    item.ContoContropartita = titleBanca3 + "(Banca3)";


                else if (item.Contropartita == "Banca4" && titleBanca4 != "Banca4")
                    item.ContoContropartita = titleBanca4 + "(Banca4)";
                else if (item.Contropartita == "Banca5" && titleBanca5 != "Banca5")
                    item.ContoContropartita = titleBanca5 + "(Banca5)";
                else if (item.Contropartita == "Banca6" && titleBanca6 != "Banca6")
                    item.ContoContropartita = titleBanca6 + "(Banca6)";





                if (item.Conto.StartsWith("Banca1") && titleBanca1 != "Banca1")
                    item.Conto = item.Conto.Replace("Banca1", titleBanca1 + "(Banca1)");
                else if (item.Conto.StartsWith("Banca2") && titleBanca2 != "Banca2")
                    item.Conto = item.Conto.Replace("Banca2", titleBanca2 + "(Banca2)");
                else if (item.Conto.StartsWith("Banca3") && titleBanca3 != "Banca3")
                    item.Conto = item.Conto.Replace("Banca3", titleBanca3 + "(Banca3)");

                else if (item.Conto.StartsWith("Banca4") && titleBanca4 != "Banca4")
                    item.Conto = item.Conto.Replace("Banca4", titleBanca4 + "(Banca4)");
                else if (item.Conto.StartsWith("Banca5") && titleBanca5 != "Banca5")
                    item.Conto = item.Conto.Replace("Banca5", titleBanca5 + "(Banca5)");
                else if (item.Conto.StartsWith("Banca5") && titleBanca5 != "Banca5")
                    item.Conto = item.Conto.Replace("Banca5", titleBanca5 + "(Banca5)");
            }



            x.ExportToPdf(filename);


            Process.Start(filename);

        }


        public bool IsFeneal
        {
            get { return Properties.Settings.Default.IsFeneal; }
        }
        public bool IsRlst
        {
            get { return Properties.Settings.Default.IsRlst; }
        }


        public void SetTestoProprietario()
        {
            lblProp.Text = Properties.Settings.Default.TestoProprietario;
        }


        public bool InventarioScriviTipoInventario
        {
            get { return Properties .Settings .Default .InventarioScriviTipoInventario; }
        }

        public bool InventarioScriviIntestazioniTipoInventario
        {
            get { return Properties.Settings.Default.InventarioScriviIntestazioniTipoInventario ; }
        }

        public bool InventarioDisegnaOrizzontalmente
        {
            get { return Properties.Settings.Default.InventarioDisegnaOrizzontalmente ; }
        }

        public int InventarioColonnaIniziale
        {
            get { return Properties.Settings.Default.InventarioColonnaIniziale; }
        }

        public int InventarioRigaIniziale
        {
            get { return Properties.Settings.Default.InventarioRigaIniziale; }
        }

        public int InventarioRigheFraTipiInventario
        {
            get { return Properties.Settings.Default.InventarioRigheFraTipiInventario ; }
        }

 

        public bool InventarioFeneal
        {
            get { return Properties.Settings.Default.InventarioFeneal; }
        }


        public bool VisibilityTabPreventivo
        {
            get { return Properties.Settings.Default.VisibilityTabPreventivo ; }
        }

        public bool VisibilityTabStatoPatrimoniale
        {
            get { return Properties.Settings.Default.VisibilityTabStatoPatrimoniale; }
        }

  
        public void HideTabPreventivo()
        {
            xtraTabControl1.TabPages[1].PageVisible = false ;
        }

        public void HideTabStatoPatrimoniale()
        {
            xtraTabControl1.TabPages[2].PageVisible = false;
        }

        #endregion

        #region IBilancioFormView Membri di


        public bool RaiseChanghedDataEvent
        {
            get { return Properties .Settings .Default .RaiseChangeDataEvent ; }
        }

        #endregion

        #region IBilancioFormView Membri di


        public void  SetHiddenContoVisible()
        {
            //string val = Properties.Settings.Default.HiddenContoVisible.ToString();
            //MessageBox.Show("il valure delle proprità hiddenconto è:" + val);
            // cmdRlst.Visible = Properties .Settings.Default.HiddenContoVisible ;
             cmdRLST11.Visible = Properties.Settings.Default.HiddenContoVisible;
        }

        public void SetHiddenContoCommandText()
        {
             //cmdRLST11.Text = Properties.Settings.Default.HidedenContoCommmandText ; 
        }

        #endregion

        //private void cmdRLST1_Click(object sender, EventArgs e)
        //{
        //    _presenter.ViewContoRLST();
        //}

        #region IBilancioFormView Membri di


        public string MainHeader
        {
            get { return Properties.Settings.Default.Header; }
        }

        #endregion

        //private void button16_Click_1(object sender, EventArgs e)
        //{
        //    _presenter.UpdateRendicontoStructure();
        //}

        //private void button17_Click(object sender, EventArgs e)
        //{
        //    _presenter.ViewScrittureBanca2();
        //}

        #region IBilancioFormView Membri di


        public void SetBanca2Iniziale(string value)
        {
            lblbancai2.Text = value;
        }

        public void SetBanca2Finale(string value)
        {
            lblbancaf2.Text = value;
        }

        #endregion

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                dtpa1.Enabled = false;
                dtpDa1.Enabled = false;
                comboBoxEdit1.Enabled = false;
            }
            else
            {
                dtpa1.Enabled = true;
                dtpDa1.Enabled = true;
                if (checkEdit1.Checked)
                    comboBoxEdit1.Enabled = true;
                else
                    comboBoxEdit1.Enabled = false;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _presenter.StampaLibroGiornale();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewScrittureCassa();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewScrittureBanca();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewScrittureBanca2();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewScrittureAccantonamento();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.OpenSituazioneIniziale();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.AggiornaFinanzaInizialePreventivo();
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                chkRaggruppa1.Enabled = false;
            }
            else
            {
                chkRaggruppa1.Enabled = true;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _presenter.Save();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _presenter.Save();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            //MessageBox.Show("Funzione temporaneamente disabilitata!");
            //return;


#if (SENDABLE)
            {
                _presenter.StartToSendBilancio();
            }
#else
                            MessageBox.Show("Funzione non abilitata!");
#endif
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {



            _presenter.Export();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.UpdateRendicontoHeader();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ShowScrittureBilancio();
        }

        private void cmdRLST11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewContoRLST();
        }

        private void navBarItem9_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.UpdateRendicontoStructure();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RemoveLayoutFile();
            RestoreLayoutFromModel();
        }

        private static void RemoveLayoutFile()
        {
            string fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            FileInfo f = new FileInfo(fileLayout);
            fileLayout = f.DirectoryName;
            fileLayout += "\\LayoutSavings\\layout.xml";
            File.Delete(fileLayout);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _presenter.AddImmobile();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            _presenter.RemoveImmobile();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            _presenter.AddDeposito();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            _presenter.RemoveDeposito();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            _presenter.AddPolizza();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            _presenter.RemovePolizza();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            _presenter.AddAuto();

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            _presenter.RemoveAuto();
        }

   


        private void RestoreLayoutFromModel()
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;


            string fileLayoutModel = fileLayout + "\\LayoutSavings\\layoutmodel.xml";

            fileLayout += "\\LayoutSavings\\layout.xml";



            File.Copy(fileLayoutModel, fileLayout, true);




            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    // Restore the previously saved layout
                    dockManager1.RestoreLayoutFromXml(fileLayout);
                }
                else
                {
                    dockManager1.SaveLayoutToXml(fileLayout);
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

        private void RestoreLayout()
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;


            

            fileLayout += "\\LayoutSavings\\layout.xml";


            


           


            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    // Restore the previously saved layout
                    dockManager1.RestoreLayoutFromXml(fileLayout);
                }
                else
                {
                    dockManager1.SaveLayoutToXml(fileLayout);
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

        private void FrmBilancio_Load(object sender, EventArgs e)
        {
            RestoreLayout();
            dtpa1.EditValue = DateTime.Now;
            dtpDa1.EditValue = DateTime.Now;
            dtpa1.Enabled = false;
            dtpDa1.Enabled = false;
        }

        private void dockManager1_EndDocking(object sender, EndDockingEventArgs e)
        {
            SaveLayout();
        }

        private void SaveLayout()
        {
            try
            {
                dockManager1.SaveLayoutToXml(fileLayout);
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

        private void dockManager1_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            SaveLayout();
        }

        private void dockManager1_ClosedPanel(object sender, DockPanelEventArgs e)
        {
            SaveLayout();
        }

        private void dockManager1_EndSizing(object sender, EndSizingEventArgs e)
        {
            SaveLayout();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(fileLayout);
                fileLayout = f.DirectoryName;
                fileLayout += "\\Assets\\Linee guida bilancio feneal.pdf";
                Process.Start(fileLayout);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(fileLayout);
                fileLayout = f.DirectoryName;
                fileLayout += "\\Assets\\Teleassistenza.exe";
                Process.Start(fileLayout);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCambiaNomeBanca frm = new FrmCambiaNomeBanca(this);
            frm.ShowDialog();
        }




        public string Banca1
        {
            //get { return TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale; }

            get
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";


                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
       

                return banca1;
            }


        }

        public string Banca2
        {
           // get { return TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale; }
            get
            {
                string banca1 = "";
                string banca2 = "";
                string banca3 = "";


                string banca4 = "";
                string banca5 = "";
                string banca6 = "";

                _presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
       

                return banca2;
            }

        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _presenter.ViewScrittureBanca3();
        }


        public void SetBanca3Finale(string p)
        {
            lblbancaf3.Text = p;
        }

        public void SetBanca3Iniziale(string p)
        {
            lblbancai3.Text = p;
        }


        public Middleware.IGridContainer<WIN.BILANCIO.DomainLayer.Mobile> GridMobili
        {
            get { return new DesktopGridContainer<Mobile>(gridMobili, bindingSource5); }
        }

        public Middleware.IGridContainer<WIN.BILANCIO.DomainLayer.AccantonamentoTFR> GridAccantonamentoTFR
        {
            get { return new DesktopGridContainer<AccantonamentoTFR>(gridAccantonamenti, bindingSource6); }
        }

        public Middleware.IGridContainer<WIN.BILANCIO.DomainLayer.Chiusura> GridChiusure
        {
            get { return new DesktopGridContainer<Chiusura>(gridChiusure, bindingSource7); }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            _presenter.AddMobile();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            _presenter.RemoveMobile();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            _presenter.AddAccantonamentoTFR();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            _presenter.RemoveAccantonamentoTFR();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            _presenter.AddChiusura();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            _presenter.RemoveChiusura();
        }

        private void gridMobili_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             if (_presenter != null)
                    _presenter.Change();
        }

        private void gridAccantonamenti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

        private void gridChiusure_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_presenter != null)
                _presenter.Change();
        }

        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(fileLayout);
                fileLayout = f.DirectoryName;
                fileLayout += "\\Assets\\Manuale utente.pdf";
                Process.Start(fileLayout);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void navBarItem6_ItemChanged(object sender, EventArgs e)
        {

        }


        public void RefreshInterface()
        {
            _presenter.RefreshInterface();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                comboBoxEdit1.Enabled = true;
                dtpa1.Enabled = false;
                dtpDa1.Enabled = false;
            }

            else
            {
                comboBoxEdit1.Enabled = false;
                dtpa1.Enabled = true;
                dtpDa1.Enabled = true;
            }
                



          

        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void lblacci_Click(object sender, EventArgs e)
        {

        }


        public void SetBanca4Finale(string p)
        {
            lblbancaf4.Text = p;
        }

        public void SetBanca5Finale(string p)
        {
            lblbancaf5.Text = p;
        }

        public void SetBanca6Finale(string p)
        {
            lblbancaf6.Text = p;
        }

        public void SetBanca4Iniziale(string p)
        {
            lblbancai4.Text = p;
        }

        public void SetBanca5Iniziale(string p)
        {
            lblbancai5.Text = p;
        }

        public void SetBanca6Iniziale(string p)
        {
            lblbancai6.Text = p;
        }

        private void lblbancaf2_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormSelectData frm = new FormSelectData();
            
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _presenter.ExportAtDate(frm.SelectedDate);
            }
            frm.Dispose();
        }
    }
}
