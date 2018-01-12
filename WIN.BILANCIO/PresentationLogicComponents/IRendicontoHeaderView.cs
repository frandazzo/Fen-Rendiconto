using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface IRendicontoHeaderView : IBasePresentation 
    {
        bool ShowAndContinue();
        void Dispose();
        void SetPresenter(RendicontoHeaderFormPresenter presenter);

        ILookupList ComboRegioni { get; }
        ILookupList ComboProvincie { get; }

        bool IsRlst { get; }
        bool IsFeneal { get; }

        bool IsComboProvincieEnabled{get;set;}
        bool IsFileInfoVisible { get; set; }
        bool IsBilancioOptionsEnabled { get; set; }


        void ClearComboProvincie();

        bool IsRegionaleTypeChecked { get; set; }
        string SelectedRegion { get; set; }
        string SelectedProprietario { get; set; }
        string SelectedProvince { get; set; }
        int SelectedYear { get; set; }

        string FileName { get; }

        bool IsFreeTemplate { get; }

        bool IsBilancioOptionsVisible { set; }
        void SetTestoProprietario();
        bool AreGeoComboVisible { set; }
      
    }
}
