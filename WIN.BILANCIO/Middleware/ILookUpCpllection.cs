using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.Middleware
{
    public interface ILookupCollection
    {
        void BindTo(ILookupList list);
    }
}
