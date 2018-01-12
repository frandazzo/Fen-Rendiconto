using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DataAccess;
using BilancioFenealgest.DomainLayer;
using System.ComponentModel;
using BilancioFenealgest.ServiceLayer.DTO;
using System.IO;
using BilancioFenealgest.ServiceLayer.ExcelExporter;
using System.Collections;
using System.Diagnostics;
using WIN.BILANCIO.ServiceLayer;
using WIN.BILANCIO.ServiceLayer.ExcelExporter;
using WIN.BILANCIO.DataAccess;
using WIN.BILANCIO.DomainLayer;
using System.Reflection;

namespace BilancioFenealgest.ServiceLayer
{
    public class RendicontoService
    {

        public event EventHandler ScritturaBilancio;
        public event EventHandler ScritturaPreventivo;
        public event EventHandler ScritturaStatoPatrimoniale;
   

        private void RaiseScritturaBilancio(object sender, EventArgs e)
        {
            if (ScritturaBilancio != null)
                ScritturaBilancio(this, EventArgs.Empty);
        }

        private void RaiseScritturaPreventivo(object sender, EventArgs e)
        {
            if (ScritturaPreventivo != null)
                ScritturaPreventivo(this, EventArgs.Empty);
        }

        private void RaiseScritturaStatoPatrimoniale(object sender, EventArgs e)
        {
            if (ScritturaStatoPatrimoniale != null)
                ScritturaStatoPatrimoniale(this, EventArgs.Empty);
        }


        RendicontoMapper _mapper = new RendicontoMapper();
        Rendiconto _current;
        string _currentPath;
        BilancioService _bilancioService;
        PreventivoService _preventivoService;
        StatoPatrimonialeService _statoPatrimonialeService;
        ContoRLSTService _contoRLSTService;

        public event EventHandler Change;


        /// <summary>
        /// metodo per il caricamento del rendiconto
        /// </summary>
        /// <param name="path"></param>
        public void LoadRendiconto(string path)
        {
            _current = _mapper.LoadRendicontoByPath(path);
            _current.CheckMandatoryContosChangedByVersions();
            if (_current == null)
                throw new ArgumentException("Percorso di file non valido o file non leggibile");
            _currentPath = path;

            //Registro gli eneti per il bilancio ed il preventivo

            


        }



        public void SetSaldiInizialiStatoPatrimonialeFromPattern(string pattern)
        {
            try
            {
                //deserializzo il pattern
                //recupero tramite una split tutte le coppie idconto valore separete da una doppia @
                string[] data = pattern.Split(new string[] { "@@" }, StringSplitOptions.RemoveEmptyEntries);

                //adesso posso delegare al bilancio service l'impostazione dei dati per ogni conto
                foreach (string item in data)
                {
                    //splitto la coppia id - totale con una nuova split
                    string[] d = item.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    string idConto = d[0];
                    double value = Convert.ToDouble(d[1]);

                    BilancioService.SetSaldoConto(idConto, (decimal)value);

                }
               
            }
            catch (Exception)
            {
                
                //non fa nulla

            }
           

        }




        public string RetrievePatternSaldiFinaliStatoPatrimoniale()
        {
            //devo restituire un pattern id conto totale per ripristinare i saldi iniziali da un bilancio precedente

            //il pattaren deve essere:
            //@@id_conto#totale_conto@@

            IList result =  BilancioService.GetListaContiStatoPatrimoniale();

            string resultString = "";

            foreach (Conto item in result)
            {
                string data = string.Format("@@{0}#{1}", item.Id, item.GetTotal);

                resultString += data;
            }


            return resultString;

        }


        public ContoRLSTService ContoRLSTService
        {

            get
            {
                if (_contoRLSTService == null)
                {
                    _contoRLSTService = new ContoRLSTService(_current.ContoRLST);
                    _contoRLSTService.Change += new EventHandler(ChangeRendiconto_Change);
                }

                return _contoRLSTService;


            }
        }


        public StatoPatrimonialeService StatoPatrimonialeService
        {

            get
            {
                if (_statoPatrimonialeService == null)
                {
                    _statoPatrimonialeService = new StatoPatrimonialeService(_current.StatoPatrimoniale);
                    _statoPatrimonialeService.Change += new EventHandler(ChangeRendiconto_Change);
                }

                return _statoPatrimonialeService;


            }
        }


