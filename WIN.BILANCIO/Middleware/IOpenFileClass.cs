using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.Middleware
{
    public interface IOpenFileClass
    {
        bool ShowAndContinue();
        string GetFileName();
        void SetFilter(string filter);
    }
}
