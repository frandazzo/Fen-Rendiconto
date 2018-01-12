using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class Auto
    {

        public Auto() { }


        [XmlAttribute("TipoMezzo")]
        public string  TipoMezzo { get; set; }


        [XmlAttribute("Intestazione")]
        public string Intestazione { get; set; }


    }
}
