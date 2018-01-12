using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.DomainLayer
{
    public interface  IRendicontoFactory
    {

        Rendiconto GetNewRendiconto(string provincia, int anno, string regione, bool isRegionale);
       

    }
}
