using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using System.Xml.Serialization;

namespace WIN.BILANCIO.DomainLayer
{
     [Serializable]
    public class BilancioNew : AbstractBilancio 
    {

    



        public BilancioNew(string id, string parentId)
            : base(id,parentId )
        {

        }

        public BilancioNew() { }



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

        public override double GetTotalAtDate(DateTime date)
        {


            if ((FontiAtDate(date) - ImpieghiAtDate(date) < 0.001) && (FontiAtDate(date) - ImpieghiAtDate(date) > -0.001))
                return 0;
            return FontiAtDate(date) - ImpieghiAtDate(date);



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


        public double AvanzoAtDate(DateTime date)
        {

            return Entrate.GetTotalAtDate(date) - Spese.GetTotalAtDate(date);


        }

        

        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale
        /// </summary>
        public double Fonti
        {
            get
            {
                return Entrate.GetTotal + Passivita.GetTotal; 
            }

        }

        public double FontiAtDate(DateTime date)
        {

            return Entrate.GetTotalAtDate(date) + Passivita.GetTotalAtDate(date);


        }
      

        /// <summary>
        /// Restituisce la somma tra le entrate e la situazione finanziaria iniziale
        /// </summary>
        public double Impieghi
        {
            get
            {
                return Spese.GetTotal + Attivita.GetTotal; 
            }

        }


        public double ImpieghiAtDate(DateTime date)
        {

            return Spese.GetTotalAtDate(date) + Attivita.GetTotalAtDate(date);


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
        //riepilogo stato patrrimoniale

        [XmlIgnore]
        public AbstractBilancio Attivita
        {
            get { return _sublist[0] as AbstractBilancio; }
        }

        [XmlIgnore]
        public AbstractBilancio Passivita
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
