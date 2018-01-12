using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace WIN.BILANCIO.DomainLayer
{
    [Serializable]
    public class NodeUpdate
    {


        public NodeUpdate() { }

        private string _ContoType;
        [XmlAttribute("ContoType")]
        public string ContoType
        {
            get
            {
                return _ContoType;
            }
            set
            {
                _ContoType = value;
            }
        }



        private string _UpdateType;
        [XmlAttribute("UpdateType")]
        public string UpdateType
        {
            get
            {
                return _UpdateType;
            }
            set
            {
                _UpdateType = value;
            }
        }


        private string _Id;
        [XmlAttribute("Id")]
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        private string _Desciption;

        [XmlAttribute("Description")]
        public string Description
        {
            get
            {
                return _Desciption;
            }
            set
            {
                _Desciption = value;
            }
        }
        private string _ParentId;


        [XmlAttribute("ParentId")]
        public string ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                _ParentId = value;
            }
        }

    }
}
