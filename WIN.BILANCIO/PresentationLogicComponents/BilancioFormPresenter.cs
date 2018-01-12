
using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.ServiceLayer.DTO;
using System.Drawing;
using BilancioFenealgest.DomainLayer;
using System.Threading;
using BilancioFenealgest.ServiceLayer.ExcelExporter;
using BilancioFenealgest.DataAccess;
using WIN.BILANCIO.PresentationLogicComponents;
using WIN.BILANCIO.ServiceLayer;
using System.IO;
using WIN.BILANCIO.ServiceLayer.DTO;
using System.Collections;
using WIN.BILANCIO.ServiceLayer.ExcelExporter;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class BilancioFormPresenter
    {
        DateTime dateToExport;
        RendicontoService _service;
        IBilancioFormView _view;
        string _idBilancio;
        BilancioService _sericeBilancio;
        PreventivoService _sericePreventivo;
        ContoRLSTService _rlstService;
        bool _dataModified = false;
        StatoPatrimonialeService _statoPatrimonialeService;
        delegate void SimpleDelegate();
        delegate void OneStringArgDelegate(string arg);

        public BilancioFormPresenter(string idBilancio, IBilancioFormView view)
        {
            _service = new RendicontoService();
            _service.ScritturaBilancio += new EventHandler(_service_ScritturaBilancio);
            _service.ScritturaPreventivo += new EventHandler(_service_ScritturaPreventivo);
            _service.ScritturaStatoPatrimoniale += new EventHandler(_service_ScritturaStatoPatrimoniale);
            _service.Change += new EventHandler(_service_Change);
            _view = view;
            _idBilancio = idBilancio;
           
        }

        void _service_ScritturaStatoPatrimoniale(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Scrittura stato patrimoniale in corso" });
        }

        void _service_ScritturaPreventivo(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Scrittura preventivo in corso" });
        }

        void _service_ScritturaBilancio(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s,  new object[]{"Scrittura bilancio in corso"} );
        }

        void _service_Change(object sender, EventArgs e)
        {
            Change();
        }


        public void InitializeForm()
        {

            if (!_view.VisibilityTabPreventivo)
                _view.HideTabPreventivo();

            if (!_view.VisibilityTabStatoPatrimoniale)
                _view.HideTabStatoPatrimoniale();

            _view.SetHiddenContoCommandText();
            _view.SetHiddenContoVisible();
            

            _view.SetTestoProprietario();

            
            if (_view.IsFeneal || _view.IsRlst)
                _view.IsTrannsferCommandVisible = true;
            else
                _view.IsTrannsferCommandVisible = false;
            
           


            //recupero il bìilancio
            _service.LoadRendiconto(_idBilancio);
            TipoBilanco.IsProvinciale = !_service.RendicontoHeader.IsRegionale;
            _sericeBilancio = _service.BilancioService;
            //aggiungo la gestione degli eventi al serviziizo del bilancio
            _sericeBilancio.BeginExport += new EventHandler(_sericeBilancio_BeginExport);
            _sericeBilancio.EndExport += new EventHandler(_sericeBilancio_EndExport);
            _sericeBilancio.ExportedRow += new WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportEventHandler(_sericeBilancio_ExportedRow);


            _sericePreventivo = _service.PreventivoService;
            _statoPatrimonialeService = _service.StatoPatrimonialeService;
            _rlstService = _service.ContoRLSTService;
            //Creo il binder gerarchico
            IerarchicalListBinder b = new IerarchicalListBinder();

            //inserisco le entrate nella prima  lista
           // b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.FinanzaIniziale ,true);
            b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.Passivita, true);
            b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.Entrate,false);

            _view.IerarchicalContainer1.ExpandAll();



            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.Attivita, true);
            b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.Spese, false);
            //b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.FinanzaFinale, false);

            _view.IerarchicalContainer.ExpandAll();



            //inserisco i preventivi
            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Passivita, true);
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Entrate, false);

            _view.IerarchicalContainer3.ExpandAll();


            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Attivita, true);
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Spese, false);

            _view.IerarchicalContainer2.ExpandAll();


            //Carico i dati di bilancio nell'header
            SetBilancioHeader();


            //Carico le statistiche
            SetStatistics();
            SetStatisticsPreventivo();

            SetSituazioneFinanziaria();



            LoadStatoPatrimoniale();

        }

        void _sericeBilancio_ExportedRow(object sender, WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportedEventArgs fe)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Perc. esportazione: " + fe.RowPercentage.ToString("p") });
        }

        void _sericeBilancio_EndExport(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Termine esportazione libro giornale" });
        }

        void _sericeBilancio_BeginExport(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Inizio esportazione libro giornale" });
        }

        private void SetSituazioneFinanziaria()
        {

            _view.SetBancaIniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA1).SaldoIniziale.ToString("c"));
            _view.SetBanca2Iniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA2).SaldoIniziale.ToString("c"));
            _view.SetBanca3Iniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA3).SaldoIniziale.ToString("c"));

            _view.SetBanca4Iniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA4).SaldoIniziale.ToString("c"));
            _view.SetBanca5Iniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA5).SaldoIniziale.ToString("c"));
            _view.SetBanca6Iniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA6).SaldoIniziale.ToString("c"));


            _view.SetCassaIniziale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.CASSA).SaldoIniziale.ToString("c"));
           // _view.SetAccIniziale(_sericeBilancio.FinanzaIniziale.Accantonamenti.ToString("c"));

            _view.SetBancaFinale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA1).GetTotal.ToString("c"));
            _view.SetBanca2Finale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA2).GetTotal.ToString("c"));
            _view.SetBanca3Finale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA3).GetTotal.ToString("c"));

            _view.SetBanca4Finale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA4).GetTotal.ToString("c"));
            _view.SetBanca5Finale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA5).GetTotal.ToString("c"));
            _view.SetBanca6Finale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.BANCA6).GetTotal.ToString("c"));

            if (_sericeBilancio.Bilancio.FindNodeById(BilancioService.CASSA).GetTotal < 0)
                _view.SetCassaFinale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.CASSA).GetTotal.ToString("c"), Color.Red);
            else
                _view.SetCassaFinale(_sericeBilancio.Bilancio.FindNodeById(BilancioService.CASSA).GetTotal.ToString("c"), Color.Black);
            //_view.SetAccFinale(_sericeBilancio.Bilancio.SaldoAccantonamento.ToString("c"));
            _view.SetTotaleFinanzaIniziale(_sericeBilancio.GetFinanzaInizialeTotal().ToString("c"));
            _view.SetTotaleFinanzaFinale(_sericeBilancio.GetFinanzaFinaleTotal().ToString("c"));
        }


        private void LoadStatoPatrimoniale()
        {
            IGridContainer<Auto> c = _view.GridAuto;
            c.AutoGenerateColumns = false;
            c.SetSource(_statoPatrimonialeService.SortableAutoList);


            IGridContainer<Polizza> c1 = _view.GridPolizze;
            c1.AutoGenerateColumns = false;
            c1.SetSource(_statoPatrimonialeService.SortablePolizzeList);

            IGridContainer<Immobile> c2 = _view.GridImmpobili;
            c2.AutoGenerateColumns = false;
            c2.SetSource(_statoPatrimonialeService.SortableImmobiliList);

            IGridContainer<Deposito> c3 = _view.GridDepositi;
            c3.AutoGenerateColumns = false;
            c3.SetSource(_statoPatrimonialeService.SortableDepositiList);

            IGridContainer<Mobile> c4 = _view.GridMobili;
            c4.AutoGenerateColumns = false;
            c4.SetSource(_statoPatrimonialeService.SortableMobiliList);

            IGridContainer<AccantonamentoTFR> c5 = _view.GridAccantonamentoTFR;
            c5.AutoGenerateColumns = false;
            c5.SetSource(_statoPatrimonialeService.SortableAccantonamentiTFRList);

            IGridContainer<Chiusura> c6 = _view.GridChiusure;
            c6.AutoGenerateColumns = false;
            c6.SetSource(_statoPatrimonialeService.SortableChiusureList);
            
        }

        private void SetStatistics()
        {
            StatisticsDTO dto = _sericeBilancio.Statistiche;

            _view.Entrate = dto.Entrate.ToString("c");
            _view.Sppese = dto.Spesee.ToString("c");
            _view.Avanzo = dto.Avanzo.ToString("c");
            _view.Fonti = dto.Fonti.ToString("c");
            _view.Impieghi = dto.Impieghi.ToString("c");

            ILabel l = _view.QuadraturaLabel;

            l.SetText(dto.Quadratura.ToString("c"));

            if (dto.Quadratura == 0)
                l.SetForeColor(Color.Black);
            else
                l.SetForeColor(Color.Red);

        }

        private void SetStatisticsPreventivo()
        {
            StatisticsDTO dto = _sericePreventivo.Statistiche;

            _view.EntratePreventivo = dto.Entrate.ToString("c");
            _view.SpesePreventivo = dto.Spesee.ToString("c");
            _view.AvanzoPreventivo = dto.Avanzo.ToString("c");
            _view.FontiPreventivo = dto.Fonti.ToString("c");
            _view.ImpieghiPreventivo = dto.Impieghi.ToString("c");

            ILabel l = _view.QuadraturaLabelPreventivo;

            l.SetText(dto.Quadratura.ToString("c"));

            if (dto.Quadratura == 0)
                l.SetForeColor(Color.Black);
            else
                l.SetForeColor(Color.Red);

        }

        public void UpdateRendicontoHeader()
        {
            IRendicontoHeaderView v = _view.RendicontoHeaderView;
            RendicontoHeaderFormPresenter presenter = new RendicontoHeaderFormPresenter(v,  _service, ActionType.Update );
            v.SetPresenter(presenter);


            presenter.InitializeView();
            //a questo punto posso utilizzare il presenter per visualizzare il form
            if (presenter.StartDialog())
                SetBilancioHeader(); //dopo che è stato effettuato tutto posso riaggiornare la vista


        }

        private void SetBilancioHeader()
        {
            RendicontoHeaderDTO dto = _service.RendicontoHeader;
            _view.Provincia = dto.Provincia;
            _view.Regione = dto.Regione;
            _view.Proprietario = dto.Proprietario;

            if (dto.IsRegionale)
                _view.TipoBilancio = "Regionale";
            else
                _view.TipoBilancio = "Provinciale";

            _view.Anno = dto.Anno.ToString();

        }


        public void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(_service.RendicontoSendableTag))
                {
                    if (_view.IsRlst)
                    {
                        _service.RendicontoSendableTag = "RLST";
                    }
                    else if (_view.IsFeneal)
                    {
                        _service.RendicontoSendableTag = "FENEAL";
                    }
                    else
                    {
                        _service.RendicontoSendableTag = "NOESIS";
                    }
                }
                _service.Save();
                if (_view.RaiseChanghedDataEvent)
                {
                    _view.GetSimpleMessageNotificator().Show("Bilancio salvato", "Informazione", MessageType.Information);
                }
                _view.NotifyChangeOnPanel(Color.White);
                _dataModified = false;
            }
            catch (Exception ex)
            {

                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            
        }

        public  void OpenSituazioneIniziale()
        {
            try
            {
                SituazioneFinanziariaPresenter presenter = new SituazioneFinanziariaPresenter(_view.SituazioneFinanziariaView, _sericeBilancio, true);

                presenter.InitializeForm();

                if (presenter.StartDialog())
                    RefreshInterface();


            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }

        public void RefreshInterface()
        {
            //rinfresco le statistiche 
            SetStatistics();
            SetStatisticsPreventivo();
            SetSituazioneFinanziaria();

            //rinfresco gli alberi

           // //Creo il binder gerarchico
           // IerarchicalListBinder b = new IerarchicalListBinder();

           // //inserisco le entrate nella prima lista
           //// b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.FinanzaIniziale, true);
           // b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.Entrate, true);

           // _view.IerarchicalContainer.ExpandAll();

           // //inserisco le uscite
           // b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.Spese, true);
           //// b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.FinanzaFinale, false);

           // _view.IerarchicalContainer1.ExpandAll();


           // //inserisco i preventivi
           // //inserisco le entrate nella prima lista
           // b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.FinanzaIniziale, true);
           // b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Entrate, false);

           // _view.IerarchicalContainer2.ExpandAll();


           // //inserisco le uscite
           // b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Spese, true);
           // b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.FinanzaFinale, false);

           // _view.IerarchicalContainer3.ExpandAll();

            //Creo il binder gerarchico
            IerarchicalListBinder b = new IerarchicalListBinder();

            //inserisco le entrate nella prima  lista
            // b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.FinanzaIniziale ,true);
            b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.Passivita, true);
            b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.Entrate, false);

            _view.IerarchicalContainer1.ExpandAll();



            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.Attivita, true);
            b.Bind(_view.IerarchicalContainer, _sericeBilancio.Bilancio.Spese, false);
            //b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.FinanzaFinale, false);

            _view.IerarchicalContainer.ExpandAll();



            //inserisco i preventivi
            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Passivita, true);
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Entrate, false);

            _view.IerarchicalContainer3.ExpandAll();


            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Attivita, true);
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Spese, false);

            _view.IerarchicalContainer2.ExpandAll();

        }


        public void ViewScrittureBanca()
        {
            //try
            //{
            //    ScritturePresenter presenter;

            //    presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, _sericeBilancio.Bilancio.Banca1Finale.Id);


            //    presenter.InitializeForm();

            //    presenter.StartDialog();

            //    RefreshInterface();

            //}
            //catch (Exception ex)
            //{
            //    _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            //}
        }


        public void ViewScrittureBanca2()
        {
            //try
            //{
            //    ScritturePresenter presenter;

            //    presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, _sericeBilancio.Bilancio.Banca2Finale.Id);


            //    presenter.InitializeForm();

            //    presenter.StartDialog();

            //    RefreshInterface();

            //}
            //catch (Exception ex)
            //{
            //    _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            //}
        }

        //public  void OpenSituazioneFinale()
        //{
        //    try
        //    {
        //        SituazioneFinanziariaPresenter presenter = new SituazioneFinanziariaPresenter(_view.SituazioneFinanziariaView, _sericeBilancio, false);

        //        presenter.InitializeForm();

        //        if (presenter.StartDialog())
        //            RefreshInterface();


        //    }
        //    catch (Exception ex)
        //    {
        //        _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
        //    }
        //}

        public  void ShowNodeDetails()
        {
            ShowDoDetails(_view.IerarchicalContainer);
        }

        public void ShowNodeDetails1()
        {
            ShowDoDetails(_view.IerarchicalContainer1);
        }


        private void ShowDoDetails(IIerarchicalContainer container)
        {
            try
            {
                ScritturePresenter presenter;
                if (container != null)
                {
                    if (container.SelectedNode == null)
                        return;
                     presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, container.SelectedNode.Tag.ToString());
                }
                else
                {
                     presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, "");
                }

                presenter.InitializeForm();

                presenter.StartDialog();

                RefreshInterface();

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }



        public void StartToSendBilancio()
        {
            try
            {
                ExportBilancioPresenter presenter = new ExportBilancioPresenter(_service, _view.BilancioExportView);
               
                presenter.StartDialog();

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }




        public void ViewScrittureCassa()
        {
            //try
            //{
            //    ScritturePresenter presenter;
                
            //    presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, _sericeBilancio.Bilancio.CassaFinale.Id);
                

            //    presenter.InitializeForm();

            //    presenter.StartDialog();

            //    RefreshInterface();

            //}
            //catch (Exception ex)
            //{
            //    _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            //}
        }



        public  void ShowScrittureBilancio()
        {
            ShowDoDetails(null);
        }

        public void Close()
        {
            if (!_dataModified)
            {
               
                return;
            }

            if (_view.GetSimpleMessageNotificator().ShowAndContibue("Il rendiconto è stato modificato. Salvare le modifiche?", "Domanda"))
            {
                _service.Save();
               
            }
        }

        public  void AggiornaFinanzaInizialePreventivo()
        {
           // _sericePreventivo.UpdateSituazioneFinanziariaIniziale();
            _sericePreventivo.UpdateSituazioneFinanziariaIniziale(_sericeBilancio.Bilancio);
            RefreshInterface();
        }

        public  void ShowPreventivoNodeDetails()
        {
            ShowPreventivoDoDetails(_view.IerarchicalContainer2);
        }

        public  void ShowPreventivoNodeDetails1()
        {
            ShowPreventivoDoDetails(_view.IerarchicalContainer3);
        }


        private void ShowPreventivoDoDetails(IIerarchicalContainer container)
        {
            try
            {



                if (container.SelectedNode == null)
                    return;

              
                ImportoContoPresenter presenter = new ImportoContoPresenter(_view.ImportoFormView,_sericePreventivo, container.SelectedNode.Tag.ToString());
                

                presenter.InitializeForm();

                presenter.StartDialog();

                RefreshPreventivoInterface();

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }

        private void RefreshPreventivoInterface()
        {
            SetStatisticsPreventivo();


            //rinfresco gli alberi

            //Creo il binder gerarchico
            IerarchicalListBinder b = new IerarchicalListBinder();

           

            //inserisco i preventivi
            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Passivita, true);
            b.Bind(_view.IerarchicalContainer3, _sericePreventivo.Bilancio.Entrate, false);

            _view.IerarchicalContainer3.ExpandAll();


            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Attivita, true);
            b.Bind(_view.IerarchicalContainer2, _sericePreventivo.Bilancio.Spese, false);

            _view.IerarchicalContainer2.ExpandAll();


        }

        public  void AddAuto()
        {
            Auto a = _statoPatrimonialeService.AddAuto();
            _view.GridAuto.BoundList.Add(a);
        }

        public  void RemoveAuto()
        {
            Auto a = _view.GridAuto.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveAuto(a);
                _view.GridAuto.BoundList.Remove(a);
                
            }

        }

        public void AddChiusura()
        {
            Chiusura a = _statoPatrimonialeService.AddChiusura();
            _view.GridChiusure.BoundList.Add(a);
        }

        public void RemoveChiusura()
        {
            Chiusura a = _view.GridChiusure.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveChiusura(a);
                _view.GridChiusure.BoundList.Remove(a);

            }

        }

        public void AddMobile()
        {
            Mobile a = _statoPatrimonialeService.AddMobile();
            _view.GridMobili.BoundList.Add(a);
        }

        public void RemoveMobile()
        {
            Mobile a = _view.GridMobili.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveMobile(a);
                _view.GridMobili.BoundList.Remove(a);

            }

        }

        public void AddAccantonamentoTFR()
        {
            AccantonamentoTFR a = _statoPatrimonialeService.AddAccantonamentoTFR();
            _view.GridAccantonamentoTFR.BoundList.Add(a);
        }

        public void RemoveAccantonamentoTFR()
        {
            AccantonamentoTFR a = _view.GridAccantonamentoTFR.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveAccantonamentoTFR(a);
                _view.GridAccantonamentoTFR.BoundList.Remove(a);

            }

        }




        public void AddImmobile()
        {
            Immobile a = _statoPatrimonialeService.AddImmobile();
            _view.GridImmpobili.BoundList.Add(a);
        }

        public void RemoveImmobile()
        {
            Immobile a = _view.GridImmpobili.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveImmobile(a);
                _view.GridImmpobili.BoundList.Remove(a);

            }

        }


        public void AddDeposito()
        {
            Deposito a = _statoPatrimonialeService.AddDeposito();
            _view.GridDepositi.BoundList.Add(a);
        }

        public void RemoveDeposito()
        {
            Deposito a = _view.GridDepositi.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemoveDeposito(a);
                _view.GridDepositi.BoundList.Remove(a);

            }

        }


        public void AddPolizza()
        {
            Polizza a = _statoPatrimonialeService.AddPolizza();
            _view.GridPolizze.BoundList.Add(a);
        }

        public void RemovePolizza()
        {
            Polizza a = _view.GridPolizze.CurrentObject();

            if (a != null)
            {
                _statoPatrimonialeService.RemovePolizza(a);
                _view.GridPolizze.BoundList.Remove(a);

            }

        }


        public void Change()
        {
            if (_view.RaiseChanghedDataEvent)
            {

                _view.NotifyChangeOnPanel(Color.Red);
                _dataModified = true;
            }
            else
            {
                Save();
            }
        }





        public  void Export()
        {
            _view.IsWaitPanelVisible = true;

            Thread t = new Thread(new ThreadStart(DoExport));
            t.Start();

            

            
        }

        public void ExportAtDate(DateTime date)
        {
            _view.IsWaitPanelVisible = true;

            dateToExport = date;

            Thread t = new Thread(new ThreadStart(DoExportAtDate));
            t.Start();

        }


        private void DoExportAtDate()
        {
            try
            {
                if (dateToExport == null)
                    throw new Exception("Data nulla");

                ExcelSearchCriteria c = _view.CriteriaSettings;


                StampaExcelSettings settings = new StampaExcelSettings(_view.InventarioScriviTipoInventario, _view.InventarioScriviIntestazioniTipoInventario, _view.InventarioRigheFraTipiInventario, _view.InventarioRigaIniziale, _view.InventarioDisegnaOrizzontalmente, _view.InventarioColonnaIniziale, _view.InventarioFeneal, _view.VisibilityTabPreventivo, _view.VisibilityTabStatoPatrimoniale, dateToExport);


                if (_view.IsFreeTemplate)
                {
                    _service.ExportToExcel(_view.ModelloStampa(), c, settings, "Rendiconto" + _view.MainHeader);
                }
                else
                {
                    _service.ExportToExcel(_view.ModelloStampa(_service.RendicontoHeader.IsRegionale), c, settings, "Rendiconto" + _view.MainHeader);
                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            finally
            {
                SimpleDelegate d = _view.HidePanel;
                _view.Invoke(d);
            }

        }

        private void DoExport()
        {
            try
            {
                dateToExport = DateTime .MinValue ;
                //dateToExport = new DateTime(2016, 3, 14);
                
                ExcelSearchCriteria c = _view.CriteriaSettings;


                StampaExcelSettings settings = new StampaExcelSettings(_view.InventarioScriviTipoInventario, _view.InventarioScriviIntestazioniTipoInventario, _view.InventarioRigheFraTipiInventario, _view.InventarioRigaIniziale, _view.InventarioDisegnaOrizzontalmente, _view.InventarioColonnaIniziale, _view.InventarioFeneal, _view.VisibilityTabPreventivo, _view.VisibilityTabStatoPatrimoniale, dateToExport);


                if (_view.IsFreeTemplate)
                {
                    _service.ExportToExcel(_view.ModelloStampa(), c, settings, "Rendiconto" + _view.MainHeader  );
                }
                else
                {
                    _service.ExportToExcel(_view.ModelloStampa(_service.RendicontoHeader.IsRegionale), c,settings , "Rendiconto" + _view.MainHeader );
                }
                
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            finally
            {
                SimpleDelegate d = _view.HidePanel;
                _view.Invoke(d);
            }
            
        }

        public  void CreateTransferFile()
        {
            try
            {
                IOpenFileClass o = _view.GetFolderBrowserDialog();

                if (o.ShowAndContinue())
                {
                    string path = o.GetFileName();

                    path = path + "\\RendicontoDaTrasferire.xml";

                    _service.SaveDtoRendiconto(path);

                    _view.GetSimpleMessageNotificator().Show("File salvato in: " + path, "Info", MessageType.Information);
                }


            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
                
            }
            



        }

        public void ViewScrittureAccantonamento()
        {
            //try
            //{
            //    ScritturePresenter presenter;

            //    presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, _sericeBilancio.Bilancio.AccantonamentoFinale.Id);


            //    presenter.InitializeForm();

            //    presenter.StartDialog();

            //    RefreshInterface();

            //}
            //catch (Exception ex)
            //{
            //    _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            //}
        }

        public void ViewContoRLST()
        {
            try
            {
                ScrittureContoRLSTPresenter presenter;

               
                presenter = new ScrittureContoRLSTPresenter(_view.ScrittureContoRLSTFormView,_rlstService,_rlstService.ContoRLST);
                
               

                presenter.InitializeForm();

                presenter.StartDialog();

                RefreshInterface();

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }

        public void StampaLibroGiornale()
        {
            _view.IsWaitPanelVisible = true;

            Thread t = new Thread(new ThreadStart(DoStampaLibroGiornale));
            t.Start();
        }


        private void DoStampaLibroGiornale()
        {
            try
            {
                string ext = "";
                bool autoFilter;

                if (_view.StampaFormatoPrimaNota)
                {
                    ext = ".pdf";
                    autoFilter = false;
                }
                else
                {
                    ext = ".xls";
                    autoFilter = true;
                }

                string file = "LibroGiornale" + _view.MainHeader;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string filename = Path.Combine(path, file + ext);

                int i = 0;
                while (System.IO.File.Exists(filename))
                {
                    i++;
                    filename = Path.Combine(path, file + i.ToString() + ext);
                } 


                ScrittureSearchCriteria c = new ScrittureSearchCriteria();
                c.NotFilterAutogenerated = autoFilter;
                if (!_view.StampaTuttoGiornale)
                {
                    c.FilterByDate = true;
                    c.DateFrom = _view.InizioStampaGiornale;
                    c.DateTo = _view.FineStampaGiornale;
                }


                if (_view.StampaFormatoPrimaNota)
                {
                    IList l = _sericeBilancio.SearchScritturePrimaNota(c);
                    _view.StampaPrimaNota(l,filename);
                }
                else
                {
                    IList<ScrittureDTO> l = _sericeBilancio.SearchScrittureGiornale(c);
                    _sericeBilancio.ExportLibroGiornale(l, filename, _view.GroupByConto, 0);
                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            finally
            {
                SimpleDelegate d = _view.HidePanel;
                _view.Invoke(d);
            }
        }

        public void UpdateRendicontoStructure()
        {
            try
            {
                
                IMessageBox v = _view.GetSimpleMessageNotificator();
                if (v.ShowAndContibue("Attenzione! La struttura del rendiconto verrà aggiornata! Si desidera proseguire?", "Domanda"))
                {
                    _service.UpdateRendicontoStructure();
                    RefreshInterface();
                    v.Show("Elaborazione terminata con successo!", "Informazione", MessageType.Information);
                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }

        public void ViewScrittureBanca3()
        {
            //try
            //{
            //    ScritturePresenter presenter;

            //    presenter = new ScritturePresenter(_view.ScrittureFormView, _sericeBilancio, _sericeBilancio.Bilancio.Banca3Finale.Id);


            //    presenter.InitializeForm();

            //    presenter.StartDialog();

            //    RefreshInterface();

            //}
            //catch (Exception ex)
            //{
            //    _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            //}
        }

        public void FillNomiBanca(ref string banca1, ref string banca2, ref string banca3, ref string banca4, ref string banca5, ref string banca6)
        {
            _service.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
        }

        public void SetNomiBanca(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            _service.SetNomiBanca(banca1, banca2, banca3, banca4, banca5, banca6);
        }
    }
}
