using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WIN.BILANCIO.DomainLayer
{
    [Serializable]
    public class AccantonamentoTFR
    {
        public AccantonamentoTFR() { }

        [XmlAttribute("Anno")]
        public string Anno { get; set; }
        [XmlAttribute("Importo")]
        public string Importo { get; set; }
        [XmlAttribute("Note")]
        public string Note { get; set; }
    }
}
