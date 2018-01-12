using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BilancioFenealgest.DomainLayer
{

    [Serializable]
    public class Bilancio : AbstractBilancio 
    {


        public void SetSituazioneFinanziariaIniziale(double banca1, double banca2,double banca3,  double cassa, double accantonamenti)
        {
            //imposto il dato bancario iniziale
            ContoPreventivo p = FinanzaIniziale.SubList[0] as ContoPreventivo;

            p.Importo = banca1;


            //imposto il dato bancario iniziale
            ContoPreventivo p1 = FinanzaIniziale.SubList[1] as ContoPreventivo;

            p1.Importo = banca2;

            //imposto il dato bancario iniziale
            ContoPreventivo p2 = FinanzaIniziale.SubList[2] as ContoPreventivo;

            p2.Importo = banca3;


            //imposto il dato cassa iniziale
            ContoPreventivo p3 = FinanzaIniziale.SubList[3] as ContoPreventivo;

            p3.Importo = cassa;


            //imposto il dato cassa iniziale
            ContoPreventivo p4 = FinanzaIniziale.SubList[4] as ContoPreventivo;

            p4.Importo = accantonamenti;


        }

        public void SetSituazioneFinnziariaFinale(double banca)
        {


            //********************************************
            //modifica per rendere la gestione della banca a partita doppia

            ////imposto il dato bancario iniziale
            //ContoPreventivo p = FinanzaFinale.SubList[0] as ContoPreventivo;

            //p.Importo = banca;

            //******************************************************************

          

        }




        public Bilancio(string id, string parentId)
            : base(id,parentId )
        {

        }

        public Bilancio() { }



        //*********************************************+
        //Saldi conti 

        /// <summary>
        /// Ritorna la verifica del totale per l'intero bilancio
        /// Viene eseguita la differenza tra le disponibilità (Entrate + Situazione finanziaria iniziale)
        /// e gli impieghi di bilancio (Spese + Situazione finanziaria finale)
        /// </summary>
        [XmlIgnore]
        public override double GetTotal
        {
            get
            {

                if ((Fonti - Impieghi < 0.001) && (Fonti - Impieghi > -0.001))
                    return 0;
                return Fonti - Impieghi;


            }
        }


        

        /// <summary>
        /// Restituisce la differenza tra le entrate e le spese
        /// </summary>
        public double Avanzo
        {
            get
            {
                return Entrate.GetTotal  - Spese.GetTotal;
            }

        }

       


        /// <summary>
        /// Restituisce la differenza tra le entrate e le spese senza ricalcolare il totale
        /// </summary>
        public double Avanzo1
        {
            get
            {
                return Entrate.Importo  - Spese.Importo;
            }

        }


        

        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale
        /// </summary>
        public double Fonti
        {
            get
            {
                return Entrate.GetTotal + FinanzaIniziale.GetTotal; 
            }

        }

       


        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale senza ricalcolare il totale
        /// </summary>
        public double Fonti1
        {
            get
            {
                return Entrate.Importo + FinanzaIniziale.Importo;
            }

        }

        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale
        /// </summary>
        public double Impieghi
        {
            get
            {
                return Spese.GetTotal + SaldoFinanzaFinale; 
            }

        }

        
        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale senza ricalcolare il totale
        /// </summary>
        public double Impieghi1
        {
            get
            {
                return Spese.Importo + SaldoFinanzaFinale; 
            }

        }


        

        [XmlIgnore]
        public double SaldoFinanzaFinale
        {
            get { return SaldoBanca1 + SaldoBanca2 + SaldoBanca3  + SaldoCassa + SaldoAccantonamento; }
        }

       


        [XmlIgnore]
        public virtual double SaldoCassa
        {
            get { return CassaIniziale.GetTotal + CassaFinale.GetTotal; }
        }
       


        [XmlIgnore]
        public virtual double SaldoBanca1
        {
            get { return Banca1Iniziale.GetTotal + Banca1Finale.GetTotal; }
        }
       

        [XmlIgnore]
        public virtual double SaldoBanca2
        {
            get { return Banca2Iniziale.GetTotal + Banca2Finale.GetTotal; }
        }
        

        [XmlIgnore]
        public virtual double SaldoBanca3
        {
            get { return Banca3Iniziale.GetTotal + Banca3Finale.GetTotal; }
        }
        


        [XmlIgnore]
        public virtual double SaldoAccantonamento
        {
            get { return AccantonamentoIniziale.GetTotal + AccantonamentoFinale.GetTotal; }
        }

        

        //*****************************************************************

        //*********************************************
        //situazione finanziaria iniziale

        [XmlIgnore]
        public AbstractBilancio  Banca1Iniziale
        {
            get { return FinanzaIniziale.SubList[0] as AbstractBilancio; }
        }

        [XmlIgnore]
        public AbstractBilancio Banca2Iniziale
        {
            get { return FinanzaIniziale.SubList[1] as AbstractBilancio; }
        }

        [XmlIgnore]
        public AbstractBilancio Banca3Iniziale
        {
            get { return FinanzaIniziale.SubList[2] as AbstractBilancio; }
        }


        [XmlIgnore]
        public AbstractBilancio CassaIniziale
        {
            get { return FinanzaIniziale.SubList[3] as AbstractBilancio; }
        }


        [XmlIgnore]
        public AbstractBilancio AccantonamentoIniziale
        {
            get { return FinanzaIniziale.SubList[4] as AbstractBilancio; }
        }

        //*****************************************************




        //*********************************************
        //situazione finanziaria finale

        [XmlIgnore]
        public Conto Banca1Finale
        {
            get { return FinanzaFinale.SubList[0] as Conto; }
        }

        [XmlIgnore]
        public Conto Banca2Finale
        {
            get { return FinanzaFinale.SubList[1] as Conto; }
        }

        [XmlIgnore]
        public Conto Banca3Finale
        {
            get { return FinanzaFinale.SubList[2] as Conto; }
        }


        [XmlIgnore]
        public Conto AccantonamentoFinale
        {
            get { return FinanzaFinale.SubList[4] as Conto; }
        }


        [XmlIgnore]
        public Conto CassaFinale
        {
            get { return FinanzaFinale.SubList[3] as Conto; }
        }

        //*********************************************

        //*********************************************
        //situazione economica

        [XmlIgnore]
        public AbstractBilancio Spese
        {
            get{return _sublist[2] as AbstractBilancio;}
        }

        [XmlIgnore]
        public AbstractBilancio Entrate
        {
            get { return _sublist[3] as AbstractBilancio; }
        }

        //**************************************************+



        //**************************************************
        //riepilogo finanziario

        [XmlIgnore]
        public AbstractBilancio FinanzaIniziale
        {
            get { return _sublist[0] as AbstractBilancio; }
        }

        [XmlIgnore]
        public AbstractBilancio FinanzaFinale
        {
            get { return _sublist[1] as AbstractBilancio; }
        }


        //**************************************************

        [XmlIgnore]
        public override bool IsLeaf
        {
            get { return false; }
        }
    }
}
