using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class ImportoContoPresenter
    {

        IFrmContoView _view; 
        PreventivoService _service;
        BilancioService _bilancioService;
        string _idConto;
        ScritturePresenter _viewSincronizer;

        public ImportoContoPresenter(IFrmContoView view, PreventivoService service, string idConto)
        {
            _service = service;
            _view = view;
            _view.SetPresenter(this);
            _idConto = idConto;
        }

        public ImportoContoPresenter(IFrmContoView view, BilancioService service, string idConto, ScritturePresenter viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
            _bilancioService = service;
            _view = view;
            _view.SetPresenter(this);
            _idConto = idConto;
        }



        public void InitializeForm()
        {

            if (_service != null)
            {
                AbstractBilancio b = _service.Bilancio.FindNodeById(_idConto) as ContoPreventivo;


                if (b == null)
                    throw new Exception("Selezionare un conto!");


                _view.CaptionText = "Conto: " + b.Description;

                _view.SelectedImporto = (decimal)b.Importo;
            }
            else
            {
                AbstractBilancio b = _bilancioService.Bilancio.FindNodeById(_idConto) as Conto;


                if (b == null)
                    throw new Exception("Selezionare un conto!");


                _view.CaptionText = "Conto: " + b.Description;

                _view.SelectedImporto = (decimal)b.SaldoIniziale;
            
            
            }

        }

        public void StartDialog()
        {
            _view.ShowDialogMode();
        }

        public  void SetNewImporto()
        {
            if (_service != null)
            {
                _service.SetImportoConto(_idConto, _view.SelectedImporto);
            }
            else
            {
                _bilancioService.SetSaldoConto(_idConto, _view.SelectedImporto);
                _viewSincronizer.RefreshSaldoConto();
            }
            _view.Close();
        }
    }
}
