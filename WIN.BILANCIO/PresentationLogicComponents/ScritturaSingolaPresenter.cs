﻿using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.ServiceLayer.DTO;
using BilancioFenealgest.Middleware;
using WIN.BILANCIO.PresentationLogicComponents;
using System.Collections;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class ScritturaSingolaPresenter
    {

        IScritturaSingloaView _view;
        BilancioService _service;
        ScrittureDTO _current;
        string _idContropartita = "";
        string _idConto;
        IScrittureFormView _subViewSyncronyzer;
        ContoActionType _action = ContoActionType.New;
        bool _isLoading = false;


        //usato per la funzione ShowScrittura
        public ScritturaSingolaPresenter(IScritturaSingloaView view, BilancioService service, ScrittureDTO current, IScrittureFormView subViewSyncronyzer)
        {
            _idConto = current.ParentId;
            _current = current;
            _service = service;
            _view = view;
            _view.SetPresenter(this);
            _subViewSyncronyzer = subViewSyncronyzer;
            _action = ContoActionType.Modify;

        }
        //usato per la funzione AddScrittura
        public ScritturaSingolaPresenter(IScritturaSingloaView view, BilancioService service, string idConto, IScrittureFormView subViewSyncronyzer)
        {
            _idConto = idConto ;
            _service = service;
            _view = view;
            _view.SetPresenter(this);
            _subViewSyncronyzer = subViewSyncronyzer;
            _action = ContoActionType.New;
        }


        //utilizzato per la funzione DuplicateScrittura
        public ScritturaSingolaPresenter(IScritturaSingloaView view, BilancioService service, string idConto, IScrittureFormView subViewSyncronyzer, ScrittureDTO prototype)
        {
            _idConto = idConto;
            _service = service;
            _view = view;
            _view.SetPresenter(this);
            _subViewSyncronyzer = subViewSyncronyzer;
            _action = ContoActionType.New;
            _current = prototype ;
        }



        public void InitializeForm()
        {
            _isLoading = true;
            try
            {
                ShowAdditionalFields();
                LoadCombos();


                _view.ComboTipoOperazione.SelectAt(0);


                if (_action == ContoActionType.Modify)
                {
                    _view.SelectedDate = _current.Date.Date;
                    _view.SelectedCausale = _current.Causale;
                    _view.SelectedNumeroPezza = _current.NumeroPezza;
                    _view.SelecteImporto = _current.Importo;
                   
                    //_view.ComboTipoOperazione.SelectedItem = _current.TipoOperazione;
                    //il tipo operazione verrà deciso dallaconrtropartita eventualmente tradotta nella stringa di output
                    SetContropartitaDataOnView();

                    //valorizzo le proprietà aggiuntive
                    _view.ComboEnte.SelectedItem = _current.Riferimento2;
                    _view.ComboSettore.SelectedItem = _current.Riferimento1;
                    _view.ComboPersonale.SelectedItem = _current.Riferimento3;

                  


                    if (_current.AutoGenerated)
                    {
                        _view.IsContainerEnabled = false;

                        _view.IsOkButtonEnabled = false;
                    }
                    _view.IsRecreateNewButtonEnabled = false;
                    return;
                }

                _view.IsRecreateNewButtonEnabled = true;

                //verifico se duplicare la scrittura
                if (_action == ContoActionType.New)
                {
                    _view.SelectedDate = DateTime.Now.Date;
                    if (_current != null)
                    {
                        //

                        _view.SelectedCausale = _current.Causale;
                        _view.SelectedNumeroPezza = _current.NumeroPezza;
                        _view.SelecteImporto = _current.Importo;
                        //_view.ComboTipoOperazione.SelectedItem = TipoOperazioneDecoder.ConvertTipoOperazioneToNormalValues(_current.TipoOperazione, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3);

                        SetContropartitaDataOnView();
                    }
                }

            }
            finally
            {
                _isLoading = false;
            }
           

        }

        private void LoadCombos()
        {
            LoadSearchCombo(_view.ComboEnte, "Riferimento2");
            LoadSearchCombo(_view.ComboPersonale, "Riferimento3");
            LoadSearchCombo(_view.ComboSettore, "Riferimento1");
        }
        private IList GetList(IList<string> iList)
        {
            ArrayList l = new ArrayList();
            foreach (string item in iList)
            {
                l.Add(item);
            }
            return l;
        }

        private void LoadSearchCombo(ILookupList list, string property)
        {

            if (!string.IsNullOrEmpty(list.SelectedItem))
                return;

            //inizializzo la view con la lista delle regioni
            IList l1 = GetList(_service.GetRiferimentoLista(property));
            StringListBinder b = new StringListBinder(l1);
            b.BindTo(list);
            //seleziono il primo elemento
            list.SelectAt(-1);
        }


        private void ShowAdditionalFields()
        {
            string desc = _service.Bilancio.FindNodeById(_idConto).Description;

            //gestione delle colonne visibili

            if (desc == "Deleghe edili" || desc == "Deleghe impianti fissi" || desc == "Tesseramento diretto")
            {
                _view.ShowPropertyInLayout("Deleghe");
                    
            }
            else if (desc == "Retribuzioni personale (nette)" ||
                    desc == "Retribuzioni lorde")
            {
                _view.ShowPropertyInLayout("Personale");
            }
            else
            {
                _view.ShowPropertyInLayout("");
            }
        }

       

        private void SetContropartitaDataOnView()
        {
            ScrittureDTO contropartita = _service.GetScritturaContropartita(_current);
            //sel'id della contropartita è quello di una banca allora metto nella combo direttamente il nome della banca
            if (!contropartita.ParentId.StartsWith("A.D")) //non è un conto delle disponibilità nelle attività( cassa o banche)
            {
               
                _idContropartita = contropartita.ParentId;
                _view.ComboTipoOperazione.SelectedItem = "Altre contropartite";//(_service.Bilancio.FindNodeById(_idContropartita) as Conto).AreaDiBilancioToString;
                _view.ShowContropartitaDetails(contropartita.ParentName);
            }
            else
            {
            //    //nascondo i dettagli
                _view.HideContropartitadetails();
            //    //normalizzo eventuali contropaartite bancarie con la loro traduzione
            //   // _view.ComboTipoOperazione.SelectedItem = TipoOperazioneDecoder.TranslateDomainValuesToGUIValues(_current, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3).Contropartita;

                //Verifico se si tratta di una delle banche se si la traduco
                if (contropartita.ParentId == "A.D.1") //cassa
                {
                    
                    _view.ComboTipoOperazione.SelectedItem = "Cassa";
                }
                else if (contropartita.ParentId == "A.D.2.a") //banca1
                {
                    _view.ComboTipoOperazione.SelectedItem = _view.Banca1;
                }
                else if (contropartita.ParentId == "A.D.2.b")//banca2
                {
                    _view.ComboTipoOperazione.SelectedItem = _view.Banca2;
                }
                else if (contropartita.ParentId == "A.D.2.c")//banca3
                {
                    _view.ComboTipoOperazione.SelectedItem = _view.Banca3;
                }

                _idContropartita = contropartita.ParentId;

            }

        }


        public void SetSelectedContropartita(string idContropartita, string nomeconto)
        {
            _idContropartita = idContropartita;
            _view.ShowContropartitaDetails(nomeconto);
        }


        public void StartDialog()
        {

            _view.ShowAndContinue();
               
            _view.Dispose();
           
        }




        public  void CreateOrUpdateScrittura()
        {
            try
            {
                if (_action == ContoActionType.New)
                    CreateNew();
                else
                    Update();
                _view.Close();
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", BilancioFenealgest.Middleware.MessageType.Error);
            }
            
        }

        private void ValidateInput(ScrittureDTO p)
        {
            



            p.Validate();

            
        }

        private void CreateNew()
        {
            ScrittureDTO p = new ScrittureDTO();
            p.Importo = _view.SelecteImporto;
            p.Date = _view.SelectedDate;
            p.Causale = _view.SelectedCausale;
            p.NumeroPezza = _view.SelectedNumeroPezza;
            p.TipoOperazione = _view.ComboTipoOperazione.SelectedItem;

            //imposto i dati aggiuntivi
            if (_view.ComboPersonale.Text == null)
                p.Riferimento3 = "";
            else
                p.Riferimento3 = _view.ComboPersonale.Text;

            if (_view.ComboEnte.Text == null)
                p.Riferimento2 = "";
            else
                p.Riferimento2 = _view.ComboEnte.Text;

            if (_view.ComboSettore.Text == null)
                p.Riferimento1 = "";
            else
                p.Riferimento1 = _view.ComboSettore.Text;

            
            //lo valido
            ValidateInput(p);


            _service.AddScrittura(_idConto, p,_idContropartita);

            //se non c'è nessun errore
            //sincronizzo
            _subViewSyncronyzer.GridContainer.BoundList.Add(TipoOperazioneDecoder.TranslateDomainValuesToGUIValues(p, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3, _subViewSyncronyzer.Banca4, _subViewSyncronyzer.Banca5, _subViewSyncronyzer.Banca6));//PrepareValueToBeshownChangingTipoOperazione(p, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2,_subViewSyncronyzer.Banca3));
            _subViewSyncronyzer.IsLabelVisible = false;
            //sincronizzo il totale
            //decimal total = _service.CalculateTotalForSCritture(_subViewSyncronyzer.GridContainer.BoundList);
            //_subViewSyncronyzer.SetScrittureTotalizzation (total.ToString("c"));
            _service.ScriviDettagliSaldoConto(_subViewSyncronyzer, _idConto);
        }

        private void ClearInterface()
        {
            _view.ComboTipoOperazione.SelectAt(0);
            _view.SelectedCausale = "";
            _view.SelectedDate = DateTime.Now.Date;
            _view.SelectedNumeroPezza = "";
            _view.SelecteImporto = 0;

        }


        private void Update()
        {
            //costruisco il dto da validare con tutti i dati necessari del dto corrente
            //n.b. il dto corrente non deve essere modificato se non dopo
            //aver passato indenne l'aggiornamento nella stato di dominio
            ScrittureDTO p = new ScrittureDTO(_current);
            p.Importo = _view.SelecteImporto;
            p.Date = _view.SelectedDate;
            p.Causale = _view.SelectedCausale;
            p.NumeroPezza = _view.SelectedNumeroPezza;
            p.TipoOperazione = _view.ComboTipoOperazione.SelectedItem;

            //imposto i dati aggiuntivi
            //imposto i dati aggiuntivi
            if (_view.ComboPersonale.Text == null)
                p.Riferimento3 = "";
            else
                p.Riferimento3 = _view.ComboPersonale.Text;

            if (_view.ComboEnte.Text == null)
                p.Riferimento2 = "";
            else
                p.Riferimento2 = _view.ComboEnte.Text;

            if (_view.ComboSettore.Text == null)
                p.Riferimento1 = "";
            else
                p.Riferimento1 = _view.ComboSettore.Text;

            //lo valido
            ValidateInput(p);


            //a questo punto posso chiedere al servizio di aggiornare l'oggetto 
            _service.UpdateScrittura(p, _idContropartita);

            //se non si è verificato nessun errore sincronizzo anche l'oggetto dto corrente
            p = TipoOperazioneDecoder.TranslateDomainValuesToGUIValues(p, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3, _subViewSyncronyzer.Banca4, _subViewSyncronyzer.Banca5, _subViewSyncronyzer.Banca6);//.PrepareValueToBeshownChangingTipoOperazione(p, _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3);
            _current.Date = p.Date;
            _current.NumeroPezza = p.NumeroPezza;
            _current.Importo = p.Importo;
            _current.TipoOperazione =p.TipoOperazione;
            _current.Causale = p.Causale;
            _current.ParentName = p.ParentName;
            _current.Contropartita = p.Contropartita;
            _current.Riferimento1 = p.Riferimento1;
            _current.Riferimento2 = p.Riferimento2;
            _current.Riferimento3 = p.Riferimento3;

            //adesso confermo le modifiche al grid contasiner
            _subViewSyncronyzer.GridContainer.RefreshCurrent();

            ////sincronizzo il totale
            //decimal total = _service.CalculateTotalForSCritture(_subViewSyncronyzer.GridContainer.BoundList);
            //_subViewSyncronyzer.SetScrittureTotalizzation(total.ToString("c"));
            _service.ScriviDettagliSaldoConto(_subViewSyncronyzer,_idConto);
        }

     



        public  void AddAndRecreeteNew()
        {
            try
            {
                CreateNew();
                ClearInterface();
                _view.SetInitialFocus();
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", BilancioFenealgest.Middleware.MessageType.Error);
            }
        }






        public void PrepareChooseContropartita()
        {

            if (_isLoading)
                return;


            if (_view.ComboTipoOperazione.SelectedItem == _view.Banca1)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.a", _view.Banca1);
                HideContropartitaDetails();
            }
            else if (_view.ComboTipoOperazione.SelectedItem == _view.Banca2)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.b", _view.Banca2);
                HideContropartitaDetails();
            }
            else if (_view.ComboTipoOperazione.SelectedItem == _view.Banca3)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.c", _view.Banca3);
                HideContropartitaDetails();
            }


            else if (_view.ComboTipoOperazione.SelectedItem == _view.Banca4)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.d", _view.Banca4);
                HideContropartitaDetails();
            }
            else if (_view.ComboTipoOperazione.SelectedItem == _view.Banca5)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.e", _view.Banca5);
                HideContropartitaDetails();
            }
            else if (_view.ComboTipoOperazione.SelectedItem == _view.Banca6)
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.2.f", _view.Banca6);
                HideContropartitaDetails();
            }



            else if (_view.ComboTipoOperazione.SelectedItem  == "Cassa")
            {
                //seleziono la contropartita e decido se mostrare o no il testo
                this.SetSelectedContropartita("A.D.1", "Cassa");
                HideContropartitaDetails();
            }
             else if (_view.ComboTipoOperazione.SelectedItem == "Altre contropartite")
            {

                FrmContropartitaPresenter pres = new FrmContropartitaPresenter(_view.GetFrmContropartita, _service, this, _view.ComboTipoOperazione.SelectedItem);
                pres.InitializeForm();
                pres.StartDialog();
            }
            else
            {
                HideContropartitaDetails();
            }




           


            
        }

        public void HideContropartitaDetails()
        {
            _view.HideContropartitadetails();
        }

        internal void CancelScritturaInContropartita()
        {
            _view.ComboTipoOperazione.SelectAt(0);
            _view.HideContropartitadetails();
        }
    }

    public enum ContoActionType
    {
        Modify,
        New
    }
}
