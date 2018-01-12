using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public class StatoPatrimoniale
    {
        public StatoPatrimoniale()
        {

        }

        private IList _mobili = new ArrayList();



        [XmlArray("Mobili"), XmlArrayItem("Mobile", typeof(Mobile))]
        public IList Mobili
        {
            get { return _mobili; }
        }

        private IList _chiusure = new ArrayList();



        [XmlArray("Chiusure"), XmlArrayItem("Chiusura", typeof(Chiusura))]
        public IList Chiusure
        {
            get { return _chiusure; }
        }

         private IList _accantonamenti = new ArrayList();



        [XmlArray("AccantonamentiTFR"), XmlArrayItem("AccantonamentoTFR", typeof(AccantonamentoTFR))]
         public IList AccantonamentiTFR
        {
            get { return _accantonamenti; }
        }



        private IList _autos = new ArrayList();



        [XmlArray("Autos"), XmlArrayItem("Auto", typeof(Auto))] 
        public IList Autos
        {
            get { return _autos; }
        }


        private IList _polizze = new ArrayList();



        [XmlArray("Polizze"), XmlArrayItem("Polizza", typeof(Polizza))]
        public IList Polizze
        {
            get { return _polizze; }
        }


        private IList _immobili = new ArrayList();



        [XmlArray("Immobili"), XmlArrayItem("Immobile", typeof(Immobile))]
        public IList Immobili
        {
            get { return _immobili; }
        }

        private IList _depositi = new ArrayList();



        [XmlArray("Depositi"), XmlArrayItem("Deposito", typeof(Deposito))]
        public IList Depositi
        {
            get { return _depositi; }
        }

    }
}
