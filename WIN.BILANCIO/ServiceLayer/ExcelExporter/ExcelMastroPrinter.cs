using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using BilancioFenealgest.ServiceLayer.DTO;
using System.Net;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.IO;

namespace WIN.BILANCIO.ServiceLayer.ExcelExporter
{
  public class ExcelMastroPrinter
    {


        public delegate void RowExportEventHandler(object sender, RowExportedEventArgs fe);


        public event RowExportEventHandler ExportingRow;
        public event EventHandler BeginExport;
        public event EventHandler EndExport;

     
        private bool singleContoReport = false;
        private bool delegheConto = false;
        private bool personaleconto = false;

        private OfficeExcelHandler _handler;
        private bool cancel = false;
        private string _model = "";

        public ExcelMastroPrinter()
        {
            _handler = new OfficeExcelHandler();
            
          
        }

        private string CreteModelPath()
        {
            string model;

            if (singleContoReport)
            {
                if (delegheConto)
                    model = "\\Modelli\\ScrittureDeleghe.xlt";
                else if (personaleconto)
                    model = "\\Modelli\\ScritturePersonale.xlt";
                else
                     model = "\\Modelli\\Scritture.xlt";
            }
            else
                model = "\\Modelli\\ScrittureContiMultipli.xlt";

            string path = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(path);

            string dir = f.DirectoryName;

            return dir + model;

        }



        private string[] CreateHeaderArray(bool groupByConto) 
        {
            string[] arr;
            //if (groupByConto)
            //    arr = new string[] { "DATA OPERAZIONE", "IMPORTO", "TIPO OPERAZIONE", "PEZZA CONTABILE", "CAUSALE", "SCRITTURA PARTITA DOPPIA" };
            //else
            //    arr = new string[] { "DATA OPERAZIONE", "CONTO", "TIPO CONTO", "IMPORTO", "TIPO OPERAZIONE", "PEZZA CONTABILE", "CAUSALE", "SCRITTURA PARTITA DOPPIA" };

            if (singleContoReport)
            {
                arr = new string[] { "DATA", "CAUSALE", "NUM. PEZZA", "OPERAZIONE", "IMPORTO", "SALDO" };
                return arr;
            }

            if (groupByConto)
                arr = new string[] { "DATA", "CAUSALE", "NUM. PEZZA", "OPERAZIONE" , "IMPORTO"};
            else
            {
                arr = new string[] { "DATA", "CONTO", "CAUSALE", "NUM. PEZZA", "OPERAZIONE", "IMPORTO" };
            }



            return arr;
        }



     
        public void CloseExporter()
        {
            if (_handler != null)
                _handler.KillAllExcelProcesses();
        }
    

         public void SaveAs(string filename)
         {
             if (_handler != null)
                 if (_handler.CurrentWorkbook != null)
                 {
                     _handler.SaveAs(filename);
                     try
                     {
                         _handler.CloseWorkbook();
                     }
                     catch (Exception)
                     {


                     }
                 }
         }


         public void Export(IList<ScrittureDTO> list, bool groupByConto, decimal saldoConto)
         {
             //verifico se il report è relativo ad un solo conto
             CheckIfSingleContoReport(list);

             _model = CreteModelPath();


             //lancio l'evento dfi inizio esportazione
            BeginExport(this,new EventArgs ());

            if (cancel)
                return;

            //// //riscrivo i nomi della banca
            //foreach (ScrittureDTO item in list)
            //{
            //    if (item.ParentName == "Banca1" && titleBanca1 != "Banca1")
            //        item.ParentName = titleBanca1 + "(Banca1)";
            //    if (item.ParentName == "Banca2" && titleBanca2 != "Banca2")
            //        item.ParentName = titleBanca2 + "(Banca2)";
            //    if (item.TipoOperazione == "Banca1" && titleBanca1 != "Banca1")
            //        item.TipoOperazione = titleBanca1 + "(Banca1)";
            //    if (item.TipoOperazione == "Banca2" && titleBanca2 != "Banca2")
            //        item.TipoOperazione = titleBanca2 + "(Banca2)";
            //}

            WriteWorkersWorkbook(1, "Libro giornale", list, groupByConto, saldoConto);

             //lancio l'evento di fine export lavoratori
            EndExport(this, new EventArgs());


           

         }

         private void CheckIfSingleContoReport(IList<ScrittureDTO> list)
         {
             List<string> conti = CreaListaConti(list);
             if (conti.Count == 1)
             {
                 singleContoReport = true;
                 if (conti[0] == "Deleghe edili" || conti[0] == "Deleghe impianti fissi" || conti[0] == "Tesseramento diretto")
                     delegheConto = true;
                 else if (conti[0] == "Retribuzioni personale (nette)"
                     ||
                    conti[0] == "Retribuzioni lorde")
                     personaleconto = true;
             }
         }


