﻿using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.ServiceLayer.DTO;
using BilancioFenealgest.UI.PresentationLogicComponents;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public interface IScrittureContoRLSTFormView : IBasePresentation   
    {
        bool IsLabelVisible { set; }
        string CaptionViewText { set; }
        IGridContainer<ScrittureDTO> GridContainer { get; }
        void SetPresenter(ScrittureContoRLSTPresenter presenter);

        IScritturaSingolaContoRLSTFormView ScritturaSingolaView { get; }

        string SaldoConto { set; }

        bool ShowAndContinue();

        void Dispose();

        string ElementiTrovati { set; }
        bool IsMessaggioContoClassificazioneVisible { set; }
        bool IsAddScritturaEnabled { set; }

        bool CanFilterByDate { get; }
        string CausaleFilter { get; }
        string PezzaFilter { get; }
        DateTime DateFromFilter { get; }
        DateTime DateToFilter { get; }
        bool ViewAutogenerated { get; }
        object Invoke(Delegate method);
        object Invoke(Delegate method, params object[] args);
        bool IsWaitPanelVisible { set; }
        void NotifyTaskLabel(string text);
        void HidePanel();
    }
}
