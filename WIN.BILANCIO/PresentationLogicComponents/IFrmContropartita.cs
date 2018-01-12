using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public interface IFrmContropartita : IBasePresentation 
    {
        IIerarchicalContainer IerarchicalContainer { get; }

        bool ShowAndContinue();

        void Close();

        void Dispose();

        void SetDialogoResultToOK();


        void SetPresenter(FrmContropartitaPresenter frmContropartitaPresenter);

       
    }
}
