using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class Deposito
    {

        public Deposito() { }

        [XmlAttribute("Denominazione")]
        public string Denominazione { get; set; }

        [XmlAttribute("ContoCorrente")]
        public string ContoCorrente { get; set; }

        [XmlAttribute("Tipo")]
        public string Tipo { get; set; }



        [XmlAttribute("IntestazioneConto")]
        public string IntestazioneConto { get; set; }

        [XmlAttribute("IsFirmaResponsabileDepositata")]
        public bool  IsFirmaResponsabileDepositata { get; set; }


        [XmlAttribute("IsFirmaAmministrativoDepositata")]
        public bool IsFirmaAmministrativoDepositata { get; set; }

    }
}
