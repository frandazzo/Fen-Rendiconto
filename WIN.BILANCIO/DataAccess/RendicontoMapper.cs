using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using WIN.TECHNICAL.MIDDLEWARE.XmlSerializzation;

namespace BilancioFenealgest.DataAccess
{
    public class RendicontoMapper
    {
        public Rendiconto LoadRendicontoByPath(string path)
        {
            return ObjectXMLSerializer<Rendiconto>.Load(path);
        }


        public void SaveRendiconto(Rendiconto f,string path)
        {
            ObjectXMLSerializer<Rendiconto>.Save(f, path);
        }
    }
}
