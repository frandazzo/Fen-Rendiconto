using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.Drawing;
//using BilancioFenealgest.UI.UIComponents;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer.ExcelExporter;
using WIN.BILANCIO.PresentationLogicComponents;
using System.Collections;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface IBilancioFormView : IBasePresentation
    {
       
        bool IsRlst { get; }
        bool IsFeneal { get; }
        bool IsTrannsferCommandVisible { set; }
        IIerarchicalContainer IerarchicalContainer { get; }
        IIerarchicalContainer IerarchicalContainer1 { get; }
        IIerarchicalContainer IerarchicalContainer2 { get; }
        IIerarchicalContainer IerarchicalContainer3 { get; }
        void SetTestoProprietario();
        IRendicontoHeaderView RendicontoHeaderView { get; }
        ISituazioneFianziariaformView SituazioneFinanziariaView { get; }
        IScrittureFormView ScrittureFormView{get;}
        IScrittureContoRLSTFormView ScrittureContoRLSTFormView { get; }

        IGridContainer<Auto> GridAuto { get; }
        IGridContainer<Immobile> GridImmpobili { get; }
        IGridContainer<Deposito > GridDepositi { get; }
        IGridContainer<Polizza > GridPolizze { get; }


        IGridContainer<Mobile> GridMobili { get; }
        IGridContainer<AccantonamentoTFR> GridAccantonamentoTFR { get; }
        IGridContainer<Chiusura> GridChiusure { get; }
   



        IFrmExportBilancio BilancioExportView { get; }


      

        string Anno { set; }
        string TipoBilancio { set; }
        string Regione { set; }
        string Provincia { set; }
        string Proprietario { set; }

        string Entrate { set; }
        string Sppese { set; }
        string Avanzo { set; }

        DateTime InizioStampaGiornale { get; }
        DateTime FineStampaGiornale { get; }
        bool StampaTuttoGiornale { get; }
        bool StampaFormatoPrimaNota { get; }

        void StampaPrimaNota(IList scritture, string fileName);


        string Fonti { set; }
        string Impieghi { set; }
        ILabel QuadraturaLabel { get; }

        void RefreshInterface();


        void ShowNoDialog();
        void NotifyChangeOnPanel(Color panelColor);
        void Close();

        void Dispose();

        string ModelloStampa(bool isRegionale);
        string ModelloStampa();





        IFrmContoView ImportoFormView { get; }

        string EntratePreventivo { set; }
        string SpesePreventivo { set; }
        string AvanzoPreventivo { set; }


        string FontiPreventivo { set; }
        string ImpieghiPreventivo { set; }
        ILabel QuadraturaLabelPreventivo { get; }


        object Invoke(Delegate method);
        object Invoke(Delegate method, params object[] args);
        bool IsWaitPanelVisible { set; }
        void NotifyTaskLabel(string text);
        void HidePanel();
        bool GroupByConto { get; }

        ExcelSearchCriteria CriteriaSettings { get; }
        bool  IsFreeTemplate { get; }
        

        
        string FileNameToSave{ get; }


        void SetCassaIniziale(string value);
        void SetBancaIniziale(string value);
        void SetBanca2Iniziale(string value);
        void SetAccIniziale(string value);
        void SetCassaFinale(string value,Color color);
        void SetBancaFinale(string value);
        void SetBanca2Finale(string value);
        void SetAccFinale(string value);


        void SetTotaleFinanzaFinale(string p);

        
        void SetTotaleFinanzaIniziale(string p);



        #region SettingsInventario

        bool InventarioScriviTipoInventario { get; }
        bool InventarioScriviIntestazioniTipoInventario { get; }
        bool InventarioDisegnaOrizzontalmente { get; }
        int  InventarioColonnaIniziale { get; }
        int  InventarioRigaIniziale { get; }
        int  InventarioRigheFraTipiInventario { get; }
        bool InventarioFeneal { get; }

        #endregion
        #region Visibilità

        bool VisibilityTabPreventivo { get; }
        bool VisibilityTabStatoPatrimoniale { get; }

        #endregion


        void HideTabPreventivo();
        void HideTabStatoPatrimoniale();


        bool RaiseChanghedDataEvent { get; }


        string MainHeader { get; }

        #region ContoNascosto

        void SetHiddenContoVisible();
        void SetHiddenContoCommandText();
        #endregion

        void SetBanca3Finale(string p);

        void SetBanca3Iniziale(string p);

        void SetBanca4Finale(string p);
        void SetBanca5Finale(string p);
        void SetBanca6Finale(string p);

        void SetBanca4Iniziale(string p);
        void SetBanca5Iniziale(string p);
        void SetBanca6Iniziale(string p);
    }
}
