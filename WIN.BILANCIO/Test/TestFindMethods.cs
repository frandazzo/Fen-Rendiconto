using System;
using System.Collections.Generic;
using System.Text;

using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.Test
{
    //[TestFixture]
    //public class TestFindMethods
    //{

    //    public void TestSimpleFindByRelativePath()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        //cerco il nodo Entrate


    //        Bilancio b = r.Bilancio;


    //        //Imposto il separatore
    //        b.SetNodePathSeparator(".");

    //        AbstractBilancio entrate = b.FindNodeByDescriptionPath("ENTRATE.");


    //        Assert.AreEqual(entrate.Description, "ENTRATE");



    //    }


    //    public void TestSimpleFindByAbsoluteAndRelativePath()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        //cerco il nodo Entrate


    //        Bilancio b = r.Bilancio;


    //        //Imposto il separatore
    //        b.SetNodePathSeparator(".");

    //        AbstractBilancio entrate = b.FindNodeByDescriptionPath(".ENTRATE.");


    //        //ricerca con path assoluto
    //        AbstractBilancio istituzionali = entrate.FindNodeByDescriptionPath("ENTRATE.Operazioni istituzionali");
    //        Assert.AreEqual(istituzionali.Id, "E.OI");

    //        //ricerca con path relativo
    //        istituzionali = entrate.FindNodeByDescriptionPath("Operazioni istituzionali");
    //        Assert.AreEqual(istituzionali.Id, "E.OI");





    //    }


    //    public void TestSimpleFind()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        //cerco il nodo Entrate


    //        Bilancio b = r.Bilancio;


    //        //Imposto il separatore
    //        b.SetNodePathSeparator(".");

    //        AbstractBilancio entrate = b.FindNodeByDescriptionPath("");


    //        Assert.IsNull(entrate);


    //        entrate = b.FindNodeByDescriptionPath("... .");

    //        //Assert.IsInstanceOfType(typeof(Bilancio), entrate);

    //        Assert.IsNull(entrate);

    //    }




    //    public void TestDeepFind()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        //cerco il nodo Entrate


    //        Bilancio b = r.Bilancio;


    //        //Imposto il separatore
    //        b.SetNodePathSeparator(".");

    //        AbstractBilancio DelegheEdili = b.FindNodeByDescriptionPath("ENTRATE.Operazioni istituzionali.Contributi territoriali.Deleghe edili");


    //        Assert.AreEqual(DelegheEdili.Id, "E.OI.1.d");


    //        //prendo il dato sulla foglia con percorso assoluto
    //        AbstractBilancio t = DelegheEdili.FindNodeByDescriptionPath("Deleghe edili");

    //        Assert.AreEqual(DelegheEdili.Id, "E.OI.1.d");


    //        //provo ad andare in profondità ad una foglia
    //        t = DelegheEdili.FindNodeByDescriptionPath("Deleghe edili.edrfgef");
    //        //le parti successive vengono ignorate
    //        Assert.AreEqual(DelegheEdili.Id, "E.OI.1.d");


    //       //sbaglio il percorso
    //        DelegheEdili = b.FindNodeByDescriptionPath("ENTRATE.Operazioni istituzionali.Contributi terrili.Deleghe edili");

    //        Assert.IsNull(DelegheEdili);


    //    }



    //    public void  TestFindByID()
    //    {
    //        Rendiconto r = RendicontoFactory.CreateRendiconto(true, "Matera", 2010, "Basilicata");


    //        //cerco il nodo Entrate


    //        Bilancio b = r.Bilancio;



    //        AbstractBilancio entrate = b.FindNodeById("E");

    //        Assert.AreEqual(entrate.Description , "ENTRATE");

    //        AbstractBilancio spesedecom = b.FindNodeById("S.OD");

    //        Assert.AreEqual(spesedecom.Description, "Operazioni decommercializzate");

    //        AbstractBilancio gettoni = b.FindNodeById("E.OI.4.c");

    //        Assert.AreEqual(gettoni.Description, "Gettoni presenza riversibili");

    //        AbstractBilancio nullo = b.FindNodeById("E.WOI.4.c");

    //        Assert.IsNull(nullo);



    //    }



    //}
}
