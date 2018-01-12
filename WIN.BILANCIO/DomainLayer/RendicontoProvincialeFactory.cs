﻿using System;
using System.Collections.Generic;
using System.Text;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.DomainLayer
{
    public class RendicontoProvincialeFactory : IRendicontoFactory 
    {

        #region IRendicontoFactory Membri di

        public Rendiconto GetNewRendiconto(string provincia, int anno, string regione, bool isRegionale)
        {
            Rendiconto r = new Rendiconto(provincia, anno,isRegionale ,regione );
            r.Bilancio = CreateBilancio();
            r.Preventivo = CreatePreventivo();

            r.Bilancio.CalculateParentName();
            r.Preventivo.CalculateParentName();

            return r;
        }

        #endregion


        private BilancioNew CreateBilancio()
        {
            BilancioNew b = new BilancioNew();


            Classificazione Attivita = new Classificazione("ATTIVITA'", "A", "");



            Classificazione immobilizzazioni = new Classificazione("Immobilizzazioni", "A.I", "A");
            immobilizzazioni.Add(new Conto("Immobilizzazioni immateriali", "A.I.1", "A.I"));
            immobilizzazioni.Add(new Conto("Immobilizzazioni materiali", "A.I.2", "A.I"));
            immobilizzazioni.Add(new Conto("Immobili", "A.I.3", "A.I"));
            immobilizzazioni.Add(new Conto("Immobilizzazioni finanziarie", "A.I.4", "A.I"));

            Classificazione crediti = new Classificazione("Crediti", "A.C", "A");
            crediti.Add(new Conto("Crediti verso enti bilaterali", "A.C.1", "A.C"));
            crediti.Add(new Conto("Crediti verso altri", "A.C.2", "A.C"));
            crediti.Add(new Conto("Crediti gestione RLST", "A.C.3", "A.C"));
            

            Classificazione disponibilita = new Classificazione("Disponibilità", "A.D", "A");
            disponibilita.Add(new Conto("Cassa", "A.D.1", "A.D"));
            Classificazione banche = new Classificazione("Depositi bancari e postali", "A.D.2", "A.D");
            banche.Add(new Conto("Banca1", "A.D.2.a", "A.D.2"));
            banche.Add(new Conto("Banca2", "A.D.2.b", "A.D.2"));
            banche.Add(new Conto("Banca3", "A.D.2.c", "A.D.2"));
            banche.Add(new Conto("Banca4", "A.D.2.d", "A.D.2"));
            banche.Add(new Conto("Banca5", "A.D.2.e", "A.D.2"));
            banche.Add(new Conto("Banca6", "A.D.2.f", "A.D.2"));
            disponibilita.Add(banche);
 
 



            Attivita.Add(immobilizzazioni);
            Attivita.Add(crediti);
            Attivita.Add(disponibilita);


            b.Add(Attivita);












            Classificazione passivita = new Classificazione("PASSIVITA'", "P", "");



            Classificazione debiti = new Classificazione("Debiti a breve", "P.D", "P");
            debiti.Add(new Conto("Debiti VS Feneal Nazionale", "P.D.1", "P.D"));
            debiti.Add(new Conto("Debiti Vs Feneal Regionali", "P.D.2", "P.D"));
            debiti.Add(new Conto("Debiti Vs C.S.T.", "P.D.3", "P.D"));
            debiti.Add(new Conto("Debiti commerciali", "P.D.4", "P.D"));
            debiti.Add(new Conto("Debiti tributari e previdenziali", "P.D.5", "P.D"));
            debiti.Add(new Conto("Debiti diversi", "P.D.6", "P.D"));
            debiti.Add(new Conto("Debiti anticipazioni Cassa Edile", "P.D.7", "P.D"));

            

            Classificazione debitilungo = new Classificazione("Debiti a lungo periodo", "P.L", "P");
            debitilungo.Add(new Conto("Mutuo passivo", "P.L.1", "P.L"));
            


            Classificazione fondi = new Classificazione("Fondi", "P.F", "P");
            fondi.Add(new Conto("Accantonamento TFR", "P.F.1", "P.F"));
            fondi.Add(new Conto("Fondi ammortamento", "P.F.2", "P.F"));
            fondi.Add(new Conto("Altri accantonamenti", "P.F.3", "P.F"));

            Classificazione netto = new Classificazione("Patrimonio sociale", "P.P", "P");
            netto.Add(new Conto("Patrimonio netto", "P.P.1", "P.P"));



            passivita.Add(debiti);
            passivita.Add(debitilungo);
            passivita.Add(fondi);
            passivita.Add(netto);


            b.Add(passivita);





         


            //****************************************************************************+++
            //******************************************************************************
            //Classificazione finanzaIniziale = new Classificazione("Situazione finanziaria iniziale", "FI", "");
            //finanzaIniziale.Add(new ContoPreventivo("Banca1","FI.0", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Banca2","FI.1", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Banca3", "FI.4", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Cassa", "FI.2", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Accantonamenti finanziari", "FI.3", "FI"));
       




            ////l'unico conto movimentabile è la cassa per la situazione finale
            //Classificazione finanzaFinale = new Classificazione("Situazione finanziaria finale", "FF", "");
            //finanzaFinale.Add(new Conto("Banca1", "FF.0", "FF"));
            //finanzaFinale.Add(new Conto("Banca2", "FF.1", "FF"));
            //finanzaFinale.Add(new Conto("Banca3", "FF.4", "FF"));
            //finanzaFinale.Add(new Conto("Cassa", "FF.2", "FF"));
            //finanzaFinale.Add(new Conto("Accantonamenti finanziari", "FF.3", "FF"));


            //b.Add(finanzaIniziale);
            //b.Add(finanzaFinale);

            //****************************************************************************************+
            //*****************************************************************************************







            Classificazione Spese = new Classificazione("SPESE","S","");
            


            Classificazione istituzionali1 = new Classificazione("Operazioni istituzionali", "S.OI","S");


            Classificazione politicoOrganizzative = new Classificazione("Spese politico organizzative", "S.OI.1", "S.OI");
            politicoOrganizzative.Add(new Conto("Attività organizzativa", "S.OI.1.a", "S.OI.1"));
            politicoOrganizzative.Add(new Conto("Informazione e propaganda", "S.OI.1.b", "S.OI.1"));
            politicoOrganizzative.Add(new Conto("Attività di formazione", "S.OI.1.c", "S.OI.1"));
            politicoOrganizzative.Add(new Conto("Strutture zonali Feneal-UIL", "S.OI.1.d", "S.OI.1"));
            politicoOrganizzative.Add(new Conto("Strutture zonali CSP-UIL", "S.OI.1.e", "S.OI.1"));




            Classificazione personale = new Classificazione("Spese del personale", "S.OI.2", "S.OI");
            personale.Add(new Conto("Retribuzioni personale (nette)", "S.OI.2.a", "S.OI.2"));
            personale.Add(new Conto("Collaboratori(netto)", "S.OI.2.b", "S.OI.2"));
            personale.Add(new Conto("IRPEF Ritenute e Addizionali", "S.OI.2.c", "S.OI.2"));
            personale.Add(new Conto("Contributi previdenziali / INPS-INAIL", "S.OI.2.d", "S.OI.2"));
            personale.Add(new Conto("IRAP", "S.OI.2.e", "S.OI.2"));
            personale.Add(new Conto("Trattenute sindacali", "S.OI.2.f", "S.OI.2"));
            personale.Add(new Conto("Liquidazione TFR", "S.OI.2.g", "S.OI.2"));



            Classificazione regionaleContr = new Classificazione("Contributo struttura regionale", "S.OI.3", "S.OI");
            regionaleContr.Add(new Conto("Quote di adesione contrattuale", "S.OI.3.a", "S.OI.3"));
            regionaleContr.Add(new Conto("Quota impianti fissi", "S.OI.3.b", "S.OI.3"));
         





            Classificazione Tesseramentocosto = new Classificazione("Tesseramento", "S.OI.4", "S.OI");
            Tesseramentocosto.Add(new Conto("Costo tessere", "S.OI.4.a", "S.OI.4"));


            Classificazione contributiStraord = new Classificazione("Contributi straordinari", "S.OI.5", "S.OI");
            contributiStraord.Add(new Conto("Contributi straordinari", "S.OI.5.a", "S.OI.5"));


            Classificazione spesegen = new Classificazione("Spese generali", "S.OI.6", "S.OI");
            spesegen.Add(new Conto("Compensi a professionisti", "S.OI.6.a", "S.OI.6"));
            spesegen.Add(new Conto("Postali - Telefoniche", "S.OI.6.b", "S.OI.6"));
            spesegen.Add(new Conto("Utenze", "S.OI.6.c", "S.OI.6"));
            spesegen.Add(new Conto("Manutenzioni", "S.OI.6.d", "S.OI.6"));
            spesegen.Add(new Conto("Affitto e condominio", "S.OI.6.e", "S.OI.6"));
            spesegen.Add(new Conto("Cancelleria", "S.OI.6.f", "S.OI.6"));
            spesegen.Add(new Conto("Polizze assicurative", "S.OI.6.g", "S.OI.6"));
            spesegen.Add(new Conto("Altre spese", "S.OI.6.h", "S.OI.6"));
            spesegen.Add(new Conto("Ritenute acconto IRES e imposte varie", "S.OI.6.i", "S.OI.6"));
            spesegen.Add(new Conto("Interessi ed oneri bancari", "S.OI.6.l", "S.OI.6"));
            spesegen.Add(new Conto("Interessi mutuo", "S.OI.6.m", "S.OI.6"));


            Classificazione spesedur = new Classificazione("Spese beni durevoli", "S.OI.7", "S.OI");
           
            
            spesedur.Add(new Conto("Hardware e software", "S.OI.7.c", "S.OI.7"));
            spesedur.Add(new Conto("Mobili e arredi", "S.OI.7.d", "S.OI.7"));
            spesedur.Add(new Conto("Autoveicoli", "S.OI.7.e", "S.OI.7"));
            spesedur.Add(new Conto("Attrezzature", "S.OI.7.f", "S.OI.7"));


            istituzionali1.Add(politicoOrganizzative);
            istituzionali1.Add(personale);
            istituzionali1.Add(regionaleContr);
            istituzionali1.Add(Tesseramentocosto);
            istituzionali1.Add(contributiStraord);
            istituzionali1.Add(spesegen);
            istituzionali1.Add(spesedur);



            Classificazione decommercializzate1 = new Classificazione("Operazioni decommercializzate", "S.OD","S");


            Classificazione organizzativeViaggi = new Classificazione("0rganizzazione viaggi e soggiorni turistici", "S.OD.1", "S.OD");
            organizzativeViaggi.Add(new Conto("Viaggi e soggiorni", "S.OD.1.a", "S.OD.1"));


            Classificazione reccoltepubbliche = new Classificazione("Raccolte pubbliche fondi (distintamente rendicontate)", "S.OD.2", "S.OD");
            reccoltepubbliche.Add(new Conto("Raccolte", "S.OD.2.a", "S.OD.2"));


            Classificazione regime = new Classificazione("Regime di convenzione e di accreditamento", "S.OD.3", "S.OD");
            regime.Add(new Conto("Regime convenzione e accr.", "S.OD.3.a", "S.OD.3"));


            Classificazione cessione = new Classificazione("Cessione di proprie pubblicazioni", "S.OD.4", "S.OD");
            cessione.Add(new Conto("Cessione pubblicazioni", "S.OD.4.a", "S.OD.4"));


            Classificazione altrespesegen = new Classificazione("Altre spese", "S.OD.5", "S.OD");
            altrespesegen.Add(new Conto("Altro", "S.OD.5.a", "S.OD.5"));


            decommercializzate1.Add(organizzativeViaggi);
            decommercializzate1.Add(reccoltepubbliche);
            decommercializzate1.Add(regime);
            decommercializzate1.Add(cessione);
            decommercializzate1.Add(altrespesegen);





            Spese.Add(istituzionali1);
            Spese.Add(decommercializzate1);




            Classificazione Entrate = new Classificazione("ENTRATE","E","");
           


            Classificazione istituzionali2 = new Classificazione("Operazioni istituzionali", "E.OI","E");

            Classificazione contributi = new Classificazione("Contributi territoriali", "E.OI.1","E.OI");
            contributi.Add(new Conto("Quote di adesione contrattuale CASSA EDILE", "E.OI.1.a", "E.OI.1"));
            contributi.Add(new Conto("Quote di adesione contrattuale EDILCASSA", "E.OI.1.b", "E.OI.1"));
            contributi.Add(new Conto("Quote di adesione contrattuale ALTRE CASSE", "E.OI.1.c", "E.OI.1"));
            contributi.Add(new Conto("Deleghe edili", "E.OI.1.d", "E.OI.1"));
            contributi.Add(new Conto("Deleghe impianti fissi", "E.OI.1.e", "E.OI.1"));
            contributi.Add(new Conto("Deleghe sindacali(LSU,DS,mobilità)", "E.OI.1.f", "E.OI.1"));






            Classificazione Tesseramento = new Classificazione("Tesseramento diretto", "E.OI.2", "E.OI");
            Tesseramento.Add(new Conto("Tesseramento", "E.OI.2.a", "E.OI.2"));


            Classificazione altricontributi = new Classificazione("Contributi", "E.OI.3", "E.OI");
            altricontributi.Add(new Conto("Contributi Feneal Nazionale", "E.OI.3.a", "E.OI.3"));
            altricontributi.Add(new Conto("Altri contributi", "E.OI.3.b", "E.OI.3"));


            Classificazione entrateVarie = new Classificazione("Entrate varie", "E.OI.4", "E.OI");
            entrateVarie.Add(new Conto("Contributi su vertenze", "E.OI.4.a", "E.OI.4"));
            entrateVarie.Add(new Conto("Interessi attivi", "E.OI.4.b", "E.OI.4"));
            entrateVarie.Add(new Conto("Gettoni presenza riversibili", "E.OI.4.c", "E.OI.4"));
            entrateVarie.Add(new Conto("Altre entrate", "E.OI.4.d", "E.OI.4"));


            Classificazione rlst = new Classificazione("Rimborso attività RLST", "E.OI.5", "E.OI");
            rlst.Add(new Conto("Costo personale RLST", "E.OI.5.a", "E.OI.5"));



            istituzionali2.Add(contributi);
            istituzionali2.Add(Tesseramento);
            istituzionali2.Add(altricontributi);
            istituzionali2.Add(entrateVarie);
            istituzionali2.Add(rlst);


            Classificazione decommercializzate2 = new Classificazione("Operazioni decommercializzate", "E.OD","E");



            Classificazione org = new Classificazione("0rganizzazione viaggi e soggiorni turistici", "E.OD.1", "E.OD");
            org.Add(new Conto("Viaggi e soggiorni", "E.OD.1.a", "E.OD.1"));

            Classificazione racc = new Classificazione("Raccolte pubbliche fondi (distintamente rendicontate)", "E.OD.2", "E.OD");
            racc.Add(new Conto("Raccolte", "E.OD.2.a", "E.OD.2"));

            Classificazione regimeconv = new Classificazione("Regime di convenzione e di accreditamento", "E.OD.3", "E.OD");
            regimeconv.Add(new Conto("Regime conv e accr.", "E.OD.3.a", "E.OD.3"));

            Classificazione cess = new Classificazione("Cessione di proprie pubblicazioni", "E.OD.4", "E.OD");
            cess.Add(new Conto("Cessione pubblicazioni", "E.OD.4.a", "E.OD.4"));

            Classificazione altre = new Classificazione("Altre entrate", "E.OD.5", "E.OD");
            altre.Add(new Conto("Altro", "E.OD.5.a", "E.OD.5"));





            decommercializzate2.Add(org);
            decommercializzate2.Add(racc);
            decommercializzate2.Add(regimeconv);
            decommercializzate2.Add(cess);
            decommercializzate2.Add(altre);




            Entrate.Add(istituzionali2);
            Entrate.Add(decommercializzate2);



            b.Add(Spese);
            b.Add(Entrate);


            return b;


        }


        private Preventivo CreatePreventivo()
        {
            Preventivo b = new Preventivo();


            //Classificazione finanzaIniziale = new Classificazione("Situazione finanziaria iniziale", "FI", "");
            //finanzaIniziale.Add(new ContoPreventivo("Banca1", "FI.0", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Banca2", "FI.1", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Banca3", "FI.4", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Cassa", "FI.2", "FI"));
            //finanzaIniziale.Add(new ContoPreventivo("Accantonamenti", "FI.3", "FI"));



            //Classificazione finanzaFinale = new Classificazione("Situazione finanziaria finale", "FF", "");
            //finanzaFinale.Add(new ContoPreventivo("Banca1", "FF.0", "FF"));
            //finanzaFinale.Add(new ContoPreventivo("Banca2", "FF.1", "FF"));
            //finanzaFinale.Add(new ContoPreventivo("Banca3", "FF.4", "FF"));
            //finanzaFinale.Add(new ContoPreventivo("Cassa", "FF.2", "FF"));
            //finanzaFinale.Add(new ContoPreventivo("Accantonamenti", "FF.3", "FF"));

            //b.Add(finanzaIniziale);
            //b.Add(finanzaFinale);





            Classificazione Attivita = new Classificazione("ATTIVITA'", "A", "");



            Classificazione immobilizzazioni = new Classificazione("Immobilizzazioni", "A.I", "A");
            immobilizzazioni.Add(new ContoPreventivo("Immobilizzazioni immateriali", "A.I.1", "A.I"));
            immobilizzazioni.Add(new ContoPreventivo("Immobilizzazioni materiali", "A.I.2", "A.I"));
            immobilizzazioni.Add(new ContoPreventivo("Immobili", "A.I.3", "A.I"));
            immobilizzazioni.Add(new ContoPreventivo("Immobilizzazioni finanziarie", "A.I.4", "A.I"));

            Classificazione crediti = new Classificazione("Crediti", "A.C", "A");
            crediti.Add(new ContoPreventivo("Crediti verso enti bilaterali", "A.C.1", "A.C"));
            crediti.Add(new ContoPreventivo("Crediti verso altri", "A.C.2", "A.C"));
            crediti.Add(new ContoPreventivo("Crediti gestione RLST", "A.C.3", "A.C"));

            Classificazione disponibilita = new Classificazione("Disponibilità", "A.D", "A");
            disponibilita.Add(new ContoPreventivo("Cassa", "A.D.1", "A.D"));
            Classificazione banche = new Classificazione("Depositi bancari e postali", "A.D.2", "A.D");
            banche.Add(new ContoPreventivo("Banca1", "A.D.2.a", "A.D.2"));
            banche.Add(new ContoPreventivo("Banca2", "A.D.2.b", "A.D.2"));
            banche.Add(new ContoPreventivo("Banca3", "A.D.2.c", "A.D.2"));
            banche.Add(new ContoPreventivo("Banca4", "A.D.2.d", "A.D.2"));
            banche.Add(new ContoPreventivo("Banca5", "A.D.2.e", "A.D.2"));
            banche.Add(new ContoPreventivo("Banca6", "A.D.2.f", "A.D.2"));
            disponibilita.Add(banche);





            Attivita.Add(immobilizzazioni);
            Attivita.Add(crediti);
            Attivita.Add(disponibilita);


            b.Add(Attivita);












            Classificazione passivita = new Classificazione("PASSIVITA'", "P", "");



            Classificazione debiti = new Classificazione("Debiti a breve", "P.D", "P");
            debiti.Add(new ContoPreventivo("Debiti VS Feneal Nazionale", "P.D.1", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti Vs Feneal Regionali", "P.D.2", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti Vs C.S.T.", "P.D.3", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti commerciali", "P.D.4", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti tributari e previdenziali", "P.D.5", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti diversi", "P.D.6", "P.D"));
            debiti.Add(new ContoPreventivo("Debiti anticipazioni Cassa Edile", "P.D.7", "P.D"));
            

            Classificazione debitilungo = new Classificazione("Debiti a lungo periodo", "P.L", "P");
            debitilungo.Add(new ContoPreventivo("Mutuo passivo", "P.L.1", "P.L"));



            Classificazione fondi = new Classificazione("Fondi", "P.F", "P");
            fondi.Add(new ContoPreventivo("Accantonamento TFR", "P.F.1", "P.F"));
            fondi.Add(new ContoPreventivo("Fondi ammortamento", "P.F.2", "P.F"));
            fondi.Add(new ContoPreventivo("Altri accantonamenti", "P.F.3", "P.F"));

            Classificazione netto = new Classificazione("Patrimonio sociale", "P.P", "P");
            netto.Add(new ContoPreventivo("Patrimonio netto", "P.P.1", "P.P"));



            passivita.Add(debiti);
            passivita.Add(debitilungo);
            passivita.Add(fondi);
            passivita.Add(netto);


            b.Add(passivita);










            Classificazione Spese = new Classificazione("SPESE", "S", "");



            Classificazione istituzionali1 = new Classificazione("Operazioni istituzionali", "S.OI", "S");


            Classificazione politicoOrganizzative = new Classificazione("Spese politico organizzative", "S.OI.1", "S.OI");
            politicoOrganizzative.Add(new ContoPreventivo("Attività organizzativa", "S.OI.1.a", "S.OI.1"));
            politicoOrganizzative.Add(new ContoPreventivo("Informazione e propaganda", "S.OI.1.b", "S.OI.1"));
            politicoOrganizzative.Add(new ContoPreventivo("Attività di formazione", "S.OI.1.c", "S.OI.1"));
            politicoOrganizzative.Add(new ContoPreventivo("Strutture zonali Feneal-UIL", "S.OI.1.d", "S.OI.1"));
            politicoOrganizzative.Add(new ContoPreventivo("Strutture zonali CSP-UIL", "S.OI.1.e", "S.OI.1"));







            Classificazione personale = new Classificazione("Spese del personale", "S.OI.2", "S.OI");
            personale.Add(new ContoPreventivo("Retribuzioni personale (nette)", "S.OI.2.a", "S.OI.2"));
            personale.Add(new ContoPreventivo("Collaboratori(netto)", "S.OI.2.b", "S.OI.2"));
            personale.Add(new ContoPreventivo("IRPEF Ritenute e Addizionali", "S.OI.2.c", "S.OI.2"));
            personale.Add(new ContoPreventivo("Contributi previdenziali / INPS-INAIL", "S.OI.2.d", "S.OI.2"));
            personale.Add(new ContoPreventivo("IRAP", "S.OI.2.e", "S.OI.2"));
            personale.Add(new ContoPreventivo("Trattenute sindacali", "S.OI.2.f", "S.OI.2"));
            personale.Add(new ContoPreventivo("Liquidazione TFR", "S.OI.2.g", "S.OI.2"));



            Classificazione regionaleContr = new Classificazione("Contributo struttura regionale", "S.OI.3", "S.OI");
            regionaleContr.Add(new ContoPreventivo("Quote di adesione contrattuale", "S.OI.3.a", "S.OI.3"));
            regionaleContr.Add(new ContoPreventivo("Quota impianti fissi", "S.OI.3.b", "S.OI.3"));
         



            Classificazione Tesseramentocosto = new Classificazione("Tesseramento", "S.OI.4", "S.OI");
            Tesseramentocosto.Add(new ContoPreventivo("Costo tessere", "S.OI.4.a", "S.OI.4"));


            Classificazione contributiStraord = new Classificazione("Contributi straordinari", "S.OI.5", "S.OI");
            contributiStraord.Add(new ContoPreventivo("Contributi straordinari", "S.OI.5.a", "S.OI.5"));


            Classificazione spesegen = new Classificazione("Spese generali", "S.OI.6", "S.OI");
            spesegen.Add(new ContoPreventivo("Compensi a professionisti", "S.OI.6.a", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Postali - Telefoniche", "S.OI.6.b", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Utenze", "S.OI.6.c", "S.OI.c"));
            spesegen.Add(new ContoPreventivo("Manutenzioni", "S.OI.6.d", "S.OI.6"));
           // spesegen.Add(new ContoPreventivo("Mobili e arredo", "S.OI.6.e", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Affitto e condominio", "S.OI.6.e", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Cancelleria", "S.OI.6.f", "S.OI.6"));
           // spesegen.Add(new ContoPreventivo("Informatica", "S.OI.6.h", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Polizze assicurative", "S.OI.6.g", "S.OI.6"));
           // spesegen.Add(new ContoPreventivo("Mutuo", "S.OI.6.h", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Altre spese", "S.OI.6.h", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Ritenute acconto IRES e imposte varie", "S.OI.6.i", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Interessi ed oneri bancari", "S.OI.6.l", "S.OI.6"));
            spesegen.Add(new ContoPreventivo("Interessi mutuo", "S.OI.6.m", "S.OI.6"));

            Classificazione spesedur = new Classificazione("Spese beni durevoli", "S.OI.7", "S.OI");
            //spesedur.Add(new ContoPreventivo("Quota costo immobili", "S.OI.7.a", "S.OI.7"));
           // spesedur.Add(new ContoPreventivo("Interessi mutuo", "S.OI.7.b", "S.OI.7"));
            spesedur.Add(new ContoPreventivo("Hardware e software", "S.OI.7.c", "S.OI.7"));
            spesedur.Add(new ContoPreventivo("Mobili e arredi", "S.OI.7.d", "S.OI.7"));
            spesedur.Add(new ContoPreventivo("Autoveicoli", "S.OI.7.e", "S.OI.7"));
            spesedur.Add(new ContoPreventivo("Attrezzature", "S.OI.7.f", "S.OI.7"));

            istituzionali1.Add(politicoOrganizzative);
            istituzionali1.Add(personale);
            istituzionali1.Add(regionaleContr);
            istituzionali1.Add(Tesseramentocosto);
            istituzionali1.Add(contributiStraord);
            istituzionali1.Add(spesegen);
            istituzionali1.Add(spesedur);


            Classificazione decommercializzate1 = new Classificazione("Operazioni decommercializzate", "S.OD", "S");


            Classificazione organizzativeViaggi = new Classificazione("0rganizzazione viaggi e soggiorni turistici", "S.OD.1", "S.OD");
            organizzativeViaggi.Add(new ContoPreventivo("Viaggi e soggiorni", "S.OD.1.a", "S.OD.1"));


            Classificazione reccoltepubbliche = new Classificazione("Raccolte pubbliche fondi", "S.OD.2", "S.OD");
            reccoltepubbliche.Add(new ContoPreventivo("Raccolte", "S.OD.2.a", "S.OD.2"));


            Classificazione regime = new Classificazione("Regime di convenzione e di accreditamento", "S.OD.3", "S.OD");
            regime.Add(new ContoPreventivo("Regime conv e accr.", "S.OD.3.a", "S.OD.3"));


            Classificazione cessione = new Classificazione("Cessione di proprie pubblicazioni", "S.OD.4", "S.OD");
            cessione.Add(new ContoPreventivo("Cessione pubblicazioni", "S.OD.4.a", "S.OD.4"));


            Classificazione altrespesegen = new Classificazione("Altre spese", "S.OD.5", "S.OD");
            altrespesegen.Add(new ContoPreventivo("Altro", "S.OD.5.a", "S.OD.5"));


            decommercializzate1.Add(organizzativeViaggi);
            decommercializzate1.Add(reccoltepubbliche);
            decommercializzate1.Add(regime);
            decommercializzate1.Add(cessione);
            decommercializzate1.Add(altrespesegen);





            Spese.Add(istituzionali1);
            Spese.Add(decommercializzate1);




            Classificazione Entrate = new Classificazione("ENTRATE", "E", "");



            Classificazione istituzionali2 = new Classificazione("Operazioni istituzionali", "E.OI", "E");

            Classificazione contributi = new Classificazione("Contributi territoriali", "E.OI.1", "E.OI");
            contributi.Add(new ContoPreventivo("Quote di adesione contrattuale CASSA EDILE", "E.OI.1.a", "E.OI.1"));
            contributi.Add(new ContoPreventivo("Quote di adesione contrattuale EDILCASSA", "E.OI.1.b", "E.OI.1"));
            contributi.Add(new ContoPreventivo("Quote di adesione contrattuale ALTRE CASSE", "E.OI.1.c", "E.OI.1"));
            contributi.Add(new ContoPreventivo("Deleghe edili", "E.OI.1.d", "E.OI.1"));
            contributi.Add(new ContoPreventivo("Deleghe impianti fissi", "E.OI.1.e", "E.OI.1"));
            contributi.Add(new ContoPreventivo("Deleghe sindacali(LSU,DS,mobilità)", "E.OI.1.f", "E.OI.1"));






            Classificazione Tesseramento = new Classificazione("Tesseramento diretto", "E.OI.2", "E.OI");
            Tesseramento.Add(new ContoPreventivo("Tesseramento", "E.OI.2.a", "E.OI.2"));


            Classificazione altricontributi = new Classificazione("Contributi", "E.OI.3", "E.OI");
            altricontributi.Add(new ContoPreventivo("Contributi Feneal Nazionale", "E.OI.3.a", "E.OI.3"));
            altricontributi.Add(new ContoPreventivo("Altri contributi", "E.OI.3.b", "E.OI.3"));


            Classificazione entrateVarie = new Classificazione("Entrate varie", "E.OI.4", "E.OI");
            entrateVarie.Add(new ContoPreventivo("Contributi su vertenze", "E.OI.4.a", "E.OI.4"));
            entrateVarie.Add(new ContoPreventivo("Interessi attivi", "E.OI.4.b", "E.OI.4"));
            entrateVarie.Add(new ContoPreventivo("Gettoni presenza riversibili", "E.OI.4.c", "E.OI.4"));
            entrateVarie.Add(new ContoPreventivo("Altre entrate", "E.OI.4.d", "E.OI.4"));


            Classificazione rlst = new Classificazione("Rimborso attività RLST", "E.OI.5", "E.OI");
            rlst.Add(new ContoPreventivo("Costo personale RLST", "E.OI.5.a", "E.OI.5"));




            istituzionali2.Add(contributi);
            istituzionali2.Add(Tesseramento);
            istituzionali2.Add(altricontributi);
            istituzionali2.Add(entrateVarie);
            istituzionali2.Add(rlst);


            Classificazione decommercializzate2 = new Classificazione("Operazioni decommercializzate", "E.OD", "E");



            Classificazione org = new Classificazione("0rganizzazione viaggi e soggiorni turistici", "E.OD.1", "E.OD");
            org.Add(new ContoPreventivo("Viaggi e soggiorni", "E.OD.1.a", "E.OD.1"));

            Classificazione racc = new Classificazione("Raccolte pubbliche fondi", "E.OD.2", "E.OD");
            racc.Add(new ContoPreventivo("Raccolte", "E.OD.2.a", "E.OD.2"));

            Classificazione regimeconv = new Classificazione("Regime di convenzione e di accreditamento", "E.OD.3", "E.OD");
            regimeconv.Add(new ContoPreventivo("Regime conv e accr.", "E.OD.3.a", "E.OD.3"));

            Classificazione cess = new Classificazione("Cessione di proprie pubblicazioni", "E.OD.4", "E.OD");
            cess.Add(new ContoPreventivo("Cessione pubblicazioni", "E.OD.4.a", "E.OD.4"));

            Classificazione altre = new Classificazione("Altre entrate", "E.OD.5", "E.OD");
            altre.Add(new ContoPreventivo("Altro", "E.OD.5.a", "E.OD.5"));





            decommercializzate2.Add(org);
            decommercializzate2.Add(racc);
            decommercializzate2.Add(regimeconv);
            decommercializzate2.Add(cess);
            decommercializzate2.Add(altre);




            Entrate.Add(istituzionali2);
            Entrate.Add(decommercializzate2);



            b.Add(Spese);
            b.Add(Entrate);


            return b;
        }



    }
}
