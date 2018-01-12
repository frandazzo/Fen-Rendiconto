using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using WIN.BASEREUSE;

namespace BilancioFenealgest.DomainLayer
{
    [XmlRootAttribute("DTORendiconto", Namespace = "www.fenealgestweb.it", IsNullable = false)]
    public class DTORendiconto 
    {

        [XmlAttribute("Regione")]
        public string Regione { get; set; }
        [XmlAttribute("Proprietario")]
        public string Proprietario { get; set; }
        [XmlAttribute("Provincia")]
        public string Provincia { get; set; }
        [XmlAttribute("Anno")]
        public int Anno { get; set; }
        [XmlAttribute("IsRegionale")]
        public bool  IsRegionale { get; set; }
        [XmlAttribute("IsBilancioQuadrato")]
        public bool  IsBilancioQuadrato { get; set; }
        [XmlAttribute("IsPreventivoQuadrato")]
        public bool IsPreventivoQuadratoQuadrato { get; set; }

        [XmlAttribute("StatoPatrimoniale")]
        public string StatoPatrimoniale { get; set; }
        [XmlAttribute("ContoRLST")]
        public double ContoRLST { get; set; }

        [XmlAttribute("Versione")]
        public int Version { get; set; }


        [XmlArray("Items"), XmlArrayItem("Item", typeof(DTORendicontoItem))] 
        public IList Items { get;  set; }

        public DTORendiconto()
        {
            Items = new ArrayList();
        }


        //public void SetParentReferenceOnChildren()
        //{
        //    foreach (DTORendicontoItem  item in Items )
        //    {
        //        item.Parent = this;
        //    }
        //}

    }
}
