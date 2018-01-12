using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WIN.BILANCIO.DomainLayer
{
    [Serializable]
    public class Chiusura
    {
          public Chiusura() { }

        [XmlAttribute("Anno")]
        public string Anno { get; set; }
        [XmlAttribute("Avanzo")]
        public string Avanzo { get; set; }
        [XmlAttribute("Disavanzo")]
        public string Disavanzo { get; set; }
    }
}
