using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public interface IScritturaSingolaContoRLSTFormView : IBasePresentation 
    {
        string SelectedCausale { get; set; }
        string SelectedNumeroPezza { get; set; }
        decimal SelecteImporto { get; set; }
        DateTime SelectedDate { get; set; }
        void SetPresenter(ScritturaSingolaContoRLSTPresenter presenter);

        ILookupList ComboTipoOperazione { get; }

       

        bool IsContainerEnabled { set; }
        bool IsOkButtonEnabled { set; }
        bool IsRecreateNewButtonEnabled { set; }
        void Close();
        bool ShowAndContinue();

        void Dispose();

        void SetInitialFocus();
    }
}
