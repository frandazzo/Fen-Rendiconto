using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace WIN.BILANCIO.PresentationLogicComponents
{
    public interface IFrmTaglia: IBasePresentation 
    {
      
        IIerarchicalContainer IerarchicalContainer { get; }
     
      

        bool ShowAndContinue();
       
        void Close();

        void Dispose();

        //bool PasteOnCassa { get; }
        //bool PasteOnAccantonamento { get; }

        void SetPresenter(FrmTagliaPresenter frmTagliaPresenter);
    }
}
