using System;
using System.Collections.Generic;
using System.Text;
using WIN.BILANCIO.ServiceLayer;
using BilancioFenealgest.ServiceLayer.DTO;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public class ScritturaSingolaContoRLSTPresenter
    {
        private IScritturaSingolaContoRLSTFormView _view;
        private ContoRLSTService _service;
        private IScrittureContoRLSTFormView _subViewSyncronyzer;
        private ScrittureDTO _current;
        public ScritturaSingolaContoRLSTPresenter(IScritturaSingolaContoRLSTFormView view, ContoRLSTService service,ScrittureDTO dto, IScrittureContoRLSTFormView  scrittureView)
        {
            _current = dto;
            _subViewSyncronyzer = scrittureView;
            _service = service;
            _view = view;
            _view.SetPresenter(this);
        }

        public void InitializeForm()
        {
            _view.ComboTipoOperazione.SelectAt(1);
            _view.ComboTipoOperazione.Enabled = false;

            if (_current != null)
            {
                _view.SelectedDate = _current.Date.Date;
                _view.SelectedCausale = _current.Causale;
                _view.SelectedNumeroPezza = _current.NumeroPezza;
                _view.SelecteImporto = _current.Importo;
                
                _view.IsRecreateNewButtonEnabled = false;
                return;
            }

            _view.IsRecreateNewButtonEnabled = true;



        }


        public void StartDialog()
        {

            _view.ShowAndContinue();

            _view.Dispose();

        }




        public void CreateOrUpdateScrittura()
        {
            try
            {
                if (_current == null)
                    CreateNew();
                else
                    Update();
                _view.Close();
                _subViewSyncronyzer.SaldoConto = "Saldo conto: " + _service.Total;
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


            //lo valido
            ValidateInput(p);


            _service.AddScrittura( p);

            //se non c'è nessun errore
            //sincronizzo
            _subViewSyncronyzer.GridContainer.BoundList.Add(p);
            _subViewSyncronyzer.IsLabelVisible = false;
            _subViewSyncronyzer.SaldoConto = "Saldo conto: " + _service.Total;

        }

        private void ClearInterface()
        {
            _view.ComboTipoOperazione.SelectAt(1);
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
           

            //lo valido
            ValidateInput(p);


            //a questo punto posso chiedere al servizio di aggiornare l'oggetto 
            _service.UpdateScrittura(p);

            //se non si è verificato nessun errore sincronizzo anche l'oggetto dto corrente
            _current.Date = p.Date;
            _current.NumeroPezza = p.NumeroPezza;
            _current.Importo = p.Importo;
            _current.TipoOperazione = p.TipoOperazione;
            _current.Causale = p.Causale;
            _current.ParentName = p.ParentName;

            //adesso confermo le modifiche al grid contasiner
            _subViewSyncronyzer.GridContainer.RefreshCurrent();
            _subViewSyncronyzer.SaldoConto = "Saldo conto: " + _service.Total;

        }





        public void AddAndRecreeteNew()
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
    }
}
