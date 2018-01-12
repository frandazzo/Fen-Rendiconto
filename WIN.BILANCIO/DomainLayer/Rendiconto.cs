using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.DomainLayer
{

    [XmlRootAttribute("Rendiconto", Namespace = "www.fenealgestweb.it", IsNullable = false)]
    public class Rendiconto
    {

        public const string BANCA4 = "A.D.2.d";
        public const string BANCA5 = "A.D.2.e";
        public const string BANCA6 = "A.D.2.f";
        public const String DEPOSITI_BANCARI_E_POSTALI = "A.D.2";

        public Rendiconto(string province, int year, bool isRegionale, string region )
        {

            _province = province;
            _year = year;
            _isRegionale = isRegionale;
            _region = region;


            //if (isRegionale)
            //    if (string.IsNullOrEmpty(_region))
            //        throw new ArgumentException("Bilancio regionale senza la regione specificata");

            //if (!isRegionale)
            //{
            //    if (string.IsNullOrEmpty(_province))
            //        throw new ArgumentException("Bilancio provinciale senza la provincia specificata");

            //    if (string.IsNullOrEmpty(_region))
            //        throw new ArgumentException("Bilancio provinciale senza la regione specificata");
            //}



        }


        public bool UpdateStructure(NodeUpdateList list)
        {
            if (list == null)
                return false;

            bool modified = false;
            

            foreach (NodeUpdate item in list.SubList)
            {
                if (UpdateBilancio(item))
                {
                    modified = true;
                }
            }


            return modified;
        }

        public void CheckMandatoryContosChangedByVersions()
        {
            AbstractBilancio banca = _bilancio.FindNodeById(BANCA4);
            AbstractBilancio bancaPreventivo = _preventivo.FindNodeById(BANCA4);
            if (banca == null && bancaPreventivo == null)
            {
                //vuol dire che non cè la banca allora creo la lista delle banche per il bilancio e per il preventivo
                //crerco il nodo deli depositi bancari
                AbstractBilancio depositi = _bilancio.FindNodeById(DEPOSITI_BANCARI_E_POSTALI);
                depositi.Add(new Conto("Banca4", "A.D.2.d", "A.D.2"));
                depositi.Add(new Conto("Banca5", "A.D.2.e", "A.D.2"));
                depositi.Add(new Conto("Banca6", "A.D.2.f", "A.D.2"));


                AbstractBilancio depositiPreventivo = _preventivo.FindNodeById(DEPOSITI_BANCARI_E_POSTALI);
                depositiPreventivo.Add(new ContoPreventivo("Banca4", "A.D.2.d", "A.D.2"));
                depositiPreventivo.Add(new ContoPreventivo("Banca5", "A.D.2.e", "A.D.2"));
                depositiPreventivo.Add(new ContoPreventivo("Banca6", "A.D.2.f", "A.D.2"));
            }
        }


        private AbstractBilancio CreateStructureItem(string contoType, string id, string description, string parentId)
        {
            switch (contoType)
            {
                case "ContoPreventivo":
                    return new ContoPreventivo(description, id, parentId);
                case "Conto":
                    return new Conto(description, id, parentId);
                case "Classificazione":
                    return new Classificazione(description, id, parentId);

                default:
                    return null;
                    
            }

        }



       

        private bool UpdateBilancio(NodeUpdate item)
        {
            AbstractBilancio structure = GetStructure(item);
            if (structure == null)//c'è un errore nel file
                return false;


            //il parent non può essere una stringa nulla poichè rappresenterebbe
            //la radice dell'albero che può avere solo le voci di spesa, entrate e finanza
            if (string.IsNullOrEmpty(item.ParentId))
                return false;

            //se devo aggiungere o modificare un nodo esso deve avere un 
            //id ed una descrizione  non nulli
            if (string.IsNullOrEmpty(item.Id))
                return false;
            if (string.IsNullOrEmpty(item.Description))
                return false;



            //a questo punto verifico per prima cosa l'esistenza del parent
            //se non esiste c'è un errore nel file.
            //anche se teoricamente il processo potrebbe continuare è bene che il file sia sempre corretto
            AbstractBilancio parent = structure.FindNodeById(item.ParentId);
            if (parent == null)
                return false;

            //a questo punto il parent esiste.
            //rimane da verifica che il nodo da aggiornare se esiste esiste sotto il parent 
            // altrimenti si tratta di una imprecisione nel file di aggiornamento
            AbstractBilancio nodeInStructure = structure.FindNodeById(item.Id);
            AbstractBilancio nodeInParent = structure.FindNodeById(item.Id);

            //se non sono nulli vuol dire che il nodo è al di sotto del parent
            //ed è pronto per essere modificato
            if (nodeInParent != null && nodeInStructure != null)
            {
                nodeInParent.Description = item.Description;
                return true;
            }
            else if (nodeInParent == null && nodeInStructure == null)//il nodo non esiste e va creato
            {
                AbstractBilancio b = CreateStructureItem(item.ContoType, item.Id, item.Description, item.ParentId);
                b.ParentName = parent.Description;
                parent.Add(b);
                return true;
            }
            else // c'è un errore nel file
            {
                return false;
            }


        }

        private AbstractBilancio GetStructure(NodeUpdate item)
        {
            AbstractBilancio structure = null;
            if (item.UpdateType == "Bilancio")
            {
                structure = _bilancio;
            }
            else if (item.UpdateType == "Preventivo")
            {
                structure = _preventivo;
            }
            return structure;
        }



        public DTORendiconto CreateDtoRendicontoWithSaldiInizialiBancaAtDate(DateTime date)
        {
            //prendo le totalizzazioni per verificare le quadrature
            double p = _preventivo.GetTotalAtDate(date);
            double b = _bilancio.GetTotalAtDate(date);
            double rlst = _contoRLST.GetTotalAtDate(date);
            string statoPatrimoniale = SerializeStatoPatrimoniale();


            DTORendiconto r = new DTORendiconto();

            r.Regione = _region;
            r.Provincia = _province;
            r.IsRegionale = _isRegionale;
            r.Anno = _year;
            r.Proprietario = _proprietario;
            r.ContoRLST = rlst;
            r.StatoPatrimoniale = statoPatrimoniale;
            r.Version = _version;

            if (p == 0)
                r.IsPreventivoQuadratoQuadrato = true;
            else
                r.IsPreventivoQuadratoQuadrato = false;

            if (b == 0)
                r.IsBilancioQuadrato = true;
            else
                r.IsBilancioQuadrato = false;


            r.Items = _bilancio.CreateDtoItemsListAtDate(this, true, date);


            return r;
        }



        public DTORendiconto CreateDtoRendicontoWithSaldiInizialiBanca()
        {
            //prendo le totalizzazioni per verificare le quadrature
            double p = _preventivo.GetTotal;
            double b = _bilancio.GetTotal;
            double rlst = _contoRLST.GetTotal;
            string statoPatrimoniale = SerializeStatoPatrimoniale();


            DTORendiconto r = new DTORendiconto();

            r.Regione = _region;
            r.Provincia = _province;
            r.IsRegionale = _isRegionale;
            r.Anno = _year;
            r.Proprietario = _proprietario;
            r.ContoRLST = rlst;
            r.StatoPatrimoniale = statoPatrimoniale;
            r.Version = _version;

            if (p == 0)
                r.IsPreventivoQuadratoQuadrato = true;
            else
                r.IsPreventivoQuadratoQuadrato = false;

            if (b == 0)
                r.IsBilancioQuadrato = true;
            else
                r.IsBilancioQuadrato = false;


            r.Items = _bilancio.CreateDtoItemsList(this, true);


            return r;
        }


        public DTORendiconto CreateDtoRendiconto()
        {
            //prendo le totalizzazioni per verificare le quadrature
            double p = _preventivo.GetTotal;
            double b = _bilancio.GetTotal;
            double rlst = _contoRLST.GetTotal;
            string statoPatrimoniale = SerializeStatoPatrimoniale();


            DTORendiconto r = new DTORendiconto();

            r.Regione = _region;
            r.Provincia = _province;
            r.IsRegionale = _isRegionale;
            r.Anno = _year;
            r.Proprietario = _proprietario;
            r.ContoRLST = rlst;
            r.StatoPatrimoniale = statoPatrimoniale;
            r.Version = _version;

            if (p == 0)
                r.IsPreventivoQuadratoQuadrato = true;
            else
                r.IsPreventivoQuadratoQuadrato = false;

            if (b == 0)
                r.IsBilancioQuadrato  = true;
            else
                r.IsBilancioQuadrato  = false;


            r.Items = _bilancio.CreateDtoItemsList(this);


            return r;
        }



        public void AllineaTotali()
        {
            double t = _bilancio.GetTotal;
            t = _preventivo.GetTotal;
            t= t+1;
        }

        public Rendiconto()
        {
      
        }


        
        protected Conto _contoRLST = new  Conto("Conto RLST","RLST","");
         [XmlElement( "ContoRLST")]
        public Conto ContoRLST
        {
            get { return _contoRLST; }
            set { _contoRLST = value; }
        }




        private string _sendableTag = "";

    

       
        protected string _province = "";
        protected string _region = "";
        protected bool _isRegionale;
        protected int _year = DateTime.Now.Year;
        private string _proprietario = "";


        //proprietà per memorizzare i dati bancari di un rendiconto
        private string _banca1 = "Banca1";

        [XmlElement("Banca1")]
        public string Banca1
        {
            get
            {
                return _banca1;
            }
            set
            {
                _banca1 = value;
            }
        }

        private string _banca2 = "Banca2";

        [XmlElement("Banca2")]
        public string Banca2
        {
            get
            {
                return _banca2;
            }
            set
            {
                _banca2 = value;
            }
        }

        private string _banca3 = "Banca3";

        [XmlElement("Banca3")]
        public string Banca3
        {
            get
            {
                return _banca3;
            }
            set
            {
                _banca3 = value;
            }
        }

        private string _banca4 = "Banca4";

        [XmlElement("Banca4")]
        public string Banca4
        {
            get
            {
                return _banca4;
            }
            set
            {
                _banca4 = value;
            }
        }

        private string _banca5 = "Banca5";

        [XmlElement("Banca5")]
        public string Banca5
        {
            get
            {
                return _banca5;
            }
            set
            {
                _banca5 = value;
            }
        }

        private string _banca6 = "Banca6";

        [XmlElement("Banca6")]
        public string Banca6
        {
            get
            {
                return _banca6;
            }
            set
            {
                _banca6 = value;
            }
        }



        //campo versione rendiconto necessario per stabilire la compatibilità tra versioni differenti
        private int _version = 500;
        [XmlAttribute("Versione")]
        public int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }







        [XmlAttribute("Proprietario")]
        public string Proprietario
        {
            get { return _proprietario; }
            set { _proprietario = value; }
        }

        [XmlAttribute("SendableTag")]
        public string SendableTag
        {
            get { return _sendableTag; }
            set { _sendableTag = value; }
        }




        [XmlAttribute("IsRegionale")]
        public bool IsRegionale
        {
            get { return _isRegionale; }
            set { _isRegionale = value; }
        }



        [XmlAttribute("Year")]
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        [XmlAttribute("Province")]
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        [XmlAttribute("Region")]
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }


        private BilancioNew _bilancio;

        private Preventivo _preventivo;


        [XmlElement( "Bilancio")]
        public BilancioNew Bilancio
        {
            get { return _bilancio; }
            set { _bilancio = value; }
        }

        [XmlElement("Preventivo")]
        public Preventivo Preventivo
        {
            get { return _preventivo; }
            set { _preventivo = value; }
        }


        private StatoPatrimoniale _statoPatrimoniale = new StatoPatrimoniale();

        [XmlElement("StatoPatrimoniale")]
        public StatoPatrimoniale StatoPatrimoniale
        {
            get { return _statoPatrimoniale; }
            set { _statoPatrimoniale = value; }
        }

        public string SerializeStatoPatrimoniale()
        {
            try
            {
                string result = "";
                MemoryStream ms = new MemoryStream();
                try
                {
                    XmlSerializer sf = new XmlSerializer(typeof(StatoPatrimoniale));

                    sf.Serialize(ms, _statoPatrimoniale);

                    StreamReader r = new StreamReader(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    result = r.ReadToEnd();

                }
                catch (Exception)
                {

                    result = "";
                }
                finally
                {
                    ms.Close();
                }


                return result;
            }
            catch (Exception)
            {

                return "";
            }

            
        }


        public void DeserializeStatoPatrimoniale(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                _statoPatrimoniale = new StatoPatrimoniale();
                return;
            }

            MemoryStream ms = new MemoryStream();
            try
            {

                StreamWriter sw = new StreamWriter(ms);
                sw.Write(text);
//sw.Write(text);
                sw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                XmlSerializer sf = new XmlSerializer(typeof(StatoPatrimoniale));
                 _statoPatrimoniale = sf.Deserialize(ms) as StatoPatrimoniale;
                
            
                    

            }
            catch (Exception)
            {
                _statoPatrimoniale = new StatoPatrimoniale();
            }
            finally
            {
                ms.Close();
            }


           
        }

    }
}
