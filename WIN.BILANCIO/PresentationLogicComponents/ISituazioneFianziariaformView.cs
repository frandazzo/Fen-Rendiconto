using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public interface ISituazioneFianziariaformView
    {

        bool ShowAndContinue();
        void Dispose();
        void SetPresenter(SituazioneFinanziariaPresenter presenter);


        decimal SelectedBanca { get; set; }
        decimal SelectedBanca2 { get; set; }
        decimal SelectedAccantonamenti { get; set; }
        decimal SelectedCassa { get; set; }

        bool IsLabelCassaVisible { set; }
        bool IsNumUpDownCassaVisible { set; }
        bool IsLabelAccantonamentoVisible { set; }
        bool IsNumUpDownAccantonamentoVisible { set; }

        string ViewCaption { set; }

        decimal SelectedBanca3 { get; set; }
    }
}
