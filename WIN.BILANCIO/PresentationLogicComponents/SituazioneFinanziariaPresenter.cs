using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.ServiceLayer.DTO;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class SituazioneFinanziariaPresenter
    {

        ISituazioneFianziariaformView _view;
        BilancioService _service;
        bool _initial;

        public SituazioneFinanziariaPresenter(ISituazioneFianziariaformView view, BilancioService service, bool initial)
        {
            _view = view;
            _service = service;
            _initial = initial;


            _view.SetPresenter(this);
        }



        public  void InitializeForm()
        {
            SetInterfaceState();
            LoadProperties();
        }

        private void LoadProperties()
        {
            if (_initial)
            {
                FinanzaInizialeDTO dto = _service.FinanzaIniziale;
                _view.SelectedAccantonamenti = (decimal)dto.Accantonamenti;
                _view.SelectedCassa = (decimal)dto.Cassa;
                _view.SelectedBanca = (decimal)dto.Banca1;
                _view.SelectedBanca2 = (decimal)dto.Banca2;
                _view.SelectedBanca3 = (decimal)dto.Banca3;
            }
            else
            {
                //FinanzaFinaleDTO  dto = _service.FinanzaFinale;
                //_view.SelectedBanca = (decimal)dto.Banca;
            }
        }

        private void SetInterfaceState()
        {
            if (_initial)
            {
                _view.IsLabelCassaVisible = true;
                _view.IsNumUpDownCassaVisible = true;
                _view.IsLabelAccantonamentoVisible = true;
                _view.IsNumUpDownAccantonamentoVisible = true;
                _view.ViewCaption = "Liquidità iniziale";
            }
            else
            {

                _view.IsLabelCassaVisible = false;
                _view.IsNumUpDownCassaVisible = false;
                _view.IsLabelAccantonamentoVisible = false;
                _view.IsNumUpDownAccantonamentoVisible = false;
                _view.ViewCaption = "Liquidità finale";
            }
        }

        public bool StartDialog()
        {
            bool result = false;
            if (_view.ShowAndContinue())
                result = true;
            _view.Dispose();
            return result;
        }

        public void UpdateFinanza()
        {
            if (_initial)
            {
                FinanzaInizialeDTO dto = new FinanzaInizialeDTO();
                dto.Accantonamenti = _view.SelectedAccantonamenti;
                dto.Cassa = _view.SelectedCassa;
                dto.Banca1 =_view.SelectedBanca;
                dto.Banca2 = _view.SelectedBanca2;
                dto.Banca3 = _view.SelectedBanca3;
                _service.FinanzaIniziale = dto;
            }
            else
            {
                //FinanzaFinaleDTO dto = new FinanzaFinaleDTO();
                //dto.Banca = _view.SelectedBanca;
                //_service.FinanzaFinale = dto;
            }
        }
    }
}