        public string CreateNewRendiconto(RendicontoHeaderDTO header)
        {

            //per prima cosa verifico la validità del percorso di directory fornito
            string path = header.FolderPath;

            if (!Directory.Exists(path))
                throw new ArgumentException("Il percorso specificato per il salvataggio non esiste!");


            //verifico l'estensione del file
            if (!header.FileName.Contains("."))
                header.FileName += ".xml";


            //verifico che il file non esista
            path = Path.Combine(path, header.FileName);

            if (File.Exists(path))
                throw new ArgumentException("Esiste già un file denominato: " + path + "!");

            //A questo punto posso creare il bilancio e salvarlo
            bool isProvinciale = !header.IsRegionale;

            Rendiconto r = RendicontoFactory.CreateRendiconto(isProvinciale, header.Provincia, header.Anno, header.Regione);
            r.Proprietario = header.Proprietario;
            r.SendableTag = header.SenderTag;
            _mapper.SaveRendiconto(r, path);


            return path;
        }

        //public string CreateNewRendiconto(RendicontoHeaderDTO header, string dir)
        //{
        //    if (string.IsNullOrEmpty(dir))
        //        return CreateNewRendiconto(header);
        //    //per prima cosa verifico la validità del percorso di directory fornito
        //    string path = dir;

        //    if (!Directory.Exists(path))
        //        throw new ArgumentException("Il percorso specificato per il salvataggio non esiste!");


        //    //verifico l'estensione del file
        //    if (!header.FileName.Contains("."))
        //        header.FileName += ".xml";


        //    //verifico che il file non esista
        //    path = Path.Combine(path, header.FileName);

        //    if (File.Exists(path))
        //        throw new ArgumentException("Esiste già un file denominato: " + path + "!");

        //    //A questo punto posso creare il bilancio e salvarlo
        //    bool isProvinciale = !header.IsRegionale;

        //    Rendiconto r = RendicontoFactory.CreateRendiconto(isProvinciale, header.Provincia, header.Anno, header.Regione);
        //    r.Proprietario = header.Proprietario;
        //    _mapper.SaveRendiconto(r, path);


        //    return path;
        //}




        public void UpdateRendicontoStructure()
        {

            string updateFile = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            FileInfo i = new FileInfo(updateFile);
            updateFile = i.DirectoryName;


            if (_current.SendableTag == "FENEAL")
            {
                if (_current.IsRegionale)
                    updateFile += @"\Updates\updatefenealregionale.xml";
                else
                    updateFile += @"\Updates\updatefenealprovinciale.xml";
            }
            else if (_current.SendableTag == "RLST")
            {
                updateFile += @"\Updates\updaterlst.xml";
            }
            else 
            {
                updateFile += @"\Updates\update.xml";
            }



            UpdateFileMapper m = new UpdateFileMapper();
            NodeUpdateList l = m.LoadUpdateFileByPath(updateFile);

            if (_current.UpdateStructure(l))
            {
                //Inoltro fgli eventi di notifica del cambiamento
                ChangeRendiconto_Change(this, EventArgs.Empty);

            }


        }

        public string CreateNewRendiconto(string template, string dir, string filename)
        {

            //creo il file sul desktop
            string path;

            if (string.IsNullOrEmpty(dir))
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            else
                path = dir;

            string file = filename;

            //verifico che il file non esista
            string location = Path.Combine(path, file);

            



            Rendiconto r = RendicontoFactory.CreateRendiconto(template);





            _mapper.SaveRendiconto(r, location);


            return location;
        }



        public string CreateNewRendiconto(string template , string dir)
        {

            //creo il file sul desktop
            string path ;

            if (string.IsNullOrEmpty(dir))
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            else
                path = dir;

            string file = "rendiconto.xml";

            //verifico che il file non esista
            string location = Path.Combine(path, file);

            int i = 1;
                
            while (File.Exists(location ))
	        {
                string newName = i.ToString() + "_" + file;
                location = Path.Combine(path, newName);
                i++;
	        }



            Rendiconto r = RendicontoFactory.CreateRendiconto(template);





            _mapper.SaveRendiconto(r, location);


            return location;
        }


