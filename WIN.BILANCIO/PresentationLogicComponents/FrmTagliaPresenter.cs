using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer.DTO;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public class FrmTagliaPresenter
    {
        private IFrmTaglia _view;
        private BilancioService _service;
        IScrittureFormView _subViewSyncronyzer;
        ScritturePresenter _subViewRefresher;
        public FrmTagliaPresenter(IFrmTaglia view, BilancioService service, IScrittureFormView subViewSyncronyzer, ScritturePresenter subViewRefresher)
        {
            _view = view;
            _service = service;
            _subViewSyncronyzer = subViewSyncronyzer;
            _subViewRefresher = subViewRefresher;
            _view.SetPresenter(this);
        }

        public void InitializeForm()
        {
            //Creo il binder gerarchico
            IerarchicalListBinder b = new IerarchicalListBinder();

            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Attivita, true,false);


            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Spese, false, false);

            //inserisco le entrate nella prima lista
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Passivita, false, false);

            //inserisco le uscite
            b.Bind(_view.IerarchicalContainer, _service.Bilancio.Entrate, false, false);
            //b.Bind(_view.IerarchicalContainer1, _sericeBilancio.Bilancio.FinanzaFinale, false);

            _view.IerarchicalContainer.ExpandAll();
          
        }

        public void StartDialog()
        {

            _view.ShowAndContinue();

            _view.Dispose();

        }

        public void PasteData()
        {
            try
            {
                //recupero la lista delle scritture selezionate
                IList<ScrittureDTO> scritture = TipoOperazioneDecoder.ConvertGUIValuesToDomainValues(_subViewSyncronyzer.GridContainer.CurrentObjects(), _subViewSyncronyzer.Banca1, _subViewSyncronyzer.Banca2, _subViewSyncronyzer.Banca3, _subViewSyncronyzer.Banca4, _subViewSyncronyzer.Banca5, _subViewSyncronyzer.Banca6);
                //recupero il conto di arrivo
                string conto = "";
                INode node = _view.IerarchicalContainer.SelectedNode;
                if (node != null)
                    conto = node.Tag.ToString();


                //eseguo il paste
                int dataPasted = _service.PasteScritture(conto, scritture);

                //verificare la necessità di un refresh
                if (dataPasted > 0)
                {
                    _subViewRefresher.InitializeForm();
                    _view.GetSimpleMessageNotificator().Show("Sono state incollate " + dataPasted.ToString() + " scritture", "Messaggio", MessageType.Information);
                    _view.Close();
                }
                else
                    _view.GetSimpleMessageNotificator().Show("Nessun elemento incollato", "Messaggio", MessageType.Information); 
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message , "Errore", MessageType.Error); 
            }
        }
    }
}
