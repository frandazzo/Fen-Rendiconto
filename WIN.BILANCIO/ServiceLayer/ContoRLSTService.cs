using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.ServiceLayer.DTO;
using TestBinding;
using System.Collections;
using BilancioFenealgest.ServiceLayer;
using WIN.BILANCIO.ServiceLayer.ExcelExporter;
using System.IO;
using System.Diagnostics;

namespace WIN.BILANCIO.ServiceLayer
{
    public class ContoRLSTService
    {
           Conto _conto;
           public event EventHandler BeginExport;
           public event EventHandler EndExport;
           public event ExcelMastroPrinter.RowExportEventHandler ExportedRow;


           public virtual void RaiseExportedRow(int rowPercentage, bool cancel)
           {
               if (ExportedRow != null)
                   ExportedRow(this, new WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportedEventArgs(rowPercentage, cancel));
           }


           public virtual void RaiseEndExport()
           {
               if (EndExport != null)
                   EndExport(this, new EventArgs());
           }





           public virtual void RaiseBeginExport()
           {
               if (BeginExport != null)
                   BeginExport(this, new EventArgs());
           }
       


           public ContoRLSTService(Conto conto)
        {
            _conto = conto;

        }


        public event EventHandler Change;



        protected virtual void RaiseChangeEvent()
        {
            // Raise the event by using the () operator.
            if (Change != null)
                Change(this, new EventArgs());
        }


        public Conto ContoRLST
        {
            get { return _conto; }
        }

        public string Total
        {

            get
            {
                return _conto.GetTotal.ToString("c");
            }
        }





        public void AddScrittura(ScrittureDTO scrittura)
        {

           

            Scrittura s = new Scrittura(_conto.Id);
            s.TipoOperazione = TipoOperazione.Banca1;
            s.Importo = Convert.ToDouble(scrittura.Importo);
            s.Causale = scrittura.Causale;
            s.Date = scrittura.Date.Date;
            s.NumeroPezza = scrittura.NumeroPezza;
            s.ParentName = _conto.Description;

           
            _conto.Add(s, null, false);

            scrittura.ParentId = _conto.Id;
            scrittura.ParentName = _conto.Description;
            scrittura.Id = s.Id;

            RaiseChangeEvent();
        }


        public void RemoveScrittura(ScrittureDTO scrittura)
        {
      
            Scrittura s = _conto.FindNodeById(scrittura.Id) as Scrittura;

            if (s == null)
                return;

            
            _conto.Remove(scrittura.Id, null);
          

            RaiseChangeEvent();

        }

        public void UpdateScrittura(ScrittureDTO scrittura)
        {
           
            Scrittura s = _conto.FindNodeById(scrittura.Id) as Scrittura;

            if (s == null)
                throw new InvalidOperationException("Tentativo di aggiornare una scrittura non presente nel conto");




          
            //a questo punto rimuovo la scrittura precedente
            RemoveScrittura(scrittura);



            //eaggiungo la nuova scrittura
            Scrittura s1 = new Scrittura();
            s1.TipoOperazione = TipoOperazione.Banca1;
            s1.Importo = Convert.ToDouble(scrittura.Importo);
            s1.Causale = scrittura.Causale;
            s1.Date = scrittura.Date.Date;
            s1.NumeroPezza = scrittura.NumeroPezza;
            s1.Id = scrittura.Id;
            s1.ParentName = _conto.Description;
          
             _conto.Add(s1, null, false);
         

            scrittura.ParentName = _conto.Description;





            RaiseChangeEvent();
        }


        public SortableBindingList<ScrittureDTO> SearchScrittureBilancio(ScrittureSearchCriteria criteria)
        {
           

            AbstractBilancio b = _conto ;

         


            IList list = b.SearchScritture(criteria);

            return ScrittureConverter.ConvertScritture(list);

        }


        public void ExportLibroGiornale(IList<ScrittureDTO> scritture, string fileName)
        {
            ExcelMastroPrinter exp = new ExcelMastroPrinter();
            exp.BeginExport += new EventHandler(exp1_BeginExport);
            exp.EndExport += new EventHandler(exp1_EndExport);
            exp.ExportingRow += new ExcelMastroPrinter.RowExportEventHandler(exp1_ExportingRow);

            exp.Export(scritture, false, 0);

            exp.SaveAs(fileName);

            exp.CloseExporter();

            //'se ho salvato il file lo apro
            if (File.Exists(fileName))
                Process.Start(fileName);
        }

        void exp1_ExportingRow(object sender, ExcelMastroPrinter.RowExportedEventArgs fe)
        {
            RaiseExportedRow(fe.RowPercentage, false);
        }

        void exp1_EndExport(object sender, EventArgs e)
        {
            RaiseEndExport();
        }

        void exp1_BeginExport(object sender, EventArgs e)
        {
            RaiseBeginExport();

        }

        public IList<ScrittureDTO> SearchScrittureGiornale(ScrittureSearchCriteria criteria)
        {
            if (_conto == null)
                return null;


            IList list = _conto.SearchScritture(criteria);

            List<ScrittureDTO> l1 = new List<ScrittureDTO>();

            foreach (ScrittureDTO item in ScrittureConverter.ConvertScritture(list))
            {
                l1.Add(item);
            }

            l1.Sort(ScrittureDTO.CompareByDate);

            return l1;
        }
    }
}