         private void WriteWorkersWorkbook(int workBookindex, string workBookName, IList<ScrittureDTO> dtos, bool groupByConto, decimal saldoConto)
        {

            if (dtos.Count == 0 )
                return;

            if (string.IsNullOrEmpty(workBookName))
                workBookName = "Export " + workBookindex.ToString ();

            if (workBookName.Length >20)
                workBookName = workBookName.Substring(0,19);


            try
            {
                if (_handler.ExcelInstance == null)
                //'creo una nuova istanza di excel
                    _handler.OpenExcelApplication(true);

              

                if (_handler.CurrentWorkbook == null)
                //'Aggiungo un nuovo documento ad excel 
                    if (groupByConto)
                        _handler.AddDocumentToExcel("");
                    else
                        _handler.AddDocumentToExcel(_model);
            
                _handler.DefineDefaultStyles();
                //'lo attivo
                _handler.ActivateWorkBook();

               

                //'seleziono lo sheet di interesse
                _handler.SelectSheetByIndex(workBookindex);
                _handler.SetCurrentSheetName ( workBookName);


                if (!groupByConto)
                    ExecuteSimpleExport(dtos, saldoConto);
                else
                    ExecuteComplexExport(dtos, saldoConto);

            }
            catch (Exception)
            {
                _handler.Dispose();
                throw;
            }
        }

         private void ExecuteComplexExport(IList<ScrittureDTO> dtos, decimal saldoConto)
         {
             //devo recuperare una lista di tutti i conti presenti
             List<string> conti = CreaListaConti(dtos);

             if (conti.Count == 0)
                 return;
             //una volta ottenuta la lista dei conti posso esportare ciclando su tutti
             //i conti 

             //inizializzo la riga iniziale
             int row = 1;

             //'Creo le intestazioni
             string[] intestazioneArr = CreateHeaderArray(true);

             //se è un report a singolo conto aggiungo l'intestazione del conto
             //if (singleContoReport)
             //{
             //    AddRigaNomeConto(dtos[0], ref row);
             //}
             //'Inserisco l'intestazione
             _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, "intestazione",0);


            

             foreach (string item in conti)
             {
                 IList<ScrittureDTO> lista = CreaListaPerConto(item, dtos);
                 InsertData(lista, ref row, true, saldoConto);
             }
         }

         private IList<ScrittureDTO> CreaListaPerConto(string conto, IList<ScrittureDTO> dtos)
         {
             List<ScrittureDTO> lista = new List<ScrittureDTO>();

             foreach (ScrittureDTO item in dtos)
             {
                 if (item.ParentName.Equals(conto))
                     lista.Add(item);
             }

             lista.Sort(ScrittureDTO.CompareByDate);

             return lista;
         }

        



         private List<string> CreaListaConti(IList<ScrittureDTO> dtos)
         {
             Hashtable t = new Hashtable();

             List<string> conti = new List<string>();

             foreach (ScrittureDTO item in dtos)
             {
                 if (!t.ContainsKey(item.ParentName))
                 {
                     t.Add(item.ParentName,"");
                     conti.Add(item.ParentName);
                 }  
             }
             
             return conti;
         }

         private void ExecuteSimpleExport(IList<ScrittureDTO> dtos, decimal saldoConto)
         {
             int row = 1;
             if (singleContoReport)
             {
                 row = 2;
             }
           

             ////'Creo le intestazioni
             //string[] intestazioneArr = CreateHeaderArray(false);


             //se è un report a singolo conto aggiungo l'intestazione del conto
             if (singleContoReport)
             {
                 AddRigaNomeConto(dtos[0], ref row, saldoConto);
             }

             //'Inserisco l'intestazione
         //   _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, "intestazione",0);


             InsertData(dtos, ref row, false, saldoConto);
         }

         private void InsertData(IList<ScrittureDTO> dtos, ref int row, bool groupByConto, decimal saldoConto)
         {
             if (dtos.Count == 0)
                 return;

             //adesso ciclo su tutte le righe
             row++;
             if (groupByConto )
             {
                 AddRigaNomeConto(dtos[0], ref row, saldoConto);
             }

             InsertRemainingRows(dtos, ref row, groupByConto, saldoConto);
         }

         private void AddRigaNomeConto(ScrittureDTO scrittura, ref int row, decimal saldoConto)
         {
             //Object[] values = new Object[2];

             //values[0] = "";
             //if (!singleContoReport)
             //    values[1] = scrittura.ParentName;
             //else
             //   values[1] =   scrittura.ParentName + " (Saldo iniziale: )" + saldoConto.ToString("c");


             Object[] values = new Object[1];


             if (!singleContoReport)
                 values[0] = scrittura.ParentName;
             else
                 values[0] = scrittura.ParentName + " (Saldo iniziale: " + saldoConto.ToString("c") + ")";



             //if (scrittura.ParentId.StartsWith("E"))
             //    values[2] = "Conto ricavo";
             //else if (scrittura.ParentId.StartsWith("S"))
             //    values[2] = "Conto spesa";
             //else
             //    values[2] = "Conto finanziario";

             row++;
             _handler.FillExcelRow(_handler.CurrentSheet, row, values, 2);
             row++;
             if (singleContoReport)
                 row++;
             
         }

