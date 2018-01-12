using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using BilancioFenealgest.DomainLayer;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WIN.BILANCIO.ServiceLayer
{
    public class ExportBilancioServiceAgent
    {

        private DTORendiconto _rendiconto;


        private string _password;
        private string _userName;
        private string _place;
        private bool _forRlst = false;

     


        public ExportBilancioServiceAgent(DTORendiconto rendiconto, string userName, string password,  string place, bool forRlst)
        {
            _userName = userName ;
            _rendiconto = rendiconto;
            _password = password;
            _place = place;
            _forRlst = forRlst;
        }


        public string SendBilancio()
        {

            

            //effettuo la prima validazione
            if (_rendiconto.IsRegionale)
            {
                CheckRegione(_rendiconto);
            }
            else
            {
                CheckRegioneProvincia(_rendiconto);
            }
            //effettuo la trasformazione con i proxy
            FenealgestServices.DTORendiconto r = TransformToProxyCompatibleData();


            FenealgestServices.Credenziali c = new FenealgestServices.Credenziali();
            c.UserName = _userName ;
            c.Password = _password ;
            c.Province = _place;

            FenealgestServices.FenealgestwebServices service = new FenealgestServices.FenealgestwebServices();

            service.CredenzialiValue = c;

            string result = "";

            if (_forRlst)
                result = service.ImportRendicontoRlstNew(r);
            else
                result = service.ImportRendicontoNew(r);
               

            return result;
        }

        private void CheckRegione(DTORendiconto r)
        {
            try
            {
                Regione reg = BilancioFenealgest.ServiceLayer.GeoElements.GeoHandlerProvider.Instance.Geo.GetGeoHandler().GetRegioneByName(_place);


                string regioneName = reg.Descrizione;


                //li confornto con i dati del rendiconto
                bool validated = true;




                if (!r.Regione.ToUpper().Equals(regioneName.ToUpper()))
                    validated = false;

                if (!validated)
                    throw new Exception("Regione  non compatibile con l'utente loggato");

            }
            catch (Exception ex)
            {
                throw new Exception("Validazione compatibilità regione provincia non riuscita!" + Environment.NewLine + ex.Message);
            }
        }

        private FenealgestServices.DTORendiconto TransformToProxyCompatibleData()
        {
            FenealgestServices.DTORendiconto r = new FenealgestServices.DTORendiconto();

            r.Anno = _rendiconto.Anno;
            r.IsBilancioQuadrato = _rendiconto.IsBilancioQuadrato;
            r.IsPreventivoQuadrato = _rendiconto.IsPreventivoQuadratoQuadrato;
            r.IsRegionale = _rendiconto.IsRegionale;
            r.Proprietario = _rendiconto.Proprietario;
            r.Provincia = _rendiconto.Provincia;
            r.Regione = _rendiconto.Regione;
            r.StatoPatrimoniale = _rendiconto.StatoPatrimoniale;
            r.ContoRLST = _rendiconto.ContoRLST;
            r.Versione = _rendiconto.Version;

            FenealgestServices.DTORendicontoItem[] items = new FenealgestServices.DTORendicontoItem[] { };
            foreach (DTORendicontoItem item in _rendiconto.Items)
            {
                FenealgestServices.DTORendicontoItem i = new FenealgestServices.DTORendicontoItem();
                i.DescrizioneNodo = item.DescrizioneNodo;
                i.IdNodo = item.IdNodo;
                i.IdNodoPadre = item.IdNodoPadre;
                i.ImportoNodoBilancio = item.ImportoBilancio;
                i.ImportoNodoPreventivo = item.ImportoPreventivo;
                i.IsLeaf = item.IsLeaf;
                i.Livello = item.Livello;

                Array.Resize<FenealgestServices.DTORendicontoItem>(ref items, items.Length + 1);
                items[items.Length - 1] = i;
            }

            r.Items = items;



            return r;
        }



        private void CheckRegioneProvincia(DTORendiconto r)
        {
            try
            {
                Provincia provincia = BilancioFenealgest.ServiceLayer.GeoElements.GeoHandlerProvider.Instance.Geo.GetGeoHandler().GetProvinciaByName(_place);


                string regioneName = BilancioFenealgest.ServiceLayer.GeoElements.GeoHandlerProvider.Instance.Geo.GetGeoHandler().GetRegioneById(provincia.IdRegione.ToString()).Descrizione;
                string ProvinciaName = provincia.Descrizione;


                //li confornto con i dati del rendiconto
                bool validated = true;

                if (!r.Provincia.ToUpper().Equals(ProvinciaName.ToUpper()))
                    validated = false;


                if (!r.Regione.ToUpper().Equals(regioneName.ToUpper()))
                    validated = false;

                if (!validated)
                    throw new Exception("Regione o provincia non compatibili con l'utente loggato");

            }
            catch (Exception ex)
            {
                throw new Exception("Validazione compatibilità regione provincia non riuscita!" + Environment.NewLine + ex.Message);
            }


        }
    }
}
