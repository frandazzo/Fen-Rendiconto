using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.ServiceLayer.DTO;
using BilancioFenealgest.DataAccess;
using WIN.BILANCIO.ServiceLayer;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public class ExportBilancioPresenter
    {
        IFrmExportBilancio _view;
        RendicontoService _service;

        public ExportBilancioPresenter(RendicontoService r, IFrmExportBilancio credential)
        {
            
            credential.SetPresenter(this);

            _view = credential ;
            _service = r;

        }

        public void StartDialog()
        {
            _view.ShowDialogMode();
        }


        public void SendBilancio()
        {
           
                if (string.IsNullOrEmpty(_service.RendicontoSendableTag))
                {
                    _view.GetSimpleMessageNotificator().Show("Esportazione non effettuata: " + Environment.NewLine + "Il rendiconto non è stato riconosciuto come un rendiconto Feneal o un rendiconto Rlst", "Errore", BilancioFenealgest.Middleware.MessageType.Error);
                    return;
                }

                if ((_service.RendicontoSendableTag == "FENEAL" && _view.IsFeneal == false)||(_service.RendicontoSendableTag != "FENEAL" && _view.IsFeneal))
                {
                    _view.GetSimpleMessageNotificator().Show("Esportazione non effettuata: " + Environment.NewLine + "Il rendiconto Feneal deve essere esportato dal programma del Rendiconto Feneal e non da quello RLST", "Errore", BilancioFenealgest.Middleware.MessageType.Error);
                    return;
                }
                else if ((_service.RendicontoSendableTag == "RLST" && _view.IsRlst == false)||(_service.RendicontoSendableTag != "RLST" && _view.IsRlst))
                {
                    _view.GetSimpleMessageNotificator().Show("Esportazione non effettuata: " + Environment.NewLine + "Il rendiconto RLST deve essere esportato dal programma del Rendiconto RLST e non da quello Feneal", "Errore", BilancioFenealgest.Middleware.MessageType.Error);
                    return;
                }

                 if ((_service.RendicontoSendableTag == "FENEAL" && _view.IsFeneal) || (_service.RendicontoSendableTag == "RLST" && _view.IsRlst ))
                 {
                     try
                     {
                            RendicontoHeaderDTO header = _service.RendicontoHeader;
                            string place;

                            if (header.IsRegionale)
                                place = header.Regione.ToUpper();
                            else
                                place = header.Provincia.ToUpper();


                            //Creo il file temporaneo
                            string path = CreateTemporaryFile();

                            //riprendio il file materializzato
                            DTORendicontoMappaer m = new DTORendicontoMappaer();

                            DTORendiconto r = m.LoadDTORendicontoByPath(path);

                            ExportBilancioServiceAgent a = new ExportBilancioServiceAgent(r, _view.UserName, _view.Password, place, _view.IsRlst);
                               

                            //a.SendBilancio();

                            string result = a.SendBilancio();

                            if (string.IsNullOrEmpty(result))
                            {
                                _view.GetSimpleMessageNotificator().Show("Esportazione terminata con successo!", "Info", BilancioFenealgest.Middleware.MessageType.Information);
                            }
                            else
                            {
                                _view.GetSimpleMessageNotificator().Show("Esportazione non effettuata: " + Environment.NewLine + result, "Errore", BilancioFenealgest.Middleware.MessageType.Error);
                                
                            }

                        }
                        catch (Exception ex)
                        {
                            _view.GetSimpleMessageNotificator().Show("Esportazione non effettuata: " + Environment.NewLine + ex.Message, "Errore", BilancioFenealgest.Middleware.MessageType.Error); 
                        }
                }

        }

        private string CreateTemporaryFile()
        {
            string path = System.IO.Path.GetTempPath();

            path = path + "\\" + Guid.NewGuid().ToString() + ".xml";

            _service.SaveDtoRendiconto(path);

            return path;
        }
    }
}