         private void InsertRemainingRows(IList<ScrittureDTO> dtos, ref int row, bool groupByConto,decimal saldoConto)
         {

             if (singleContoReport)
                 CalculateSaldi(dtos, saldoConto);

             foreach (ScrittureDTO item in dtos)
             {
                 //bool continua = true;

                 if (singleContoReport)
                     if (groupByConto)
                        FillRow(item, row, groupByConto,0 );
                     else
                         FillRow(item, row, groupByConto, 1);
                 else
                     FillRow(item, row, groupByConto, 0);
                 //incremento la rownumber
                 row++;

                 //inizializzo l'eventarg
                 RowExportedEventArgs a = new RowExportedEventArgs(Convert.ToInt32((100 * (row - 2) / dtos.Count)), cancel);
                 //lancio l'evento
                 ExportingRow(this, a);


             }
           
         }

         private void CalculateSaldi(IList<ScrittureDTO> dtos, decimal saldoConto)
         {
             decimal saldo = saldoConto;

             foreach (ScrittureDTO item in dtos)
             {
                 saldo = saldo + item.Importo;
                 item.Saldo = saldo;
             }

         }


         private void FillRow(ScrittureDTO item, int row, bool groupByConto, int offset)
        {
             Object[] values;

             values = CreateArrayData(item, groupByConto);

            _handler.FillExcelRow(_handler.CurrentSheet, row, values,offset);
        }

        private object[] CreateArrayData(ScrittureDTO item,bool groupByConto)
        {
            if (singleContoReport)
            {

                if (delegheConto)
                {

                    Object[] values = new Object[8];

                    values[0] = "'" + item.Date.ToShortDateString();
                    values[1] = item.Causale;
                    values[2] = item.Riferimento1; //settore
                    values[3] = item.Riferimento2; //ente
                    values[4] = item.NumeroPezza;
                    //values[3] = item.TipoOperazione;
                    values[5] = item.Contropartita;
                    values[6] = item.Importo.ToString("c");
                    values[7] = item.Saldo.ToString("c"); ;

                    return values;
                }
                else if (personaleconto)
                {
                    Object[] values = new Object[7];

                    values[0] = "'" + item.Date.ToShortDateString();
                    values[1] = item.Causale;
                    values[2] = item.Riferimento3; //settore
                    values[3] = item.NumeroPezza;
                    //values[3] = item.TipoOperazione;
                    values[4] = item.Contropartita;
                    values[5] = item.Importo.ToString("c");
                    values[6] = item.Saldo.ToString("c"); ;
                    return values;
                }
                else
                {
                    Object[] values = new Object[7];

                    values[0] = "'" + item.Date.ToShortDateString();
                    values[1] = item.Causale;
                    values[2] = item.NumeroPezza;
                    //values[3] = item.TipoOperazione;
                    values[3] = item.Contropartita;
                    if (item.Importo > 0)
                    {
                        values[4] = item.Importo.ToString("c");
                        values[5] = "";
                    }
                    else
                    {
                        values[5] = item.Importo.ToString("c");
                        values[4] = "";
                    }
                    
                    values[6] = item.Saldo.ToString("c"); ;
                    return values;
                }
            }
            
            if (!groupByConto)
            {
               
                
                    Object[] values = new Object[6];

                    values[0] = "'" + item.Date.ToShortDateString();
                    values[1] = item.ParentName;
                    values[2] = item.Causale;
                    values[3] = item.NumeroPezza;
                   // values[4] = item.TipoOperazione;
                    values[4] = item.Contropartita;
                    values[5] = item.Importo.ToString("c");

                    return values;
                

            }
            else
            {
                
                Object[] values = new Object[5];

                values[0] = "'" + item.Date.ToShortDateString();
                values[1] = item.Causale;
                values[2] = item.NumeroPezza;
                //values[3] = item.TipoOperazione;
                values[3] = item.Contropartita;
                values[4] = item.Importo.ToString("c");



                return values;
            }
        }



         public class RowExportedEventArgs : EventArgs
        {
            public RowExportedEventArgs(int rowPercentage,  bool cancel)
            {
                this.Cancel = cancel ;
                this.RowPercentage = rowPercentage ;
            }

           
            public bool Cancel;
            public int RowPercentage;

        }

    }




}


