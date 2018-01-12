using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using WIN.BILANCIO.PresentationLogicComponents;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface IScritturaSingloaView : IBasePresentation 
    {

        string SelectedCausale { get; set; }
        string SelectedNumeroPezza { get; set; }
        decimal SelecteImporto { get; set; }
        DateTime SelectedDate { get; set; }
        void SetPresenter(ScritturaSingolaPresenter presenter);

        ILookupList ComboTipoOperazione { get; }
        IFrmContropartita GetFrmContropartita { get; }

        bool IsContainerEnabled { set; }
        bool IsOkButtonEnabled { set; }
        bool IsRecreateNewButtonEnabled { set; }
        void Close();
        bool ShowAndContinue();

        ILookupList ComboEnte { get; }
        ILookupList ComboPersonale { get; }
        ILookupList ComboSettore { get; }

        void Dispose();

        void SetInitialFocus();

        void ShowPropertyInLayout(string property);

        void ShowContropartitaDetails(string contoName);
        void HideContropartitadetails();


        string Banca1 { get; }
        string Banca2 { get; }
        string Banca3 { get; }

        string Banca4 { get; }
        string Banca5 { get; }
        string Banca6 { get; }

    }
}
