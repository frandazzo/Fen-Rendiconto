using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WIN.BILANCIO.DomainLayer
{
  [Serializable]
    public class Mobile
    {

      public Mobile() { }

      [XmlAttribute("Numero")]
        public string Numero { get; set; }
      [XmlAttribute("Descrizione")]
        public string Descrizione { get; set; }
    }
}
