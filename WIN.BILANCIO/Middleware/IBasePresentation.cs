using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.Middleware
{
    public interface IBasePresentation 
    {
       IMessageBox GetSimpleMessageNotificator();
       IOpenFileClass GetOpenFileDialog();
       IOpenFileClass GetFolderBrowserDialog();
    }
}
