using System;
using System.Collections.Generic;
using System.Text;

using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.ServiceLayer.DTO;
using BilancioFenealgest.DataAccess;

namespace BilancioFenealgest.Test
{

    //[TestFixture]
    //public class TestScritture
    //{



    //    [Test]
    //    public void TestScritturaSempliceBilancio()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010,"Basilicata");


    //        Bilancio b = r.Bilancio;

    //        //Eseguo il calcolo delle totalizzazioni per il bilancio
    //        double d = b.GetTotal;
    //        Assert.AreEqual(d, 0);

    //        //Creo qualche scrittura semplice

    //        //voce di entrata1
    //        Scrittura s = new Scrittura();
    //        s.Causale = "Quote cassa edile";
    //        s.Date = DateTime.Now.Date;
    //        s.Description = "";
    //        s.Importo = 100;
    //        s.TipoOperazione = TipoOperazione.Bancaria;

           


    //        //verifico il totale per le spese
    //        AbstractBilancio spese = b.SubList[2] as AbstractBilancio;
    //        Assert.AreEqual(spese.Description, "SPESE");
    //        Assert.AreEqual(spese.GetTotal, 0);

    //        //Cerco il nodo delle entrate
    //        AbstractBilancio entrate = b.SubList[3] as AbstractBilancio;
    //        Assert.AreEqual(entrate.Description, "ENTRATE");
    //        Assert.AreEqual(entrate.GetTotal , 0);




    //        //Prendo il nodo operazioni istituzionali
    //        AbstractBilancio istituzionali = entrate.SubList[0] as AbstractBilancio;
    //        Assert.AreEqual(istituzionali.Description, "Operazioni istituzionali");
    //        Assert.AreEqual(istituzionali.GetTotal, 0);

    //        //Prendo il nodo contributi territoriali
    //        AbstractBilancio contributi = istituzionali.SubList[0] as AbstractBilancio;
    //        Assert.AreEqual(contributi.Description, "Contributi territoriali");
    //        Assert.AreEqual(contributi.GetTotal, 0);

    //        //Prendo il conto contributi territoriali
    //        Conto quote = contributi.SubList[0] as Conto;
    //        Assert.AreEqual(quote.Description, "Quote di adesione contrattuale CASSA EDILE");
    //        Assert.AreEqual(quote.GetTotal, 0);






    //        //ottenuto il conto posso aggingere la scrittura
    //        quote.Add(s, b.Cassa);


    //        //riverifico tutte le principali totalizzazioni
    //         spese = b.SubList[2] as AbstractBilancio;
    //        Assert.AreEqual(spese.Description, "SPESE");
    //        Assert.AreEqual(spese.GetTotal, 0);

    //        //Cerco il nodo delle entrate
    //         entrate = b.SubList[3] as AbstractBilancio;
    //        Assert.AreEqual(entrate.Description, "ENTRATE");
    //        Assert.AreEqual(entrate.GetTotal, 100);

    //        //Prendo il nodo operazioni istituzionali
    //         istituzionali = entrate.SubList[0] as AbstractBilancio;
    //        Assert.AreEqual(istituzionali.Description, "Operazioni istituzionali");
    //        Assert.AreEqual(istituzionali.GetTotal, 100);


    //        //Prendo il nodo delle commercializzate e verifico che il totale sia 0
    //        AbstractBilancio decomm = entrate.SubList[1] as AbstractBilancio;
    //        Assert.AreEqual(decomm.GetTotal, 0);

    //        //Prendo il nodo contributi territoriali
    //         contributi = istituzionali.SubList[0] as AbstractBilancio;
    //        Assert.AreEqual(contributi.Description, "Contributi territoriali");
    //        Assert.AreEqual(contributi.GetTotal, 100);

    //        //Prendo il conto contributi territoriali
    //         quote = contributi.SubList[0] as Conto;
    //        Assert.AreEqual(quote.Description, "Quote di adesione contrattuale CASSA EDILE");
    //        Assert.AreEqual(quote.GetTotal, 100);



    //        //Verifico inoltre la presenza della scrittura
    //        Assert.AreEqual(quote.SubList.Count, 1);
    //        Scrittura sc = quote.SubList[0] as Scrittura;



    //        Assert.AreEqual(sc.Causale  , "Quote cassa edile");
    //        Assert.AreEqual(sc.Date , DateTime.Now.Date );
    //        Assert.AreEqual(sc.Description , "" );
    //        Assert.AreEqual(sc.Importo , 100 );
    //        Assert.AreEqual(sc.TipoOperazione  ,TipoOperazione.Bancaria );


    //        Assert.AreEqual(b.GetTotal, 100);
    //    }





    //    [Test]
    //    public void TestScrittureSemplici()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        Bilancio b = r.Bilancio;


