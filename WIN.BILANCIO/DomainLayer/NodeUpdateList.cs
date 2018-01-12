using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace WIN.BILANCIO.DomainLayer
{
    [XmlRootAttribute("ListaAggiornamentonodi", Namespace = "www.fenealgestweb.it", IsNullable = false)]
    public class NodeUpdateList
    {

        public NodeUpdateList()
        { }


        private IList _sublist = new ArrayList();


        [XmlArray("SubList"), XmlArrayItem("Update", typeof(NodeUpdate))]


        public IList SubList
        { 
            get { return _sublist;}
            set { _sublist = value; }
        }



    }
}
