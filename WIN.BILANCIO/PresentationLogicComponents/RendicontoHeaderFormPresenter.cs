using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer;
using BilancioFenealgest.Middleware;
using WIN.BASEREUSE;
using BilancioFenealgest.ServiceLayer.DTO;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{



    public class RendicontoHeaderFormPresenter 
    {

        IRendicontoHeaderView _view;
        RendicontoService _service;
        ActionType _type;
       

        private string _createdBilancio = "";


        public string CreatedBilancioPath
        {
            get
            {
                return _createdBilancio;
            }
        }

        public RendicontoHeaderFormPresenter(IRendicontoHeaderView view, RendicontoService service, ActionType type )
        {
            _service = service;
            _type = type;
            _view = view;
          
        }

        public void InitializeView( )
        {
            //imposto il testo per la label del proprietario
            _view.SetTestoProprietario();

            ILookupList l = _view.ComboRegioni;
            //inizializzo la view con la lista delle regioni
            StringListBinder b = new StringListBinder(GeoLocationFacade.Instance().GetGeoHandler().GetListaNomiRegioni());
            b.BindTo(l);
            //seleziono il primo elemento
            l.SelectAt(0);



            if (_type == ActionType.New)
            {
                _view.IsBilancioOptionsEnabled = true;
                _view.IsFileInfoVisible = true;
                //poichè il tipo regionale è impostato all'inizio
                //disabilito il combo province
                SetInterfaceFromType();
                _view.SelectedYear = DateTime.Now.Year;

            }
            else
            {
                //carico i dati dal dto
                RendicontoHeaderDTO dto = _service.RendicontoHeader;
                _view.SelectedProprietario = dto.Proprietario;
                _view.SelectedYear = dto.Anno;

                if (!_view.IsFreeTemplate)
                {
                    SetInterfaceFromType();
                    _view.IsRegionaleTypeChecked = dto.IsRegionale;

                    _view.SelectedRegion = dto.Regione;

                    _view.SelectedProvince = dto.Provincia;

                    _view.IsBilancioOptionsEnabled = false;
                    _view.IsFileInfoVisible = false;
                   
                }
                else
                {
                    _view.IsBilancioOptionsVisible = false;
                    _view.IsFileInfoVisible = false;
                    _view.AreGeoComboVisible = true;

                    SetInterfaceFromType();
                    _view.IsRegionaleTypeChecked = dto.IsRegionale;

                    _view.SelectedRegion = dto.Regione;

                    _view.SelectedProvince = dto.Provincia;
                }
            }
        }

        public bool  StartDialog()
        {
            bool result = false;
            if (_view.ShowAndContinue())
                result = true;
            _view.Dispose();
            return result;
        }


        public  void SetComboProvince()
        {
            if (!_view.IsRegionaleTypeChecked)
            {
                LoadProvince();
            }
        }

        private void LoadProvince()
        {
            StringListBinder b1 = new StringListBinder(GeoLocationFacade.Instance().GetGeoHandler().GetNomiProviciePerRegione(_view.SelectedRegion));
            b1.BindTo(_view.ComboProvincie);
            _view.ComboProvincie.SelectAt(0);
        }

        public void ChangeBilancioType()
        {
            if (_type == ActionType.Update)
                return;

            SetInterfaceFromType();


        }

        private void SetInterfaceFromType()
        {
            if (_view.IsRegionaleTypeChecked)
            {
                _view.ComboProvincie.Clear();
                _view.IsComboProvincieEnabled = false;
            }
            else
            {
                _view.IsComboProvincieEnabled = true;
                LoadProvince();
            }
        }

        private void UpdateHeader()
        {
            RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
            dto.Anno = _view.SelectedYear;
            dto.Proprietario= _view.SelectedProprietario;
            dto.Provincia = _view.SelectedProvince;
            dto.Regione = _view.SelectedRegion;
            _service.RendicontoHeader = dto;
        }

        public  void CreateBilancioOrUpdateHeader()
        {
            
                if (_type == ActionType.Update)
                {
                    UpdateHeader();
                }
                else
                {
                    CreateBilancio();
                }
            
            
            
        }

        private void CreateBilancio()
        {

            RendicontoHeaderDTO dto;
            try
            {
                dto = CreaDTO();

                string pp = "";

                IOpenFileClass c = _view.GetFolderBrowserDialog();
                if (c.ShowAndContinue())
                    pp = c.GetFileName();
                else
                    pp = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                dto.FolderPath = pp ;
                
                _createdBilancio = _service.CreateNewRendiconto(dto);
               
            }
            catch (Exception)
            {
                try
                {
                    dto = CreaDTO();

                    IOpenFileClass h = _view.GetFolderBrowserDialog();

                    if (h.ShowAndContinue() == true)
                        dto.FolderPath = h.GetFileName();
                    else
                        throw new Exception("Impossibile salvare il nuovo rendiconto");

                    
                        _createdBilancio = _service.CreateNewRendiconto(dto);
                   
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        
            
        }

        private RendicontoHeaderDTO CreaDTO()
        {
            RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
            dto.Anno = _view.SelectedYear; 
            dto.Proprietario = _view.SelectedProprietario;
            dto.FileName = _view.FileName;
            dto.Provincia = _view.SelectedProvince;

            dto.IsRegionale = _view.IsRegionaleTypeChecked;
            dto.Regione = _view.SelectedRegion;

            if (_view.IsFeneal)
                dto.SenderTag = "FENEAL";
            else if (_view.IsRlst)
                dto.SenderTag = "RLST";
            else
                dto.SenderTag = "NOESIS";



            return dto;
        }
    }
}
