using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class Immobile
    {
        public Immobile() { DataAcquisto = DateTime.Now.Date; }

        [XmlAttribute("Ubicazione")]
        public string Ubicazione { get; set; }

        [XmlAttribute("Via")]
        public string Via { get; set; }

        [XmlAttribute("NumCivico")]
        public string NumCivico { get; set; }


        [XmlAttribute("PartitaCatastale")]
        public string PartitaCatastale { get; set; }


        [XmlAttribute("UtilizzataDa")]
        public string UtilizzataDa { get; set; }


        [XmlAttribute("IntestazioneProprieta")]
        public string IntestazioneProprieta { get; set; }


        [XmlAttribute("DataAcquisto")]
        public DateTime DataAcquisto { get; set; }
    }
}
