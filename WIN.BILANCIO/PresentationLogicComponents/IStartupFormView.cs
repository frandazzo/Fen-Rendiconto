using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface IStartupFormView : IBasePresentation
    {
        void SetHeader();
       
        IRendicontoHeaderView RendicontoHeaderView { get; }

        IBilancioFormView BilancioView(string idBilancio);

        bool IsFreeTemplate { get; }


        string FileFreeTemplate { get; }


    }
}
