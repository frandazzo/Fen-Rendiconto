﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.DomainLayer
{

    [Serializable]
    public class Conto : AbstractBilancio 
    {

        public Conto()
        {}


        public Conto(string description, string id, string parentId):base(id,parentId )
        {
            _description = description;
            _id = id;
        }


        [XmlIgnore]
        public override bool IsLeaf
        {
            get { return true; }
        }

       
     


        public override void Add(AbstractBilancio part)
        {

            throw new InvalidOperationException("Chiamata a metodo non implementato. Utilizzare metodo alternativo!");


        }



        public void Remove(string idScrittura, AbstractBilancio cp)
        {

          

            Scrittura s = FindNodeById(idScrittura) as Scrittura;

            if (s == null)
                return;

            //commento la riga di codice che verifica la presenza di una
            //scrittura autogenerata in un conto finanziario. Tale scrittura puo'
            //trovarsi in qualsiasi tipo di conto.
            //if (CalculateTipoConto() == TipoConto.Finanza)
            if (s.AutoGenerated == true)
                throw new InvalidOperationException("Impossibile eliminare una scrittura autogenerata. Per eliminarla procedere alla eliminazione della scrittura dal relativo conto!");


            //se il conto di contropartita risulta nullo vuol dire che devo cercare la scrittura 
            //di cotropartita nell'albero delle entrate o delle uscite a seconda che il tipoConto
            //sia entrate o uscite
            //if (contoContropartita != null)
            //{

            BilancioNew bil = cp as BilancioNew;
            if (bil == null)
                throw new InvalidOperationException("Impossibile convertire la contropartita di una partita di giro in un oggetto Bilancio da cui ricercare i conto di contropartita!!!");

            Conto contoContropartita = bil.FindNodeById(s.IdContropartita) as Conto;

            Scrittura s1 = contoContropartita.FindNodeById(s.Id) as Scrittura;
            if (s1 != null)
                contoContropartita.Remove(s1);
            //}
            //else
            //{
            //    TipoConto c = CalculateTipoConto();
            //    //se la contropartita è nulla vuol dire che ho passato l'intero bilancio
            //    Bilancio bil = cp as Bilancio;
            //    // se è nullo c'è un errore imprevisto
            //    if (bil == null)
            //        throw new InvalidOperationException("Impossibile convertire la contropartita di una partita di giro in un oggetto Bilancio da cui ricercare i conto di contropartita!!!");

            //    //*****************************
            //    //definisco l'id della classificazione dove ricercare il conto
            //    string idClassificazione = "";

            //    if (c == TipoConto.Entrate)
            //        //dovro' cercare la scrittura di contropartita nelle spese
            //        idClassificazione = "S";
            //    else
            //        //dovro' cercare la scrittura di contropartita nelle entrate
            //        idClassificazione = "E";



            //    //rimuovo la scrittura previa ricerca
            //    Classificazione clas = bil.FindNodeById(idClassificazione) as Classificazione;
            //    //cerco la scritttura
            //    Scrittura s1 = clas.FindNodeById(s.Id) as Scrittura;
            //    if (s1 != null)
            //    {
            //        //ne recupero il conto padre
            //        Conto cc = clas.FindNodeById(s1.ParentId) as Conto;
            //        //la elimino dal conto
            //        cc.Remove(s1);
            //    }


            //    //*************************************************

            //}



            _sublist.Remove(s);

        }

        /// <summary>
        /// Metodo utilizzato dal client per inserire una nuova scrittura nel conto
        /// </summary>
        /// <param name="part">Questa è la scrittura che deve essere inserita nel conto già correttamente valorizzata</param>
        /// <param name="contoContropartita">il conto di contropartita è
        /// il conto dove la scrittura gemella deve essere aggiunta per la quadratura di tutto il bliancio</param>
        /// <param name="scritturaPartitaDoppia">il parametro partita doppia serve per indicare  se la scrittura corrente è la 
        /// scrittura che sarà scritta nella contropartita: lo stesso metodo è utilizzato per aggiungere la scrittura al conto principale che al conto di contropartita.
        /// Se sto aggiungendo la scrittura al conto principale allora il parametro sarà negativo. Vedi implementazione....</param>
        public virtual void Add(Scrittura part, Conto contoContropartita, bool scritturaPartitaDoppia)
        {
            if (scritturaPartitaDoppia == false)
                if (contoContropartita != null)
                    if (this.Id.Equals(contoContropartita.Id))
                        throw new Exception("Impossibile scrivere una scrittura in partita doppia sullo stesso conto!");

            part.ParentId = this.Id;
            


            if (scritturaPartitaDoppia)
            {
                _sublist.Add(part);
                return;
            }

            AddScritturaPartitaDoppia(contoContropartita, part);
        


        }


        private void AddScritturaPartitaDoppia(Conto contoContropartita, Scrittura scrittura)
        {
            //mi serve per impostare il nome del campo contropartita su ogni scrittura
            //presente sul conto
            string nomeContropartita = contoContropartita.Description;
            scrittura.Contropartita = nomeContropartita;
            scrittura.IdContropartita = contoContropartita.Id;

            //aggiungo l'elemento alla lista
            _sublist.Add(scrittura);
            //aggiungo l'elemnto alla cassa
            Scrittura s = new Scrittura(scrittura, Conto.NegateImportoOperazione(this, contoContropartita), _description);
            s.ParentName = contoContropartita.Description;
            //se invece sto inserendo la scrittura 
            //di contropartita ne scrivo il conto di contropartita
            s.Contropartita = this._description;
            s.IdContropartita = this._id;
            contoContropartita.Add(s, contoContropartita, true);
           

        }



        //private TipoConto CalculateTipoConto()
        //{
        //    TipoConto c;
        //    if (_id.StartsWith("E"))
        //        c = TipoConto.Entrate;
        //    else if (_id.StartsWith("S"))
        //        c = TipoConto.Spese;
        //    else
        //        c = TipoConto.Finanza;
        //    return c;
        //}

        //private void AddScritturaPartitaDoppia(TipoConto c, Conto contoContropartita, Scrittura scrittura)
        //{
        //    //mi serve per impostare il nome del campo contropartita su ogni scrittura
        //    //presente sul conto
        //    string nomeContropartita = contoContropartita.Description;
        //    scrittura.Contropartita = nomeContropartita;
            
        //    if (c == TipoConto.Finanza && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Entrate)
        //        throw new InvalidOperationException("Operazione Finanza --> Entrate non consentita");
        //    if (c == TipoConto.Finanza && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Spese)
        //        throw new InvalidOperationException("Operazione Finanza --> Spese non consentita");

        //    if (c == TipoConto.Spese && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Spese)
        //        throw new InvalidOperationException("Operazione Spese --> Spese non consentita");
        //    if (c == TipoConto.Entrate && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Entrate)
        //        throw new InvalidOperationException("Operazione Spese --> Spese non consentita");


        //    //se si tratta di una scrittura in partita di giro 
        //    //spese --> entrate oppure entrate --> spese
        //    if ((c == TipoConto.Spese && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Entrate) || (c == TipoConto.Entrate && Conto.CalculateTipoConto(contoContropartita.Id) == TipoConto.Spese))
        //    {
        //        //aggiungo l'elemento alla lista
        //        _sublist.Add(scrittura);
        //        //aggiungo l'elemnto alla cassa
        //        Scrittura s = new Scrittura(scrittura, false, _description);
        //        s.ParentName = contoContropartita.Description;
        //        //se invece sto inserendo la scrittura 
        //        //di contropartita ne scrivo il conto di contropartita
        //        s.Contropartita = this._description;
        //        contoContropartita.Add(s, contoContropartita, true);
        //    }
        //    else
        //    {


        //        if (c == TipoConto.Entrate)
        //        {
        //            //aggiungo l'elemento alla lista
        //            _sublist.Add(scrittura);
        //            //aggiungo l'elemnto alla cassa
        //            Scrittura s = new Scrittura(scrittura, false, _description);
        //            s.ParentName = contoContropartita.Description;
        //            //se invece sto inserendo la scrittura 
        //            //di contropartita ne scrivo il conto di contropartita
        //            s.Contropartita = this._description;
        //            contoContropartita.Add(s, contoContropartita, true);
        //        }
        //        else
        //        {
        //            //aggiungo l'elemento alla lista
        //            _sublist.Add(scrittura);
        //            Scrittura s = new Scrittura(scrittura, true, _description);
        //            s.ParentName = contoContropartita.Description;
        //            //se invece sto inserendo la scrittura 
        //            //di contropartita ne scrivo il conto di contropartita
        //            s.Contropartita = this._description;
        //            //aggiungo l'elemnto alla cassa cambiandogli il segno
        //            contoContropartita.Add(s, contoContropartita, true);
        //        }

        //    }

        //}

        //public static TipoConto CalculateTipoConto(string id)
        //{
        //    BilancioFenealgest.DomainLayer.Conto.TipoConto c;
        //    if (id.StartsWith("E"))
        //        c = BilancioFenealgest.DomainLayer.Conto.TipoConto.Entrate;
        //    else if (id.StartsWith("S"))
        //        c = BilancioFenealgest.DomainLayer.Conto.TipoConto.Spese;
        //    else
        //        c = BilancioFenealgest.DomainLayer.Conto.TipoConto.Finanza;
        //    return c;
        //}

      

        //public enum TipoConto
        //{
        //    Entrate,
        //    Spese,
        //    Finanza
        //}




        //metodo per indicare se una operazione necessiti che la scrittura da aggiungere alla contropartita sarà scritta con importo negato
        private static bool NegateImportoOperazione(Conto conto, Conto contropartita)
        {

            DirezioneOperazione op = CalcolaDirezioneOperazione(conto, contropartita);
            if (op == DirezioneOperazione.Orizzontale)
                return false;


            return true;

        }

        //queto enumerato serve a definire la direzione di una scrittura:
        //una scrittura si dice verticale allorquando ha come contropartita un conto che si trova nella stessa area
        // o nellarea direttamente sottostante; orizzontale negli altri casi.
        //ad esempio una scrittura che va dalle attività alle passività  o dalle entrate alle uscite è una scrittura orizzontale(anke il viceversa)
        //se la scrittura riguarda le attività e le spese allora è una scrittura verticale cosi come le passivita e le entrate.
        //tutte le scritture incrociate sono scritture orizzontali
        //In dipendenza dalla direzione della operazione è possibile stabilire se la contropartita deve
        //avere il segno cambiato per mantenere sempre a zero il totale di tutto il bilancio
        private enum DirezioneOperazione
        {
            Verticale,
            Orizzontale
        }


        private static DirezioneOperazione CalcolaDirezioneOperazione(Conto conto, Conto contropartita)
        {

            if (conto == null)
                throw new ArgumentException("conto nullo per il calcolo della direzione di una operazione");
            if (contropartita == null)
                throw new ArgumentException("conto cotropartita nullo per il calcolo della direzione di una operazione");

            //se faccio una operazione nella stessa area  essa risulta sempre verticale
            if (conto.AreaDiBilancio.Equals(contropartita.AreaDiBilancio))
                return DirezioneOperazione.Verticale;


            //tutte le scritture "Strettamente verticali " e non oblique sono definite verticali
            //altrimenti saranno definite orizzontali
            if (conto.AreaDiBilancio == "A" && contropartita.AreaDiBilancio == "S")
                return DirezioneOperazione.Verticale;
            if (conto.AreaDiBilancio == "S" && contropartita.AreaDiBilancio == "A")
                return DirezioneOperazione.Verticale;


            if (conto.AreaDiBilancio == "P" && contropartita.AreaDiBilancio == "E")
                return DirezioneOperazione.Verticale;
            if (conto.AreaDiBilancio == "E" && contropartita.AreaDiBilancio == "P")
                return DirezioneOperazione.Verticale;

            //in tutti gli altri casi sono operaizoni con una componente orizzontale
            return DirezioneOperazione.Orizzontale;



            //ricordarsi che la struttura di un bilancio tipico è cosi fatta:


            //ATTIVITA                   //PASSIVITA
            //_____________________________________________
            ////Immobilizzaizoni         ////Fondi ammortamenti
            ////Crediti                  ////Debiti
            ////Disponibilita            ////Patrimonio netto
            ////....                     ////....

            

            //SPESE                      //ENTRATE
            //__________________________________________
            ////Affitti                  ////Ricavi
            ////Spese varie              ////Ricavi diversi
            ////....                     ////....

        }

       

    }
}
