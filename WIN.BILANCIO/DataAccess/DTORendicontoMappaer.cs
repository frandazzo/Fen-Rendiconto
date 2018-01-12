using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using WIN.TECHNICAL.MIDDLEWARE.XmlSerializzation;

namespace BilancioFenealgest.DataAccess
{
    public class DTORendicontoMappaer
    {
        public DTORendiconto LoadDTORendicontoByPath(string path)
        {
            return ObjectXMLSerializer<DTORendiconto>.Load(path);
        }


        public void SaveDTORendiconto(DTORendiconto f, string path)
        {
            ObjectXMLSerializer<DTORendiconto>.Save(f, path);
        }
    }
}
