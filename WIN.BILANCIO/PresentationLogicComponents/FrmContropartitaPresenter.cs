using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.DomainLayer;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public class FrmContropartitaPresenter
    {
        public void SelectConto()
        {
            string conto = "";
            INode node = _view.IerarchicalContainer.SelectedNode;
            if (node != null)//ottengo l'id del conto
                conto = node.Tag.ToString();

            if (!_service.IsConto(conto))
            {
                _view.GetSimpleMessageNotificator().Show("Specificare un conto!","Attenzione", MessageType.Exclamation);
                return;
            }


           
            // a questo punto punto chiudo la view e passo la contropartita al presenter della scrittura singola
            _view.SetDialogoResultToOK();
            _view.Close();
            _subPresenter.SetSelectedContropartita(conto, node.Text);
        }


        string _areaBilancio;
        private IFrmContropartita _view;
        private BilancioService _service;
        ScritturaSingolaPresenter _subPresenter;
        //ScritturePresenter _subViewRefresher;
        public FrmContropartitaPresenter(IFrmContropartita view, BilancioService service, ScritturaSingolaPresenter subpresenter, string conto)//, ScritturePresenter subViewRefresher)
        {
            _areaBilancio = conto;
            _view = view;
            _service = service;
            _subPresenter = subpresenter;
           // _subViewRefresher = subViewRefresher;
            _view.SetPresenter(this);
        }

        public void InitializeForm()
        {
            //Creo il binder gerarchico
            IerarchicalListBinder b = new IerarchicalListBinder();
            //if (_areaBilancio.Equals(AbstractBilancio.AREA_BILANCIO_ENTRATE))
            ////inserisco le entrate nella prima lista
            //    b.Bind(_view.IerarchicalContainer, _service.Bilancio.Entrate, true,false);
            //else if (_areaBilancio.Equals(AbstractBilancio.AREA_BILANCIO_SPESE))
            ////inserisco le uscite
            //    b.Bind(_view.IerarchicalContainer, _service.Bilancio.Spese, true, false);

            //else if (_areaBilancio.Equals(AbstractBilancio.AREA_BILANCIO_ATTIVITA))
            //    //inserisco le uscite
            //    b.Bind(_view.IerarchicalContainer, _service.Bilancio.Attivita, true, false);

            //else
            //    b.Bind(_view.IerarchicalContainer, _service.Bilancio.Passivita, true, false);

            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Attivita, true, false);
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Passivita, false, false);
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Entrate, false, false);
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Spese, false, false);

            _view.IerarchicalContainer.ExpandAll();
          
        }

        public void StartDialog()
        {

            if (!_view.ShowAndContinue())
            {
                //se ho annullato l'operazione
                _subPresenter.CancelScritturaInContropartita();
            }

            _view.Dispose();

        }
    }
}