    //        //entrate
    //        Scrittura quoteCassa = new Scrittura();
    //        quoteCassa.Causale = "Quote cassa edile primo sem 2010";
    //        quoteCassa.Date = DateTime.Now.Date;
    //        quoteCassa.Importo = 2200;
    //        quoteCassa.NumeroPezza = "100A";
    //        quoteCassa.TipoOperazione = TipoOperazione.Bancaria;



    //        //prendo il conto delle quote
    //        Conto quote = b.FindNodeById("E.OI.1.a") as Conto;
    //        quote.Add(quoteCassa, b.Cassa);



    //        Scrittura quoteTesseramentoDiretto = new Scrittura();
    //        quoteTesseramentoDiretto.Causale = "Tesseramento diretto Francesco Randazzo primo sem 2010";
    //        quoteTesseramentoDiretto.Date = DateTime.Now.Date;
    //        quoteTesseramentoDiretto.Importo = 95.25;
    //        quoteTesseramentoDiretto.NumeroPezza = "21T";
    //        quoteTesseramentoDiretto.TipoOperazione = TipoOperazione.Cassa;

    //        //prendo il conto delle quote tesseramento diretto
    //        Conto tesseramento = b.FindNodeById("E.OI.2.a") as Conto;
    //        tesseramento.Add(quoteTesseramentoDiretto, b.Cassa);



    //        //uscite
    //        Scrittura personale= new Scrittura();
    //        personale.Causale = "personale maggio 2010 (gaetano e giorgia)";
    //        personale.Date = DateTime.Now.Date;
    //        personale.Importo = 1100.50;
    //        personale.NumeroPezza = "56/r";
    //        personale.TipoOperazione = TipoOperazione.Bancaria;

    //        //prendo il conto del costo personale
    //        Conto personalec = b.FindNodeById("S.OI.2.a") as Conto;
    //        personalec.Add(personale, b.Cassa);


         
    //        Scrittura spese_telefoniche = new Scrittura();
    //        spese_telefoniche.Causale = "spese telefoiniche";
    //        spese_telefoniche.Date = DateTime.Now.Date;
    //        spese_telefoniche.Importo = 12.50;
    //        spese_telefoniche.NumeroPezza = "57/r";
    //        spese_telefoniche.TipoOperazione = TipoOperazione.Cassa;

    //        //prendo il conto spese telefoniuiche
    //        Conto tel = b.FindNodeById("S.OI.6.a") as Conto;
    //        tel.Add(spese_telefoniche, b.Cassa);




    //        b.SetSituazioneFinnziariaFinale(1099.5, 0);



    //        double t = b.GetTotal;

    //        Assert.AreEqual(t,0);



    //        //provo  a rimuovere una scritutra di cassa
    //        string id = spese_telefoniche.Id;
    //        tel.Remove(id, b.Cassa);


    //        //poichè viene tolta una scrittura anche dalla cassa sarò sicuro
    //        //che il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);


    //        //reinserisco la stessa scrittura
    //        tel = b.FindNodeById("S.OI.6.a") as Conto;
    //        tel.Add(spese_telefoniche, b.Cassa);
    //        //il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);

    //        //Adesso tolgo una scrittura daklle entrate


    //        id = quoteTesseramentoDiretto.Id;
    //        tesseramento.Remove(id, b.Cassa);

    //        //il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);

    //        //ripristino la situazione
    //        tesseramento = b.FindNodeById("E.OI.2.a") as Conto;
    //        tesseramento.Add(quoteTesseramentoDiretto, b.Cassa);

    //        //il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);



    //        //Se adesso provo a togliere una scrittura bancaria
    //        //le cose cambiano

    //        id = quoteCassa.Id;
    //        quote.Remove(id, b.Cassa);

    //        //a questo punto per far tornare il bilancio a 0 devo modificare
    //        //la cassa
    //        //il valore del bilancio sarà pari a 
    //        //Entrate (95,25) + Finanza inizialie (0) - Spese (1113) - Finanza Finale (cassa(82,75) + banca (1099,5))
    //        //= -2200

    //        t = b.GetTotal;
    //        Assert.AreEqual(t, -2200);

    //        //ripristino la situazione
    //        quote = b.FindNodeById("E.OI.1.a") as Conto;
    //        quote.Add(quoteCassa, b.Cassa);
    //        //il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);


    //        //tolgo adesso un conto spesa bancario

    //        id = personale.Id;
    //        personalec.Remove(id, b.Cassa);


