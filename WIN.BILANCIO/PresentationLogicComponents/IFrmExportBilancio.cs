using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public interface IFrmExportBilancio : IBasePresentation
    {
        string UserName { get; }
        string Password { get; }
        void SetPresenter(ExportBilancioPresenter presenter);
        bool IsRlst { get; }
        bool IsFeneal { get; }
        void ShowDialogMode();
    }
}
