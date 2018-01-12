using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using System.ComponentModel;
using BilancioFenealgest.ServiceLayer.DTO;
using TestBinding;
using System.Collections;
using WIN.BILANCIO.ServiceLayer.ExcelExporter;
using System.IO;
using System.Diagnostics;
using WIN.BILANCIO.ServiceLayer.DTO;
using BilancioFenealgest.UI.PresentationLogicComponents;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.ServiceLayer
{
    public class BilancioService
    {

        protected BilancioNew _bilancio;

          public const string PATRIMONIO_NETTO = "P.P.1";
          public const string CASSA = "A.D.1";

          public const string DISPONIBILITA = "A.D";
          public const string BANCA1 = "A.D.2.a";
          public const string BANCA2 = "A.D.2.b";
          public const string BANCA3 = "A.D.2.c";
          public const string BANCA4 = "A.D.2.d";
          public const string BANCA5 = "A.D.2.e";
          public const string BANCA6 = "A.D.2.f";

        public event EventHandler Change;
        public event EventHandler BeginExport;
        public event EventHandler EndExport;
        public event ExcelMastroPrinter.RowExportEventHandler ExportedRow;


        public double GetFinanzaInizialeTotal()
        {
            return _bilancio.FindNodeById(CASSA).SaldoIniziale +
                _bilancio.FindNodeById(BANCA1).SaldoIniziale +
                _bilancio.FindNodeById(BANCA2).SaldoIniziale +
                _bilancio.FindNodeById(BANCA3).SaldoIniziale +
                _bilancio.FindNodeById(BANCA4).SaldoIniziale +
                _bilancio.FindNodeById(BANCA5).SaldoIniziale +
                _bilancio.FindNodeById(BANCA6).SaldoIniziale;
        }

        public double GetFinanzaFinaleTotal()
        {
            return _bilancio.FindNodeById(DISPONIBILITA).GetTotal;
        } 


        public virtual void RaiseExportedRow(int rowPercentage, bool cancel)
        {
            if (ExportedRow != null)
                ExportedRow(this, new WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportedEventArgs(rowPercentage,cancel));
        }


        public virtual void RaiseEndExport()
        {
            if (EndExport != null)
                EndExport(this, new EventArgs());
        }


        public IList<string> GetRiferimentoLista(string propertyName)
        {
            return _bilancio.GetRiferimentoList(propertyName);
        }



        public virtual void RaiseBeginExport()
        {
            if (BeginExport != null)
                BeginExport(this, new EventArgs());
        }
       


     
        protected virtual void RaiseChangeEvent()
        {
            


            // Raise the event by using the () operator.
            if (Change != null)
                Change(this, new EventArgs());
        }


        public BilancioService(BilancioNew bilancio)
        {
            _bilancio = bilancio;
        }

        /// <summary>
        /// proprietà per il recupero dei dati gerarchici da mostrare
        /// Si è optato per questa scelta anzichè per un DTO data la struttura complessa dell'oggetto
        /// </summary>
        public BilancioNew Bilancio
        {
            get
            {
                return _bilancio;
            }
        }


        public StatisticsDTO Statistiche
        {
            get
            {
                StatisticsDTO dto = new StatisticsDTO();

                dto.Quadratura = _bilancio.GetTotal;
              
                dto.Entrate = _bilancio.Entrate.GetTotal;

                dto.Spesee = _bilancio.Spese.GetTotal;

                dto.Avanzo = _bilancio.Avanzo;

                dto.Fonti = _bilancio.Fonti;
                dto.Impieghi = _bilancio.Impieghi;

                return dto;
            }
        }



        public FinanzaInizialeDTO FinanzaIniziale
        {
            get
            {
                FinanzaInizialeDTO dto = new FinanzaInizialeDTO();
                //dto.Accantonamenti = (decimal)_bilancio.AccantonamentoIniziale.Importo;
                //dto.Cassa = (decimal)_bilancio.CassaIniziale.Importo;
                //dto.Banca1 = (decimal)_bilancio.Banca1Iniziale.Importo;
                //dto.Banca2 = (decimal)_bilancio.Banca2Iniziale.Importo;
                //dto.Banca3 = (decimal)_bilancio.Banca3Iniziale.Importo;
                return dto;
            }
            set
            {
                //_bilancio.SetSituazioneFinanziariaIniziale(Convert.ToDouble(value.Banca1), Convert.ToDouble(value.Banca2), Convert.ToDouble(value.Banca3), Convert.ToDouble(value.Cassa), Convert.ToDouble(value.Accantonamenti));
                RaiseChangeEvent();
            }
        }


  


        public SortableBindingList<ScrittureDTO> SearchScrittureBilancio(string idConto, ScrittureSearchCriteria criteria)
        {
            if (_bilancio == null)
                return null;

            AbstractBilancio b;

            if (string.IsNullOrEmpty(idConto))
                b = _bilancio;
            else
                b = _bilancio.FindNodeById(idConto);


            if (b == null)
                throw new InvalidOperationException("Richiesta scritture per un elemento sconosciuto");

            IList list = b.SearchScritture(criteria);

            return ScrittureConverter.ConvertScritture(list);

        }


        public SortableBindingList<ScrittureDTO> ScrittureContoBilancio(string idConto)
        {
            if (_bilancio  == null)
                return null;

            AbstractBilancio b = _bilancio.FindNodeById(idConto) as Conto;


            if (b == null)
                throw new InvalidOperationException("Richiesta scritture per un elemento di bilancio diverso da un conto");


            return ScrittureConverter.ConvertScritture(b.SubList);

        }


        public void ScriviDettagliSaldoConto(IScrittureFormView view,string conto)
        {
            decimal initValue = 0;
            decimal total = this.CalculateTotalForSCritture(view.GridContainer.BoundList, conto, ref initValue);
            if (initValue == 0)
                view.SetScrittureTotalizzation(total.ToString("c"));
            else
            {
                string commento = ".          Saldo iniziale conto: " + initValue.ToString("c");
                view.SetScrittureTotalizzation(total.ToString("c") + commento);
            }
        }

        internal decimal CalculateTotalForSCritture(IList dtos, string conto, ref decimal initialValue)
        {
            //vedo se c'è un saldo iniziale verificando che il conto sia un conto finanziario
            
            //if (!string.IsNullOrEmpty(conto))
            //{
            //    switch (conto)
            //    {
            //        case"FF.0"://banca1
            //                initialValue = Convert.ToDecimal(_bilancio.Banca1Iniziale.Importo);
            //                break;
            //        case "FF.1"://banca2
            //                initialValue = Convert.ToDecimal(_bilancio.Banca2Iniziale.Importo);
            //                break;
            //        case "FF.2"://cassa
            //                initialValue = Convert.ToDecimal(_bilancio.CassaIniziale.Importo);
            //                break;
            //        case "FF.3"://accantonamento
            //                initialValue = Convert.ToDecimal(_bilancio.AccantonamentoIniziale.Importo);
            //                break;
            //        case "FF.4"://accantonamento
            //                initialValue = Convert.ToDecimal(_bilancio.Banca3Iniziale.Importo);
            //                break;
            //        default:
            //            break;
            //    }
            //}


            //se c'è un conto verifico il totale  dal conto stesso
            if (!string.IsNullOrEmpty(conto))
            {
                Conto current = _bilancio.FindNodeById(conto) as Conto;
                //se sto verificando il saldo iniziale di una classificaizone ad esempio
                if (current == null)
                    return 0;


                initialValue = (decimal)current.SaldoIniziale;
                return (decimal)current.GetTotal;
            
            }


            decimal t = 0;

            foreach (ScrittureDTO  item in dtos)
            {
                t = t + item.Importo;
            }


            return t + initialValue;
        }


        public void AddScrittura(string idConto, ScrittureDTO scrittura, string contropartita)
        {
            Conto c = _bilancio.FindNodeById(contropartita) as Conto;

            AddScrittura(idConto, scrittura, c);


        }


        private void ValidateOperazioniDiuCassa(Conto contoCorrente, Conto contropartita, decimal importo)
        {


            //verifico che il primo conto movimentato sia un conto cassa
            if (contoCorrente.Id.Equals(CASSA) || contropartita.Id.Equals(CASSA))
                if (importo > 3000 || importo < -3000)
                    throw new Exception("Attenzione! Le scritture di cassa non possono superare i 3.000 Euro!");


        }

        private void AddScrittura(string idConto, ScrittureDTO scrittura, Conto contropartita)
        {




            if (contropartita == null)
                throw new InvalidOperationException("Contropartita nulla");

            Conto c = _bilancio.FindNodeById(idConto) as Conto;
            if (c == null)
                throw new InvalidOperationException("Tentativo di aggingere una scrittura ad un elemento diverso da un conto");


            //prima di aggiungere la scrittura devo eseguire una validazione sulle possibili operazioni di cassa
            ValidateOperazioniDiuCassa(c, contropartita, scrittura.Importo);


            Scrittura s = new Scrittura(idConto);
           // s.TipoOperazione = (TipoOperazione)Enum.Parse(typeof(TipoOperazione), scrittura.TipoOperazione);
            s.Importo = Convert.ToDouble(scrittura.Importo);
            s.Causale = scrittura.Causale;
            s.Date = scrittura.Date.Date;
            s.NumeroPezza = scrittura.NumeroPezza;
            s.ParentName = c.Description;
            s.Riferimento1 = scrittura.Riferimento1;
            s.Riferimento2 = scrittura.Riferimento2;
            s.Riferimento3 = scrittura.Riferimento3;

            //if (s.TipoOperazione == TipoOperazione.Cassa)
            //    c.Add(s, _bilancio.CassaFinale, false);
            //else if (s.TipoOperazione == TipoOperazione.Accantonamento)
            //    c.Add(s, _bilancio.AccantonamentoFinale, false);
            //else if (s.TipoOperazione == TipoOperazione.Banca1)
            //    c.Add(s, _bilancio.Banca1Finale, false);
            //else if (s.TipoOperazione == TipoOperazione.Banca2)
            //    c.Add(s, _bilancio.Banca2Finale, false);
            //else if (s.TipoOperazione == TipoOperazione.Banca3)
            //    c.Add(s, _bilancio.Banca3Finale, false);
            //else
            c.Add(s, contropartita, false);

            scrittura.ParentId = c.Id;
            scrittura.ParentName = c.Description;
            scrittura.Contropartita = s.Contropartita;
            scrittura.IdContropartita = s.IdContropartita;
            scrittura.Id = s.Id;

            RaiseChangeEvent();
        }


        public int  PasteScritture(string toIdConto, IList<ScrittureDTO> list)
        {

            Conto c = _bilancio.FindNodeById(toIdConto) as Conto;

            if (c == null)
                throw new ArgumentException("Id conto non specificato! Impossibile trovare il conto di destinazione.");



            int _pasted = 0;

            foreach (ScrittureDTO item in list)
            {
                //non faccio nulla se il conto di partenza è lo stesso del conto di arrivo
                if (!toIdConto.Equals(item.ParentId))
                {//non faccio nulla se la scrittura è autogenerata
                    if (!item.AutoGenerated)
                    {
                        
                        //BilancioFenealgest.DomainLayer.Conto.TipoConto tipoCTo = Conto.CalculateTipoConto(toIdConto);
                        //BilancioFenealgest.DomainLayer.Conto.TipoConto tipoCFrom = Conto.CalculateTipoConto(item.ParentId);

                        ////se non sto riscrivendo una scrittura in partita doppia tutta su spese o oentrate
                        //if (!(item.TipoOperazione == "Contropartita" && tipoCFrom != tipoCTo))
                        //{
                        //ottengo la scrittura di contropartita prima di cancellarla
                        ScrittureDTO controp = GetScritturaContropartita(item);

                        //rimuovo la scrittura 
                        RemoveScrittura(item);

                        //aggiungo la scrittura ad un conto
                        AddScrittura(toIdConto, item, controp.ParentId);
                        //notifico che è necessario un refresh(almeno un elemento è cambiato)
                        _pasted++;
                        //}
                       

                      
                    }
                }
            }

            return _pasted;
        }



        public void RemoveScrittura(ScrittureDTO scrittura)
        {
            Conto c = _bilancio.FindNodeById(scrittura.ParentId) as Conto;
            if (c == null)
                throw new InvalidOperationException("Tentativo di rimuovere una scrittura ad un elemento diverso da un conto");

            Scrittura s = c.FindNodeById(scrittura.Id) as Scrittura;

            if (s == null)
                return;

            //if (s.TipoOperazione == TipoOperazione.Accantonamento)
            //    c.Remove(scrittura.Id, _bilancio.AccantonamentoFinale);
            //else if (s.TipoOperazione == TipoOperazione.Cassa)
            //    c.Remove(scrittura.Id, _bilancio.CassaFinale);
            //else if (s.TipoOperazione == TipoOperazione.Banca1)
            //    c.Remove(scrittura.Id, _bilancio.Banca1Finale);
            //else if (s.TipoOperazione == TipoOperazione.Banca2)
            //    c.Remove(scrittura.Id, _bilancio.Banca2Finale);
            //else if (s.TipoOperazione == TipoOperazione.Banca3)
            //    c.Remove(scrittura.Id, _bilancio.Banca3Finale);
            //else
            c.Remove(scrittura.Id, _bilancio);//gestione della cancellazione scritture di contropartita

            RaiseChangeEvent();

        }

        public void UpdateScrittura(ScrittureDTO scrittura, string contropartitaId)
        {
            
            Conto contropartita = _bilancio.FindNodeById(contropartitaId) as Conto;
            Conto c = _bilancio.FindNodeById(scrittura.ParentId) as Conto;
            if (c == null)
                throw new InvalidOperationException("Tentativo di aggiornare una scrittura ad un elemento diverso da un conto");

            if (contropartita == null)
                throw new InvalidOperationException("Tentativo di aggiornare una scrittura con contropartita nulla");



            //prima di aggiungere la scrittura devo eseguire una validazione sulle possibili operazioni di cassa
            ValidateOperazioniDiuCassa(c, contropartita, scrittura.Importo);


            Scrittura s = c.FindNodeById(scrittura.Id) as Scrittura;

            if (s == null)
                throw new InvalidOperationException("Tentativo di aggiornare una scrittura non presente nel conto");



            //se si tratta di una scrittura autogenerata 
            if (s.AutoGenerated)
            {
                s.Importo = Convert.ToDouble(scrittura.Importo);
                s.Causale = scrittura.Causale;
                s.Date = scrittura.Date.Date;
                s.NumeroPezza = scrittura.NumeroPezza;

                return;
            }

            //verifico preventivamente la possibilità di fare una scrittura in partita doppia sullo
            //stesso conto
            //**********************************
            Conto fin= null;
            //TipoOperazione tip = (TipoOperazione)Enum.Parse(typeof(TipoOperazione), scrittura.TipoOperazione);
            //if (tip == TipoOperazione.Cassa)
            //    fin = _bilancio.CassaFinale;
            //else if (tip == TipoOperazione.Accantonamento)
            //    fin = _bilancio.AccantonamentoFinale;
            //else if (tip == TipoOperazione.Banca1)
            //    fin = _bilancio.Banca1Finale;
            //else if (tip == TipoOperazione.Banca2)
            //    fin = _bilancio.Banca2Finale;
            //else if (tip == TipoOperazione.Banca3)
            //    fin = _bilancio.Banca3Finale;
            //else
                fin = contropartita;
              
            if (fin != null)
                if (c.Id.Equals(fin.Id))
                    throw new Exception("Impossibile scrivere una scrittura in partita doppia sullo stesso conto!");
            //**********************************





            //a questo punto rimuovo la scrittura precedente
            RemoveScrittura(scrittura);



            //eaggiungo la nuova scrittura
            Scrittura s1 = new Scrittura();
           // s1.TipoOperazione = tip;
            s1.Importo = Convert.ToDouble(scrittura.Importo);
            s1.Causale = scrittura.Causale;
            s1.Date = scrittura.Date.Date;
            s1.NumeroPezza = scrittura.NumeroPezza;
            s1.Id = scrittura.Id;
            s1.ParentName = c.Description;
            s1.Riferimento1 = scrittura.Riferimento1;
            s1.Riferimento2 = scrittura.Riferimento2;
            s1.Riferimento3 = scrittura.Riferimento3;
            //if (s1.TipoOperazione == TipoOperazione.Cassa)
            //    c.Add(s1, _bilancio.CassaFinale, false);
            //else if (s1.TipoOperazione == TipoOperazione.Accantonamento)
            //    c.Add(s1, _bilancio.AccantonamentoFinale, false);
            //else if (s1.TipoOperazione == TipoOperazione.Banca1)
            //    c.Add(s1, _bilancio.Banca1Finale, false);
            //else if (s1.TipoOperazione == TipoOperazione.Banca2)
            //    c.Add(s1, _bilancio.Banca2Finale, false);
            //else if (s1.TipoOperazione == TipoOperazione.Banca3)
            //    c.Add(s1, _bilancio.Banca3Finale, false);
            //else
                c.Add(s1, fin, false);

            scrittura.ParentName = c.Description;
            scrittura.Contropartita = s1.Contropartita;

            

            RaiseChangeEvent();
        }



        //public void ExportLibroGiornale(IList<ScrittureDTO> scritture, string fileName, bool groupByConto)
        //{
           
        //}

        void exp_ExportingRow(object sender, ExcelMastroPrinter.RowExportedEventArgs fe)
        {
            RaiseExportedRow(fe.RowPercentage, false);
        }

        void exp_EndExport(object sender, EventArgs e)
        {
            RaiseEndExport();
        }

        void exp_BeginExport(object sender, EventArgs e)
        {
            RaiseBeginExport();

        }

        public IList<ScrittureDTO> SearchScrittureGiornale(ScrittureSearchCriteria criteria)
        {
            if (_bilancio == null)
                return null;

           
            IList list = _bilancio.SearchScritture(criteria);   
         
            List<ScrittureDTO> l1 = new  List<ScrittureDTO>();

            foreach (ScrittureDTO item in ScrittureConverter.ConvertScritture(list))
	        {
        		 l1.Add(item);
	        } 

            l1.Sort(ScrittureDTO.CompareByDate);

            return l1;
        }

        public bool IsConto(string idConto)
        {
            Conto c = _bilancio.FindNodeById(idConto) as Conto;
            return c != null;
        }


        public IList SearchScritturePrimaNota(ScrittureSearchCriteria criteria)
        {
            if (_bilancio == null)
                return null;


            IList list = _bilancio.SearchScritture(criteria);

            List<ScritturaPrimaNotaDTO> l1 = new List<ScritturaPrimaNotaDTO>();

            foreach (ScritturaPrimaNotaDTO item in ScrittureConverter.ConvertScrittureToPrimaNota(list))
            {
                l1.Add(item);
            }

            l1.Sort(ScritturaPrimaNotaDTO.CompareByDate);

            //anche se è brutto a vedersi riporto tutto ad un arraylist

            return new ArrayList(l1);
        }



        public void ExportLibroGiornale(IList<ScrittureDTO> scritture, string fileName, bool groupByConto,  decimal saldoConto)
        {
            ExcelMastroPrinter exp = new ExcelMastroPrinter();
            exp.BeginExport += new EventHandler(exp_BeginExport);
            exp.EndExport += new EventHandler(exp_EndExport);
            exp.ExportingRow += new ExcelMastroPrinter.RowExportEventHandler(exp_ExportingRow);

            exp.Export(scritture, groupByConto,  saldoConto);

            exp.SaveAs(fileName);

            exp.CloseExporter();

            //'se ho salvato il file lo apro
            if (File.Exists(fileName))
                Process.Start(fileName);
        }

        internal ScrittureDTO GetScritturaContropartita(ScrittureDTO _current)
        {

            //if (_current.TipoOperazione == "Contropartita")
            //{

                //BilancioFenealgest.DomainLayer.Conto.TipoConto c = Conto.CalculateTipoConto(_current.ParentId);
                ////se la contropartita è nulla vuol dire che ho passato l'intero bilancio


                ////*****************************
                ////definisco l'id della classificazione dove ricercare il conto
                //string idClassificazione = "";

                //if (c == BilancioFenealgest.DomainLayer.Conto.TipoConto.Entrate)
                //    //dovro' cercare la scrittura di contropartita nelle spese
                //    idClassificazione = "S";
                //else
                //    //dovro' cercare la scrittura di contropartita nelle entrate
                //    idClassificazione = "E";



                ////rimuovo la scrittura previa ricerca
                //Classificazione clas = _bilancio.FindNodeById(idClassificazione) as Classificazione;


                Conto conto = _bilancio.FindNodeById(_current.IdContropartita) as Conto;

                //cerco la scritttura
                Scrittura s1 = conto.FindNodeById(_current.Id) as Scrittura;

                if (s1 == null)
                    throw new Exception("Scrittura di partita doppia non trovata");



                return ScrittureConverter.ConvertToScritturaDTO(s1);

            //}
            //else
            //{
            //    Conto c;

            //    switch (_current.TipoOperazione)
            //    {
            //        case "Cassa":
            //            c = _bilancio.CassaFinale;
            //            break;
            //        case "Banca2":
            //            c = _bilancio.Banca2Finale;
            //            break;
            //        case "Banca1":
            //            c = _bilancio.Banca1Finale;
            //            break;
            //        case "Banca3":
            //            c = _bilancio.Banca3Finale;
            //            break;
            //        case "Accantonamento":
            //            c = _bilancio.AccantonamentoFinale;
            //            break;
            //        default:
            //            throw new ArgumentException("Tipo operazione sconosciuta!");
                       
            //    }

            //    Scrittura s1 = c.FindNodeById(_current.Id) as Scrittura;

            //    if (s1 == null)
            //        throw new Exception("Scrittura di partita doppia non trovata");



            //    return ScrittureConverter.ConvertToScritturaDTO(s1);
            //}
        }

        internal void SetSaldoConto(string idConto, decimal p)
        {


            Conto c = _bilancio.FindNodeById(idConto) as Conto;

            if (c == null)
                return;

            c.SaldoIniziale = (double)p;



            //una volta impostato il saldo iniziale di un conto devo provvedere a far
            //quadrare tutto il bilancio. La quadratura del bilancio è automatica
            //quando creo delle scritture; quando invece modifico il saldo iniziale di un conto
            //tale quadratura viene a mancare. In contabilità la quadratura viene ripristinata modificando il saldo 
            //iniizale del patrimonio netto che nella fattispece avrà come id conto "P.P.1".


            //Pertanto una volta impostato il saldo iniziale del conto eseguiro' il totale del bilancio 
            //e sommero tale totale (con segno cambiato) al saldo iniziale del patrimonio netto

            //eseguo la totalizzaizone del bilancio 
            double tot = _bilancio.GetTotal;

            Conto patrimonioNetto = _bilancio.FindNodeById(PATRIMONIO_NETTO) as Conto;

            //reimposto ilaldo iniziale del patrimonio netto
            patrimonioNetto.SaldoIniziale += tot * -1;


            RaiseChangeEvent();
            
        }

        internal IList GetListaContiStatoPatrimoniale()
        {
            //recupero i conti delle passività
            AbstractBilancio pass = _bilancio.Passivita;
            //recupero la lista dei conti delle passività
            IList contiPassivita = _bilancio.CreateListaConti(pass.Id);


            //recupero i conti delleattività
            AbstractBilancio att = _bilancio.Attivita;
            //recupero la lista dei conti delle passività
            IList contiAttivita = _bilancio.CreateListaConti(att.Id);


            //ritorno il merge delle due liste
            IList result = new ArrayList();


            foreach (Conto item in contiAttivita)
            {
                result.Add(item);
            }


            foreach (Conto item in contiPassivita)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
