using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.DomainLayer
{
    [Serializable]
    public abstract class AbstractBilancio : IIerarchicalObject
    {

        public static readonly  string AREA_BILANCIO_ATTIVITA = "Attivita'";
        public static readonly string AREA_BILANCIO_PASSIVITA = "Passivita'";
        public static readonly string AREA_BILANCIO_SPESE = "Spese";
        public static readonly string AREA_BILANCIO_ENTRATE = "Entrate";

        protected string _id = "";
        protected string _parentId = "";
        protected string _parentName = "";
        

        public AbstractBilancio(string id, string parentId)
        {
            _id = id;
            _parentId = parentId;
        }


        public IList CreateListaConti(string nodeId)
        {

            IList result = new ArrayList();

            //definisco il nodo da dove eseguire la ricerca dei conti
            AbstractBilancio mainNode = null;

            //se il node id è nullo allora il main node sarà se stesso
            if (string.IsNullOrEmpty(nodeId))
                mainNode = this;
            else
                mainNode = this.FindNodeById(nodeId);


            if (mainNode == null)
                return result;

            
            //se il nodo è una foglia lo aggiungo alla lista e ritorno
            if ((mainNode.IsLeaf))
            {
                result.Add(mainNode);
                return result;
            }

            DoCreateListConti(result, mainNode);

            return result;
        }

        private void DoCreateListConti(IList result, AbstractBilancio mainNode)
        {
            foreach (AbstractBilancio item in mainNode.SubList)
            {
                if (item.IsLeaf)
                    result.Add(item);
                else
                    DoCreateListConti(result, item);
            }
        }

        public IList CreateDtoItemsListAtDate(Rendiconto rendiconto, bool registerSaldiInizialiBanca, DateTime date)
        {
            IList items = new ArrayList();


            FillDTORendicontoItemListAtDate(items, rendiconto, 0, date);


            //recupero dagli items i saldi iniziali delle banche
            //tramite i relativi id
            Conto banca1 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.a");
            Conto banca2 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.b");
            Conto banca3 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.c");
            Conto banca4 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.d");
            Conto banca5 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.e");
            Conto banca6 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.f");
            Conto cassa = (Conto)rendiconto.Bilancio.FindNodeById("A.D.1");

            DTORendicontoItem i1 = CreateItemForSaldiIniziali(banca1.Id, banca1.SaldoIniziale);
            DTORendicontoItem i2 = CreateItemForSaldiIniziali(banca2.Id, banca2.SaldoIniziale);
            DTORendicontoItem i3 = CreateItemForSaldiIniziali(banca3.Id, banca3.SaldoIniziale);
            DTORendicontoItem i4 = CreateItemForSaldiIniziali(banca4.Id, banca4.SaldoIniziale);
            DTORendicontoItem i5 = CreateItemForSaldiIniziali(banca5.Id, banca5.SaldoIniziale);
            DTORendicontoItem i6 = CreateItemForSaldiIniziali(banca6.Id, banca6.SaldoIniziale);

            DTORendicontoItem cas = CreateItemForSaldiIniziali(cassa.Id, cassa.SaldoIniziale);

            items.Add(i1);
            items.Add(i2);
            items.Add(i3);
            items.Add(i4);
            items.Add(i5);
            items.Add(i6);
            items.Add(cas);

            return items;
        }

        public IList CreateDtoItemsList(Rendiconto rendiconto, bool registerSaldiInizialiBanca)
        {
            IList items = new ArrayList();


            FillDTORendicontoItemList(items, rendiconto, 0);


            //recupero dagli items i saldi iniziali delle banche
            //tramite i relativi id
            Conto banca1 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.a");
            Conto banca2 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.b");
            Conto banca3 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.c");
            Conto banca4 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.d");
            Conto banca5 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.e");
            Conto banca6 = (Conto)rendiconto.Bilancio.FindNodeById("A.D.2.f");
            Conto cassa = (Conto)rendiconto.Bilancio.FindNodeById("A.D.1");

            DTORendicontoItem i1 = CreateItemForSaldiIniziali(banca1.Id, banca1.SaldoIniziale);
            DTORendicontoItem i2 = CreateItemForSaldiIniziali(banca2.Id, banca2.SaldoIniziale);
            DTORendicontoItem i3 = CreateItemForSaldiIniziali(banca3.Id, banca3.SaldoIniziale);
            DTORendicontoItem i4 = CreateItemForSaldiIniziali(banca4.Id, banca4.SaldoIniziale);
            DTORendicontoItem i5 = CreateItemForSaldiIniziali(banca5.Id, banca5.SaldoIniziale);
            DTORendicontoItem i6 = CreateItemForSaldiIniziali(banca6.Id, banca6.SaldoIniziale);

            DTORendicontoItem cas = CreateItemForSaldiIniziali(cassa.Id, cassa.SaldoIniziale);

            items.Add(i1);
            items.Add(i2);
            items.Add(i3);
            items.Add(i4);
            items.Add(i5);
            items.Add(i6);
            items.Add(cas);

            return items;
        }


        protected DTORendicontoItem CreateItemForSaldiIniziali(string contoId, double saldoIniziale)
        {
            DTORendicontoItem i = new DTORendicontoItem();
           
            i.IdNodo = contoId + "si";
            
            i.DescrizioneNodo = "";
            i.ImportoBilancio = saldoIniziale ;
          
            i.Livello = 0;
            i.IsLeaf = true;
            //se sono nella root (nodo bialncio senza id)
           
            i.ImportoPreventivo = 0;

            return i;
        }


        public IList CreateDtoItemsList(Rendiconto rendiconto)
        {
            IList items = new ArrayList();

            
            FillDTORendicontoItemList(items, rendiconto, 0);
        
            return items;
        }

        private DTORendicontoItem FindDTOByID(string p, IList items)
        {
            foreach (DTORendicontoItem item in items)
            {
                if (item.IdNodo == p)
                    return item;
            }
            return null;
        }
        protected void FillDTORendicontoItemListAtDate(IList items, Rendiconto rendiconto, int livello, DateTime date)
        {
            //inserisco il dato relativo al nodo corrente
            DTORendicontoItem i = new DTORendicontoItem();
            if (string.IsNullOrEmpty(_id))
                i.IdNodo = "Bilancio";
            else
                i.IdNodo = _id;
            if (string.IsNullOrEmpty(_parentId))
            {
                if (!string.IsNullOrEmpty(_id))
                    i.IdNodoPadre = "Bilancio";
                else
                    i.IdNodoPadre = "";
            }
            else
            {
                i.IdNodoPadre = _parentId;
            }
            i.DescrizioneNodo = _description;
            i.ImportoBilancio = GetTotalAtDate(date);
            //i.SaldoIninziale = _saldoIniziale;
            i.Livello = livello;
            i.IsLeaf = this.IsLeaf;
            //se sono nella root (nodo bialncio senza id)
            if (_id == "")
                i.ImportoPreventivo = 0;
            else
            {
                AbstractBilancio b = rendiconto.Preventivo.FindNodeById(_id);
                if (b != null)
                    i.ImportoPreventivo = b.GetTotalAtDate(date);
            }
            //aggiungo alla lista
            items.Add(i);

            //inserisco il dato relativo ai nodi figli se 
            //non sono su una foglia
            if (!IsLeaf)
            {
                int lev = livello + 1;
                foreach (AbstractBilancio item in _sublist)
                {
                    item.FillDTORendicontoItemListAtDate(items, rendiconto, lev, date);
                }
            }


        }

        protected void FillDTORendicontoItemList(IList items,Rendiconto rendiconto,int livello)
        {
            //inserisco il dato relativo al nodo corrente
            DTORendicontoItem i = new DTORendicontoItem();
            if (string.IsNullOrEmpty(_id))
                i.IdNodo = "Bilancio";
            else
                i.IdNodo = _id;
            if (string.IsNullOrEmpty(_parentId))
            {
                if (!string.IsNullOrEmpty(_id))
                    i.IdNodoPadre = "Bilancio";
                else
                    i.IdNodoPadre = "";
            }
            else
            {
                i.IdNodoPadre = _parentId;
            }
            i.DescrizioneNodo = _description;
            i.ImportoBilancio = GetTotal;
           //i.SaldoIninziale = _saldoIniziale;
            i.Livello = livello;
            i.IsLeaf = this.IsLeaf;
            //se sono nella root (nodo bialncio senza id)
            if (_id == "")
                i.ImportoPreventivo = 0;
            else
            {
                AbstractBilancio b = rendiconto.Preventivo.FindNodeById(_id);
                if (b != null)
                    i.ImportoPreventivo = b.GetTotal;
            }
            //aggiungo alla lista
            items.Add(i);

            //inserisco il dato relativo ai nodi figli se 
            //non sono su una foglia
            if (!IsLeaf)
            {
                int lev = livello + 1;
                foreach (AbstractBilancio  item in _sublist)
                {
                    item.FillDTORendicontoItemList(items, rendiconto, lev);
                }
            }


        }

        //questa propriètà restituisce l'area di bilancio di un rendiconto
        //le aree possono essere quelle delle attivita, passivita, entrate e uscite
        [XmlIgnore]
        public string AreaDiBilancio
        {
            get
            {

                return this.Id.Substring(0, 1);

            }
        }


        [XmlIgnore]
        public string AreaDiBilancioToString
        {
            get
            {

                if (AreaDiBilancio.Equals("A"))
                    return AREA_BILANCIO_ATTIVITA;
                else if (AreaDiBilancio.Equals("P"))
                    return AREA_BILANCIO_PASSIVITA;
                else if (AreaDiBilancio.Equals("E"))
                    return AREA_BILANCIO_ENTRATE;
                else
                    return AREA_BILANCIO_SPESE;
            }
        }



        public AbstractBilancio()
        {
        }


        [XmlAttribute("Id")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlAttribute("ParentId")]
        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        [XmlAttribute("ParentName")]
        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }

        protected string _description = "";
        protected double _importo = 0;

        protected double _saldoIniziale = 0;



        protected string _separator = "|";

        protected IList _sublist = new ArrayList();




        public void CalculateParentName()
        {
            foreach (AbstractBilancio  item in _sublist)
            {
                item.ParentName = _description;
                item.CalculateParentName();
            }
        }



        /// <summary>
        /// Inmposta il separatore nel percorso per il raggiungimento di un nodo
        /// Il percorso per raggiungere un nodo viene utilizzato nel metodo Find
        /// per raggiungere celermente un nodo del bilancio
        /// </summary>
        /// <param name="separator"></param>
        public void SetNodePathSeparator(string separator)
        {
            _separator = separator;
            foreach (AbstractBilancio  item in _sublist)
            {
                item.SetNodePathSeparator(separator);
            }
        }

        public IList SearchScritture(ScrittureSearchCriteria criteria)
        {
            IList list = new ArrayList();

            DoSearch(list, criteria);


            return list;
        }

        protected virtual void DoSearch(IList list, ScrittureSearchCriteria criteria)
        {
            foreach (AbstractBilancio item in _sublist)
            {
                item.DoSearch(list, criteria);
            }
        }


        /// <summary>
        /// Metodo per la ricerca di un nodo all'interno del bilancio per mezzo della 
        /// descrizione del nodo all'interno di un percorso.
        /// La ricerca si ferma ai conti e non procede nelle relative scritture
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AbstractBilancio FindNodeByDescriptionPath(string path)
        {
            //splitto il percorso
            string[] arr = path.Split(new string[]{_separator}, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 0)
                return null;


            ArrayList list = new ArrayList(arr);


            return FindNodeByPathDescriptionArray(list);

        }

        /// <summary>
        /// Ricerca un nodo attraverso il proprio id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AbstractBilancio FindNodeById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;


            if (_id.Equals(id))
                return this;

            foreach (AbstractBilancio item in _sublist)
            {
                AbstractBilancio b = item.FindNodeById(id);
                if (b != null)
                    return b;
            }

            return null;

        }

        public AbstractBilancio FindNodeByPathDescriptionArray(ArrayList list)
        {

            if (list.Count == 0)
                return null;
            //se il nodo è foglia (leaf)
            //eseguo un semplice check sul primo elemento dell'array
            if (IsLeaf)
            {
                //non procedo nelle scritture
                if (this.GetType().Equals(typeof(Conto)))
                {
                    string check = list[0].ToString();
                    if (_description.Equals(check))
                        return this;
                    return null;
                }
                return null;
            }

            //prendo il primo elemento da verificare con la descrizione 
            //del nodo corrente
            string firstElem = list[0].ToString();

            //se la descrizione coincide posso continuare nella ricerca tra i sottonodi
            //se il percorso non è terminato oppure restituire l'oggetto corrente
            if (firstElem.Equals(_description))
            {
                list.RemoveAt(0);

                if (list.Count == 0)
                    return this;

                return FindSubNodeByBescriptionPath(list, this);
            }
            // altrimenti posso sospettare la presenza di un percorso relativo e
            //pertanto vado direttamente nei sottonodi
            else
            {
                return FindSubNodeByBescriptionPath(list,this);
            }
        }




        protected AbstractBilancio FindSubNodeByBescriptionPath(ArrayList  arr, AbstractBilancio current)
        {
            //se si tratta di una foglia ritorno un valore null
            //in quanto non può verificare i sottonodi
            if (IsLeaf)
                return null;


            // se nella ricorsione non trovo elementi da ricercare 
            //c'è un errore nell'algoritmo
            if (arr.Count == 0)
                throw new Exception("Errore nella ricerca del nodo. Lista elementi da ricercare vuota prima di eseguire il confronto");



            // prendo il primo elemento
            string check = arr[0].ToString();



            //ciclo su tutti gli elementi in lista
            foreach (AbstractBilancio item in current.SubList)
            {
                //opero il confronto con la descrizione dell'elemento
                if (item.Description.Equals(check))
                {
                    //se la descrizione è la stessa ho trovato il nodo
                    //relativo al check

                    //rimuovo l'elemento trovato dalla lista e se la lista è vuota vuol dire che
                    //ho trovato l'elemento che mi interessa
                    arr.RemoveAt(0);

                    if ((arr.Count == 0) || IsLeaf)
                        return item;

                    return FindSubNodeByBescriptionPath(arr,item);

                }
            }
            return null;
            

            
        }


      
        




        [XmlArray("SubList"), XmlArrayItem("Classificazione", typeof(Classificazione)),
         XmlArrayItem("Conto", typeof(Conto)), XmlArrayItem("Scrittura", typeof(Scrittura)),
        XmlArrayItem("ContoPreventivo", typeof(ContoPreventivo ))] 
        public IList SubList
        { get { return _sublist; } }


        [XmlAttribute("Importo")]
        public double Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }


        [XmlAttribute("SaldoIniziale")]
        public double SaldoIniziale
        {
            get { return _saldoIniziale; }
            set { _saldoIniziale = value; }
        }


        public virtual void Add(AbstractBilancio part)
        {

            AbstractBilancio p = part as Scrittura;

            if (p != null)
                throw new InvalidOperationException("Impossibile aggiungere una scrittura ad una classificazione generica");

            _sublist.Add(part);
        }


        /// <summary>
        /// Matodo utilizzato per rimuovoere una scrittur, un conto , una classificazione
        /// </summary>
        /// <param name="part"></param>
        public virtual void Remove(AbstractBilancio part)
        {
            foreach (AbstractBilancio item in _sublist)
            {
                if (item.Id.Equals(part.Id))
                {
                    _sublist.Remove(item);
                    return;
                }
            }
        }


        [XmlAttribute("Description")]
        public string Description 
        { 
            get {return _description; }
            set { _description = value; }
        }



        /// <summary>
        /// Calcola il totale della classificazione a qualunque livello ad una certa data
        /// </summary>
     
        public virtual double GetTotalAtDate(DateTime data)
        {
           
                double total = 0;
                CalculatePartials(ref total, data);

                return total;
            
        }




        /// <summary>
        /// Calcola il totale della classificazione a qualunque livello
        /// </summary>
        [XmlIgnore]
        public virtual double  GetTotal
        {
            get
            {
                double total = 0;
                double i = CalculatePartials(ref total);

                return i;
            }
        }

      
        /// <summary>
        /// metodo usato pertirare fuori una lista di valori per una determinata proprietà
        /// tra quelle che hanno nome "riferimento1", "riferimento2", "riferimento3"
        /// in particolare questa funzione è servita per recuperare la lista di nomi del 
        /// personale damettere in una tendina
        /// </summary>
        public IList<string> GetRiferimentoList(string propertyName)
        {
            
                IList<string> result  = new List<string>();
                CalculateList(ref result, propertyName);
                return result;
            
        }

        protected virtual void CalculateList(ref IList<string> result, string propertyName)
        {
            foreach (AbstractBilancio item in _sublist)
            {
                item.CalculateList(ref result, propertyName);
            }
        }

        protected virtual void CalculatePartials(ref double total, DateTime date)
        {
           
            foreach (AbstractBilancio item in _sublist)
            {
                item.CalculatePartials(ref total, date);
            }


            
        }

        protected virtual double CalculatePartials(ref double  total)
        {
            _importo = 0;   
            foreach (AbstractBilancio item in _sublist)
            {
               _importo += item.CalculatePartials(ref total);
            }

            
            return _importo + _saldoIniziale;
        }

        /// <summary>
        /// Restituisce true se si tratta di un conto di bilancio e non di una macro classificazione
        /// </summary>
        [XmlIgnore]
        public abstract bool IsLeaf { get; }





        #region IIerarchicalObject Membri di


        public IList<IIerarchicalObject> IerarchicalSubList()
        {
            IList<IIerarchicalObject> l = new List<IIerarchicalObject>();


            foreach (IIerarchicalObject item in _sublist)
            {
                l.Add(item);
            }



            return l;
        }

        public IList Properties()
        {
            ArrayList l = new ArrayList();

            l.Add(GetTotal.ToString("c"));

            return l;
        }

        #endregion
    }
}
