using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using System.Collections;
using System.Reflection;
using System.IO;
using BilancioFenealgest.DomainLayer;
using WIN.BILANCIO.ServiceLayer.ExcelExporter;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.ServiceLayer.ExcelExporter
{
    public class Exporter
    {
        private StampaExcelSettings _settings = new StampaExcelSettings ();

        public void SetStatoPatrimonialeSettings(StampaExcelSettings settings)
        {
            _settings = settings ;
        }

        public event EventHandler BeginExportBilancio;
      

        public event EventHandler BeginExportPreventivo;
    

        public event EventHandler BeginExportStatoPatrimoniale;
  


        private OfficeExcelHandler _handler;
        string _model;

        public Exporter(string model)
        {
            _handler = new OfficeExcelHandler();


            _model = CreteModelPath(model);
        }

        private string CreteModelPath(string model)
        {
            model = "\\Modelli\\" + model;

            string path = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(path);

            string dir = f.DirectoryName;

            return dir +  model;

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

        public void Export(BilancioFenealgest.DomainLayer.Rendiconto current,ExcelSearchCriteria criteria)
        {
            DTORendiconto r = null;

            if (_settings.DateToExport != null && _settings.DateToExport > DateTime.MinValue)
                r = current.CreateDtoRendicontoWithSaldiInizialiBancaAtDate(_settings.DateToExport);
            else
                r = current.CreateDtoRendicontoWithSaldiInizialiBanca();

            //lancio l'evento dfi inizio esportazione
            BeginExportBilancio(this, new EventArgs());

            ScriviBilancio(1, r, criteria);

            //////WriteWorkersWorkbook(1, "Lavoratori", list);


            if (_settings.StampaPreventivo)
            {
                //lancio l'evento dfi inizio esportazione
                BeginExportPreventivo(this, new EventArgs());

                ScriviBilancio(2, r, criteria);
            }


            if (_settings.StampaStatoPatrimoniale)
            {
                //lancio l'evento dfi inizio esportazione
                BeginExportStatoPatrimoniale(this, new EventArgs());



                ScriviStatoPatrimoniale(3, current.StatoPatrimoniale, r);

            }
        
          
        }



        private void ScriviBilancio(int workBookindex, DTORendiconto r,ExcelSearchCriteria criteria)
        {
            try
            {
                if (_handler.ExcelInstance == null)
                {    //'creo una nuova istanza di excel
                    _handler.OpenExcelApplication(true);

                }



                if (_handler.CurrentWorkbook == null)
                //'Aggiungo un nuovo documento ad excel 
                {
                    _handler.AddDocumentToExcel(_model);
                    //'lo attivo
                    _handler.ActivateWorkBook();
                    
                }

                //'seleziono lo sheet di interesse
                _handler.SelectSheetByIndex(workBookindex);

                _handler.FindReplaceCellValue(3, 26, "#prop#", r.Proprietario, true, OfficeExcelHandler.FindMode.Table);
                _handler.FindReplaceCellValue(54, 26, "#prop#", r.Proprietario, true, OfficeExcelHandler.FindMode.LockRow);

                if (workBookindex == 2)
                {
                    _handler.FindReplaceCellValue(3, 26, "#anno#", (r.Anno+1).ToString(), true, OfficeExcelHandler.FindMode.Table);
                    _handler.FindReplaceCellValue(54, 26, "#anno#", (r.Anno + 1).ToString(), true, OfficeExcelHandler.FindMode.LockRow );

                }
                else
                {
                    _handler.FindReplaceCellValue(3, 26, "#anno#", r.Anno.ToString(), true, OfficeExcelHandler.FindMode.Table);
                    _handler.FindReplaceCellValue(54, 26, "#anno#", r.Anno.ToString(), true, OfficeExcelHandler.FindMode.LockRow);

                }
                

                foreach (DTORendicontoItem  item in r.Items )
                {
                    if (item.IdNodo != "")
                    {
                        if (workBookindex == 1)
                        {
                           // if (item.IdNodo.StartsWith("E") || item.IdNodo.StartsWith("P") || item.IdNodo.StartsWith("A"))
                                _handler.FindReplaceCellValue(criteria.MaxRowPrimaColonna , criteria.MaxColPrimaColonna , "#" + item.IdNodo + "#", item.ImportoBilancio.ToString("c"), false, criteria.FindMode );
                           // else
                                _handler.FindReplaceCellValue(criteria.MaxRowSecondaColonna, criteria.MaxColSecondaColonna, "#" + item.IdNodo + "#", item.ImportoBilancio.ToString("c"), false, criteria.FindMode );
                        }
                        else
                        {
                           // if (item.IdNodo.StartsWith("E") || item.IdNodo.StartsWith("P") || item.IdNodo.StartsWith("A"))
                                _handler.FindReplaceCellValue(criteria.MaxRowPrimaColonna, criteria.MaxColPrimaColonna, "#" + item.IdNodo + "#", item.ImportoPreventivo.ToString("c"), false, criteria.FindMode);
                          //  else
                                _handler.FindReplaceCellValue(criteria.MaxRowSecondaColonna, criteria.MaxColSecondaColonna, "#" + item.IdNodo + "#", item.ImportoPreventivo.ToString("c"), false, criteria.FindMode);
                        }
                    }
                }
               
                //_handler.FindReplaceCellValue(10, 3, "Quote", "Pubblicità", false);

                //_handler.FillExcelCell(c.Row, c.Column, h);


            }
            catch (Exception)
            {
                _handler.Dispose();
                throw;
            } 

        }


        private void ScriviStatoPatrimoniale(int workBookindex, StatoPatrimoniale r, DTORendiconto rendiconto)
        {

            try
            {
                if (_handler.ExcelInstance == null)
                {    //'creo una nuova istanza di excel
                    _handler.OpenExcelApplication(true);

                }


                if (_handler.CurrentWorkbook == null)
                //'Aggiungo un nuovo documento ad excel 
                {
                    _handler.AddDocumentToExcel(_model);
                    //'lo attivo
                    _handler.ActivateWorkBook();

                }

                //'seleziono lo sheet di interesse
                _handler.SelectSheetByIndex(workBookindex);



                _handler.FindReplaceCellValue(10, 10, "#prop#", rendiconto.Proprietario, false, OfficeExcelHandler.FindMode.Table);
                _handler.FindReplaceCellValue(10, 10, "#anno#", rendiconto.Anno.ToString(), false, OfficeExcelHandler.FindMode.Table);


                if (_settings.InventarioDisegnaOrizzontalmente)
                {
                    int currentRow = 1 + _settings.InventarioRigaIniziale;
                    int currentCol = 1;

                    WriteBeniImmobiliOrizzontalmente(r.Immobili, ref currentRow, ref currentCol);
                    WriteDepositiOrizzontalmente(r.Depositi, ref currentRow, ref currentCol);
                    WritePolizzeOrizzontalmente(r.Polizze, ref currentRow, ref currentCol);
                    WriteAutoOrizzontalmente(r.Autos, ref currentRow, ref currentCol);

                    WriteMobiliOrizzontalmente(r.Mobili, ref currentRow, ref currentCol);
                    WriteAccantonamentiTFROrizzontalmente(r.AccantonamentiTFR, ref currentRow, ref currentCol);
                    WriteChiusureOrizzontalmente(r.Chiusure, ref currentRow, ref currentCol);
                }
                else
                {
                    int currentRow = 1 + _settings.InventarioRigaIniziale;
                    int currentCol = 1 + _settings.InventarioColonnaIniziale;

                    WriteBeniImmobiliVerticalmente(r.Immobili, ref currentRow,  currentCol);
                    WriteDepositiVerticalmente(r.Depositi, ref currentRow,  currentCol);
                    WritePolizzeVerticalmente(r.Polizze, ref currentRow,  currentCol);
                    WriteAutoVerticalmente(r.Autos, ref currentRow,  currentCol);

                    WriteMobiliVerticalmente(r.Mobili, ref currentRow,  currentCol);
                    WriteAccantonamentiTFRVerticalmente(r.AccantonamentiTFR, ref currentRow,  currentCol);
                    WriteChiusureVerticalmente(r.Chiusure, ref currentRow,  currentCol);
                }

            }
            catch (Exception)
            {
                _handler.Dispose();
                throw;
            }
           
        }

        private void WriteAutoVerticalmente(IList iList, ref int currentRow,  int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Auto" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateAutoHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateAutoHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;
                return;
            }

            //adesso ciclo

            foreach (Auto item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.TipoMezzo, item.Intestazione }, currentRow);
                currentCol++;
            }

            currentRow = currentRow + CreateAutoHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;

        }

        private void WritePolizzeVerticalmente(IList iList, ref int currentRow,  int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Polizze" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreatePolizzeHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreatePolizzeHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;
                return;
            }

            //adesso ciclo

            foreach (Polizza item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.DenominazioneCompagnia, item.Tipo, item.NumeroPolizza, item.DenominazioneSocieta }, currentRow);
                currentCol++;
            }

            currentRow = currentRow + CreatePolizzeHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;

        }

        private void WriteDepositiVerticalmente(IList iList, ref int currentRow,  int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Depositi" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateDepositiHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateDepositiHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;
                return;
            }

            //adesso ciclo

            foreach (Deposito item in iList)
            {
                string firmaAm = "No";
                string firmaResp = "No";
                if (item.IsFirmaAmministrativoDepositata)
                    firmaAm = "Si";
                if (item.IsFirmaResponsabileDepositata)
                    firmaResp = "Si";
                if (_settings.InventarioFeneal)
                    _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Denominazione, item.ContoCorrente, item.IntestazioneConto, item.Tipo, firmaAm, firmaResp }, currentRow);
                else
                    _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Denominazione, item.ContoCorrente, item.IntestazioneConto, item.Tipo }, currentRow);

                currentCol++;
            }

            currentRow = currentRow + CreateDepositiHeaderArray().Length + _settings.InventarioRigheFraTipiInventario ;

        }

        private void WriteBeniImmobiliVerticalmente(IList iList, ref int currentRow,  int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Immobili" }, _settings.InventarioRigaIniziale);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateImmobiliHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, _settings.InventarioRigaIniziale);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateImmobiliHeaderArray().Length  +  _settings.InventarioRigheFraTipiInventario -1;
                return;
            }

            //adesso ciclo

            foreach (Immobile item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Ubicazione, item.Via, item.NumCivico, item.PartitaCatastale, item.DataAcquisto.ToShortDateString(), item.IntestazioneProprieta, item.UtilizzataDa }, _settings.InventarioRigaIniziale);
                currentCol++;
            }

            currentRow = currentRow + CreateImmobiliHeaderArray().Length + _settings.InventarioRigheFraTipiInventario - 1;
        }

        private string[] CreateMobiliHeaderArray()
        {
            return new string[] { "Numero", "Descrizione" };
        }
        private string[] CreateAccantonamentiTFRHeaderArray()
        {
            return new string[] { "Anno", "Importo", "Note" };
        }
        private string[] CreateChiusureHeaderArray()
        {
            return new string[] { "Anno", "Avanzo", "Disavanzo" };
        }


        private string[] CreateAutoHeaderArray()
        {
            return new string[] { "Tipo mezzo", "Intestazione veicolo" };
        }

        private string[] CreatePolizzeHeaderArray()
        {
            return new string[] { "Denominazione compagnia", "Tipo", "Num. polizza", "Denominazione società" };
        }

        private string[] CreateDepositiHeaderArray()
        {
            if (_settings.InventarioFeneal)
                return new string[] { "Banca/Società di gestione", "Numero conto corrente", "Intestazione conto", "Tipo conto", "Firma amministrativo", "Firma responsabile" };
            else
                return new string[] { "Banca/Società di gestione", "Numero conto corrente", "Intestazione conto", "Tipo conto" };
        }

        private string[] CreateImmobiliHeaderArray()
        {
            return new string[] { "Ubicazione", "Via", "Num. civico", "Partita catastale", "Data acquisto", "Intestazione", "Utilizzata da" };
        }

        private void WriteAutoOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Automobili" }, _settings.InventarioColonnaIniziale);
                row++;
            }

            if (_settings.InventarioScriviIntestazioniTipoInventario )
            {
                string[] intestazioneArr =  CreateAutoHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr,_settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo
           
            foreach (Auto item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.TipoMezzo, item.Intestazione }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;


        }


        private void WriteMobiliOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Beni mobili" }, _settings.InventarioColonnaIniziale);
                row++;
            }

            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateMobiliHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Mobile item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Numero, item.Descrizione }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;


        }

        private void WriteMobiliVerticalmente(IList iList, ref int currentRow, int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Beni mobili" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateMobiliHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateMobiliHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Mobile item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Numero, item.Descrizione }, currentRow);
                currentCol++;
            }

            currentRow = currentRow + CreateMobiliHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;

        }



        private void WritePolizzeOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Polizze" }, _settings.InventarioColonnaIniziale);
                row++;
            }

            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreatePolizzeHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Polizza item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.DenominazioneCompagnia, item.Tipo, item.NumeroPolizza, item.DenominazioneSocieta }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;

        }

        private void WriteDepositiOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Depositi" }, _settings.InventarioColonnaIniziale);
                row++;
            }




            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateDepositiHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Deposito item in iList)
            {
                string firmaAm = "No";
                string firmaResp = "No";
                if (item.IsFirmaAmministrativoDepositata )
                    firmaAm = "Si";
                if (item.IsFirmaResponsabileDepositata  )
                    firmaResp = "Si";
                if (_settings.InventarioFeneal )
                    _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Denominazione, item.ContoCorrente, item.IntestazioneConto, item.Tipo, firmaAm, firmaResp }, _settings.InventarioColonnaIniziale);
                else
                    _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Denominazione, item.ContoCorrente, item.IntestazioneConto, item.Tipo }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;
        }

        private void WriteBeniImmobiliOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Immobili" }, _settings.InventarioColonnaIniziale);
                row++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateImmobiliHeaderArray ();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Immobile item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Ubicazione, item.Via, item.NumCivico, item.PartitaCatastale, item.DataAcquisto.ToShortDateString(), item.IntestazioneProprieta, item.UtilizzataDa }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;
        }













        private void WriteAccantonamentiTFROrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Accantonamenti TFR" }, _settings.InventarioColonnaIniziale);
                row++;
            }

            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateAccantonamentiTFRHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (AccantonamentoTFR item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Anno, item.Importo, item.Note }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;


        }

        private void WriteAccantonamentiTFRVerticalmente(IList iList, ref int currentRow, int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Accantonamenti TFR" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateAccantonamentiTFRHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateAccantonamentiTFRHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (AccantonamentoTFR item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Anno, item.Importo, item.Note }, currentRow);
                currentCol++;
            }

            currentRow = currentRow + CreateAccantonamentiTFRHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;

        }



        private void WriteChiusureOrizzontalmente(IList iList, ref int row, ref int col)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { "Avanzo / disavanzo" }, _settings.InventarioColonnaIniziale);
                row++;
            }

            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateChiusureHeaderArray();
                //riempio la prima riga
                _handler.FillExcelRow(_handler.CurrentSheet, row, intestazioneArr, _settings.InventarioColonnaIniziale);
                row++;
            }


            if (iList.Count == 0)
            {
                row = row + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Chiusura item in iList)
            {
                _handler.FillExcelRow(_handler.CurrentSheet, row, new string[] { item.Anno, item.Avanzo, item.Disavanzo }, _settings.InventarioColonnaIniziale);
                row++;
            }

            row = row + _settings.InventarioRigheFraTipiInventario;


        }

        private void WriteChiusureVerticalmente(IList iList, ref int currentRow, int currentCol)
        {
            if (_settings.InventarioScriviTipoInventario)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { "Avanzo / disavanzo" }, currentRow);
                currentCol++;
            }



            if (_settings.InventarioScriviIntestazioniTipoInventario)
            {
                string[] intestazioneArr = CreateChiusureHeaderArray();
                //riempio la prima riga
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, intestazioneArr, currentRow);
                currentCol++;
            }


            if (iList.Count == 0)
            {
                currentRow = currentRow + CreateChiusureHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;
                return;
            }

            //adesso ciclo

            foreach (Chiusura item in iList)
            {
                _handler.FillExcelColumn(_handler.CurrentSheet, currentCol, new string[] { item.Anno, item.Avanzo, item.Disavanzo }, currentRow);
                currentCol++;
            }

            currentRow = currentRow + CreateChiusureHeaderArray().Length + _settings.InventarioRigheFraTipiInventario;

        }



       
    }
}
