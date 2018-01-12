using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class Polizza
    {

        public Polizza() { }

        [XmlAttribute("DenominazioneCompagnia")]
        public string DenominazioneCompagnia { get; set; }

        [XmlAttribute("NumeroPolizza")]
        public string NumeroPolizza { get; set; }

        [XmlAttribute("DenominazioneSocieta")]
        public string DenominazioneSocieta { get; set; }

        [XmlAttribute("Tipo")]
        public string Tipo { get; set; }

    }
}
