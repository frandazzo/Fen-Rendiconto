using System;
using System.Collections.Generic;
using System.Text;

using BilancioFenealgest.DomainLayer;
using WIN.TECHNICAL.MIDDLEWARE.XmlSerializzation;

namespace BilancioFenealgest.Test
{
   // [TestFixture]
   //public  class TestSerializzazione
   // {

   //     [Test]
   //     public void TestSerializzaizoneBilancioProvinciale()
   //     {

   //         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\prova.xml";

   //         Rendiconto f = RendicontoFactory.CreateRendiconto(true, "MATERA", 2010, "Basilicata");


   //         ObjectXMLSerializer<Rendiconto>.Save(f, path);



   //     }

   //     public void TestDeserializzaizoneBilancioProvinciale()
   //     {

   //         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\prova.xml";

   //         Rendiconto rend = ObjectXMLSerializer<Rendiconto>.Load(path);
   //         Assert.AreEqual(rend.Province, "MATERA");
   //         Assert.AreEqual(rend.Year, 2010);

   //         CheckBilancioProvinciale(rend.Bilancio);
   //         CheckPreventivoProvinciale(rend.Preventivo);

   //     }

   //     private void CheckBilancioProvinciale(Bilancio b)
   //     {
           

   //         AbstractBilancio bil = b.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "SPESE");
   //         Assert.AreEqual(bil.Id, "S");
   //         Assert.AreEqual(bil.ParentId, "");

   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Id, "S.OI");
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).ParentId, "S");
   //         AbstractBilancio subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Spese politico organizzative");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Id, "S.OI.1");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).ParentId, "S.OI");

   //         AbstractBilancio subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Attività organizzativa");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.1.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.1");

   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Informazione e propaganda");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "S.OI.1.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "S.OI.1");




   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Attività di sviluppo");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "S.OI.1.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "S.OI.1");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Attività di formazione");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "S.OI.1.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "S.OI.1");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Spese del personale");

   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Id, "S.OI.2");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).ParentId, "S.OI");







   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Retribuzioni personale (nette)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.2.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.2");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "IRPEF + Addiz. Regionale, Comunale");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "S.OI.2.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "S.OI.2");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Contributi previdenziali / INPS-INAIL");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "S.OI.2.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "S.OI.2");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Irap-Ires-Ici");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "S.OI.2.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "S.OI.2");




   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Description, "Collaboratori-Professionisti(netto)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Id, "S.OI.2.e");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).ParentId, "S.OI.2");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Description, "Ritenute d'acconto");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Id, "S.OI.2.f");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).ParentId, "S.OI.2");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Description, "Accantonamento TFR (se accantonato)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Id, "S.OI.2.g");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).ParentId, "S.OI.2");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Description, "Liquidazioni TRF erogate");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Id, "S.OI.2.h");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).ParentId, "S.OI.2");






   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributo struttura regionale");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Id, "S.OI.3");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).ParentId, "S.OI");





   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.3.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.3");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Quota impianti fissi");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "S.OI.3.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "S.OI.3");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Strutture zonali Feneal-UIL");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "S.OI.3.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "S.OI.3");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Strutture zonali CSP-UIL");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "S.OI.3.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "S.OI.3");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Tesseramento");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Id, "S.OI.4");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).ParentId, "S.OI");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Costo tessere");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.4.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.4");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Contributi straordinari");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Id, "S.OI.5");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).ParentId, "S.OI");


   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi straordinari");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.5.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.5");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[5]).Description, "Spese generali");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[5]).Id, "S.OI.6");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[5]).ParentId, "S.OI");

   //         subsubbil = subbil.SubList[5] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Postali - Telefoniche");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OI.6.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Utenze");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "S.OI.6.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "S.OI.6");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Manutenzioni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "S.OI.6.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Mobili e arredo");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "S.OI.6.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Description, "Fitto e condominio");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Id, "S.OI.6.e");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Description, "Cancelleria");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Id, "S.OI.6.f");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Description, "Informatica");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Id, "S.OI.6.g");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Description, "Polizze assicurative");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Id, "S.OI.6.h");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).ParentId, "S.OI.6");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[8]).Description, "Mutuo");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[8]).Id, "S.OI.6.i");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[8]).ParentId, "S.OI.6");


   //         //**********************************************************************************


   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Id, "S.OD");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).ParentId, "S");


   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Id, "S.OD.1");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).ParentId, "S.OD");



   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OD.1.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OD.1");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Id, "S.OD.2");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).ParentId, "S.OD");


   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Raccolte");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OD.2.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OD.2");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Id, "S.OD.3");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).ParentId, "S.OD");


   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Regime conv e accr.");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OD.3.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OD.3");

   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Id, "S.OD.4");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).ParentId, "S.OD");



   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OD.4.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OD.4");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre spese");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Id, "S.OD.5");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).ParentId, "S.OD");




   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Altro");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "S.OD.5.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "S.OD.5");


   //         bil = b.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "ENTRATE");
   //         Assert.AreEqual(bil.SubList.Count, 2);




   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Id, "E.OI");
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).ParentId, "E");


   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Id, "E.OD");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).ParentId, "E");

   //         subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Contributi territoriali");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Id, "E.OI.1");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).ParentId, "E.OI");





   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale CASSA EDILE");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OI.1.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OI.1");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Quote di adesione contrattuale EDILCASSA");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "E.OI.1.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "E.OI.1");

   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Quote di adesione contrattuale ALTRE CASSE");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "E.OI.1.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "E.OI.1");

   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Deleghe edili");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "E.OI.1.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "E.OI.1");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Description, "Deleghe impianti fissi");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Id, "E.OI.1.e");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).ParentId, "E.OI.1");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Description, "Deleghe sindacali(LSU,DS,mobilità)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Id, "E.OI.1.f");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).ParentId, "E.OI.1");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Tesseramento diretto");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Id, "E.OI.2");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).ParentId, "E.OI");



   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Tesseramento");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OI.2.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OI.2");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributi");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Id, "E.OI.3");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).ParentId, "E.OI");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi Feneal Nazionale");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OI.3.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OI.3");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Altri contributi");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "E.OI.3.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "E.OI.3");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Entrate varie");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Id, "E.OI.4");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).ParentId, "E.OI");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi su vertenze");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OI.4.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OI.4");



   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Interessi attivi");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Id, "E.OI.4.b");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).ParentId, "E.OI.4");

   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Gettoni presenza riversibili");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Id, "E.OI.4.c");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).ParentId, "E.OI.4");


   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Altre entrate");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Id, "E.OI.4.d");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).ParentId, "E.OI.4");






   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Id, "E.OD");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).ParentId, "E");



   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Id, "E.OD.1");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).ParentId, "E.OD");


   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OD.1.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OD.1");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Id, "E.OD.2");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).ParentId, "E.OD");


   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Raccolte");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OD.2.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OD.2");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Id, "E.OD.3");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).ParentId, "E.OD");



   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Regime conv e accr.");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OD.3.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OD.3");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Id, "E.OD.4");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).ParentId, "E.OD");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OD.4.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OD.4");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre entrate");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Id, "E.OD.5");
   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).ParentId, "E.OD");



   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Altro");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Id, "E.OD.5.a");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).ParentId, "E.OD.5");

   //     }



   //     private void CheckPreventivoProvinciale(Bilancio b)
   //     {


   //         AbstractBilancio bil = b.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "SPESE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");

   //         AbstractBilancio subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Spese politico organizzative");

   //         AbstractBilancio subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Attività organizzativa");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Informazione e propaganda");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Attività di sviluppo");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Attività di formazione");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Spese del personale");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Retribuzioni personale (nette)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "IRPEF + Addiz. Regionale, Comunale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Contributi previdenziali / INPS-INAIL");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Irap-Ires-Ici");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Collaboratori-Professionisti(netto)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Ritenute d'acconto");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[6]).Description, "Accantonamento TFR (se accantonato)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[7]).Description, "Liquidazioni TRF erogate");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributo struttura regionale");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Quota impianti fissi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Strutture zonali Feneal-UIL");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Strutture zonali CSP-UIL");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Tesseramento");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Costo tessere");






   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Contributi straordinari");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi straordinari");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[5]).Description, "Spese generali");


   //         subsubbil = subbil.SubList[5] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Postali - Telefoniche");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Utenze");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Manutenzioni");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Mobili e arredo");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Fitto e condominio");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Cancelleria");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[6]).Description, "Informatica");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[7]).Description, "Polizze assicurative");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[8]).Description, "Mutuo");


   //         //**********************************************************************************


   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Regime conv e accr.");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre spese");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Altro");



   //         bil = b.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "ENTRATE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");


   //         subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Contributi territoriali");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale CASSA EDILE");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Quote di adesione contrattuale EDILCASSA");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Quote di adesione contrattuale ALTRE CASSE");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Deleghe edili");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Deleghe impianti fissi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Deleghe sindacali(LSU,DS,mobilità)");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Tesseramento diretto");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Tesseramento");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributi");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi Feneal Nazionale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Altri contributi");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Entrate varie");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi su vertenze");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Interessi attivi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Gettoni presenza riversibili");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Altre entrate");







   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Regime conv e accr.");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre entrate");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Altro");

   //     }





   //     [Test]
   //     public void TestSerializzaizoneBilancioRegionale()
   //     {

   //         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\provareg.xml";

   //         Rendiconto f = RendicontoFactory.CreateRendiconto(false, "MATERA", 2010, "Basilicata");


   //         ObjectXMLSerializer<Rendiconto>.Save(f, path);



   //     }




   //     public void TestDeserializzaizoneBilancioRegionale()
   //     {

   //         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\provareg.xml";

   //         Rendiconto rend = ObjectXMLSerializer<Rendiconto>.Load(path);
   //         Assert.AreEqual(rend.Province, "MATERA");
   //         Assert.AreEqual(rend.Year, 2010);

   //         CheckBilancioProvinciale(rend.Bilancio);
   //         CheckPreventivoProvinciale(rend.Preventivo);

   //     }

   //     private void CheckBilancioRegionale(Bilancio b)
   //     {


   //         AbstractBilancio bil = b.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "SPESE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");

   //         AbstractBilancio subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Spese politico organizzative");

   //         AbstractBilancio subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Attività organizzativa");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Informazione e propaganda");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Attività di sviluppo");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Attività di formazione");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Spese del personale");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Retribuzioni personale (nette)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "IRPEF + Addiz. Regionale, Comunale");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Contributi previdenziali / INPS-INAIL");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Irap-Ires-Ici");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Description, "Collaboratori-Professionisti(netto)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Description, "Ritenute d'acconto");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Description, "Accantonamento TFR (se accantonato)");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Description, "Liquidazioni TRF erogate");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributi straordinari");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi straordinari");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Spese generali");


   //         subsubbil = subbil.SubList[5] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Postali - Telefoniche");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Utenze");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[2]).Description, "Manutenzioni");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[3]).Description, "Mobili e arredo");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[4]).Description, "Fitto e condominio");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[5]).Description, "Cancelleria");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[6]).Description, "Informatica");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[7]).Description, "Polizze assicurative");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[8]).Description, "Mutuo");


   //         //**********************************************************************************


   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Regime conv e accr.");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre spese");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Altro");



   //         bil = b.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "ENTRATE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");


   //         subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Contributi provinciali");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Quote impianti fissi");
          




   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Contributi Feneal nazionale");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi");
   //         Assert.AreEqual(((Conto)subsubbil.SubList[1]).Description, "Altri contributi");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributi straordinari");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Contributi");
  






   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Interessi attivi bancari e/o postali");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Interessi attivi");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre entrate");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Gettoni presenza riversibili");








   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Regime conv e accr.");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre entrate");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((Conto)subsubbil.SubList[0]).Description, "Altro");

   //     }



   //     private void CheckPreventivoRegionale(Bilancio b)
   //     {


   //         AbstractBilancio bil = b.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "SPESE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");

   //         AbstractBilancio subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Spese politico organizzative");

   //         AbstractBilancio subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Attività organizzativa");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Informazione e propaganda");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Attività di sviluppo");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Attività di formazione");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Spese del personale");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Retribuzioni personale (nette)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "IRPEF + Addiz. Regionale, Comunale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Contributi previdenziali / INPS-INAIL");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Irap-Ires-Ici");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Collaboratori-Professionisti(netto)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Ritenute d'acconto");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[6]).Description, "Accantonamento TFR (se accantonato)");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[7]).Description, "Liquidazioni TRF erogate");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributo struttura regionale");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Quota impianti fissi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Strutture zonali Feneal-UIL");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Strutture zonali CSP-UIL");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Tesseramento");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Costo tessere");






   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Contributi straordinari");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi straordinari");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[5]).Description, "Spese generali");


   //         subsubbil = subbil.SubList[5] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Postali - Telefoniche");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Utenze");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Manutenzioni");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Mobili e arredo");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Fitto e condominio");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Cancelleria");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[6]).Description, "Informatica");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[7]).Description, "Polizze assicurative");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[8]).Description, "Mutuo");


   //         //**********************************************************************************


   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Regime conv e accr.");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre spese");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Altro");



   //         bil = b.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(bil.Description, "ENTRATE");
   //         Assert.AreEqual(bil.SubList.Count, 2);
   //         Assert.AreEqual(((Classificazione)bil.SubList[0]).Description, "Operazioni istituzionali");
   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");


   //         subbil = bil.SubList[0] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "Contributi territoriali");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Quote di adesione contrattuale CASSA EDILE");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Quote di adesione contrattuale EDILCASSA");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Quote di adesione contrattuale ALTRE CASSE");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Deleghe edili");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[4]).Description, "Deleghe impianti fissi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[5]).Description, "Deleghe sindacali(LSU,DS,mobilità)");





   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Tesseramento diretto");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Tesseramento");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Contributi");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi Feneal Nazionale");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Altri contributi");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Entrate varie");

   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Contributi su vertenze");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[1]).Description, "Interessi attivi");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[2]).Description, "Gettoni presenza riversibili");
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[3]).Description, "Altre entrate");







   //         Assert.AreEqual(((Classificazione)bil.SubList[1]).Description, "Operazioni decommercializzate");

   //         subbil = bil.SubList[1] as AbstractBilancio;


   //         Assert.AreEqual(((Classificazione)subbil.SubList[0]).Description, "0rganizzazione viaggi e soggiorni turistici");

   //         subsubbil = subbil.SubList[0] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Viaggi e soggiorni");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[1]).Description, "Raccolte pubbliche fondi");

   //         subsubbil = subbil.SubList[1] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Raccolte");


   //         Assert.AreEqual(((Classificazione)subbil.SubList[2]).Description, "Regime di convenzione e di accreditamento");

   //         subsubbil = subbil.SubList[2] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Regime conv e accr.");



   //         Assert.AreEqual(((Classificazione)subbil.SubList[3]).Description, "Cessione di proprie pubblicazioni");


   //         subsubbil = subbil.SubList[3] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Cessione pubblicazioni");




   //         Assert.AreEqual(((Classificazione)subbil.SubList[4]).Description, "Altre entrate");

   //         subsubbil = subbil.SubList[4] as AbstractBilancio;
   //         Assert.AreEqual(((ContoPreventivo)subsubbil.SubList[0]).Description, "Altro");

   //     }

















   // }
}




