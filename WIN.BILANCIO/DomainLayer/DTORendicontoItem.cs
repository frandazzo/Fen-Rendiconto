using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WIN.BASEREUSE;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class DTORendicontoItem 
    {
        [XmlAttribute("IdNodo")]
        public string IdNodo { get; set; }
        [XmlAttribute("IdNodoPadre")]
        public string IdNodoPadre { get; set; }
        [XmlAttribute("Livello")]
        public int Livello { get; set; }
        [XmlAttribute("DescrizioneNodo")]
        public string DescrizioneNodo { get; set; }
        [XmlAttribute("ImportoNodoBilancio")]
        public double ImportoBilancio { get; set; }
        //[XmlIgnore]
        //public double SaldoIninziale { get; set; }
        [XmlAttribute("ImportoNodoPreventivo")]
        public double ImportoPreventivo { get; set; }
        [XmlAttribute("IsLeaf")]
        public bool  IsLeaf { get; set; }


        //[XmlIgnore]
        //public DTORendiconto Parent { get; set; }

        public DTORendicontoItem() { }
    }
}
