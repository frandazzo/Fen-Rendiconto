using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface IFrmContoView
    {
        decimal SelectedImporto { get; set; }


        void ShowDialogMode();


        string CaptionText { set; }

        void SetPresenter(ImportoContoPresenter importoContoPresenter);

        void Close();
    }
}