        public string RendicontoSendableTag
        {
            get
            {
                if (_current == null)
                    return "";
                if (_current.SendableTag == null)
                    return "";
                return _current.SendableTag;
            }
            set
            {
                _current.SendableTag = value;
            }
        }



        /// <summary>
        /// Proprietà per il recupero della struttura del bilancio, del precentivo o latre proprietà da visualizzare
        /// </summary>
        public RendicontoHeaderDTO RendicontoHeader
        {
            get 
            {
                RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
                dto.Anno = _current.Year;
                dto.IsRegionale = _current.IsRegionale;
                dto.Provincia = _current.Province;
                dto.Regione = _current.Region;
                dto.Proprietario = _current.Proprietario;
                return dto;
            }
            set
            {
                _current.Proprietario = value.Proprietario;
                _current.Region = value.Regione;
                _current.Province = value.Provincia;
                _current.Year = value.Anno;
                ChangeRendiconto_Change(this, EventArgs.Empty);
            }        
        }


        public BilancioService BilancioService
        {
            get
            {
                if (_bilancioService == null)
                {
                    _bilancioService = new BilancioService(_current.Bilancio);
                    _bilancioService.Change += new EventHandler(ChangeRendiconto_Change);
                }
                return _bilancioService;
            }
        }

        void ChangeRendiconto_Change(object sender, EventArgs e)
        {
            if (Change != null)
                Change(this, new EventArgs());
        }


        public PreventivoService PreventivoService
        {
            get
            {
                if (_preventivoService == null)
                {
                    _preventivoService = new PreventivoService(_current.Preventivo);
                    _preventivoService.Change += new EventHandler(ChangeRendiconto_Change);
                }
                return _preventivoService;
            }
        }

        public void Save()
        {
            if (_current == null) return;

            _current.AllineaTotali();

            _mapper.SaveRendiconto(_current, _currentPath);

        }






        public  void ExportToExcel(string model,ExcelSearchCriteria criteria,StampaExcelSettings settings, string name)
        {
            Exporter ex = new Exporter(model);
            ex.SetStatoPatrimonialeSettings(settings);
            ex.BeginExportBilancio += new EventHandler(ex_BeginExportBilancio);
            ex.BeginExportPreventivo += new EventHandler(ex_BeginExportPreventivo);
            ex.BeginExportStatoPatrimoniale += new EventHandler(ex_BeginExportStatoPatrimoniale);
       

            ex.Export(_current, criteria);

            string file = name;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filename = Path.Combine(path, file + ".xls");

            int i = 0;
            while (System.IO.File.Exists(filename))
            {
                i++;
                filename = Path.Combine(path, file + i.ToString() + ".xls");
            } 



            //string path = Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory );
            //string file = Path.Combine(path,nomeFileDaSalvare);

            ex.SaveAs(filename);


            Process.Start(filename);
           
        }


        void ex_BeginExportStatoPatrimoniale(object sender, EventArgs e)
        {

            RaiseScritturaStatoPatrimoniale(sender, e);
        }

        void ex_BeginExportPreventivo(object sender, EventArgs e)
        {
            RaiseScritturaPreventivo(sender, e);
        }

        void ex_BeginExportBilancio(object sender, EventArgs e)
        {
            RaiseScritturaBilancio(sender, e);
        }

        public void SaveDtoRendiconto(string path)
        {
           DTORendicontoMappaer m = new DTORendicontoMappaer();

           m.SaveDTORendiconto(_current.CreateDtoRendiconto(), path);
        }

        internal void FillNomiBanca(ref string banca1, ref string banca2, ref string banca3, ref string banca4, ref string banca5, ref string banca6)
        {
            banca1 = _current.Banca1;
            banca2 = _current.Banca2;
            banca3 = _current.Banca3;

            banca4 = _current.Banca4;
            banca5 = _current.Banca5;
            banca6 = _current.Banca6;
        }

        internal void SetNomiBanca(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
             _current.Banca1 = banca1;
            _current.Banca2 = banca2;
            _current.Banca3 = banca3;


            _current.Banca4 = banca4;
            _current.Banca5 = banca5;
            _current.Banca6 = banca6;
           
        }
    }
}
