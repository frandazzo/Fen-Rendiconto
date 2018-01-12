using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using WIN.BILANCIO.DomainLayer;
using System.Collections;

namespace BilancioFenealgest.ServiceLayer
{
    public class PreventivoService : BilancioService 
    {
       

          public PreventivoService(BilancioNew preventivo):base(preventivo)
        {
            
        }


          public void UpdateSituazioneFinanziariaIniziale(BilancioNew bilancio)
          {
              //_bilancio.Banca1Iniziale.Importo = bilancio.SaldoBanca1;
              //_bilancio.Banca2Iniziale.Importo = bilancio.SaldoBanca2;
              //_bilancio.Banca3Iniziale.Importo = bilancio.SaldoBanca3;

              //_bilancio.CassaIniziale.Importo = bilancio.SaldoCassa;
              //_bilancio.AccantonamentoIniziale.Importo = bilancio.SaldoAccantonamento;


              //devo recuperare dal bilancio la lista di tutti i conti delle attività e delle passivita
              //ed impostare il loro totale come importo nei rispettivi conti del preventivo
 
              //recupero i conti delle passività
              AbstractBilancio pass = bilancio.Passivita;
              //recupero la lista dei conti delle passività
              IList contiPassivita = bilancio.CreateListaConti(pass.Id);
              //eseguo un ciclo su tali conti per valorizzare le passività del preventivo

              foreach (Conto item in contiPassivita)
              {
                  //cerco il conto del preventivo analogo a quello del bilancio
                  ContoPreventivo c = _bilancio.FindNodeById(item.Id) as ContoPreventivo;
                  if (c != null)
                      c.Importo = item.GetTotal;

              }


              //ora ripeto la stessa cosa per le attività

              //recupero i conti delle passività
              AbstractBilancio att = bilancio.Attivita;
              //recupero la lista dei conti delle passività
              IList contiatt = bilancio.CreateListaConti(att.Id);
              //eseguo un ciclo su tali conti per valorizzare le passività del preventivo

              foreach (Conto item1 in contiatt)
              {
                  //cerco il conto del preventivo analogo a quello del bilancio
                  ContoPreventivo c1 = _bilancio.FindNodeById(item1.Id) as ContoPreventivo;
                  if (c1 != null)
                      c1.Importo = item1.GetTotal;

              }






              double t = _bilancio.GetTotal;

              ContoPreventivo pp = _bilancio.FindNodeById("P.P.1") as ContoPreventivo;
              pp.Importo = pp.Importo - t;

               t =_bilancio.GetTotal;

              RaiseChangeEvent();
          }



          public void SetImportoConto(string _idConto, decimal p)
          {
              _bilancio.FindNodeById(_idConto).Importo = Convert.ToDouble(p);
              RaiseChangeEvent();
          }
    }
}
