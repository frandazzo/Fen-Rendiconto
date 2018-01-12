using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.UI.PresentationLogicComponents;
using WIN.BILANCIO.ServiceLayer;
using BilancioFenealgest.DomainLayer;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.ServiceLayer.DTO;
using TestBinding;
using System.Threading;
using System.IO;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public class ScrittureContoRLSTPresenter
    {
        IScrittureContoRLSTFormView _view;
        ContoRLSTService _service;
        Conto _conto;
        delegate void SimpleDelegate();
        delegate void OneStringArgDelegate(string arg);

        public ScrittureContoRLSTPresenter(IScrittureContoRLSTFormView view, ContoRLSTService service, Conto conto)
        {
            _view = view;
            _view.SetPresenter(this);
            _service = service;
            _conto = conto;
        }

        public void InitializeForm()
        {
            LoadDataAndResetInterface(null);

        }

        private void LoadDataAndResetInterface(ScrittureSearchCriteria criteria)
        {
            IGridContainer<ScrittureDTO> grid = _view.GridContainer;
            grid.AutoGenerateColumns = false;

            SortableBindingList<ScrittureDTO> list = _service.SearchScrittureBilancio(criteria);

            AbstractBilancio b = _service.ContoRLST;




            SetCaptionText(b);
            CheckAddEnabled(b);
            CheckMessageVisibility(b);
            CheckEmptyLabelVisibility(list);
            SetFoundElements(list);
            SetColumnContoVisible(b);

            grid.SetSource(list);
            _view.SaldoConto = "Saldo conto: " + _service.Total;
        }

        private void SetColumnContoVisible(AbstractBilancio b)
        {
            Conto conto = b as Conto;
            if (conto == null)
                _view.GridContainer.IsColumnVisible(0, true);
            else
                _view.GridContainer.IsColumnVisible(0, false);
        }

        private void SetCaptionText(AbstractBilancio b)
        {
            _view.CaptionViewText = "Visualizzazione conto nascosto";
        }

        private void CheckAddEnabled(AbstractBilancio b)
        {
            Conto conto = b as Conto;
            if (conto == null)
                _view.IsAddScritturaEnabled = false;
            else
                _view.IsAddScritturaEnabled = true;
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
                _view.IsMessaggioContoClassificazioneVisible = true;
           
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


            ScritturaSingolaContoRLSTPresenter presenter = new ScritturaSingolaContoRLSTPresenter(_view.ScritturaSingolaView, _service, dto,_view);

            presenter.InitializeForm();


            presenter.StartDialog();




        }



        public void AddScrittura()
        {

            ScritturaSingolaContoRLSTPresenter presenter = new ScritturaSingolaContoRLSTPresenter(_view.ScritturaSingolaView, _service, null, _view);

            presenter.InitializeForm();


            presenter.StartDialog();

        }

        public void RemoveScrittura()
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
                    _view.SaldoConto = "Saldo conto: " + _service.Total;
                }

            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }

        }

        public void ReloadData()
        {
            InitializeForm();
        }

        public void Filter()
        {

            ScrittureSearchCriteria criteria = new ScrittureSearchCriteria();

            criteria.FilterByDate = _view.CanFilterByDate;
            criteria.FilterCausale = _view.CausaleFilter;
            criteria.FilterPezza = _view.PezzaFilter;
            criteria.DateFrom = _view.DateFromFilter;
            criteria.DateTo = _view.DateToFilter;
            criteria.NotFilterAutogenerated = _view.ViewAutogenerated;




            LoadDataAndResetInterface(criteria);


        }



     


        public void ExportToExcel()
        {
            _view.NotifyTaskLabel("Esportazione conto nascosto");
            _view.IsWaitPanelVisible = true;

            DoStampa1();
           
        }

        private void DoStampa1()
        {
            try
            {

                //string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                //filename = Path.Combine(filename, "ScrittureContoRLST.xls");

                string file = "ScrittureContoNascosto";
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

               
                _service.ExportLibroGiornale(l, filename);

              
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            finally
            {
                _view.IsWaitPanelVisible = false;
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
    }
    
}