    //        // a questo punto il totale sarà 
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 1100.5);


    //       //ripristino
    //        personalec = b.FindNodeById("S.OI.2.a") as Conto;
    //        personalec.Add(personale, b.Cassa);
    //        //il totale sarà sempre 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);



    //        //aggiungo una scrittura di cassa
    //        Scrittura cash = new Scrittura();
    //        cash.Importo = 100;
    //        cash.Causale = "Prelievo conto";
    //        cash.Date = DateTime.Now.Date;
    //        cash.NumeroPezza = "ff4";

    //        b.Cassa.Add(cash, null);

    //        //Se testo il toale adesso esso risulta = -100
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, -100);

    //        //ovviamente modifico l'importo della banca e tutto torna ok

    //        b.SetSituazioneFinnziariaFinale(999.5, 0);




    //        //a questo punto il totale torna ad essere 0
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);


    //        //se tologlo la scrittura dal conto di cassa
    //        b.Cassa.Remove(cash.Id, null);

    //        //Il totale sarà 100 euro 
    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 100);

    //        //se ripristino la situazione iniziale con la finanza tutto torna a 0

    //        b.SetSituazioneFinnziariaFinale(1099.5, 0);


    //        t = b.GetTotal;
    //        Assert.AreEqual(t, 0);


    //        //Adesso salvo e riverifico i totali e i saldi sei singoli conti

    //        RendicontoMapper m = new RendicontoMapper();

    //         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\prova.xml";

    //         m.SaveRendiconto(r, path);


    //         Rendiconto r1 = m.LoadRendicontoByPath(path);


    //         Bilancio b1 = r1.Bilancio;

    //         t = b1.GetTotal;
    //         Assert.AreEqual(t, 0);

    //         tel = b1.FindNodeById("S.OI.6.a") as Conto;
    //         quote = b1.FindNodeById("E.OI.1.a") as Conto;
    //         personalec = b1.FindNodeById("S.OI.2.a") as Conto;
    //         tesseramento = b1.FindNodeById("E.OI.2.a") as Conto;
            

    //        //adesso verifico i saldi
    //         Assert.AreEqual(tel.GetTotal, 12.5);
    //         Assert.AreEqual(quote.GetTotal, 2200);
    //         Assert.AreEqual(personalec.GetTotal, 1100.5);
    //         Assert.AreEqual(tesseramento.GetTotal, 95.25);
    //         Assert.AreEqual(b1.Cassa.GetTotal, 82.75);
    //         Assert.AreEqual(b1.BancaFinale.GetTotal, 1099, 5);

    //    }


    //    [Test]
    //    public void TestBilancioService()
    //    {
    //        Rendiconto r = CreateRendiconto();

    //        BilancioService s = new BilancioService(r.Bilancio);


    //        ScrittureDTO dto = new ScrittureDTO();






    //    }

    //    private Rendiconto CreateRendiconto()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");
    //        Bilancio b = r.Bilancio;


    //        //entrate
    //        Scrittura quoteCassa = new Scrittura();
    //        quoteCassa.Causale = "Quote cassa edile primo sem 2010";
    //        quoteCassa.Date = DateTime.Now.Date;
    //        quoteCassa.Importo = 2200;
    //        quoteCassa.NumeroPezza = "100A";
    //        quoteCassa.TipoOperazione = TipoOperazione.Bancaria;



    //        //prendo il conto delle quote
    //        Conto quote = b.FindNodeById("E.OI.1.a") as Conto;
    //        quote.Add(quoteCassa, b.Cassa);



    //        Scrittura quoteTesseramentoDiretto = new Scrittura();
    //        quoteTesseramentoDiretto.Causale = "Tesseramento diretto Francesco Randazzo primo sem 2010";
    //        quoteTesseramentoDiretto.Date = DateTime.Now.Date;
    //        quoteTesseramentoDiretto.Importo = 95.25;
    //        quoteTesseramentoDiretto.NumeroPezza = "21T";
    //        quoteTesseramentoDiretto.TipoOperazione = TipoOperazione.Cassa;

    //        //prendo il conto delle quote tesseramento diretto
    //        Conto tesseramento = b.FindNodeById("E.OI.2.a") as Conto;
    //        tesseramento.Add(quoteTesseramentoDiretto, b.Cassa);



    //        //uscite
    //        Scrittura personale = new Scrittura();
    //        personale.Causale = "personale maggio 2010 (gaetano e giorgia)";
    //        personale.Date = DateTime.Now.Date;
    //        personale.Importo = 1100.50;
    //        personale.NumeroPezza = "56/r";
    //        personale.TipoOperazione = TipoOperazione.Bancaria;

    //        //prendo il conto del costo personale
    //        Conto personalec = b.FindNodeById("S.OI.2.a") as Conto;
    //        personalec.Add(personale, b.Cassa);



    //        Scrittura spese_telefoniche = new Scrittura();
    //        spese_telefoniche.Causale = "spese telefoiniche";
    //        spese_telefoniche.Date = DateTime.Now.Date;
    //        spese_telefoniche.Importo = 12.50;
    //        spese_telefoniche.NumeroPezza = "57/r";
    //        spese_telefoniche.TipoOperazione = TipoOperazione.Cassa;

    //        //prendo il conto spese telefoniuiche
    //        Conto tel = b.FindNodeById("S.OI.6.a") as Conto;
    //        tel.Add(spese_telefoniche, b.Cassa);




    //        b.SetSituazioneFinnziariaFinale(1099.5, 0);

    //        return r;
    //    }
    //}
}
