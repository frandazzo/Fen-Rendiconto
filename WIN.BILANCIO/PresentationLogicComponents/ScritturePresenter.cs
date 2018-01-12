using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.ServiceLayer.DTO;
using TestBinding;
using BilancioFenealgest.DomainLayer;
using System.Threading;
using System.IO;
using System.Drawing;
using WIN.BILANCIO.PresentationLogicComponents;
using System.Collections;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class ScritturePresenter
    {

        IScrittureFormView _view;
        BilancioService _service;
        string _idConto;
        delegate void SimpleDelegate();
        delegate void OneStringArgDelegate(string arg);

        public ScritturePresenter(IScrittureFormView view, BilancioService service, string idConto)
        {
            _view = view;
            _view.SetPresenter(this);
            _service = service;
           
            _idConto = idConto;

        }




        void service_ExportedRow(object sender, WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportedEventArgs fe)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Perc. esportazione: " + fe.RowPercentage.ToString("p") });
        }

        void service_EndExport(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Termine esportazione libro giornale" });
        }

        void service_BeginExport(object sender, EventArgs e)
        {
            OneStringArgDelegate s = new OneStringArgDelegate(_view.NotifyTaskLabel);
            _view.Invoke(s, new object[] { "Inizio esportazione libro giornale" });
        }

        public void InitializeForm()
        {
            LoadDataAndResetInterface(null);

        }

        private void LoadDataAndResetInterface(ScrittureSearchCriteria criteria)
        {
            IGridContainer<ScrittureDTO> grid = _view.GridContainer;
            grid.AutoGenerateColumns = false;

            SortableBindingList<ScrittureDTO> list = _service.SearchScrittureBilancio(_idConto, criteria);

            AbstractBilancio b;
            if (!string.IsNullOrEmpty(_idConto))
                b = _service.Bilancio.FindNodeById(_idConto);
            else
                b = _service.Bilancio;


            LoadSearchCombos();
            SetCaptionText(b);
            CheckAddEnabled(b);
            CheckMessageVisibility(b);
            CheckEmptyLabelVisibility(list);
            SetFoundElements(list);
            SetColumnContoVisible(b);

            grid.SetSource(TipoOperazioneDecoder.TranslateDomainValuesToListGUIValues(list, _view.Banca1, _view.Banca2, _view.Banca3, _view.Banca4, _view.Banca5, _view.Banca6));

            //sincronizzo il totale
           // decimal initialValue = 0;

            //decimal total = _service.CalculateTotalForSCritture(grid.BoundList);


            //_view.SetScrittureTotalizzation(total.ToString("c"));
            RefreshSaldoConto();
        }

        public void RefreshSaldoConto()
        {
            _service.ScriviDettagliSaldoConto(_view, _idConto);
        }


        private void LoadSearchCombo(ILookupList list, string property)
        {

            if (!string.IsNullOrEmpty(list.SelectedItem))
                return;

            //inizializzo la view con la lista delle regioni
            IList l1 = GetList(_service.GetRiferimentoLista(property));
            StringListBinder b = new StringListBinder(l1);
            b.BindTo(list);
            //seleziono il primo elemento
            list.SelectAt(-1);
        }


        private void LoadSearchCombos()
        {
            LoadSearchCombo(_view.ComboEnte, "Riferimento2");
            LoadSearchCombo(_view.ComboPersonale, "Riferimento3");
            LoadSearchCombo(_view.ComboSettore, "Riferimento1");
        }

        private IList GetList(IList<string> iList)
        {
            ArrayList l = new ArrayList();
            foreach (string item in iList)
            {
                l.Add(item);
            }
            return l;
        }
    

        private void SetColumnContoVisible(AbstractBilancio b)
        {
            Conto contoContabile = b as Conto;
            
            if (contoContabile == null)
            {
                _view.GridContainer.IsColumnVisible(0, true);

            }
            else
            {
                _view.GridContainer.IsColumnVisible(0, false);
            }


            //gestione delle colonne visibili
            if (contoContabile != null)
            {
                if (contoContabile.Description == "Tesseramento diretto" || contoContabile.Description == "Deleghe edili" || contoContabile.Description == "Deleghe impianti fissi")
                {
                    _view.GridContainer.IsColumnVisible(6, true);
                    _view.GridContainer.IsColumnVisible(7, true);
                    _view.GridContainer.IsColumnVisible(8, false);
                }
                else if (contoContabile.Description == "Retribuzioni personale (nette)" ||
                    contoContabile.Description == "Retribuzioni lorde")
                {
                    _view.GridContainer.IsColumnVisible(8, true);
                    _view.GridContainer.IsColumnVisible(6, false);
                    _view.GridContainer.IsColumnVisible(7, false);
                }
                else
                {
                    _view.GridContainer.IsColumnVisible(6, false);
                    _view.GridContainer.IsColumnVisible(7, false);
                    _view.GridContainer.IsColumnVisible(8, false);
                }
            }
            else
            {
                _view.GridContainer.IsColumnVisible(6, false);
                _view.GridContainer.IsColumnVisible(7, false);
                _view.GridContainer.IsColumnVisible(8, false);
            }







        }

        private void SetCaptionText(AbstractBilancio b)
        {

            //se il conto è un conto banca (me ne accorgo dall'id)
            //imposto il titolo del form
            if (b.Description.ToUpper() == "BANCA1")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca1;
            else if (b.Description.ToUpper() == "BANCA2")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca2;
            else if (b.Description.ToUpper() == "BANCA3")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca3;


            else if (b.Description.ToUpper() == "BANCA4")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca4;
            else if (b.Description.ToUpper() == "BANCA5")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca5;
            else if (b.Description.ToUpper() == "BANCA6")
                _view.CaptionViewText = "Visualizzazione conto: " + _view.Banca6;


            else
                _view.CaptionViewText = "Visualizzazione conto: " + b.Description.ToUpper();



        }

        private void CheckAddEnabled(AbstractBilancio b)
        {
            Conto conto = b as Conto;
            if (conto == null)
            {
                _view.IsAddScritturaEnabled = false;
                _view.IsDuplicateScritturaEnabled = false;
                _view.IsSaldoInizialeEnabled = false;
            }
            else
            {
                _view.IsAddScritturaEnabled = true;
                _view.IsDuplicateScritturaEnabled = true;
                _view.IsSaldoInizialeEnabled = true;
            }
        }

        private void SetFoundElements(SortableBindingList<ScrittureDTO> list)
        {
            _view.ElementiTrovati = "Numero di elementi trovati : " + list.Count.ToString();
        }

        private void CheckEmptyLabelVisibility(SortableBindingList<ScrittureDTO> list)
        {
            if (list.Count == 0)
                _view.IsLabelVisible = true;
            else
                _view.IsLabelVisible = false;
        }

        private void CheckMessageVisibility(AbstractBilancio b)
        {
            Conto conto = b as Conto;
            if (conto == null)
                _view.IsMessaggioContoClassificazioneVisible = true;
            else
                _view.IsMessaggioContoClassificazioneVisible = false;
        }


        public bool StartDialog()
        {
            bool result = false;
            if (_view.ShowAndContinue())
                result = true;
            _view.Dispose();
            return result;
        }


     

        public void ShowScrittura()
        {
            ScrittureDTO dto = _view.GridContainer.CurrentObject();




            if (dto == null)
                return;


            //ScritturaSingolaPresenter presenter = new ScritturaSingolaPresenter(_view.ScritturaSingolaView, _service, TipoOperazioneDecoder.TranslateDomainValuesToGUIValues(dto, _view.Banca1, _view.Banca2, _view.Banca3), _view);
            ScritturaSingolaPresenter presenter = new ScritturaSingolaPresenter(_view.ScritturaSingolaView, _service,dto, _view);

            presenter.InitializeForm();


            presenter.StartDialog();

           


        }



        public  void AddScrittura()
        {

            ScritturaSingolaPresenter presenter = new ScritturaSingolaPresenter(_view.ScritturaSingolaView, _service, _idConto , _view);

            presenter.InitializeForm();


            presenter.StartDialog();

        }

        public  void RemoveScrittura()
        {
            try
            {
                ScrittureDTO dto = _view.GridContainer.CurrentObject();

                if (dto != null)
                {
                    _service.RemoveScrittura(dto);
                    _view.GridContainer.BoundList.Remove(dto);
                    if (_view.GridContainer.BoundList.Count == 0)
                        _view.IsLabelVisible = true;
                    else
                        _view.IsLabelVisible = false;

                    //sincronizzo il totale
                    //decimal total = _service.CalculateTotalForSCritture(_view.GridContainer.BoundList);
                    //_view.SetScrittureTotalizzation(total.ToString("c"));
                    _service.ScriviDettagliSaldoConto(_view,_idConto);
                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            
        }

        public  void ReloadData()
        {
            InitializeForm();
        }

        public void Filter()
        {

            ScrittureSearchCriteria criteria = new ScrittureSearchCriteria ();

            criteria.FilterByDate = _view.CanFilterByDate;
            criteria.FilterCausale  = _view.CausaleFilter;
            criteria.FilterPezza = _view.PezzaFilter;
            criteria.DateFrom = _view.DateFromFilter;
            criteria.DateTo = _view.DateToFilter;
            criteria.NotFilterAutogenerated = _view.ViewAutogenerated;
            criteria.FilterRiferimento1 = _view.ComboSettore.SelectedItem;
            criteria.FilterRiferimento2 = _view.ComboEnte.SelectedItem;
            criteria.FilterRiferimento3 = _view.ComboPersonale.SelectedItem;



            LoadDataAndResetInterface(criteria);

            
        }

        public void ExportToExcel()
        {
            _view.IsWaitPanelVisible = true;

            Thread t = new Thread(new ThreadStart(DoStampa));
            t.Start();
        }

        private void DoStampa()
        {
            try
            {
                string file = "ScrittureRendiconto" + _view.MainHeader;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string filename = Path.Combine(path, file + ".xls");

                int i = 0;
                while (System.IO.File.Exists(filename)) 
                {
                    i++;
                    filename = Path.Combine(path, file + i.ToString() + ".xls");
                } 
             



                //ScrittureSearchCriteria c = new ScrittureSearchCriteria();
                //c.NotFilterAutogenerated = true;


                IList<ScrittureDTO> l = CreateList(_view.GridContainer.BoundList);

                _service.BeginExport += new EventHandler(service_BeginExport);
                _service.EndExport += new EventHandler(service_EndExport);
                _service.ExportedRow += new WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportEventHandler(service_ExportedRow);


                if (!string.IsNullOrEmpty(_idConto))
                {
                    decimal initValue = 0;
                    _service.CalculateTotalForSCritture(_view.GridContainer.BoundList, _idConto, ref initValue);

                    _service.ExportLibroGiornale(l, filename, _view.GroupByConto, initValue);

                }
                else
                    _service.ExportLibroGiornale(l, filename, _view.GroupByConto, 0);


                

                _service.BeginExport -= new EventHandler(service_BeginExport);
                _service.EndExport -= new EventHandler(service_EndExport);
                _service.ExportedRow -= new WIN.BILANCIO.ServiceLayer.ExcelExporter.ExcelMastroPrinter.RowExportEventHandler(service_ExportedRow);

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            finally
            {
                SimpleDelegate d = _view.HidePanel;
                _view.Invoke(d);
            }
        }

        private IList<ScrittureDTO> CreateList(System.Collections.IList iList)
        {
            List<ScrittureDTO> l = new List<ScrittureDTO>();

            foreach (ScrittureDTO item in iList)
            {
                l.Add(item);
            }

            l.Sort(ScrittureDTO.CompareByDate);

            return l;
        }

        public void Duplicate()
        {
            ScrittureDTO dto = _view.GridContainer.CurrentObject();

            if (dto == null)
            {
                _view.GetSimpleMessageNotificator().Show("Selezionare una scrittura", "Messaggio", MessageType.Exclamation);

                return;
            }

            if (dto.AutoGenerated)
            {
                _view.GetSimpleMessageNotificator().Show("Impossibile duplicare una scrittura autogenerata!", "Messaggio", MessageType.Error);

                return;
            }


           
            ScritturaSingolaPresenter presenter = new ScritturaSingolaPresenter(_view.ScritturaSingolaView, _service, _idConto, _view, dto);


            presenter.InitializeForm();


            presenter.StartDialog();

        }

        public void ChooseIfShowMenu(Point p,bool rightButton)
        {

            //if (dto.AutoGenerated)
            //{
            //    _view.GetSimpleMessageNotificator().Show("Impossibile tagliare e incollare scritture da un conto finanziario!", "Messaggio", MessageType.Error);

            //    return;
            //}
            if (!rightButton )
                return;


            if (_view.SelectedRowsCount > 0)
            {
                _view.ShowContextMenu(_view.GridContainer.ConcreteWidget, p);
            }
            else
                _view.HideContextMenu();
        }

        public void PrepareToPaste()
        {
            FrmTagliaPresenter pres = new FrmTagliaPresenter(_view.FrmTagliaView, _service, _view,this );
            pres.InitializeForm();
            pres.StartDialog();


            //sincronizzo il totale
            //decimal total = _service.CalculateTotalForSCritture(_view.GridContainer.BoundList);
            //_view.SetScrittureTotalizzation(total.ToString("c"));
            _service.ScriviDettagliSaldoConto(_view, _idConto);
        }

        public void PrepareToDelete()
        {
            try
            {
                IList<ScrittureDTO> dtos = _view.GridContainer.CurrentObjects();


                bool continueDeleting = _view.GetSimpleMessageNotificator().ShowAndContibue("Sicuro di voler procedere?", "Domanda") ;

                if (continueDeleting) 
                {
                    foreach (ScrittureDTO item in dtos)
                    {
                        if (!item.AutoGenerated)
                        {
                            _service.RemoveScrittura(item);
                            _view.GridContainer.BoundList.Remove(item);
                        }
                    }


                    if (_view.GridContainer.BoundList.Count == 0)
                        _view.IsLabelVisible = true;
                    else
                        _view.IsLabelVisible = false;


                    //sincronizzo il totale
                    //decimal total = _service.CalculateTotalForSCritture(_view.GridContainer.BoundList);
                    //_view.SetScrittureTotalizzation(total.ToString("c"));
                    _service.ScriviDettagliSaldoConto(_view, _idConto);

                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error );
            }
        }

        public void SetSaldo()
        {
            try
            {


                ImportoContoPresenter presenter = new ImportoContoPresenter(_view.ImportoFormView, _service, _idConto, this);


                presenter.InitializeForm();

                presenter.StartDialog();

                

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }
    }
}
