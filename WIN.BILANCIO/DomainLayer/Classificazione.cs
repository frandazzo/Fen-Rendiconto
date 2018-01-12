using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class Classificazione : AbstractBilancio
    {


        public Classificazione()
        {
            
        }


        public Classificazione(string description, string id, string parentId)
            : base(id,parentId )
        {
            _description = description;
            _id = id;
        }

        [XmlIgnore]
        public override bool IsLeaf
        {
            get { return false; }
        }


       
       
        


    }
}
