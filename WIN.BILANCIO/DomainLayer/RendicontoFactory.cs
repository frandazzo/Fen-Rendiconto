using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.MIDDLEWARE.XmlSerializzation;
using BilancioFenealgest.DataAccess;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.DomainLayer
{
    public class RendicontoFactory
    {

        public static Rendiconto CreateRendiconto(bool provinciale, string provincia, int anno, string regione)
        {
            IRendicontoFactory f;

            if (provinciale)
            {
                f = new RendicontoProvincialeFactory();
            }
            else
            {
                f = new RendicondoRegionaleFactory();
            }


            return f.GetNewRendiconto(provincia, anno,regione ,!provinciale );

        }

        public static Rendiconto CreateRendiconto(string template)
        {

            Rendiconto r =  ObjectXMLSerializer<Rendiconto>.Load(template);
            r.Bilancio.CalculateParentName();
            r.Preventivo.CalculateParentName();

            return r;

        }

        public static Rendiconto CreateRendiconto(DTORendiconto dto, string template)
        {
            Rendiconto r = MaterializeRendiconto(template);

            r.Province = dto.Provincia;
            r.Proprietario = dto.Proprietario;
            r.Region = dto.Regione;
            r.Year = dto.Anno;
            r.IsRegionale = dto.IsRegionale;

            //questa istruzione è neecessaria per calcolare i totali sui conti e 
            //non sulle scritture

            r.Bilancio = r.Preventivo;

            BilancioNew b = r.Bilancio;
           // Bilancio p = r.Preventivo;

            foreach (DTORendicontoItem item in dto.Items)
            {
                AbstractBilancio c = b.FindNodeById(item.IdNodo) as ContoPreventivo;
                if (c != null)
                    c.Importo = item.ImportoBilancio;

                //AbstractBilancio c1 = p.FindNodeById(item.IdNodo) as ContoPreventivo;
                //if (c1 != null)
                //    c1.Importo = item.ImportoPreventivo;

            }


            return r;
        }



        public static Rendiconto CreateRendiconto(DTORendiconto dto)
        {
            Rendiconto r = CreateRendiconto(!dto.IsRegionale, dto.Provincia, dto.Anno, dto.Regione);

            
            r.Proprietario = dto.Proprietario;


            //questa istruzione è neecessaria per calcolare i totali sui conti e 
            //non sulle scritture

            r.Bilancio = r.Preventivo;

            BilancioNew b = r.Bilancio;
            //Bilancio p = r.Preventivo;

            foreach (DTORendicontoItem item in dto.Items)
            {
                AbstractBilancio c = b.FindNodeById(item.IdNodo) as ContoPreventivo;
                if (c != null)
                    c.Importo = item.ImportoBilancio;




                //AbstractBilancio c1 = p.FindNodeById(item.IdNodo) as ContoPreventivo;
                //if (c1 != null)
                //    c1.Importo = item.ImportoPreventivo;

            }


            return r;
        }

        private static Rendiconto MaterializeRendiconto(string template)
        {
            RendicontoMapper m = new RendicontoMapper();
            return m.LoadRendicontoByPath(template);
        }
        

    }
}
